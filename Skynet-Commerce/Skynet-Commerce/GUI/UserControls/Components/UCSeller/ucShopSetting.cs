using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Skynet_Commerce.BUS.Services;
using Skynet_Commerce.BLL.Models.Seller;
using System.Net; // Cần thiết cho WebClient
using System.Threading.Tasks; // Cần thiết cho Task

namespace Skynet_Commerce
{
    public partial class ucShopSetting : UserControl
    {
        private readonly SellerDetailService _sellerDetailService;
        private SellerDetailDto shopDetails;
        private readonly int _shopID; // ID của Seller hiện tại

        // Constructor mới chấp nhận Service và AccountID
        public ucShopSetting(int accountId)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _sellerDetailService = new SellerDetailService();
            _shopID = accountId;
            LoadShopSettings(_shopID);
        }

        public ucShopSetting()
        {
            InitializeComponent();
            _sellerDetailService = new SellerDetailService();
            this.Dock = DockStyle.Fill;
            LoadShopSettings(1);
            _shopID = 1;
        }

        private void LoadShopSettings(int accountId)
        {
            shopDetails = _sellerDetailService.GetSellerDetails(accountId, null);

            if (shopDetails != null)
            {
                // 1. Thông tin cơ bản
                txtShopName.Text = shopDetails.ShopName;
                txtDescription.Text = shopDetails.Description;
                txtEmail.Text = shopDetails.SellerEmail;
                txtPhone.Text = shopDetails.SellerPhone;

                // Chỉ load avatar nếu có dữ liệu
                if (!string.IsNullOrWhiteSpace(shopDetails.AvatarURL))
                {
                    LoadImageFromPathOrUrl(shopDetails.AvatarURL, pbAvatar);
                    pbAvatar.Tag = shopDetails.AvatarURL; // Gán luôn để lưu đúng file khi Save
                }
                else
                {
                    pbAvatar.Image = null;
                    pbAvatar.Tag = null;
                }

                // Chỉ load cover nếu có dữ liệu
                if (!string.IsNullOrWhiteSpace(shopDetails.CoverImageURL))
                {
                    LoadImageFromPathOrUrl(shopDetails.CoverImageURL, pbCover);
                    pbCover.Tag = shopDetails.CoverImageURL;
                }
                else
                {
                    pbCover.Image = null;
                    pbCover.Tag = null;
                }

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin Shop cho tài khoản này.", "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- Phương thức tải ảnh từ URL hoặc Đường dẫn Tuyệt đối ---
        private async void LoadImageFromPathOrUrl(string pathOrUrl, PictureBox pictureBox)
        {
            if (string.IsNullOrWhiteSpace(pathOrUrl)) return;

            pictureBox.Image = null; // Xóa ảnh cũ trước

            try
            {
                // Kiểm tra xem đó có phải là URL Web (http/https) hợp lệ hay không
                bool isWebUrl = Uri.IsWellFormedUriString(pathOrUrl, UriKind.Absolute) &&
                                (pathOrUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                                 pathOrUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase));

                if (isWebUrl)
                {
                    // TẢI TỪ URL (Sử dụng WebClient - cần System.Net)
                    using (var wc = new WebClient())
                    {
                        // DownloadDataTaskAsync cần System.Threading.Tasks
                        byte[] bytes = await wc.DownloadDataTaskAsync(new Uri(pathOrUrl));
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    // TẢI TỪ ĐƯỜNG DẪN TUYỆT ĐỐI LOCAL (Cần System.IO)
                    if (File.Exists(pathOrUrl))
                    {
                        // Sử dụng FileStream để mở file và tạo Image (tránh khóa file)
                        using (FileStream fs = new FileStream(pathOrUrl, FileMode.Open, FileAccess.Read))
                        {
                            // Tạo bản sao của Image để đóng FileStream ngay lập tức
                            Image originalImage = Image.FromStream(fs);
                            pictureBox.Image = new Bitmap(originalImage);
                            originalImage.Dispose();
                        }
                    }
                    else
                    {
                        // Đường dẫn không tồn tại
                        throw new FileNotFoundException($"Không tìm thấy file ảnh tại đường dẫn: {pathOrUrl}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Thiết lập ảnh placeholder nếu tải thất bại
                pictureBox.Image = null; // Có thể gán ảnh mặc định ở đây
                MessageBox.Show($"Lỗi tải ảnh:\n{ex.Message}", "Lỗi tải ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Lỗi tải ảnh: {ex.Message}");
            }
        }


        // --- Các sự kiện khác (Giữ nguyên logic của bạn)

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Thu thập dữ liệu từ Form
            string shopName = txtShopName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            // 2. Logic validation cơ bản 
            if (string.IsNullOrWhiteSpace(shopName))
            {
                MessageBox.Show("Tên Shop không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Tạo DTO
            var updateDto = new SellerDetailDto
            {
                ShopID = this._shopID,
                ShopName = shopName,
                AccountID = shopDetails.AccountID,
                Description = description,
                SellerPhone = phone,
                SellerEmail = email,
                AvatarURL = pbAvatar.Tag?.ToString() ?? "",
                CoverImageURL = pbCover.Tag?.ToString() ?? "",

            };

            // 4. GỌI SERVICE LƯU DỮ LIỆU
            bool success = _sellerDetailService.UpdateShopSettings(updateDto);

            // 5. Xử lý kết quả
            if (success)
            {
                MessageBox.Show($"Đã lưu cài đặt cho Shop: {shopName}\n" +
                                "Các thông tin sẽ được cập nhật.",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                pbAvatar.Tag = updateDto.AvatarURL;
                pbCover.Tag = updateDto.CoverImageURL;
            }
            else
            {
                MessageBox.Show("Lưu cài đặt thất bại. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            UploadImage(pbAvatar);
        }

        private void btnChangeCover_Click(object sender, EventArgs e)
        {
            UploadImage(pbCover);
        }

        // Logic UploadImage giữ nguyên
        private void UploadImage(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Chọn ảnh cho Shop";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;

                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        Image originalImage = Image.FromStream(fs);
                        // Tạo một bản sao của ảnh để không khóa file gốc
                        pictureBox.Image = new Bitmap(originalImage);
                        originalImage.Dispose();

                        // Lưu đường dẫn tạm vào Tag để xử lý Upload khi bấm Save
                        pictureBox.Tag = imagePath;
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