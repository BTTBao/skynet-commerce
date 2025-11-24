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
                btnOrderHistory.Click -= BtnOrderHistory_Click;
                btnOrderHistory.Click += BtnOrderHistory_Click;
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

            if (btnLogout != null)
            {
                btnLogout.Click -= BtnLogout_Click;
                btnLogout.Click += BtnLogout_Click;
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
            if (AppSession.Instance.AccountID <= 0)
            {
                ClearProfileUI();
                return;
            }

            await LoadUserProfile();

            // [MỚI] Kiểm tra và ẩn/hiện nút Đăng ký Shop ngay sau khi load
            UpdateSellerStatus();
        }

        // [MỚI] Hàm cập nhật trạng thái Người bán
        private void UpdateSellerStatus()
        {
            if (pnlSeller != null)
            {
                string userRole = AppSession.Instance.Role;

                // Nếu là Admin hoặc Seller thì ẩn panel đăng ký shop
                if (userRole == "Seller" || userRole == "Admin")
                {
                    pnlSeller.Visible = false;
                    // Tùy chọn: Thay đổi chức năng của nút btnRegisterShop thành "Quản lý Shop" (nếu có form quản lý)
                    // if (btnRegisterShop != null) btnRegisterShop.Text = "Quản lý Shop";
                }
                else
                {
                    // Nếu là Buyer (Người mua), vẫn hiện nút đăng ký shop
                    pnlSeller.Visible = true;
                }
            }
        }


        // Hàm mới: Xóa trắng thông tin trên giao diện
        private void ClearProfileUI()
        {
            if (lblName != null) lblName.Text = "Khách";
            if (lblEmail != null) lblEmail.Text = "---";
            if (picAvatar != null) picAvatar.Image = null; // Hoặc set ảnh default
            if (pnlSeller != null) pnlSeller.Visible = false; // Ẩn luôn nếu chưa đăng nhập
        }

        public async Task LoadUserProfile()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;

                using (var db = new ApplicationDbContext())
                {
                    var userInfo = await Task.Run(() =>
                        db.Users.Include(u => u.Account)
                                 .FirstOrDefault(u => u.AccountID == accId)
                    );

                    var account = await Task.Run(() => db.Accounts.Find(accId));

                    if (lblEmail != null && account != null)
                        lblEmail.Text = account.Email;

                    if (userInfo != null)
                    {
                        if (lblName != null)
                            lblName.Text = string.IsNullOrEmpty(userInfo.FullName) ? "Chưa cập nhật tên" : userInfo.FullName;

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
                // Xử lý lỗi
            }
        }

        // --- CÁC SỰ KIỆN CLICK (Giữ nguyên) ---

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
                AppSession.Instance.Clear();
                SessionManager.ClearCart();

                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (main != null)
                {
                    main.UpdateLoginState();
                    main.LoadPage("Home");
                }
                else
                {
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