using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using LiveCharts.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Main Controls
        private Guna2DataGridView dgvBestSellers;
        private CartesianChart revenueChart;

        // KPI Card Values
        private Label lblTotalOrdersValue;
        private Label lblTotalRevenueValue;
        private Label lblTotalCustomersValue;

        // Today Stats
        private Label lblTodayOrders;
        private Label lblTodayPending;
        private Label lblTodayRevenue;
        private Label lblTodayGrowth;

        // Containers
        private Guna2Panel chartContainer;
        private Guna2Panel todayContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(820, 720);
            this.Text = "Skynet Seller Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(242, 245, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SellerDashboardForm";

            // Initialize all components
            InitializeKPICards();
            InitializeChartArea();
            InitializeTodayPanel();
            InitializeBestSellersGrid();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeKPICards()
        {
            // Card 1: Total Orders
            var card1 = CreateStatCardPanel(new Point(20, 20));
            CreateStatCardContent(card1, "TỔNG ĐƠN HÀNG", out lblTotalOrdersValue,
                Color.FromArgb(94, 148, 255));
            this.Controls.Add(card1);

            // Card 2: Total Revenue
            var card2 = CreateStatCardPanel(new Point(290, 20));
            CreateStatCardContent(card2, "TỔNG DOANH THU", out lblTotalRevenueValue,
                Color.FromArgb(40, 167, 69));
            this.Controls.Add(card2);

            // Card 3: Total Customers
            var card3 = CreateStatCardPanel(new Point(560, 20));
            CreateStatCardContent(card3, "TỔNG KHÁCH HÀNG", out lblTotalCustomersValue,
                Color.FromArgb(255, 193, 7));
            this.Controls.Add(card3);
        }

        private Guna2Panel CreateStatCardPanel(Point location)
        {
            return new Guna2Panel
            {
                Size = new Size(250, 120),
                Location = location,
                FillColor = Color.White,
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };
        }

        private void CreateStatCardContent(Guna2Panel card, string title,
            out Label valueLabel, Color accentColor)
        {
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(20, 20),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            valueLabel = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(20, 55),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Guna2CircleButton indicator = new Guna2CircleButton
            {
                Size = new Size(50, 50),
                Location = new Point(185, 35),
                FillColor = Color.FromArgb(30, accentColor),
                DisabledState = {
                    BorderColor = Color.Transparent,
                    FillColor = Color.FromArgb(30, accentColor)
                },
                Enabled = false
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(valueLabel);
            card.Controls.Add(indicator);
        }

        private void InitializeChartArea()
        {
            chartContainer = new Guna2Panel
            {
                Location = new Point(20, 160),
                Size = new Size(520, 320),
                FillColor = Color.White,
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };

            Label lblChartTitle = new Label
            {
                Text = "📊 Doanh thu 7 ngày gần nhất",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(31, 30, 68)
            };

            revenueChart = new CartesianChart
            {
                Location = new Point(10, 45),
                Size = new Size(500, 260),
                BackColor = Color.White,
                LegendLocation = LiveCharts.LegendLocation.Top
            };

            // Setup chart axes
            revenueChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Separator = new LiveCharts.Wpf.Separator { IsEnabled = false },
                FontSize = 11,
                Foreground = System.Windows.Media.Brushes.Gray
            });

            revenueChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                LabelFormatter = value => (value / 1000000).ToString("N1") + "M",
                FontSize = 11,
                Foreground = System.Windows.Media.Brushes.Gray,
                Separator = new LiveCharts.Wpf.Separator { StrokeThickness = 1 }
            });

            chartContainer.Controls.Add(lblChartTitle);
            chartContainer.Controls.Add(revenueChart);
            this.Controls.Add(chartContainer);
        }

        private void InitializeTodayPanel()
        {
            todayContainer = new Guna2Panel
            {
                Location = new Point(560, 160),
                Size = new Size(220, 320),
                FillColor = Color.FromArgb(31, 30, 68),
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };

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

            lblTodayOrders = new Label
            {
                Text = "📦 Đơn hàng mới: 0",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 80),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblTodayPending = new Label
            {
                Text = "⏳ Chờ xử lý: 0",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 110),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblTodayRevenue = new Label
            {
                Text = "💰 Doanh thu:\n   ₫0",
                ForeColor = Color.FromArgb(0, 255, 128),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(20, 150),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblTodayGrowth = new Label
            {
                Text = "📈 Tăng trưởng: 0%",
                ForeColor = Color.FromArgb(100, 200, 255),
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 220),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            todayContainer.Controls.Add(lblHeader);
            todayContainer.Controls.Add(separator);
            todayContainer.Controls.Add(lblTodayOrders);
            todayContainer.Controls.Add(lblTodayPending);
            todayContainer.Controls.Add(lblTodayRevenue);
            todayContainer.Controls.Add(lblTodayGrowth);

            this.Controls.Add(todayContainer);
        }

        private void InitializeBestSellersGrid()
        {
            Label lblTableTitle = new Label
            {
                Text = "🔥 DANH SÁCH SẢN PHẨM BÁN CHẠY",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(20, 500),
                AutoSize = true,
                ForeColor = Color.FromArgb(31, 30, 68)
            };
            this.Controls.Add(lblTableTitle);

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
                EnableHeadersVisualStyles = false,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
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

            // Setup columns
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Sản phẩm",
                Width = 280
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoldCount",
                HeaderText = "Đã bán",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockQuantity",
                HeaderText = "Tồn kho",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Revenue",
                HeaderText = "Doanh thu",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 10, 0)
                }
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng thái",
                Width = 120
            });

            this.Controls.Add(dgvBestSellers);
        }
    }
}