using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            if (!string.IsNullOrEmpty(categoryName) && categoryName != "All Categories")
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
                                  Status = (x.p.StockQuantity == 0) ? "Out of Stock" : x.p.Status
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
    }
}
