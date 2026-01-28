using System.Collections.Generic;

namespace Skynet_Ecommerce.BLL.Services
{
    public interface ISellerDashboardService
    {
        SellerDashboardData GetDashboardData(int shopId);
    }

    public class SellerDashboardData
    {
        // KPI Cards
        public int TotalOrders { get; set; }
        public string TotalRevenue { get; set; }
        public int TotalCustomers { get; set; }

        // Today Stats
        public int TodayNewOrders { get; set; }
        public int TodayPendingOrders { get; set; }
        public string TodayRevenue { get; set; }
        public string GrowthPercentage { get; set; }

        // Chart Data
        public Dictionary<string, double> RevenueChartData { get; set; }

        // Best Sellers
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