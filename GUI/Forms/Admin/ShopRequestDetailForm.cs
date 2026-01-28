using Skynet_Ecommerce;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.Admin
{
    public partial class ShopRequestDetailForm : Form
    {
        private readonly int _registrationID;
        private ApplicationDbContext _context;

        public ShopRequestDetailForm(int registrationID)
        {
            InitializeComponent();
            _registrationID = registrationID;
            _context = new ApplicationDbContext();
        }

        private void ShopRequestDetailForm_Load(object sender, EventArgs e)
        {
            BuildUI();
            LoadRequestDetails();
        }

        private void BuildUI()
        {
            // Build Shop Info Tab
            BuildShopInfoTab();
            // Build Account Info Tab
            BuildAccountInfoTab();
            // Build Citizen Info Tab
            BuildCitizenInfoTab();
        }

        private void BuildShopInfoTab()
        {
            pnlShopInfo.Controls.Clear();
            int y = 20;

            // Section: Shop Details
            AddSectionLabel(pnlShopInfo, "THÔNG TIN SHOP", ref y);
            txtShopName = AddTextBox(pnlShopInfo, "Tên Shop:", ref y);
            txtDescription = AddTextBox(pnlShopInfo, "Mô tả:", ref y, multiline: true, height: 100);
            txtStatus = AddTextBox(pnlShopInfo, "Trạng thái:", ref y);
            txtCreatedAt = AddTextBox(pnlShopInfo, "Ngày tạo:", ref y);
            txtReviewedAt = AddTextBox(pnlShopInfo, "Ngày xét duyệt:", ref y);

            y += 20;
        }

        private void BuildAccountInfoTab()
        {
            pnlAccountInfo.Controls.Clear();
            int y = 20;

            // Section: User Info
            AddSectionLabel(pnlAccountInfo, "THÔNG TIN NGƯỜI DÙNG", ref y);
            txtUserID = AddTextBox(pnlAccountInfo, "User ID:", ref y);
            txtFullName = AddTextBox(pnlAccountInfo, "Họ tên:", ref y);
            txtGender = AddTextBox(pnlAccountInfo, "Giới tính:", ref y);
            txtDateOfBirth = AddTextBox(pnlAccountInfo, "Ngày sinh:", ref y);

            y += 20;

            // Section: Account Info
            AddSectionLabel(pnlAccountInfo, "THÔNG TIN TÀI KHOẢN", ref y);
            txtAccountID = AddTextBox(pnlAccountInfo, "Account ID:", ref y);
            txtEmail = AddTextBox(pnlAccountInfo, "Email:", ref y);
            txtPhone = AddTextBox(pnlAccountInfo, "Số điện thoại:", ref y);
            txtAccountCreated = AddTextBox(pnlAccountInfo, "Ngày tạo TK:", ref y);
            txtAccountStatus = AddTextBox(pnlAccountInfo, "Trạng thái TK:", ref y);

            y += 20;

            // Section: Statistics
            AddSectionLabel(pnlAccountInfo, "THỐNG KÊ", ref y);
            txtTotalOrders = AddTextBox(pnlAccountInfo, "Tổng đơn hàng:", ref y);
            txtCurrentRoles = AddTextBox(pnlAccountInfo, "Vai trò hiện tại:", ref y);
        }

        private void BuildCitizenInfoTab()
        {
            pnlCitizenInfo.Controls.Clear();
            int y = 20;

            AddSectionLabel(pnlCitizenInfo, "THÔNG TIN CCCD", ref y);
            txtCitizenID = AddTextBox(pnlCitizenInfo, "Số CCCD:", ref y);

            y += 20;

            // Label for Citizen Images
            var lblImage = new Label
            {
                Text = "Ảnh CCCD:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(20, y),
                AutoSize = true
            };
            pnlCitizenInfo.Controls.Add(lblImage);
            y += 30;

            // FlowLayoutPanel để chứa nhiều ảnh CCCD
            picCitizenImage = new FlowLayoutPanel
            {
                Location = new Point(20, y),
                Size = new Size(550, 400),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240),
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };
            pnlCitizenInfo.Controls.Add(picCitizenImage);
        }

        private void AddSectionLabel(Guna.UI2.WinForms.Guna2Panel panel, string text, ref int y)
        {
            var label = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136),
                Location = new Point(20, y),
                AutoSize = true
            };
            panel.Controls.Add(label);
            y += 40;
        }

        private Guna.UI2.WinForms.Guna2TextBox AddTextBox(Guna.UI2.WinForms.Guna2Panel panel, string label, ref int y, bool multiline = false, int height = 36)
        {
            // Label
            var lbl = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(20, y),
                AutoSize = true
            };
            panel.Controls.Add(lbl);
            y += 25;

            // TextBox
            var txt = new Guna.UI2.WinForms.Guna2TextBox
            {
                Location = new Point(20, y),
                Size = new Size(550, height),
                ReadOnly = true,
                BorderRadius = 8,
                Multiline = multiline,
                ScrollBars = multiline ? ScrollBars.Vertical : ScrollBars.None
            };
            panel.Controls.Add(txt);
            y += height + 15;

            return txt;
        }

        private void LoadRequestDetails()
        {
            try
            {
                var registration = _context.Database.SqlQuery<ShopRequestDetailDTO>(
                    "SELECT * FROM fn_Admin_GetShopRequestDetails(@p0)", _registrationID)
                    .FirstOrDefault();

                if (registration == null)
                {
                    MessageBox.Show("Không tìm thấy đơn đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                // Shop Information
                txtShopName.Text = registration.ShopName;
                txtDescription.Text = registration.Description ?? "";
                txtStatus.Text = registration.Status;
                txtCreatedAt.Text = registration.CreatedAt.ToString("dd/MM/yyyy HH:mm") ?? "";
                txtReviewedAt.Text = registration.ReviewedAt?.ToString("dd/MM/yyyy HH:mm") ?? "Chưa xử lý";

                // Citizen Information
                txtCitizenID.Text = registration.CitizenID ?? "N/A";
                LoadCitizenImages(registration.CitizenImageURL);

                // Account Information
                txtAccountID.Text = registration.AccountID.ToString();
                txtEmail.Text = registration.Email ?? "";
                txtPhone.Text = registration.Phone ?? "";
                txtAccountCreated.Text = registration.AccountCreatedAt.ToString("dd/MM/yyyy HH:mm");
                txtAccountStatus.Text = registration.AccountStatus ? "✓ Hoạt động" : "✖ Đã khóa";
                txtAccountStatus.ForeColor = registration.AccountStatus ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);

                // User Information
                txtUserID.Text = registration.UserID?.ToString() ?? "N/A";
                txtFullName.Text = registration.FullName ?? "N/A";
                txtGender.Text = registration.Gender ?? "N/A";
                txtDateOfBirth.Text = registration.DateOfBirth?.ToString("dd/MM/yyyy") ?? "N/A";

                // Statistics
                txtTotalOrders.Text = registration.TotalOrdersAsBuyer.ToString();
                txtCurrentRoles.Text = registration.CurrentRoles ?? "Buyer";

                // Update status colors
                UpdateStatusColors(registration.Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCitizenImages(string imageUrls)
        {
            picCitizenImage.Controls.Clear();

            if (string.IsNullOrWhiteSpace(imageUrls))
            {
                var lblNoImage = new Label
                {
                    Text = "Không có ảnh CCCD",
                    Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                picCitizenImage.Controls.Add(lblNoImage);
                return;
            }

            // Split URLs bằng dấu phẩy
            var urls = imageUrls.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var url in urls)
            {
                var trimmedUrl = url.Trim();
                if (string.IsNullOrWhiteSpace(trimmedUrl))
                    continue;

                var pic = new PictureBox
                {
                    Width = 250,
                    Height = 180,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    BackColor = Color.White
                };

                try
                {
                    pic.LoadAsync(trimmedUrl);
                }
                catch (Exception ex)
                {
                    // Nếu load thất bại, hiển thị thông báo lỗi
                    pic.BackColor = Color.LightGray;
                    Console.WriteLine($"Không thể load ảnh CCCD: {trimmedUrl}. Lỗi: {ex.Message}");
                }

                picCitizenImage.Controls.Add(pic);
            }
        }

        private void UpdateStatusColors(string status)
        {
            switch (status)
            {
                case "Pending":
                    txtStatus.ForeColor = Color.FromArgb(255, 152, 0);
                    break;
                case "Approved":
                    txtStatus.ForeColor = Color.FromArgb(16, 185, 129);
                    break;
                case "Rejected":
                    txtStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    // DTO for fn_Admin_GetShopRequestDetails
    public class ShopRequestDetailDTO
    {
        public int RegistrationID { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string CitizenID { get; set; }
        public string CitizenImageURL { get; set; }
        public int AccountID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AccountCreatedAt { get; set; }
        public bool AccountStatus { get; set; }
        public int? UserID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AvatarURL { get; set; }
        public int TotalOrdersAsBuyer { get; set; }
        public string CurrentRoles { get; set; }
    }
}
