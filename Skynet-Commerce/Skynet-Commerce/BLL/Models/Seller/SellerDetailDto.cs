using System;

namespace Skynet_Commerce.BLL.Models.Seller
{
    public class SellerDetailDto
    {
        // Thông tin từ bảng Shops
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string AvatarURL { get; set; }
        public string CoverImageURL { get; set; }
        public decimal RatingAverage { get; set; }
        public bool IsActive { get; set; }

        // Thông tin từ bảng Accounts
        public int AccountID { get; set; }
        public string SellerEmail { get; set; }
        public string SellerPhone { get; set; } // Số điện thoại đăng ký tài khoản
    }
}