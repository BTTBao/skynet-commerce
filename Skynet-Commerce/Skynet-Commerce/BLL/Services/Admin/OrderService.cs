using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService()
        {
            _context = new ApplicationDbContext();
        }
        // Hàm lấy danh sách Order cho trang Admin
        public List<OrderViewModel> GetAllOrders()
        {

            // Sử dụng LINQ để join các bảng: Order, Shop, User (thông qua Account), OrderDetail
            var query = from o in _context.Orders
                        join s in _context.Shops on o.ShopID equals s.ShopID
                        // Join vào bảng User để lấy tên người mua (dựa trên AccountID)
                        // Dùng Left Join (DefaultIfEmpty) để tránh lỗi nếu Account chưa có User Profile
                        join u in _context.Users on o.AccountID equals u.AccountID into userGroup
                        from u in userGroup.DefaultIfEmpty()

                        orderby o.CreatedAt descending // Đơn mới nhất lên đầu

                        select new OrderViewModel
                        {
                            OrderID = o.OrderID,
                            BuyerName = u.FullName,
                            ShopName = s.ShopName,

                            // Tính tổng số lượng item trong đơn hàng
                            TotalItems = o.OrderDetails.Sum(od => od.Quantity) ?? 0,

                            TotalAmount = o.TotalAmount ?? 0,
                            CreatedAt = o.CreatedAt ?? DateTime.Now,
                            Status = o.Status
                        };
            return query.ToList();
        }
    }
}

