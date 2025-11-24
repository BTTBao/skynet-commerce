using System;
using System.Collections.Generic;

namespace Skynet_Commerce.BLL.Models.Seller
{
    // DTO cho KPI Dashboard
    public class SellerKpiDto
    {
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalFollowers { get; set; }
    }

    // DTO cho dữ liệu biểu đồ doanh thu theo tháng
    public class MonthlyRevenueDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Revenue { get; set; }
    }

    // DTO cho đơn hàng gần đây
    public class RecentOrderDto
    {
        public string OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAvatar { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string TimeAgo { get; set; }
    }

    // DTO tổng hợp cho Dashboard
    public class SellerDashboardDto
    {
        public SellerKpiDto KpiData { get; set; }
        public List<MonthlyRevenueDto> MonthlyRevenues { get; set; }
        public List<RecentOrderDto> RecentOrders { get; set; }
    }
}