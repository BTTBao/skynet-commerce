// Services/IOrderService.cs
using System.Collections.Generic;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrdersByShop(int shopId);
        IEnumerable<Order> GetOrdersByShopAndStatus(int shopId, string status);
        Order GetOrderById(int orderId);
        bool UpdateOrderStatus(int orderId, string newStatus);
        OrderStatistics GetOrderStatistics(int shopId);
    }

    public class OrderStatistics
    {
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int ShippingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int CancelledOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}