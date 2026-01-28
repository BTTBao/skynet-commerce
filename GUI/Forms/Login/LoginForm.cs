using Skynet_Commerce.DAL.Entities; // Namespace chứa AppSession
using Skynet_Commerce.GUI.Forms; // Cần cho Entity Framework
using Skynet_Ecommerce.GUI.Forms.Login; // Đổi namespace nếu cần
using Skynet_Ecommerce.GUI.Forms.Seller;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BCrypt.Net;

namespace Skynet_Ecommerce.GUI.Forms.Login
{
    public partial class LoginForm : Form
    {
        // Khởi tạo DbContext (Thay SkynetContext bằng tên Context thực tế của bạn)
        private ApplicationDbContext _context = new ApplicationDbContext();

        public LoginForm()
        {
            InitializeComponent();
            this.Load += FormLogin_Load;
            btnLogin.Click += BtnLogin_Click;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            btnBrandIcon.BringToFront();
            pnlMain.Location = new Point(
                (this.Width - pnlMain.Width) / 2,
                (this.Height - pnlMain.Height) / 2
            );

            // 1. TỰ ĐỘNG ĐIỀN THÔNG TIN NẾU ĐÃ GHI NHỚ
            if (Properties.Settings.Default.IsRemembered)
            {
                txtUser.Text = Properties.Settings.Default.RememberUser;
                txtPass.Text = Properties.Settings.Default.RememberPass;
                switchRemember.Checked = true;

                // Tùy chọn: Tự động bấm nút đăng nhập luôn (Auto Login)
                 PerformLogin(txtUser.Text, txtPass.Text);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerformLogin(username, password);
        }

        private void PerformLogin(string email, string password)
        {
            try
            {
                // 1. Tìm tài khoản trong CSDL
                var account = _context.Accounts
                    .Include(a => a.Users)
                    .Include(a => a.UserRoles)
                    .FirstOrDefault(a => a.Email == email);

                if (account == null)
                {
                    MessageBox.Show(
                        "Không tồn tại tài khoản!",
                        "Lỗi đăng nhập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                if (account.IsActive == false)
                {
                    MessageBox.Show(
                        "Tài khoản đã bị khoá!",
                        "Lỗi đăng nhập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // 2. KIỂM TRA MẬT KHẨU BẰNG BCrypt
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, account.PasswordHash);

                if (!isPasswordValid)
                {
                    MessageBox.Show(
                        "Tài khoản hoặc mật khẩu không chính xác!",
                        "Lỗi đăng nhập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // 3. LẤY THÔNG TIN USER & ROLE
                var userProfile = account.Users.FirstOrDefault();
                var roleObj = account.UserRoles.FirstOrDefault();
                string userRoleName = roleObj?.RoleName ?? "Customer";

                // 4. LƯU VÀO APPSESSION
                AppSession.Instance.Clear();
                AppSession.Instance.AccountID = account.AccountID;
                AppSession.Instance.Email = account.Email;
                AppSession.Instance.FullName = userProfile?.FullName ?? "Unknown User";
                AppSession.Instance.Role = userRoleName;

                // 5. LẤY SHOPID NẾU LÀ SELLER
                int shopId = 0;
                if (userRoleName.Equals("Seller", StringComparison.OrdinalIgnoreCase))
                {
                    var shop = _context.Shops.FirstOrDefault(s => s.AccountID == account.AccountID);
                    if (shop != null)
                    {
                        shopId = shop.ShopID;
                        // AppSession.Instance.ShopID = shopId; // nếu cần
                    }
                    else
                    {
                        MessageBox.Show(
                            "Tài khoản Seller chưa được tạo cửa hàng!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }

                // 6. REMEMBER ME (không lưu password thô)
                if (switchRemember.Checked)
                {
                    Properties.Settings.Default.RememberUser = email;
                    Properties.Settings.Default.IsRemembered = true;
                }
                else
                {
                    Properties.Settings.Default.RememberUser = "";
                    Properties.Settings.Default.IsRemembered = false;
                }
                Properties.Settings.Default.RememberPass = ""; // KHÔNG LƯU PASSWORD
                Properties.Settings.Default.Save();

                // 7. CHUYỂN FORM THEO ROLE
                NavigateToMainForm(userRoleName, shopId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi hệ thống: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void NavigateToMainForm(string role, int shopID)
        {
            Form mainForm = null;

            // Logic chuyển form dựa trên Role
            switch (role.ToLower())
            {
                case "admin":
                case "administrator":
                    MessageBox.Show($"Xin chào Admin {AppSession.Instance.FullName}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm = new DashboardForm();
                    break;

                case "seller": // Thêm logic cho Seller ở đây
                    MessageBox.Show($"Xin chào đối tác bán hàng: {AppSession.Instance.FullName}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm = new SellerMainForm(shopID); // Điều hướng sang form dành riêng cho Seller
                    break;

                case "staff":
                    MessageBox.Show($"Xin chào nhân viên {AppSession.Instance.FullName}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm = new FrmMain();
                    break;

                default: // User / Customer / Hoặc các role khác
                    MessageBox.Show($"Đăng nhập thành công! Xin chào {AppSession.Instance.FullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm = new FrmMain();
                    break;
            }

            if (mainForm != null)
            {
                this.Hide(); // Ẩn form Login
                             // Đảm bảo khi đóng form chính thì ứng dụng sẽ thoát hoàn toàn
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
        }
    }
}