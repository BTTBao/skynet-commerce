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

        // ==========================================
        // API TẠO ĐƠN HÀNG (STRICT MODE - KHÔNG MẤT ITEM)
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

            // 3. MỞ TRANSACTION
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // ===================================================================
                // BƯỚC 1: VALIDATE SẢN PHẨM (CHẶT CHẼ)
                // ===================================================================

                // Lấy danh sách ID sản phẩm khách đặt (loại bỏ trùng lặp để query)
                var requestedProductIds = request.Items.Select(i => i.ProductId).Distinct().ToList();

                // Query DB lấy thông tin sản phẩm
                var productsInDb = await _context.Products
                                                .Include(p => p.ProductVariants)
                                                .Where(p => requestedProductIds.Contains(p.ProductId))
                                                .ToListAsync();

                // CHECK 1: Số lượng sản phẩm tìm thấy phải khớp với số lượng ID gửi lên
                if (productsInDb.Count < requestedProductIds.Count)
                {
                    // Tìm ra ID nào bị thiếu
                    var dbIds = productsInDb.Select(p => p.ProductId).ToList();
                    var missingIds = requestedProductIds.Except(dbIds).ToList();
                    return BadRequest(new { message = $"Lỗi: Sản phẩm có ID [{string.Join(", ", missingIds)}] không tồn tại hoặc đã bị xóa." });
                }

                // CHECK 2: Kiểm tra xem có sản phẩm nào bị lỗi ShopId (NULL hoặc 0) không
                var invalidShopProducts = productsInDb.Where(p => p.ShopId == null || p.ShopId <= 0).ToList();
                if (invalidShopProducts.Any())
                {
                    var names = string.Join(", ", invalidShopProducts.Select(p => p.Name));
                    return BadRequest(new { message = $"Lỗi dữ liệu: Sản phẩm [{names}] chưa được gán Shop (ShopId bị thiếu). Vui lòng liên hệ Admin." });
                }

                // ===================================================================
                // BƯỚC 2: GOM NHÓM THEO SHOP (DỮ LIỆU ĐÃ SẠCH)
                // ===================================================================
                var itemsByShop = request.Items
                    .GroupBy(item =>
                    {
                        var product = productsInDb.First(p => p.ProductId == item.ProductId);
                        return product.ShopId!.Value; // Chắc chắn có value vì đã check ở trên
                    })
                    .ToList();

                // ===================================================================
                // BƯỚC 3: KIỂM TRA ĐỊA CHỈ
                // ===================================================================
                if (request.AddressId <= 0)
                    return BadRequest(new { message = "Vui lòng chọn địa chỉ nhận hàng." });

                var existingAddress = await _context.UserAddresses
                    .FirstOrDefaultAsync(a => a.AddressId == request.AddressId && a.AccountId == accountId);

                if (existingAddress == null)
                    return BadRequest(new { message = "Địa chỉ không tồn tại hoặc không thuộc về tài khoản này." });

                int addressId = existingAddress.AddressId;

                // ===================================================================
                // BƯỚC 4: TẠO ORDER GROUP (TỔNG)
                // ===================================================================
                var orderGroup = new OrderGroup
                {
                    AccountId = accountId,
                    CreatedAt = DateTime.Now,
                    TotalAmount = 0
                };
                _context.OrderGroups.Add(orderGroup);
                await _context.SaveChangesAsync();

                decimal grandTotal = 0;

                // ===================================================================
                // BƯỚC 5: TẠO ORDER CON CHO TỪNG SHOP
                // ===================================================================
                foreach (var shopGroup in itemsByShop)
                {
                    int shopId = shopGroup.Key;
                    decimal shopTotalAmount = 0;

                    // 5.1 Tạo Order
                    var newOrder = new Order
                    {
                        OrderGroupId = orderGroup.OrderGroupId,
                        ShopId = shopId,
                        AccountId = accountId,
                        AddressId = addressId,
                        Status = "Pending",
                        CreatedAt = DateTime.Now,
                        IsReviewed = false,
                        TotalAmount = 0
                    };

                    _context.Orders.Add(newOrder);
                    await _context.SaveChangesAsync(); // Sinh OrderId

                    // 5.2 Tạo Order Details (Chi tiết sản phẩm)
                    foreach (var item in shopGroup)
                    {
                        var product = productsInDb.First(p => p.ProductId == item.ProductId);

                        // Mặc định lấy giá gốc (cho trường hợp không biến thể như Smart Phone)
                        decimal finalPrice = product.Price ?? 0;
                        int? variantId = null;

                        // Kiểm tra nếu khách có chọn Size hoặc Màu
                        bool hasVariantRequest = !string.IsNullOrEmpty(item.Color) || !string.IsNullOrEmpty(item.Size);

                        if (hasVariantRequest)
                        {
                            var variant = product.ProductVariants.FirstOrDefault(v =>
                                (string.IsNullOrEmpty(item.Color) || v.Color == item.Color) &&
                                (string.IsNullOrEmpty(item.Size) || v.Size == item.Size));

                            if (variant != null)
                            {
                                finalPrice = variant.Price ?? finalPrice;
                                variantId = variant.VariantId;
                            }
                            else
                            {
                                // Nếu khách chọn Size/Màu mà DB không có -> Báo lỗi luôn
                                return BadRequest(new { message = $"Sản phẩm '{product.Name}' không còn loại Màu: {item.Color}, Size: {item.Size}." });
                            }
                        }

                        // Kiểm tra giá cuối cùng (đề phòng sản phẩm chưa set giá)
                        if (finalPrice <= 0)
                        {
                            return BadRequest(new { message = $"Sản phẩm '{product.Name}' chưa được cập nhật giá bán." });
                        }

                        var itemSubTotal = finalPrice * item.Quantity;
                        shopTotalAmount += itemSubTotal;

                        var detail = new OrderDetail
                        {
                            OrderId = newOrder.OrderId,
                            ProductId = item.ProductId,
                            VariantId = variantId, // SQL phải cho phép NULL cột này
                            Quantity = item.Quantity,
                            UnitPrice = finalPrice,
                            SubTotal = itemSubTotal
                        };
                        _context.OrderDetails.Add(detail);
                    }

                    // 5.3 Cập nhật tổng tiền Order con
                    newOrder.TotalAmount = shopTotalAmount;
                    grandTotal += shopTotalAmount;

                    // 5.4 Tạo Shipping & History
                    var shippingInfo = new OrderShippingInfo { OrderId = newOrder.OrderId, Status = "Processing", ShippingFee = 0 };
                    _context.OrderShippingInfos.Add(shippingInfo);

                    var history = new OrderStatusHistory { OrderId = newOrder.OrderId, NewStatus = "Pending", ChangedAt = DateTime.Now };
                    _context.OrderStatusHistories.Add(history);
                }

                // ===================================================================
                // BƯỚC 6: HOÀN TẤT
                // ===================================================================
                orderGroup.TotalAmount = grandTotal;
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Đặt hàng thành công!",
                    orderGroupId = orderGroup.OrderGroupId
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                var innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                // Log lỗi ra console server để debug
                Console.WriteLine($"Order Error: {innerMsg}");
                return StatusCode(500, new { message = "Lỗi hệ thống khi tạo đơn: " + innerMsg });
            }
        }

        // ==========================================
        // CÁC API KHÁC (GET, CANCEL...)
        // ==========================================
        [HttpGet("mine")]
        public async Task<IActionResult> GetMyOrders()
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var history = await _context.OrderGroups
                .Where(g => g.AccountId == accountId)
                .OrderByDescending(g => g.CreatedAt) // Mới nhất lên đầu
                .Select(g => new
                {
                    g.OrderGroupId,
                    CreatedAt = g.CreatedAt,
                    TotalGroupAmount = g.TotalAmount, // Tổng tiền người dùng phải trả cho lần bấm nút đó

                    // Danh sách các đơn con (Tách theo Shop) nằm trong Group này
                    SubOrders = g.Orders.Select(o => new
                    {
                        o.OrderId,
                        o.Status, 
                        o.IsReviewed, // ✅ QUAN TRỌNG: Trả về trạng thái đã đánh giá hay chưa
                        ShopName = o.Shop.ShopName,
                        TotalOrderAmount = o.TotalAmount, 

                        // Lấy sản phẩm đại diện để hiển thị
                        FirstProductName = o.OrderDetails.Select(od => od.Product.Name).FirstOrDefault() ?? "Sản phẩm",
                        ProductCount = o.OrderDetails.Sum(od => od.Quantity ?? 0),

                        // Lấy chi tiết items (để hiển thị nếu cần)
                        Items = o.OrderDetails.Select(od => new {
                            ProductName = od.Product.Name,
                            Quantity = od.Quantity ?? 0,
                            Price = od.UnitPrice ?? 0,
                            Variant = od.Variant != null ? $"{od.Variant.Color} {od.Variant.Size}" : ""
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync();

            return Ok(history);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var accountId = GetCurrentAccountId();
            if (accountId == -1) return Unauthorized();

            var order = await _context.Orders
                .Where(o => o.OrderId == id && o.AccountId == accountId)
                .Select(o => new
                {
                    o.OrderId,
                    o.TotalAmount,
                    o.Status,
                    // Xử lý an toàn khi không có địa chỉ
                    ReceiverName = o.Address != null ? o.Address.ReceiverFullName : "Không xác định",
                    ReceiverPhone = o.Address != null ? o.Address.ReceiverPhone : "Không xác định",
                    ShippingAddress = o.Address != null
                        ? $"{o.Address.AddressLine}, {o.Address.Ward}, {o.Address.District}, {o.Address.Province}"
                        : "Địa chỉ đã bị xóa hoặc không tồn tại",

                    Items = o.OrderDetails.Select(od => new
                    {
                        od.ProductId,
                        // 1. Lấy tên sản phẩm an toàn (tránh lỗi null)
                        ProductName = od.Product != null ? od.Product.Name : "Sản phẩm đã bị xóa",

                        // 2. Lấy thêm thông tin Phân loại (Size/Màu) để hiển thị cho rõ
                        Color = od.Variant != null ? od.Variant.Color : null,
                        Size = od.Variant != null ? od.Variant.Size : null,

                        // 3. Ghép tên đầy đủ để hiển thị 1 dòng cho đẹp (Option cho Frontend dùng luôn)
                        FullProductName = od.Product.Name + (od.Variant != null ? $" ({od.Variant.Color}, {od.Variant.Size})" : ""),

                        // 4. Xử lý số lượng và giá (tránh null)
                        Quantity = od.Quantity ?? 0,
                        Price = od.UnitPrice ?? 0,

                        // Ảnh demo (sau này bạn thay bằng logic lấy ảnh thật từ bảng ProductImages)
                        Image = "https://via.placeholder.com/50"
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (order == null) return NotFound(new { message = "Không tìm thấy đơn hàng" });

            return Ok(order);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var accountId = GetCurrentAccountId();
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id && o.AccountId == accountId);

            if (order == null) return NotFound();
            if (order.Status != "Pending") return BadRequest(new { message = "Chỉ có thể hủy đơn hàng khi đang chờ xác nhận." });

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
    // DTO REQUEST
    // ==========================================
    public class CreateOrderRequest
    {
        public int AddressId { get; set; }
        public string? Note { get; set; }
        public string? PaymentMethod { get; set; }

        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public string? AddressLine { get; set; }

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