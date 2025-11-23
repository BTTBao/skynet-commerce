namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcProfile
    {
        private System.ComponentModel.IContainer components = null;

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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSeller = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRegisterShop = new Guna.UI2.WinForms.Guna2Button();
            this.lblSellerDesc = new System.Windows.Forms.Label();
            this.lblSellerTitle = new System.Windows.Forms.Label();
            this.pnlProfile = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditInfo = new Guna.UI2.WinForms.Guna2Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tlpStats = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat1Key = new System.Windows.Forms.Label();
            this.lblStat1Val = new System.Windows.Forms.Label();
            this.pnlStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat2Key = new System.Windows.Forms.Label();
            this.lblStat2Val = new System.Windows.Forms.Label();
            this.pnlStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat3Key = new System.Windows.Forms.Label();
            this.lblStat3Val = new System.Windows.Forms.Label();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddress = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrderHistory = new Guna.UI2.WinForms.Guna2Button();
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSeller.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.tlpStats.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.pnlStat3.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tlpMain.Controls.Add(this.pnlRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(20);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1200, 800);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlSeller);
            this.pnlLeft.Controls.Add(this.pnlProfile);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(23, 23);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.pnlLeft.Size = new System.Drawing.Size(344, 754);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlSeller
            // 
            this.pnlSeller.BackColor = System.Drawing.Color.Transparent;
            this.pnlSeller.BorderRadius = 10;
            this.pnlSeller.Controls.Add(this.btnRegisterShop);
            this.pnlSeller.Controls.Add(this.lblSellerDesc);
            this.pnlSeller.Controls.Add(this.lblSellerTitle);
            this.pnlSeller.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.pnlSeller.Location = new System.Drawing.Point(0, 320);
            this.pnlSeller.Name = "pnlSeller";
            this.pnlSeller.ShadowDecoration.Depth = 5;
            this.pnlSeller.ShadowDecoration.Enabled = true;
            this.pnlSeller.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlSeller.Size = new System.Drawing.Size(320, 180);
            this.pnlSeller.TabIndex = 1;
            // 
            // btnRegisterShop
            // 
            this.btnRegisterShop.BorderRadius = 5;
            this.btnRegisterShop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterShop.FillColor = System.Drawing.Color.White;
            this.btnRegisterShop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegisterShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnRegisterShop.Location = new System.Drawing.Point(20, 120);
            this.btnRegisterShop.Name = "btnRegisterShop";
            this.btnRegisterShop.Size = new System.Drawing.Size(280, 40);
            this.btnRegisterShop.TabIndex = 2;
            this.btnRegisterShop.Text = "Đăng ký mở Shop";
            this.btnRegisterShop.Click += new System.EventHandler(this.btnRegisterShop_Click);
            // 
            // lblSellerDesc
            // 
            this.lblSellerDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblSellerDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSellerDesc.ForeColor = System.Drawing.Color.White;
            this.lblSellerDesc.Location = new System.Drawing.Point(20, 50);
            this.lblSellerDesc.Name = "lblSellerDesc";
            this.lblSellerDesc.Size = new System.Drawing.Size(280, 60);
            this.lblSellerDesc.TabIndex = 1;
            this.lblSellerDesc.Text = "Bắt đầu bán hàng và kiếm tiền cùng ShopViet. Đăng ký miễn phí và dễ dàng!";
            // 
            // lblSellerTitle
            // 
            this.lblSellerTitle.AutoSize = true;
            this.lblSellerTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSellerTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSellerTitle.ForeColor = System.Drawing.Color.White;
            this.lblSellerTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSellerTitle.Name = "lblSellerTitle";
            this.lblSellerTitle.Size = new System.Drawing.Size(196, 21);
            this.lblSellerTitle.TabIndex = 0;
            this.lblSellerTitle.Text = "🏠 Trở thành Người bán";
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.Transparent;
            this.pnlProfile.BorderRadius = 10;
            this.pnlProfile.Controls.Add(this.btnEditInfo);
            this.pnlProfile.Controls.Add(this.lblEmail);
            this.pnlProfile.Controls.Add(this.lblName);
            this.pnlProfile.Controls.Add(this.picAvatar);
            this.pnlProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProfile.FillColor = System.Drawing.Color.White;
            this.pnlProfile.Location = new System.Drawing.Point(0, 0);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.ShadowDecoration.Depth = 5;
            this.pnlProfile.ShadowDecoration.Enabled = true;
            this.pnlProfile.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlProfile.Size = new System.Drawing.Size(324, 280);
            this.pnlProfile.TabIndex = 0;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.BorderColor = System.Drawing.Color.LightGray;
            this.btnEditInfo.BorderRadius = 4;
            this.btnEditInfo.BorderThickness = 1;
            this.btnEditInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditInfo.FillColor = System.Drawing.Color.White;
            this.btnEditInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditInfo.ForeColor = System.Drawing.Color.Black;
            this.btnEditInfo.Location = new System.Drawing.Point(80, 220);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(160, 35);
            this.btnEditInfo.TabIndex = 3;
            this.btnEditInfo.Text = "Chỉnh sửa hồ sơ";
            this.btnEditInfo.Click += new System.EventHandler(this.BtnEditProfile_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(0, 170);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(324, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "nguyen.vana@example.com";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(0, 135);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(324, 30);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nguyễn Văn A";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.LightGray;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(112, 30);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tlpStats);
            this.pnlRight.Controls.Add(this.pnlMenu);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(373, 23);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(804, 754);
            this.pnlRight.TabIndex = 1;
            // 
            // tlpStats
            // 
            this.tlpStats.ColumnCount = 3;
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpStats.Controls.Add(this.pnlStat1, 0, 0);
            this.tlpStats.Controls.Add(this.pnlStat2, 1, 0);
            this.tlpStats.Controls.Add(this.pnlStat3, 2, 0);
            this.tlpStats.Location = new System.Drawing.Point(0, 580);
            this.tlpStats.Name = "tlpStats";
            this.tlpStats.RowCount = 1;
            this.tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStats.Size = new System.Drawing.Size(800, 120);
            this.tlpStats.TabIndex = 1;
            // 
            // pnlStat1
            // 
            this.pnlStat1.BackColor = System.Drawing.Color.Transparent;
            this.pnlStat1.BorderRadius = 10;
            this.pnlStat1.Controls.Add(this.lblStat1Key);
            this.pnlStat1.Controls.Add(this.lblStat1Val);
            this.pnlStat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStat1.FillColor = System.Drawing.Color.White;
            this.pnlStat1.Location = new System.Drawing.Point(10, 10);
            this.pnlStat1.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStat1.Name = "pnlStat1";
            this.pnlStat1.ShadowDecoration.Depth = 5;
            this.pnlStat1.ShadowDecoration.Enabled = true;
            this.pnlStat1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlStat1.Size = new System.Drawing.Size(246, 100);
            this.pnlStat1.TabIndex = 0;
            // 
            // lblStat1Key
            // 
            this.lblStat1Key.BackColor = System.Drawing.Color.Transparent;
            this.lblStat1Key.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat1Key.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat1Key.ForeColor = System.Drawing.Color.Gray;
            this.lblStat1Key.Location = new System.Drawing.Point(0, 60);
            this.lblStat1Key.Name = "lblStat1Key";
            this.lblStat1Key.Size = new System.Drawing.Size(246, 30);
            this.lblStat1Key.TabIndex = 1;
            this.lblStat1Key.Text = "Đơn hàng";
            this.lblStat1Key.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStat1Val
            // 
            this.lblStat1Val.BackColor = System.Drawing.Color.Transparent;
            this.lblStat1Val.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat1Val.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStat1Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblStat1Val.Location = new System.Drawing.Point(0, 0);
            this.lblStat1Val.Name = "lblStat1Val";
            this.lblStat1Val.Size = new System.Drawing.Size(246, 60);
            this.lblStat1Val.TabIndex = 0;
            this.lblStat1Val.Text = "12";
            this.lblStat1Val.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlStat2
            // 
            this.pnlStat2.BackColor = System.Drawing.Color.Transparent;
            this.pnlStat2.BorderRadius = 10;
            this.pnlStat2.Controls.Add(this.lblStat2Key);
            this.pnlStat2.Controls.Add(this.lblStat2Val);
            this.pnlStat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStat2.FillColor = System.Drawing.Color.White;
            this.pnlStat2.Location = new System.Drawing.Point(276, 10);
            this.pnlStat2.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStat2.Name = "pnlStat2";
            this.pnlStat2.ShadowDecoration.Depth = 5;
            this.pnlStat2.ShadowDecoration.Enabled = true;
            this.pnlStat2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlStat2.Size = new System.Drawing.Size(246, 100);
            this.pnlStat2.TabIndex = 1;
            // 
            // lblStat2Key
            // 
            this.lblStat2Key.BackColor = System.Drawing.Color.Transparent;
            this.lblStat2Key.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat2Key.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat2Key.ForeColor = System.Drawing.Color.Gray;
            this.lblStat2Key.Location = new System.Drawing.Point(0, 60);
            this.lblStat2Key.Name = "lblStat2Key";
            this.lblStat2Key.Size = new System.Drawing.Size(246, 30);
            this.lblStat2Key.TabIndex = 1;
            this.lblStat2Key.Text = "Yêu thích";
            this.lblStat2Key.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStat2Val
            // 
            this.lblStat2Val.BackColor = System.Drawing.Color.Transparent;
            this.lblStat2Val.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat2Val.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStat2Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblStat2Val.Location = new System.Drawing.Point(0, 0);
            this.lblStat2Val.Name = "lblStat2Val";
            this.lblStat2Val.Size = new System.Drawing.Size(246, 60);
            this.lblStat2Val.TabIndex = 0;
            this.lblStat2Val.Text = "5";
            this.lblStat2Val.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlStat3
            // 
            this.pnlStat3.BackColor = System.Drawing.Color.Transparent;
            this.pnlStat3.BorderRadius = 10;
            this.pnlStat3.Controls.Add(this.lblStat3Key);
            this.pnlStat3.Controls.Add(this.lblStat3Val);
            this.pnlStat3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStat3.FillColor = System.Drawing.Color.White;
            this.pnlStat3.Location = new System.Drawing.Point(542, 10);
            this.pnlStat3.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStat3.Name = "pnlStat3";
            this.pnlStat3.ShadowDecoration.Depth = 5;
            this.pnlStat3.ShadowDecoration.Enabled = true;
            this.pnlStat3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlStat3.Size = new System.Drawing.Size(248, 100);
            this.pnlStat3.TabIndex = 2;
            // 
            // lblStat3Key
            // 
            this.lblStat3Key.BackColor = System.Drawing.Color.Transparent;
            this.lblStat3Key.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat3Key.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStat3Key.ForeColor = System.Drawing.Color.Gray;
            this.lblStat3Key.Location = new System.Drawing.Point(0, 60);
            this.lblStat3Key.Name = "lblStat3Key";
            this.lblStat3Key.Size = new System.Drawing.Size(248, 30);
            this.lblStat3Key.TabIndex = 1;
            this.lblStat3Key.Text = "Đánh giá";
            this.lblStat3Key.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStat3Val
            // 
            this.lblStat3Val.BackColor = System.Drawing.Color.Transparent;
            this.lblStat3Val.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat3Val.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStat3Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblStat3Val.Location = new System.Drawing.Point(0, 0);
            this.lblStat3Val.Name = "lblStat3Val";
            this.lblStat3Val.Size = new System.Drawing.Size(248, 60);
            this.lblStat3Val.TabIndex = 0;
            this.lblStat3Val.Text = "3";
            this.lblStat3Val.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.BorderRadius = 10;
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnEditProfile);
            this.pnlMenu.Controls.Add(this.btnAddress);
            this.pnlMenu.Controls.Add(this.btnChangePassword);
            this.pnlMenu.Controls.Add(this.btnOrderHistory);
            this.pnlMenu.Controls.Add(this.lblMenuTitle);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.FillColor = System.Drawing.Color.White;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.ShadowDecoration.Depth = 5;
            this.pnlMenu.ShadowDecoration.Enabled = true;
            this.pnlMenu.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Size = new System.Drawing.Size(804, 560);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FillColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLogout.Location = new System.Drawing.Point(40, 350);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(720, 60);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "🚪   Đăng xuất";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BackColor = System.Drawing.Color.White;
            this.btnEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProfile.FillColor = System.Drawing.Color.White;
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEditProfile.ForeColor = System.Drawing.Color.Black;
            this.btnEditProfile.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnEditProfile.Location = new System.Drawing.Point(40, 280);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(720, 60);
            this.btnEditProfile.TabIndex = 6;
            this.btnEditProfile.Text = "⚙   Cài đặt tài khoản";
            this.btnEditProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditProfile.Click += new System.EventHandler(this.BtnEditProfile_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.BackColor = System.Drawing.Color.White;
            this.btnAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddress.FillColor = System.Drawing.Color.White;
            this.btnAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAddress.ForeColor = System.Drawing.Color.Black;
            this.btnAddress.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAddress.Location = new System.Drawing.Point(40, 210);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(720, 60);
            this.btnAddress.TabIndex = 3;
            this.btnAddress.Text = "📍   Địa chỉ nhận hàng";
            this.btnAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddress.Click += new System.EventHandler(this.BtnAddress_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.White;
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FillColor = System.Drawing.Color.White;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.Black;
            this.btnChangePassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnChangePassword.Location = new System.Drawing.Point(40, 140);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(720, 60);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "❤   Đổi mật khẩu";
            this.btnChangePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // btnOrderHistory
            // 
            this.btnOrderHistory.BackColor = System.Drawing.Color.White;
            this.btnOrderHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderHistory.FillColor = System.Drawing.Color.White;
            this.btnOrderHistory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOrderHistory.ForeColor = System.Drawing.Color.Black;
            this.btnOrderHistory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnOrderHistory.Location = new System.Drawing.Point(40, 70);
            this.btnOrderHistory.Name = "btnOrderHistory";
            this.btnOrderHistory.Size = new System.Drawing.Size(720, 60);
            this.btnOrderHistory.TabIndex = 1;
            this.btnOrderHistory.Text = "📦   Đơn hàng của tôi";
            this.btnOrderHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOrderHistory.Click += new System.EventHandler(this.BtnOrderHistory_Click);
            // 
            // lblMenuTitle
            // 
            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitle.Location = new System.Drawing.Point(40, 30);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new System.Drawing.Size(162, 25);
            this.lblMenuTitle.TabIndex = 0;
            this.lblMenuTitle.Text = "Tài khoản của tôi";
            // 
            // UcProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tlpMain);
            this.Name = "UcProfile";
            this.Size = new System.Drawing.Size(1200, 800);
            this.tlpMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlSeller.ResumeLayout(false);
            this.pnlSeller.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.tlpStats.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat2.ResumeLayout(false);
            this.pnlStat3.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private Guna.UI2.WinForms.Guna2Panel pnlProfile;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2Button btnEditInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlSeller;
        private System.Windows.Forms.Label lblSellerTitle;
        private System.Windows.Forms.Label lblSellerDesc;
        private Guna.UI2.WinForms.Guna2Button btnRegisterShop;
        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private System.Windows.Forms.Label lblMenuTitle;
        private Guna.UI2.WinForms.Guna2Button btnOrderHistory;
        private Guna.UI2.WinForms.Guna2Button btnAddress;
        private Guna.UI2.WinForms.Guna2Button btnEditProfile;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private Guna.UI2.WinForms.Guna2Panel pnlStat1;
        private System.Windows.Forms.Label lblStat1Key;
        private System.Windows.Forms.Label lblStat1Val;
        private Guna.UI2.WinForms.Guna2Panel pnlStat2;
        private System.Windows.Forms.Label lblStat2Key;
        private System.Windows.Forms.Label lblStat2Val;
        private Guna.UI2.WinForms.Guna2Panel pnlStat3;
        private System.Windows.Forms.Label lblStat3Key;
        private System.Windows.Forms.Label lblStat3Val;
    }
}