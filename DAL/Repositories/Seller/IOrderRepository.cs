// Repositories/IOrderRepository.cs
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System.Collections.Generic;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByShop(int shopId);
        Order GetOrderWithDetails(int orderId);
        IEnumerable<Order> GetOrdersByShopAndStatus(int shopId, string status);
    }
}