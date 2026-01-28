using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    // ========== DTO ==========
    public class ShopInfoDTO
    {
        public int ShopID { get; set; }
        public int AccountID { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string AvatarURL { get; set; }
        public string CoverImageURL { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal RatingAverage { get; set; }

        // Thông tin từ Account
        public string Email { get; set; }
        public string Phone { get; set; }

        // Thông tin từ ShopRegistrations
        public string CitizenImageURL { get; set; }

        // Thông tin địa chỉ (lấy địa chỉ mặc định)
        public string AddressLine { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }

    public class ShopUpdateDTO
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string AvatarURL { get; set; }
        public string CoverImageURL { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine { get; set; }
        public string CitizenImageURL { get; set; }
    }

    // ========== REPOSITORY ==========
    public class ShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository()
        {
            _context = new ApplicationDbContext();
        }

        // Get Shop by AccountID với đầy đủ thông tin
        public async Task<ShopInfoDTO> GetShopByAccountIdAsync(int accountId)
        {
            try
            {
                var result = await (from shop in _context.Shops
                                    join account in _context.Accounts on shop.AccountID equals account.AccountID
                                    where shop.AccountID == accountId
                                    select new
                                    {
                                        shop,
                                        account,
                                        // Lấy địa chỉ mặc định
                                        defaultAddress = _context.UserAddresses
                                            .Where(a => a.AccountID == accountId && a.IsDefault == true)
                                            .FirstOrDefault(),
                                        // Lấy ảnh CCCD từ ShopRegistrations
                                        citizenImage = _context.ShopRegistrations
                                            .Where(r => r.AccountID == accountId && r.Status == "Approved")
                                            .OrderByDescending(r => r.ReviewedAt)
                                            .Select(r => r.CitizenImageURL)
                                            .FirstOrDefault()
                                    })
                                   .FirstOrDefaultAsync();

                if (result == null) return null;

                return new ShopInfoDTO
                {
                    ShopID = result.shop.ShopID,
                    AccountID = result.shop.AccountID,
                    ShopName = result.shop.ShopName,
                    Description = result.shop.Description,
                    AvatarURL = result.shop.AvatarURL,
                    CoverImageURL = result.shop.CoverImageURL,
                    IsActive = result.shop.IsActive ?? true,
                    CreatedAt = result.shop.CreatedAt ?? DateTime.Now,
                    RatingAverage = result.shop.RatingAverage ?? 0,
                    Email = result.account.Email,
                    Phone = result.account.Phone,
                    CitizenImageURL = result.citizenImage,
                    AddressLine = result.defaultAddress?.AddressLine ?? "",
                    Ward = result.defaultAddress?.Ward ?? "",
                    District = result.defaultAddress?.District ?? "",
                    Province = result.defaultAddress?.Province ?? ""
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin shop: {ex.Message}", ex);
            }
        }

        // Get Shop by ShopID
        public async Task<ShopInfoDTO> GetShopByIdAsync(int shopId)
        {
            try
            {
                var result = await (from shop in _context.Shops
                                    join account in _context.Accounts on shop.AccountID equals account.AccountID
                                    where shop.ShopID == shopId
                                    select new
                                    {
                                        shop,
                                        account,
                                        defaultAddress = _context.UserAddresses
                                            .Where(a => a.AccountID == shop.AccountID && a.IsDefault == true)
                                            .FirstOrDefault(),
                                        citizenImage = _context.ShopRegistrations
                                            .Where(r => r.AccountID == shop.AccountID && r.Status == "Approved")
                                            .OrderByDescending(r => r.ReviewedAt)
                                            .Select(r => r.CitizenImageURL)
                                            .FirstOrDefault()
                                    })
                                   .FirstOrDefaultAsync();

                if (result == null) return null;

                return new ShopInfoDTO
                {
                    ShopID = result.shop.ShopID,
                    AccountID = result.shop.AccountID,
                    ShopName = result.shop.ShopName,
                    Description = result.shop.Description,
                    AvatarURL = result.shop.AvatarURL,
                    CoverImageURL = result.shop.CoverImageURL,
                    IsActive = result.shop.IsActive ?? true,
                    CreatedAt = result.shop.CreatedAt ?? DateTime.Now,
                    RatingAverage = result.shop.RatingAverage ?? 0,
                    Email = result.account.Email,
                    Phone = result.account.Phone,
                    CitizenImageURL = result.citizenImage,
                    AddressLine = result.defaultAddress?.AddressLine ?? "",
                    Ward = result.defaultAddress?.Ward ?? "",
                    District = result.defaultAddress?.District ?? "",
                    Province = result.defaultAddress?.Province ?? ""
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin shop: {ex.Message}", ex);
            }
        }

        // Update Shop Info
        public async Task<bool> UpdateShopAsync(ShopUpdateDTO updateDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Cập nhật thông tin Shop
                    var shop = await _context.Shops.FindAsync(updateDTO.ShopID);
                    if (shop == null) return false;

                    shop.ShopName = updateDTO.ShopName;
                    shop.Description = updateDTO.Description;
                    shop.IsActive = updateDTO.IsActive;

                    // Chỉ cập nhật URL nếu có thay đổi
                    if (!string.IsNullOrEmpty(updateDTO.AvatarURL))
                        shop.AvatarURL = updateDTO.AvatarURL;

                    if (!string.IsNullOrEmpty(updateDTO.CoverImageURL))
                        shop.CoverImageURL = updateDTO.CoverImageURL;

                    // 2. Cập nhật Email & Phone trong Account
                    var account = await _context.Accounts.FindAsync(shop.AccountID);
                    if (account != null)
                    {
                        if (!string.IsNullOrEmpty(updateDTO.Email))
                            account.Email = updateDTO.Email;

                        if (!string.IsNullOrEmpty(updateDTO.Phone))
                            account.Phone = updateDTO.Phone;
                    }

                    // 3. Cập nhật địa chỉ mặc định
                    if (!string.IsNullOrEmpty(updateDTO.AddressLine))
                    {
                        var defaultAddress = await _context.UserAddresses
                            .Where(a => a.AccountID == shop.AccountID && a.IsDefault == true)
                            .FirstOrDefaultAsync();

                        if (defaultAddress != null)
                        {
                            defaultAddress.AddressLine = updateDTO.AddressLine;
                        }
                        else
                        {
                            // Tạo địa chỉ mới nếu chưa có
                            var newAddress = new UserAddress
                            {
                                AccountID = shop.AccountID,
                                AddressName = "Địa chỉ mặc định",
                                ReceiverFullName = account?.Email ?? "Shop Owner",
                                ReceiverPhone = account?.Phone ?? "0000000000",
                                AddressLine = updateDTO.AddressLine,
                                Ward = "N/A",
                                District = "N/A",
                                Province = "N/A",
                                IsDefault = true
                            };
                            _context.UserAddresses.Add(newAddress);
                        }
                    }

                    // 4. Cập nhật ảnh CCCD trong ShopRegistrations
                    if (!string.IsNullOrEmpty(updateDTO.CitizenImageURL))
                    {
                        var registration = await _context.ShopRegistrations
                            .Where(r => r.AccountID == shop.AccountID && r.Status == "Approved")
                            .OrderByDescending(r => r.ReviewedAt)
                            .FirstOrDefaultAsync();

                        if (registration != null)
                        {
                            registration.CitizenImageURL = updateDTO.CitizenImageURL;
                        }
                    }

                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Lỗi khi cập nhật shop: {ex.Message}", ex);
                }
            }
        }

        // Check if Shop Name exists (for validation)
        public async Task<bool> IsShopNameExistsAsync(string shopName, int excludeShopId = 0)
        {
            return await _context.Shops
                .AnyAsync(s => s.ShopName == shopName && s.ShopID != excludeShopId);
        }

        // Update Rating Average
        public async Task UpdateShopRatingAsync(int shopId)
        {
            try
            {
                var averageRating = await _context.Reviews
                    .Where(r => r.ShopID == shopId && r.Status == "Approved")
                    .Select(r => r.Rating)
                    .DefaultIfEmpty(0)
                    .AverageAsync();

                var shop = await _context.Shops.FindAsync(shopId);
                if (shop != null)
                {
                    shop.RatingAverage = (decimal?)averageRating ?? 0;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật rating: {ex.Message}", ex);
            }
        }

        // Dispose
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}