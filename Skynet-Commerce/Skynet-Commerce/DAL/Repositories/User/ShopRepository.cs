using Skynet_Commerce.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Skynet_Commerce.DAL.Repositories
{
    // [ĐÃ SỬA] Thêm từ khóa 'partial' để khớp với file designer (nếu có)
    public partial class ShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository()
        {
            _context = new ApplicationDbContext();
        }

        // Lấy thông tin chi tiết của Shop
        public Shop GetShopById(int shopId)
        {
            return _context.Shops
                .FirstOrDefault(s => s.ShopID == shopId);
        }

        // Lấy danh sách sản phẩm của Shop đó
        public List<Product> GetProductsByShopId(int shopId)
        {
            return _context.Products
                .Include(p => p.ProductImages)
                .Where(p => p.ShopID == shopId && p.Status == "Active")
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
        }
    }
}