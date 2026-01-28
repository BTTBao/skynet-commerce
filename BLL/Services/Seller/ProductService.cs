using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        // Bỏ biến _imageDirectory vì không cần lưu ảnh cục bộ nữa

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddProduct(ProductDTO productDto, int shopId)
        {
            try
            {
                // 1. Tạo Product
                var product = new Product
                {
                    ShopID = shopId,
                    CategoryID = productDto.CategoryId,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    StockQuantity = productDto.Variants.Sum(v => v.Stock),
                    SoldCount = 0,
                    Status = "Active",
                    CreatedAt = DateTime.Now
                };

                _unitOfWork.Products.Add(product);
                _unitOfWork.Complete(); // Lưu để lấy ProductID

                // 2. Lưu ảnh chính (Dùng trực tiếp URL từ DTO, KHÔNG gọi SaveImage)
                if (!string.IsNullOrEmpty(productDto.MainImagePath))
                {
                    var mainImage = new ProductImage
                    {
                        ProductID = product.ProductID,
                        ImageURL = productDto.MainImagePath, // URL Cloudinary
                        IsPrimary = true
                    };
                    _unitOfWork.ProductImages.Add(mainImage);
                }

                // 3. Lưu ảnh phụ (Dùng trực tiếp URL từ DTO)
                if (productDto.SubImagePaths != null && productDto.SubImagePaths.Any())
                {
                    foreach (var imagePath in productDto.SubImagePaths)
                    {
                        var subImage = new ProductImage
                        {
                            ProductID = product.ProductID,
                            ImageURL = imagePath, // URL Cloudinary
                            IsPrimary = false
                        };
                        _unitOfWork.ProductImages.Add(subImage);
                    }
                }

                // 4. Lưu variants
                if (productDto.Variants != null && productDto.Variants.Any())
                {
                    foreach (var variantData in productDto.Variants)
                    {
                        var variant = new ProductVariant
                        {
                            ProductID = product.ProductID,
                            Color = variantData.Color,
                            Size = variantData.Size,
                            SKU = variantData.SKU,
                            Price = variantData.Price,
                            StockQuantity = variantData.Stock
                        };
                        _unitOfWork.ProductVariants.Add(variant);
                    }
                }

                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                // Nếu muốn debug kỹ hơn, hãy throw ex ra ngoài để Form bắt được
                throw;
            }
        }

        // Bỏ hàm SaveImage vì không dùng nữa
        // private string SaveImage(...) { ... }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Products.GetProductWithDetails(id);
        }

        public IEnumerable<Product> GetProductsByShop(int shopId)
        {
            return _unitOfWork.Products.GetProductsByShop(shopId);
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                _unitOfWork.Products.Update(product);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = _unitOfWork.Products.GetById(id);
                if (product != null)
                {
                    product.Status = "Deleted";
                    _unitOfWork.Products.Update(product);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}