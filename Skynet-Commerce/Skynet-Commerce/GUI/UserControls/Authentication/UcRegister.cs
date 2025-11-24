using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

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
            // [FIX LỖI TRÙNG SỰ KIỆN]
            if (btnRegister != null)
            {
                btnRegister.Click -= btnRegister_Click;
                btnRegister.Click += btnRegister_Click;
            }

            if (lblBackToLogin != null) lblBackToLogin.Click += btnBack_Click;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_parentForm is FrmMain mainForm) mainForm.LoadPage("Login", _nextPage);
            else if (_parentForm is Authentication authForm) { UcLogin login = new UcLogin(authForm); authForm.ShowControl(login); }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
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

            btnRegister.Enabled = false;
            btnRegister.Text = "Đang xử lý...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    // 2. Check trùng
                    var exist = await Task.Run(() => db.Accounts.FirstOrDefault(a => a.Email == email || a.Phone == phone));
                    if (exist != null)
                    {
                        btnRegister.Enabled = true;
                        btnRegister.Text = "ĐĂNG KÝ";
                        if (exist.Email == email) MessageBox.Show("Email này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Số điện thoại này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string passwordHash = HashPassword(password);

                    // 3. Tạo Account
                    var newAccount = new Account
                    {
                        Email = email,
                        Phone = phone,
                        PasswordHash = passwordHash,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    };
                    db.Accounts.Add(newAccount);
                    await db.SaveChangesAsync(); // SAVE 1: AccountID được sinh ra

                    // [ĐÃ COMMENT/XÓA VÌ CÓ TRIGGER TRONG DB]
                    // var defaultRole = new UserRole { AccountID = newAccount.AccountID, RoleName = "Buyer", CreatedAt = DateTime.Now };
                    // db.UserRoles.Add(defaultRole); 

                    // 4. Tạo User Profile
                    var newUser = new Skynet_Commerce.DAL.Entities.User
                    {
                        AccountID = newAccount.AccountID, // Dùng AccountID vừa sinh ra
                        FullName = email.Split('@')[0],
                        Gender = "Other",
                        DateOfBirth = DateTime.Now
                    };
                    db.Users.Add(newUser);

                    // Lưu User Profile (Role đã được Trigger xử lý tự động)
                    await db.SaveChangesAsync(); // SAVE 2: Chỉ lưu User Profile

                    MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Chuyển sang Login
                    if (_parentForm is FrmMain mainForm) mainForm.LoadPage("Login", _nextPage);
                    else if (_parentForm is Authentication authForm) { UcLogin login = new UcLogin(authForm); authForm.ShowControl(login); }
                }
            }
            catch (Exception ex)
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "ĐĂNG KÝ";
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}