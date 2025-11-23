using System;
using System.Collections.Generic;
using System.Linq;
using Skynet_Commerce.BUS.DTOs;
using Skynet_Commerce.DAL;
using Skynet_Commerce.DAL.Entities;

namespace Skynet_Commerce.BUS.Services
{
    public class SellerDashboardService : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public SellerDashboardService()
        {
            // Tốt hơn là nên dùng Dependency Injection, nhưng trong cấu trúc này, ta giữ nguyên.
            _context = new ApplicationDbContext();
        }

        // Thay đổi tham số từ accountId sang shopId
        public SellerDashboardDto GetSellerDashboardData(int shopId)
        {
            return new SellerDashboardDto
            {
                // Truyền shopId vào các phương thức con
                KpiData = GetSellerKpiData(shopId),
                MonthlyRevenues = GetMonthlyRevenue(shopId),
                RecentOrders = GetRecentOrders(shopId)
            };
        }

        // Lấy dữ liệu KPI (Sản phẩm, Đơn hàng, Doanh thu, Người theo dõi)
        // Thay đổi tham số từ accountId sang shopId
        public SellerKpiDto GetSellerKpiData(int shopId)
        {
            SellerKpiDto kpi = new SellerKpiDto();

            try
            {
                // KHÔNG CẦN LẤY SHOP NỮA, vì ta đã có shopId để truy vấn trực tiếp
                // Tuy nhiên, ta cần kiểm tra xem ShopID có tồn tại không.
                // Một cách an toàn là dùng shopId trực tiếp trong các truy vấn.

                // Tổng số sản phẩm Active
                kpi.TotalProducts = _context.Products
                    .Count(p => p.ShopID == shopId && p.Status == "Active");

                // Tổng số đơn hàng
                kpi.TotalOrders = _context.Orders
                    .Count(o => o.ShopID == shopId);

                // Tổng doanh thu (loại bỏ đơn hủy/từ chối)
                kpi.TotalRevenue = _context.Orders
                    .Where(o => o.ShopID == shopId
                        && o.Status != "Cancelled"
                        && o.Status != "Rejected")
                    .Sum(o => (decimal?)o.TotalAmount) ?? 0;

                // Tổng số người theo dõi (đếm qua Wishlist)
                // LƯU Ý: Phải Join/Include Products để truy vấn ShopID
                kpi.TotalFollowers = _context.Wishlists
                    .Where(w => w.Product.ShopID == shopId)
                    .Select(w => w.AccountID)
                    .Distinct()
                    .Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetSellerKpiData: {ex.Message}");
            }

            return kpi;
        }

        // Lấy dữ liệu doanh thu theo 12 tháng gần nhất
        // Thay đổi tham số từ accountId sang shopId
        public List<MonthlyRevenueDto> GetMonthlyRevenue(int shopId)
        {
            List<MonthlyRevenueDto> revenues = new List<MonthlyRevenueDto>();

            try
            {
                // KHÔNG CẦN LẤY SHOP BẰNG accountId NỮA
                // var shop = _context.Shops.FirstOrDefault(s => s.AccountID == accountId);

                // Kiểm tra xem ShopID có hợp lệ không (tùy chọn)
                var shopExists = _context.Shops.Any(s => s.ShopID == shopId);

                if (!shopExists)
                    return FillMissingMonths(revenues);

                // Lấy doanh thu 12 tháng gần nhất
                DateTime twelveMonthsAgo = DateTime.Now.AddMonths(-12);

                // Sử dụng shopId trực tiếp
                revenues = _context.Orders
                    .Where(o => o.ShopID == shopId
                        && o.Status != "Cancelled"
                        && o.Status != "Rejected"
                        && o.CreatedAt >= twelveMonthsAgo)
                    .GroupBy(o => new {
                        Month = o.CreatedAt.Value.Month,
                        Year = o.CreatedAt.Value.Year
                    })
                    .Select(g => new MonthlyRevenueDto
                    {
                        Month = g.Key.Month,
                        Year = g.Key.Year,
                        Revenue = g.Sum(o => o.TotalAmount ?? 0) / 1000000m // Chuyển sang triệu
                    })
                    .OrderBy(r => r.Year)
                    .ThenBy(r => r.Month)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMonthlyRevenue: {ex.Message}");
            }

            // Đảm bảo có đủ 12 tháng
            return FillMissingMonths(revenues);
        }

