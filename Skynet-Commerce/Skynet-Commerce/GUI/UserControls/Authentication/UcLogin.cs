using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.UserControls.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcLogin : UserControl
    {
        private Authentication main;
        public UcLogin(Authentication main)
        {
            InitializeComponent();
            this.main = main;
        }
        private bool VerifyPassword(string password, string storedPassword)
        {
            return password == storedPassword;
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

            // Disable nút để tránh click đúp
            guna2Button1.Enabled = false;
            guna2Button1.Text = "Đang đăng nhập...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int count = db.Accounts.Count();
                    MessageBox.Show("Tổng số tài khoản tìm thấy trong DB: " + count);
                    // Tìm tài khoản
                    var account = await Task.Run(() =>
                        db.Accounts.FirstOrDefault(a => a.Email == email && a.IsActive == true)
                    );
                    if (account == null)
                    {
                        MessageBox.Show("Email không tồn tại hoặc tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra mật khẩu (Khớp logic với phần Register)
                    if (!VerifyPassword(password, account.PasswordHash))
                    {
                        MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Login thành công -> Lưu Session
                    AppSession.Instance.AccountID = account.AccountID;
                    AppSession.Instance.Email = account.Email;
                    // AppSession.Instance.Role = ... (Nếu bạn có bảng Role, hãy query và gán vào đây)

                    MessageBox.Show("Đăng nhập thành công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xử lý sau khi login thành công (Ví dụ: Mở Form chính và ẩn Form Login)
                    // this.main.Hide(); // Hoặc chuyển trang tùy vào logic Main Form của bạn
                    // new MainForm().Show(); 
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái nút nếu login thất bại
                if (this.Visible) // Chỉ enable lại nếu form chưa bị ẩn đi
                {
                    guna2Button1.Enabled = true;
                    guna2Button1.Text = "LOGIN";
                }
            }
        }


        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        public void ShowRegister()
        {
            UcRegister regis = new UcRegister(main);
            regis.Dock = DockStyle.Fill;
            main.ShowControl(regis);
        }
        private void btnRegis_Click(object sender, EventArgs e)
        {
            ShowRegister();
        }
    }
}
