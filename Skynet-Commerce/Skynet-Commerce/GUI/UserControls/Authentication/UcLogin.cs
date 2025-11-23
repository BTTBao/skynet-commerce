using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.BLL.Helpers; // Để dùng AppSession
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcLogin : UserControl
    {
        // Biến lưu Form cha
        private Form _parentForm;
        private string _nextPage;

        // Constructor 1: Dùng cho form Authentication cũ (giữ lại để tương thích ngược)
        public UcLogin(Authentication main)
        {
            InitializeComponent();
            _parentForm = main;
        }

        // Constructor 2: Dùng cho FrmMain (Popup giữa màn hình - KHUYÊN DÙNG)
        public UcLogin(FrmMain main, string nextPage = null)
        {
            InitializeComponent();
            _parentForm = main;
            _nextPage = nextPage;

            // Đăng ký sự kiện Click (Nếu Designer chưa gán)
            if (btnLogin != null) btnLogin.Click += btnLogin_Click;
            if (btnRegis != null) btnRegis.Click += btnRegis_Click;
        }

        private bool VerifyPassword(string password, string storedPassword)
        {
            return password == storedPassword; // (Thực tế nên dùng Hash)
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
                    var account = await Task.Run(() =>
                        db.Accounts.FirstOrDefault(a => a.Email == email && a.IsActive == true)
                    );

                    if (account == null)
                    {
                        MessageBox.Show("Email không tồn tại hoặc tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    if (!VerifyPassword(password, account.PasswordHash))
                    {
                        MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // Lấy quyền
                    var userRolesList = await Task.Run(() =>
                        db.UserRoles.Where(r => r.AccountID == account.AccountID).Select(r => r.RoleName).ToList()
                    );

                    string finalRole = "Customer";
                    if (userRolesList.Contains("Admin")) finalRole = "Admin";
                    else if (userRolesList.Contains("Seller")) finalRole = "Seller";

                    // Lưu Session
                    AppSession.Instance.AccountID = account.AccountID;
                    AppSession.Instance.Email = account.Email;
                    AppSession.Instance.Role = finalRole;

                    var userProfile = db.Users.FirstOrDefault(u => u.AccountID == account.AccountID);
                    if (userProfile != null) AppSession.Instance.FullName = userProfile.FullName;


                    // --- XỬ LÝ CHUYỂN TRANG AN TOÀN ---
                    if (_parentForm is FrmMain mainForm)
                    {
                        // 1. Ẩn Login trước để giao diện mượt
                        this.Visible = false;

                        // 2. [FIX LỖI] Kiểm tra Parent trước khi Remove
                        if (this.Parent != null)
                        {
                            this.Parent.Controls.Remove(this);
                        }

                        // 3. Chuyển đến trang đích
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
                        // Trường hợp chạy form Authentication cũ
                        FrmMain newMain = new FrmMain();
                        newMain.Show();
                        _parentForm.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

        // Sự kiện Click nút Đăng Nhập
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        // Sự kiện Click nút Đăng Ký -> Chuyển sang trang Register
        private void btnRegis_Click(object sender, EventArgs e)
        {
            if (_parentForm is FrmMain mainForm)
            {
                // Chuyển sang trang Register, mang theo nextPage để sau này quay lại
                mainForm.LoadPage("Register", _nextPage);
            }
        }
    }
}