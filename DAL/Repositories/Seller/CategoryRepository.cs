// Repositories/CategoryRepository.cs
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return DbSet.OrderBy(c => c.CategoryName).ToList();
        }

        public Category GetCategoryWithProducts(int categoryId)
        {
            return DbSet.Include(c => c.Products)
                       .FirstOrDefault(c => c.CategoryID == categoryId);
        }
    }
}