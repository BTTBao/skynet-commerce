using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcCategoryItem : UserControl
    {
        // Biến lưu vị trí ban đầu để hover không bị trôi
        private int _defaultY;
        private bool _isLoaded = false;

        // --- PROPERTIES ---
        public string CategoryName
        {
            get => lblCategoryName.Text;
            set => lblCategoryName.Text = value;
        }

        public Color IconBackgroundColor
        {
            get => pnlIconContainer.FillColor;
            set => pnlIconContainer.FillColor = value;
        }

        public Image IconImage
        {
            get => pbIcon.Image;
            set
            {
                pbIcon.Image = value;
                // Nếu không có ảnh thì ẩn PictureBox đi để không hiện ô trắng
                pbIcon.Visible = (value != null);
            }
        }

        // --- CONSTRUCTOR ---
        public UcCategoryItem()
        {
            InitializeComponent();

            // [QUAN TRỌNG] Sửa lỗi ô vuông trắng
            // Đặt nền PictureBox thành trong suốt
            if (pbIcon != null)
            {
                pbIcon.BackColor = Color.Transparent;
                pbIcon.UseTransparentBackground = true;
                pbIcon.FillColor = Color.Transparent;
            }

            SetupHoverEffect();
        }

        public UcCategoryItem(string name, Color bgColor, Image icon) : this()
        {
            this.CategoryName = name;
            this.IconBackgroundColor = bgColor;
            this.IconImage = icon;
        }

        // --- XỬ LÝ LOGIC HOVER CHUẨN (KHÔNG BỊ TRÔI) ---

        // 1. Lấy vị trí gốc khi UserControl vừa hiện lên
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _defaultY = pnlIconContainer.Top;
            _isLoaded = true;
        }

        private void SetupHoverEffect()
        {
            this.Cursor = Cursors.Hand;

            // Gán sự kiện Hover cho tất cả thành phần con để mượt mà
            this.MouseEnter += (s, e) => ApplyHover(true);
            this.MouseLeave += (s, e) => ApplyHover(false);

            lblCategoryName.MouseEnter += (s, e) => ApplyHover(true);
            pnlIconContainer.MouseEnter += (s, e) => ApplyHover(true);
            pbIcon.MouseEnter += (s, e) => ApplyHover(true); // Thêm cái này
        }

        private void ApplyHover(bool isHovering)
        {
            if (!_isLoaded) return;

            if (isHovering)
            {
                // Bay lên: Set vị trí cố định so với gốc (Gốc - 5px)
                pnlIconContainer.Top = _defaultY - 8;

                // Thêm hiệu ứng đổ bóng đậm hơn khi hover (nếu muốn)
                pnlIconContainer.ShadowDecoration.Depth = 15;
            }
            else
            {
                // Hạ cánh: Về đúng vị trí gốc
                pnlIconContainer.Top = _defaultY;

                // Trả lại bóng bình thường
                pnlIconContainer.ShadowDecoration.Depth = 5;
            }
        }
    }
}