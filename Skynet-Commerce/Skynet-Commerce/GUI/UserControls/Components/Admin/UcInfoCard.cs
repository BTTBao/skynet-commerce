using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcInfoCard : UserControl
    {
        public UcInfoCard()
        {
            InitializeComponent();
        }

        public void SetData(string title, string value, string percent, bool isIncrease)
        {
            _lblTitle.Text = title;
            _lblValue.Text = value;
            _btnPercent.Text = percent;

            if (isIncrease)
                _btnPercent.ForeColor = Color.FromArgb(34, 197, 94); // Green
            else
                _btnPercent.ForeColor = Color.FromArgb(239, 68, 68); // Red

            string imageUrl = "";

            switch (title)
            {
                case "Total Users":
                    // Thay link ảnh thật của bạn vào đây
                    imageUrl = "https://cdn-icons-png.flaticon.com/512/1077/1077114.png";
                    _picIcon.FillColor = Color.FromArgb(224, 231, 255);
                    break;

                case "Active Sellers":
                    imageUrl = "https://cdn-icons-png.flaticon.com/128/3733/3733203.png";
                    _picIcon.FillColor = Color.FromArgb(254, 243, 199);
                    break;

                case "Total Orders":
                    imageUrl = "https://cdn-icons-png.flaticon.com/512/1170/1170678.png";
                    _picIcon.FillColor = Color.FromArgb(220, 252, 231);
                    break;

                case "Revenue":
                    imageUrl = "https://cdn-icons-png.flaticon.com/512/2454/2454282.png";
                    _picIcon.FillColor = Color.FromArgb(255, 237, 213);
                    break;

                case "Products":
                    imageUrl = "https://cdn-icons-png.flaticon.com/512/679/679720.png";
                    _picIcon.FillColor = Color.FromArgb(243, 232, 255);
                    break;

                default:
                    _picIcon.Image = null;
                    break;
            }

            // 4. Gọi lệnh tải ảnh (Nếu có URL)
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    // LoadAsync giúp tải ảnh không đồng bộ (không làm treo ứng dụng)
                    _picIcon.LoadAsync(imageUrl);

                    // Nếu muốn chỉnh chế độ hiển thị ảnh cho đẹp (Zoom/Stretch)
                    _picIcon.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    // Xử lý nếu link ảnh bị lỗi (có thể gán ảnh mặc định)
                    _picIcon.LoadAsync("https://cdn-icons-png.flaticon.com/128/2100/2100813.png");
                }
            }
        }
    }
}