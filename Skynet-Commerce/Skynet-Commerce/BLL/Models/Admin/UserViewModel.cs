using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public int? AccountID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
    }
}
