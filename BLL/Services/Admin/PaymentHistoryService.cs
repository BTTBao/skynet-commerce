using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services.Admin
{
    // DTO for Payment History
    public class PaymentHistoryDTO
    {
        public int SettlementID { get; set; }
        public DateTime SettlementDate { get; set; }
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopOwnerPhone { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PlatformFee { get; set; }
        public decimal NetAmount { get; set; }
        public int OrderCount { get; set; }
        public string ProcessedBy { get; set; }
    }

    public class PaymentHistoryService
    {
        private ApplicationDbContext _context;

        public PaymentHistoryService()
        {
            _context = new ApplicationDbContext();
        }

        // Get all payment history
        public List<PaymentHistoryDTO> GetAllPaymentHistory()
        {
            var query = @"SELECT * FROM v_Admin_PaymentHistory ORDER BY SettlementDate DESC";
            return _context.Database.SqlQuery<PaymentHistoryDTO>(query).ToList();
        }

        // Filter by date range
        public List<PaymentHistoryDTO> FilterByDateRange(DateTime startDate, DateTime endDate)
        {
            var query = @"
                SELECT * FROM v_Admin_PaymentHistory 
                WHERE SettlementDate >= @p0 AND SettlementDate <= @p1
                ORDER BY SettlementDate DESC";
            return _context.Database.SqlQuery<PaymentHistoryDTO>(query, startDate, endDate).ToList();
        }

        // Filter by shop
        public List<PaymentHistoryDTO> FilterByShop(int shopId)
        {
            var query = @"
                SELECT * FROM v_Admin_PaymentHistory 
                WHERE ShopID = @p0
                ORDER BY SettlementDate DESC";
            return _context.Database.SqlQuery<PaymentHistoryDTO>(query, shopId).ToList();
        }

        // Search by shop name
        public List<PaymentHistoryDTO> SearchByShopName(string shopName)
        {
            var query = @"
                SELECT * FROM v_Admin_PaymentHistory 
                WHERE ShopName LIKE N'%' + @p0 + '%'
                ORDER BY SettlementDate DESC";
            return _context.Database.SqlQuery<PaymentHistoryDTO>(query, shopName).ToList();
        }

        // Get shops for dropdown filter
        public List<ShopDropdownDTO> GetShopsWithPaymentHistory()
        {
            var query = @"
                SELECT DISTINCT ShopID, ShopName 
                FROM v_Admin_PaymentHistory 
                ORDER BY ShopName";
            return _context.Database.SqlQuery<ShopDropdownDTO>(query).ToList();
        }
    }

    public class ShopDropdownDTO
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
    }
}
