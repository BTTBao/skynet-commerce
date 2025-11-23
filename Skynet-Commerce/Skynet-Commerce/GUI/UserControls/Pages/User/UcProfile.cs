using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.Forms.User; // Để gọi lại Login nếu Logout
using Skynet_Commerce.GUI.UserControls.Pages.User; // Để gọi UcOrderHistory
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcProfile : UserControl
    {
        private FrmMain main;

        public UcProfile(FrmMain main)
        {
            this.main = main;
            InitializeComponent();
            this.Load += UcProfile_Load;

            // Gán sự kiện click cho các nút (Nếu chưa gán trong Designer)
            btnMenu1.Click += BtnMenu1_Click; // Đơn mua
            btnMenu2.Click += BtnMenu2_Click; // Đổi mật khẩu
            btnMenu3.Click += BtnMenu3_Click;
            btnMenu7.Click += BtnMenu7_Click; // Đăng xuất
        }

        private async void UcProfile_Load(object sender, EventArgs e)
        {
            await LoadUserProfile();
            SetupMenuLabels();
        }

        private void SetupMenuLabels()
        {
            //// Đặt tên cho các nút menu (nếu Designer chưa đặt)
            //btnMenu1.Text = "  Lịch sử mua hàng";
            //btnMenu2.Text = "  Đổi mật khẩu";
            //btnMenu3.Text = "  Voucher của tôi"; // Ví dụ
            btnMenu7.Text = "  Đăng xuất";
        }

        // Hàm tải thông tin người dùng
        public async Task LoadUserProfile()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;

                using (var db = new ApplicationDbContext())
                {
                    // Join bảng Account và User để lấy full thông tin
                    var userInfo = await Task.Run(() =>
                        db.Users.Include(u => u.Account)
                                .FirstOrDefault(u => u.AccountID == accId)
                    );

                    var account = await Task.Run(() => db.Accounts.Find(accId));

                    // Hiển thị Email
                    lblEmail.Text = account.Email;

                    if (userInfo != null)
                    {
                        // Hiển thị Tên
                        lblName.Text = string.IsNullOrEmpty(userInfo.FullName) ? "Chưa cập nhật tên" : userInfo.FullName;

                        // Hiển thị Avatar (Nếu có URL)
                        if (!string.IsNullOrEmpty(userInfo.AvatarURL))
                        {
                            try
                            {
                                picAvatar.Load(userInfo.AvatarURL); // Load ảnh từ URL
                            }
                            catch { /* Nếu lỗi link ảnh thì thôi, giữ ảnh mặc định */ }
                        }
                    }
                    else
                    {
                        lblName.Text = "Người dùng mới";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- CÁC SỰ KIỆN CHUYỂN TRANG ---

        // 1. Chuyển sang trang Chỉnh sửa thông tin
        private void BtnEditProfile_Click(object sender, EventArgs e)
        {

            main.LoadPage("EditProfile");
        }

        // 2. Chuyển sang Lịch sử đơn hàng (File bạn đã có Designer)
        private void BtnMenu1_Click(object sender, EventArgs e)
        {
            main.LoadPage("Order");
        }

        private void BtnMenu3_Click(object sender, EventArgs e)
        {
            main.LoadPage("Address");
        }
        private void BtnMenu2_Click(object sender, EventArgs e)
        {
            main.LoadPage("ChangePassword");
        }

        // 4. Đăng xuất
        private void BtnMenu7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Xóa session
                AppSession.Instance.AccountID = 0;
                AppSession.Instance.Email = null;

                // Quay về màn hình Login (Authentication Form)
                // Tùy vào kiến trúc App của bạn, thường sẽ đóng FrmMain và mở lại Form Login
                Authentication auth = new Authentication();
                auth.Show();
                main.Close(); // Đóng form chính
            }
        }

        private void btnRegisterShop_Click(object sender, EventArgs e)
        {
            main.LoadPage("ShopRegister");
        }
    }
}