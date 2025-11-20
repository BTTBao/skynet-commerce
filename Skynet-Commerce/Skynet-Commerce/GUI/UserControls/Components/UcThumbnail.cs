// Trong UcThumbnail.cs

using Guna.UI2.WinForms;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    // Kế thừa từ Guna2Panel (Đảm bảo lớp này khớp với Designer)
    public partial class UcThumbnail : Guna2Panel
    {
        public string ImagePath { get; set; }
        public event System.EventHandler ThumbnailClicked;

        // Constructor mặc định (cần thiết cho Designer)
        public UcThumbnail()
        {
            InitializeComponent();
            SetupClickEvent();
        }

        // <<< KHẮC PHỤC LỖI CONSTRUCTOR VÀ LOGIC TẢI ẢNH >>>
        public UcThumbnail(string imagePath) : this()
        {
            this.ImagePath = imagePath;
            LoadImage();
        }

        private void SetupClickEvent()
        {
            // Gán sự kiện click cho Panel chứa ảnh
            this.Click += UcThumbnail_Click;

            // Gán sự kiện click cho PictureBox con (nếu đã khởi tạo)
            if (this.Controls.OfType<Guna2PictureBox>().Any())
            {
                this.Controls.OfType<Guna2PictureBox>().First().Click += UcThumbnail_Click;
            }
        }
        // ... (LoadImage và UcThumbnail_Click)

        private void LoadImage()
        {
            // Lấy Guna2PictureBox con đã được khởi tạo trong Designer
            Guna2PictureBox thumbnailBox = this.Controls.OfType<Guna2PictureBox>().FirstOrDefault();

            if (thumbnailBox != null && System.IO.File.Exists(this.ImagePath))
            {
                thumbnailBox.ImageLocation = this.ImagePath;
            }
        }

        private void UcThumbnail_Click(object sender, System.EventArgs e)
        {
            ThumbnailClicked?.Invoke(this, e);
        }
    }
}