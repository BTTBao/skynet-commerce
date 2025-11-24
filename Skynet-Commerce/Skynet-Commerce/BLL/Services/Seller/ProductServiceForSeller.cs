using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Models.Seller;
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
            // 1. Tải Sản phẩm
            var product = _context.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product == null)
                return null;

            // 2. TRUY VẤN TÊN DANH MỤC
            string categoryName = null;
            if (product.CategoryID.HasValue && product.CategoryID.Value > 0)
            {
                var category = _context.Categories
                    .FirstOrDefault(c => c.CategoryID == product.CategoryID.Value);

                if (category != null)
                {
                    categoryName = category.CategoryName;
                }
            }

            // 3. Tải Ảnh
            var images = _context.ProductImages
                .Where(img => img.ProductID == productId)
                .Select(img => new ProductImageDTO
                {
                    ImageID = img.ImageID,
                    ImageURL = img.ImageURL,
                    ImagePublicId = img.ImagePublicId,
                    IsPrimary = (bool)img.IsPrimary
                })
                .ToList();

            // 4. Tải Biến thể
            var variants = _context.ProductVariants
                .Where(v => v.ProductID == productId)
                .Select(v => new ProductVariantDTO
                {
                    VariantID = v.VariantID,
                    Size = v.Size,
                    Color = v.Color,
                    SKU = v.SKU,
                    Price = v.Price,
                    StockQuantity = (int)v.StockQuantity
                })
                .ToList();

            // 5. Khởi tạo DTO
            var dto = new ProductFullSellerDTO
            {
                ProductID = product.ProductID,
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price ?? 0,
                StockQuantity = product.StockQuantity ?? 0,
                SoldCount = product.SoldCount ?? 0,
                Status = product.Status,
                CategoryID = product.CategoryID ?? 0,
                // Gán TÊN DANH MỤC
                CategoryName = categoryName,
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
                int finalCategoryId = 0;

                // 1. KIỂM TRA CATEGORY ID: Nếu CategoryID đã có, sử dụng nó.
                if (dto.CategoryID > 0)
                {
                    finalCategoryId = dto.CategoryID;
                }
                // 2. TÌM KIẾM CATEGORY ID BẰNG TÊN (Giả sử dto có CategoryName)
                else if (!string.IsNullOrEmpty(dto.CategoryName))
                {
                    // Truy vấn cơ sở dữ liệu để tìm CategoryID dựa trên CategoryName
                    var category = _context.Categories
                        .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

                    if (category == null)
                    {
                        // Nếu không tìm thấy danh mục, log lỗi và trả về thất bại
                        Console.WriteLine($"Error adding product: Category name '{dto.CategoryName}' not found.");
                        return -1;
                    }

                    finalCategoryId = category.CategoryID;
                }
                else
                {
                    // Nếu không có cả ID và Name, báo lỗi
                    Console.WriteLine("Error adding product: CategoryID or CategoryName is required.");
                    return -1;
                }


                // Nếu không có CategoryID hợp lệ sau khi tìm kiếm, thoát.
                if (finalCategoryId == 0)
                {
                    Console.WriteLine("Error adding product: Final CategoryID is invalid.");
                    return -1;
                }


                // 3. TẠO ENTITY SẢN PHẨM VỚI FINAL CATEGORY ID
                var product = new Product
                {
                    ShopID = shopId,
                    CategoryID = finalCategoryId, // SỬ DỤNG ID ĐÃ TÌM ĐƯỢC
                    Name = dto.ProductName,
                    Description = dto.Description,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity,
                    // Sử dụng toán tử null-coalescing để cung cấp giá trị mặc định an toàn
                    SoldCount = dto.SoldCount,
                    Status = dto.Status ?? "Active",
                    CreatedAt = DateTime.Now
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                int newProductId = product.ProductID;

                // 4. THÊM ẢNH (Logic giữ nguyên)
                if (dto.Images != null && dto.Images.Any())
                {
                    foreach (var img in dto.Images)
                    {
                        var productImage = new ProductImage
                        {
                            ProductID = newProductId,
                            ImageURL = img.ImageURL,
                            // Giả sử ImagePublicId và IsPrimary là nullable hoặc được xử lý trong DTO
                            ImagePublicId = img.ImagePublicId,
                            IsPrimary = img.IsPrimary
                        };

                        _context.ProductImages.Add(productImage);
                    }
                }

                // 5. THÊM BIẾN THỂ (Logic giữ nguyên)
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

                // Lưu tất cả ảnh và biến thể
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
                int finalCategoryId = 0;

                // 1. KIỂM TRA CATEGORY ID: Nếu CategoryID đã có, sử dụng nó.
                if (dto.CategoryID > 0)
                {
                    finalCategoryId = dto.CategoryID;
                }
                // 2. TÌM KIẾM CATEGORY ID BẰNG TÊN (Giả sử dto có CategoryName)
                else if (!string.IsNullOrEmpty(dto.CategoryName))
                {
                    // Truy vấn cơ sở dữ liệu để tìm CategoryID dựa trên CategoryName
                    var category = _context.Categories
                        .FirstOrDefault(c => c.CategoryName == dto.CategoryName);

                    if (category == null)
                    {
                        // Nếu không tìm thấy danh mục, log lỗi và trả về thất bại
                        Console.WriteLine($"Error adding product: Category name '{dto.CategoryName}' not found.");
                        return false;
                    }

                    finalCategoryId = category.CategoryID;
                }
                else
                {
                    // Nếu không có cả ID và Name, báo lỗi
                    Console.WriteLine("Error adding product: CategoryID or CategoryName is required.");
                    return false;
                }


                // Nếu không có CategoryID hợp lệ sau khi tìm kiếm, thoát.
                if (finalCategoryId == 0)
                {
                    Console.WriteLine("Error adding product: Final CategoryID is invalid.");
                    return false;
                }
                var product = _context.Products.FirstOrDefault(p => p.ProductID == dto.ProductID);
                if (product == null)
                    return false;

                product.Name = dto.ProductName;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.StockQuantity = dto.StockQuantity;
                product.SoldCount = dto.SoldCount;
                product.Status = "Active";
                product.CategoryID = finalCategoryId;

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

        public List<string> GetAllCategories()
        {
            try
            {
                var categories = _context.Categories
                    .Select(c => c.CategoryName.Trim()).ToList();

                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                return null;
            }
        }
    }
}
