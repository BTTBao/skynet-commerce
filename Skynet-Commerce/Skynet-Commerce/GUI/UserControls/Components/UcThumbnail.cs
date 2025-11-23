using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcThumbnail : UserControl
    {
        public event EventHandler ThumbnailClicked;
        public string ImagePath { get; private set; }
        private PictureBox pbThumb;
        private Panel pnlBorder;

        public UcThumbnail(string imagePath)
        {
            // Không cần gọi InitializeComponent() nếu bạn tạo giao diện bằng code bên dưới
            // InitializeComponent(); 

            this.ImagePath = imagePath;
            this.Size = new Size(70, 70); // Kích thước ô ảnh nhỏ
            this.Cursor = Cursors.Hand;
            this.Margin = new Padding(5);

            SetupUI();
            LoadImage();
        }

        private void SetupUI()
        {
            // 1. Tạo viền
            pnlBorder = new Panel();
            pnlBorder.Dock = DockStyle.Fill;
            pnlBorder.Padding = new Padding(2);
            pnlBorder.BackColor = Color.Transparent;

            // 2. Tạo PictureBox
            pbThumb = new PictureBox();
            pbThumb.Dock = DockStyle.Fill;
            pbThumb.SizeMode = PictureBoxSizeMode.Zoom; // Co giãn ảnh
            pbThumb.BackColor = Color.WhiteSmoke;

            // Sự kiện click
            pbThumb.Click += (s, e) => ThumbnailClicked?.Invoke(this, e);

            pnlBorder.Controls.Add(pbThumb);
            this.Controls.Add(pnlBorder);
        }

        private void LoadImage()
        {
            // Case 1: Link Online
            if (!string.IsNullOrEmpty(this.ImagePath) && this.ImagePath.StartsWith("http"))
            {
                pbThumb.ImageLocation = this.ImagePath;
            }
            // Case 2: File Offline
            else if (File.Exists(this.ImagePath))
            {
                pbThumb.ImageLocation = this.ImagePath;
            }
            // Case 3: Lỗi
            else
            {
                pbThumb.BackColor = Color.LightGray; // Hiện màu xám nếu lỗi
            }
        }

        public void SetActive(bool isActive)
        {
            pnlBorder.BackColor = isActive ? Color.OrangeRed : Color.Transparent;
        }
    }
}