using Skynet_Commerce.BLL.Models; // Đây là nơi chứa ShopDTO (cho User)
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services
{
    public class UserShopService
    {
        private readonly ShopRepository _shopRepo;

        public UserShopService()
        {
            _shopRepo = new ShopRepository();
        }

        // Hàm này trả về ShopDTO (chuẩn cho User) chứ KHÔNG phải ShopViewModel (Admin)
        public ShopDTO GetShopDetail(int shopId)
        {
            // 1. Lấy Entity từ Database
            Shop shopEntity = _shopRepo.GetShopById(shopId);

            if (shopEntity == null) return null;

            // 2. Lấy danh sách sản phẩm Entity
            List<Product> productsEntity = _shopRepo.GetProductsByShopId(shopId);

            // 3. Chuyển đổi thủ công từ Entity -> DTO (Mapping)
            var productDtos = new List<ProductDTO>();
            foreach (var p in productsEntity)
            {
                // Lấy ảnh đại diện
                var mainImg = p.ProductImages.FirstOrDefault(i => i.IsPrimary == true)
                              ?? p.ProductImages.FirstOrDefault();

                productDtos.Add(new ProductDTO
                {
                    ProductId = p.ProductID,
                    Name = p.Name,
                    Price = p.Price.GetValueOrDefault(0),
                    Rating = 5.0,
                    SoldQuantity = p.SoldCount.GetValueOrDefault(0),
                    // Lấy URL ảnh an toàn
                    ImagePath = mainImg != null ? mainImg.ImageURL : "",

                    // Thông tin shop
                    ShopId = shopId,
                    ShopName = shopEntity.ShopName
                });
            }

            // 4. Trả về ShopDTO hoàn chỉnh
            return new ShopDTO
            {
                ShopId = shopEntity.ShopID,
                ShopName = shopEntity.ShopName,
                Description = shopEntity.Description,
                AvatarUrl = shopEntity.AvatarURL,
                CoverImageUrl = shopEntity.CoverImageURL,
                Rating = shopEntity.RatingAverage.GetValueOrDefault(0),
                ProductCount = productDtos.Count,
                JoinDate = shopEntity.CreatedAt.HasValue ? shopEntity.CreatedAt.Value.ToString("MM/yyyy") : "N/A",

                // Gán danh sách sản phẩm vào Shop
                Products = productDtos
            };
        }
    }
}