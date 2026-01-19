// Services/ICategoryService.cs
using System.Collections.Generic;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}