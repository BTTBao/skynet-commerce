namespace Skynet_Commerce.BLL.Models
{
    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // [THÊM MỚI] Thông tin biến thể
        public int? VariantId { get; set; }
        public string VariantName { get; set; }   // VD: "M, Đen"

        public decimal Subtotal => Price * Quantity;
        public bool IsSelected { get; set; } = true;
    }
}