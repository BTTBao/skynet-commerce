using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<OrderViewModel> GetAllOrders(string keyword = "", string status = "All", 
            DateTime? fromDate = null, DateTime? toDate = null)
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
            
            // 4. Lọc theo khoảng thời gian
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.o.CreatedAt >= fromDate.Value);
            }
            
            if (toDate.HasValue)
            {
                query = query.Where(x => x.o.CreatedAt <= toDate.Value);
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
            // 1. Lấy đơn hàng và các thông tin cơ bản
            var orderQuery = from o in _context.Orders
                             join s in _context.Shops on o.ShopID equals s.ShopID
                             join u in _context.Users on o.AccountID equals u.AccountID into uGroup
                             from u in uGroup.DefaultIfEmpty()

                                 // Join Địa chỉ giao hàng
                             join addr in _context.UserAddresses on o.AddressID equals addr.AddressID into addrGroup
                             from address in addrGroup.DefaultIfEmpty()

                                 // Join Thông tin vận chuyển
                             join ship in _context.OrderShippingInfoes on o.OrderID equals ship.OrderID into shipGroup
                             from shipping in shipGroup.DefaultIfEmpty()

                             where o.OrderID == orderId
                             select new
                             {
                                 Order = o,
                                 ShopName = s.ShopName,
                                 ShopID = s.ShopID,
                                 BuyerName = u != null ? u.FullName : "Unknown",

                                 // Địa chỉ
                                 ReceiverName = address != null ? address.ReceiverFullName : "",
                                 ReceiverPhone = address != null ? address.ReceiverPhone : "",
                                 FullAddress = address != null ? (address.Province + ", " + address.District + ", " + address.Ward + ", " + address.AddressLine) : "N/A",

                                 // Vận chuyển
                                 ShipFee = shipping != null ? shipping.ShippingFee : 0,
                                 TrackingCode = shipping != null ? shipping.TrackingCode : "N/A"
                             };

            var data = orderQuery.FirstOrDefault();
            if (data == null) return null;

            // 2. Lấy danh sách sản phẩm
            var items = (from od in _context.OrderDetails
                         join p in _context.Products on od.ProductID equals p.ProductID
                         // Join biến thể để lấy Màu/Size
                         join v in _context.ProductVariants on od.VariantID equals v.VariantID into vGroup
                         from variant in vGroup.DefaultIfEmpty()
                         where od.OrderID == orderId
                         select new OrderItemDTO
                         {
                             ProductName = p.Name,
                             // Nếu có biến thể thì hiển thị, không thì để trống
                             VariantInfo = variant != null ? (variant.Color + " / " + variant.Size) : "",
                             Quantity = od.Quantity ?? 0,
                             Price = od.UnitPrice ?? 0
                         }).ToList();

            // 3. Lấy lịch sử đơn hàng
            var histories = _context.OrderStatusHistories
                                    .Where(h => h.OrderID == orderId)
                                    .OrderByDescending(h => h.ChangedAt)
                                    .Select(h => new OrderHistoryDTO
                                    {
                                        OldStatus = h.OldStatus,
                                        NewStatus = h.NewStatus,
                                        ChangedAt = h.ChangedAt ?? DateTime.Now
                                    }).ToList();

            // 4. Map sang DTO
            return new OrderDetailDTO
            {
                OrderID = data.Order.OrderID,
                OrderDate = data.Order.CreatedAt ?? DateTime.Now,
                Status = data.Order.Status,
                TotalAmount = data.Order.TotalAmount ?? 0,
                ShippingFee = data.ShipFee ?? 0,

                BuyerName = data.BuyerName,
                ShopName = data.ShopName,
                ShopID = data.ShopID,

                ReceiverName = data.ReceiverName,
                ReceiverPhone = data.ReceiverPhone,
                DeliveryAddress = data.FullAddress,
                ShippingPartner = "",
                TrackingCode = data.TrackingCode,

                Items = items,
                HistoryLogs = histories
            };
        }

    }

    public class OrderDetailDTO
    {
        // 1. Thông tin chung
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ShippingFee { get; set; } // Phí ship

        // 2. Thông tin Người mua & Shop
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string ShopName { get; set; }
        public int ShopID { get; set; }

        // 3. Thông tin Giao hàng (Từ UserAddress & OrderShippingInfo)
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public string ShippingPartner { get; set; }
        public string TrackingCode { get; set; }

        // 4. Danh sách
        public List<OrderItemDTO> Items { get; set; }
        public List<OrderHistoryDTO> HistoryLogs { get; set; }
    }

    public class OrderItemDTO
    {
        public string ProductName { get; set; }
        public string VariantInfo { get; set; } // Màu/Size
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal => Quantity * Price;
    }

    public class OrderHistoryDTO
    {
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}

