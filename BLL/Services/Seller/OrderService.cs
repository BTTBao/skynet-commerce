// Services/OrderService.cs
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetOrdersByShop(int shopId)
        {
            return _unitOfWork.Orders.GetOrdersByShop(shopId);
        }

        public IEnumerable<Order> GetOrdersByShopAndStatus(int shopId, string status)
        {
            if (status == "All" || string.IsNullOrEmpty(status))
            {
                return GetOrdersByShop(shopId);
            }
            return _unitOfWork.Orders.GetOrdersByShopAndStatus(shopId, status);
        }

        public Order GetOrderById(int orderId)
        {
            return _unitOfWork.Orders.GetOrderWithDetails(orderId);
        }

        public bool UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                var order = _unitOfWork.Orders.GetById(orderId);
                if (order == null) return false;

                string oldStatus = order.Status;

                // Validate status transition
                if (!IsValidStatusTransition(oldStatus, newStatus))
                {
                    return false;
                }

                order.Status = newStatus;
                _unitOfWork.Orders.Update(order);

                // Lưu lịch sử thay đổi trạng thái
                var history = new OrderStatusHistory
                {
                    OrderID = orderId,
                    OldStatus = oldStatus,
                    NewStatus = newStatus,
                    ChangedAt = DateTime.Now
                };
                _unitOfWork.OrderStatusHistory.Add(history);

                _unitOfWork.Complete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidStatusTransition(string oldStatus, string newStatus)
        {
            // Định nghĩa các chuyển đổi trạng thái hợp lệ
            var validTransitions = new Dictionary<string, List<string>>
            {
                { "Pending", new List<string> { "Confirmed", "Cancelled" } },
                { "Confirmed", new List<string> { "Preparing", "Cancelled" } },
                { "Preparing", new List<string> { "Shipping", "Cancelled" } },
                { "Shipping", new List<string> { "Delivered", "Cancelled" } },
                { "Delivered", new List<string> { "Completed" } }
            };

            if (!validTransitions.ContainsKey(oldStatus))
                return false;

            return validTransitions[oldStatus].Contains(newStatus);
        }

        public OrderStatistics GetOrderStatistics(int shopId)
        {
            var orders = GetOrdersByShop(shopId).ToList();

            return new OrderStatistics
            {
                TotalOrders = orders.Count,
                PendingOrders = orders.Count(o => o.Status == "Pending"),
                ProcessingOrders = orders.Count(o => o.Status == "Confirmed" || o.Status == "Preparing"),
                ShippingOrders = orders.Count(o => o.Status == "Shipping"),
                CompletedOrders = orders.Count(o => o.Status == "Completed" || o.Status == "Delivered"),
                CancelledOrders = orders.Count(o => o.Status == "Cancelled"),
                TotalRevenue = orders.Where(o => o.Status == "Completed" || o.Status == "Delivered")
                                    .Sum(o => o.TotalAmount ?? 0)
            };
        }
    }
}