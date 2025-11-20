using System.Collections.Generic;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class ProductFullSellerDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }       
        public int StockQuantity { get; set; }
        public int SoldCount { get; set; }
        public string Status { get; set; }
        public List<ProductImageDTO> Images { get; set; }
        public List<ProductVariantDTO> Variants { get; set; }
    }

    public class ProductImageDTO
    {
        public int ImageID { get; set; }
        public string ImageURL { get; set; }
        public string ImagePublicId { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class ProductVariantDTO
    {
        public int VariantID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string SKU { get; set; }
        public decimal? Price { get; set; }    
        public int StockQuantity { get; set; }
    }
}
