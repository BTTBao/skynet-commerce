using Skynet_Commerce.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Helpers
{
    public static class SessionManager
    {
        // Giỏ hàng lưu trong bộ nhớ (Mất khi tắt app)
        public static List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();

        // Hàm thêm sản phẩm vào giỏ
        public static void AddToCart(ProductDTO product, int quantity)
        {
            // Kiểm tra xem sản phẩm đã có trong giỏ chưa
            var existingItem = CartItems.FirstOrDefault(x => x.ProductId == product.ProductId);

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
                    Price = product.Price,
                    Quantity = quantity,
                    ImageUrl = product.ImagePath
                });
            }
        }

        // Hàm xóa khỏi giỏ
        public static void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null) CartItems.Remove(item);
        }

        // Hàm tính tổng tiền
        public static decimal GetTotalAmount()
        {
            return CartItems.Sum(x => x.Price * x.Quantity);
        }
    }

    // DTO đơn giản cho Cart Item
    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}