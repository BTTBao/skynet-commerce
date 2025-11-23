using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcEditProfile : UserControl
    {
        private FrmMain main;

        public UcEditProfile(FrmMain main)
        {
            this.main = main;
            InitializeComponent();
            LoadCurrentInfo();
        }

        private async void LoadCurrentInfo()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    var user = await Task.Run(() => db.Users.FirstOrDefault(u => u.AccountID == accId));
                    var acc = await Task.Run(() => db.Accounts.Find(accId));

                    // Fill thông tin vào Sidebar (để đồng bộ với trang Profile)
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

                    // Fill thông tin vào các ô nhập liệu ở phần Content
                    if (acc != null) txtPhone.Text = acc.Phone;

                    if (user != null)
                    {
                        txtFullName.Text = user.FullName;
                        txtAvatarUrl.Text = user.AvatarURL;
                        if (user.DateOfBirth != null) dtpDob.Value = user.DateOfBirth.Value;
                        if (!string.IsNullOrEmpty(user.Gender)) cbGender.SelectedItem = user.Gender;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // ... (Logic lưu giữ nguyên như cũ) ...
            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    var acc = db.Accounts.Find(accId);
                    if (acc != null) acc.Phone = txtPhone.Text.Trim();

                    var user = db.Users.FirstOrDefault(u => u.AccountID == accId);
                    if (user == null)
                    {
                        user = new DAL.Entities.User { AccountID = accId };
                        db.Users.Add(user);
                    }

                    user.FullName = txtFullName.Text.Trim();
                    user.Gender = cbGender.SelectedItem?.ToString();
                    user.DateOfBirth = dtpDob.Value;
                    user.AvatarURL = txtAvatarUrl.Text.Trim();

                    await db.SaveChangesAsync();
                    MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main.LoadPage("Profile");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện nút Hủy
        private void btnCancel_Click(object sender, EventArgs e)
        {
            main.LoadPage("Profile");
        }

        // Các nút menu bên sidebar (để trống hoặc điều hướng tương ứng)
        // Vì đang ở trang Edit nên click vào các nút khác sẽ chuyển trang
        private void btnMenuOrder_Click(object sender, EventArgs e) => main.LoadPage("Orders");
        private void btnMenuPassword_Click(object sender, EventArgs e) => main.LoadPage("ChangePassword");
        // ... xử lý logout ...
    }
}