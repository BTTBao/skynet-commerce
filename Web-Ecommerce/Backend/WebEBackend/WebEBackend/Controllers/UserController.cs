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

        public UserController(SkynetCommerceContext context)
        {
            _context = context;
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
                    // Ghép chuỗi địa chỉ đầy đủ để hiển thị cho đẹp
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

            // Logic: Nếu user chọn địa chỉ này là Mặc định -> Phải bỏ mặc định của tất cả địa chỉ cũ
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

            // Tạo đối tượng UserAddress từ dữ liệu Frontend gửi lên
            var newAddress = new UserAddress
            {
                AccountId = accountId,
                AddressName = request.AddressName,      // Ví dụ: "Nhà riêng", "Văn phòng"
                ReceiverFullName = request.ReceiverFullName,
                ReceiverPhone = request.ReceiverPhone,
                Province = request.Province,            // Lưu tên Tỉnh (VD: Hà Nội)
                District = request.District,            // Lưu tên Huyện (VD: Cầu Giấy)
                Ward = request.Ward,                    // Lưu tên Xã (VD: Dịch Vọng)
                AddressLine = request.AddressLine,      // Số nhà cụ thể
                IsDefault = request.IsDefault
            };

            _context.UserAddresses.Add(newAddress);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Thêm địa chỉ thành công!" });
        }

        // ==========================================
        // 3. ĐĂNG KÝ LÀM NGƯỜI BÁN (SELLER)
        // ==========================================
        [HttpPost("register-shop")]
        public async Task<IActionResult> RegisterShop([FromBody] ShopRegisterRequest request)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            // Kiểm tra xem đã gửi đơn chưa (tránh spam)
            var existingRequest = await _context.ShopRegistrations
                .FirstOrDefaultAsync(r => r.AccountId == accountId && r.Status == "Pending");

            if (existingRequest != null)
            {
                return BadRequest(new { message = "Bạn đang có một yêu cầu chờ duyệt rồi." });
            }

            // Kiểm tra xem đã là Seller chưa
            var isSeller = await _context.UserRoles
                .AnyAsync(ur => ur.AccountId == accountId && ur.RoleName == "Seller");

            if (isSeller)
            {
                return BadRequest(new { message = "Tài khoản này đã là Người bán hàng." });
            }

            // Tạo yêu cầu mới
            var registration = new ShopRegistration
            {
                AccountId = accountId,
                ShopName = request.ShopName,
                Description = request.Description,
                Status = "Pending",
                CreatedAt = DateTime.Now
            };

            _context.ShopRegistrations.Add(registration);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Gửi yêu cầu thành công! Vui lòng chờ Admin duyệt." });
        }

        // ==========================================
        // HÀM PHỤ: LẤY ID TỪ TOKEN
        // ==========================================
        private int GetCurrentAccountId()
{
    var identity = User.Identity as ClaimsIdentity;
    
    // 1. Kiểm tra xem đã xác thực thành công chưa?
    if (identity == null || !identity.IsAuthenticated)
    {
        Console.WriteLine(">>> DEBUG: User chưa đăng nhập hoặc Token không hợp lệ.");
        return -1;
    }

    // 2. In ra tất cả các Claim mà Backend nhận được
    Console.WriteLine(">>> DEBUG: Danh sách Claims nhận được:");
    foreach (var c in identity.Claims)
    {
        Console.WriteLine($" - Type: {c.Type}, Value: {c.Value}");
    }

    // 3. Thử lấy ID theo nhiều cách khác nhau (để tránh lệch tên)
    // Cách chuẩn .NET
    var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
    
    // Nếu không thấy, thử tìm theo tên ngắn "nameid" (đôi khi JWT map về cái này)
    if (claim == null) claim = identity.FindFirst("nameid");
    
    // Nếu vẫn không thấy, thử tìm theo "id"
    if (claim == null) claim = identity.FindFirst("id");

    if (claim == null)
    {
        Console.WriteLine(">>> DEBUG: Không tìm thấy Claim chứa AccountId.");
        return -1;
    }

    Console.WriteLine($">>> DEBUG: Tìm thấy AccountId = {claim.Value}");
    return int.Parse(claim.Value);
}   
    }

    // ==========================================
    // CÁC CLASS DTO (DATA TRANSFER OBJECT)
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
    }
}