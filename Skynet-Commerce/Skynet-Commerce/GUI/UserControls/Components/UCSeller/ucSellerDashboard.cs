using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace Skynet_Commerce.GUI.UserControls.Components.UCSeller
{
    public partial class ucSellerDashboard : UserControl
    {
        public ucSellerDashboard()
        {
            InitializeComponent();
        }

        private void UcSellerDashboard_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mẫu cho các card thống kê
            LoadKpiData();

            // Khởi tạo và load biểu đồ
            LoadRevenueChart();

            // Load dữ liệu mẫu cho bảng đơn hàng
            LoadRecentOrdersData();
        }

        private void LoadKpiData()
        {
            // Giá trị màu sắc từ thiết kế
            Color colorProducts = Color.FromArgb(64, 64, 64);
            Color colorOrders = Color.FromArgb(0, 192, 0); // Xanh lá cây
            Color colorRevenue = Color.FromArgb(255, 128, 0); // Cam
            Color colorFollowers = Color.FromArgb(192, 0, 192); // Tím

            // Gán màu cho các control
            lblProductsValue.ForeColor = colorProducts;
            lblOrdersValue.ForeColor = colorOrders;
            lblRevenueValue.ForeColor = colorRevenue;
            lblFollowersValue.ForeColor = colorFollowers;

            // Dữ liệu mẫu
            lblProductsValue.Text = "45";
            lblOrdersValue.Text = "12";
            lblRevenueValue.Text = "12.5M";
            lblFollowersValue.Text = "1,234";
        }

        private void LoadRevenueChart()
        {
            // Thiết lập biểu đồ cột LiveCharts
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<double> { 15.0, 20.5, 18.0, 22.0, 19.5, 25.0, 16.0, 21.0, 23.5, 27.0, 20.0, 24.5 },
                    // Màu xanh dương nhạt cho LiveChart
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(140, 172, 238)),
                    MaxColumnWidth = 35
                }
            };

            // Thiết lập nhãn trục X (Tháng)
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = new[] { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12" }
            });

            // Thiết lập nhãn trục Y (Giá trị)
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Triệu VNĐ",
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart1.LegendLocation = LegendLocation.Top;
            cartesianChart1.DataTooltip.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 245, 245)); // Màu trắng ngà
            cartesianChart1.DataTooltip.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(45, 45, 45)); // Màu xám đậm
        }

        private void LoadRecentOrdersData()
        {
            // Đổ dữ liệu mẫu vào DataGridView
            // Để đơn giản, giả sử bạn có 2 icon trong Resources: user_icon (cho Column2) và view_icon (cho Column8)
            Image userIcon = global::Skynet_Commerce.Properties.Resources.profile; // Thay bằng Resource thực tế của bạn
            Image viewIcon = global::Skynet_Commerce.Properties.Resources.trash; // Thay bằng Resource View/Details thực tế của bạn

            dgvRecentOrders.Rows.Clear();

            // Dữ liệu mẫu
            dgvRecentOrders.Rows.Add("DH12345", userIcon, "Nguyễn Văn A", "20/11/2025", "500.000", "Đang xử lý", "10 phút trước", viewIcon);
            dgvRecentOrders.Rows.Add("DH12346", userIcon, "Trần Thị B", "19/11/2025", "1.250.000", "Đã giao hàng", "3 giờ trước", viewIcon);
            dgvRecentOrders.Rows.Add("DH12347", userIcon, "Lê Văn C", "19/11/2025", "80.000", "Đã hủy", "1 ngày trước", viewIcon);
            dgvRecentOrders.Rows.Add("DH12348", userIcon, "Phạm Thu D", "18/11/2025", "3.100.000", "Đang vận chuyển", "2 ngày trước", viewIcon);

            // Cập nhật số lượng đơn hàng mới nhất
            label8.Text = $"Đơn hàng mới nhất ({dgvRecentOrders.RowCount})";
        }
    }
}