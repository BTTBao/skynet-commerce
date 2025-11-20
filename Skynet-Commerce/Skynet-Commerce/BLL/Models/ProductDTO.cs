
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Skynet_Commerce.BLL.Models
{
    /// <summary>
    /// ProductDTO: Lớp DTO để truyền dữ liệu sản phẩm giữa các tầng (Data Transfer Object).
    /// </summary>
    public class ProductDTO
    {
        // Thuộc tính cơ bản (Chỉ chứa dữ liệu)
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; } // Giá cũ (có thể null nếu không có khuyến mãi)
        public double? Rating { get; set; } // Đánh giá
        public int? SoldQuantity { get; set; } // Số lượng đã bán

        // Dữ liệu cho giao diện
        public Image Image { get; set; }
        public string ImagePath { get; set; }

        // Dữ liệu tạm thời cho giỏ hàng
        public int InitialQuantity { get; set; } = 1;
        public List<string> ThumbnailPaths { get; set; } = new List<string>(); // <<< MỚI: Danh sách đường dẫn ảnh phụ

        // <<< MỚI: Danh sách các biến thể của sản phẩm này >>>
        public List<ProductVariantDTO> Variants { get; set; } = new List<ProductVariantDTO>();

        // Thuộc tính tính toán (Được giữ lại vì nó là tính toán dựa trên dữ liệu thuần túy)
        public int DiscountPercent
        {
            get
            {
                if (OldPrice.HasValue && Price < OldPrice.Value && OldPrice.Value > 0)
                {
                    // Tránh chia cho 0
                    if (OldPrice.Value > 0)
                    {
                        return (int)((1 - (Price / OldPrice.Value)) * 100);
                    }
                }
                return 0;
            }
        }
    }
    public class ProductOption
    {
        public string Value { get; set; }
        public bool IsAvailable { get; set; } = true;
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