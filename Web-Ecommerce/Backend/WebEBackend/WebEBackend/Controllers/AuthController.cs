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
            if (await _context.Accounts.AnyAsync(a => a.Email == request.Email))
                return BadRequest(new { message = "Email này đã được sử dụng." });
            if (await _context.Accounts.AnyAsync(a => a.Phone == request.Phone))
                return BadRequest(new { message = "Số điện thoại này đã được sử dụng." });

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Tạo Account
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
                await _context.SaveChangesAsync(); 

                // Tạo User Profile
                var newUser = new User
                {
                    AccountId = newAccount.AccountId,
                    FullName = request.FullName,
                };
                _context.Users.Add(newUser);

                // Tạo Role Buyer
                var newRole = new UserRole
                {
                    AccountId = newAccount.AccountId,
                    RoleName = "Buyer",
                    CreatedAt = DateTime.Now
                };
                _context.UserRoles.Add(newRole);

                // Tạo Cart
                var newCart = new Cart
                {
                    AccountId = newAccount.AccountId,
                    CreatedAt = DateTime.Now
                };
                _context.Carts.Add(newCart);

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
            var account = await _context.Accounts
                .Include(a => a.User)
                .Include(a => a.UserRoles)
                .FirstOrDefaultAsync(a => a.Email == request.Email);

            if (account == null || account.IsActive == false)
                return Unauthorized(new { message = "Email hoặc mật khẩu không đúng." });

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, account.PasswordHash);
            if (!isPasswordValid)
                return Unauthorized(new { message = "Email hoặc mật khẩu không đúng." });

            var token = GenerateJwtToken(account);

            return Ok(new
            {
                token = token,
                user = new
                {
                    id = account.AccountId,
                    name = account.User?.FullName ?? "Người dùng",
                    email = account.Email,
                    phone = account.Phone,
                    roles = account.UserRoles.Select(r => r.RoleName).ToList()
                }
            });
        }

        // ==========================================
        // 3. LẤY THÔNG TIN USER (GET ME)
        // ==========================================
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                int accountId = GetCurrentAccountId();
                if (accountId == -1) return Unauthorized(new { message = "Token không hợp lệ." });

                var account = await _context.Accounts
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(a => a.AccountId == accountId);

                if (account == null) return NotFound(new { message = "Không tìm thấy người dùng." });

                return Ok(new
                {
                    accountId = account.AccountId,
                    email = account.Email,
                    phone = account.Phone,
                    fullName = account.User?.FullName,
                    dateOfBirth = account.User?.DateOfBirth, 
                    gender = account.User?.Gender,           
                    avatarUrl = account.User?.AvatarUrl      
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

        // ==========================================
        // 4. CẬP NHẬT THÔNG TIN (UPDATE PROFILE) - ĐÃ SỬA LỖI DATEONLY
        // ==========================================
        [HttpPut("update-profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            int accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var account = await _context.Accounts.FindAsync(accountId);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.AccountId == accountId);

            if (account == null || user == null) return NotFound(new { message = "Dữ liệu người dùng lỗi." });

            // Kiểm tra trùng SĐT
            if (request.Phone != account.Phone)
            {
                var isPhoneTaken = await _context.Accounts.AnyAsync(a => a.Phone == request.Phone && a.AccountId != accountId);
                if (isPhoneTaken) return BadRequest(new { message = "Số điện thoại này đã được sử dụng bởi người khác." });
                account.Phone = request.Phone;
            }

            // Cập nhật User Info
            user.FullName = request.FullName;
            user.Gender = request.Gender;

            // --- ĐOẠN ĐÃ SỬA: Dùng DateOnly.TryParse thay vì DateTime ---
            if (!string.IsNullOrEmpty(request.DateOfBirth) && DateOnly.TryParse(request.DateOfBirth, out DateOnly dob))
            {
                user.DateOfBirth = dob;
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cập nhật thông tin thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

        // ==========================================
        // 5. ĐỔI MẬT KHẨU (CHANGE PASSWORD)
        // ==========================================
        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            int accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null) return NotFound("Tài khoản không tồn tại");

            bool isOldValid = BCrypt.Net.BCrypt.Verify(request.OldPassword, account.PasswordHash);
            if (!isOldValid)
                return BadRequest(new { message = "Mật khẩu hiện tại không đúng." });

            string newHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            account.PasswordHash = newHash;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Đổi mật khẩu thành công!" });
        }

        // ==========================================
        // HELPERS & DTOs
        // ==========================================
        private int GetCurrentAccountId()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null) return -1;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier) ?? identity.FindFirst("nameid") ?? identity.FindFirst("id");
            return claim != null ? int.Parse(claim.Value) : -1;
        }

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
    }

    public class LoginRequest { public string Email { get; set; } public string Password { get; set; } }
    public class RegisterRequest { public string FullName { get; set; } public string Email { get; set; } public string Phone { get; set; } public string Password { get; set; } }
    public class ChangePasswordRequest { public string OldPassword { get; set; } public string NewPassword { get; set; } }
    public class UpdateProfileRequest { public string FullName { get; set; } public string Phone { get; set; } public string DateOfBirth { get; set; } public string Gender { get; set; } }
}