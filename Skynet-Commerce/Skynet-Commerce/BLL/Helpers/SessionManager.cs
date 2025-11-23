using Skynet_Commerce.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Helpers
{
    public static class SessionManager
    {
        public static List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
        public static UserSessionDTO CurrentUser { get; set; } = null;
        public static void AddToCart(ProductDTO product, int quantity)
        {
            // [QUAN TRỌNG] Tìm xem sản phẩm này đã có trong giỏ chưa?
            // Lưu ý: Ở đây mình tìm theo ProductId. 
            // Nếu sau này bạn làm biến thể (Size/Màu), phải so sánh thêm cả VariantID nữa nhé.
            var existingItem = CartItems.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (existingItem != null)
            {
                // NẾU ĐÃ CÓ -> CỘNG DỒN SỐ LƯỢNG
                existingItem.Quantity += quantity;
            }
            else
            {
                // NẾU CHƯA CÓ -> THÊM MỚI
                CartItems.Add(new CartItemDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    ImageUrl = product.ImagePath
                });
            }
        }

        public static void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null) CartItems.Remove(item);
        }

        public static decimal GetTotalAmount()
        {
            return CartItems.Sum(x => x.Price * x.Quantity);
        }
    }

    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
    public class UserSessionDTO
    {
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Buyer, Seller, Admin
    }
}