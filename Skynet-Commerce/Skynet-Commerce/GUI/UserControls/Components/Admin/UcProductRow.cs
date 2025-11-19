using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcProductRow : UserControl
    {
        public UcProductRow()
        {
            InitializeComponent();
            // Kẻ đường line mờ dưới đáy
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        public void SetData(string name, string id, string shop, string category, string price, int stock, string status)
        {
            _lblName.Text = name;
            _lblId.Text = id;
            _lblShop.Text = shop;
            _lblCategory.Text = category;
            _lblPrice.Text = price;
            _lblStock.Text = stock.ToString();
            _badgeStatus.Text = status;

            // Logic màu sắc cho Stock
            if (stock == 0)
            {
                _lblStock.ForeColor = Color.Red;
            }
            else
            {
                _lblStock.ForeColor = Color.Black;
            }

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

            // TODO: Load Image từ URL hoặc Resources
            // _picImage.Image = ...
        }
    }
}