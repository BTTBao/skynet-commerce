using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Linq;
using System.Data.Entity;

namespace Skynet_Commerce.BLL.Services
{
    public class CartService
    {
        // Hàm thêm sản phẩm vào DB (Xử lý cả 2 bảng)
        public void AddItemToDb(int accountId, int productId, int quantity, int? variantId)
        {
            using (var db = new ApplicationDbContext())
            {
                // ... (Đoạn tìm/tạo Cart giữ nguyên) ...
                var cart = db.Carts.FirstOrDefault(c => c.AccountID == accountId);
                if (cart == null) { /* Tạo mới cart... */ }

                // Tìm CartItem khớp cả ProductID VÀ VariantID
                var item = db.CartItems.FirstOrDefault(ci => ci.CartID == cart.CartID
                                                          && ci.ProductID == productId
                                                          && ci.VariantID == variantId); // [QUAN TRỌNG]

                if (item != null) item.Quantity += quantity;
                else
                {
                    item = new CartItem
                    {
                        CartID = cart.CartID,
                        ProductID = productId,
                        VariantID = variantId, // [QUAN TRỌNG]
                        Quantity = quantity,
                        AddedAt = DateTime.Now
                    };
                    db.CartItems.Add(item);
                }
                db.SaveChanges();
            }
        }

        // Hàm load lại giỏ hàng từ DB lên Session (Để khi đăng nhập lại vẫn thấy hàng)
        public void LoadCartFromDbToSession(int accountId)
        {
            using (var db = new ApplicationDbContext())
            {
                // Join các bảng để lấy thông tin chi tiết
                var cart = db.Carts
                             .Include(c => c.CartItems.Select(ci => ci.Product.ProductImages))
                             .FirstOrDefault(c => c.AccountID == accountId);

                // Xóa session cũ trên RAM
                Skynet_Commerce.BLL.Helpers.SessionManager.CartItems.Clear();

                if (cart != null && cart.CartItems != null)
                {
                    foreach (var ci in cart.CartItems)
                    {
                        // Lấy ảnh đại diện
                        var img = ci.Product.ProductImages.FirstOrDefault(i => i.IsPrimary == true)
                                  ?? ci.Product.ProductImages.FirstOrDefault();

                        // Đẩy vào SessionManager để hiển thị lên UI
                        Skynet_Commerce.BLL.Helpers.SessionManager.CartItems.Add(new CartItemDTO
                        {
                            ProductId = ci.ProductID,
                            ProductName = ci.Product.Name,
                            Price = ci.Product.Price.GetValueOrDefault(0),
                            Quantity = ci.Quantity.GetValueOrDefault(1),
                            ImageUrl = img != null ? img.ImageURL : ""
                        });
                    }
                }
            }
        }

        // Hàm xóa
        public void RemoveItemFromDb(int accountId, int productId)
        {
            using (var db = new ApplicationDbContext())
            {
                var cart = db.Carts.FirstOrDefault(c => c.AccountID == accountId);
                if (cart != null)
                {
                    var item = db.CartItems.FirstOrDefault(ci => ci.CartID == cart.CartID && ci.ProductID == productId);
                    if (item != null)
                    {
                        db.CartItems.Remove(item);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}