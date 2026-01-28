// Services/CategoryService.cs
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System.Collections.Generic;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.Categories.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }
    }
}