using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Skynet_Ecommerce.DAL.Repositories;

namespace Skynet_Ecommerce.BLL.Services
{
    public class SellerDashboardService : ISellerDashboardService
    {
        private readonly SellerDashboardRepository _repository;

        public SellerDashboardService()
        {
            _repository = new SellerDashboardRepository();
        }

        public SellerDashboardData GetDashboardData(int shopId)
        {
            var data = new SellerDashboardData();

            // KPI Cards
            data.TotalOrders = _repository.GetTotalOrders(shopId);
            data.TotalRevenue = FormatCurrency(_repository.GetTotalRevenue(shopId));
            data.TotalCustomers = _repository.GetTotalCustomers(shopId);

            // Today Stats
            data.TodayNewOrders = _repository.GetTodayNewOrders(shopId);
            data.TodayPendingOrders = _repository.GetTodayPendingOrders(shopId);
            data.TodayRevenue = FormatCurrency(_repository.GetTodayRevenue(shopId));

            var growth = _repository.GetGrowthPercentage(shopId);
            data.GrowthPercentage = (growth >= 0 ? "+" : "") + growth.ToString("0.##") + "%";

            // NEW: Settlement Stats
            var settlementStats = _repository.GetSettlementStats(shopId);
            data.TotalSettledOrders = settlementStats.TotalSettledOrders;
            data.TotalNetRevenue = settlementStats.TotalNetRevenue;

            // Chart Data
            var revenueData = _repository.GetLast7DaysRevenue(shopId);
            data.RevenueChartData = revenueData.ToDictionary(
                kvp => kvp.Key.ToString("dd/MM"),
                kvp => (double)kvp.Value
            );

            // Best Sellers
            var bestSellers = _repository.GetBestSellingProducts(shopId, 5);
            data.BestSellers = bestSellers.Select(bs => new BestSellerItem
            {
                ProductName = bs.ProductName,
                SoldCount = bs.SoldCount.ToString(),
                StockQuantity = bs.StockQuantity.ToString(),
                Revenue = FormatCurrency(bs.TotalRevenue),
                Status = bs.Status
            }).ToList();

            return data;
        }

        private string FormatCurrency(decimal amount)
        {
            return "₫" + amount.ToString("N0", new CultureInfo("vi-VN"));
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
            }
        }
    }

    // ============================================================
    // DTOs for Service Layer
    // ============================================================
    public class SellerDashboardData
    {
        public int TotalOrders { get; set; }
        public string TotalRevenue { get; set; }
        public int TotalCustomers { get; set; }
        public int TodayNewOrders { get; set; }
        public int TodayPendingOrders { get; set; }
        public string TodayRevenue { get; set; }
        public string GrowthPercentage { get; set; }

        // NEW: Settlement Stats
        public int TotalSettledOrders { get; set; }
        public decimal TotalNetRevenue { get; set; }

        public Dictionary<string, double> RevenueChartData { get; set; }
        public List<BestSellerItem> BestSellers { get; set; }
    }

    public class BestSellerItem
    {
        public string ProductName { get; set; }
        public string SoldCount { get; set; }
        public string StockQuantity { get; set; }
        public string Revenue { get; set; }
        public string Status { get; set; }
    }
}