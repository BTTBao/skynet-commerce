using Skynet_Commerce.DAL.Entities; // Namespace chứa Account và DbContext
using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions; // Thêm cái này để kiểm tra định dạng SĐT
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcRegister : UserControl
    {
        private Authentication main;

        public UcRegister(Authentication main)
        {
            this.main = main;
            InitializeComponent();

            // Gán sự kiện Click
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
        }

        private void ShowLogin()
        {
            if (main != null)
            {
                UcLogin login = new UcLogin(main);
                main.ShowControl(login);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        // Logic xử lý đăng ký
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ các TextBox
            string email = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text;
            string confirmPass = guna2TextBox3.Text;
            string phone = phoneLb.Text.Trim(); // <--- Lấy SĐT từ phoneLb

            // 2. Validate dữ liệu cơ bản
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(phone)) // <--- Check rỗng phone
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Email, SĐT, Mật khẩu)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Mật khẩu khớp
            if (password != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate độ dài mật khẩu
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate định dạng SĐT (Quan trọng: Database bạn giới hạn 10 ký tự)
            // Regex: Bắt đầu bằng số 0, theo sau là 9 chữ số nữa (Tổng 10 số)
            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (Phải là 10 số và bắt đầu bằng số 0)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khóa nút để tránh click nhiều lần
            btnRegister.Enabled = false;
            btnRegister.Text = "Đang xử lý...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    // 3. Kiểm tra Email hoặc SĐT đã tồn tại chưa
                    // Chúng ta lấy ra account đầu tiên trùng Email hoặc trùng Phone
                    var existingAccount = await Task.Run(() =>
                        db.Accounts.FirstOrDefault(a => a.Email == email || a.Phone == phone)
                    );

                    if (existingAccount != null)
                    {
                        if (existingAccount.Email == email)
                        {
                            MessageBox.Show("Email này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return; // Dừng lại không lưu
                    }

                    // 4. Tạo tài khoản mới
                    var newAccount = new Account
                    {
                        Email = email,
                        Phone = phone, // <--- Lưu SĐT vào
                        PasswordHash = password, // (Nên mã hóa nếu có thể)
                        CreatedAt = DateTime.Now,
                        IsActive = true,
                    };

                    db.Accounts.Add(newAccount);
                    await db.SaveChangesAsync();

                    MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Chuyển về màn hình đăng nhập
                    ShowLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở lại nút sau khi xử lý xong
                if (this.Visible) // Kiểm tra nếu form chưa chuyển đi
                {
                    btnRegister.Enabled = true;
                    btnRegister.Text = "REGISTER";
                }
            }
        }
    }
}