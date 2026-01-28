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
    public class ReviewsController : ControllerBase
    {
        private readonly SkynetCommerceContext _context;

        public ReviewsController(SkynetCommerceContext context)
        {
            _context = context;
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewRequest request)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            // 1. Kiểm tra đơn hàng có tồn tại và đã hoàn thành chưa
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId && o.AccountId == accountId);

            if (order == null) return NotFound("Đơn hàng không tồn tại.");
            if (order.Status != "Delivered") return BadRequest("Bạn chỉ được đánh giá khi đơn hàng đã hoàn thành.");
            if (order.IsReviewed == true) return BadRequest("Đơn hàng này đã được đánh giá rồi.");

            // 2. Lưu đánh giá cho từng sản phẩm trong đơn hàng
            foreach (var item in order.OrderDetails)
            {
                var review = new Review
                {
                    ProductId = item.ProductId,
                    AccountId = accountId,
                    ShopId = order.ShopId,
                    Rating = request.Rating,
                    Comment = request.Comment,
                    CreatedAt = DateTime.Now,
                    Status = "Approved", // Hoặc "Pending" nếu cần kiểm duyệt
                    OrderDetailId = item.OrderDetailId
                };
                _context.Reviews.Add(review);
            }

            // 3. Đánh dấu đơn hàng là đã đánh giá
            order.IsReviewed = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đánh giá thành công!" });
        }

        private int GetCurrentAccountId()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null) return -1;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? int.Parse(claim.Value) : -1;
        }
    }

    // DTO để nhận dữ liệu từ React
    public class ReviewRequest
    {
        public int OrderId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}