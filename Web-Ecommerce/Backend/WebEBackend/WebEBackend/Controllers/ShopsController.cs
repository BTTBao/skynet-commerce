using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEBackend.Models; // Namespace chứa Entity Shop của bạn

namespace WebEBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        // Thay 'WebEBackendContext' bằng tên class DbContext thực tế của bạn
        private readonly SkynetCommerceContext _context;

        public ShopsController(SkynetCommerceContext context)
        {
            _context = context;
        }

        // GET: api/Shops
        // Lấy danh sách tất cả các Shop (Thường dùng cho trang admin hoặc danh sách shop gợi ý)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            return await _context.Shops.ToListAsync();
        }

        // GET: api/Shops/5
        // API bạn đang cần gọi ở Frontend
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            // Tìm Shop theo ShopId
            // Lưu ý: Ở đây mình KHÔNG dùng .Include(s => s.Products) hay .Orders 
            // Vì React của bạn đã gọi API Products riêng rồi, load thêm vào đây sẽ rất nặng.
            var shop = await _context.Shops
                .FirstOrDefaultAsync(s => s.ShopId == id);

            if (shop == null)
            {
                return NotFound(new { message = "Không tìm thấy Shop" });
            }

            return shop;
        }
    }
}