using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public string BuyerName { get; set; }
        public string ShopName { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        // --- Các Property dùng để hiển thị lên UI (Format sẵn) ---

        // Format tiền tệ Việt Nam
        public string AmountDisplay => TotalAmount.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));

        public string DateDisplay => CreatedAt.ToString("dd/MM/yyyy");

        // Nếu User bị null (không tìm thấy), hiển thị tên mặc định
        public string BuyerDisplay => string.IsNullOrEmpty(BuyerName) ? "Unknown User" : BuyerName;
    }
}