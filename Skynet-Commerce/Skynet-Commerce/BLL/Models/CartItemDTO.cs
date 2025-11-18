// TRONG BLL/Models/CartItemDTO.cs (Nếu chưa có)
namespace Skynet_Commerce.BLL.Models
{
    public class CartItemDTO
    {
        public string Id { get; set; } // Dùng để xác định Variant + Product
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } // Path/URL ảnh
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Variant { get; set; } // Ví dụ: "L, Xanh đen"
        public decimal Subtotal => Price * Quantity;
        public bool IsSelected { get; set; } = false;
    }
}