using System;
using System.Collections.Generic;

namespace Skynet_Ecommerce.DAL.Repositories
{
    public interface ISellerDashboardRepository
    {
        // KPI Statistics
        int GetTotalOrders(int shopId);
        decimal GetTotalRevenue(int shopId);
        int GetTotalCustomers(int shopId);

        // Today's Statistics
        int GetTodayNewOrders(int shopId);
        int GetTodayPendingOrders(int shopId);
        decimal GetTodayRevenue(int shopId);
        decimal GetGrowthPercentage(int shopId);

        // Revenue Chart Data (Last 7 days)
        Dictionary<DateTime, decimal> GetLast7DaysRevenue(int shopId);

        // Best Selling Products
        List<BestSellerProductDto> GetBestSellingProducts(int shopId, int topCount = 5);
    }

    public class BestSellerProductDto
    {
        public string ProductName { get; set; }
        public int SoldCount { get; set; }
        public int StockQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
        public string Status { get; set; }
    }
}