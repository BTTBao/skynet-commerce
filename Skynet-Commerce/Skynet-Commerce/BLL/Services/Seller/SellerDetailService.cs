using Skynet_Commerce.BLL.Models.Seller;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.BUS.Services
{
    public class SellerDetailService
    {
        private readonly ApplicationDbContext _context;

        public SellerDetailService()
        {
            _context = new ApplicationDbContext();
        }

        public SellerDetailDto GetSellerDetails(int? shopId, int? accountId)
        {
            if (shopId == null && accountId == null)
            {
                return null;
            }

            // 1. Bắt đầu truy vấn từ Shops
            var shopQuery = _context.Shops.AsQueryable();

            if (shopId.HasValue)
            {
                shopQuery = shopQuery.Where(s => s.ShopID == shopId.Value);
            }
            else if (accountId.HasValue)
            {
                shopQuery = shopQuery.Where(s => s.AccountID == accountId.Value);
            }

            // 2. Sử dụng Select để Projection dữ liệu từ Shops và Accounts
            var result = shopQuery
                .Select(s => new SellerDetailDto
                {
                    // Từ Shops
                    ShopID = s.ShopID,
                    ShopName = s.ShopName,
                    Description = s.Description,
                    AvatarURL = s.AvatarURL ?? "",
                    CoverImageURL = s.CoverImageURL ?? "",
                    RatingAverage = (decimal)s.RatingAverage,
                    IsActive = (bool)s.IsActive,

                    // Từ Accounts
                    AccountID = s.AccountID,
                    SellerEmail = s.Account.Email,
                    SellerPhone = s.Account.Phone,
                })
                .FirstOrDefault();

            return result;
        }

        public bool UpdateShopSettings(SellerDetailDto updateDto)
        {
            try
            {
                // 1. Tìm Shop Entity
                var shopEntity = _context.Shops.FirstOrDefault(s => s.ShopID == updateDto.ShopID);

                if (shopEntity == null)
                {
                    // Lỗi: Không tìm thấy Shop
                    return false;
                }

                var acc = _context.Accounts.FirstOrDefault(a => a.AccountID == shopEntity.AccountID);

                // 2. Cập nhật thông tin Shops
                shopEntity.ShopName = updateDto.ShopName;
                shopEntity.Description = updateDto.Description;
                shopEntity.AvatarURL = updateDto.AvatarURL;
                shopEntity.CoverImageURL = updateDto.CoverImageURL;
                if (acc != null)
                {
                    acc.Email = updateDto.SellerEmail;
                    acc.Phone = updateDto.SellerPhone;
                }

                // 4. Lưu thay đổi vào Database
                _context.SaveChanges();

                return true; // Thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "LỖI DATABASE:\n" + ex.Message +
                    "\n\nINNER EXCEPTION:\n" + ex.InnerException?.Message +
                    "\n\nSTACK TRACE:\n" + ex.InnerException?.StackTrace
                );
                return false; // Thất bại
            }


        }
    }
}