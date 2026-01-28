using Skynet_Commerce.DAL;
using Skynet_Commerce.DAL.Entities; // Đảm bảo namespace này trỏ đúng tới Entity của bạn
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class FraudDetectionService
    {
        private readonly ApplicationDbContext _context;

        public FraudDetectionService()
        {
            _context = new ApplicationDbContext();
        }

        // --- 1. USER: Lấy danh sách User có tỷ lệ hủy cao ---
        public List<HighRiskUserDTO> GetHighRiskUsers(int minOrders = 5, double minRate = 50)
        {
            try
            {
                string query = "SELECT * FROM v_Fraud_HighCancelRate WHERE TotalOrders >= @p0 AND CancelRate >= @p1";
                return _context.Database.SqlQuery<HighRiskUserDTO>(query, minOrders, minRate).ToList();
            }
            catch { return new List<HighRiskUserDTO>(); }
        }

        // --- 2. SHOP: Lấy danh sách Shop nghi vấn Spam Review ---
        public List<ShopSpamDTO> GetShopSpammers()
        {
            try
            {
                string query = "SELECT * FROM v_Fraud_ReviewSpam";
                return _context.Database.SqlQuery<ShopSpamDTO>(query).ToList();
            }
            catch { return new List<ShopSpamDTO>(); }
        }

        // --- 3. CLONE: Lấy danh sách Clone Account ---
        public List<CloneAccountDTO> GetCloneAccounts()
        {
            try
            {
                string query = "SELECT * FROM v_Fraud_DuplicateInfo";
                return _context.Database.SqlQuery<CloneAccountDTO>(query).ToList();
            }
            catch { return new List<CloneAccountDTO>(); }
        }

        // --- ACTION: Khóa tài khoản User ---
        public bool LockAccount(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
                if (user == null || user.AccountID == null) return false;

                var account = _context.Accounts.FirstOrDefault(a => a.AccountID == user.AccountID);
                if (account != null)
                {
                    account.IsActive = false; // false = Khóa
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch { return false; }
        }

        // --- ACTION: Khóa Shop ---
        public bool LockShop(int shopId)
        {
            try
            {
                // Tìm shop theo ID
                var shop = _context.Shops.FirstOrDefault(s => s.ShopID == shopId);
                if (shop != null)
                {
                    shop.IsActive = false; // Giả sử trong DB có cột IsActive (bit)
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch { return false; }
        }
    }

    // --- DTO Classes ---
    public class HighRiskUserDTO
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int TotalOrders { get; set; }
        public int CancelledOrders { get; set; }
        public decimal CancelRate { get; set; }
    }

    public class ShopSpamDTO
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public int ReviewerID { get; set; }
        public int ReviewCount { get; set; }
        public int TimeSpanMinutes { get; set; }
    }

    public class CloneAccountDTO
    {
        public string ReceiverPhone { get; set; }
        public int LinkedAccountsCount { get; set; }
        public string AccountIDs { get; set; }
    }
}