using Skynet_Commerce.DAL.Entities;
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services
{
    public class DashboardService
    {
        // Hàm lấy thống kê cho 4-5 thẻ bài trên cùng
        public List<StatCardData> GetSummaryStats()
        {
            using (var db = new ApplicationDbContext())
            {
                var now = DateTime.Now;
                var startOfThisMonth = new DateTime(now.Year, now.Month, 1);
                var startOfLastMonth = startOfThisMonth.AddMonths(-1);
                var endOfLastMonth = startOfThisMonth.AddDays(-1);

                // 1. Total Users (Lưu ý: User của bạn không có CreatedAt nên không tính % tăng trưởng được)
                var totalUsers = db.Users.Count();

                // 2. Active Sellers (Shop Active)
                var activeShops = db.Shops.Count(s => s.IsActive == true);

                // 3. Total Orders & Growth
                var totalOrders = db.Orders.Count();
                var ordersThisMonth = db.Orders.Count(o => o.CreatedAt >= startOfThisMonth);
                var ordersLastMonth = db.Orders.Count(o => o.CreatedAt >= startOfLastMonth && o.CreatedAt <= endOfLastMonth);
                var orderGrowth = CalculateGrowth(ordersThisMonth, ordersLastMonth);

                // 4. Revenue (Doanh thu từ Order đã Completed) & Growth
                // Giả định Status "Completed" là đơn thành công
                var totalRevenue = db.Orders
                                     .Where(o => o.Status == "Completed")
                                     .Sum(o => o.TotalAmount) ?? 0;

                var revenueThisMonth = db.Orders
                                         .Where(o => o.Status == "Completed" && o.CreatedAt >= startOfThisMonth)
                                         .Sum(o => o.TotalAmount) ?? 0;

                var revenueLastMonth = db.Orders
                                         .Where(o => o.Status == "Completed" && o.CreatedAt >= startOfLastMonth && o.CreatedAt <= endOfLastMonth)
                                         .Sum(o => o.TotalAmount) ?? 0;

                var revenueGrowth = CalculateGrowth((double)revenueThisMonth, (double)revenueLastMonth);

                // 5. Total Products
                var totalProducts = db.Products.Count();


                // Trả về danh sách hiển thị
                return new List<StatCardData>
                {
                    new StatCardData
                    {
                        Title = "Tổng số người dùng",
                        Value = totalUsers.ToString("N0"),
                        Percent = "--",
                        IsIncrease = true
                    },
                    new StatCardData
                    {
                        Title = "Tổng số shop",
                        Value = activeShops.ToString("N0"),
                        Percent = "Hoạt động",
                        IsIncrease = true
                    },
                    new StatCardData
                    {
                        Title = "Tổng số đơn đặt hàng",
                        Value = totalOrders.ToString("N0"),
                        Percent = $"{orderGrowth:+#0.0;-#0.0}%",
                        IsIncrease = orderGrowth >= 0
                    },
                    new StatCardData
                    {
                        Title = "Doanh thu",
                        Value = totalRevenue.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN")),
                        Percent = $"{revenueGrowth:+#0.0;-#0.0}%",
                        IsIncrease = revenueGrowth >= 0
                    },
                    new StatCardData
                    {
                        Title = "Tổng số sản phẩm",
                        Value = totalProducts.ToString("N0"),
                        Percent = "Còn hàng",
                        IsIncrease = true
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

        // Biểu đồ 1: Doanh thu 6 tháng gần nhất
        public List<ChartData> GetRevenueChartData()
        {
            using (var db = new ApplicationDbContext())
            {
                var sixMonthsAgo = DateTime.Now.AddMonths(-5); // Lấy từ 5 tháng trước đến nay

                // Nhóm theo Tháng/Năm
                // Lưu ý: LINQ to Entities không hỗ trợ format string trực tiếp, nên ta lấy data thô rồi xử lý client
                var rawData = db.Orders
                    .Where(o => o.Status == "Completed" && o.CreatedAt >= sixMonthsAgo)
                    .GroupBy(o => new { o.CreatedAt.Value.Year, o.CreatedAt.Value.Month })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Total = g.Sum(x => x.TotalAmount) ?? 0
                    })
                    .ToList();

                // Map sang ChartData và điền các tháng bị thiếu (nếu có)
                var result = new List<ChartData>();
                for (int i = 5; i >= 0; i--)
                {
                    var d = DateTime.Now.AddMonths(-i);
                    var record = rawData.FirstOrDefault(r => r.Month == d.Month && r.Year == d.Year);

                    result.Add(new ChartData
                    {
                        Label = d.ToString("MMM"), // Jan, Feb...
                        Value = (double)(record?.Total ?? 0)
                    });
                }

                return result;
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
    }
}