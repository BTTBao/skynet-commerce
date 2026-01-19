// Repositories/ICategoryRepository.cs
using System.Collections.Generic;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryWithProducts(int categoryId);
    }
}