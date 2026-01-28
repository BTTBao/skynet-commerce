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
                       (o.Status == "Completed" || o.Status == "Delivered"))
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
                           (o.Status == "Completed" || o.Status == "Delivered"))
                    .Sum(o => (decimal?)o.TotalAmount) ?? 0;

                result.Add(date, revenue);
            }

            return result;
        }

        public List<BestSellerProductDto> GetBestSellingProducts(int shopId, int topCount = 5)
        {
            return _context.Products
                .Where(p => p.ShopID == shopId && p.SoldCount > 0)
                .OrderByDescending(p => p.SoldCount)
                .Take(topCount)
                .Select(p => new BestSellerProductDto
                {
                    ProductName = p.Name,
                    SoldCount = p.SoldCount ?? 0,
                    StockQuantity = p.StockQuantity ?? 0,
                    TotalRevenue = (p.Price ?? 0) * (p.SoldCount ?? 0),
                    Status = p.StockQuantity > 50 ? "✅ Còn hàng" :
                             p.StockQuantity > 20 ? "⭐ Nổi bật" :
                             p.StockQuantity > 0 ? "🔥 Hot" : "❌ Hết hàng"
                })
                .ToList();
        }
    }
}