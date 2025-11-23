using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.Forms.User;
using Skynet_Commerce.BLL.Helpers;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcProfile : UserControl
    {
        private FrmMain main;

        // Constructor chính nhận FrmMain
        public UcProfile(FrmMain main)
        {
            InitializeComponent();
            this.main = main;
            SetupEvents();
        }

        // Constructor mặc định
        public UcProfile()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            this.Load += UcProfile_Load;

            // Gán sự kiện click (Đã cập nhật tên biến theo file Designer mới)
            if (btnOrderHistory != null) btnOrderHistory.Click += BtnOrderHistory_Click; // Đơn mua
            if (btnChangePassword != null) btnChangePassword.Click += BtnChangePassword_Click; // Đổi mật khẩu
            if (btnAddress != null) btnAddress.Click += BtnAddress_Click; // Địa chỉ
            if (btnLogout != null) btnLogout.Click += BtnLogout_Click; // Đăng xuất

            if (btnEditProfile != null) btnEditProfile.Click += BtnEditProfile_Click; // Nút menu Edit Profile
            if (btnEditInfo != null) btnEditInfo.Click += BtnEditProfile_Click; // Nút Edit Info ở trên

            if (btnRegisterShop != null) btnRegisterShop.Click += btnRegisterShop_Click;
        }

        private async void UcProfile_Load(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập
            if (AppSession.Instance.AccountID <= 0) return;

            await LoadUserProfile();
        }

        public async Task LoadUserProfile()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;

                using (var db = new ApplicationDbContext())
                {
                    // Lấy thông tin User
                    var userInfo = await Task.Run(() =>
                        db.Users.Include(u => u.Account)
                                .FirstOrDefault(u => u.AccountID == accId)
                    );

                    // Lấy thông tin Account
                    var account = await Task.Run(() => db.Accounts.Find(accId));

                    // Hiển thị Email
                    if (lblEmail != null && account != null)
                        lblEmail.Text = account.Email;

                    if (userInfo != null)
                    {
                        // Hiển thị Tên
                        if (lblName != null)
                            lblName.Text = string.IsNullOrEmpty(userInfo.FullName) ? "Chưa cập nhật tên" : userInfo.FullName;

                        // Hiển thị Avatar
                        if (picAvatar != null && !string.IsNullOrEmpty(userInfo.AvatarURL))
                        {
                            try
                            {
                                if (userInfo.AvatarURL.StartsWith("http"))
                                    picAvatar.Load(userInfo.AvatarURL);
                                else
                                    picAvatar.ImageLocation = userInfo.AvatarURL;
                            }
                            catch { /* Giữ ảnh mặc định nếu lỗi */ }
                        }
                    }
                    else
                    {
                        if (lblName != null) lblName.Text = "Khách hàng mới";
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Lỗi tải hồ sơ: " + ex.Message);
            }
        }

        // --- CÁC SỰ KIỆN CLICK (Đã đổi tên hàm cho khớp) ---

        private void BtnOrderHistory_Click(object sender, EventArgs e)
        {
            if (main != null) main.LoadPage("Orders");
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (main != null) main.LoadPage("ChangePassword");
        }

        private void BtnAddress_Click(object sender, EventArgs e)
        {
            if (main != null) main.LoadPage("Address");
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            if (main != null) main.LoadPage("EditProfile");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 1. Xóa Session
                AppSession.Instance.Clear();
                SessionManager.ClearCart();
                // 2. Đóng Form chính
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Chuyển về trang chủ (Thay vì Restart App)
                if (main != null)
                {
                    main.LoadPage("Home");
                }
                else
                {
                    // Dự phòng nếu biến main bị null
                    FrmMain parentForm = this.FindForm() as FrmMain;
                    if (parentForm != null) parentForm.LoadPage("Home");
                }
            }
        }

        private void btnRegisterShop_Click(object sender, EventArgs e)
        {
            main.LoadPage("ShopRegister");
        }
    }
}