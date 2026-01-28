using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebEBackend.Models; // Đảm bảo đúng namespace model của bạn

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

        // ==========================================
        // API TẠO ĐƠN HÀNG (FULL LOGIC - AN TOÀN)
        // ==========================================
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            // 1. Kiểm tra giỏ hàng
            if (request.Items == null || !request.Items.Any())
                return BadRequest(new { message = "Giỏ hàng trống!" });

            // 2. Lấy User ID
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            // 3. MỞ TRANSACTION (An toàn dữ liệu tuyệt đối)
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // ===================================================================
                // BƯỚC 1: CHUẨN BỊ VÀ KIỂM TRA DỮ LIỆU SẢN PHẨM (QUAN TRỌNG NHẤT)
                // ===================================================================
                // Phải làm bước này TRƯỚC khi lưu bất cứ cái gì vào DB để tránh rác
                var productIds = request.Items.Select(i => i.ProductId).Distinct().ToList();

                var productsInDb = await _context.Products
                                        .Include(p => p.ProductVariants)
                                        .Where(p => productIds.Contains(p.ProductId))
                                        .ToListAsync();

                // Gom nhóm sản phẩm theo ShopId
                var itemsByShop = request.Items
                    .GroupBy(item =>
                    {
                        var product = productsInDb.FirstOrDefault(p => p.ProductId == item.ProductId);
                        // Nếu không tìm thấy sp hoặc ShopId = 0/null thì trả về 0
                        return product?.ShopId ?? 0;
                    })
                    .Where(g => g.Key != 0) // Loại bỏ các nhóm không hợp lệ
                    .ToList(); // Chốt danh sách ngay lập tức

                // --- CHỐT CHẶN: Nếu không tìm thấy Shop nào hợp lệ -> BÁO LỖI NGAY ---
                if (!itemsByShop.Any())
                {
                    return BadRequest(new
                    {
                        message = "Lỗi đặt hàng: Không tìm thấy sản phẩm hoặc Sản phẩm chưa được gán ShopId (ShopId=0). Vui lòng kiểm tra lại Database."
                    });
                }

                // ===================================================================
                // BƯỚC 2: TẠO ĐỊA CHỈ NGƯỜI DÙNG (USER ADDRESS)
                // ===================================================================
                var newAddress = new UserAddress
                {
                    AccountId = accountId,
                    ReceiverFullName = request.ReceiverName, // Map từ Frontend
                    ReceiverPhone = request.ReceiverPhone,   // Map từ Frontend
                    AddressLine = request.AddressLine,       // Map từ Frontend

                    // ĐIỀN GIÁ TRỊ MẶC ĐỊNH CHO CÁC CỘT NOT NULL (Tránh lỗi SQL)
                    Ward = "Chưa cập nhật",
                    District = "Chưa cập nhật",
                    Province = "Chưa cập nhật",

                    AddressName = "Địa chỉ đặt hàng",
                    IsDefault = false
                };

                _context.UserAddresses.Add(newAddress);
                await _context.SaveChangesAsync(); // Lưu để sinh AddressId
                int addressId = newAddress.AddressId;

                // ===================================================================
                // BƯỚC 3: TẠO ORDER GROUP (HÓA ĐƠN TỔNG)
                // ===================================================================
                var orderGroup = new OrderGroup
                {
                    AccountId = accountId,
                    CreatedAt = DateTime.Now,
                    TotalAmount = 0 // Sẽ cộng dồn sau
                };
                _context.OrderGroups.Add(orderGroup);
                await _context.SaveChangesAsync(); // Lưu để sinh OrderGroupId

                decimal grandTotal = 0;

                // ===================================================================
                // BƯỚC 4: TẠO ORDER CON CHO TỪNG SHOP
                // ===================================================================
                foreach (var shopGroup in itemsByShop)
                {
                    int shopId = shopGroup.Key;
                    decimal shopTotalAmount = 0;

                    // 4.1 Tạo Order
                    var newOrder = new Order
                    {
                        OrderGroupId = orderGroup.OrderGroupId,
                        ShopId = shopId,
                        AccountId = accountId,
                        AddressId = addressId, // Link với địa chỉ bước 2
                        Status = "Pending",
                        CreatedAt = DateTime.Now,
                        IsReviewed = false,
                        TotalAmount = 0
                    };

                    _context.Orders.Add(newOrder);
                    await _context.SaveChangesAsync(); // Lưu để sinh OrderId

                    // 4.2 Tạo Order Details
                    foreach (var item in shopGroup)
                    {
                        var product = productsInDb.FirstOrDefault(p => p.ProductId == item.ProductId);
                        if (product == null) continue;

                        decimal finalPrice = product.Price ?? 0;
                        int? variantId = null;

                        // Check Variant (Màu/Size)
                        if (!string.IsNullOrEmpty(item.Color) || !string.IsNullOrEmpty(item.Size))
                        {
                            var variant = product.ProductVariants.FirstOrDefault(v =>
                                (string.IsNullOrEmpty(item.Color) || v.Color == item.Color) &&
                                (string.IsNullOrEmpty(item.Size) || v.Size == item.Size));

                            if (variant != null)
                            {
                                finalPrice = variant.Price ?? finalPrice;
                                variantId = variant.VariantId;
                            }
                        }

                        var itemSubTotal = finalPrice * item.Quantity;
                        shopTotalAmount += itemSubTotal;

                        var detail = new OrderDetail
                        {
                            OrderId = newOrder.OrderId,
                            ProductId = item.ProductId,
                            VariantId = variantId,
                            Quantity = item.Quantity,
                            UnitPrice = finalPrice,
                            SubTotal = itemSubTotal
                        };
                        _context.OrderDetails.Add(detail);
                    }

                    // Cập nhật tổng tiền đơn con
                    newOrder.TotalAmount = shopTotalAmount;
                    grandTotal += shopTotalAmount;

                    // 4.3 Tạo Shipping Info
                    var shippingInfo = new OrderShippingInfo
                    {
                        OrderId = newOrder.OrderId,
                        Status = "Processing",
                        ShippingFee = 0,
                        ShipperId = null,
                        TrackingCode = null
                    };
                    _context.OrderShippingInfos.Add(shippingInfo);

                    // 4.4 Tạo History Status
                    var history = new OrderStatusHistory
                    {
                        OrderId = newOrder.OrderId,
                        OldStatus = null,
                        NewStatus = "Pending",
                        ChangedAt = DateTime.Now
                    };
                    _context.OrderStatusHistories.Add(history);
                }

                // ===================================================================
                // BƯỚC 5: HOÀN TẤT
                // ===================================================================
                orderGroup.TotalAmount = grandTotal;
                await _context.SaveChangesAsync();

                await transaction.CommitAsync(); // Xác nhận Transaction

                return Ok(new
                {
                    message = "Đặt hàng thành công!",
                    orderGroupId = orderGroup.OrderGroupId
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Lấy lỗi gốc từ SQL để dễ debug
                var innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new { message = "Lỗi hệ thống: " + innerMsg });
            }
        }

        // API Lấy danh sách đơn hàng
        [HttpGet("mine")]
        public async Task<IActionResult> GetMyOrders()
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var orders = await _context.Orders
                .Where(o => o.AccountId == accountId)
                .Include(o => o.Shop)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new
                {
                    o.OrderId,
                    ShopName = o.Shop.ShopName,
                    o.Status,
                    o.TotalAmount,
                    CreatedAt = o.CreatedAt,
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

    // ==========================================
    // DTO: CLASS DỮ LIỆU NHẬN TỪ FRONTEND
    // ==========================================
    public class CreateOrderRequest
    {
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string AddressLine { get; set; }

        public string? Note { get; set; }
        public string? PaymentMethod { get; set; }

        public List<CartItemRequest> Items { get; set; }
    }

    public class CartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
    }
}