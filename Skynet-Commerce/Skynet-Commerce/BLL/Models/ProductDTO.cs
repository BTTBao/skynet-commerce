using System;
using System.Collections.Generic;
using System.Drawing;

namespace Skynet_Commerce.BLL.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public int ShopId { get; set; } // [MỚI] ID Shop
        public string ShopName { get; set; } // [MỚI] Tên Shop

        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public double? Rating { get; set; }
        public int? SoldQuantity { get; set; }

        public Image Image { get; set; }
        public string ImagePath { get; set; }

        public int InitialQuantity { get; set; } = 1;
        public List<string> ThumbnailPaths { get; set; } = new List<string>();
        public List<ProductVariantDTO> Variants { get; set; } = new List<ProductVariantDTO>();

        public int DiscountPercent
        {
            get
            {
                if (OldPrice.HasValue && Price < OldPrice.Value && OldPrice.Value > 0)
                {
                    return (int)((1 - (Price / OldPrice.Value)) * 100);
                }
                return 0;
            }
        }
    }

    public class ProductVariantDTO
    {
        public int VariantID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}