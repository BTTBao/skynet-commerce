using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Skynet_Ecommerce;
using Skynet_Commerce.DAL.Entities;

namespace Skynet_Ecommerce.BLL.Services.Admin
{
    public class SettlementService
    {
        private readonly ApplicationDbContext _context;

        public SettlementService()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Lấy danh sách Shop và số dư từ View v_Admin_ShopBalances
        /// </summary>
        public List<ShopBalanceDTO> GetShopBalances()
        {
            try
            {
                return _context.Database.SqlQuery<ShopBalanceDTO>(
                    "SELECT * FROM v_Admin_ShopBalances"
                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải danh sách Shop: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lấy danh sách Clone Accounts từ View v_Admin_CloneAccounts_Detail
        /// </summary>
        public List<CloneAccountDTO> GetCloneAccounts()
        {
            try
            {
                return _context.Database.SqlQuery<CloneAccountDTO>(
                    "SELECT * FROM v_Admin_CloneAccounts_Detail"
                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải danh sách Clone Accounts: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Khóa tài khoản gian lận
        /// </summary>
        public bool BanAccount(int accountId, int adminId, string reason)
        {
            try
            {
                _context.Database.ExecuteSqlCommand(
                    "EXEC sp_Admin_BanAccount @p0, @p1, @p2",
                    accountId, adminId, reason
                );
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi khóa tài khoản: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lấy chi tiết thanh toán của một Shop (số đơn Delivered, tổng tiền khả dụng)
        /// </summary>
        public SettlementDetailDTO GetSettlementDetail(int shopId)
        {
            try
            {
                var shop = _context.Shops.FirstOrDefault(s => s.ShopID == shopId);
                if (shop == null)
                    throw new Exception("Shop không tồn tại");

                // Đếm số đơn Delivered
                var deliveredOrders = _context.Orders
                    .Where(o => o.ShopID == shopId && o.Status == "Delivered")
                    .ToList();

                int orderCount = deliveredOrders.Count;

                // Tính tổng tiền (Sau khi trừ phí 5%)
                decimal totalAmount = 0;
                foreach (var order in deliveredOrders)
                {
                    var orderDetails = _context.OrderDetails
                        .Where(od => od.OrderID == order.OrderID)
                        .ToList();
                    
                    foreach (var detail in orderDetails)
                    {
                        int quantity = detail.Quantity ?? 0;
                        decimal unitPrice = detail.UnitPrice ?? 0;
                        totalAmount += (quantity * unitPrice * 0.95m);
                    }
                }

                return new SettlementDetailDTO
                {
                    ShopID = shopId,
                    ShopName = shop.ShopName,
                    DeliveredOrdersCount = orderCount,
                    AvailableBalance = totalAmount
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải chi tiết thanh toán: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thanh toán cho Shop - Chuyển trạng thái đơn từ Delivered -> Settled
        /// </summary>
        public bool SettleForShop(int shopId, int adminId)
        {
            try
            {
                // Gọi Stored Procedure sp_Admin_SettlePayment
                var result = _context.Database.SqlQuery<int>(
                    "EXEC sp_Admin_SettlePayment @ShopID, @AdminID",
                    new System.Data.SqlClient.SqlParameter("@ShopID", shopId),
                    new System.Data.SqlClient.SqlParameter("@AdminID", adminId)
                ).FirstOrDefault();

                return result == 1; // 1 = thành công, 0 = thất bại
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thực hiện thanh toán: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm kiếm Shop theo tên
        /// </summary>
        public List<ShopBalanceDTO> SearchShops(string searchTerm)
        {
            try
            {
                var allShops = GetShopBalances();
                
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return allShops;

                return allShops
                    .Where(s => s.ShopName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm Shop: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lọc Shop có số dư khả dụng > 0
        /// </summary>
        public List<ShopBalanceDTO> FilterShopsWithBalance()
        {
            try
            {
                var allShops = GetShopBalances();
                return allShops.Where(s => s.AvailableBalance > 0).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc Shop: {ex.Message}", ex);
            }
        }
    }

    // DTO for Clone Account Detection
    public class CloneAccountDTO
    {
        public string ReceiverPhone { get; set; }
        public int AccountCount { get; set; }
        public int AccountID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int TotalOrders { get; set; }
        public int CancelledOrders { get; set; }
        public bool IsActive { get; set; }
    }

    public class ShopBalanceDTO
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopOwnerPhone { get; set; }
        public decimal LockedBalance { get; set; }
        public decimal AvailableBalance { get; set; }
    }

    public class SettlementDetailDTO
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public int DeliveredOrdersCount { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}
