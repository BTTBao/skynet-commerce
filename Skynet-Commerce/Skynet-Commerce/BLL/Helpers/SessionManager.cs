using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.BLL.Services;
using Skynet_Commerce.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Helpers
{
    public static class SessionManager
    {
        public static List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
        public static UserSessionDTO CurrentUser { get; set; } // Giữ lại để tránh lỗi legacy

        // Hàm thêm (Giữ nguyên code cũ của bạn)
        public static void AddToCart(ProductDTO product, int quantity, int? variantId = null, string variantName = "")
        {
            // 1. Kiểm tra xem sản phẩm + biến thể này đã có trong giỏ chưa
            var existingItem = CartItems.FirstOrDefault(x => x.ProductId == product.ProductId && x.VariantId == variantId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItemDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price, // Lưu ý: Nếu biến thể có giá riêng thì phải truyền giá biến thể vào
                    Quantity = quantity,
                    ImageUrl = product.ImagePath,
                    VariantId = variantId,    // [MỚI]
                    VariantName = variantName // [MỚI]
                });
            }

            // 2. Lưu xuống DB nếu đã đăng nhập
            if (AppSession.Instance.IsLoggedIn)
            {
                try
                {
                    CartService service = new CartService();
                    service.AddItemToDb(AppSession.Instance.AccountID, product.ProductId, quantity, variantId);
                }
                catch { }
            }
        }

        // [CẬP NHẬT] Hàm xóa xử lý cả DB
        public static void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                // 1. Xóa trên RAM (Giao diện cập nhật ngay)
                CartItems.Remove(item);

                // 2. Xóa dưới Database (nếu đã đăng nhập)
                if (AppSession.Instance.IsLoggedIn)
                {
                    try
                    {
                        CartService service = new CartService();
                        service.RemoveItemFromDb(AppSession.Instance.AccountID, productId);
                    }
                    catch
                    {
                        // Bỏ qua lỗi nếu không xóa được dưới DB (để tránh treo app)
                    }
                }
            }
        }

        public static decimal GetTotalAmount()
        {
            return CartItems.Sum(x => x.Price * x.Quantity);
        }

        public static void ClearCart()
        {
            CartItems.Clear();
        }
    }
}