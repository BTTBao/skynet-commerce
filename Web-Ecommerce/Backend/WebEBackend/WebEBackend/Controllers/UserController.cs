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
        // 1. LẤY DANH SÁCH ĐỊA CHỈ (Đã sắp xếp Mặc định lên đầu)
        // ==========================================
        [HttpGet("addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var addresses = await _context.UserAddresses
                .Where(a => a.AccountId == accountId)
                .OrderByDescending(a => a.IsDefault)
                .Select(a => new
                {
                    a.AddressId,
                    a.AddressName,
                    a.ReceiverFullName,
                    a.ReceiverPhone,
                    
                    // 👇 BỔ SUNG CÁC DÒNG NÀY (NẾU THIẾU) 👇
                    a.AddressLine, 
                    a.Ward,
                    a.District,
                    a.Province,
                    // ----------------------------------------

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

            // Nếu user chọn địa chỉ mới là mặc định -> Bỏ mặc định các cái cũ
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
            
            var existingShop = await _context.Shops.FirstOrDefaultAsync(s => s.AccountId == accountId);
            if (existingShop != null)
            {
                return Ok(new ShopStatusResponse { Status = "Approved", Message = "Bạn đã có Shop." });
            }

            var latestReg = await _context.ShopRegistrations
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync(r => r.AccountId == accountId);

            if (latestReg != null)
            {
                if (latestReg.Status == "Pending")
                    return Ok(new ShopStatusResponse { Status = "Pending", Message = "Đơn đăng ký đang chờ duyệt." });
                
                if (latestReg.Status == "Rejected")
                    return Ok(new ShopStatusResponse { Status = "Rejected", Message = latestReg.RejectionReason ?? "Hồ sơ không đạt yêu cầu." });

                if (latestReg.Status == "Approved")
                    return Ok(new ShopStatusResponse { Status = "Approved", Message = "Đơn đã được duyệt." });
            }

            return Ok(new ShopStatusResponse { Status = "None", Message = "Chưa đăng ký." });
        }

        // ==========================================
        // 4. ĐĂNG KÝ SHOP
        // ==========================================
        [HttpPost("register-shop")]
        public async Task<IActionResult> RegisterShop([FromForm] ShopRegisterRequest request)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            if (await _context.Shops.AnyAsync(s => s.AccountId == accountId))
                return BadRequest(new { message = "Bạn đã sở hữu một cửa hàng rồi." });

            if (await _context.ShopRegistrations.AnyAsync(r => r.AccountId == accountId && r.Status == "Pending"))
                return BadRequest(new { message = "Bạn đang có đơn chờ duyệt." });

            if (await _context.Shops.AnyAsync(s => s.ShopName == request.ShopName))
                return BadRequest(new { message = $"Tên Shop '{request.ShopName}' đã tồn tại." });
            
            if (await _context.ShopRegistrations.AnyAsync(r => r.ShopName == request.ShopName && r.Status == "Pending" && r.AccountId != accountId))
                return BadRequest(new { message = $"Tên Shop '{request.ShopName}' đang được đăng ký bởi người khác." });

             if (await _context.ShopRegistrations.AnyAsync(r => r.CitizenId == request.CitizenID && r.Status == "Pending" && r.AccountId != accountId))
                return BadRequest(new { message = "Số CCCD này đang được sử dụng trong đơn khác." });

            string imagePath = null;
            if (request.CitizenImage != null)
            {
                var fileName = $"{Guid.NewGuid()}_{request.CitizenImage.FileName}";
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
        // 5. XÓA ĐỊA CHỈ
        // ==========================================
        [HttpDelete("addresses/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var accountId = GetCurrentAccountId();
            var address = await _context.UserAddresses.FirstOrDefaultAsync(a => a.AddressId == id && a.AccountId == accountId);

            if (address == null) return NotFound(new { message = "Địa chỉ không tồn tại" });
            
            // ✅ FIX LỖI: So sánh bool? với true
            if (address.IsDefault == true) 
                return BadRequest(new { message = "Không thể xóa địa chỉ mặc định. Hãy chọn địa chỉ khác làm mặc định trước." });

            _context.UserAddresses.Remove(address);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Xóa địa chỉ thành công" });
        }

        // ==========================================
        // 6. ĐẶT LÀM MẶC ĐỊNH (SET DEFAULT)
        // ==========================================
        [HttpPut("addresses/{id}/set-default")]
        public async Task<IActionResult> SetDefaultAddress(int id)
        {
            var accountId = GetCurrentAccountId();
            
            // 1. Bỏ mặc định của tất cả địa chỉ cũ
            var allAddresses = await _context.UserAddresses.Where(a => a.AccountId == accountId).ToListAsync();
            foreach (var addr in allAddresses)
            {
                addr.IsDefault = false;
            }

            // 2. Set mặc định cho địa chỉ được chọn
            var targetAddress = allAddresses.FirstOrDefault(a => a.AddressId == id);
            if (targetAddress == null) return NotFound(new { message = "Địa chỉ không tồn tại" });

            targetAddress.IsDefault = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã đặt làm địa chỉ mặc định" });
        }

        // ==========================================
        // 7. CẬP NHẬT ĐỊA CHỈ (EDIT)
        // ==========================================
        [HttpPut("addresses/{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddAddressRequest request)
        {
            var accountId = GetCurrentAccountId();
            var address = await _context.UserAddresses.FirstOrDefaultAsync(a => a.AddressId == id && a.AccountId == accountId);

            if (address == null) return NotFound();

            // Nếu user sửa thành mặc định -> reset các cái cũ
            if (request.IsDefault)
            {
                var defaults = await _context.UserAddresses.Where(a => a.AccountId == accountId && a.IsDefault == true).ToListAsync();
                foreach(var d in defaults) d.IsDefault = false;
            }

            // Cập nhật thông tin
            address.AddressName = request.AddressName;
            address.ReceiverFullName = request.ReceiverFullName;
            address.ReceiverPhone = request.ReceiverPhone;
            address.Province = request.Province;
            address.District = request.District;
            address.Ward = request.Ward;
            address.AddressLine = request.AddressLine;
            address.IsDefault = request.IsDefault;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật thành công" });
        }

        // ==========================================
        // HÀM PHỤ & DTO
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