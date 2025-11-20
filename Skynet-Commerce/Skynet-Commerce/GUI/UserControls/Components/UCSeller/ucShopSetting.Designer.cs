using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    partial class ucShopSetting
    {
        private System.ComponentModel.IContainer components = null;

        // --- Controls
        private Panel pnlMain;
        private Label lblTitle;
        private Label lblSubtitle;

        // --- Hình ảnh Shop
        private Panel pnlImageSection;
        private Label lblImageShop;
        private Label lblAvatarTitle;
        private PictureBox pbAvatar;
        private Button btnChangeAvatar;
        private Label lblCoverTitle;
        private PictureBox pbCover;
        private Button btnChangeCover;

        // --- Thông tin cơ bản
        private Panel pnlBasicInfo;
        private Label lblBasicTitle;
        private Label lblShopName;
        private TextBox txtShopName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblOperatingHours;
        private TextBox txtOperatingHours;

        // --- Thông tin Thuế & Ngân hàng
        private Panel pnlBankInfo;
        private Label lblBankTitle;
        private Label lblTaxID;
        private TextBox txtTaxID;
        private Label lblBankName;
        private TextBox txtBankName;
        private Label lblBankAccount;
        private TextBox txtBankAccount;

        private Button btnSave; // Nút lưu chung

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            // Sections
            this.pnlImageSection = new System.Windows.Forms.Panel();
            this.pnlBasicInfo = new System.Windows.Forms.Panel();
            this.pnlBankInfo = new System.Windows.Forms.Panel();

            this.btnSave = new System.Windows.Forms.Button();

            // Khởi tạo các Control
            this.InitializeImageControls();
            this.InitializeBasicInfoControls();
            this.InitializeBankInfoControls();

            // --- Cấu hình chung cho UserControl
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucShopSetting";
            this.Size = new System.Drawing.Size(1000, 900);

            // --- Cấu hình Panel Chính
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);

            // Tiêu đề
            this.lblTitle.Text = "CÀI ĐẶT SHOP";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;

            this.lblSubtitle.Text = "Quản lý thông tin và cài đặt shop của bạn";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.Location = new System.Drawing.Point(20, 60);
            this.lblSubtitle.AutoSize = true;

            // Thêm các Panel vào Main Panel
            int currentY = 100;
            int sectionSpacing = 30;

            this.pnlImageSection.Location = new System.Drawing.Point(20, currentY);
            currentY += this.pnlImageSection.Height + sectionSpacing;

            this.pnlBasicInfo.Location = new System.Drawing.Point(20, currentY);
            currentY += this.pnlBasicInfo.Height + sectionSpacing;

            this.pnlBankInfo.Location = new System.Drawing.Point(20, currentY);
            currentY += this.pnlBankInfo.Height + sectionSpacing;

            this.btnSave.Location = new System.Drawing.Point(20, currentY);
            this.btnSave.Text = "LƯU CÀI ĐẶT";
            this.btnSave.BackColor = System.Drawing.Color.Orange;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Height = 40;
            this.btnSave.Width = 150;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Thêm tất cả vào Main Panel
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblSubtitle);
            this.pnlMain.Controls.Add(this.pnlImageSection);
            this.pnlMain.Controls.Add(this.pnlBasicInfo);
            this.pnlMain.Controls.Add(this.pnlBankInfo);
            this.pnlMain.Controls.Add(this.btnSave);

            // Điều chỉnh kích thước các panel sau khi đã thêm controls (giả định chiều rộng cố định)
            int panelWidth = 800;
            this.pnlImageSection.Width = panelWidth;
            this.pnlBasicInfo.Width = panelWidth;
            this.pnlBankInfo.Width = panelWidth;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        private void InitializeImageControls()
        {
            this.pnlImageSection.BackColor = System.Drawing.Color.White;
            this.pnlImageSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImageSection.Padding = new System.Windows.Forms.Padding(15);
            int currentY = 10;

            // Title
            this.lblImageShop = new System.Windows.Forms.Label();
            this.lblImageShop.Text = "Hình ảnh Shop";
            this.lblImageShop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblImageShop.Location = new System.Drawing.Point(15, currentY);
            this.lblImageShop.AutoSize = true;
            currentY += 40;

            // Avatar Section
            this.lblAvatarTitle = new System.Windows.Forms.Label();
            this.lblAvatarTitle.Text = "Ảnh đại diện Shop";
            this.lblAvatarTitle.Location = new System.Drawing.Point(15, currentY);
            this.lblAvatarTitle.AutoSize = true;
            currentY += 25;

            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.pbAvatar.BorderStyle = BorderStyle.FixedSingle;
            this.pbAvatar.Size = new System.Drawing.Size(80, 80);
            this.pbAvatar.Location = new System.Drawing.Point(15, currentY);
            this.pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbAvatar.Image = new Bitmap(80, 80); // Placeholder image

            this.btnChangeAvatar = new System.Windows.Forms.Button();
            this.btnChangeAvatar.Text = "Upload Ảnh";
            this.btnChangeAvatar.Location = new System.Drawing.Point(110, currentY + 30);
            this.btnChangeAvatar.Click += (s, e) => MessageBox.Show("Thay đổi ảnh đại diện");
            currentY += 100;

            // Cover Section
            this.lblCoverTitle = new System.Windows.Forms.Label();
            this.lblCoverTitle.Text = "Ảnh bìa Shop";
            this.lblCoverTitle.Location = new System.Drawing.Point(15, currentY);
            this.lblCoverTitle.AutoSize = true;
            currentY += 25;

            this.pbCover = new System.Windows.Forms.PictureBox();
            this.pbCover.BorderStyle = BorderStyle.FixedSingle;
            this.pbCover.Size = new System.Drawing.Size(750, 150);
            this.pbCover.Location = new System.Drawing.Point(15, currentY);
            this.pbCover.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbCover.Image = new Bitmap(750, 150); // Placeholder image

            this.btnChangeCover = new System.Windows.Forms.Button();
            this.btnChangeCover.Text = "Upload Ảnh";
            this.btnChangeCover.Location = new System.Drawing.Point(650, currentY + 160);
            this.btnChangeCover.Click += (s, e) => MessageBox.Show("Thay đổi ảnh bìa");

            currentY += 150 + 50; // Total height of this section

            this.pnlImageSection.Controls.AddRange(new Control[] {
                this.lblImageShop, this.lblAvatarTitle, this.pbAvatar, this.btnChangeAvatar,
                this.lblCoverTitle, this.pbCover, this.btnChangeCover
            });
            this.pnlImageSection.Height = currentY + 10;
        }

        private void InitializeBasicInfoControls()
        {
            this.pnlBasicInfo.BackColor = System.Drawing.Color.White;
            this.pnlBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBasicInfo.Padding = new System.Windows.Forms.Padding(15);
            int currentY = 10;
            int inputWidth = 350;

            // Title
            this.lblBasicTitle = new System.Windows.Forms.Label();
            this.lblBasicTitle.Text = "Thông tin cơ bản";
            this.lblBasicTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBasicTitle.Location = new System.Drawing.Point(15, currentY);
            this.lblBasicTitle.AutoSize = true;
            currentY += 40;

            // Shop Name
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblShopName.Text = "Tên Shop *";
            this.lblShopName.Location = new System.Drawing.Point(15, currentY);
            this.lblShopName.AutoSize = true;
            currentY += 20;
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.txtShopName.Text = "Fashion Store";
            this.txtShopName.Location = new System.Drawing.Point(15, currentY);
            this.txtShopName.Width = inputWidth;
            currentY += 30;

            // Description
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescription.Text = "Mô tả Shop *";
            this.lblDescription.Location = new System.Drawing.Point(15, currentY);
            this.lblDescription.AutoSize = true;
            currentY += 20;
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDescription.Text = "Chuyên cung cấp các sản phẩm thời trang chất lượng cao, phong cách trẻ trung và hiện đại.";
            this.txtDescription.Location = new System.Drawing.Point(15, currentY);
            this.txtDescription.Width = inputWidth * 2 + 30; // Full width
            this.txtDescription.Height = 70;
            this.txtDescription.Multiline = true;
            currentY += 80;

            // Phone and Email (Two columns)
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPhone.Text = "Số điện thoại *";
            this.lblPhone.Location = new System.Drawing.Point(15, currentY);
            this.lblPhone.AutoSize = true;

            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmail.Text = "Email *";
            this.lblEmail.Location = new System.Drawing.Point(inputWidth + 30, currentY);
            this.lblEmail.AutoSize = true;
            currentY += 20;

            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPhone.Text = "0912345678";
            this.txtPhone.Location = new System.Drawing.Point(15, currentY);
            this.txtPhone.Width = inputWidth;

            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEmail.Text = "fashionstore@example.com";
            this.txtEmail.Location = new System.Drawing.Point(inputWidth + 30, currentY);
            this.txtEmail.Width = inputWidth;
            currentY += 40;

            // Address
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddress.Text = "Địa chỉ *";
            this.lblAddress.Location = new System.Drawing.Point(15, currentY);
            this.lblAddress.AutoSize = true;
            currentY += 20;
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtAddress.Text = "128 Đường ABC, Quận 1, TP. Hồ Chí Minh";
            this.txtAddress.Location = new System.Drawing.Point(15, currentY);
            this.txtAddress.Width = inputWidth * 2 + 30; // Full width
            currentY += 40;

            // Operating Hours
            this.lblOperatingHours = new System.Windows.Forms.Label();
            this.lblOperatingHours.Text = "Giờ hoạt động";
            this.lblOperatingHours.Location = new System.Drawing.Point(15, currentY);
            this.lblOperatingHours.AutoSize = true;
            currentY += 20;
            this.txtOperatingHours = new System.Windows.Forms.TextBox();
            this.txtOperatingHours.Text = "8:00 - 22:00";
            this.txtOperatingHours.Location = new System.Drawing.Point(15, currentY);
            this.txtOperatingHours.Width = inputWidth;
            currentY += 40;

            this.pnlBasicInfo.Controls.AddRange(new Control[] {
                this.lblBasicTitle, this.lblShopName, this.txtShopName,
                this.lblDescription, this.txtDescription,
                this.lblPhone, this.txtPhone, this.lblEmail, this.txtEmail,
                this.lblAddress, this.txtAddress,
                this.lblOperatingHours, this.txtOperatingHours
            });
            this.pnlBasicInfo.Height = currentY + 10;
        }

        private void InitializeBankInfoControls()
        {
            this.pnlBankInfo.BackColor = System.Drawing.Color.White;
            this.pnlBankInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBankInfo.Padding = new System.Windows.Forms.Padding(15);
            int currentY = 10;
            int inputWidth = 350;

            // Title
            this.lblBankTitle = new System.Windows.Forms.Label();
            this.lblBankTitle.Text = "Thông tin thuế & ngân hàng";
            this.lblBankTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBankTitle.Location = new System.Drawing.Point(15, currentY);
            this.lblBankTitle.AutoSize = true;
            currentY += 40;

            // Tax ID
            this.lblTaxID = new System.Windows.Forms.Label();
            this.lblTaxID.Text = "Mã số thuế";
            this.lblTaxID.Location = new System.Drawing.Point(15, currentY);
            this.lblTaxID.AutoSize = true;
            currentY += 20;
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.txtTaxID.Text = "0123456789";
            this.txtTaxID.Location = new System.Drawing.Point(15, currentY);
            this.txtTaxID.Width = inputWidth;
            currentY += 40;

            // Bank Name
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblBankName.Text = "Tên ngân hàng";
            this.lblBankName.Location = new System.Drawing.Point(15, currentY);
            this.lblBankName.AutoSize = true;
            currentY += 20;
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtBankName.Text = "Ngân hàng TMCP Công thương Việt Nam";
            this.txtBankName.Location = new System.Drawing.Point(15, currentY);
            this.txtBankName.Width = inputWidth * 2 + 30; // Full width
            currentY += 40;

            // Bank Account Number
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.lblBankAccount.Text = "Số tài khoản";
            this.lblBankAccount.Location = new System.Drawing.Point(15, currentY);
            this.lblBankAccount.AutoSize = true;
            currentY += 20;
            this.txtBankAccount = new System.Windows.Forms.TextBox();
            this.txtBankAccount.Text = "1234567890";
            this.txtBankAccount.Location = new System.Drawing.Point(15, currentY);
            this.txtBankAccount.Width = inputWidth;
            currentY += 40;

            this.pnlBankInfo.Controls.AddRange(new Control[] {
                this.lblBankTitle, this.lblTaxID, this.txtTaxID,
                this.lblBankName, this.txtBankName,
                this.lblBankAccount, this.txtBankAccount
            });
            this.pnlBankInfo.Height = currentY + 10;
        }

        #endregion
    }
}