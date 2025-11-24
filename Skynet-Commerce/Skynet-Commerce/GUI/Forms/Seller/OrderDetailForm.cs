using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

public class OrderDetailForm : Form
{
    private Guna2Panel headerPanel;
    private Guna2Panel contentPanel;
    private Guna2Panel footerPanel;
    private Label lblOrderId;
    private Label lblStatus;
    private Guna2Button btnClose;
    private Guna2VSeparator statusSeparator;

    public OrderDetailForm(int orderId, List<OrderSellerDTO> orderItems)
    {
        InitializeForm();
        LoadOrderDetails(orderId, orderItems);
    }

    private void InitializeForm()
    {
        // Form settings
        this.Text = "Chi tiết đơn hàng";
        this.Size = new Size(850, 700);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = Color.FromArgb(240, 242, 245);

        // Add shadow effect
        Guna2ShadowForm shadow = new Guna2ShadowForm(this);
        shadow.SetShadowForm(this);

        // Header Panel - Gradient background
        headerPanel = new Guna2Panel
        {
            Dock = DockStyle.Top,
            Height = 100,
            FillColor = Color.FromArgb(33, 150, 243),
            Padding = new Padding(30, 20, 30, 20)
        };

        lblOrderId = new Label
        {
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(30, 25),
            BackColor = Color.Transparent  // Quan trọng!
        };

        lblStatus = new Label
        {
            Font = new Font("Segoe UI", 11, FontStyle.Regular),
            ForeColor = Color.FromArgb(230, 245, 255), // Màu trắng nhẹ hơn
            AutoSize = true,
            Location = new Point(30, 60),
            BackColor = Color.Transparent  // Quan trọng!
        };

        headerPanel.Controls.Add(lblOrderId);
        headerPanel.Controls.Add(lblStatus);

        // Content Panel (scrollable)
        contentPanel = new Guna2Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(30, 25, 30, 25),
            FillColor = Color.White
        };

        // Footer Panel
        footerPanel = new Guna2Panel
        {
            Dock = DockStyle.Bottom,
            Height = 80,
            FillColor = Color.White,
            Padding = new Padding(30, 20, 30, 20)
        };

        btnClose = new Guna2Button
        {
            Text = "Đóng",
            Size = new Size(140, 45),
            Location = new Point(680, 18),
            FillColor = Color.FromArgb(33, 150, 243),
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            BorderRadius = 8,
            Cursor = Cursors.Hand
        };
        btnClose.Click += (s, e) => this.Close();

        footerPanel.Controls.Add(btnClose);

