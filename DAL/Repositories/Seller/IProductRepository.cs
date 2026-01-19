// Repositories/IProductRepository.cs
using System.Collections.Generic;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductWithDetails(int productId);
        IEnumerable<Product> GetProductsByShop(int shopId);
    }
}