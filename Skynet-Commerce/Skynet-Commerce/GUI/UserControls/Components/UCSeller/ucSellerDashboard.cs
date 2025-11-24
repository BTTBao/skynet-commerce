using LiveCharts;
using LiveCharts.Wpf;
using Skynet_Commerce.BLL.Models.Seller;
using Skynet_Commerce.BLL.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components.UCSeller
{
    public partial class ucSellerDashboard : UserControl
    {
        private SellerDashboardService dashboardService;
        private int currentAccountId; 

        public ucSellerDashboard()
        {
            InitializeComponent();
            dashboardService = new SellerDashboardService();
            currentAccountId = 1;
            this.Load += UcSellerDashboard_Load;
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
        }

        public ucSellerDashboard(int accountId) : this()
        {
            InitializeComponent();
            dashboardService = new SellerDashboardService();
            this.Load += UcSellerDashboard_Load;
            currentAccountId = accountId;
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
        }

        private void UcSellerDashboard_Load(object sender, EventArgs e)
        {
            // Giả sử lấy AccountID từ Session hoặc biến global
            // currentAccountId = SessionManager.CurrentAccountId;

            LoadDashboardData();
        }

        private async void LoadDashboardData()
        {
            try
            {
                // Hiển thị loading nếu cần
                // ShowLoading();

                // Lấy dữ liệu từ service (có thể dùng async)
                await Task.Run(() =>
                {
                    var dashboardData = dashboardService.GetSellerDashboardData(currentAccountId);

                    // Update UI trên main thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        LoadKpiData(dashboardData.KpiData);
                        LoadRevenueChart(dashboardData.MonthlyRevenues);
                        LoadRecentOrdersData(dashboardData.RecentOrders);
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKpiData(SellerKpiDto kpi)
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

            // Dữ liệu thực từ database
            lblProductsValue.Text = kpi.TotalProducts.ToString();
            Console.WriteLine(kpi.TotalProducts);
            lblOrdersValue.Text = kpi.TotalOrders.ToString();

            // Format doanh thu
            if (kpi.TotalRevenue >= 1000000)
            {
                lblRevenueValue.Text = $"{(kpi.TotalRevenue / 1000000):0.#}M";
            }
            else if (kpi.TotalRevenue >= 1000)
            {
                lblRevenueValue.Text = $"{(kpi.TotalRevenue / 1000):0.#}K";
            }
            else
            {
                lblRevenueValue.Text = $"{kpi.TotalRevenue:N0}";
            }

            lblFollowersValue.Text = kpi.TotalFollowers.ToString("N0");
        }

        private void LoadRevenueChart(List<MonthlyRevenueDto> monthlyRevenues)
        {
            // Chuyển đổi dữ liệu sang ChartValues
            var revenueValues = new ChartValues<double>();
            var monthLabels = new List<string>();

            foreach (var revenue in monthlyRevenues)
            {
                revenueValues.Add((double)revenue.Revenue);
                monthLabels.Add($"T{revenue.Month}");
            }

            // Thiết lập biểu đồ cột LiveCharts
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = revenueValues,
                    Fill = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(140, 172, 238)),
                    MaxColumnWidth = 35
                }
            };

            // Thiết lập nhãn trục X (Tháng)
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = monthLabels.ToArray()
            });

            // Thiết lập nhãn trục Y (Giá trị)
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Triệu VNĐ",
                LabelFormatter = value => value.ToString("N1")
            });

            cartesianChart1.LegendLocation = LegendLocation.Top;
            cartesianChart1.DataTooltip.Background = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromRgb(245, 245, 245));
            cartesianChart1.DataTooltip.Foreground = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromRgb(45, 45, 45));
        }

        private void LoadRecentOrdersData(List<RecentOrderDto> orders)
        {
            // Giả định bạn đã khai báo các biến Image ở phạm vi lớp (class scope)
            // Image userIcon = global::Skynet_Commerce.Properties.Resources.profile;
            // Image viewIcon = global::Skynet_Commerce.Properties.Resources.trash;

            dgvRecentOrders.Rows.Clear();

            foreach (var order in orders)
            {
                // 1. FORMAT MÃ ĐƠN HÀNG (SỬA ĐỔI Ở ĐÂY)
                // Đảm bảo OrderID là số và định dạng thành 6 chữ số, sau đó thêm tiền tố "DH"
                string formattedOrderId = "DH" + order.OrderID.ToString().PadLeft(6, '0');

                // 2. Format giá tiền
                string formattedAmount = $"{order.TotalAmount:N0}";

                dgvRecentOrders.Rows.Add(
                    formattedOrderId, // SỬ DỤNG MÃ ĐÃ FORMAT
                    order.CustomerName,
                    order.OrderDate.ToString("dd/MM/yyyy"),
                    formattedAmount,
                    order.Status,
                    order.TimeAgo
                // Lưu ý: Nếu bạn có cột "Thao tác" (View/Edit) là cột thứ 7, bạn cần thêm giá trị (thường là một Image) vào đây.
                );
            }

            // Cập nhật số lượng đơn hàng
            label8.Text = $"Đơn hàng mới nhất ({orders.Count})";
        }

    }
}