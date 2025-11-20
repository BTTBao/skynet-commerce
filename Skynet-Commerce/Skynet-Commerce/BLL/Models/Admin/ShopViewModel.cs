using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class ShopViewModel
    {
        public int ShopID { get; set; }
        public int AccountID { get; set; }
        public string OwnerName { get; set; }
        public string ShopName { get; set; }
        public decimal? RatingAverage { get; set; }
        public int? StockQuantity { get; set; }
        public string Status { get; set; }
    }
}
