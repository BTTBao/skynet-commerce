using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Ecommerce;
using Skynet_Ecommerce.BLL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService()
        {
            _context = new ApplicationDbContext();
        }

        public List<ProductViewModel> GetAllProducts(string keyword = "", string categoryName = "All Categories")
        {
            // 1. Khởi tạo Query cơ bản (Join các bảng)
            var query = from p in _context.Products
                        join s in _context.Shops on p.ShopID equals s.ShopID into ps
                        from shop in ps.DefaultIfEmpty()
                        join c in _context.Categories on p.CategoryID equals c.CategoryID into pc
                        from cat in pc.DefaultIfEmpty()
                        select new
                        {
                            p,
                            ShopID = shop.ShopID,
                            CategoryId = cat.CategoryID,
                            ShopName = shop != null ? shop.ShopName : "Unknown",
                            CategoryName = cat != null ? cat.CategoryName : "Uncategorized"
                        };

            // 2. Áp dụng bộ lọc TÌM KIẾM (nếu có keyword)
            if (!string.IsNullOrEmpty(keyword))
            {
                // Tìm theo Tên sản phẩm HOẶC Tên Shop
                query = query.Where(x => x.p.Name.Contains(keyword) || x.ShopName.Contains(keyword));
            }

            // 3. Áp dụng bộ lọc DANH MỤC (nếu không phải chọn tất cả)
            if (!string.IsNullOrEmpty(categoryName) && categoryName != "Tất cả")
            {
                query = query.Where(x => x.CategoryName == categoryName);
            }

            // 4. Sắp xếp và lấy dữ liệu (Lúc này mới chạy câu lệnh SQL)
            var result = query.OrderByDescending(x => x.p.CreatedAt)
                              .Select(x => new ProductViewModel
                              {
                                  ProductID = x.p.ProductID,
                                  ProductName = x.p.Name,
                                  ShopID = x.ShopID,
                                  ShopName = x.ShopName,
                                  CategoryID = x.CategoryId,
                                  CategoryName = x.CategoryName,
                                  Price = x.p.Price ?? 0,
                                  StockQuantity = x.p.StockQuantity ?? 0,
                                  Status = (x.p.StockQuantity == 0) ? "OutOfStock" : x.p.Status
                              }).ToList();

            return result;
        }

        public List<string> GetCategoryNames()
        {
            return _context.Categories
                           .OrderBy(c => c.CategoryName) // Sắp xếp A-Z
                           .Select(c => c.CategoryName)  // Chỉ lấy tên
                           .ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }

    public ProductFullDetailViewModel GetProductFullDetail(int productId)
    {
        // 1. Query thông tin chính + Shop + Category bằng .Include (Nạp ngay lập tức)
        // Cách này thay thế cho việc dùng .Reference().Load() bị lỗi
        var product = _context.Products
                              .Include("Shop")       // Load thông tin Shop
                              .Include("Category")   // Load thông tin Category
                              .FirstOrDefault(p => p.ProductID == productId);

        if (product == null) return null;

        // 2. Lấy tên Chủ Shop (Shop Owner)
        // Vì bảng Account chưa chắc đã có kết nối ngược lại User (User -> Account thì có, nhưng Account -> User có thể chưa config)
        // Nên ta query trực tiếp từ bảng User dựa vào AccountID của Shop cho an toàn nhất.
        string ownerName = "Unknown";
        if (product.Shop != null)
        {
            var owner = _context.Users.FirstOrDefault(u => u.AccountID == product.Shop.AccountID);
            if (owner != null) ownerName = owner.FullName;
        }

        // 3. Lấy danh sách ảnh
        var images = _context.ProductImages
                             .Where(img => img.ProductID == productId)
                             .Select(img => img.ImageURL)
                             .ToList();

        // 4. Lấy danh sách biến thể
        var variants = _context.ProductVariants
                               .Where(v => v.ProductID == productId)
                               .Select(v => new VariantViewModel
                               {
                                   SKU = v.SKU,
                                   Size = v.Size,
                                   Color = v.Color,
                                   Price = v.Price ?? 0,
                                   Stock = v.StockQuantity ?? 0
                               }).ToList();

        // 5. Map sang ViewModel
        return new ProductFullDetailViewModel
        {
            ProductID = product.ProductID,
            ProductName = product.Name,
            Description = product.Description,
            Price = product.Price ?? 0,
            StockQuantity = product.StockQuantity ?? 0,
            CategoryName = product.Category != null ? product.Category.CategoryName : "N/A",
            Status = product.Status,
            CreatedAt = product.CreatedAt ?? DateTime.Now,

            ShopID = product.ShopID ?? 0,
            ShopName = product.Shop != null ? product.Shop.ShopName : "Unknown",
            ShopOwner = ownerName, // Đã lấy ở bước 2

            Images = images,
            Variants = variants
        };
    }
    // Hàm Xóa an toàn (Nghiệp vụ Xóa Mềm)
    public void DeleteProductSafe(int productId)
        {
            var p = _context.Products.FirstOrDefault(x => x.ProductID == productId);
            if (p == null) throw new Exception("Sản phẩm không tồn tại.");

            // 1. Kiểm tra ràng buộc
            bool isUsedInOrders = _context.OrderDetails.Any(od => od.ProductID == productId);
            bool isUsedInCart = _context.CartItems.Any(ci => ci.ProductID == productId);
            bool isVariantUsed = _context.OrderDetails.Any(od => od.ProductVariant.ProductID == productId);

            if (isUsedInOrders || isUsedInCart || isVariantUsed)
            {
                // === SOFT DELETE ===
                // Database không có trạng thái 'Deleted', nên ta dùng 'Hidden'
                p.Status = "Hidden";

                // Đổi tên để đánh dấu (Optional: giúp Admin phân biệt hàng ẩn và hàng xóa)
                if (!p.Name.StartsWith("[Đã xóa]"))
                {
                    p.Name = "[Đã xóa] " + p.Name;
                }
            }
            else
            {
                // === HARD DELETE (Giữ nguyên logic cũ) ===
                var images = _context.ProductImages.Where(x => x.ProductID == productId);
                _context.ProductImages.RemoveRange(images);

                var variants = _context.ProductVariants.Where(x => x.ProductID == productId);
                _context.ProductVariants.RemoveRange(variants);

                var reviews = _context.Reviews.Where(x => x.ProductID == productId);
                _context.Reviews.RemoveRange(reviews);

                var wishlists = _context.Wishlists.Where(x => x.ProductID == productId);
                _context.Wishlists.RemoveRange(wishlists);

                _context.Products.Remove(p);
            }

            _context.SaveChanges();
        }

        public void UpdateProductStatus(int productId, string newStatus)
        {
            // Validate dữ liệu đầu vào chặt chẽ để không gây lỗi SQL
            var allowedStatuses = new List<string> { "Active", "Hidden", "OutOfStock" }
            ;

            if (!allowedStatuses.Contains(newStatus))
            {
                throw new Exception($"Trạng thái '{newStatus}' không hợp lệ. Chỉ chấp nhận: Active, Hidden, OutOfStock.");
            }

            var p = _context.Products.Find(productId);
            if (p != null)
            {
                p.Status = newStatus;
                _context.SaveChanges();
            }
        }
    }
}
