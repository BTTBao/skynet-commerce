using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcChangePassword : UserControl
    {
        private FrmMain main;

        public UcChangePassword(FrmMain main)
        {
            this.main = main;
            InitializeComponent(); // Gọi từ Designer.cs
            LoadSidebarInfo();     // Tải thông tin cột trái
        }

        private async void LoadSidebarInfo()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    // Lấy thông tin user để hiển thị avatar + tên bên Sidebar
                    var user = await Task.Run(() => db.Users.FirstOrDefault(u => u.AccountID == accId));
                    var acc = await Task.Run(() => db.Accounts.Find(accId));

                    lblSidebarEmail.Text = acc?.Email;

                    if (user != null)
                    {
                        lblSidebarName.Text = string.IsNullOrEmpty(user.FullName) ? "Chưa cập nhật tên" : user.FullName;
                        if (!string.IsNullOrEmpty(user.AvatarURL))
                        {
                            try { picSidebarAvatar.Load(user.AvatarURL); } catch { }
                        }
                    }
                    else
                    {
                        lblSidebarName.Text = "Người dùng mới";
                    }
                }
            }
            catch (Exception ex)
            {
                // Ignore error loading sidebar
            }
        }

        private async void BtnChange_Click(object sender, EventArgs e)
        {
            string oldP = txtOldPass.Text.Trim();
            string newP = txtNewPass.Text;
            string confP = txtConfirmPass.Text;

            // 1. Validate
            if (string.IsNullOrEmpty(oldP) || string.IsNullOrEmpty(newP) || string.IsNullOrEmpty(confP))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newP != confP)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newP.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Process Change Password
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var acc = db.Accounts.Find(AppSession.Instance.AccountID);

                    // So sánh mật khẩu cũ (Plain text - giống logic bạn đang dùng)
                    if (acc.PasswordHash != oldP)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lưu mật khẩu mới
                    acc.PasswordHash = newP;
                    await db.SaveChangesAsync();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay về Profile
                    main.LoadPage("Profile");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            main.LoadPage("Profile");
        }

        // --- Navigation Sidebar ---
        // Khi click vào "Chỉnh sửa thông tin"
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            main.LoadPage("EditProfile");
        }

        // Khi click vào "Lịch sử mua hàng"
        private void btnMenuOrder_Click(object sender, EventArgs e)
        {
            main.LoadPage("Orders");
        }
    }
}