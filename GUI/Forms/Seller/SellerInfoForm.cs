using Skynet_Ecommerce.BLL.Helpers;
using Skynet_Ecommerce.BLL.Services.Seller;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerInfoForm : Form
    {
        private readonly ShopServiceSeller _shopService;
        private int _currentAccountId;
        private int _currentShopId;
        private string _originalAvatarUrl;
        private string _originalCoverUrl;
        private string _originalCitizenImageUrl;
        private bool _isEditMode = false;

        public SellerInfoForm(int accountId)
        {
            InitializeComponent();
            _shopService = new ShopServiceSeller();
            _currentAccountId = accountId;
            LoadShopData();
            SetFieldsEditable(false);
        }

        // ========== LOAD DATA ==========
        private async void LoadShopData()
        {
            try
            {
                var shopInfo = await _shopService.GetShopByAccountIdAsync(_currentAccountId);

                if (shopInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin cửa hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _currentShopId = shopInfo.ShopID;

                // Hiển thị thông tin cơ bản
                lblShopID.Text = $"Shop ID: {shopInfo.ShopID}";
                lblAccountID.Text = $"Account ID: {shopInfo.AccountID}";
                txtShopName.Text = shopInfo.ShopName;
                txtDescription.Text = shopInfo.Description ?? "";
                txtEmail.Text = shopInfo.Email ?? "";
                txtPhone.Text = shopInfo.Phone ?? "";
                txtAddress.Text = shopInfo.AddressLine ?? "";

                // Hiển thị rating
                lblRating.Text = $"{shopInfo.RatingAverage:F1}/5.0";

                // Hiển thị thời gian tạo
                lblCreatedAt.Text = $"Tạo lúc: {shopInfo.CreatedAt:dd/MM/yyyy HH:mm}";

                // Hiển thị trạng thái
                lblStatus.Text = shopInfo.IsActive ? "Đang hoạt động" : "Tạm ngưng";
                lblStatus.ForeColor = shopInfo.IsActive ? Color.Green : Color.Red;

                // Load images
                LoadImage(pbShopAvatar, shopInfo.AvatarURL);
                LoadImage(pbShopCover, shopInfo.CoverImageURL);
                LoadImage(pbCitizenImage, shopInfo.CitizenImageURL);

                // Lưu URL gốc
                _originalAvatarUrl = shopInfo.AvatarURL;
                _originalCoverUrl = shopInfo.CoverImageURL;
                _originalCitizenImageUrl = shopInfo.CitizenImageURL;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== HELPER: LOAD IMAGE ==========
        private void LoadImage(Guna.UI2.WinForms.Guna2PictureBox pictureBox, string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                pictureBox.Image = null;
                return;
            }

            try
            {
                if (imageUrl.StartsWith("http"))
                {
                    // Load from URL
                    pictureBox.LoadAsync(imageUrl);
                }
                else if (File.Exists(imageUrl))
                {
                    // Load from local file
                    pictureBox.Image = Image.FromFile(imageUrl);
                }
            }
            catch
            {
                pictureBox.Image = null;
            }
        }

        // ========== BUTTON: EDIT MODE ==========
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _isEditMode = true;
            SetFieldsEditable(true);
        }

        // ========== BUTTON: SAVE ==========
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtShopName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên cửa hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShopName.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtPhone.Text) && !IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (10 số)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                // Disable buttons during save
                btnSave.Enabled = false;
                btnSave.Text = "Đang lưu...";

                // Upload images nếu có thay đổi
                string newAvatarUrl = _originalAvatarUrl;
                string newCoverUrl = _originalCoverUrl;
                string newCitizenImageUrl = _originalCitizenImageUrl;

                if (pbShopAvatar.Tag != null && pbShopAvatar.Tag.ToString() != _originalAvatarUrl)
                {
                    newAvatarUrl = CloudinaryHelper.UploadImage(pbShopAvatar.Tag.ToString());
                }

                if (pbShopCover.Tag != null && pbShopCover.Tag.ToString() != _originalCoverUrl)
                {
                    newCoverUrl = CloudinaryHelper.UploadImage(pbShopCover.Tag.ToString());
                }

                if (pbCitizenImage.Tag != null && pbCitizenImage.Tag.ToString() != _originalCitizenImageUrl)
                {
                    newCitizenImageUrl = CloudinaryHelper.UploadImage(pbCitizenImage.Tag.ToString());
                }

                // Cập nhật thông tin shop
                bool success = await _shopService.UpdateShopInfoAsync(
                    _currentShopId,
                    txtShopName.Text.Trim(),
                    txtDescription.Text.Trim(),
                    newAvatarUrl,
                    newCoverUrl,
                    toggleIsActive.Checked,
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    newCitizenImageUrl
                );

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _isEditMode = false;
                    SetFieldsEditable(false);
                    LoadShopData(); // Reload data
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu thay đổi";
            }
        }

        // ========== BUTTON: CANCEL ==========
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy các thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _isEditMode = false;
                SetFieldsEditable(false);
                LoadShopData(); // Reload original data
            }
        }

        // ========== BUTTON: CHANGE AVATAR ==========
        private void BtnChangeAvatar_Click(object sender, EventArgs e)
        {
            UploadImageToControl(pbShopAvatar, "Chọn ảnh đại diện");
        }

        // ========== BUTTON: CHANGE COVER ==========
        private void BtnChangeCover_Click(object sender, EventArgs e)
        {
            UploadImageToControl(pbShopCover, "Chọn ảnh bìa");
        }

        // ========== BUTTON: CHANGE CITIZEN IMAGE ==========
        private void BtnChangeCitizenImage_Click(object sender, EventArgs e)
        {
            UploadImageToControl(pbCitizenImage, "Chọn ảnh căn cước công dân");
        }

        // ========== HELPER: UPLOAD IMAGE ==========
        private void UploadImageToControl(Guna.UI2.WinForms.Guna2PictureBox pictureBox, string title)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = title;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Validate file size (max 5MB)
                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        if (fileInfo.Length > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Kích thước ảnh không được vượt quá 5MB!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Load and display image
                        using (var img = Image.FromFile(ofd.FileName))
                        {
                            pictureBox.Image = new Bitmap(img);
                        }

                        pictureBox.Tag = ofd.FileName; // Lưu đường dẫn file
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ========== SET FIELDS EDITABLE ==========
        private void SetFieldsEditable(bool editable)
        {
            // Text fields
            txtShopName.ReadOnly = !editable;
            txtDescription.ReadOnly = !editable;
            txtEmail.ReadOnly = !editable;
            txtPhone.ReadOnly = !editable;
            txtAddress.ReadOnly = !editable;

            // Toggle
            toggleIsActive.Enabled = editable;

            // Image change buttons
            btnChangeAvatar.Visible = editable;
            btnChangeCover.Visible = editable;
            btnChangeCitizenImage.Visible = editable;

            // Action buttons
            btnSave.Enabled = editable;
            btnCancel.Visible = editable;
            btnEdit.Enabled = !editable;

            // Background colors
            Color bgColor = editable ? Color.White : Color.FromArgb(245, 245, 245);
            txtShopName.FillColor = bgColor;
            txtDescription.FillColor = bgColor;
            txtEmail.FillColor = bgColor;
            txtPhone.FillColor = bgColor;
            txtAddress.FillColor = bgColor;

            // Border colors
            Color borderColor = editable ? Color.FromArgb(94, 148, 255) : Color.FromArgb(213, 218, 223);
            txtShopName.BorderColor = borderColor;
            txtDescription.BorderColor = borderColor;
            txtEmail.BorderColor = borderColor;
            txtPhone.BorderColor = borderColor;
            txtAddress.BorderColor = borderColor;
        }

        // ========== VALIDATION HELPERS ==========
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains("@") && email.Contains(".");
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return true;

            // Remove spaces and dashes
            phone = phone.Replace(" ", "").Replace("-", "").Replace(".", "");

            // Chấp nhận số điện thoại Việt Nam (10 số, bắt đầu bằng 0)
            return phone.Length == 10 && phone.All(char.IsDigit) && phone.StartsWith("0");
        }
    }
}