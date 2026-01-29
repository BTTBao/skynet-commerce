using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Ecommerce.BLL.Services;
using LiveCharts;
using LiveCharts.Wpf;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerDashboardForm : Form
    {
        private readonly SellerDashboardService _dashboardService;
        private readonly int _shopId;

        public SellerDashboardForm(int shopId)
        {
            _dashboardService = new SellerDashboardService();
            _shopId = shopId;
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                var data = _dashboardService.GetDashboardData(_shopId);
                UpdateKPICards(data);
                UpdateTodayStats(data);
                UpdateSettlementStats(data); // NEW
                UpdateRevenueChart(data.RevenueChartData);
                UpdateBestSellersGrid(data.BestSellers);
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void UpdateKPICards(SellerDashboardData data)
        {
            lblTotalOrdersValue.Text = data.TotalOrders.ToString("N0");
            lblTotalRevenueValue.Text = data.TotalRevenue;
            lblTotalCustomersValue.Text = data.TotalCustomers.ToString("N0");
        }

        private void UpdateTodayStats(SellerDashboardData data)
        {
            lblTodayOrders.Text = $"📦 Đơn hàng mới: {data.TodayNewOrders}";
            lblTodayPending.Text = $"⏳ Chờ xử lý: {data.TodayPendingOrders}";
            lblTodayRevenue.Text = $"💰 Doanh thu: {data.TodayRevenue}";
        }

        // NEW: Update Settlement Stats
        private void UpdateSettlementStats(SellerDashboardData data)
        {
            lblSettledOrdersValue.Text = string.Format("{0} đơn", data.TotalSettledOrders);
            lblNetRevenueValue.Text = string.Format("₫{0:N0}", data.TotalNetRevenue);
        }

        private void UpdateRevenueChart(Dictionary<string, double> data)
        {
            if (data == null || data.Count == 0)
            {
                return;
            }

            ChartValues<double> revenueValues = new ChartValues<double>();
            List<string> labels = new List<string>();

            foreach (var item in data)
            {
                labels.Add(item.Key);
                revenueValues.Add(item.Value);
            }

            revenueChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Doanh thu (VNĐ)",
                    Values = revenueValues,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 3,
                    Stroke = System.Windows.Media.Brushes.RoyalBlue,
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };

            if (revenueChart.AxisX.Count > 0)
            {
                revenueChart.AxisX[0].Labels = labels;
            }
        }

        private void UpdateBestSellersGrid(List<BestSellerItem> bestSellers)
        {
            dgvBestSellers.Rows.Clear();
            if (bestSellers == null || bestSellers.Count == 0)
            {
                return;
            }

            foreach (var item in bestSellers)
            {
                dgvBestSellers.Rows.Add(
                    item.ProductName,
                    item.SoldCount,
                    item.StockQuantity,
                    item.Revenue,
                    item.Status
                );
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void RefreshData()
        {
            LoadDashboardData();
        }
    }
}