        // Lấy danh sách đơn hàng gần đây (10 đơn)
        // Thay đổi tham số từ accountId sang shopId
        public List<RecentOrderDto> GetRecentOrders(int shopId)
        {
            List<RecentOrderDto> orders = new List<RecentOrderDto>();

            try
            {
                // KHÔNG CẦN LẤY SHOP BẰNG accountId NỮA
                // var shop = _context.Shops.FirstOrDefault(s => s.AccountID == accountId);

                // Kiểm tra xem ShopID có hợp lệ không (tùy chọn)
                var shopExists = _context.Shops.Any(s => s.ShopID == shopId);

                if (!shopExists)
                    return orders;

                // Lấy 10 đơn hàng mới nhất
                // Sử dụng shopId trực tiếp
                orders = _context.Orders
                    .Where(o => o.ShopID == shopId)
                    .OrderByDescending(o => o.CreatedAt)
                    .Take(10)
                    .Select(o => new
                    {
                        Order = o,
                        // Lưu ý: Đảm bảo có Eager Loading hoặc Lazy Loading cho o.Account.Users
                        // hoặc dùng Join/Select thủ công để tối ưu.
                        // Trong cấu trúc này, ta giữ nguyên và dùng AsEnumerable để chuyển sang client.
                        User = o.Account.Users.FirstOrDefault()
                    })
                    .AsEnumerable() // Chuyển sang client-side để xử lý string operations
                    .Select(x => new RecentOrderDto
                    {
                        OrderID = "DH" + x.Order.OrderID,
                        CustomerName = x.User != null && !string.IsNullOrEmpty(x.User.FullName)
                            ? x.User.FullName
                            : "Khách hàng",
                        CustomerAvatar = x.User?.AvatarURL,
                        OrderDate = x.Order.CreatedAt ?? DateTime.Now,
                        TotalAmount = x.Order.TotalAmount ?? 0,
                        Status = TranslateOrderStatus(x.Order.Status),
                        TimeAgo = CalculateTimeAgo(x.Order.CreatedAt ?? DateTime.Now)
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRecentOrders: {ex.Message}");
            }

            return orders;
        }

        // Helper: Điền các tháng thiếu vào dữ liệu biểu đồ
        private List<MonthlyRevenueDto> FillMissingMonths(List<MonthlyRevenueDto> revenues)
        {
            // ... (Logic giữ nguyên)
            List<MonthlyRevenueDto> result = new List<MonthlyRevenueDto>();
            DateTime now = DateTime.Now;

            for (int i = 11; i >= 0; i--)
            {
                DateTime targetDate = now.AddMonths(-i);
                int targetMonth = targetDate.Month;
                int targetYear = targetDate.Year;

                var existing = revenues.FirstOrDefault(r =>
                    r.Month == targetMonth && r.Year == targetYear);

                result.Add(new MonthlyRevenueDto
                {
                    Month = targetMonth,
                    Year = targetYear,
                    Revenue = existing?.Revenue ?? 0
                });
            }

            return result;
        }

        // Helper: Chuyển đổi trạng thái đơn hàng sang tiếng Việt
        private string TranslateOrderStatus(string status)
        {
            // ... (Logic giữ nguyên)
            if (string.IsNullOrEmpty(status))
                return "Không xác định";

            switch (status)
            {
                case "Pending": return "Đang xử lý";
                case "Processing": return "Đang xử lý";
                case "Confirmed": return "Đã xác nhận";
                case "Shipping": return "Đang vận chuyển";
                case "Delivered": return "Đã giao hàng";
                case "Completed": return "Hoàn thành";
                case "Cancelled": return "Đã hủy";
                case "Rejected": return "Đã từ chối";
                default: return status;
            }
        }

        // Helper: Tính thời gian "x phút/giờ/ngày trước"
        private string CalculateTimeAgo(DateTime orderDate)
        {
            // ... (Logic giữ nguyên)
            TimeSpan diff = DateTime.Now - orderDate;

            if (diff.TotalMinutes < 1)
                return "Vừa xong";
            else if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} phút trước";
            else if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} giờ trước";
            else if (diff.TotalDays < 30)
                return $"{(int)diff.TotalDays} ngày trước";
            else
                return orderDate.ToString("dd/MM/yyyy");
        }

        // Dispose context khi không dùng nữa
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}