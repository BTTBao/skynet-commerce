using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcRegister : UserControl
    {
        private Form _parentForm;
        private string _nextPage;

        public UcRegister(Authentication main)
        {
            InitializeComponent();
            _parentForm = main;
            SetupEvents();
        }

        public UcRegister(FrmMain main, string nextPage = null)
        {
            InitializeComponent();
            _parentForm = main;
            _nextPage = nextPage;
            SetupEvents();
        }

        private void SetupEvents()
        {
            if (btnRegister != null) btnRegister.Click += btnRegister_Click;
            if (lblBackToLogin != null) lblBackToLogin.Click += btnBack_Click;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_parentForm is FrmMain mainForm) mainForm.LoadPage("Login", _nextPage);
            else if (_parentForm is Authentication authForm) { UcLogin login = new UcLogin(authForm); authForm.ShowControl(login); }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text;
            string confirmPass = txtConfirmPass.Text;

            // 1. Validate
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (10 số, bắt đầu bằng 0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [QUAN TRỌNG] Khóa nút ngay lập tức để tránh Click đúp
            btnRegister.Enabled = false;
            btnRegister.Text = "Đang xử lý...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    // 2. Check trùng trong C# trước
                    var exist = await Task.Run(() => db.Accounts.FirstOrDefault(a => a.Email == email || a.Phone == phone));
                    if (exist != null)
                    {
                        // Mở lại nút nếu lỗi logic
                        btnRegister.Enabled = true;
                        btnRegister.Text = "ĐĂNG KÝ";

                        if (exist.Email == email) MessageBox.Show("Email này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Số điện thoại này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Tạo Account
                    var newAccount = new Account
                    {
                        Email = email,
                        Phone = phone,
                        PasswordHash = password,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    };
                    db.Accounts.Add(newAccount);
                    await db.SaveChangesAsync();

                    // 4. Tạo User Profile
                    var newUser = new Skynet_Commerce.DAL.Entities.User
                    {
                        AccountID = newAccount.AccountID,
                        FullName = email.Split('@')[0],
                        Gender = "Other",
                        DateOfBirth = DateTime.Now
                    };
                    db.Users.Add(newUser);
                    await db.SaveChangesAsync();

                    MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Chuyển trang
                    if (_parentForm is FrmMain mainForm) mainForm.LoadPage("Login", _nextPage);
                    else if (_parentForm is Authentication authForm) { UcLogin login = new UcLogin(authForm); authForm.ShowControl(login); }
                }
            }
            catch (Exception ex)
            {
                // Mở lại nút nếu có lỗi hệ thống để người dùng thử lại
                btnRegister.Enabled = true;
                btnRegister.Text = "ĐĂNG KÝ";

                // Kiểm tra nếu lỗi do trùng lặp (Duplicate)
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("UNIQUE KEY"))
                {
                    MessageBox.Show("Email hoặc Số điện thoại này đã tồn tại trong hệ thống!", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}