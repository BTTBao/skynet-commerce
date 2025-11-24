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

            // Gán sự kiện click an toàn (Gỡ trước rồi mới gán)
            if (btnOrderHistory != null)
            {
                btnOrderHistory.Click -= BtnOrderHistory_Click; // Gỡ bỏ cũ
                btnOrderHistory.Click += BtnOrderHistory_Click; // Gán mới
            }

            if (btnChangePassword != null)
            {
                btnChangePassword.Click -= BtnChangePassword_Click;
                btnChangePassword.Click += BtnChangePassword_Click;
            }

            if (btnAddress != null)
            {
                btnAddress.Click -= BtnAddress_Click;
                btnAddress.Click += BtnAddress_Click;
            }

            // --- ĐÂY LÀ CHỖ SỬA LỖI ĐĂNG XUẤT 2 LẦN ---
            if (btnLogout != null)
            {
                btnLogout.Click -= BtnLogout_Click; // Gỡ bỏ sự kiện nếu Designer đã gán
                btnLogout.Click += BtnLogout_Click; // Gán lại duy nhất 1 lần
            }

            if (btnEditProfile != null)
            {
                btnEditProfile.Click -= BtnEditProfile_Click;
                btnEditProfile.Click += BtnEditProfile_Click;
            }

            if (btnEditInfo != null)
            {
                btnEditInfo.Click -= BtnEditProfile_Click;
                btnEditInfo.Click += BtnEditProfile_Click;
            }

            if (btnRegisterShop != null)
            {
                btnRegisterShop.Click -= btnRegisterShop_Click;
                btnRegisterShop.Click += btnRegisterShop_Click;
            }
        }

        private async void UcProfile_Load(object sender, EventArgs e)
        {
            // LOGIC MỚI: Kiểm tra đăng nhập
            // Nếu không có AccountID (đã đăng xuất), xóa trắng UI và thoát
            if (AppSession.Instance.AccountID <= 0)
            {
                ClearProfileUI(); // Xóa dữ liệu cũ trên form
                // Tùy chọn: Nếu muốn bắt buộc đăng nhập mới xem được thì chuyển trang tại đây
                // MessageBox.Show("Vui lòng đăng nhập để xem thông tin.");
                // if (main != null) main.LoadPage("Login");
                return;
            }

            // Nếu đã đăng nhập, luôn luôn fetch lại dữ liệu từ DB
            await LoadUserProfile();
        }

        // Hàm mới: Xóa trắng thông tin trên giao diện
        private void ClearProfileUI()
        {
            if (lblName != null) lblName.Text = "Khách";
            if (lblEmail != null) lblEmail.Text = "---";
            if (picAvatar != null) picAvatar.Image = null; // Hoặc set ảnh default
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
                // Xử lý lỗi âm thầm hoặc log
                // MessageBox.Show("Lỗi tải hồ sơ: " + ex.Message);
            }
        }

        // --- CÁC SỰ KIỆN CLICK ---

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
                // 1. Xóa Session & Giỏ hàng
                AppSession.Instance.Clear();
                SessionManager.ClearCart();

                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2. Xử lý logic UI Main Form
                if (main != null)
                {
                    main.UpdateLoginState();

                    // Chuyển về trang chủ
                    main.LoadPage("Home");
                }
                else
                {
                    // Dự phòng nếu biến main bị null (tìm form cha)
                    FrmMain parentForm = this.FindForm() as FrmMain;
                    if (parentForm != null)
                    {
                        parentForm.UpdateLoginState();
                        parentForm.LoadPage("Home");
                    }
                }
            }
        }

        private void btnRegisterShop_Click(object sender, EventArgs e)
        {
            if (main != null) main.LoadPage("ShopRegister");
        }
    }
}