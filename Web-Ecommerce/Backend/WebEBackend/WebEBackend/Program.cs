using Microsoft.EntityFrameworkCore;
using WebEBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt; // Cần thiết cho dòng Clear()

var builder = WebApplication.CreateBuilder(args);

// ====================================================
// 1. CẤU HÌNH DỊCH VỤ (SERVICES)
// ====================================================

// Tắt mapping claim mặc định của .NET (Để giữ nguyên tên claim như "sub", "id"...)
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

// Cấu hình Controllers và xử lý lỗi vòng lặp JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Kết nối Database
builder.Services.AddDbContext<SkynetCommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình CORS (Cho phép React gọi vào)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Cấu hình JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
string secretKey = jwtSettings["SecretKey"] ?? "Key_Mac_Dinh_Khong_Duoc_De_Lo_Ra_Ngoai_123456";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // Tắt kiểm tra Issuer
        ValidateAudience = false, // Tắt kiểm tra Audience
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

// ====================================================
// 2. XÂY DỰNG APP (BUILD)
// ====================================================
var app = builder.Build();

// ====================================================
// 3. CẤU HÌNH MIDDLEWARE (PIPELINE)
// ====================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Kích hoạt CORS (Phải trước Auth)
app.UseCors("AllowReactApp");

// Kích hoạt Authentication & Authorization (Đúng thứ tự)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();