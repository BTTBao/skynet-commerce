using System;

namespace Skynet_Commerce.BLL.Models
{
    // DTO (Data Transfer Object) dùng để lưu thông tin phiên đăng nhập
    public class UserSessionDTO
    {
        public int AccountID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // Ví dụ: "Buyer", "Seller", "Admin"
        public int CartCount { get; set; } // Số lượng giỏ hàng hiển thị trên Header
        public string AvatarURL { get; set; } // Thêm nếu cần hiển thị ảnh
    }
}