using Skynet_Commerce.DAL.Entities; // Namespace chứa Account và DbContext
using System;
using System.Data.Entity; // Cần thiết cho các thao tác Async của Entity Framework
using System.Linq;
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

            // Gán sự kiện Click cho nút đăng ký (nếu chưa gán trong Designer)
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
            // 1. Lấy dữ liệu từ các TextBox (dựa theo tên trong Designer)
            string email = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text;
            string confirmPass = guna2TextBox3.Text;

            // 2. Validate dữ liệu cơ bản
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khóa nút để tránh click nhiều lần
            btnRegister.Enabled = false;
            btnRegister.Text = "Đang xử lý...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    // 3. Kiểm tra Email đã tồn tại chưa
                    // Lưu ý: Dùng Task.Run để tránh đơ UI nếu EF phiên bản cũ không hỗ trợ đầy đủ Async
                    bool isEmailExist = await Task.Run(() => db.Accounts.Any(a => a.Email == email));

                    if (isEmailExist)
                    {
                        MessageBox.Show("Email này đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Tạo tài khoản mới
                    // Lưu ý: Hiện tại đang lưu Password dạng Text thường để khớp với Login của bạn.
                    // Trong thực tế nên mã hóa (MD5/Bcrypt) trước khi lưu.
                    var newAccount = new Account
                    {
                        Email = email,
                        PasswordHash = password, // Bạn có thể thêm hàm mã hóa tại đây
                        CreatedAt = DateTime.Now,
                        IsActive = true,
                        // Các trường khác có thể để null hoặc default
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
                // Mở lại nút sau khi xử lý xong (nếu chưa chuyển trang)
                btnRegister.Enabled = true;
                btnRegister.Text = "REGISTER";
            }
        }
    }
}