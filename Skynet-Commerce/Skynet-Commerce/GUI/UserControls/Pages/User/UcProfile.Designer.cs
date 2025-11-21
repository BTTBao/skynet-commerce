namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcProfile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcProfile));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSeller = new System.Windows.Forms.Panel();
            this.btnRegisterShop = new System.Windows.Forms.Button();
            this.lblSellerDesc = new System.Windows.Forms.Label();
            this.lblSellerTitle = new System.Windows.Forms.Label();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tlpStats = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.lblStat1Key = new System.Windows.Forms.Label();
            this.lblStat1Val = new System.Windows.Forms.Label();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.lblStat2Key = new System.Windows.Forms.Label();
            this.lblStat2Val = new System.Windows.Forms.Label();
            this.pnlStat3 = new System.Windows.Forms.Panel();
            this.lblStat3Key = new System.Windows.Forms.Label();
            this.lblStat3Val = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnMenu7 = new System.Windows.Forms.Button();
            this.btnMenu6 = new System.Windows.Forms.Button();
            this.btnMenu5 = new System.Windows.Forms.Button();
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.btnMenu2 = new System.Windows.Forms.Button();
            this.btnMenu1 = new System.Windows.Forms.Button();
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
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tlpMain.Controls.Add(this.pnlRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(20);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 700);
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
            this.pnlLeft.Size = new System.Drawing.Size(314, 654);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlSeller
            // 
            this.pnlSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.pnlSeller.Controls.Add(this.btnRegisterShop);
            this.pnlSeller.Controls.Add(this.lblSellerDesc);
            this.pnlSeller.Controls.Add(this.lblSellerTitle);
            this.pnlSeller.Location = new System.Drawing.Point(0, 240);
            this.pnlSeller.Name = "pnlSeller";
            this.pnlSeller.Size = new System.Drawing.Size(277, 160);
            this.pnlSeller.TabIndex = 1;
            // 
            // btnRegisterShop
            // 
            this.btnRegisterShop.BackColor = System.Drawing.Color.White;
            this.btnRegisterShop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterShop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegisterShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnRegisterShop.Location = new System.Drawing.Point(15, 100);
            this.btnRegisterShop.Name = "btnRegisterShop";
            this.btnRegisterShop.Size = new System.Drawing.Size(247, 35);
            this.btnRegisterShop.TabIndex = 2;
            this.btnRegisterShop.Text = resources.GetString("btn_RegisterShop");
            this.btnRegisterShop.UseVisualStyleBackColor = false;
            // 
            // lblSellerDesc
            // 
            this.lblSellerDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSellerDesc.ForeColor = System.Drawing.Color.White;
            this.lblSellerDesc.Location = new System.Drawing.Point(15, 45);
            this.lblSellerDesc.Name = "lblSellerDesc";
            this.lblSellerDesc.Size = new System.Drawing.Size(250, 45);
            this.lblSellerDesc.TabIndex = 1;
            this.lblSellerDesc.Text = resources.GetString("lbl_SellerDesc");
            // 
            // lblSellerTitle
            // 
            this.lblSellerTitle.AutoSize = true;
            this.lblSellerTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSellerTitle.ForeColor = System.Drawing.Color.White;
            this.lblSellerTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSellerTitle.Name = "lblSellerTitle";
            this.lblSellerTitle.Size = new System.Drawing.Size(225, 25);
            this.lblSellerTitle.TabIndex = 0;
            this.lblSellerTitle.Text = resources.GetString("lbl_SellerTitle");
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.White;
            this.pnlProfile.Controls.Add(this.btnEditProfile);
            this.pnlProfile.Controls.Add(this.lblEmail);
            this.pnlProfile.Controls.Add(this.lblName);
            this.pnlProfile.Controls.Add(this.picAvatar);
            this.pnlProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProfile.Location = new System.Drawing.Point(0, 0);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(294, 220);
            this.pnlProfile.TabIndex = 0;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Location = new System.Drawing.Point(68, 170);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(140, 35);
            this.btnEditProfile.TabIndex = 3;
            this.btnEditProfile.Text = resources.GetString("btn_EditProfile");
            this.btnEditProfile.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(0, 135);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(277, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = resources.GetString("lbl_ProfileEmail");
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(0, 110);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(277, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = resources.GetString("lbl_ProfileName");
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.LightGray;
            this.picAvatar.Location = new System.Drawing.Point(98, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(80, 80);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tlpStats);
            this.pnlRight.Controls.Add(this.pnlMenu);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(343, 23);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(634, 654);
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
            this.tlpStats.Location = new System.Drawing.Point(0, 470);
            this.tlpStats.Name = "tlpStats";
            this.tlpStats.RowCount = 1;
            this.tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStats.Size = new System.Drawing.Size(634, 100);
            this.tlpStats.TabIndex = 1;
            // 
            // pnlStat1
            // 
            this.pnlStat1.BackColor = System.Drawing.Color.White;
            this.pnlStat1.Controls.Add(this.lblStat1Key);
            this.pnlStat1.Controls.Add(this.lblStat1Val);
            this.pnlStat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStat1.Location = new System.Drawing.Point(5, 5);
            this.pnlStat1.Margin = new System.Windows.Forms.Padding(5);
            this.pnlStat1.Name = "pnlStat1";
            this.pnlStat1.Size = new System.Drawing.Size(201, 90);
            this.pnlStat1.TabIndex = 0;
            // 
            // lblStat1Key
            // 
            this.lblStat1Key.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat1Key.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat1Key.ForeColor = System.Drawing.Color.Gray;
            this.lblStat1Key.Location = new System.Drawing.Point(0, 50);
            this.lblStat1Key.Name = "lblStat1Key";
            this.lblStat1Key.Size = new System.Drawing.Size(201, 23);
            this.lblStat1Key.TabIndex = 1;
            this.lblStat1Key.Text = resources.GetString("lbl_Stat1_Key");
            this.lblStat1Key.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStat1Val
            // 
            this.lblStat1Val.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat1Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat1Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblStat1Val.Location = new System.Drawing.Point(0, 0);
            this.lblStat1Val.Name = "lblStat1Val";
            this.lblStat1Val.Size = new System.Drawing.Size(201, 50);
            this.lblStat1Val.TabIndex = 0;
            this.lblStat1Val.Text = resources.GetString("lbl_Stat1_Val");
            this.lblStat1Val.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlStat2
            // 
            this.pnlStat2.BackColor = System.Drawing.Color.White;
            this.pnlStat2.Controls.Add(this.lblStat2Key);
            this.pnlStat2.Controls.Add(this.lblStat2Val);
            this.pnlStat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStat2.Location = new System.Drawing.Point(216, 5);
            this.pnlStat2.Margin = new System.Windows.Forms.Padding(5);
            this.pnlStat2.Name = "pnlStat2";
            this.pnlStat2.Size = new System.Drawing.Size(201, 90);
            this.pnlStat2.TabIndex = 1;
            // 
            // lblStat2Key
            // 
            this.lblStat2Key.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat2Key.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat2Key.ForeColor = System.Drawing.Color.Gray;
            this.lblStat2Key.Location = new System.Drawing.Point(0, 50);
            this.lblStat2Key.Name = "lblStat2Key";
            this.lblStat2Key.Size = new System.Drawing.Size(201, 23);
            this.lblStat2Key.TabIndex = 1;
            this.lblStat2Key.Text = resources.GetString("lbl_Stat2_Key");
            this.lblStat2Key.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStat2Val
            // 
            this.lblStat2Val.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat2Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat2Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblStat2Val.Location = new System.Drawing.Point(0, 0);
            this.lblStat2Val.Name = "lblStat2Val";
            this.lblStat2Val.Size = new System.Drawing.Size(201, 50);
            this.lblStat2Val.TabIndex = 0;
            this.lblStat2Val.Text = resources.GetString("lbl_Stat2_Val");
            this.lblStat2Val.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlStat3
            // 
            this.pnlStat3.BackColor = System.Drawing.Color.White;
            this.pnlStat3.Controls.Add(this.lblStat3Key);
            this.pnlStat3.Controls.Add(this.lblStat3Val);
            this.pnlStat3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStat3.Location = new System.Drawing.Point(427, 5);
            this.pnlStat3.Margin = new System.Windows.Forms.Padding(5);
            this.pnlStat3.Name = "pnlStat3";
            this.pnlStat3.Size = new System.Drawing.Size(202, 90);
            this.pnlStat3.TabIndex = 2;
            // 
            // lblStat3Key
            // 
            this.lblStat3Key.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat3Key.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat3Key.ForeColor = System.Drawing.Color.Gray;
            this.lblStat3Key.Location = new System.Drawing.Point(0, 50);
            this.lblStat3Key.Name = "lblStat3Key";
            this.lblStat3Key.Size = new System.Drawing.Size(202, 23);
            this.lblStat3Key.TabIndex = 1;
            this.lblStat3Key.Text = resources.GetString("lbl_Stat3_Key");
            this.lblStat3Key.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStat3Val
            // 
            this.lblStat3Val.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStat3Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat3Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblStat3Val.Location = new System.Drawing.Point(0, 0);
            this.lblStat3Val.Name = "lblStat3Val";
            this.lblStat3Val.Size = new System.Drawing.Size(202, 50);
            this.lblStat3Val.TabIndex = 0;
            this.lblStat3Val.Text = resources.GetString("lbl_Stat3_Val");
            this.lblStat3Val.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnMenu7);
            this.pnlMenu.Controls.Add(this.btnMenu6);
            this.pnlMenu.Controls.Add(this.btnMenu5);
            this.pnlMenu.Controls.Add(this.btnMenu4);
            this.pnlMenu.Controls.Add(this.btnMenu3);
            this.pnlMenu.Controls.Add(this.btnMenu2);
            this.pnlMenu.Controls.Add(this.btnMenu1);
            this.pnlMenu.Controls.Add(this.lblMenuTitle);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(634, 450);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnMenu7
            // 
            this.btnMenu7.BackColor = System.Drawing.Color.White;
            this.btnMenu7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu7.FlatAppearance.BorderSize = 0;
            this.btnMenu7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu7.ForeColor = System.Drawing.Color.Red;
            this.btnMenu7.Location = new System.Drawing.Point(0, 360);
            this.btnMenu7.Name = "btnMenu7";
            this.btnMenu7.Size = new System.Drawing.Size(634, 50);
            this.btnMenu7.TabIndex = 7;
            this.btnMenu7.Text = resources.GetString("btn_Menu7");
            this.btnMenu7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu7.UseVisualStyleBackColor = false;
            // 
            // btnMenu6
            // 
            this.btnMenu6.BackColor = System.Drawing.Color.White;
            this.btnMenu6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu6.FlatAppearance.BorderSize = 0;
            this.btnMenu6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu6.Location = new System.Drawing.Point(0, 310);
            this.btnMenu6.Name = "btnMenu6";
            this.btnMenu6.Size = new System.Drawing.Size(634, 50);
            this.btnMenu6.TabIndex = 6;
            this.btnMenu6.Text = resources.GetString("btn_Menu6");
            this.btnMenu6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu6.UseVisualStyleBackColor = false;
            // 
            // btnMenu5
            // 
            this.btnMenu5.BackColor = System.Drawing.Color.White;
            this.btnMenu5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu5.FlatAppearance.BorderSize = 0;
            this.btnMenu5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu5.Location = new System.Drawing.Point(0, 260);
            this.btnMenu5.Name = "btnMenu5";
            this.btnMenu5.Size = new System.Drawing.Size(634, 50);
            this.btnMenu5.TabIndex = 5;
            this.btnMenu5.Text = resources.GetString("btn_Menu5");
            this.btnMenu5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu5.UseVisualStyleBackColor = false;
            // 
            // btnMenu4
            // 
            this.btnMenu4.BackColor = System.Drawing.Color.White;
            this.btnMenu4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu4.FlatAppearance.BorderSize = 0;
            this.btnMenu4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu4.Location = new System.Drawing.Point(0, 210);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Size = new System.Drawing.Size(634, 50);
            this.btnMenu4.TabIndex = 4;
            this.btnMenu4.Text = resources.GetString("btn_Menu4");
            this.btnMenu4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu4.UseVisualStyleBackColor = false;
            // 
            // btnMenu3
            // 
            this.btnMenu3.BackColor = System.Drawing.Color.White;
            this.btnMenu3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu3.FlatAppearance.BorderSize = 0;
            this.btnMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu3.Location = new System.Drawing.Point(0, 160);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Size = new System.Drawing.Size(634, 50);
            this.btnMenu3.TabIndex = 3;
            this.btnMenu3.Text = resources.GetString("btn_Menu3");
            this.btnMenu3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu3.UseVisualStyleBackColor = false;
            // 
            // btnMenu2
            // 
            this.btnMenu2.BackColor = System.Drawing.Color.White;
            this.btnMenu2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu2.FlatAppearance.BorderSize = 0;
            this.btnMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu2.Location = new System.Drawing.Point(0, 110);
            this.btnMenu2.Name = "btnMenu2";
            this.btnMenu2.Size = new System.Drawing.Size(634, 50);
            this.btnMenu2.TabIndex = 2;
            this.btnMenu2.Text = resources.GetString("btn_Menu2");
            this.btnMenu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu2.UseVisualStyleBackColor = false;
            // 
            // btnMenu1
            // 
            this.btnMenu1.BackColor = System.Drawing.Color.White;
            this.btnMenu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu1.FlatAppearance.BorderSize = 0;
            this.btnMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu1.Location = new System.Drawing.Point(0, 60);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Size = new System.Drawing.Size(634, 50);
            this.btnMenu1.TabIndex = 1;
            this.btnMenu1.Text = resources.GetString("btn_Menu1");
            this.btnMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu1.UseVisualStyleBackColor = false;
            // 
            // lblMenuTitle
            // 
            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitle.Location = new System.Drawing.Point(20, 15);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new System.Drawing.Size(203, 30);
            this.lblMenuTitle.TabIndex = 0;
            this.lblMenuTitle.Text = resources.GetString("lbl_MenuTitle");
            // 
            // UcProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tlpMain);
            this.Name = "UcProfile";
            this.Size = new System.Drawing.Size(1000, 700);
            this.tlpMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlSeller.ResumeLayout(false);
            this.pnlSeller.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.tlpStats.ResumeLayout(false);
            this.pnlStat3.ResumeLayout(false);
            this.pnlStat2.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Panel pnlSeller;
        private System.Windows.Forms.Label lblSellerTitle;
        private System.Windows.Forms.Label lblSellerDesc;
        private System.Windows.Forms.Button btnRegisterShop;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.Button btnMenu1;
        private System.Windows.Forms.Button btnMenu2;
        private System.Windows.Forms.Button btnMenu3;
        private System.Windows.Forms.Button btnMenu4;
        private System.Windows.Forms.Button btnMenu5;
        private System.Windows.Forms.Button btnMenu6;
        private System.Windows.Forms.Button btnMenu7;
        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Label lblStat1Key;
        private System.Windows.Forms.Label lblStat1Val;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Label lblStat2Key;
        private System.Windows.Forms.Label lblStat2Val;
        private System.Windows.Forms.Panel pnlStat3;
        private System.Windows.Forms.Label lblStat3Key;
        private System.Windows.Forms.Label lblStat3Val;
    }
}