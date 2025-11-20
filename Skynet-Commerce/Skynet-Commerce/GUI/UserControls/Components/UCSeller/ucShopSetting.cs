using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
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

        // Phương thức giả định để xử lý việc tải ảnh (nếu cần)
        // public void LoadShopImages(string avatarPath, string coverPath) { ... }
    }
}