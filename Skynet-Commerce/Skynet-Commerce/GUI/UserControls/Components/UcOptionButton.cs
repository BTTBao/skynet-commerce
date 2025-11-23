using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcOptionButton : UserControl
    {
        // [QUAN TRỌNG] Thuộc tính IsActive để code bên ngoài kiểm tra trạng thái
        public bool IsActive { get; private set; } = false;

        // Property để lấy màu nền (Hỗ trợ code cũ nếu cần kiểm tra màu)
        public Color ButtonFillColor
        {
            get { return btnOption.FillColor; }
        }

        // Override Text để khi gán Text cho UserControl, nó gán vào cái nút bên trong
        public override string Text
        {
            get { return btnOption.Text; }
            set { btnOption.Text = value; }
        }

        // Constructor mặc định cho Designer
        public UcOptionButton()
        {
            InitializeComponent();
            SetupEventForwarding();
        }

        // Constructor có tham số để tạo nhanh
        public UcOptionButton(string text) : this()
        {
            this.Text = text;
        }

        // Hàm chuyển tiếp sự kiện Click
        // Khi người dùng bấm vào btnOption, ta kích hoạt sự kiện Click của chính UserControl này
        private void SetupEventForwarding()
        {
            btnOption.Click += (s, e) => this.InvokeOnClick(this, EventArgs.Empty);
        }

        // --- CÁC HÀM STYLE MÀ BẠN ĐANG THIẾU ---

        public void SetActiveStyle()
        {
            // Trạng thái ĐANG CHỌN: Màu Cam
            btnOption.FillColor = Color.FromArgb(255, 87, 34);
            btnOption.ForeColor = Color.White;
            btnOption.BorderThickness = 0;

            this.IsActive = true; // Đánh dấu là Active
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