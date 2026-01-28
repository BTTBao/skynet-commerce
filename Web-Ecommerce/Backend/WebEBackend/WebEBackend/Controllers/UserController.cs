using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebEBackend.Models;

namespace WebEBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bắt buộc phải đăng nhập
    public class UserController : ControllerBase
    {
        private readonly SkynetCommerceContext _context;
        private readonly IWebHostEnvironment _env;

        public UserController(SkynetCommerceContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // ==========================================
        // 1. LẤY DANH SÁCH ĐỊA CHỈ
        // ==========================================
        [HttpGet("addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var addresses = await _context.UserAddresses
                .Where(a => a.AccountId == accountId)
                .Select(a => new
                {
                    a.AddressId,
                    a.AddressName,
                    a.ReceiverFullName,
                    a.ReceiverPhone,
                    FullAddress = $"{a.AddressLine}, {a.Ward}, {a.District}, {a.Province}",
                    a.IsDefault
                })
                .ToListAsync();

            return Ok(addresses);
        }

        // ==========================================
        // 2. THÊM ĐỊA CHỈ MỚI
        // ==========================================
        [HttpPost("addresses")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddressRequest request)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            if (request.IsDefault)
            {
                var defaultAddresses = await _context.UserAddresses
                    .Where(a => a.AccountId == accountId && a.IsDefault == true)
                    .ToListAsync();
                
                foreach (var addr in defaultAddresses)
                {
                    addr.IsDefault = false;
                }
            }

            var newAddress = new UserAddress
            {
                AccountId = accountId,
                AddressName = request.AddressName,
                ReceiverFullName = request.ReceiverFullName,
                ReceiverPhone = request.ReceiverPhone,
                Province = request.Province,
                District = request.District,
                Ward = request.Ward,
                AddressLine = request.AddressLine,
                IsDefault = request.IsDefault
            };

            _context.UserAddresses.Add(newAddress);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Thêm địa chỉ thành công!" });
        }

        // ==========================================
        // 3. KIỂM TRA TRẠNG THÁI SHOP
        // ==========================================
        [HttpGet("shop-status")]
        public async Task<IActionResult> GetShopStatus()
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();
            
            // 1. Kiểm tra bảng Shops (Ưu tiên 1)
            var existingShop = await _context.Shops.FirstOrDefaultAsync(s => s.AccountId == accountId);
            if (existingShop != null)
            {
                return Ok(new ShopStatusResponse { Status = "Approved", Message = "Bạn đã có Shop." });
            }

            // 2. Lấy đơn đăng ký MỚI NHẤT
            var latestReg = await _context.ShopRegistrations
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync(r => r.AccountId == accountId);

            // 3. Phân loại trạng thái
            if (latestReg != null)
            {
                if (latestReg.Status == "Pending")
                {
                    return Ok(new ShopStatusResponse { Status = "Pending", Message = "Đơn đăng ký đang chờ duyệt." });
                }
                
                if (latestReg.Status == "Rejected")
                {
                    return Ok(new ShopStatusResponse { 
                        Status = "Rejected", 
                        Message = latestReg.RejectionReason ?? "Hồ sơ không đạt yêu cầu." 
                    });
                }

                // 👇 THÊM ĐOẠN NÀY: Nếu đơn đã Approved nhưng chưa có trong bảng Shops
                if (latestReg.Status == "Approved")
                {
                    return Ok(new ShopStatusResponse { Status = "Approved", Message = "Đơn đã được duyệt." });
                }
            }

            return Ok(new ShopStatusResponse { Status = "None", Message = "Chưa đăng ký." });
        }

        // ==========================================
        // 4. ĐĂNG KÝ SHOP (ĐÃ FIX LỖI PATH NULL)
        // ==========================================
        [HttpPost("register-shop")]
        public async Task<IActionResult> RegisterShop([FromForm] ShopRegisterRequest request)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            // --- CHECK 1: User này đã có Shop Active chưa? ---
            var hasShop = await _context.Shops.AnyAsync(s => s.AccountId == accountId);
            if (hasShop) return BadRequest(new { message = "Bạn đã sở hữu một cửa hàng rồi." });

            // --- CHECK 2: User này có đang Pending không? ---
            var isPending = await _context.ShopRegistrations.AnyAsync(r => r.AccountId == accountId && r.Status == "Pending");
            if (isPending) return BadRequest(new { message = "Bạn đang có đơn chờ duyệt. Vui lòng chờ kết quả." });

            // --- CHECK 3: TÊN SHOP CÓ BỊ TRÙNG KHÔNG? ---
            if (await _context.Shops.AnyAsync(s => s.ShopName == request.ShopName))
                return BadRequest(new { message = $"Tên Shop '{request.ShopName}' đã tồn tại. Vui lòng chọn tên khác." });
            
            if (await _context.ShopRegistrations.AnyAsync(r => r.ShopName == request.ShopName && r.Status == "Pending" && r.AccountId != accountId))
                return BadRequest(new { message = $"Tên Shop '{request.ShopName}' đang được người khác đăng ký." });

            // --- CHECK 4: CCCD CÓ BỊ TRÙNG KHÔNG? ---
            // Fix: Sử dụng CitizenId (chữ d thường)
             if (await _context.ShopRegistrations.AnyAsync(r => r.CitizenId == request.CitizenID && r.Status == "Pending" && r.AccountId != accountId))
                return BadRequest(new { message = "Số CCCD này đang được sử dụng trong một đơn đăng ký khác." });

            // --- XỬ LÝ LƯU ẢNH (QUAN TRỌNG: FIX LỖI NULL PATH) ---
            string imagePath = null;
            if (request.CitizenImage != null)
            {
                var fileName = $"{Guid.NewGuid()}_{request.CitizenImage.FileName}";
                
                // FIX: Nếu WebRootPath null thì lấy ContentRootPath + "wwwroot"
                string rootPath = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
                
                var uploadsFolder = Path.Combine(rootPath, "uploads", "identity");
                
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
                
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.CitizenImage.CopyToAsync(stream);
                }
                imagePath = $"/uploads/identity/{fileName}"; 
            }

            // --- TẠO ĐƠN MỚI ---
            var registration = new ShopRegistration
            {
                AccountId = accountId, 
                ShopName = request.ShopName,
                Description = request.Description,
                CitizenId = request.CitizenID,
                CitizenImageUrl = imagePath,
                Status = "Pending",
                CreatedAt = DateTime.Now
            };

            _context.ShopRegistrations.Add(registration);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã gửi đơn đăng ký thành công!" });
        }

        // ==========================================
        // HÀM PHỤ: LẤY ID TỪ TOKEN
        // ==========================================
        private int GetCurrentAccountId()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null || !identity.IsAuthenticated) return -1;

            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) claim = identity.FindFirst("nameid");
            if (claim == null) claim = identity.FindFirst("id");

            return claim != null ? int.Parse(claim.Value) : -1;
        }
    }

    // ==========================================
    // CÁC CLASS DTO
    // ==========================================
    
    public class AddAddressRequest
    {
        public string AddressName { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverPhone { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string AddressLine { get; set; }
        public bool IsDefault { get; set; }
    }

    public class ShopRegisterRequest
    {
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string CitizenID { get; set; } 
        public IFormFile CitizenImage { get; set; } 
    }

    public class ShopStatusResponse
    {
        public string Status { get; set; } 
        public string Message { get; set; }
    }
}