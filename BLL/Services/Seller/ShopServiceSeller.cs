using System;
using System.Threading.Tasks;
using Skynet_Ecommerce.DAL.Repositories.Seller;

namespace Skynet_Ecommerce.BLL.Services.Seller
{
    public class ShopServiceSeller
    {
        private readonly ShopRepository _shopRepository;

        public ShopServiceSeller()
        {
            _shopRepository = new ShopRepository();
        }

        // ========== GET SHOP INFO ==========
        public async Task<ShopInfoDTO> GetShopByAccountIdAsync(int accountId)
        {
            try
            {
                if (accountId <= 0)
                    throw new ArgumentException("Account ID không hợp lệ");

                return await _shopRepository.GetShopByAccountIdAsync(accountId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin shop: {ex.Message}", ex);
            }
        }

        public async Task<ShopInfoDTO> GetShopByIdAsync(int shopId)
        {
            try
            {
                if (shopId <= 0)
                    throw new ArgumentException("Shop ID không hợp lệ");

                return await _shopRepository.GetShopByIdAsync(shopId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin shop: {ex.Message}", ex);
            }
        }

        // ========== UPDATE SHOP INFO ==========
        public async Task<bool> UpdateShopInfoAsync(
            int shopId,
            string shopName,
            string description,
            string avatarUrl,
            string coverImageUrl,
            bool isActive,
            string email = null,
            string phone = null,
            string addressLine = null,
            string citizenImageUrl = null)
        {
            try
            {
                // Validation
                if (shopId <= 0)
                    throw new ArgumentException("Shop ID không hợp lệ");

                if (string.IsNullOrWhiteSpace(shopName))
                    throw new ArgumentException("Tên shop không được để trống");

                if (shopName.Length < 3 || shopName.Length > 200)
                    throw new ArgumentException("Tên shop phải có độ dài từ 3-200 ký tự");

                // Kiểm tra tên shop đã tồn tại chưa
                bool nameExists = await _shopRepository.IsShopNameExistsAsync(shopName, shopId);
                if (nameExists)
                    throw new ArgumentException("Tên shop đã tồn tại, vui lòng chọn tên khác");

                // Validate email nếu có
                if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
                    throw new ArgumentException("Email không hợp lệ");

                // Validate phone nếu có
                if (!string.IsNullOrEmpty(phone) && !IsValidPhone(phone))
                    throw new ArgumentException("Số điện thoại không hợp lệ (phải là 10 chữ số)");

                // Tạo DTO
                var updateDTO = new ShopUpdateDTO
                {
                    ShopID = shopId,
                    ShopName = shopName,
                    Description = description,
                    AvatarURL = avatarUrl,
                    CoverImageURL = coverImageUrl,
                    IsActive = isActive,
                    Email = email,
                    Phone = phone,
                    AddressLine = addressLine,
                    CitizenImageURL = citizenImageUrl
                };

                // Thực hiện update
                return await _shopRepository.UpdateShopAsync(updateDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật shop: {ex.Message}", ex);
            }
        }

        // ========== UPDATE SHOP STATUS ==========
        public async Task<bool> ToggleShopStatusAsync(int shopId)
        {
            try
            {
                var shop = await _shopRepository.GetShopByIdAsync(shopId);
                if (shop == null)
                    throw new ArgumentException("Không tìm thấy shop");

                return await UpdateShopInfoAsync(
                    shopId,
                    shop.ShopName,
                    shop.Description,
                    shop.AvatarURL,
                    shop.CoverImageURL,
                    !shop.IsActive
                );
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thay đổi trạng thái shop: {ex.Message}", ex);
            }
        }

        // ========== UPDATE RATING ==========
        public async Task UpdateShopRatingAsync(int shopId)
        {
            try
            {
                if (shopId <= 0)
                    throw new ArgumentException("Shop ID không hợp lệ");

                await _shopRepository.UpdateShopRatingAsync(shopId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật rating: {ex.Message}", ex);
            }
        }

        // ========== VALIDATION HELPERS ==========
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains("@") && email.Contains(".");
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Chỉ cho phép 10 chữ số
            if (phone.Length != 10)
                return false;

            // Kiểm tra tất cả ký tự là số
            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        // ========== CHECK SHOP EXISTS ==========
        public async Task<bool> ShopExistsAsync(int accountId)
        {
            try
            {
                var shop = await _shopRepository.GetShopByAccountIdAsync(accountId);
                return shop != null;
            }
            catch
            {
                return false;
            }
        }

        // ========== GET SHOP STATISTICS (Optional - for dashboard) ==========
        public async Task<ShopStatsDTO> GetShopStatisticsAsync(int shopId)
        {
            // TODO: Implement nếu cần thống kê
            // - Tổng số sản phẩm
            // - Tổng đơn hàng
            // - Doanh thu
            // - Số lượt đánh giá
            throw new NotImplementedException("Chức năng thống kê chưa được triển khai");
        }

        // Dispose
        public void Dispose()
        {
            _shopRepository?.Dispose();
        }
    }

    // ========== OPTIONAL DTO FOR STATISTICS ==========
    public class ShopStatsDTO
    {
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalReviews { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalFollowers { get; set; }
    }
}