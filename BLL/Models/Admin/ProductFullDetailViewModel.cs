using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Ecommerce.BLL.Models.Admin
{
    public class ProductFullDetailViewModel
    {
        // 1. Thông tin cơ bản
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; } // Tổng tồn kho
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // 2. Thông tin Shop (Để Admin biết ai bán mà liên hệ/phạt)
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopOwner { get; set; }

        // 3. Danh sách ảnh (URLs)
        public List<string> Images { get; set; }

        // 4. Danh sách biến thể (Size/Màu)
        public List<VariantViewModel> Variants { get; set; }
    }

    public class VariantViewModel
    {
        public string SKU { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
