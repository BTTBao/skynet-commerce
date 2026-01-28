using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class UserDetailsService
    {
        private readonly ApplicationDbContext db;

        public UserDetailsService()
        {
            db = new ApplicationDbContext();
        }

        public UserDetailDTO GetUserDetails(int userID)
        {
            try
            {
                var result = db.Database.SqlQuery<UserDetailDTO>(
                    "SELECT * FROM fn_Admin_GetUserDetails(@UserID)",
                    new SqlParameter("@UserID", userID)
                ).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết user: " + ex.Message);
            }
        }

        public List<UserAddressDTO> GetUserAddresses(int accountID)
        {
            try
            {
                var addresses = db.UserAddresses
                    .Where(ua => ua.AccountID == accountID)
                    .Select(ua => new UserAddressDTO
                    {
                        AddressID = ua.AddressID,
                        ReceiverName = ua.ReceiverFullName,
                        ReceiverPhone = ua.ReceiverPhone,
                        AddressLine = ua.AddressLine,
                        Ward = ua.Ward,
                        District = ua.District,
                        Province = ua.Province,
                        IsDefault = (bool)ua.IsDefault
                    })
                    .ToList();

                return addresses;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách địa chỉ: " + ex.Message);
            }
        }

        public bool BanAccount(int accountID, int adminID, string reason)
        {
            try
            {
                var result = db.Database.SqlQuery<int>(
                    "EXEC sp_Admin_BanAccount @AccountID, @AdminID, @Reason",
                    new SqlParameter("@AccountID", accountID),
                    new SqlParameter("@AdminID", adminID),
                    new SqlParameter("@Reason", reason)
                ).FirstOrDefault();

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khóa tài khoản: " + ex.Message);
            }
        }

        public bool UnbanAccount(int accountID, int adminID)
        {
            try
            {
                var result = db.Database.SqlQuery<int>(
                    "EXEC sp_Admin_UnbanAccount @AccountID, @AdminID",
                    new SqlParameter("@AccountID", accountID),
                    new SqlParameter("@AdminID", adminID)
                ).FirstOrDefault();

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi mở khóa tài khoản: " + ex.Message);
            }
        }
    }

    // DTO for fn_Admin_GetUserDetails function
    public class UserDetailDTO
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AvatarURL { get; set; }
        public int AccountID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AccountCreatedAt { get; set; }
        public bool AccountStatus { get; set; }
        public int TotalAddresses { get; set; }
        public string Roles { get; set; }
        public int TotalOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public int TotalReviews { get; set; }
        public int? ShopID { get; set; }
        public string ShopName { get; set; }
    }

    // DTO for UserAddresses
    public class UserAddressDTO
    {
        public int AddressID { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string AddressLine { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public bool IsDefault { get; set; }
    }
}
