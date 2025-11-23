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

        public List<ProductDTO> GetSuggestedProducts(int limit)
        {
            List<Product> entities = _repo.GetHomeProducts(limit);
            List<ProductDTO> dtos = new List<ProductDTO>();

            foreach (var item in entities)
            {
                // 1. Lấy ảnh chính
                var mainImage = item.ProductImages.FirstOrDefault(x => x.IsPrimary == true)
                                ?? item.ProductImages.FirstOrDefault();

                // 2. [MỚI] Lấy danh sách tất cả đường dẫn ảnh (Thumbnails)
                var imgList = item.ProductImages.Select(x => x.ImageURL).ToList();

                // 3. [MỚI] Lấy danh sách biến thể (Variants)
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
                            // Xử lý null cho giá và kho
                            Price = v.Price.GetValueOrDefault(item.Price.GetValueOrDefault(0)),
                            StockQuantity = v.StockQuantity.GetValueOrDefault(0)
                        });
                    }
                }

                // 4. Tạo DTO
                dtos.Add(new ProductDTO
                {
                    ProductId = item.ProductID,
                    Name = item.Name,
                    Price = item.Price.GetValueOrDefault(0),
                    Rating = 5.0,
                    SoldQuantity = item.SoldCount.GetValueOrDefault(0),

                    // Shop Info
                    ShopId = item.ShopID.GetValueOrDefault(0),
                    ShopName = item.Shop != null ? item.Shop.ShopName : "Unknown Shop",

                    // Image Info
                    ImagePath = mainImage != null ? mainImage.ImageURL : "",
                    ThumbnailPaths = imgList, // Gán list ảnh

                    // Variant Info
                    Variants = variantList // Gán list biến thể
                });
            }

            return dtos;
        }
    }
}