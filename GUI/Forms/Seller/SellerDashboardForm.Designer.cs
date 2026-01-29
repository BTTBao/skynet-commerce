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

        // Settlement Stats (NEW)
        private Label lblSettledOrdersValue;
        private Label lblNetRevenueValue;

        // Containers
        private Guna2Panel chartContainer;
        private Guna2Panel todayContainer;
        private Guna2Panel settlementContainer; // NEW

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

            // Form - Tăng chiều rộng để chứa cột mới
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1050, 720); // Tăng từ 820 lên 1050
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
            InitializeSettlementPanel(); // NEW
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
                Size = new Size(220, 150), // Giảm chiều cao từ 320 xuống 150
                FillColor = Color.FromArgb(31, 30, 68),
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };

            Label lblHeader = new Label
            {
                Text = "📅 HÔM NAY",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Guna2Separator separator = new Guna2Separator
            {
                Location = new Point(20, 45),
                Size = new Size(180, 10),
                FillColor = Color.FromArgb(100, 255, 255, 255)
            };

            lblTodayOrders = new Label
            {
                Text = "📦 Đơn hàng mới: 0",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(20, 65),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblTodayPending = new Label
            {
                Text = "⏳ Chờ xử lý: 0",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(20, 90),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblTodayRevenue = new Label
            {
                Text = "💰 Doanh thu: ₫0",
                ForeColor = Color.FromArgb(0, 255, 128),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(20, 115),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            todayContainer.Controls.Add(lblHeader);
            todayContainer.Controls.Add(separator);
            todayContainer.Controls.Add(lblTodayOrders);
            todayContainer.Controls.Add(lblTodayPending);
            todayContainer.Controls.Add(lblTodayRevenue);

            this.Controls.Add(todayContainer);
        }

        // NEW: Settlement Panel
        private void InitializeSettlementPanel()
        {
            settlementContainer = new Guna2Panel
            {
                Location = new Point(560, 330), // Đặt dưới todayContainer
                Size = new Size(220, 150),
                FillColor = Color.White,
                BorderRadius = 15,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };

            Label lblHeader = new Label
            {
                Text = "💰 QUYẾT TOÁN",
                ForeColor = Color.FromArgb(31, 30, 68),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Guna2Separator separator = new Guna2Separator
            {
                Location = new Point(20, 45),
                Size = new Size(180, 10),
                FillColor = Color.FromArgb(230, 230, 230)
            };

            Label lblSettledOrdersLabel = new Label
            {
                Text = "Tổng đơn đã quyết toán",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 65),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblSettledOrdersValue = new Label
            {
                Text = "0 đơn",
                ForeColor = Color.FromArgb(94, 148, 255),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(20, 85),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblNetRevenueLabel = new Label
            {
                Text = "Tổng tiền nhận được",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 115),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblNetRevenueValue = new Label
            {
                Text = "₫0",
                ForeColor = Color.FromArgb(40, 167, 69),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(20, 135),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            settlementContainer.Controls.Add(lblHeader);
            settlementContainer.Controls.Add(separator);
            settlementContainer.Controls.Add(lblSettledOrdersLabel);
            settlementContainer.Controls.Add(lblSettledOrdersValue);
            settlementContainer.Controls.Add(lblNetRevenueLabel);
            settlementContainer.Controls.Add(lblNetRevenueValue);

            this.Controls.Add(settlementContainer);
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
                Size = new Size(1000, 150), // Tăng từ 760 lên 1000
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
                Width = 320
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoldCount",
                HeaderText = "Đã bán",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockQuantity",
                HeaderText = "Tồn kho",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvBestSellers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Revenue",
                HeaderText = "Doanh thu",
                Width = 200,
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
                Width = 140
            });

            this.Controls.Add(dgvBestSellers);
        }
    }
}