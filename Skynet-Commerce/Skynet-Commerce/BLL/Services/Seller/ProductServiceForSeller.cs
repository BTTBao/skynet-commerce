using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Skynet_Commerce.BLL.Services.Seller
{
    public class ProductServiceForSeller
    {
        private readonly ApplicationDbContext _context;

        public ProductServiceForSeller()
        {
            _context = new ApplicationDbContext();
        }

        public List<ProductSellerDTO> GetAllProducts(int shopId)
        {
            var query = from p in _context.Products
                        where p.ShopID == shopId
                        select new ProductSellerDTO
                        {
                            ProductID = p.ProductID,
                            ProductName = p.Name,
                            Price = p.Price ?? 0,
                            StockQuantity = p.StockQuantity ?? 0,
                            SoldCount = p.SoldCount ?? 0,
                            Status = (p.StockQuantity == 0) ? "OutOfStock" : p.Status,

                            // Ảnh đại diện
                            ImageUrl = _context.ProductImages
                                        .Where(img => img.ProductID == p.ProductID)
                                        .OrderByDescending(img => img.IsPrimary)
                                        .Select(img => img.ImageURL)
                                        .FirstOrDefault()
                        };

            return query
                .OrderByDescending(x => x.ProductID)
                .ToList();
        }

        public bool UpdateProductStatus(int productId, string newStatus)
        {
            var validStatuses = new List<string> { "Active", "Hidden", "OutOfStock" };

            if (!validStatuses.Contains(newStatus))
                return false;
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
                return false;

            product.Status = newStatus;
            _context.SaveChanges();
            return true;
        }

        public ProductFullSellerDTO GetProductFullSellerDTO(int productId)
        {
            var product = _context.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product == null)
                return null;

            var images = _context.ProductImages
                .Where(img => img.ProductID == productId)
                .Select(img => new ProductImageDTO
                {
                    ImageID = img.ImageID,
                    ImageURL = img.ImageURL,
                    ImagePublicId = img.ImagePublicId,
                    IsPrimary = img.IsPrimary
                })
                .ToList();

            var variants = _context.ProductVariants
                .Where(v => v.ProductID == productId)
                .Select(v => new ProductVariantDTO
                {
                    VariantID = v.VariantID,
                    Size = v.Size,
                    Color = v.Color,
                    SKU = v.SKU,
                    Price = v.Price,
                    StockQuantity = v.StockQuantity
                })
                .ToList();

            var dto = new ProductFullSellerDTO
            {
                ProductID = product.ProductID,
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price ?? 0,
                StockQuantity = product.StockQuantity ?? 0,
                SoldCount = product.SoldCount ?? 0,
                Status = product.Status,

                Images = images,
                Variants = variants
            };

            return dto;
        }


        public bool DeleteProductFullSeller(int productId)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
                if (product == null)
                    return false;
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting product: " + ex.Message);
                return false;
            }
        }


        public int AddProductFullSeller(ProductFullSellerDTO dto, int shopId)
        {
            try
            {
                var product = new Product
                {
                    ShopID = shopId,
                    CategoryID = dto.CategoryID,      
                    Name = dto.ProductName,
                    Description = dto.Description,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity,
                    SoldCount = dto.SoldCount,
                    Status = dto.Status ?? "Active",
                    CreatedAt = DateTime.Now
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                int newProductId = product.ProductID;

                if (dto.Images != null && dto.Images.Any())
                {
                    foreach (var img in dto.Images)
                    {
                        var productImage = new ProductImage
                        {
                            ProductID = newProductId,
                            ImageURL = img.ImageURL,
                            ImagePublicId = img.ImagePublicId,
                            IsPrimary = img.IsPrimary
                        };

                        _context.ProductImages.Add(productImage);
                    }
                }

                if (dto.Variants != null && dto.Variants.Any())
                {
                    foreach (var v in dto.Variants)
                    {
                        var variant = new ProductVariant
                        {
                            ProductID = newProductId,
                            Size = v.Size,
                            Color = v.Color,
                            SKU = v.SKU,
                            Price = v.Price,
                            StockQuantity = v.StockQuantity
                        };

                        _context.ProductVariants.Add(variant);
                    }
                }

                _context.SaveChanges();
                return newProductId; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding product: " + ex.Message);
                return -1;
            }
        }


        public bool UpdateProductFullSeller(ProductFullSellerDTO dto)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductID == dto.ProductID);
                if (product == null)
                    return false;

                product.Name = dto.ProductName;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.StockQuantity = dto.StockQuantity;
                product.SoldCount = dto.SoldCount;
                product.Status = dto.Status;
                product.CategoryID = dto.CategoryID;

                _context.SaveChanges();

                var oldImages = _context.ProductImages
                    .Where(i => i.ProductID == dto.ProductID)
                    .ToList();

                _context.ProductImages.RemoveRange(oldImages);

                if (dto.Images != null && dto.Images.Any())
                {
                    foreach (var img in dto.Images)
                    {
                        var newImg = new ProductImage
                        {
                            ProductID = dto.ProductID,
                            ImageURL = img.ImageURL,
                            ImagePublicId = img.ImagePublicId,
                            IsPrimary = img.IsPrimary
                        };
                        _context.ProductImages.Add(newImg);
                    }
                }

                var oldVariants = _context.ProductVariants
                    .Where(v => v.ProductID == dto.ProductID)
                    .ToList();

                _context.ProductVariants.RemoveRange(oldVariants);

                if (dto.Variants != null && dto.Variants.Any())
                {
                    foreach (var v in dto.Variants)
                    {
                        var newVariant = new ProductVariant
                        {
                            ProductID = dto.ProductID,
                            Size = v.Size,
                            Color = v.Color,
                            SKU = v.SKU,
                            Price = v.Price,
                            StockQuantity = v.StockQuantity
                        };
                        _context.ProductVariants.Add(newVariant);
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update product error: " + ex.Message);
                return false;
            }
        } 
    }
}
