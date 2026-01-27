using System;
using System.Collections.Generic;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class ShopFullDetailViewModel
    {
        // 1. Thông tin Cửa hàng
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string AvatarURL { get; set; }
        public string Status { get; set; } // Active / Suspended
        public DateTime CreatedAt { get; set; }
        public decimal Rating { get; set; }

        // 2. Thông tin Chủ sở hữu (Từ bảng User & Account)
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } // Giả sử bảng Account hoặc User có Phone

        // 3. Thống kê kinh doanh (Tính toán từ Product & Order)
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; } // Tổng tiền bán được

        // 4. Danh sách con (Để hiển thị lên Grid ở các Tab khác)
        public List<SimpleProductViewModel> TopProducts { get; set; }
        public List<SimpleOrderViewModel> RecentOrders { get; set; }
    }

    public class SimpleProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
    }

    public class SimpleOrderViewModel
    {
        public int OrderID { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}