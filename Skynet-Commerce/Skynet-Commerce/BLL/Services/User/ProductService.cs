using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService()
        {
            _repo = new ProductRepository();
        }

        // Hàm hỗ trợ map từ Entity sang DTO để tránh viết lại code nhiều lần
        private ProductDTO MapToDTO(Product item)
        {
            // 1. Lấy ảnh chính
            var mainImage = item.ProductImages.FirstOrDefault(x => x.IsPrimary == true)
                            ?? item.ProductImages.FirstOrDefault();

            // 2. Lấy danh sách link ảnh
            var imgList = item.ProductImages.Select(x => x.ImageURL).ToList();

            // 3. Lấy danh sách biến thể
            var variantList = new List<ProductVariantDTO>();
            if (item.ProductVariants != null)
            {
                foreach (var v in item.ProductVariants)
                {
                    variantList.Add(new ProductVariantDTO
                    {
                        VariantID = v.VariantID,
                        Size = v.Size,
                        Color = v.Color,
                        Price = v.Price.GetValueOrDefault(item.Price.GetValueOrDefault(0)),
                        StockQuantity = v.StockQuantity.GetValueOrDefault(0)
                    });
                }
            }

            // 4. Trả về DTO hoàn chỉnh
            return new ProductDTO
            {
                ProductId = item.ProductID,
                Name = item.Name, // [SỬA] Dùng Name
                Price = item.Price.GetValueOrDefault(0),
                Rating = 5.0, // Mặc định hoặc lấy từ DB nếu có
                SoldQuantity = item.SoldCount.GetValueOrDefault(0),

                // Shop Info
                ShopId = item.ShopID.GetValueOrDefault(0),
                ShopName = item.Shop != null ? item.Shop.ShopName : "Unknown Shop",

                // Image Info
                ImagePath = mainImage != null ? mainImage.ImageURL : "",
                ThumbnailPaths = imgList,

                // Variants
                Variants = variantList
            };
        }

        public List<ProductDTO> GetSuggestedProducts(int limit)
        {
            var entities = _repo.GetHomeProducts(limit);
            return entities.Select(e => MapToDTO(e)).ToList();
        }

        public List<ProductDTO> SearchProducts(string keyword)
        {
            var entities = _repo.Search(keyword);
            // Sử dụng chung logic map để đảm bảo dữ liệu đầy đủ như trang chủ
            return entities.Select(e => MapToDTO(e)).ToList();
        }
    }
}