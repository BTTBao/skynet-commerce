using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms; // Cần thiết để truy cập Guna2Panel và Guna2PictureBox

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcCategoryItem : UserControl
    {
        // -------------------------------------------------------------
        // I. PROPERTIES CÔNG KHAI (Public Properties)
        // Dùng để thiết lập dữ liệu từ bên ngoài (ví dụ: UcHomePage)
        // -------------------------------------------------------------

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
            set => pbIcon.Image = value;
        }


        // -------------------------------------------------------------
        // II. CONSTRUCTOR
        // -------------------------------------------------------------

        // Constructor mặc định (dùng cho Designer)
        public UcCategoryItem()
        {
            InitializeComponent();
            SetupHoverEffect();
        }

        /// <summary>
        /// Constructor để khởi tạo UcCategoryItem với dữ liệu
        /// </summary>
        /// <param name="name">Tên danh mục</param>
        /// <param name="bgColor">Màu nền của icon (Color)</param>
        /// <param name="icon">Hình ảnh icon (Image)</param>
        public UcCategoryItem(string name, Color bgColor, Image icon) : this()
        {
            this.CategoryName = name;
            this.IconBackgroundColor = bgColor;
            this.IconImage = icon;
        }


        // -------------------------------------------------------------
        // III. HÀM XỬ LÝ SỰ KIỆN VÀ HIỆU ỨNG
        // -------------------------------------------------------------

        /// <summary>
        /// Thiết lập hiệu ứng khi di chuột vào (hover)
        /// </summary>
        private void SetupHoverEffect()
        {
            this.Cursor = Cursors.Hand;

            // Xử lý hiệu ứng khi di chuột vào toàn bộ UserControl
            this.MouseEnter += (s, e) => ApplyHover(true);
            this.MouseLeave += (s, e) => ApplyHover(false);

            // Đảm bảo hiệu ứng cũng áp dụng cho các controls con
            lblCategoryName.MouseEnter += (s, e) => ApplyHover(true);
            pnlIconContainer.MouseEnter += (s, e) => ApplyHover(true);
        }

        private void ApplyHover(bool isHovering)
        {
            if (isHovering)
            {
                // Khi di chuột vào: Nâng nhẹ container icon
                pnlIconContainer.Location = new Point(pnlIconContainer.Left, pnlIconContainer.Top - 3);
            }
            else
            {
                // Khi di chuột ra: Đặt lại vị trí ban đầu
                pnlIconContainer.Location = new Point(pnlIconContainer.Left, pnlIconContainer.Top + 3);
            }
        }
    }
}