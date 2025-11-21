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

        public OrderDetailDTO GetOrderDetail(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null) return null;

            var user = _context.Users.FirstOrDefault(u => u.AccountID == order.AccountID);
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == order.AccountID);

            // Lấy danh sách sản phẩm trong đơn
            var items = (from od in _context.OrderDetails
                         join p in _context.Products on od.ProductID equals p.ProductID
                         where od.OrderID == orderId
                         select new OrderItemDTO
                         {
                             ProductName = p.Name,
                             Quantity = od.Quantity ?? 0,
                             Price = od.UnitPrice ?? 0
                         }).ToList();

            return new OrderDetailDTO
            {
                OrderID = order.OrderID,
                OrderDate = order.CreatedAt ?? DateTime.Now,
                Status = order.Status,
                TotalAmount = order.TotalAmount ?? 0,
                BuyerName = user != null ? user.FullName : "Unknown",
                BuyerEmail = account != null ? account.Email : "",
                Items = items
            };
        }
    }

    public class OrderDetailDTO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        // Thông tin người mua
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; } // Nếu có trong bảng Account/User

        // Danh sách sản phẩm
        public List<OrderItemDTO> Items { get; set; }
    }

    public class OrderItemDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal => Quantity * Price;
    }
}

