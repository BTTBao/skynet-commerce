using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class PendingShopViewModel
    {
        public int RegistrationID { get; set; } // ID của đơn đăng ký
        public string ShopName { get; set; }
        public string OwnerName { get; set; }   // Lấy từ bảng User
        public string Email { get; set; }       // Lấy từ bảng Account
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
    }
}
