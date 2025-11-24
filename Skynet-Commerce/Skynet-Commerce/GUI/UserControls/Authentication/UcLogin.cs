using Skynet_Commerce.BLL.Helpers;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Pages;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcLogin : UserControl
    {
        private Form _parentForm;
        private string _nextPage;

        // Constructor cho form Authentication cũ
        public UcLogin(Authentication main)
        {
            InitializeComponent();
            _parentForm = main;
        }

        // Constructor cho FrmMain (Popup)
        public UcLogin(FrmMain main, string nextPage = null)
        {
            InitializeComponent();
            _parentForm = main;
            _nextPage = nextPage;

            // --- SỬA LỖI 2 LẦN THÔNG BÁO TẠI ĐÂY ---
            // Gỡ bỏ sự kiện cũ (nếu có) trước khi gán mới
            if (btnLogin != null)
            {
                btnLogin.Click -= btnLogin_Click; // Gỡ
                btnLogin.Click += btnLogin_Click; // Gán
            }

            if (btnRegis != null)
            {
                btnRegis.Click -= btnRegis_Click; // Gỡ
                btnRegis.Click += btnRegis_Click; // Gán
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            // Mã hóa mật khẩu người dùng vừa nhập
            string inputHash = HashPassword(inputPassword);

            // So sánh với mật khẩu đã lưu trong DB
            return inputHash == storedHash;
        }

        // Copy lại hàm HashPassword giống bên Register để dùng
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private async Task LoginAsync()
        {
            string email = userLb.Text.Trim();
            string password = passLb.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Đang xử lý...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    // 1. Tìm Account
                    var account = await Task.Run(() =>
                        db.Accounts.FirstOrDefault(a => a.Email == email && a.IsActive == true)
                    );

                    if (account == null)
                    {
                        MessageBox.Show("Email không tồn tại hoặc tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // 2. Check Password
                    if (!VerifyPassword(password, account.PasswordHash))
                    {
                        MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // 3. Lấy Quyền (Role) - Chuẩn theo DB (Buyer, Seller, Admin)
                    var userRolesList = await Task.Run(() =>
                        db.UserRoles.Where(r => r.AccountID == account.AccountID)
                                    .Select(r => r.RoleName)
                                    .ToList()
                    );

                    string finalRole = "Buyer"; // Mặc định là Buyer
                    if (userRolesList.Contains("Admin")) finalRole = "Admin";
                    else if (userRolesList.Contains("Seller")) finalRole = "Seller";

                    // 4. Lấy Thông tin User (FullName)
                    var userProfile = await Task.Run(() =>
                        db.Users.FirstOrDefault(u => u.AccountID == account.AccountID)
                    );

                    // --- LƯU SESSION ---
                    AppSession.Instance.AccountID = account.AccountID;
                    AppSession.Instance.Email = account.Email;
                    AppSession.Instance.Role = finalRole;

                    if (userProfile != null && !string.IsNullOrEmpty(userProfile.FullName))
                    {
                        AppSession.Instance.FullName = userProfile.FullName;
                    }
                    else
                    {
                        AppSession.Instance.FullName = "Thành viên mới";
                    }

                    // [ĐÃ XÓA] Đoạn code lưu Properties.Settings ở đây

                    // ============================================================
                    // LOGIC: NẾU LÀ ADMIN -> SANG DASHBOARD
                    // ============================================================
                    if (finalRole == "Admin")
                    {
                        MessageBox.Show("Đăng nhập thành công! Chào mừng Admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DashboardForm dashboard = new DashboardForm();
                        dashboard.Show();

                        // Ẩn form chính đi
                        if (_parentForm != null) _parentForm.Hide();
                        else this.FindForm()?.Hide();

                        // Tắt toàn bộ App khi đóng Dashboard
                        dashboard.FormClosed += (s, args) => Application.Exit();

                        return; // DỪNG LẠI, KHÔNG CHẠY CODE DƯỚI
                    }

                    // ============================================================
                    // LOGIC: USER THƯỜNG -> VỀ TRANG CHỦ / TRANG TRƯỚC
                    // ============================================================
                    if (_parentForm is FrmMain mainForm)
                    {
                        // Cập nhật Header (Hiện tên user)
                        mainForm.UpdateLoginState();

                        // Ẩn Popup Login
                        this.Visible = false;
                        if (this.Parent != null) this.Parent.Controls.Remove(this);

                        // Điều hướng
                        if (!string.IsNullOrEmpty(_nextPage))
                        {
                            mainForm.LoadPage(_nextPage);
                        }
                        else
                        {
                            mainForm.LoadPage("Home");
                        }
                    }
                    else
                    {
                        // Fallback cho form Authentication cũ
                        FrmMain newMain = new FrmMain();
                        newMain.Show();
                        _parentForm.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
                ResetButton();
            }
        }

        private void ResetButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ResetButton));
                return;
            }
            btnLogin.Enabled = true;
            btnLogin.Text = "ĐĂNG NHẬP";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            if (_parentForm is FrmMain mainForm)
            {
                mainForm.LoadPage("Register", _nextPage);
            }
        }
    }
}