using Microsoft.EntityFrameworkCore;
using WebEBackend.Models;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình Controllers và xử lý lỗi vòng lặp JSON (Rất quan trọng cho Model Product của bạn)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SkynetCommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. KHAI BÁO CHÍNH SÁCH CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000") // Port của Vite hoặc CRA
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. KÍCH HOẠT CORS (Phải đặt TRƯỚC UseAuthorization và MapControllers)
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();