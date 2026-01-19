// Repositories/OrderRepository.cs
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrdersByShop(int shopId)
        {
            return DbSet
                .Include(o => o.Account)
                .Include(o => o.Account.Users)
                .Include(o => o.UserAddress)
                .Include(o => o.OrderDetails)
                .Include(o => o.OrderDetails.Select(od => od.Product))
                .Include(o => o.OrderDetails.Select(od => od.Product.ProductImages))
                .Include(o => o.OrderDetails.Select(od => od.ProductVariant))
                .Where(o => o.ShopID == shopId)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();
        }

        public Order GetOrderWithDetails(int orderId)
        {
            return DbSet
                .Include(o => o.Account)
                .Include(o => o.Account.Users)
                .Include(o => o.UserAddress)
                .Include(o => o.OrderDetails)
                .Include(o => o.OrderDetails.Select(od => od.Product))
                .Include(o => o.OrderDetails.Select(od => od.Product.ProductImages))
                .Include(o => o.OrderDetails.Select(od => od.ProductVariant))
                .Include(o => o.Shop)
                .FirstOrDefault(o => o.OrderID == orderId);
        }

        public IEnumerable<Order> GetOrdersByShopAndStatus(int shopId, string status)
        {
            return DbSet
                .Include(o => o.Account)
                .Include(o => o.Account.Users)
                .Include(o => o.UserAddress)
                .Include(o => o.OrderDetails)
                .Include(o => o.OrderDetails.Select(od => od.Product))
                .Include(o => o.OrderDetails.Select(od => od.Product.ProductImages))
                .Include(o => o.OrderDetails.Select(od => od.ProductVariant))
                .Where(o => o.ShopID == shopId && o.Status == status)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();
        }
    }
}