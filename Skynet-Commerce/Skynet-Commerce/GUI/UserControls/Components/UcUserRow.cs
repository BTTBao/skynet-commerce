using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcUserRow : UserControl
    {
        public UcUserRow()
        {
            InitializeComponent();
            // Tạo đường kẻ mờ dưới mỗi hàng
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        public void SetData(string id, string name, string email, string phone, string role, string status)
        {
            _lblId.Text = id;
            _lblName.Text = name;
            _lblEmail.Text = email;
            _lblPhone.Text = phone;

            // Xử lý Role Badge
            _btnRole.Text = role;
            if (role == "Admin")
            {
                _btnRole.FillColor = Color.FromArgb(79, 70, 229); // Tím đậm
                _btnRole.ForeColor = Color.White;
            }
            else if (role == "Seller")
            {
                _btnRole.FillColor = Color.White;
                _btnRole.BorderThickness = 1;
                _btnRole.BorderColor = Color.LightGray;
                _btnRole.ForeColor = Color.Black;
            }
            else
            { // Buyer
                _btnRole.FillColor = Color.FromArgb(243, 244, 246); // Xám nhạt
                _btnRole.ForeColor = Color.Black;
            }

            // Xử lý Status Badge
            _btnStatus.Text = status;
            if (status == "Active")
            {
                _btnStatus.FillColor = Color.FromArgb(79, 70, 229); // Xanh tím
            }
            else
            {
                _btnStatus.FillColor = Color.FromArgb(220, 38, 38); // Đỏ
            }
        }
    }
}