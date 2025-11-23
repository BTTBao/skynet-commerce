using Skynet_Commerce.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; // Bắt buộc để dùng .Include

namespace Skynet_Commerce.DAL.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Product> GetHomeProducts(int limit)
        {
            return _context.Products
                .Include(p => p.ProductImages)   // Lấy Ảnh
                .Include(p => p.ProductVariants) // Lấy Biến thể (Size/Color)
                .Include(p => p.Shop)            // Lấy thông tin Shop
                .Where(p => p.Status == "Active")
                .OrderByDescending(p => p.CreatedAt)
                .Take(limit)
                .ToList();
        }

        public List<Product> Search(string keyword)
        {
            // [QUAN TRỌNG] Cần Include giống hệt hàm trên để lấy Ảnh và Shop
            return _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductVariants)
                .Include(p => p.Shop)
                // [SỬA LỖI] Đổi ProductName -> Name (theo entity của bạn)
                .Where(p => p.Name.Contains(keyword) && p.Status == "Active")
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
        }
    }
}