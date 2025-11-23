namespace Skynet_Commerce.BLL.Models
{
    public class ShopDTO
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public int ProductCount { get; set; } // Số lượng sản phẩm
        public string JoinDate { get; set; }  // Ngày tham gia

        // Danh sách sản phẩm của shop
        public System.Collections.Generic.List<ProductDTO> Products { get; set; }
    }
}