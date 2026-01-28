using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int TotalProducts { get; set; }
        public int TotalSubCategories { get; set; }

        // --- Helper Properties để hiển thị lên UI ---

        public string NameDisplay => CategoryName;

        public string ProductCountDisplay => TotalProducts.ToString("N0"); // Format số có dấu phẩy

        public string SubCatCountDisplay => TotalSubCategories.ToString();
    }
}
