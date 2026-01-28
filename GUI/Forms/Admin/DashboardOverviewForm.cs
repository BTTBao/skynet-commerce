using Guna.UI2.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using Skynet_Commerce.BLL.Services;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            LoadFraudAlerts(); // Load first so it appears at top
            LoadSummaryCards();
            LoadCharts();
            LoadTopTables();
        }

        private void LoadSummaryCards()
        {
            try
            {
                _statsContainer.Controls.Clear();
                var stats = _service.GetSummaryStats();

                _statsContainer.ColumnStyles.Clear();
                _statsContainer.ColumnCount = stats.Count; // Số cột = Số thẻ
                _statsContainer.RowCount = 1;
                _statsContainer.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

                // Setup chia đều % cho các cột
                float percent = 100f / stats.Count;
                for (int i = 0; i < stats.Count; i++)
                {
                    _statsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                }

                // Thêm card vào từng cột
                for (int i = 0; i < stats.Count; i++)
                {
                    var stat = stats[i];
                    var card = new UcInfoCard();

                    // Quan trọng: Dock Fill để card tự bung ra hết ô chứa
                    card.Dock = DockStyle.Fill;

                    // Margin để tạo khe hở giữa các card
                    card.Margin = new Padding(10);

                    card.SetData(stat.Title, stat.Value, stat.Percent, stat.IsIncrease);

                    // Thêm vào cột thứ i, hàng 0
                    _statsContainer.Controls.Add(card, i, 0);
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
                _chartsContainer.Controls.Clear();

                // Configure 3 columns for 3 charts
                _chartsContainer.ColumnCount = 3;
                _chartsContainer.ColumnStyles.Clear();
                _chartsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                _chartsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                _chartsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

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
                        Fill = System.Windows.Media.Brushes.RoyalBlue,
                        MaxColumnWidth = 30
                    }
                };

                chartRevenue.AxisX.Add(new Axis
                {
                    Labels = revenueData.Select(x => x.Label).ToList(),
                    Separator = new Separator { Step = 1, IsEnabled = false }
                });

                chartRevenue.AxisY.Add(new Axis
                {
                    LabelFormatter = val => val > 1000000 ? (val / 1000000).ToString("N0") + "M" : (val > 1000 ? (val / 1000).ToString("N0") + "k" : val.ToString("N0"))
                });

                pnlRevenue.Controls.Add(chartRevenue);
                _chartsContainer.Controls.Add(pnlRevenue, 0, 0);

                // --- CHART 2: ORDER STATUS (Pie Chart) ---
                var statusData = _service.GetOrderStatusStats();
                var pnlStatus = CreateChartPanel("Phân bổ đơn hàng theo trạng thái");
                var chartStatus = new LiveCharts.WinForms.PieChart
                {
                    Dock = DockStyle.Fill,
                    LegendLocation = LegendLocation.Bottom
                };

                chartStatus.Series = new SeriesCollection();
                foreach (var item in statusData)
                {
                    chartStatus.Series.Add(new PieSeries
                    {
                        Title = TranslateStatus(item.Status),
                        Values = new ChartValues<int> { item.OrderCount },
                        DataLabels = true,
                        LabelPoint = point => point.Y + " đơn"
                    });
                }

                pnlStatus.Controls.Add(chartStatus);
                _chartsContainer.Controls.Add(pnlStatus, 1, 0);

                // --- CHART 3: ORDERS (Line Chart) ---
                var orderData = _service.GetOrderGrowthChartData();
                var pnlOrders = CreateChartPanel("Đơn đặt hàng theo tháng");
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
                        Fill = System.Windows.Media.Brushes.Transparent,
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
                _chartsContainer.Controls.Add(pnlOrders, 2, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ: " + ex.Message);
            }
        }

        private void LoadTopTables()
        {
            try
            {
                // Create panel for tables (below charts)
                var pnlTables = new TableLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    Height = 300,
                    ColumnCount = 2,
                    RowCount = 1,
                    Padding = new Padding(10)
                };
                pnlTables.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                pnlTables.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                // Top Products Table
                var pnlTopProducts = CreateTablePanel("🏆 Top 10 Sản phẩm bán chạy");
                var dgvProducts = CreateDataGridView();
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sản phẩm", DataPropertyName = "ProductName", Width = 150 });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Shop", DataPropertyName = "ShopName", Width = 120 });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đã bán", DataPropertyName = "SoldCount", Width = 70, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá", DataPropertyName = "Price", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
                dgvProducts.DataSource = _service.GetTopProducts();
                pnlTopProducts.Controls.Add(dgvProducts);
                pnlTables.Controls.Add(pnlTopProducts, 0, 0);

                // Top Shops Table
                var pnlTopShops = CreateTablePanel("🏪 Top 10 Shop doanh thu cao");
                var dgvShops = CreateDataGridView();
                dgvShops.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Shop", DataPropertyName = "ShopName", Width = 150 });
                dgvShops.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn hàng", DataPropertyName = "TotalOrders", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
                dgvShops.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Doanh thu", DataPropertyName = "TotalRevenue", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
                dgvShops.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đánh giá", DataPropertyName = "RatingAverage", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "0.0", Alignment = DataGridViewContentAlignment.MiddleCenter } });
                dgvShops.DataSource = _service.GetTopShops();
                pnlTopShops.Controls.Add(dgvShops);
                pnlTables.Controls.Add(pnlTopShops, 1, 0);

                this.Controls.Add(pnlTables);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng: " + ex.Message);
            }
        }

        private void LoadFraudAlerts()
        {
            try
            {
                var fraudData = _service.GetFraudAlerts();
                
                // Update fraud alert panel (already defined in Designer)
                _lblFraudAlert.Text = $"⚠️ Cảnh báo gian lận: {fraudData.HighCancelRateCount} người hủy đơn cao | " +
                                      $"{fraudData.ReviewSpamCount} spam đánh giá | {fraudData.CloneAccountsCount} tài khoản clone";
                
                _pnlFraudAlert.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải cảnh báo: " + ex.Message);
            }
        }

        private string TranslateStatus(string status)
        {
            switch (status)
            {
                case "Pending": return "Chờ xác nhận";
                case "Processing": return "Đang xử lý";
                case "Shipping": return "Đang vận chuyển";
                case "Delivered": return "Đã giao hàng";
                case "Settled": return "Đã quyết toán";
                case "Cancelled": return "Đã hủy";
                default: return status;
            }
        }

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

        private Guna2Panel CreateTablePanel(string title)
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

        private Guna2DataGridView CreateDataGridView()
        {
            var dgv = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoGenerateColumns = false,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 },
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            return dgv;
        }
    }
}