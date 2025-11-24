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

        // --- Đã loại bỏ phần Thuế & Ngân hàng (Không cần khai báo nữa)
        // private Guna2Panel pnlBankInfo;
        // ... (các control liên quan)

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
            // Đã loại bỏ this.pnlBankInfo

            this.btnSave = new Guna.UI2.WinForms.Guna2Button();

            // Khởi tạo các Control
            this.InitializeImageControls();
            this.InitializeBasicInfoControls();
            // Đã loại bỏ this.InitializeBankInfoControls();

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

            // Thêm các Panel vào Main Panel (Bố cục chỉ còn 1 cột cho Image Section và Basic Info)
            int panelWidth = 960; // Chiều rộng cho các panel (1000 - 2*20 padding)
            int columnX = 20;
            int currentY = 100;
            int sectionSpacing = 20;

            // COLUMN 1: Image Section (Chiều rộng được điều chỉnh)
            this.pnlImageSection.Location = new System.Drawing.Point(columnX, currentY);
            this.pnlImageSection.Width = panelWidth; // Điều chỉnh chiều rộng để tràn hết

            // Tái cấu hình lại kích thước của các control con trong Image Section để phù hợp với chiều rộng mới (Nếu cần, nhưng tạm thời giữ nguyên)
            // Cập nhật Y sau Image Section
            currentY = currentY + this.pnlImageSection.Height + sectionSpacing;

            // Basic Info Section (Thay thế cho pnlBasicInfo cũ)
            this.pnlBasicInfo.Location = new System.Drawing.Point(columnX, currentY);
            this.pnlBasicInfo.Width = panelWidth; // Điều chỉnh chiều rộng để tràn hết

            // Nút lưu
            int saveButtonY = currentY + this.pnlBasicInfo.Height + sectionSpacing;
            this.btnSave.Location = new System.Drawing.Point(columnX, saveButtonY);
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
            // Đã loại bỏ this.pnlMain.Controls.Add(this.pnlBankInfo);
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
            int sectionWidth = 930; // 960 - 2 * 15 padding

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
            this.pbCover.Size = new System.Drawing.Size(sectionWidth - 30, (sectionWidth - 30) * 4 / 16); // Tỉ lệ ~ 4:1 (Điều chỉnh theo chiều rộng mới)
            this.pbCover.Location = new System.Drawing.Point(sectionPadding, currentY);
            this.pbCover.SizeMode = PictureBoxSizeMode.StretchImage;

            this.btnChangeCover = new Guna2Button();
            this.btnChangeCover.Text = "Upload Ảnh";
            this.btnChangeCover.FillColor = System.Drawing.Color.LightGray;
            this.btnChangeCover.ForeColor = System.Drawing.Color.Black;
            this.btnChangeCover.BorderRadius = 8;
            this.btnChangeCover.Height = 35;
            // Cập nhật vị trí nút Upload Cover nằm dưới và bên phải ảnh bìa (hoặc căn giữa)
            this.btnChangeCover.Location = new System.Drawing.Point(sectionWidth - 200, currentY + this.pbCover.Height + 10);
            this.btnChangeCover.Click += new System.EventHandler(this.btnChangeCover_Click);

            currentY += this.pbCover.Height + 50; // Total height of this section

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

            int sectionWidth = 930; // 960 - 2 * 15 padding
            int sectionMargin = 30;
            int inputWidthOneColumn = sectionWidth - 2 * sectionPadding;
            int inputWidthTwoColumns = (sectionWidth - 3 * sectionPadding) / 2;
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
            this.lblEmail.Location = new System.Drawing.Point(sectionPadding + inputWidthTwoColumns + sectionMargin, labelY);
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
            this.txtEmail.Location = new System.Drawing.Point(sectionPadding + inputWidthTwoColumns + sectionMargin, controlY);
            this.txtEmail.Width = inputWidthTwoColumns;
            this.txtEmail.Height = inputHeight;
            this.txtEmail.BorderRadius = 8;
            currentY = controlY + inputHeight + 20;
            

            this.pnlBasicInfo.Controls.AddRange(new Control[] {
                this.lblBasicTitle, this.lblShopName, this.txtShopName,
                this.lblDescription, this.txtDescription,
                this.lblPhone, this.txtPhone, this.lblEmail, this.txtEmail,
                this.lblAddress, this.txtAddress,
                this.lblOperatingHours, this.txtOperatingHours
            });
            this.pnlBasicInfo.Height = currentY + 10;
        }

        // Đã loại bỏ hoàn toàn phương thức InitializeBankInfoControls()

        #endregion
    }
}