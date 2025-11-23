using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Services.Seller
{
    // Áp dụng IDisposable để đảm bảo _context được giải phóng
    public class OrderServiceForSeller : IDisposable
    {
        // Khởi tạo context trong phương thức để đảm bảo sử dụng using và giải phóng tài nguyên.
        // Tốt hơn là nên inject context qua constructor nếu bạn đang dùng Dependency Injection.
        // Tuy nhiên, để sửa nhanh, ta sẽ dùng cách này.
        // private readonly ApplicationDbContext _context; // Đã bỏ readonly context

        public OrderServiceForSeller()
        {
            // _context = new ApplicationDbContext(); // Không khởi tạo ở đây nữa
        }

        // Sửa lỗi: Thay thế .Trim(char[]) không được hỗ trợ trong LINQ to Entities
        public async Task<List<OrderSellerDTO>> GetOrdersForSeller(int shopId)
        {
            // Dùng khối using để đảm bảo context được Dispose sau khi dùng
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    // BƯỚC 1: Kiểm tra Orders
                    var ordersCount = await context.Orders
                        .Where(o => o.ShopID == shopId)
                        .CountAsync();

                    if (ordersCount == 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"ShopID {shopId} KHÔNG CÓ ĐƠN HÀNG!");
                        return new List<OrderSellerDTO>();
                    }

                    // BƯỚC 2: Query đầy đủ
                    var query = from od in context.OrderDetails
                                join o in context.Orders on od.OrderID equals o.OrderID
                                join acc in context.Accounts on o.AccountID equals acc.AccountID
                                join ua in context.UserAddresses on o.AddressID equals ua.AddressID into uaJoin
                                from ua in uaJoin.DefaultIfEmpty()
                                join u in context.Users on o.AccountID equals u.AccountID into userJoin
                                from uj in userJoin.DefaultIfEmpty()
                                join p in context.Products on od.ProductID equals p.ProductID
                                join img in context.ProductImages.Where(i => i.IsPrimary == true)
                                    on p.ProductID equals img.ProductID into imgJoin
                                from imgPrimary in imgJoin.DefaultIfEmpty()
                                join v in context.ProductVariants on od.VariantID equals v.VariantID into vJoin
                                from variant in vJoin.DefaultIfEmpty()
                                where o.ShopID == shopId
                                select new
                                {
                                    // Chọn tất cả các trường cần thiết, nhưng tránh các hàm C# không hỗ trợ
                                    Order = o,
                                    OrderDetail = od,
                                    Account = acc,
                                    UserAddress = ua,
                                    User = uj,
                                    Product = p,
                                    Image = imgPrimary,
                                    Variant = variant
                                };

                    // BƯỚC 3: Thực hiện truy vấn trên DB và tải dữ liệu vào bộ nhớ
                    var resultFromDb = await query.ToListAsync();

                    // BƯỚC 4: Chuyển đổi sang DTO và xử lý các thao tác C# (như .Trim(char[])) trong bộ nhớ
                    var result = resultFromDb.Select(item =>
                    {
                        // SỬA LỖI TRIM Ở ĐÂY: Thực thi trong LINQ to Objects (C#)
                        string variantString = "Không có";
                        if (item.Variant != null)
                        {
                            variantString = ((item.Variant.Size ?? "") + " - " + (item.Variant.Color ?? "")).Trim('-', ' ').Trim();
                        }

                        return new OrderSellerDTO
                        {
                            OrderID = item.Order.OrderID,
                            CustomerName = item.User != null ? (item.User.FullName ?? "Khách không tên") : "Khách không tên",
                            CustomerPhone = item.Account.Phone ?? "N/A",
                            ProductName = item.Product.Name ?? "Sản phẩm không tên",
                            Variant = variantString, // Đã xử lý Trim() ở trên
                            ImageURL = item.Image != null ? item.Image.ImageURL : null,
                            CreatedAt = item.Order.CreatedAt ?? DateTime.Now,
                            UnitPrice = item.OrderDetail.UnitPrice ?? 0,
                            Quantity = item.OrderDetail.Quantity ?? 0,
                            SubTotal = item.OrderDetail.SubTotal ?? 0,
                            TotalOrderAmount = item.Order.TotalAmount ?? 0,
                            Status = item.Order.Status ?? "Pending",
                            AddressFull = item.UserAddress != null
                                ? (item.UserAddress.AddressLine + ", " + item.UserAddress.Ward + ", " + item.UserAddress.District + ", " + item.UserAddress.Province)
                                : "Chưa có địa chỉ"
                        };
                    }).ToList();

                    System.Diagnostics.Debug.WriteLine($"Kết quả cuối cùng: {result.Count} items");
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR in GetOrdersForSeller: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"STACK TRACE: {ex.StackTrace}");
                    if (ex.InnerException != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"INNER EXCEPTION: {ex.InnerException.Message}");
                    }
                    throw;
                }
            }
        }

        // Phương thức DiagnoseShopData được giữ nguyên logic, chỉ thêm using
        public async Task<string> DiagnoseShopData(int shopId)
        {
            var result = "";

            using (var context = new ApplicationDbContext())
            {
                try
                {
                    // ... (Phần logic truy vấn context.Shops, context.Orders, v.v. đã được giữ nguyên)
                    // 1. Kiểm tra Shop
                    var shop = await context.Shops.FirstOrDefaultAsync(s => s.ShopID == shopId);
                    result += $"1. Shop (ID={shopId}): {(shop != null ? "Tồn tại - " + shop.ShopName : "KHÔNG TỒN TẠI")}\n";

                    // 2. Kiểm tra Orders
                    var orders = await context.Orders.Where(o => o.ShopID == shopId).ToListAsync();
                    result += $"2. Orders: {orders.Count} đơn hàng\n";

                    if (orders.Any())
                    {
                        var firstOrder = orders.First();
                        result += $"  - OrderID đầu tiên: {firstOrder.OrderID}\n";
                        result += $"  - AccountID: {firstOrder.AccountID}\n";
                        result += $"  - Status: {firstOrder.Status}\n";
                        result += $"  - TotalAmount: {firstOrder.TotalAmount}\n";

                        // 3. Kiểm tra OrderDetails
                        var details = await context.OrderDetails
                            .Where(od => od.OrderID == firstOrder.OrderID)
                            .ToListAsync();
                        result += $"3. OrderDetails của Order đầu: {details.Count} items\n";

                        // 4. Kiểm tra Account
                        var account = await context.Accounts
                            .FirstOrDefaultAsync(a => a.AccountID == firstOrder.AccountID);
                        result += $"4. Account: {(account != null ? "Tồn tại" : "KHÔNG TỒN TẠI")}\n";

                        // 5. Kiểm tra User
                        var user = await context.Users
                            .FirstOrDefaultAsync(u => u.AccountID == firstOrder.AccountID);
                        result += $"5. User: {(user != null ? user.FullName : "KHÔNG CÓ")}\n";

                        // 6. Kiểm tra Address
                        if (firstOrder.AddressID != null)
                        {
                            var address = await context.UserAddresses
                                .FirstOrDefaultAsync(ua => ua.AddressID == firstOrder.AddressID);
                            result += $"6. Address: {(address != null ? "Tồn tại" : "KHÔNG TỒN TẠI")}\n";
                        }
                        else
                        {
                            result += $"6. Address: NULL\n";
                        }

                        // 7. Kiểm tra Products
                        if (details.Any())
                        {
                            var productId = details.First().ProductID;
                            var product = await context.Products
                                .FirstOrDefaultAsync(p => p.ProductID == productId);
                            result += $"7. Product: {(product != null ? product.Name : "KHÔNG TỒN TẠI")}\n";

                            // 8. Kiểm tra ProductImages
                            var images = await context.ProductImages
                                .Where(img => img.ProductID == productId)
                                .ToListAsync();
                            result += $"8. ProductImages: {images.Count} ảnh\n";
                        }
                    }
                    else
                    {
                        result += "\n=== DANH SÁCH TẤT CẢ SHOPS CÓ ĐƠN HÀNG ===\n";
                        var shopsWithOrders = await context.Orders
                            .GroupBy(o => o.ShopID)
                            .Select(g => new { ShopID = g.Key, OrderCount = g.Count() })
                            .ToListAsync();

                        foreach (var s in shopsWithOrders)
                        {
                            var shopInfo = await context.Shops.FirstOrDefaultAsync(sh => sh.ShopID == s.ShopID);
                            result += $"  ShopID: {s.ShopID} ({shopInfo?.ShopName ?? "N/A"}) - {s.OrderCount} đơn\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    result += $"\nLỖI: {ex.Message}\n";
                    result += $"INNER: {ex.InnerException?.Message}\n";
                }

                return result;
            }
        }

        // Phương thức UpdateOrderStatus được giữ nguyên logic, chỉ thêm using
        public bool UpdateOrderStatus(int orderID, string newStatus)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var order = context.Orders.FirstOrDefault(o => o.OrderID == orderID);
                    if (order == null)
                        return false;

                    // Thao tác DeductStockQuantity cũng cần sử dụng cùng context
                    if (newStatus == "Đang giao" || newStatus == "Shipping")
                    {
                        DeductStockQuantity(context, orderID);
                    }

                    order.Status = newStatus;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi cập nhật trạng thái: {ex.Message}", ex);
                }
            }
        }

        // Thêm đối số context để sử dụng chung context từ UpdateOrderStatus
        private void DeductStockQuantity(ApplicationDbContext context, int orderID)
        {
            var orderDetails = context.OrderDetails
                .Where(od => od.OrderID == orderID)
                .ToList();

            foreach (var detail in orderDetails)
            {
                int quantity = detail.Quantity ?? 0;

                if (detail.VariantID != null && detail.VariantID > 0)
                {
                    var variant = context.ProductVariants
                        .FirstOrDefault(v => v.VariantID == detail.VariantID);

                    if (variant != null)
                    {
                        if ((variant.StockQuantity ?? 0) < quantity)
                        {
                            throw new Exception($"Không đủ tồn kho cho biến thể SKU: {variant.SKU}");
                        }
                        variant.StockQuantity = (variant.StockQuantity ?? 0) - quantity;
                    }
                }
                else
                {
                    var product = context.Products
                        .FirstOrDefault(p => p.ProductID == detail.ProductID);

                    if (product != null)
                    {
                        if ((product.StockQuantity ?? 0) < quantity)
                        {
                            throw new Exception($"Không đủ tồn kho cho sản phẩm: {product.Name}");
                        }
                        product.StockQuantity = (product.StockQuantity ?? 0) - quantity;
                        product.SoldCount = (product.SoldCount ?? 0) + quantity;
                    }
                }
            }
            // Không cần SaveChanges ở đây vì nó sẽ được gọi trong UpdateOrderStatus
        }

        // Áp dụng IDisposable, nhưng hiện tại đã sử dụng using cục bộ, 
        // nên phương thức này chỉ cần rỗng.
        public void Dispose()
        {
            // _context?.Dispose(); // Không cần thiết vì đã bỏ _context readonly
        }
    }
}