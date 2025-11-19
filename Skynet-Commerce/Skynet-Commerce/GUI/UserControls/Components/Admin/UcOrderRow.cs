using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcOrderRow : UserControl
    {
        public UcOrderRow()
        {
            InitializeComponent();
            // Kẻ đường line mờ
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        public void SetData(string id, string buyer, string shop, string items, string amount, string date, string status)
        {
            _lblId.Text = id;
            _lblBuyer.Text = buyer;
            _lblShop.Text = shop;
            _lblItems.Text = items;
            _lblAmount.Text = amount;
            _lblDate.Text = date;
            _badgeStatus.Text = status;

            // Xử lý màu sắc Status dựa trên ảnh
            // Completed: Xanh đậm, Chữ trắng
            // Processing/Pending: Nền xám nhạt/Xanh nhạt, Chữ đen
            switch (status)
            {
                case "Completed":
                    _badgeStatus.FillColor = Color.FromArgb(79, 70, 229); // Xanh tím (Indigo)
                    _badgeStatus.ForeColor = Color.White;
                    break;

                case "Processing":
                    _badgeStatus.FillColor = Color.FromArgb(229, 231, 235); // Xám nhạt
                    _badgeStatus.ForeColor = Color.FromArgb(31, 41, 55);    // Chữ xám đậm
                    break;

                case "Pending":
                    _badgeStatus.FillColor = Color.FromArgb(254, 243, 199); // Vàng nhạt (cho khác biệt xíu) hoặc giữ xám
                    _badgeStatus.ForeColor = Color.FromArgb(146, 64, 14);   // Chữ nâu
                    // Hoặc nếu muốn giống hệt ảnh (màu nhạt):
                    // _badgeStatus.FillColor = Color.FromArgb(243, 244, 246);
                    // _badgeStatus.ForeColor = Color.Black;
                    break;

                case "Shipped":
                    _badgeStatus.FillColor = Color.FromArgb(209, 250, 229); // Xanh ngọc nhạt
                    _badgeStatus.ForeColor = Color.FromArgb(6, 95, 70);     // Chữ xanh đậm
                    break;

                default:
                    _badgeStatus.FillColor = Color.LightGray;
                    break;
            }
        }
    }
}