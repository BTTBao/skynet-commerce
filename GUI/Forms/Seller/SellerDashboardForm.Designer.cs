using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerDashboardForm : Form
    {
        private Guna2DataGridView dgvBestSellers;
        private CartesianChart revenueChart;
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form settings
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 720);
            this.Text = "Skynet Seller Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(242, 245, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            SetupDashboardLayout();
            LoadDummyData();

            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        public void SetupDashboardLayout()
        {
            // 1. KPI Cards - 3 khối thống kê trên cùng
            CreateStatCard("TỔNG ĐƠN HÀNG", "1,250", Color.FromArgb(94, 148, 255), 20, 20);
            CreateStatCard("TỔNG DOANH THU", "₫45.800.000", Color.FromArgb(40, 167, 69), 290, 20);
            CreateStatCard("TỔNG KHÁCH HÀNG", "856", Color.FromArgb(255, 193, 7), 560, 20);

            // 2. Khu vực Biểu đồ
            Guna2Panel chartContainer = new Guna2Panel
            {
                Location = new Point(20, 160),
                Size = new Size(520, 320),
                FillColor = Color.White,
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };
            this.Controls.Add(chartContainer);

            Label lblChartTitle = new Label
            {
                Text = "📊 Doanh thu 7 ngày gần nhất",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(31, 30, 68)
            };
            chartContainer.Controls.Add(lblChartTitle);

            SetupLiveChart(chartContainer);

            // 3. Khối "HÔM NAY"
            Guna2Panel todayContainer = new Guna2Panel
            {
                Location = new Point(560, 160),
                Size = new Size(220, 320),
                FillColor = Color.FromArgb(31, 30, 68),
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };
            this.Controls.Add(todayContainer);
            SetupTodayStats(todayContainer);

            // 4. Danh sách bán chạy
            Label lblTableTitle = new Label
            {
                Text = "🔥 DANH SÁCH SẢN PHẨM BÁN CHẠY",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(20, 500),
                AutoSize = true,
                ForeColor = Color.FromArgb(31, 30, 68)
            };
            this.Controls.Add(lblTableTitle);

            SetupBestSellerGrid();
        }

        private void SetupLiveChart(Guna2Panel container)
        {
            revenueChart = new CartesianChart
            {
                Location = new Point(10, 45),
                Size = new Size(500, 260),
                BackColor = Color.White
            };

            ChartValues<double> revenueValues = new ChartValues<double>();
            List<string> labels = new List<string>();
            Random rand = new Random(42); // Seed cố định để dữ liệu ổn định

            // Tạo dữ liệu mẫu cho 7 ngày
            double[] sampleRevenue = { 3200000, 2800000, 4500000, 3900000, 4200000, 3700000, 5100000 };

            for (int i = 6; i >= 0; i--)
            {
                labels.Add(DateTime.Now.AddDays(-i).ToString("dd/MM"));
                revenueValues.Add(sampleRevenue[6 - i]);
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
                    Fill = System.Windows.Media.Brushes.Transparent // Không dùng gradient để tránh lỗi
                }
            };

            revenueChart.AxisX.Add(new Axis
            {
                Labels = labels,
                Separator = new Separator { IsEnabled = false },
                FontSize = 11,
                Foreground = System.Windows.Media.Brushes.Gray
            });

            revenueChart.AxisY.Add(new Axis
            {
                LabelFormatter = value => (value / 1000000).ToString("N1") + "M",
                FontSize = 11,
                Foreground = System.Windows.Media.Brushes.Gray,
                Separator = new Separator { StrokeThickness = 1 }
            });

            revenueChart.LegendLocation = LegendLocation.Top;

            container.Controls.Add(revenueChart);
        }

        private void CreateStatCard(string title, string value, Color accentColor, int x, int y)
        {
            Guna2Panel card = new Guna2Panel
            {
                Size = new Size(250, 120),
                Location = new Point(x, y),
                FillColor = Color.White,
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(20, 20),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(20, 55),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Icon indicator
            Guna2CircleButton indicator = new Guna2CircleButton
            {
                Size = new Size(50, 50),
                Location = new Point(185, 35),
                FillColor = Color.FromArgb(30, accentColor),
                DisabledState = { BorderColor = Color.Transparent, FillColor = Color.FromArgb(30, accentColor) },
                Enabled = false
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            card.Controls.Add(indicator);
            this.Controls.Add(card);
        }

        private void SetupTodayStats(Guna2Panel container)
        {
            Label lblHeader = new Label
            {
                Text = "📅 HÔM NAY",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Guna2Separator separator = new Guna2Separator
            {
                Location = new Point(20, 55),
                Size = new Size(180, 10),
                FillColor = Color.FromArgb(100, 255, 255, 255)
            };

            Label lblOrders = new Label
            {
                Text = "📦 Đơn hàng mới: 24",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 80),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblPending = new Label
            {
                Text = "⏳ Chờ xử lý: 8",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 110),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblRevenue = new Label
            {
                Text = "💰 Doanh thu:\n   ₫5.100.000",
                ForeColor = Color.FromArgb(0, 255, 128),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(20, 150),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblGrowth = new Label
            {
                Text = "📈 Tăng trưởng: +15%",
                ForeColor = Color.FromArgb(100, 200, 255),
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 220),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            container.Controls.Add(lblHeader);
            container.Controls.Add(separator);
            container.Controls.Add(lblOrders);
            container.Controls.Add(lblPending);
            container.Controls.Add(lblRevenue);
            container.Controls.Add(lblGrowth);
        }

        private void SetupBestSellerGrid()
        {
            dgvBestSellers = new Guna2DataGridView
            {
                Location = new Point(20, 535),
                Size = new Size(760, 150),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 },
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(71, 69, 94),
                    SelectionBackColor = Color.FromArgb(231, 229, 255),
                    SelectionForeColor = Color.FromArgb(71, 69, 94),
                    Font = new Font("Segoe UI", 9.5F)
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(31, 30, 68),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0)
                }
            };

            dgvBestSellers.EnableHeadersVisualStyles = false;
            dgvBestSellers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            this.Controls.Add(dgvBestSellers);
        }

        private void LoadDummyData()
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Sản phẩm", typeof(string));
            dt.Columns.Add("Đã bán", typeof(string));
            dt.Columns.Add("Tồn kho", typeof(string));
            dt.Columns.Add("Doanh thu", typeof(string));
            dt.Columns.Add("Trạng thái", typeof(string));

            // Thêm dữ liệu mẫu
            dt.Rows.Add("iPhone 15 Pro Max 256GB", "120", "45", "₫3.600.000.000", "🔥 Hot");
            dt.Rows.Add("MacBook M3 Air 13\" 16GB", "85", "12", "₫2.400.000.000", "⭐ Nổi bật");
            dt.Rows.Add("Samsung Galaxy S24 Ultra", "95", "28", "₫2.850.000.000", "🔥 Hot");
            dt.Rows.Add("AirPods Pro Gen 2", "156", "67", "₫936.000.000", "⭐ Nổi bật");
            dt.Rows.Add("iPad Pro M2 11\" WiFi", "73", "19", "₫1.825.000.000", "✅ Còn hàng");

            dgvBestSellers.DataSource = dt;

            // Tùy chỉnh độ rộng cột
            if (dgvBestSellers.Columns.Count > 0)
            {
                dgvBestSellers.Columns[0].Width = 280; // Sản phẩm
                dgvBestSellers.Columns[1].Width = 80;  // Đã bán
                dgvBestSellers.Columns[2].Width = 80;  // Tồn kho
                dgvBestSellers.Columns[3].Width = 180; // Doanh thu
                dgvBestSellers.Columns[4].Width = 120; // Trạng thái

                // Căn giữa cho các cột số
                dgvBestSellers.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBestSellers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBestSellers.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBestSellers.Columns[3].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            }
        }
    }
}