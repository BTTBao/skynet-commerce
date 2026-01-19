// Services/ProductService.cs
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
        private readonly string _imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            // Tạo thư mục lưu ảnh nếu chưa có
            if (!Directory.Exists(_imageDirectory))
            {
                Directory.CreateDirectory(_imageDirectory);
            }
        }

        public bool AddProduct(ProductDTO productDto, int shopId)
        {
            try
            {
                // Tạo Product
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

                // Lưu ảnh chính
                if (!string.IsNullOrEmpty(productDto.MainImagePath))
                {
                    string savedImagePath = SaveImage(productDto.MainImagePath, product.ProductID, true);

                    var mainImage = new ProductImage
                    {
                        ProductID = product.ProductID,
                        ImageURL = savedImagePath,
                        IsPrimary = true
                    };
                    _unitOfWork.ProductImages.Add(mainImage);
                }

                // Lưu ảnh phụ
                if (productDto.SubImagePaths != null && productDto.SubImagePaths.Any())
                {
                    foreach (var imagePath in productDto.SubImagePaths)
                    {
                        string savedImagePath = SaveImage(imagePath, product.ProductID, false);

                        var subImage = new ProductImage
                        {
                            ProductID = product.ProductID,
                            ImageURL = savedImagePath,
                            IsPrimary = false
                        };
                        _unitOfWork.ProductImages.Add(subImage);
                    }
                }

                // Lưu variants
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
                // Log error
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }

        private string SaveImage(string sourcePath, int productId, bool isPrimary)
        {
            try
            {
                string fileName = $"{productId}_{(isPrimary ? "main" : Guid.NewGuid().ToString())}_{Path.GetFileName(sourcePath)}";
                string destinationPath = Path.Combine(_imageDirectory, fileName);

                File.Copy(sourcePath, destinationPath, true);

                // Trả về đường dẫn tương đối
                return Path.Combine("ProductImages", fileName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving image: {ex.Message}");
            }
        }

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
            catch
            {
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