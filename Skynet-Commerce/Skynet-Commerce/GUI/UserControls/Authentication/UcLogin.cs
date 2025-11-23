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

            guna2Button1.Enabled = false;
            guna2Button1.Text = "Đang đăng nhập...";

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
                        return;
                    }

                    if (!VerifyPassword(password, account.PasswordHash))
                    {
                        MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var userRolesList = await Task.Run(() =>
                        db.UserRoles
                            .Where(r => r.AccountID == account.AccountID)
                            .Select(r => r.RoleName)
                            .ToList()
                    );

                    string finalRole = "Customer";

                    if (userRolesList.Contains("Admin"))
                    {
                        finalRole = "Admin";
                    }
                    else if (userRolesList.Contains("Seller"))
                    {
                        finalRole = "Seller";
                    }

                    AppSession.Instance.AccountID = account.AccountID;
                    AppSession.Instance.Email = account.Email;
                    AppSession.Instance.Role = finalRole;

                    MessageBox.Show($"Đăng nhập thành công với quyền: {finalRole}!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.main.Hide();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (this.Visible)
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
