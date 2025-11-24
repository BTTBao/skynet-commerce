using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.BLL.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Security.Cryptography; // [MỚI] Cho Hashing
using System.Text; // Cho Encoding

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcLogin : UserControl
    {
        private Form _parentForm;
        private string _nextPage;

        // Constructor cho form Authentication cũ
        public UcLogin(Authentication main)
        {
            InitializeComponent();
            _parentForm = main;
        }

        // Constructor cho FrmMain (Popup)
        public UcLogin(FrmMain main, string nextPage = null)
        {
            InitializeComponent();
            _parentForm = main;
            _nextPage = nextPage;

            // --- ỔN ĐỊNH SỰ KIỆN CLICK (FIX LỖI 2 LẦN THÔNG BÁO) ---
            if (btnLogin != null)
            {
                btnLogin.Click -= btnLogin_Click;
                btnLogin.Click += btnLogin_Click;
            }

            if (btnRegis != null)
            {
                btnRegis.Click -= btnRegis_Click;
                btnRegis.Click += btnRegis_Click;
            }
        }

        // --- HÀM HASHING VÀ VERIFY (BẮT BUỘC ĐỂ ĐĂNG NHẬP SAU KHI ĐĂNG KÝ MÃ HÓA) ---

        // Hàm Hash mật khẩu (Copy từ UcRegister)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Hàm kiểm tra mật khẩu
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }

        private async Task LoginAsync()
        {
            string email = userLb.Text.Trim();
            string password = passLb.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Đang xử lý...";

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    // 1. Tìm Account
                    var account = await Task.Run(() =>
                        db.Accounts.FirstOrDefault(a => a.Email == email && a.IsActive == true)
                    );

                    if (account == null)
                    {
                        MessageBox.Show("Email không tồn tại hoặc tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // 2. Check Password (Dùng hàm Hash Verification)
                    if (!VerifyPassword(password, account.PasswordHash))
                    {
                        MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // 3. Lấy Quyền (Role)
                    var userRolesList = await Task.Run(() =>
                        db.UserRoles.Where(r => r.AccountID == account.AccountID)
                                    .Select(r => r.RoleName)
                                    .ToList()
                    );

                    string finalRole = "Buyer";
                    if (userRolesList.Contains("Admin")) finalRole = "Admin";
                    else if (userRolesList.Contains("Seller")) finalRole = "Seller";

                    // 4. Lấy Thông tin User (FullName)
                    var userProfile = await Task.Run(() =>
                        db.Users.FirstOrDefault(u => u.AccountID == account.AccountID)
                    );

                    // --- LƯU SESSION ---
                    AppSession.Instance.AccountID = account.AccountID;
                    AppSession.Instance.Email = account.Email;
                    AppSession.Instance.Role = finalRole;

                    if (userProfile != null && !string.IsNullOrEmpty(userProfile.FullName))
                    {
                        AppSession.Instance.FullName = userProfile.FullName;
                    }
                    else
                    {
                        AppSession.Instance.FullName = "Thành viên mới";
                    }

                    // ============================================================
                    // LOGIC ĐIỀU HƯỚNG THEO VAI TRÒ (ADMIN & SELLER)
                    // ============================================================

                    // Xử lý Admin
                    if (finalRole == "Admin")
                    {
                        MessageBox.Show("Đăng nhập thành công! Chào mừng Admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DashboardForm dashboard = new DashboardForm();
                        dashboard.Show();
                        if (_parentForm != null) _parentForm.Hide();
                        else this.FindForm()?.Hide();
                        dashboard.FormClosed += (s, args) => Application.Exit();
                        return;
                    }

                    // Xử lý Seller (Hỏi người dùng muốn vào đâu)
                    if (finalRole == "Seller")
                    {
                        int sellerShopId = 0;
                        var shop = db.Shops.FirstOrDefault(s => s.AccountID == account.AccountID);
                        if (shop != null) sellerShopId = shop.ShopID;

                        if (sellerShopId > 0)
                        {
                            DialogResult result = MessageBox.Show(
                                "Bạn muốn vào Kênh người bán hay giao diện khách hàng?",
                                "Xác nhận vai trò",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1 // Yes button
                            );

                            if (result == DialogResult.Yes) // Yes: Vào SellerLayout
                            {
                                MessageBox.Show("Chuyển đến Kênh Người Bán...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SellerLayout sellerForm = new SellerLayout(sellerShopId);
                                sellerForm.Show();

                                if (_parentForm != null) _parentForm.Hide();
                                else this.FindForm()?.Hide();

                                sellerForm.FormClosed += (s, args) => Application.Exit();
                                return;
                            }
                        }
                    }

                    // LOGIC: USER THƯỜNG (Buyer / Seller chọn NO) -> VỀ TRANG CHỦ
                    if (_parentForm is FrmMain mainForm)
                    {
                        mainForm.UpdateLoginState(); // Cập nhật Header

                        this.Visible = false;
                        if (this.Parent != null) this.Parent.Controls.Remove(this);

                        if (!string.IsNullOrEmpty(_nextPage))
                        {
                            mainForm.LoadPage(_nextPage);
                        }
                        else
                        {
                            mainForm.LoadPage("Home");
                        }
                    }
                    else
                    {
                        FrmMain newMain = new FrmMain();
                        newMain.Show();
                        _parentForm.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
                ResetButton();
            }
        }

        private void ResetButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ResetButton));
                return;
            }
            btnLogin.Enabled = true;
            btnLogin.Text = "ĐĂNG NHẬP";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            if (_parentForm is FrmMain mainForm)
            {
                mainForm.LoadPage("Register", _nextPage);
            }
        }
    }
}