using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Guna.UI2.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using Skynet_Commerce.BLL.Services;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class DashboardOverviewForm : Form
    {
        private DashboardService _service;

        public DashboardOverviewForm()
        {
            // Hàm này giờ gọi từ file Designer.cs, không tự viết nữa
            InitializeComponent();

            _service = new DashboardService();

            // Chỉ gọi hàm load dữ liệu
            LoadDataToUI();
        }

        // Đã xóa hàm InitializeLayout() vì Designer đã lo việc này

        private void LoadDataToUI()
        {
            var stats = _service.GetSummaryStats();
            foreach (var stat in stats)
            {
                // Đảm bảo bạn đã có UserControl tên là UcInfoCard
                var card = new UcInfoCard();
                card.SetData(stat.Title, stat.Value, stat.Percent, stat.IsIncrease);
                card.Margin = new Padding(0, 0, 20, 0);
                _statsContainer.Controls.Add(card);
            }

            LoadSalesChart();
            LoadUsersChart();
        }

        private void LoadSalesChart()
        {
            Guna2Panel chartPanel = new Guna2Panel { Dock = DockStyle.Fill, FillColor = Color.White, BorderRadius = 12, Margin = new Padding(0, 10, 10, 10), Padding = new Padding(10) };
            chartPanel.Controls.Add(new Label { Text = "Monthly Sales", Font = new Font("Segoe UI", 12, FontStyle.Bold), Dock = DockStyle.Top, Height = 30 });

            var data = _service.GetSalesChartData();
            var chart = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill, Hoverable = true };

            chart.Series = new SeriesCollection { new ColumnSeries { Title = "Revenue", Values = new ChartValues<double>(data.Select(x => x.Value)), Fill = System.Windows.Media.Brushes.RoyalBlue, MaxColumnWidth = 35 } };
            chart.AxisX.Add(new Axis { Labels = data.Select(x => x.Label).ToList(), Separator = new Separator { Step = 1, IsEnabled = false } });
            chart.AxisY.Add(new Axis { LabelFormatter = val => val.ToString("N0") });

            chartPanel.Controls.Add(chart);
            _chartsContainer.Controls.Add(chartPanel, 0, 0);
        }

        private void LoadUsersChart()
        {
            Guna2Panel chartPanel = new Guna2Panel { Dock = DockStyle.Fill, FillColor = Color.White, BorderRadius = 12, Margin = new Padding(10, 10, 0, 10), Padding = new Padding(10) };
            chartPanel.Controls.Add(new Label { Text = "New Users", Font = new Font("Segoe UI", 12, FontStyle.Bold), Dock = DockStyle.Top, Height = 30 });

            var data = _service.GetUserGrowthData();
            var chart = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill, Hoverable = true };

            chart.Series = new SeriesCollection { new LineSeries { Title = "Users", Values = new ChartValues<double>(data.Select(x => x.Value)), Stroke = System.Windows.Media.Brushes.RoyalBlue, Fill = System.Windows.Media.Brushes.Transparent, PointGeometrySize = 10, LineSmoothness = 1 } };
            chart.AxisX.Add(new Axis { Labels = data.Select(x => x.Label).ToList(), Separator = new Separator { IsEnabled = false } });

            chartPanel.Controls.Add(chart);
            _chartsContainer.Controls.Add(chartPanel, 1, 0);
        }
    }
}