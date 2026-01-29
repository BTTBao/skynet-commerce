using System;
using System.Collections.Generic;

namespace Skynet_Ecommerce.DAL.Repositories
{
    public interface ISellerDashboardRepository
    {
        int GetTotalOrders(int shopId);
        decimal GetTotalRevenue(int shopId);
        int GetTotalCustomers(int shopId);
        int GetTodayNewOrders(int shopId);
        int GetTodayPendingOrders(int shopId);
        decimal GetTodayRevenue(int shopId);
        decimal GetGrowthPercentage(int shopId);
        Dictionary<DateTime, decimal> GetLast7DaysRevenue(int shopId);

        // FIX: Đổi return type
        List<BestSellerProductDto> GetBestSellingProducts(int shopId, int topCount = 5);
        SettlementStatsDto GetSettlementStats(int shopId);
        void Dispose();
    }
}