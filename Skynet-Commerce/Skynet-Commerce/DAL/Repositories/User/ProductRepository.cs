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
                .Include(p => p.ProductVariants) // [MỚI] Lấy Biến thể (Size/Color)
                .Include(p => p.Shop)            // Lấy thông tin Shop
                .Where(p => p.Status == "Active")
                .OrderByDescending(p => p.CreatedAt)
                .Take(limit)
                .ToList();
        }
    }
}