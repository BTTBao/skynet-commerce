using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Ecommerce.DAL.Repositories
{
    public class SellerDashboardRepository : ISellerDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public SellerDashboardRepository()
        {
            _context = new ApplicationDbContext();
        }

        public int GetTotalOrders(int shopId)
        {
            return _context.Orders
                .Where(o => o.ShopID == shopId)
                .Count();
        }

        public decimal GetTotalRevenue(int shopId)
        {
            return _context.Orders
                .Where(o => o.ShopID == shopId &&
                       (o.Status == "Completed" || o.Status == "Delivered" || o.Status == "Settled"))
                .Sum(o => (decimal?)o.TotalAmount) ?? 0;
        }

        public int GetTotalCustomers(int shopId)
        {
            return _context.Orders
                .Where(o => o.ShopID == shopId)
                .Select(o => o.AccountID)
                .Distinct()
                .Count();
        }

        public int GetTodayNewOrders(int shopId)
        {
            var today = DateTime.Today;
            return _context.Orders
                .Where(o => o.ShopID == shopId &&
                       o.CreatedAt >= today)
                .Count();
        }

        public int GetTodayPendingOrders(int shopId)
        {
            var today = DateTime.Today;
            return _context.Orders
                .Where(o => o.ShopID == shopId &&
                       o.CreatedAt >= today &&
                       o.Status == "Pending")
                .Count();
        }

        public decimal GetTodayRevenue(int shopId)
        {
            var today = DateTime.Today;
            return _context.Orders
                .Where(o => o.ShopID == shopId &&
                       o.CreatedAt >= today &&
                       (o.Status == "Completed" || o.Status == "Delivered"))
                .Sum(o => (decimal?)o.TotalAmount) ?? 0;
        }

        public decimal GetGrowthPercentage(int shopId)
        {
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            var todayRevenue = _context.Orders
                .Where(o => o.ShopID == shopId &&
                       o.CreatedAt >= today &&
                       (o.Status == "Completed" || o.Status == "Delivered"))
                .Sum(o => (decimal?)o.TotalAmount) ?? 0;

            var yesterdayRevenue = _context.Orders
                .Where(o => o.ShopID == shopId &&
                       o.CreatedAt >= yesterday &&
                       o.CreatedAt < today &&
                       (o.Status == "Completed" || o.Status == "Delivered"))
                .Sum(o => (decimal?)o.TotalAmount) ?? 0;

            if (yesterdayRevenue == 0) return 0;

            return Math.Round(((todayRevenue - yesterdayRevenue) / yesterdayRevenue) * 100, 2);
        }

        public Dictionary<DateTime, decimal> GetLast7DaysRevenue(int shopId)
        {
            var result = new Dictionary<DateTime, decimal>();
            var startDate = DateTime.Today.AddDays(-6);

            for (int i = 0; i < 7; i++)
            {
                var date = startDate.AddDays(i);
                var nextDate = date.AddDays(1);

                var revenue = _context.Orders
                    .Where(o => o.ShopID == shopId &&
                           o.CreatedAt >= date &&
                           o.CreatedAt < nextDate &&
                           (o.Status == "Completed" || o.Status == "Delivered" || o.Status == "Settled"))
                    .Sum(o => (decimal?)o.TotalAmount) ?? 0;

                result.Add(date, revenue);
            }

            return result;
        }

        // FIX: Đổi tên DTO từ BestSellerProductDto2 thành BestSellerProductDto
        public List<BestSellerProductDto> GetBestSellingProducts(int shopId, int topCount = 5)
        {
            try
            {
                // Tính tổng số lượng bán được từ OrderDetails của các đơn Delivered
                var productSales = _context.OrderDetails
                    .Where(od => od.Order.ShopID == shopId &&
                                (od.Order.Status == "Delivered" || od.Order.Status == "Settled" || od.Order.Status == "Completed"))
                    .GroupBy(od => od.ProductID)
                    .Select(g => new
                    {
                        ProductID = g.Key,
                        TotalSold = g.Sum(od => od.Quantity ?? 0),
                        TotalRevenue = g.Sum(od => (od.Quantity ?? 0) * (od.UnitPrice ?? 0))
                    })
                    .OrderByDescending(x => x.TotalSold)
                    .Take(topCount)
                    .ToList();

                // Join với Products để lấy thông tin chi tiết
                var bestSellers = productSales
                    .Join(_context.Products,
                        sale => sale.ProductID,
                        product => product.ProductID,
                        (sale, product) => new BestSellerProductDto
                        {
                            ProductName = product.Name ?? "Unknown",
                            SoldCount = sale.TotalSold,
                            StockQuantity = product.StockQuantity ?? 0,
                            TotalRevenue = sale.TotalRevenue,
                            Status = (product.StockQuantity ?? 0) > 50 ? "Còn hàng" :
                                     (product.StockQuantity ?? 0) > 20 ? "Nổi bật" :
                                     (product.StockQuantity ?? 0) > 0 ? "Hot" : "Hết hàng"
                        })
                    .ToList();

                return bestSellers;
            }
            catch (Exception ex)
            {
                // Log error for debugging
                System.Diagnostics.Debug.WriteLine("Error in GetBestSellingProducts: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);
                return new List<BestSellerProductDto>();
            }
        }

        // Get Settlement Stats
        public SettlementStatsDto GetSettlementStats(int shopId)
        {
            try
            {
                var settledOrders = _context.Orders
                    .Where(so => so.ShopID == shopId && so.Status == "Settled")
                    .ToList();

                if (!settledOrders.Any())
                {
                    return new SettlementStatsDto
                    {
                        TotalSettledOrders = 0,
                        TotalNetRevenue = 0
                    };
                }

                var totalCount = settledOrders.Count;

                // Tính tổng tiền nhận được = OrderAmount - 5% commission
                var totalNetRevenue = settledOrders.Sum(so =>
                {
                    var orderAmount = so.TotalAmount ?? 0;
                    var commission = orderAmount * 0.05m; // 5% hoa hồng
                    return orderAmount - commission;
                });

                return new SettlementStatsDto
                {
                    TotalSettledOrders = totalCount,
                    TotalNetRevenue = totalNetRevenue
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetSettlementStats: " + ex.Message);
                return new SettlementStatsDto
                {
                    TotalSettledOrders = 0,
                    TotalNetRevenue = 0
                };
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }

    // ============================================================
    // DTOs for Repository - FIX: Đổi tên thành BestSellerProductDto
    // ============================================================
    public class BestSellerProductDto
    {
        public string ProductName { get; set; }
        public int SoldCount { get; set; }
        public int StockQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
        public string Status { get; set; }
    }

    public class SettlementStatsDto
    {
        public int TotalSettledOrders { get; set; }
        public decimal TotalNetRevenue { get; set; }
    }
}