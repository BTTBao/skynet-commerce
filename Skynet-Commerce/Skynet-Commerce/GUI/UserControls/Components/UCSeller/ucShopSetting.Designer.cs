using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Commerce
{
    partial class ucShopSetting
    {
        private System.ComponentModel.IContainer components = null;

        // --- Controls (Đổi sang Guna)
        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblSubtitle;

        // --- Hình ảnh Shop
        private Guna2Panel pnlImageSection;
        private Label lblImageShop;
        private Label lblAvatarTitle;
        private Guna2CirclePictureBox pbAvatar; // Dùng Guna2CirclePictureBox cho Avatar
        private Guna2Button btnChangeAvatar;
        private Label lblCoverTitle;
        private Guna2PictureBox pbCover;
        private Guna2Button btnChangeCover;

        // --- Thông tin cơ bản
        private Guna2Panel pnlBasicInfo;
        private Label lblBasicTitle;
        private Label lblShopName;
        private Guna2TextBox txtShopName;
        private Label lblDescription;
        private Guna2TextBox txtDescription;
        private Label lblPhone;
        private Guna2TextBox txtPhone;
        private Label lblEmail;
        private Guna2TextBox txtEmail;
        private Label lblAddress;
        private Guna2TextBox txtAddress;
        private Label lblOperatingHours;
        private Guna2TextBox txtOperatingHours;

        // --- Thông tin Thuế & Ngân hàng
        private Guna2Panel pnlBankInfo;
        private Label lblBankTitle;
        private Label lblTaxID;
        private Guna2TextBox txtTaxID;
        private Label lblBankName;
        private Guna2TextBox txtBankName;
        private Label lblBankAccount;
        private Guna2TextBox txtBankAccount;

        private Guna2Button btnSave; // Nút lưu chung

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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            // Sections
            this.pnlImageSection = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBasicInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBankInfo = new Guna.UI2.WinForms.Guna2Panel();

            this.btnSave = new Guna.UI2.WinForms.Guna2Button();

            // Khởi tạo các Control
            this.InitializeImageControls();
            this.InitializeBasicInfoControls();
            this.InitializeBankInfoControls();

            // --- Cấu hình chung cho UserControl
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "ucShopSetting";
            this.Size = new System.Drawing.Size(1000, 900);

            // --- Cấu hình Panel Chính
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);

            // Tiêu đề
            this.lblTitle.Text = "CÀI ĐẶT SHOP";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); // Tăng size
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;

            this.lblSubtitle.Text = "Quản lý thông tin và cài đặt shop của bạn";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F); // Tăng size
            this.lblSubtitle.Location = new System.Drawing.Point(20, 60);
            this.lblSubtitle.AutoSize = true;

            // Thêm các Panel vào Main Panel (Bố cục 2 cột cho các sections chính)
            int panelWidth = 480; // Chiều rộng cho các panel 
            int column1X = 20;
            int column2X = 500;
            int currentY = 100;
            int sectionSpacing = 20;

            // Dùng cột 1 cho ImageSection và cột 2 cho BankInfo (Yêu cầu căn ngang hàng)
            // Lần lượt đặt các Panel vào vị trí

            // COLUMN 1: Image Section
            this.pnlImageSection.Location = new System.Drawing.Point(column1X, currentY);
            this.pnlImageSection.Width = panelWidth;

            // COLUMN 2: Bank Info Section
            this.pnlBankInfo.Location = new System.Drawing.Point(column2X + 30, currentY);
            this.pnlBankInfo.Width = panelWidth;

            // Thêm pnlBasicInfo xuống dưới pnlImageSection (cột 1)
            int basicInfoY = currentY + this.pnlImageSection.Height + sectionSpacing;
            this.pnlBasicInfo.Location = new System.Drawing.Point(column1X, basicInfoY);
            this.pnlBasicInfo.Width = panelWidth * 2 + 20; // Dùng chiều rộng lớn hơn cho Basic Info

            // Nút lưu
            int saveButtonY = basicInfoY + this.pnlBasicInfo.Height + sectionSpacing;
            this.btnSave.Location = new System.Drawing.Point(column1X, saveButtonY);
            this.btnSave.Text = "LƯU CÀI ĐẶT";
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))); // Màu cam
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.BorderRadius = 10;
            this.btnSave.Height = 45;
            this.btnSave.Width = 180;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);


            // Thêm tất cả vào Main Panel
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblSubtitle);
            this.pnlMain.Controls.Add(this.pnlImageSection);
            this.pnlMain.Controls.Add(this.pnlBasicInfo);
            this.pnlMain.Controls.Add(this.pnlBankInfo);
            this.pnlMain.Controls.Add(this.btnSave);

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
        }

        private void InitializeImageControls()
        {
            this.pnlImageSection.FillColor = System.Drawing.Color.White;
            this.pnlImageSection.BorderRadius = 15; // Bo góc
            this.pnlImageSection.Padding = new System.Windows.Forms.Padding(15);
            int currentY = 15;
            int sectionPadding = 15;

            // Title
            this.lblImageShop = new System.Windows.Forms.Label();
            this.lblImageShop.Text = "🖼️ Hình ảnh Shop";
            this.lblImageShop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblImageShop.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblImageShop.AutoSize = true;
            this.lblImageShop.BackColor = System.Drawing.Color.Transparent;
            currentY += 45;

            // Avatar Section
            this.lblAvatarTitle = new System.Windows.Forms.Label();
            this.lblAvatarTitle.Text = "Ảnh đại diện Shop";
            this.lblAvatarTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAvatarTitle.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblAvatarTitle.AutoSize = true;
            this.lblAvatarTitle.BackColor = System.Drawing.Color.Transparent;
            currentY += 30;

            this.pbAvatar = new Guna2CirclePictureBox();
            this.pbAvatar.Size = new System.Drawing.Size(80, 80);
            this.pbAvatar.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage; // Sử dụng StretchImage

            this.btnChangeAvatar = new Guna2Button();
            this.btnChangeAvatar.Text = "Upload Ảnh";
            this.btnChangeAvatar.FillColor = System.Drawing.Color.LightGray;
            this.btnChangeAvatar.ForeColor = System.Drawing.Color.Black;
            this.btnChangeAvatar.BorderRadius = 8;
            this.btnChangeAvatar.Height = 35;
            this.btnChangeAvatar.Location = new System.Drawing.Point(110, currentY + 25);
            this.btnChangeAvatar.Click += new System.EventHandler(this.btnChangeAvatar_Click);
            currentY += 100;

            // Cover Section
            this.lblCoverTitle = new System.Windows.Forms.Label();
            this.lblCoverTitle.Text = "Ảnh bìa Shop (Tỉ lệ 16:4)";
            this.lblCoverTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCoverTitle.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblCoverTitle.AutoSize = true;
            this.lblCoverTitle.BackColor = System.Drawing.Color.Transparent;
            currentY += 30;

            this.pbCover = new Guna2PictureBox();
            this.pbCover.BorderRadius = 10;
            this.pbCover.Size = new System.Drawing.Size(440, 110); // Tỉ lệ ~ 4:1
            this.pbCover.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.pbCover.SizeMode = PictureBoxSizeMode.StretchImage;

            this.btnChangeCover = new Guna2Button();
            this.btnChangeCover.Text = "Upload Ảnh";
            this.btnChangeCover.FillColor = System.Drawing.Color.LightGray;
            this.btnChangeCover.ForeColor = System.Drawing.Color.Black;
            this.btnChangeCover.BorderRadius = 8;
            this.btnChangeCover.Height = 35;
            this.btnChangeCover.Location = new System.Drawing.Point(280, currentY + 120); // Đặt nút bên phải ảnh bìa
            this.btnChangeCover.Click += new System.EventHandler(this.btnChangeCover_Click);

            currentY += 110 + 50; // Total height of this section

            this.pnlImageSection.Controls.AddRange(new Control[] {
                this.lblImageShop, this.lblAvatarTitle, this.pbAvatar, this.btnChangeAvatar,
                this.lblCoverTitle, this.pbCover, this.btnChangeCover
            });
            this.pnlImageSection.Height = currentY + 10;
        }

        private void InitializeBasicInfoControls()
        {
            this.pnlBasicInfo.FillColor = System.Drawing.Color.White;
            this.pnlBasicInfo.BorderRadius = 15;
            this.pnlBasicInfo.Padding = new System.Windows.Forms.Padding(15);
            int currentY = 15;
            int sectionPadding = 15;

            int panelWidth = 480;
            int sectionMargin = 30;
            int inputWidthOneColumn = panelWidth * 2 + sectionMargin;
            int inputWidthTwoColumns = 465;
            int inputHeight = 40;

            Font inputFont = new System.Drawing.Font("Times New Roman", 11F);

            // Title
            this.lblBasicTitle = new System.Windows.Forms.Label();
            this.lblBasicTitle.Text = "📝 Thông tin cơ bản";
            this.lblBasicTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBasicTitle.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblBasicTitle.AutoSize = true;
            this.lblBasicTitle.BackColor = System.Drawing.Color.Transparent;
            currentY += 45;

            // Shop Name
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblShopName.Text = "Tên Shop *";
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblShopName.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblShopName.AutoSize = true;
            this.lblShopName.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtShopName = new Guna2TextBox();
            this.txtShopName.PlaceholderText = "Nhập tên Shop";
            this.txtShopName.Text = "";
            this.txtShopName.ForeColor = System.Drawing.Color.Black;
            this.txtShopName.Font = inputFont;
            this.txtShopName.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtShopName.Width = inputWidthOneColumn;
            this.txtShopName.Height = inputHeight;
            this.txtShopName.BorderRadius = 8;
            currentY += inputHeight + 20;

            // Description
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescription.Text = "Mô tả Shop *";
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtDescription = new Guna2TextBox();
            this.txtDescription.PlaceholderText = "Nhập mô tả Shop";
            this.txtDescription.Text = "";
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Font = inputFont;
            this.txtDescription.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtDescription.Width = inputWidthOneColumn;
            this.txtDescription.Height = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.BorderRadius = 8;
            currentY += 110;

            // Phone and Email (Two columns)
            int labelY = currentY;
            int controlY = currentY + 25;

            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPhone.Text = "Số điện thoại *";
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.Location = new System.Drawing.Point(sectionPadding, labelY);
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;

            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmail.Text = "Email *";
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(inputWidthTwoColumns + sectionMargin, labelY);
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;

            this.txtPhone = new Guna2TextBox();
            this.txtPhone.PlaceholderText = "Nhập SĐT";
            this.txtPhone.Text = "";
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Font = inputFont;
            this.txtPhone.Location = new System.Drawing.Point(sectionPadding, controlY);
            this.txtPhone.Width = inputWidthTwoColumns;
            this.txtPhone.Height = inputHeight;
            this.txtPhone.BorderRadius = 8;

            this.txtEmail = new Guna2TextBox();
            this.txtEmail.PlaceholderText = "Nhập Email";
            this.txtEmail.Text = "";
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Font = inputFont;
            this.txtEmail.Location = new System.Drawing.Point(inputWidthTwoColumns + sectionMargin, controlY);
            this.txtEmail.Width = inputWidthTwoColumns;
            this.txtEmail.Height = inputHeight;
            this.txtEmail.BorderRadius = 8;
            currentY = controlY + inputHeight + 20;

            // Address
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddress.Text = "Địa chỉ *";
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtAddress = new Guna2TextBox();
            this.txtAddress.PlaceholderText = "Nhập địa chỉ";
            this.txtAddress.Text = "";
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Font = inputFont;
            this.txtAddress.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtAddress.Width = inputWidthOneColumn;
            this.txtAddress.Height = inputHeight;
            this.txtAddress.BorderRadius = 8;
            currentY += inputHeight + 20;

            // Operating Hours
            this.lblOperatingHours = new System.Windows.Forms.Label();
            this.lblOperatingHours.Text = "Giờ hoạt động";
            this.lblOperatingHours.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOperatingHours.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblOperatingHours.AutoSize = true;
            this.lblOperatingHours.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtOperatingHours = new Guna2TextBox();
            this.txtOperatingHours.PlaceholderText = "Ví dụ: 8:00 - 22:00";
            this.txtOperatingHours.Text = "";
            this.txtOperatingHours.ForeColor = System.Drawing.Color.Black;
            this.txtOperatingHours.Font = inputFont;
            this.txtOperatingHours.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtOperatingHours.Width = inputWidthTwoColumns;
            this.txtOperatingHours.Height = inputHeight;
            this.txtOperatingHours.BorderRadius = 8;
            currentY += inputHeight + 20;

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
            this.pnlBankInfo.FillColor = System.Drawing.Color.White;
            this.pnlBankInfo.BorderRadius = 15;
            this.pnlBankInfo.Padding = new System.Windows.Forms.Padding(15);
            int currentY = 15;
            int sectionPadding = 15;
            int inputWidth = 450;
            int inputHeight = 40;

            Font inputFont = new System.Drawing.Font("Times New Roman", 11F);

            // Title
            this.lblBankTitle = new System.Windows.Forms.Label();
            this.lblBankTitle.Text = "💳 Thông tin thuế & ngân hàng";
            this.lblBankTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBankTitle.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblBankTitle.AutoSize = true;
            this.lblBankTitle.BackColor = System.Drawing.Color.Transparent;
            currentY += 45;

            // Tax ID
            this.lblTaxID = new System.Windows.Forms.Label();
            this.lblTaxID.Text = "Mã số thuế";
            this.lblTaxID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxID.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblTaxID.AutoSize = true;
            this.lblTaxID.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtTaxID = new Guna2TextBox();
            this.txtTaxID.PlaceholderText = "Nhập mã số thuế";
            this.txtTaxID.Text = "";
            this.txtTaxID.ForeColor = System.Drawing.Color.Black;
            this.txtTaxID.Font = inputFont;
            this.txtTaxID.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtTaxID.Width = inputWidth;
            this.txtTaxID.Height = inputHeight;
            this.txtTaxID.BorderRadius = 8;
            currentY += inputHeight + 20;

            // Bank Name
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblBankName.Text = "Tên ngân hàng";
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBankName.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblBankName.AutoSize = true;
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtBankName = new Guna2TextBox();
            this.txtBankName.PlaceholderText = "Nhập tên ngân hàng";
            this.txtBankName.Text = "";
            this.txtBankName.ForeColor = System.Drawing.Color.Black;
            this.txtBankName.Font = inputFont;
            this.txtBankName.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtBankName.Width = inputWidth;
            this.txtBankName.Height = inputHeight;
            this.txtBankName.BorderRadius = 8;
            currentY += inputHeight + 20;

            // Bank Account Number
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.lblBankAccount.Text = "Số tài khoản";
            this.lblBankAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBankAccount.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.BackColor = System.Drawing.Color.Transparent;
            currentY += 25;

            this.txtBankAccount = new Guna2TextBox();
            this.txtBankAccount.PlaceholderText = "Nhập số tài khoản";
            this.txtBankAccount.Text = "";
            this.txtBankAccount.ForeColor = System.Drawing.Color.Black;
            this.txtBankAccount.Font = inputFont;
            this.txtBankAccount.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.txtBankAccount.Width = inputWidth;
            this.txtBankAccount.Height = inputHeight;
            this.txtBankAccount.BorderRadius = 8;
            currentY += inputHeight + 20;

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