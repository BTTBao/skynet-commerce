using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    public partial class UcShopRegister : UserControl
    {
        private FrmMain main;

        public UcShopRegister(FrmMain main)
        {
            this.main = main;
            InitializeComponent();
            LoadSidebarInfo();
        }

        private async void LoadSidebarInfo()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    var user = await Task.Run(() => db.Users.FirstOrDefault(u => u.AccountID == accId));
                    var acc = await Task.Run(() => db.Accounts.Find(accId));

                    if (acc != null) lblSidebarEmail.Text = acc.Email;

                    if (user != null)
                    {
                        lblSidebarName.Text = string.IsNullOrEmpty(user.FullName) ? "Chưa cập nhật tên" : user.FullName;
                    }
                    else
                    {
                        lblSidebarName.Text = "Người dùng mới";
                    }
                }
            }
            catch { }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtShopName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Vui lòng nhập Tên Shop và Mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int accId = AppSession.Instance.AccountID;

                    // Kiểm tra trùng
                    var existing = db.ShopRegistrations
                        .FirstOrDefault(r => r.AccountID == accId && r.Status == "Pending");

                    if (existing != null)
                    {
                        MessageBox.Show("Bạn đã có yêu cầu đang chờ duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var newReg = new ShopRegistration
                    {
                        AccountID = accId,
                        ShopName = name,
                        Description = desc,
                        Status = "Pending",
                        CreatedAt = DateTime.Now
                    };

                    db.ShopRegistrations.Add(newReg);
                    await db.SaveChangesAsync();

                    MessageBox.Show("Gửi đăng ký thành công! Vui lòng chờ Admin duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}