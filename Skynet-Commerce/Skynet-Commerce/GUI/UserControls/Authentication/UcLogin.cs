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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                // EF6 không có FirstOrDefaultAsync mặc định với .NET Framework < 4.5, nếu dùng EF Core thì ok
                var account = await Task.Run(() =>
                    db.Accounts.FirstOrDefault(a => a.Email == email && a.IsActive == true)
                );

                if (account == null)
                {
                    MessageBox.Show("Email không tồn tại hoặc tài khoản bị khóa!");
                    return;
                }

                if (!VerifyPassword(password, account.PasswordHash))
                {
                    MessageBox.Show("Sai mật khẩu!");
                    return;
                }

                // Login thành công
                AppSession.Instance.AccountID = account.AccountID;
                AppSession.Instance.Email = account.Email;

                MessageBox.Show("Đăng nhập thành công!");
                this.Visible = false; // ẩn login
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