        // Add panels to form
        this.Controls.Add(contentPanel);
        this.Controls.Add(headerPanel);
        this.Controls.Add(footerPanel);
    }

    private void LoadOrderDetails(int orderId, List<OrderSellerDTO> orderItems)
    {
        if (!orderItems.Any()) return;

        var first = orderItems.First();
        int yPosition = 10;

        // Header info
        lblOrderId.Text = $"Đơn hàng #{orderId.ToString().PadLeft(6, '0')}";
        lblStatus.Text = $"Trạng thái: {TranslateStatus(first.Status)}";

        // Customer Info Section
        AddSectionTitle("👤  THÔNG TIN KHÁCH HÀNG", ref yPosition);
        yPosition += 10;
        AddInfoCard(new Dictionary<string, string>
        {
            { "Khách hàng", first.CustomerName },
            { "Số điện thoại", first.CustomerPhone },
            { "Địa chỉ giao hàng", first.AddressFull }
        }, ref yPosition);

        yPosition += 25;

        // Order Info Section
        AddSectionTitle("📋  THÔNG TIN ĐƠN HÀNG", ref yPosition);
        yPosition += 10;
        AddInfoCard(new Dictionary<string, string>
        {
            { "Ngày đặt hàng", first.CreatedAt.ToString("dd/MM/yyyy - HH:mm") },
            { "Phương thức thanh toán", "Thanh toán khi nhận hàng (COD)" }
        }, ref yPosition);

        yPosition += 25;

        // Products Section
        AddSectionTitle("🛍️  SẢN PHẨM ĐÃ ĐẶT", ref yPosition);
        yPosition += 10;

        decimal totalAmount = 0;
        foreach (var item in orderItems)
        {
            AddProductCard(item, ref yPosition);
            totalAmount += item.SubTotal;
            yPosition += 15;
        }

        yPosition += 15;

        // Total Section
        AddTotalCard(totalAmount, first.TotalOrderAmount, ref yPosition);
    }

    private void AddSectionTitle(string title, ref int yPosition)
    {
        Label lblSection = new Label
        {
            Text = title,
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 73, 94),
            AutoSize = true,
            Location = new Point(0, yPosition)
        };
        contentPanel.Controls.Add(lblSection);
        yPosition += 45;
    }

    private void AddInfoCard(Dictionary<string, string> data, ref int yPosition)
    {
        Guna2Panel infoCard = new Guna2Panel
        {
            Location = new Point(0, yPosition),
            Size = new Size(760, data.Count * 45 + 30),
            FillColor = Color.FromArgb(248, 250, 252),
            BorderRadius = 10,
            BorderThickness = 1,
            BorderColor = Color.FromArgb(226, 232, 240)
        };

        int itemY = 20;
        foreach (var item in data)
        {
            Label lblKey = new Label
            {
                Text = item.Key + ":",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(25, itemY),
                Size = new Size(180, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblValue = new Label
            {
                Text = item.Value ?? "N/A",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(215, itemY),
                Size = new Size(520, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Nếu text quá dài, cho phép wrap
            if (item.Value != null && item.Value.Length > 60)
            {
                lblValue.AutoSize = true;
                lblValue.MaximumSize = new Size(520, 0);
                int extraHeight = lblValue.PreferredHeight - 25;
                if (extraHeight > 0)
                {
                    infoCard.Height += extraHeight;
                }
            }

            infoCard.Controls.Add(lblKey);
            infoCard.Controls.Add(lblValue);

            itemY += 45;
        }

        contentPanel.Controls.Add(infoCard);
        yPosition += infoCard.Height;
    }

    private void AddProductCard(OrderSellerDTO item, ref int yPosition)
    {
        Guna2Panel productCard = new Guna2Panel
        {
            Location = new Point(0, yPosition),
            Size = new Size(760, 100),
            FillColor = Color.FromArgb(248, 250, 252),
            BorderRadius = 10,
            BorderThickness = 1,
            BorderColor = Color.FromArgb(226, 232, 240)
        };

        // Product name
        Label lblProductName = new Label
        {
            Text = item.ProductName,
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 41, 59),
            Location = new Point(25, 15),
            Size = new Size(450, 25),
            AutoEllipsis = true
        };

        // Variant
        if (!string.IsNullOrEmpty(item.Variant) && item.Variant != "Không có")
        {
            Label lblVariant = new Label
            {
                Text = $"📦 {item.Variant}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(25, 42),
                AutoSize = true
            };
            productCard.Controls.Add(lblVariant);
        }

        // Quantity and Unit Price row
        Label lblQuantity = new Label
        {
            Text = $"Số lượng: {item.Quantity}",
            Font = new Font("Segoe UI", 9, FontStyle.Regular),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(25, 68),
            Size = new Size(120, 20)
        };

        Label lblUnitPrice = new Label
        {
            Text = $"Đơn giá: {item.UnitPrice:N0}₫",
            Font = new Font("Segoe UI", 9, FontStyle.Regular),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(155, 68),
            Size = new Size(180, 20)
        };

        // Subtotal with background
        Guna2Panel subtotalPanel = new Guna2Panel
        {
            Location = new Point(580, 30),
            Size = new Size(155, 40),
            FillColor = Color.FromArgb(220, 252, 231),
            BorderRadius = 8
        };

        Label lblSubtotal = new Label
        {
            Text = $"{item.SubTotal:N0}₫",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(22, 163, 74),
            Location = new Point(0, 0),
            Size = new Size(155, 40),
            TextAlign = ContentAlignment.MiddleCenter
        };

        subtotalPanel.Controls.Add(lblSubtotal);
        productCard.Controls.AddRange(new Control[] { lblProductName, lblQuantity, lblUnitPrice, subtotalPanel });
        contentPanel.Controls.Add(productCard);

        yPosition += 105;
    }

    private void AddTotalCard(decimal subtotal, decimal total, ref int yPosition)
    {
        Guna2Panel totalCard = new Guna2Panel
        {
            Location = new Point(0, yPosition),
            Size = new Size(760, 160),
            FillColor = Color.White,
            BorderRadius = 10,
            BorderThickness = 2,
            BorderColor = Color.FromArgb(33, 150, 243)
        };

        // Subtotal row
        Label lblSubtotalLabel = new Label
        {
            Text = "Tạm tính:",
            Font = new Font("Segoe UI", 11, FontStyle.Regular),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(450, 25),
            Size = new Size(150, 25),
            TextAlign = ContentAlignment.MiddleLeft
        };

        Label lblSubtotalValue = new Label
        {
            Text = $"{subtotal:N0}₫",
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 41, 59),
            Location = new Point(610, 25),
            Size = new Size(130, 25),
            TextAlign = ContentAlignment.MiddleRight
        };

        // Shipping row
        Label lblShippingLabel = new Label
        {
            Text = "Phí vận chuyển:",
            Font = new Font("Segoe UI", 11, FontStyle.Regular),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(450, 58),
            Size = new Size(150, 25),
            TextAlign = ContentAlignment.MiddleLeft
        };

        Label lblShippingValue = new Label
        {
            Text = "Miễn phí",
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.FromArgb(22, 163, 74),
            Location = new Point(610, 58),
            Size = new Size(130, 25),
            TextAlign = ContentAlignment.MiddleRight
        };

        // Separator line
        Guna2Separator separator = new Guna2Separator
        {
            Location = new Point(450, 95),
            Size = new Size(290, 10),
            FillColor = Color.FromArgb(226, 232, 240)
        };

        // Total row with background
        Guna2Panel totalBg = new Guna2Panel
        {
            Location = new Point(440, 110),
            Size = new Size(305, 40),
            FillColor = Color.FromArgb(239, 246, 255),
            BorderRadius = 8
        };

        Label lblTotalLabel = new Label
        {
            Text = "TỔNG CỘNG:",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 41, 59),
            Location = new Point(15, 8),
            Size = new Size(150, 25),
            TextAlign = ContentAlignment.MiddleLeft
        };

        Label lblTotalValue = new Label
        {
            Text = $"{total:N0}₫",
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            ForeColor = Color.FromArgb(239, 68, 68),
            Location = new Point(175, 5),
            Size = new Size(125, 30),
            TextAlign = ContentAlignment.MiddleRight
        };

        totalBg.Controls.Add(lblTotalLabel);
        totalBg.Controls.Add(lblTotalValue);

        totalCard.Controls.AddRange(new Control[] {
            lblSubtotalLabel, lblSubtotalValue,
            lblShippingLabel, lblShippingValue,
            separator, totalBg
        });

        contentPanel.Controls.Add(totalCard);
        yPosition += 170;
    }

    private string TranslateStatus(string status)
    {
        switch (status)
        {
            case "Pending": return "Chờ xử lý";
            case "Confirmed": return "Đã xác nhận";
            case "Shipping": return "Đang giao";
            case "Delivered": return "Đã giao hàng";
            case "Completed": return "Hoàn thành";
            case "Cancelled": return "Đã hủy";
            default: return status;
        }
    }
}