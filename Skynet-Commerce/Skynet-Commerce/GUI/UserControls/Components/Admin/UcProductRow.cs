using Skynet_Commerce.BLL.Models.Admin;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcProductRow : UserControl
    {
        public int ProductId { get; private set; }
        public UcProductRow()
        {
            InitializeComponent();
            // Kẻ đường line mờ dưới đáy
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        // Hàm SetData mới nhận ViewModel
        public void SetData(ProductViewModel item)
        {
            this.ProductId = item.ProductID;

            _lblName.Text = item.ProductName;
            _lblId.Text = item.ProductID.ToString();
            _lblShop.Text = item.ShopName;
            _lblCategory.Text = item.CategoryName;
            _lblPrice.Text = item.Price.ToString("C0", CultureInfo.GetCultureInfo("vi-VN")); ; // Format tiền tệ
            _lblStock.Text = item.StockQuantity.ToString();
            _badgeStatus.Text = item.Status;

            // Xử lý màu sắc trạng thái (Optional)
            UpdateStatusColor(item.Status);
        }

        private void UpdateStatusColor(string status)
        {
            // Logic màu sắc cho Status
            switch (status)
            {
                case "Active":
                    _badgeStatus.FillColor = Color.FromArgb(79, 70, 229); // Xanh tím
                    _badgeStatus.ForeColor = Color.White;
                    break;
                case "Out of Stock":
                    _badgeStatus.FillColor = Color.FromArgb(220, 38, 38); // Đỏ
                    _badgeStatus.ForeColor = Color.White;
                    _badgeStatus.Width = 100; // Nới rộng nút vì chữ dài
                    break;
                case "Hidden":
                    _badgeStatus.FillColor = Color.FromArgb(229, 231, 235); // Xám nhạt
                    _badgeStatus.ForeColor = Color.DimGray;
                    break;
                default:
                    _badgeStatus.FillColor = Color.Gray;
                    break;
            }
        }
    }
}