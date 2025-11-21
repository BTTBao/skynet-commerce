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
        public List<OrderViewModel> GetAllOrders(string keyword = "", string status = "All")
        {
            // 1. Khởi tạo query cơ bản (Joins)
            var query = from o in _context.Orders
                        join s in _context.Shops on o.ShopID equals s.ShopID
                        join u in _context.Users on o.AccountID equals u.AccountID into userGroup
                        from u in userGroup.DefaultIfEmpty()
                        select new
                        {
                            o,
                            s,
                            u
                        };

            // 2. Xử lý Tìm kiếm (Nếu có keyword)
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower(); // Chuyển về chữ thường để tìm tương đối
                query = query.Where(x =>
                    x.o.OrderID.ToString().Contains(keyword) ||       // Tìm theo ID đơn
                    x.s.ShopName.ToLower().Contains(keyword) ||      // Tìm theo tên Shop
                    (x.u.FullName != null && x.u.FullName.ToLower().Contains(keyword)) // Tìm theo tên người mua
                );
            }

            // 3. Xử lý Lọc theo trạng thái (Nếu status khác "All")
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                query = query.Where(x => x.o.Status == status);
            }

            // 4. Sắp xếp và Projection (Chuyển đổi sang ViewModel)
            var result = query.OrderByDescending(x => x.o.CreatedAt)
                              .Select(x => new OrderViewModel
                              {
                                  OrderID = x.o.OrderID,
                                  BuyerName = x.u.FullName ?? "Unknown", // Xử lý null
                                  ShopName = x.s.ShopName,
                                  // Tính tổng số lượng (dùng null coalescing)
                                  TotalItems = x.o.OrderDetails.Sum(od => (int?)od.Quantity) ?? 0,
                                  TotalAmount = x.o.TotalAmount ?? 0,
                                  CreatedAt = x.o.CreatedAt ?? DateTime.Now,
                                  Status = x.o.Status
                              });

            return result.ToList();
        }
    }
}

