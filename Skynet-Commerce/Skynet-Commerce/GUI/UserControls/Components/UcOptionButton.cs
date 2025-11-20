using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    // Kế thừa từ UserControl vì Designer.cs đang nhúng Guna2Button bên trong
    public partial class UcOptionButton : UserControl
    {
        // -------------------------------------------------------------
        // CONSTRUCTORS (Chỉ định nghĩa MỘT lần)
        // -------------------------------------------------------------

        public UcOptionButton()
        {
            InitializeComponent();
            // Đảm bảo nút bên trong kích hoạt sự kiện cho control cha
            this.btnOption.Click += (s, e) => this.OnClick(e);
            SetInactiveStyle();
        }

        public UcOptionButton(string optionText) : this()
        {
            this.btnOption.Text = optionText;
        }

        // -------------------------------------------------------------
        // CÁC HÀM STYLE
        // -------------------------------------------------------------

        public void SetActiveStyle()
        {
            // Tác động lên nút Guna2Button bên trong (btnOption)
            this.btnOption.BorderColor = Color.FromArgb(255, 87, 34);
            this.btnOption.FillColor = Color.FromArgb(255, 87, 34);
            this.btnOption.ForeColor = Color.White;
        }

        public void SetInactiveStyle()
        {
            // Tác động lên nút Guna2Button bên trong (btnOption)
            this.btnOption.BorderColor = Color.Gray;
            this.btnOption.FillColor = Color.White;
            this.btnOption.ForeColor = Color.Black;
            this.btnOption.Enabled = true;
        }

        public void SetDisabledStyle()
        {
            // Tác động lên nút Guna2Button bên trong (btnOption)
            this.btnOption.Enabled = false;
            this.btnOption.BorderColor = Color.LightGray;
            this.btnOption.FillColor = Color.WhiteSmoke;
            this.btnOption.ForeColor = Color.DarkGray;
            // Xóa hết hàng ra khỏi tên để dễ dàng lọc biến thể
            this.btnOption.Text = this.btnOption.Text.Replace(" (Hết)", "");
        }
        public Color ButtonFillColor
        {
            get => btnOption.FillColor;
        }

        public override string Text
        {
            get => btnOption.Text;
            set => btnOption.Text = value;
        }
    }
}