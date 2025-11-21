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
        private readonly DashboardService _service;

        public DashboardOverviewForm()
        {
            InitializeComponent();
            _service = new DashboardService();

            // Gọi hàm tải dữ liệu khi form khởi tạo
            this.Load += DashboardOverviewForm_Load;
        }

        private void DashboardOverviewForm_Load(object sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadCharts();
        }

        private void LoadSummaryCards()
        {
            try
            {
                _statsContainer.Controls.Clear();
                var stats = _service.GetSummaryStats();

                foreach (var stat in stats)
                {
                    var card = new UcInfoCard();
                    // SetData(Title, Value, PercentText, IsIncrease)
                    card.SetData(stat.Title, stat.Value, stat.Percent, stat.IsIncrease);
                    card.Margin = new Padding(0, 0, 15, 15); // Khoảng cách giữa các thẻ
                    _statsContainer.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message);
            }
        }

        private void LoadCharts()
        {
            try
            {
                _chartsContainer.Controls.Clear(); // Xóa chart cũ nếu có

                // --- CHART 1: REVENUE (Doanh thu) ---
                var revenueData = _service.GetRevenueChartData();

                var pnlRevenue = CreateChartPanel("Doanh thu 6 tháng gần nhất");
                var chartRevenue = new LiveCharts.WinForms.CartesianChart
                {
                    Dock = DockStyle.Fill,
                    Hoverable = true,
                    DisableAnimations = false
                };

                chartRevenue.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Doanh thu",
                        Values = new ChartValues<double>(revenueData.Select(x => x.Value)),
                        Fill = System.Windows.Media.Brushes.RoyalBlue, // Màu xanh
                        MaxColumnWidth = 30
                    }
                };

                // Cấu hình trục X (Tháng)
                chartRevenue.AxisX.Add(new Axis
                {
                    Labels = revenueData.Select(x => x.Label).ToList(),
                    Separator = new Separator { Step = 1, IsEnabled = false }
                });

                // Cấu hình trục Y (Tiền tệ - rút gọn k/M nếu cần)
                chartRevenue.AxisY.Add(new Axis
                {
                    LabelFormatter = val => val > 1000 ? (val / 1000).ToString("N0") + "k" : val.ToString("N0")
                });

                pnlRevenue.Controls.Add(chartRevenue);
                _chartsContainer.Controls.Add(pnlRevenue, 0, 0); // Cột 0, Hàng 0


                // --- CHART 2: ORDERS (Số lượng đơn) ---
                var orderData = _service.GetOrderGrowthChartData();

                var pnlOrders = CreateChartPanel("Đơn đặt hàng hàng tháng");
                var chartOrders = new LiveCharts.WinForms.CartesianChart
                {
                    Dock = DockStyle.Fill,
                    Hoverable = true
                };

                chartOrders.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Đơn đặt hàng",
                        Values = new ChartValues<double>(orderData.Select(x => x.Value)),
                        Stroke = System.Windows.Media.Brushes.DarkOrange,
                        Fill = System.Windows.Media.Brushes.Transparent, // Chỉ vẽ đường line
                        PointGeometrySize = 10,
                        LineSmoothness = 0.5
                    }
                };

                chartOrders.AxisX.Add(new Axis
                {
                    Labels = orderData.Select(x => x.Label).ToList(),
                    Separator = new Separator { IsEnabled = false }
                });

                pnlOrders.Controls.Add(chartOrders);
                _chartsContainer.Controls.Add(pnlOrders, 1, 0); // Cột 1, Hàng 0
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ: " + ex.Message);
            }
        }

        // Helper tạo Panel bao quanh Chart cho đẹp
        private Guna2Panel CreateChartPanel(string title)
        {
            Guna2Panel panel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                BorderRadius = 12,
                Margin = new Padding(10),
                Padding = new Padding(15),
                ShadowDecoration = { Enabled = true, Depth = 5 }
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Dock = DockStyle.Top,
                Height = 40
            };

            panel.Controls.Add(lblTitle);
            return panel;
        }
    }
}