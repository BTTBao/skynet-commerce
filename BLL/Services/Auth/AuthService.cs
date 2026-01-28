using Skynet_Commerce.DAL.Entities; // Chứa AppSession, SkynetContext
using Skynet_Commerce.GUI.Forms;
using Skynet_Ecommerce.GUI.Forms.Login; // Chứa LoginForm
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Ecommerce.BLL.Services.Auth
{
    public static class AuthService
    {
        /// <summary>
        /// Hàm này kiểm tra "Remember Me", validate với DB và trả về Form cần khởi động
        /// </summary>
        public static Form GetStartupForm()
        {
            // 1. Kiểm tra xem người dùng có tick "Ghi nhớ" trước đó không
            if (Properties.Settings.Default.IsRemembered)
            {
                string storedUser = Properties.Settings.Default.RememberUser;
                string storedPass = Properties.Settings.Default.RememberPass;

                try
                {
                    // 2. Gọi DB kiểm tra lại (Validate)
                    using (var db = new ApplicationDbContext())
                    {
                        var account = db.Accounts
                            .Include(a => a.Users)
                            .Include(a => a.UserRoles)
                            .FirstOrDefault(a => a.Email == storedUser && a.IsActive == true);

                        // 3. So sánh mật khẩu
                        if (account != null && account.PasswordHash == storedPass)
                        {
                            // --- ĐĂNG NHẬP THÀNH CÔNG ---

                            // a. Nạp Session
                            var userProfile = account.Users.FirstOrDefault();
                            var roleObj = account.UserRoles.FirstOrDefault();
                            var userRoleName = roleObj != null ? roleObj.RoleName : "Buyer";

                            AppSession.Instance.Clear();
                            AppSession.Instance.AccountID = account.AccountID;
                            AppSession.Instance.Email = account.Email;
                            AppSession.Instance.FullName = userProfile?.FullName ?? "Unknown User";
                            AppSession.Instance.Role = userRoleName;

                            // b. Trả về Form tương ứng theo Role
                            if (userRoleName.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                                userRoleName.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
                            {
                                // return new AdminDashboardForm();
                                return new DashboardForm(); // Tạm thời (Thay bằng AdminForm của bạn)
                            }
                            else
                            {
                                // return new MainForm();
                                return new FrmMain(); // Tạm thời (Thay bằng UserForm của bạn)
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // 4. Nếu logic trên thất bại (Không nhớ, sai pass, lỗi DB...) -> Xóa nhớ và về Login
            ClearRememberLogin();
            return new LoginForm();
        }

        /// <summary>
        /// Hàm tiện ích để xóa ghi nhớ đăng nhập
        /// </summary>
        public static void ClearRememberLogin()
        {
            if (Properties.Settings.Default.IsRemembered)
            {
                Properties.Settings.Default.IsRemembered = false;
                Properties.Settings.Default.RememberUser = "";
                Properties.Settings.Default.RememberPass = "";
                Properties.Settings.Default.Save();
            }
        }
    }
}