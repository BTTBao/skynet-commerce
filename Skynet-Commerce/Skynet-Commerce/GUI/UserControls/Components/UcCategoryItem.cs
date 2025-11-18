using System;
using System.Drawing;
using System.Drawing.Drawing2D; // Cần thêm cái này để bo tròn góc
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcCategoryItem : UserControl
    {
        public UcCategoryItem()
        {
            InitializeComponent();
        }

        // Constructor nhận thông tin: Tên danh mục, Màu nền, Icon (tạm thời chưa có icon thì dùng màu)
        public UcCategoryItem(string categoryName, Color backgroundColor) : this()
        {
            // 1. Thiết lập chung cho thẻ
            this.Size = new Size(120, 120); // Kích thước vuông vức
            this.BackColor = Color.Transparent; // Để nhìn thấy bo góc
            this.Margin = new Padding(10, 0, 10, 0); // Khoảng cách giữa các ô

            // 2. Tạo Panel nền màu (để bo tròn)
            Panel pnlBackground = new Panel();
            pnlBackground.Size = new Size(120, 90); // Phần màu chiếm 3/4 phía trên
            pnlBackground.Dock = DockStyle.Top;
            pnlBackground.BackColor = backgroundColor;

            // --- Xử lý bo tròn góc (Nâng cao một chút cho đẹp) ---
            pnlBackground.Paint += (s, e) =>
            {
                GraphicsPath path = new GraphicsPath();
                int radius = 20; // Độ bo tròn
                Rectangle rect = pnlBackground.ClientRectangle;
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                pnlBackground.Region = new Region(path);
            };

            // 3. Icon (PictureBox) nằm giữa phần màu
            PictureBox pbIcon = new PictureBox();
            pbIcon.Size = new Size(50, 50);
            pbIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbIcon.BackColor = Color.Transparent;
            // Canh giữa icon trong Panel màu
            pbIcon.Location = new Point((120 - 50) / 2, (90 - 50) / 2);
            // Tạm thời chưa có ảnh thật thì để trống hoặc dùng icon mặc định hệ thống
            // pbIcon.Image = Properties.Resources.IconThoiTrang; (Sau này bạn bỏ ảnh vào đây)

            pnlBackground.Controls.Add(pbIcon);

            // 4. Tên danh mục (Label) nằm ở dưới
            Label lblName = new Label();
            lblName.Text = categoryName;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblName.Dock = DockStyle.Bottom;
            lblName.Height = 30; // Chiều cao phần chữ
            lblName.Font = new Font("Arial", 9, FontStyle.Regular);

            // Thêm các thành phần vào UserControl
            this.Controls.Add(pnlBackground);
            this.Controls.Add(lblName);
        }
        // Sửa lại constructor để nhận thêm productId
       
        
    }
}