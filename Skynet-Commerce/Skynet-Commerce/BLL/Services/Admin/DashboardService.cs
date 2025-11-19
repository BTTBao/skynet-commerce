using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Services
{
    public class DashboardService
    {
        // Lấy dữ liệu cho 5 thẻ trên cùng
        public List<StatCardData> GetSummaryStats()
        {
            return new List<StatCardData>
            {
                new StatCardData { Title = "Total Users", Value = "12,458", Percent = "+12.5%", IsIncrease = true, IconName = "user_icon" },
                new StatCardData { Title = "Active Sellers", Value = "2,341", Percent = "+8.2%", IsIncrease = true, IconName = "shop_icon" },
                new StatCardData { Title = "Total Orders", Value = "8,234", Percent = "+23.1%", IsIncrease = true, IconName = "cart_icon" },
                new StatCardData { Title = "Revenue", Value = "$458,923", Percent = "+18.4%", IsIncrease = true, IconName = "money_icon" },
                new StatCardData { Title = "Products", Value = "15,678", Percent = "+5.7%", IsIncrease = true, IconName = "box_icon" }
            };
        }

        // Lấy dữ liệu biểu đồ Sales
        public List<ChartData> GetSalesChartData()
        {
            return new List<ChartData>
            {
                new ChartData { Label = "Jan", Value = 45000 },
                new ChartData { Label = "Feb", Value = 51000 },
                new ChartData { Label = "Mar", Value = 47000 },
                new ChartData { Label = "Apr", Value = 61000 },
                new ChartData { Label = "May", Value = 55000 },
                new ChartData { Label = "Jun", Value = 68000 }
            };
        }

        // Lấy dữ liệu biểu đồ New Users
        public List<ChartData> GetUserGrowthData()
        {
            return new List<ChartData>
            {
                new ChartData { Label = "Jan", Value = 800 },
                new ChartData { Label = "Feb", Value = 1000 },
                new ChartData { Label = "Mar", Value = 950 },
                new ChartData { Label = "Apr", Value = 1250 },
                new ChartData { Label = "May", Value = 1100 },
                new ChartData { Label = "Jun", Value = 1450 }
            };
        }
    }
}
