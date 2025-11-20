
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
// Đã xóa dòng using bị lỗi ở đây

namespace Skynet_Commerce.BLL.Models
{
    // Giả định rằng ProductDTO và ProductVariantDTO đều nằm trong namespace này (BLL.Models)

    public static class SampleDataGenerator
    {
        public static ProductDTO GetSampleProductDetail()
        {
            string basePath = Application.StartupPath;
            string product1Path = Path.Combine(basePath, @"img\slide1.jpg");

            // Dữ liệu biến thể mẫu
            var variants = new List<ProductVariantDTO>
            {
                new ProductVariantDTO { VariantID = 1, Size = "S", Color = "Xanh đen", Price = 890000, StockQuantity = 50 },
                new ProductVariantDTO { VariantID = 2, Size = "M", Color = "Xanh đen", Price = 890000, StockQuantity = 100 },
                new ProductVariantDTO { VariantID = 3, Size = "L", Color = "Xanh đen", Price = 890000, StockQuantity = 20 },
                new ProductVariantDTO { VariantID = 4, Size = "XL", Color = "Xanh đen", Price = 890000, StockQuantity = 0 }, // Hết hàng
                new ProductVariantDTO { VariantID = 5, Size = "S", Color = "Xanh nhạt", Price = 890000, StockQuantity = 10 },
                new ProductVariantDTO { VariantID = 6, Size = "S", Color = "Đen", Price = 900000, StockQuantity = 150 },
            };

            // Tạo DTO chi tiết
            var product = new ProductDTO
            {
                ProductId = 104,
                Name = "Bộ mỹ phẩm dưỡng da",
                Price = 890000,
                OldPrice = 990000,
                Rating = 4.6,
                SoldQuantity = 890,
                ImagePath = product1Path, // Dùng ảnh mẫu đã có
                Variants = variants,
                // Dữ liệu ảnh phụ (Giả định ảnh thumbs 1, 2, 3 có trong thư mục)
                ThumbnailPaths = new List<string> {
                    product1Path,
                    Path.Combine(basePath, @"img\slide1.jpg"),
                    Path.Combine(basePath, @"img\slide1.jpg"),
                    Path.Combine(basePath, @"img\slide1.jpg")
                }
            };

            return product;
        }
    }
}