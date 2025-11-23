namespace Skynet_Commerce.BLL.Models.Seller
{
    public class ProductSellerDTO
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ImageUrl { get; set; }   // ảnh đại diện sản phẩm

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int SoldCount { get; set; }

        public string Status { get; set; }
    }
}