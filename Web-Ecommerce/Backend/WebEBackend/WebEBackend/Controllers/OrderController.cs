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
        // 2. LẤY CHI TIẾT ĐƠN HÀNG (API Mới)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var order = await _context.Orders
                .Where(o => o.OrderId == id && o.AccountId == accountId) // Bảo mật: Chỉ xem được đơn của mình
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Address) // Lấy thông tin địa chỉ
                .Select(o => new
                {
                    o.OrderId,
                    o.TotalAmount,
                    o.Status,
                    ReceiverName = o.Address != null ? o.Address.ReceiverFullName : "N/A",
                    ReceiverPhone = o.Address != null ? o.Address.ReceiverPhone : "N/A",
                    ShippingAddress = o.Address != null 
                        ? $"{o.Address.AddressLine}, {o.Address.Ward}, {o.Address.District}, {o.Address.Province}" 
                        : "Địa chỉ đã bị xóa",
                    Items = o.OrderDetails.Select(od => new
                    {
                        od.ProductId,
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        Price = od.UnitPrice,
                        // Nếu có ảnh thì lấy ảnh đầu tiên (tùy logic DB của bạn)
                        Image = "https://via.placeholder.com/50" 
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (order == null) return NotFound(new { message = "Không tìm thấy đơn hàng" });

            return Ok(order);
        }

        // 3. HỦY ĐƠN HÀNG (API Mới - Cho nút Hủy)
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var accountId = GetCurrentAccountId();
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id && o.AccountId == accountId);

            if (order == null) return NotFound();
            
            if (order.Status != "Pending") 
                return BadRequest(new { message = "Chỉ có thể hủy đơn hàng khi đang chờ xác nhận." });

            order.Status = "Cancelled";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã hủy đơn hàng." });
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