using Skynet_Commerce.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; // Cần thiết để dùng .Include()

namespace Skynet_Commerce.DAL.Repositories.User
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository()
        {
            _context = new ApplicationDbContext();
        }

        // Lấy danh sách sản phẩm mới nhất cho trang chủ
        public List<Product> GetHomeProducts(int limit)
        {
            return _context.Products
                .Include(p => p.ProductImages) // Lấy kèm hình ảnh
                .Where(p => p.Status == "Active") // Chỉ lấy sản phẩm đang hoạt động
                .OrderByDescending(p => p.CreatedAt) // Mới nhất lên đầu
                .Take(limit) // Giới hạn số lượng (ví dụ 4 sản phẩm)
                .ToList();
        }
    }
}