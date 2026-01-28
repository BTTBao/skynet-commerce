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
    }
}