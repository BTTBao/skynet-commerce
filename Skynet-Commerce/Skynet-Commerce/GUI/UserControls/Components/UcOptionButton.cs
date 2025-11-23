using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcOptionButton : UserControl
    {
        // 1. Thuộc tính IsActive
        public bool IsActive { get; private set; } = false;

        // 2. [QUAN TRỌNG] Thêm thuộc tính FillColor để bên ngoài gọi được
        public Color FillColor
        {
            get { return btnOption.FillColor; }
            set { btnOption.FillColor = value; }
        }

        // 3. Override Text để gán chữ vào nút bên trong
        public override string Text
        {
            get { return btnOption.Text; }
            set { btnOption.Text = value; }
        }

        // Constructor mặc định
        public UcOptionButton()
        {
            InitializeComponent();
            SetupEventForwarding();
        }

        // Constructor tiện lợi
        public UcOptionButton(string text) : this()
        {
            this.Text = text;
        }

        // Hàm chuyển tiếp sự kiện Click
        private void SetupEventForwarding()
        {
            btnOption.Click += (s, e) => this.InvokeOnClick(this, EventArgs.Empty);
        }

        // --- CÁC HÀM STYLE ---

        public void SetActiveStyle()
        {
            // Trạng thái ĐANG CHỌN: Màu Cam
            btnOption.FillColor = Color.FromArgb(255, 87, 34);
            btnOption.ForeColor = Color.White;
            btnOption.BorderThickness = 0;

            this.IsActive = true;
        }

        public void SetInactiveStyle()
        {
            // Trạng thái BÌNH THƯỜNG: Màu Trắng, Viền Xám
            btnOption.FillColor = Color.White;
            btnOption.ForeColor = Color.Black;
            btnOption.BorderThickness = 1;
            btnOption.BorderColor = Color.Silver;
            btnOption.Enabled = true;

            this.IsActive = false;
        }

        public void SetDisabledStyle()
        {
            // Trạng thái VÔ HIỆU (Hết hàng): Màu Xám nhạt, Không bấm được
            btnOption.FillColor = Color.WhiteSmoke;
            btnOption.ForeColor = Color.LightGray;
            btnOption.BorderThickness = 1;
            btnOption.BorderColor = Color.Gainsboro;
            btnOption.Enabled = false;

            this.IsActive = false;
        }
    }
}