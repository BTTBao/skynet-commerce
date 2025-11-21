using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Models.Admin
{
    public class StatCardData
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public string Percent { get; set; }
        public bool IsIncrease { get; set; }
        // IconName dùng để xác định icon hiển thị bên GUI (logic này tùy bạn xử lý ở GUI)
    }

    public class ChartData
    {
        public string Label { get; set; } // Tháng 1, Tháng 2...
        public double Value { get; set; } // Giá trị
    }
}
