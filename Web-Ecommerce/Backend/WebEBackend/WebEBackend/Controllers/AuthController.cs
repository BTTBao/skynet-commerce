using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebEBackend.Models;
using BCrypt.Net; 
using Microsoft.AspNetCore.Authorization;
namespace WebEBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SkynetCommerceContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(SkynetCommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // ==========================================
        // 1. ĐĂNG KÝ (REGISTER)
        // ==========================================
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // 1. Kiểm tra Email hoặc Phone đã tồn tại chưa
            if (await _context.Accounts.AnyAsync(a => a.Email == request.Email))
            {
                return BadRequest(new { message = "Email này đã được sử dụng." });
            }
            if (await _context.Accounts.AnyAsync(a => a.Phone == request.Phone))
            {
                return BadRequest(new { message = "Số điện thoại này đã được sử dụng." });
            }

            // Dùng Transaction để đảm bảo tạo Account + User + Role + Cart cùng lúc
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 2. Tạo Account (Bảng Accounts)
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                var newAccount = new Account
                {
                    Email = request.Email,
                    Phone = request.Phone,
                    PasswordHash = passwordHash,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                _context.Accounts.Add(newAccount);
                await _context.SaveChangesAsync(); // Lưu để lấy AccountId

                // 3. Tạo User Profile (Bảng Users)
                var newUser = new User
                {
                    AccountId = newAccount.AccountId,
                    FullName = request.FullName,
                    // Các trường khác như Gender, Avatar để null hoặc mặc định
                };
                _context.Users.Add(newUser);

                // 4. Gán quyền mặc định là "Buyer" (Bảng UserRoles)
                var newRole = new UserRole
                {
                    AccountId = newAccount.AccountId,
                    RoleName = "Buyer",
                    CreatedAt = DateTime.Now
                };
                _context.UserRoles.Add(newRole);

                // 5. Tạo luôn Giỏ hàng rỗng (Bảng Carts)
                var newCart = new Cart
                {
                    AccountId = newAccount.AccountId,
                    CreatedAt = DateTime.Now
                };
                _context.Carts.Add(newCart);

                // Lưu tất cả
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = "Đăng ký thành công!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        // ==========================================
        // 2. ĐĂNG NHẬP (LOGIN)
        // ==========================================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // 1. Tìm Account, Join sang bảng Users và UserRoles
            var account = await _context.Accounts
                .Include(a => a.User)       // Để lấy FullName
                .Include(a => a.UserRoles)  // Để lấy Role (Buyer/Seller/Admin)
                .FirstOrDefaultAsync(a => a.Email == request.Email);

            // 2. Kiểm tra tài khoản
            if (account == null)
            {
                return Unauthorized(new { message = "Email hoặc mật khẩu không đúng." });
            }

            if (account.IsActive == false)
            {
                return Unauthorized(new { message = "Tài khoản đã bị khóa." });
            }

            // 3. Kiểm tra mật khẩu (So sánh Hash)
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, account.PasswordHash);
            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Email hoặc mật khẩu không đúng." });
            }

            // 4. Tạo Token
            var token = GenerateJwtToken(account);

            // 5. Trả về kết quả
            return Ok(new
            {
                token = token,
                user = new
                {
                    id = account.AccountId,
                    name = account.User?.FullName ?? "Người dùng", // Lấy từ bảng Users
                    email = account.Email,
                    phone = account.Phone,
                    roles = account.UserRoles.Select(r => r.RoleName).ToList() // Trả về danh sách quyền
                }
            });
        }
        // ==========================================
        // 3. LẤY THÔNG TIN USER TỪ TOKEN (GET ME)
        // ==========================================
        [HttpGet("me")]
        [Authorize] // <--- Bắt buộc phải có Token mới gọi được
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                // 1. Lấy AccountID từ trong Token (ClaimTypes.NameIdentifier)
                var accountIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (accountIdClaim == null)
                {
                    return Unauthorized(new { message = "Token không hợp lệ." });
                }

                int accountId = int.Parse(accountIdClaim.Value);

                // 2. Truy vấn Database để lấy thông tin chi tiết
                var account = await _context.Accounts
                    .Include(a => a.User) // Join bảng Users để lấy tên, ngày sinh...
                    .FirstOrDefaultAsync(a => a.AccountId == accountId);

                if (account == null)
                {
                    return NotFound(new { message = "Không tìm thấy người dùng." });
                }

                // 3. Trả về dữ liệu (DTO)
                return Ok(new
                {
                    accountId = account.AccountId,
                    email = account.Email,
                    phone = account.Phone,
                    fullName = account.User?.FullName,
                    dateOfBirth = account.User?.DateOfBirth, // Giả sử model User có trường này
                    gender = account.User?.Gender,           // Giả sử model User có trường này
                    avatarUrl = account.User?.AvatarUrl      // Giả sử model User có trường này
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

        // ==========================================
        // HÀM BỔ TRỢ (Private)
        // ==========================================
        private string GenerateJwtToken(Account account)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            string secretKey = jwtSettings["SecretKey"] ?? "Key_Mac_Dinh_Khong_Duoc_De_Lo_Ra_Ngoai_123456";
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                new Claim(ClaimTypes.Email, account.Email),
            };

            // Thêm tất cả các Role vào Token (Ví dụ user vừa là Buyer vừa là Seller)
            foreach (var role in account.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        // DTO Nhận dữ liệu
public class ChangePasswordRequest
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}

// Thêm vào trong class AuthController
[HttpPost("change-password")]
[Authorize] // Bắt buộc phải đăng nhập
public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
{
    // 1. Lấy ID user từ Token
    var identity = User.Identity as ClaimsIdentity;
    var accountIdStr = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(accountIdStr)) return Unauthorized();
    
    int accountId = int.Parse(accountIdStr);

    // 2. Tìm tài khoản trong DB
    var account = await _context.Accounts.FindAsync(accountId);
    if (account == null) return NotFound("Tài khoản không tồn tại");

    // 3. Kiểm tra mật khẩu cũ (Dùng BCrypt)
    bool isOldValid = BCrypt.Net.BCrypt.Verify(request.OldPassword, account.PasswordHash);
    if (!isOldValid)
    {
        return BadRequest(new { message = "Mật khẩu hiện tại không đúng." });
    }

    // 4. Mã hóa mật khẩu mới và Lưu
    string newHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
    account.PasswordHash = newHash;

    await _context.SaveChangesAsync();

    return Ok(new { message = "Đổi mật khẩu thành công!" });
}
    }
    

    // DTO Classes
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}