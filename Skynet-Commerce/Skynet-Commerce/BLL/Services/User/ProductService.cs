using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.DAL.Repositories;
using Skynet_Commerce.DAL.Repositories.User;
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

        // Lấy danh sách sản phẩm gợi ý (đã chuyển sang DTO)
        public List<ProductDTO> GetSuggestedProducts(int limit)
        {
            // 1. Lấy dữ liệu thô từ DAL
            List<Product> entities = _repo.GetHomeProducts(limit);

            // 2. Chuyển đổi sang DTO
            List<ProductDTO> dtos = new List<ProductDTO>();

            foreach (var item in entities)
            {
                // Logic lấy ảnh: Ưu tiên ảnh chính (IsPrimary=true), nếu không có thì lấy ảnh đầu tiên
                var mainImage = item.ProductImages.FirstOrDefault(x => x.IsPrimary == true)
                                ?? item.ProductImages.FirstOrDefault();

                dtos.Add(new ProductDTO
                {
                    ProductId = item.ProductID,
                    Name = item.Name,
                    // Xử lý giá trị null của Price và SoldCount
                    Price = item.Price.GetValueOrDefault(0),
                    Rating = 5.0, // Database chưa có bảng rating trung bình, tạm để 5.0
                    SoldQuantity = item.SoldCount.GetValueOrDefault(0),
                    // Lấy URL ảnh, nếu không có ảnh nào thì để chuỗi rỗng
                    ImagePath = mainImage != null ? mainImage.ImageURL : ""
                });
            }

            return dtos;
        }
    }
}