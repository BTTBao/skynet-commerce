// Services/IProductService.cs
using Skynet_Ecommerce.GUI.Forms.Seller;
using System.Collections.Generic;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public interface IProductService
    {
        bool AddProduct(ProductDTO productDto, int shopId);
        Product GetProductById(int id);
        IEnumerable<Product> GetProductsByShop(int shopId);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }

    // DTO cho Product
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string MainImagePath { get; set; }
        public List<string> SubImagePaths { get; set; }
        public List<VariantData> Variants { get; set; }
    }
}