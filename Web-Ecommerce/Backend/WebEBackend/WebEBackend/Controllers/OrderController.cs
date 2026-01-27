using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebEBackend.Models;

namespace WebEBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly SkynetCommerceContext _context;

        public OrderController(SkynetCommerceContext context)
        {
            _context = context;
        }

        // LẤY DANH SÁCH ĐƠN HÀNG CỦA TÔI
        [HttpGet("mine")]
        public async Task<IActionResult> GetMyOrders()
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var orders = await _context.Orders
                .Where(o => o.AccountId == accountId)
                .Include(o => o.Shop) // Để lấy tên Shop
                .Include(o => o.OrderDetails) // Để đếm số lượng sp
                    .ThenInclude(od => od.Product) // Để lấy tên sp
                .OrderByDescending(o => o.CreatedAt) // Mới nhất lên đầu
                .Select(o => new
                {
                    o.OrderId,
                    ShopName = o.Shop.ShopName,
                    o.Status, // Pending, Shipping, Completed...
                    o.TotalAmount,
                    CreatedAt = o.CreatedAt,
                    // Lấy hình ảnh hoặc tên sản phẩm đầu tiên để hiển thị đại diện
                    FirstProductName = o.OrderDetails.FirstOrDefault().Product.Name,
                    ProductCount = o.OrderDetails.Sum(od => od.Quantity)
                })
                .ToListAsync();

            return Ok(orders);
        }

        private int GetCurrentAccountId()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null) return -1;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? int.Parse(claim.Value) : -1;
        }
    }
}