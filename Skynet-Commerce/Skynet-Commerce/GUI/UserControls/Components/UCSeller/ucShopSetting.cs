using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skynet_Commerce
{
    public partial class ucShopSetting : UserControl
    {
        public ucShopSetting()
        {
            InitializeComponent();
            // Đảm bảo UserControl lấp đầy Panel chứa nó
            this.Dock = DockStyle.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường
            string shopName = txtShopName.Text;
            string description = txtDescription.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            // Logic validation cơ bản (ví dụ: kiểm tra Tên Shop)
            if (string.IsNullOrWhiteSpace(shopName))
            {
                MessageBox.Show("Tên Shop không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý lưu dữ liệu (gọi API hoặc database)
            // Ví dụ: SaveShopSettings(shopName, description, phone, email, ...);

            MessageBox.Show($"Đã lưu cài đặt cho Shop: {shopName}\n" +
                            "Các thông tin sẽ được cập nhật sau 5 phút.",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            UploadImage(pbAvatar);
        }

        private void btnChangeCover_Click(object sender, EventArgs e)
        {
            UploadImage(pbCover);
        }

        // Đặt phương thức này vào class ucShopSetting (trong file ucShopSetting.cs)
        private void UploadImage(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Đặt bộ lọc chỉ cho phép chọn các file hình ảnh
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Chọn ảnh cho Shop";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Đọc hình ảnh từ file đã chọn
                    string imagePath = openFileDialog.FileName;

                    // Sử dụng FileStream để mở file và tạo Image (tránh khóa file sau khi đóng dialog)
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        Image originalImage = Image.FromStream(fs);
                        pictureBox.Image = originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}