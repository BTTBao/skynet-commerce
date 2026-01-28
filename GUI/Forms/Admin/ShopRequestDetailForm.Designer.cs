namespace Skynet_Commerce.GUI.Forms.Admin
{
    partial class ShopRequestDetailForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabShopInfo = new System.Windows.Forms.TabPage();
            this.pnlShopInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.tabAccountInfo = new System.Windows.Forms.TabPage();
            this.pnlAccountInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.tabCitizenInfo = new System.Windows.Forms.TabPage();
            this.pnlCitizenInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabShopInfo.SuspendLayout();
            this.tabAccountInfo.SuspendLayout();
            this.tabCitizenInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(327, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "CHI TIẾT ĐƠN ĐĂNG KÝ SHOP";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(670, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabShopInfo);
            this.tabControl.Controls.Add(this.tabAccountInfo);
            this.tabControl.Controls.Add(this.tabCitizenInfo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 540);
            this.tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.tabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabShopInfo
            // 
            this.tabShopInfo.BackColor = System.Drawing.Color.White;
            this.tabShopInfo.Controls.Add(this.pnlShopInfo);
            this.tabShopInfo.Location = new System.Drawing.Point(184, 4);
            this.tabShopInfo.Name = "tabShopInfo";
            this.tabShopInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabShopInfo.Size = new System.Drawing.Size(612, 532);
            this.tabShopInfo.TabIndex = 0;
            this.tabShopInfo.Text = "Thông tin Shop";
            // 
            // pnlShopInfo
            // 
            this.pnlShopInfo.AutoScroll = true;
            this.pnlShopInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShopInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlShopInfo.Name = "pnlShopInfo";
            this.pnlShopInfo.Padding = new System.Windows.Forms.Padding(20);
            this.pnlShopInfo.Size = new System.Drawing.Size(606, 526);
            this.pnlShopInfo.TabIndex = 0;
            // 
            // tabAccountInfo
            // 
            this.tabAccountInfo.BackColor = System.Drawing.Color.White;
            this.tabAccountInfo.Controls.Add(this.pnlAccountInfo);
            this.tabAccountInfo.Location = new System.Drawing.Point(184, 4);
            this.tabAccountInfo.Name = "tabAccountInfo";
            this.tabAccountInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountInfo.Size = new System.Drawing.Size(612, 532);
            this.tabAccountInfo.TabIndex = 1;
            this.tabAccountInfo.Text = "Thông tin chủ Shop";
            // 
            // pnlAccountInfo
            // 
            this.pnlAccountInfo.AutoScroll = true;
            this.pnlAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccountInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlAccountInfo.Name = "pnlAccountInfo";
            this.pnlAccountInfo.Padding = new System.Windows.Forms.Padding(20);
            this.pnlAccountInfo.Size = new System.Drawing.Size(606, 526);
            this.pnlAccountInfo.TabIndex = 0;
            // 
            // tabCitizenInfo
            // 
            this.tabCitizenInfo.BackColor = System.Drawing.Color.White;
            this.tabCitizenInfo.Controls.Add(this.pnlCitizenInfo);
            this.tabCitizenInfo.Location = new System.Drawing.Point(184, 4);
            this.tabCitizenInfo.Name = "tabCitizenInfo";
            this.tabCitizenInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCitizenInfo.Size = new System.Drawing.Size(612, 532);
            this.tabCitizenInfo.TabIndex = 2;
            this.tabCitizenInfo.Text = "Thông tin CCCD";
            // 
            // pnlCitizenInfo
            // 
            this.pnlCitizenInfo.AutoScroll = true;
            this.pnlCitizenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCitizenInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlCitizenInfo.Name = "pnlCitizenInfo";
            this.pnlCitizenInfo.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCitizenInfo.Size = new System.Drawing.Size(606, 526);
            this.pnlCitizenInfo.TabIndex = 0;
            // 
            // ShopRequestDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopRequestDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết đơn đăng ký Shop";
            this.Load += new System.EventHandler(this.ShopRequestDetailForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabShopInfo.ResumeLayout(false);
            this.tabAccountInfo.ResumeLayout(false);
            this.tabCitizenInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2TabControl tabControl;
        private System.Windows.Forms.TabPage tabShopInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlShopInfo;
        private System.Windows.Forms.TabPage tabAccountInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlAccountInfo;
        private System.Windows.Forms.TabPage tabCitizenInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlCitizenInfo;

        private Guna.UI2.WinForms.Guna2TextBox txtShopName;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtCreatedAt;
        private Guna.UI2.WinForms.Guna2TextBox txtReviewedAt;
        private Guna.UI2.WinForms.Guna2TextBox txtCitizenID;
        private System.Windows.Forms.PictureBox picCitizenImage;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountID;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountCreated;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtUserID;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtGender;
        private Guna.UI2.WinForms.Guna2TextBox txtDateOfBirth;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalOrders;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentRoles;
    }
}
