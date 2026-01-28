// Repositories/ProductRepository.cs
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{ 
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Product GetProductWithDetails(int productId)
        {
            return DbSet.Include(p => p.ProductImages)
                       .Include(p => p.ProductVariants)
                       .Include(p => p.Category)
                       .FirstOrDefault(p => p.ProductID == productId);
        }

        public IEnumerable<Product> GetProductsByShop(int shopId)
        {
            return DbSet.Include(p => p.ProductImages)
                       .Include(p => p.ProductVariants)
                       .Where(p => p.ShopID == shopId)
                       .ToList();
        }
    }
}