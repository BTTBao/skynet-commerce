using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.DAL.Entities
{
    // Class đại diện cho 1 thẻ thống kê (Top Cards)
    public class StatCardData
    {
        public string Title { get; set; }      // VD: Total Users
        public string Value { get; set; }      // VD: 12,458
        public string Percent { get; set; }    // VD: +12.5%
        public bool IsIncrease { get; set; }   // Tăng (xanh) hay giảm (đỏ)
        public string IconName { get; set; }   // Tên icon (để load từ Resources)
    }

    // Class đại diện dữ liệu biểu đồ
    public class ChartData
    {
        public string Label { get; set; } // Tháng (Jan, Feb...)
        public double Value { get; set; } // Giá trị
    }
}
