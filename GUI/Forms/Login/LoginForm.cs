using Skynet_Ecommerce.GUI.Forms.Login; // Đổi namespace nếu cần
using Skynet_Commerce.DAL.Entities; // Namespace chứa AppSession
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using Skynet_Commerce.GUI.Forms; // Cần cho Entity Framework

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
                // 2. TÌM TÀI KHOẢN TRONG CSDL
                // Lưu ý: PasswordHash thực tế nên dùng BCrypt để Verify, ở đây demo so sánh chuỗi
                var account = _context.Accounts
                    .Include(a => a.Users)      // Load thông tin User
                    .Include(a => a.UserRoles) // Load thông tin Role
                    .FirstOrDefault(a => a.Email == email);

                if (account == null)
                {
                    MessageBox.Show("Không tồn tại tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (account.IsActive == false)
                {
                    MessageBox.Show("Tài khoản đã bị khoá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra tài khoản và mật khẩu
                if (account.PasswordHash != password)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. LẤY THÔNG TIN USER & ROLE
                var userProfile = account.Users.FirstOrDefault();
                var roleObj = account.UserRoles.FirstOrDefault();
                var userRoleName = roleObj != null ? roleObj.RoleName : "Customer";

                // 4. LƯU VÀO APPSESSION (Global State)
                AppSession.Instance.Clear(); // Xóa session cũ
                AppSession.Instance.AccountID = account.AccountID;
                AppSession.Instance.Email = account.Email;
                AppSession.Instance.FullName = userProfile?.FullName ?? "Unknown User";
                AppSession.Instance.Role = userRoleName;

                // 5. XỬ LÝ "REMEMBER ME"
                if (switchRemember.Checked)
                {
                    Properties.Settings.Default.RememberUser = email;
                    Properties.Settings.Default.RememberPass = password; // Thực tế nên mã hóa trước khi lưu
                    Properties.Settings.Default.IsRemembered = true;
                }
                else
                {
                    Properties.Settings.Default.RememberUser = "";
                    Properties.Settings.Default.RememberPass = "";
                    Properties.Settings.Default.IsRemembered = false;
                }
                Properties.Settings.Default.Save(); // Lưu xuống ổ cứng

                // 6. CHUYỂN HƯỚNG THEO ROLE
                NavigateToMainForm(userRoleName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToMainForm(string role)
        {
            this.Hide(); // Ẩn form Login đi
            Form mainForm = null;

            // Logic chuyển form dựa trên Role
            switch (role.ToLower())
            {
                case "admin":
                case "administrator":
                     mainForm = new DashboardForm(); 
                    MessageBox.Show($"Xin chào Admin {AppSession.Instance.FullName}!");
                    break;

                case "staff":
                case "seller":
                     mainForm = new FrmMain();
                    MessageBox.Show($"Xin chào Staff {AppSession.Instance.FullName}!");
                    break;

                default: // User / Customer
                     mainForm = new FrmMain();
                    MessageBox.Show($"Đăng nhập thành công! Xin chào {AppSession.Instance.FullName}");
                    break;
            }

            if (mainForm != null) 
            {
                mainForm.FormClosed += (s, args) => this.Close(); // Đóng hẳn app khi form chính đóng
                mainForm.Show();
            }
            else 
            {
                this.Show(); // Hiện lại nếu chưa có form đích
            }
        }
    }
}