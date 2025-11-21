using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Skynet_Commerce.BLL.Services.Seller
{
    public class OrderServiceForSeller
    {
        private readonly ApplicationDbContext _context;

        public OrderServiceForSeller()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<List<OrderSellerDTO>> GetOrdersForSeller(int shopId)
        {
            var query = from od in _context.OrderDetails
                        join o in _context.Orders on od.OrderID equals o.OrderID
                        join acc in _context.Accounts on o.AccountID equals acc.AccountID
                        join ua in _context.UserAddresses on o.AddressID equals ua.AddressID
                        join u in _context.Users on o.AccountID equals u.AccountID into userJoin
                        from uj in userJoin.DefaultIfEmpty()
                        join p in _context.Products on od.ProductID equals p.ProductID
                        join img in _context.ProductImages.Where(i => i.IsPrimary == true)
                            on p.ProductID equals img.ProductID into imgJoin
                        from imgPrimary in imgJoin.DefaultIfEmpty()
                        join v in _context.ProductVariants on od.VariantID equals v.VariantID into vJoin
                        from variant in vJoin.DefaultIfEmpty()
                        where o.ShopID == shopId
                        select new OrderSellerDTO
                        {
                            OrderID = o.OrderID,
                            CustomerName = uj.FullName ?? "Khách không tên",
                            CustomerPhone = acc.Phone,
                            ProductName = p.Name,
                            Variant = variant != null ? (variant.Size + " - " + variant.Color) : "Không có",
                            ImageURL = imgPrimary.ImageURL,
                            CreatedAt = (DateTime)o.CreatedAt,
                            UnitPrice = (decimal)od.UnitPrice,
                            Quantity = (int)od.Quantity,
                            SubTotal = (decimal)od.SubTotal,
                            TotalOrderAmount = (decimal)o.TotalAmount,
                            Status = o.Status,
                            AddressFull = ua.AddressLine + ", " + ua.Ward + ", " + ua.District + ", " + ua.Province
                        };

            return await query.ToListAsync();
        }


        public bool UpdateOrderStatus(int orderID, string newStatus)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order == null)
                return false;

            if (newStatus == "Đang giao")
            {
                var orderDetails = _context.OrderDetails
                    .Where(od => od.OrderID == orderID)
                    .ToList();

                foreach (var detail in orderDetails)
                {
                    if (detail.VariantID != null)
                    {
                        var variant = _context.ProductVariants
                            .FirstOrDefault(v => v.VariantID == detail.VariantID);

                        if (variant != null)
                        {
                            if (variant.StockQuantity < detail.Quantity)
                                throw new Exception("Không đủ tồn kho cho sản phẩm: " + variant.SKU);

                            variant.StockQuantity -= detail.Quantity;
                        }
                    }
                    else
                    {
                        var product = _context.Products
                            .FirstOrDefault(p => p.ProductID == detail.ProductID);

                        if (product != null)
                        {
                            if (product.StockQuantity < detail.Quantity)
                                throw new Exception("Không đủ tồn kho cho sản phẩm: " + product.Name);

                            product.StockQuantity -= detail.Quantity;
                        }
                    }
                }
            }

            order.Status = newStatus;
            _context.SaveChanges();
            return true;
        }
    }
}
