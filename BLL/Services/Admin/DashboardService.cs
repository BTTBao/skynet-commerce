using Skynet_Commerce.DAL.Entities;
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services
{
    public class DashboardService
    {
        // Hàm lấy thống kê cho thẻ bài từ View v_Admin_Dashboard_Overview
        public List<StatCardData> GetSummaryStats()
        {
            using (var db = new ApplicationDbContext())
            {
                var overview = db.Database.SqlQuery<DashboardOverviewDTO>(
                    "SELECT * FROM v_Admin_Dashboard_Overview"
                ).FirstOrDefault();

                if (overview == null)
                {
                    return new List<StatCardData>();
                }

                var revenueGrowth = CalculateGrowth((double)overview.RevenueThisMonth, (double)overview.RevenueLastMonth);

                return new List<StatCardData>
                {
                    new StatCardData
                    {
                        Title = "Tổng người dùng",
                        Value = overview.TotalUsers.ToString("N0"),
                        Percent = $"+{overview.NewUsersLast7Days} (7 ngày)",
                        IsIncrease = overview.NewUsersLast7Days > 0
                    },
                    new StatCardData
                    {
                        Title = "Shop hoạt động",
                        Value = overview.TotalActiveShops.ToString("N0"),
                        Percent = $"+{overview.NewShopsLast30Days} (30 ngày)",
                        IsIncrease = overview.NewShopsLast30Days > 0
                    },
                    new StatCardData
                    {
                        Title = "Sản phẩm đang bán",
                        Value = overview.TotalActiveProducts.ToString("N0"),
                        Percent = "Còn hàng",
                        IsIncrease = true
                    },
                    new StatCardData
                    {
                        Title = "Tổng đơn hàng",
                        Value = overview.TotalOrders.ToString("N0"),
                        Percent = $"{overview.OrdersThisMonth} tháng này",
                        IsIncrease = true
                    },
                    new StatCardData
                    {
                        Title = "Doanh thu tháng",
                        Value = overview.RevenueThisMonth.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN")),
                        Percent = $"{revenueGrowth:+0.0;-0.0}%",
                        IsIncrease = revenueGrowth >= 0
                    }
                };
            }
        }

        // Helper tính % tăng trưởng
        private double CalculateGrowth(double current, double previous)
        {
            if (previous == 0) return current > 0 ? 100 : 0;
            return ((current - previous) / previous) * 100;
        }

        // Biểu đồ 1: Doanh thu 6 tháng gần nhất từ View
        public List<ChartData> GetRevenueChartData()
        {
            using (var db = new ApplicationDbContext())
            {
                var data = db.Database.SqlQuery<RevenueByMonthDTO>(
                    "SELECT TOP 6 * FROM v_Admin_Revenue_ByMonth ORDER BY Year DESC, Month DESC"
                ).ToList();

                return data.OrderBy(x => x.Year).ThenBy(x => x.Month)
                    .Select(x => new ChartData
                    {
                        Label = $"{x.Month}/{x.Year}",
                        Value = (double)x.TotalRevenue
                    }).ToList();
            }
        }

        // Biểu đồ 2: Số lượng đơn hàng theo tháng
        public List<ChartData> GetOrderGrowthChartData()
        {
            using (var db = new ApplicationDbContext())
            {
                var sixMonthsAgo = DateTime.Now.AddMonths(-5);

                var rawData = db.Orders
                    .Where(o => o.CreatedAt >= sixMonthsAgo)
                    .GroupBy(o => new { o.CreatedAt.Value.Year, o.CreatedAt.Value.Month })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Count = g.Count()
                    })
                    .ToList();

                var result = new List<ChartData>();
                for (int i = 5; i >= 0; i--)
                {
                    var d = DateTime.Now.AddMonths(-i);
                    var record = rawData.FirstOrDefault(r => r.Month == d.Month && r.Year == d.Year);

                    result.Add(new ChartData
                    {
                        Label = d.ToString("MMM"),
                        Value = record?.Count ?? 0
                    });
                }
                return result;
            }
        }

        // Top Products
        public List<TopProductDTO> GetTopProducts()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Database.SqlQuery<TopProductDTO>(
                    "SELECT * FROM v_Admin_TopProducts"
                ).ToList();
            }
        }

        // Top Shops
        public List<TopShopDTO> GetTopShops()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Database.SqlQuery<TopShopDTO>(
                    "SELECT * FROM v_Admin_TopShops"
                ).ToList();
            }
        }

        // Order Status Statistics for Pie Chart
        public List<OrderStatusStatDTO> GetOrderStatusStats()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Database.SqlQuery<OrderStatusStatDTO>(
                    "SELECT * FROM v_Admin_OrderStatus_Stats"
                ).ToList();
            }
        }

        // Fraud Alerts Count
        public FraudAlertsDTO GetFraudAlerts()
        {
            using (var db = new ApplicationDbContext())
            {
                var highCancelRate = db.Database.SqlQuery<int>(
                    "SELECT COUNT(*) FROM v_Fraud_HighCancelRate"
                ).FirstOrDefault();

                var reviewSpam = db.Database.SqlQuery<int>(
                    "SELECT COUNT(*) FROM v_Fraud_ReviewSpam"
                ).FirstOrDefault();

                var cloneAccounts = db.Database.SqlQuery<int>(
                    "SELECT COUNT(DISTINCT ReceiverPhone) FROM v_Fraud_DuplicateInfo"
                ).FirstOrDefault();

                return new FraudAlertsDTO
                {
                    HighCancelRateCount = highCancelRate,
                    ReviewSpamCount = reviewSpam,
                    CloneAccountsCount = cloneAccounts
                };
            }
        }
    }

    // DTOs
    public class DashboardOverviewDTO
    {
        public int TotalUsers { get; set; }
        public int NewUsersLast7Days { get; set; }
        public int TotalActiveShops { get; set; }
        public int NewShopsLast30Days { get; set; }
        public int TotalActiveProducts { get; set; }
        public int TotalOrders { get; set; }
        public int OrdersThisMonth { get; set; }
        public decimal RevenueThisMonth { get; set; }
        public decimal RevenueLastMonth { get; set; }
    }

    public class RevenueByMonthDTO
    {
        public string YearMonth { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal PlatformFee { get; set; }
    }

    public class TopProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ShopName { get; set; }
        public int SoldCount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class TopShopDTO
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal RatingAverage { get; set; }
    }

    public class OrderStatusStatDTO
    {
        public string Status { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class FraudAlertsDTO
    {
        public int HighCancelRateCount { get; set; }
        public int ReviewSpamCount { get; set; }
        public int CloneAccountsCount { get; set; }
    }
}