namespace Skynet_Commerce.GUI.Forms
{
    partial class ShopsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this._pageTitle = new System.Windows.Forms.Label();
            this._pageSub = new System.Windows.Forms.Label();
            this._cardPending = new Guna.UI2.WinForms.Guna2Panel();
            this._lblPendingTitle = new System.Windows.Forms.Label();
            this._headerPending = new System.Windows.Forms.Panel();
            this._lblH_P_Id = new System.Windows.Forms.Label();
            this._lblH_P_Name = new System.Windows.Forms.Label();
            this._lblH_P_Owner = new System.Windows.Forms.Label();
            this._lblH_P_Email = new System.Windows.Forms.Label();
            this._lblH_P_Sub = new System.Windows.Forms.Label();
            this._lblH_P_Act = new System.Windows.Forms.Label();
            this._pendingContainer = new System.Windows.Forms.FlowLayoutPanel();
            this._cardAllShops = new Guna.UI2.WinForms.Guna2Panel();
            this._lblAllShopsTitle = new System.Windows.Forms.Label();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._headerActive = new System.Windows.Forms.Panel();
            this._lblH_A_Id = new System.Windows.Forms.Label();
            this._lblH_A_Name = new System.Windows.Forms.Label();
            this._lblH_A_Owner = new System.Windows.Forms.Label();
            this._lblH_A_Rate = new System.Windows.Forms.Label();
            this._lblH_A_Prod = new System.Windows.Forms.Label();
            this._lblH_A_Stat = new System.Windows.Forms.Label();
            this._lblH_A_Act = new System.Windows.Forms.Label();
            this._activeContainer = new System.Windows.Forms.FlowLayoutPanel();
            this._comboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this._cardPending.SuspendLayout();
            this._headerPending.SuspendLayout();
            this._cardAllShops.SuspendLayout();
            this._headerActive.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pageTitle
            // 
            this._pageTitle.AutoSize = true;
            this._pageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._pageTitle.Location = new System.Drawing.Point(20, 20);
            this._pageTitle.Name = "_pageTitle";
            this._pageTitle.Size = new System.Drawing.Size(167, 25);
            this._pageTitle.TabIndex = 3;
            this._pageTitle.Text = "Quản lý cửa hàng";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(334, 19);
            this._pageSub.TabIndex = 2;
            this._pageSub.Text = "Rà soát và quản lý tất cả các cửa hàng trên hệ thống.";
            // 
            // _cardPending
            // 
            this._cardPending.BackColor = System.Drawing.Color.Transparent;
            this._cardPending.BorderRadius = 12;
            this._cardPending.Controls.Add(this._lblPendingTitle);
            this._cardPending.Controls.Add(this._headerPending);
            this._cardPending.Controls.Add(this._pendingContainer);
            this._cardPending.FillColor = System.Drawing.Color.White;
            this._cardPending.Location = new System.Drawing.Point(25, 90);
            this._cardPending.Name = "_cardPending";
            this._cardPending.ShadowDecoration.Depth = 5;
            this._cardPending.ShadowDecoration.Enabled = true;
            this._cardPending.Size = new System.Drawing.Size(997, 250);
            this._cardPending.TabIndex = 1;
            // 
            // _lblPendingTitle
            // 
            this._lblPendingTitle.AutoSize = true;
            this._lblPendingTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblPendingTitle.Location = new System.Drawing.Point(20, 20);
            this._lblPendingTitle.Name = "_lblPendingTitle";
            this._lblPendingTitle.Size = new System.Drawing.Size(202, 20);
            this._lblPendingTitle.TabIndex = 0;
            this._lblPendingTitle.Text = "Đang chờ đăng ký cửa hàng";
            // 
            // _headerPending
            // 
            this._headerPending.Controls.Add(this._lblH_P_Id);
            this._headerPending.Controls.Add(this._lblH_P_Name);
            this._headerPending.Controls.Add(this._lblH_P_Owner);
            this._headerPending.Controls.Add(this._lblH_P_Email);
            this._headerPending.Controls.Add(this._lblH_P_Sub);
            this._headerPending.Controls.Add(this._lblH_P_Act);
            this._headerPending.Location = new System.Drawing.Point(20, 50);
            this._headerPending.Name = "_headerPending";
            this._headerPending.Size = new System.Drawing.Size(974, 30);
            this._headerPending.TabIndex = 1;
            // 
            // _lblH_P_Id
            // 
            this._lblH_P_Id.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_P_Id.Location = new System.Drawing.Point(24, 4);
            this._lblH_P_Id.Name = "_lblH_P_Id";
            this._lblH_P_Id.Size = new System.Drawing.Size(68, 23);
            this._lblH_P_Id.TabIndex = 0;
            this._lblH_P_Id.Text = "Shop ID";
            // 
            // _lblH_P_Name
            // 
            this._lblH_P_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_P_Name.Location = new System.Drawing.Point(126, 4);
            this._lblH_P_Name.Name = "_lblH_P_Name";
            this._lblH_P_Name.Size = new System.Drawing.Size(87, 23);
            this._lblH_P_Name.TabIndex = 1;
            this._lblH_P_Name.Text = "Tên cửa hàng";
            // 
            // _lblH_P_Owner
            // 
            this._lblH_P_Owner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_P_Owner.Location = new System.Drawing.Point(290, 4);
            this._lblH_P_Owner.Name = "_lblH_P_Owner";
            this._lblH_P_Owner.Size = new System.Drawing.Size(93, 23);
            this._lblH_P_Owner.TabIndex = 2;
            this._lblH_P_Owner.Text = "Người sở hữu";
            // 
            // _lblH_P_Email
            // 
            this._lblH_P_Email.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_P_Email.Location = new System.Drawing.Point(439, 4);
            this._lblH_P_Email.Name = "_lblH_P_Email";
            this._lblH_P_Email.Size = new System.Drawing.Size(100, 23);
            this._lblH_P_Email.TabIndex = 3;
            this._lblH_P_Email.Text = "Email";
            // 
            // _lblH_P_Sub
            // 
            this._lblH_P_Sub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_P_Sub.Location = new System.Drawing.Point(602, 4);
            this._lblH_P_Sub.Name = "_lblH_P_Sub";
            this._lblH_P_Sub.Size = new System.Drawing.Size(74, 23);
            this._lblH_P_Sub.TabIndex = 4;
            this._lblH_P_Sub.Text = "Ngày gửi";
            // 
            // _lblH_P_Act
            // 
            this._lblH_P_Act.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_P_Act.Location = new System.Drawing.Point(830, 4);
            this._lblH_P_Act.Name = "_lblH_P_Act";
            this._lblH_P_Act.Size = new System.Drawing.Size(72, 23);
            this._lblH_P_Act.TabIndex = 5;
            this._lblH_P_Act.Text = "Hành động";
            // 
            // _pendingContainer
            // 
            this._pendingContainer.AutoScroll = true;
            this._pendingContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._pendingContainer.Location = new System.Drawing.Point(20, 85);
            this._pendingContainer.Name = "_pendingContainer";
            this._pendingContainer.Size = new System.Drawing.Size(974, 150);
            this._pendingContainer.TabIndex = 2;
            this._pendingContainer.WrapContents = false;
            // 
            // _cardAllShops
            // 
            this._cardAllShops.BackColor = System.Drawing.Color.Transparent;
            this._cardAllShops.BorderRadius = 12;
            this._cardAllShops.Controls.Add(this._lblAllShopsTitle);
            this._cardAllShops.Controls.Add(this._txtSearch);
            this._cardAllShops.Controls.Add(this._headerActive);
            this._cardAllShops.Controls.Add(this._activeContainer);
            this._cardAllShops.Controls.Add(this._comboStatus);
            this._cardAllShops.FillColor = System.Drawing.Color.White;
            this._cardAllShops.Location = new System.Drawing.Point(25, 360);
            this._cardAllShops.Name = "_cardAllShops";
            this._cardAllShops.ShadowDecoration.Depth = 5;
            this._cardAllShops.ShadowDecoration.Enabled = true;
            this._cardAllShops.Size = new System.Drawing.Size(997, 275);
            this._cardAllShops.TabIndex = 0;
            // 
            // _lblAllShopsTitle
            // 
            this._lblAllShopsTitle.AutoSize = true;
            this._lblAllShopsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblAllShopsTitle.Location = new System.Drawing.Point(20, 20);
            this._lblAllShopsTitle.Name = "_lblAllShopsTitle";
            this._lblAllShopsTitle.Size = new System.Drawing.Size(119, 20);
            this._lblAllShopsTitle.TabIndex = 0;
            this._lblAllShopsTitle.Text = "Tất cả cửa hàng";
            // 
            // _txtSearch
            // 
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(560, 11);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Tìm kiếm và nhấn Enter...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            this._txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // _headerActive
            // 
            this._headerActive.Controls.Add(this._lblH_A_Id);
            this._headerActive.Controls.Add(this._lblH_A_Name);
            this._headerActive.Controls.Add(this._lblH_A_Owner);
            this._headerActive.Controls.Add(this._lblH_A_Rate);
            this._headerActive.Controls.Add(this._lblH_A_Prod);
            this._headerActive.Controls.Add(this._lblH_A_Stat);
            this._headerActive.Controls.Add(this._lblH_A_Act);
            this._headerActive.Location = new System.Drawing.Point(20, 60);
            this._headerActive.Name = "_headerActive";
            this._headerActive.Size = new System.Drawing.Size(974, 30);
            this._headerActive.TabIndex = 2;
            // 
            // _lblH_A_Id
            // 
            this._lblH_A_Id.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Id.Location = new System.Drawing.Point(20, 4);
            this._lblH_A_Id.Name = "_lblH_A_Id";
            this._lblH_A_Id.Size = new System.Drawing.Size(73, 23);
            this._lblH_A_Id.TabIndex = 0;
            this._lblH_A_Id.Text = "Shop ID";
            // 
            // _lblH_A_Name
            // 
            this._lblH_A_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Name.Location = new System.Drawing.Point(118, 4);
            this._lblH_A_Name.Name = "_lblH_A_Name";
            this._lblH_A_Name.Size = new System.Drawing.Size(95, 23);
            this._lblH_A_Name.TabIndex = 1;
            this._lblH_A_Name.Text = "Tên cửa hàng";
            // 
            // _lblH_A_Owner
            // 
            this._lblH_A_Owner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Owner.Location = new System.Drawing.Point(300, 4);
            this._lblH_A_Owner.Name = "_lblH_A_Owner";
            this._lblH_A_Owner.Size = new System.Drawing.Size(92, 23);
            this._lblH_A_Owner.TabIndex = 2;
            this._lblH_A_Owner.Text = "Người sỡ hữu";
            // 
            // _lblH_A_Rate
            // 
            this._lblH_A_Rate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Rate.Location = new System.Drawing.Point(478, 4);
            this._lblH_A_Rate.Name = "_lblH_A_Rate";
            this._lblH_A_Rate.Size = new System.Drawing.Size(56, 23);
            this._lblH_A_Rate.TabIndex = 3;
            this._lblH_A_Rate.Text = "Đánh giá";
            // 
            // _lblH_A_Prod
            // 
            this._lblH_A_Prod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Prod.Location = new System.Drawing.Point(569, 4);
            this._lblH_A_Prod.Name = "_lblH_A_Prod";
            this._lblH_A_Prod.Size = new System.Drawing.Size(65, 23);
            this._lblH_A_Prod.TabIndex = 4;
            this._lblH_A_Prod.Text = "Sản phẩm";
            // 
            // _lblH_A_Stat
            // 
            this._lblH_A_Stat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Stat.Location = new System.Drawing.Point(713, 4);
            this._lblH_A_Stat.Name = "_lblH_A_Stat";
            this._lblH_A_Stat.Size = new System.Drawing.Size(77, 23);
            this._lblH_A_Stat.TabIndex = 5;
            this._lblH_A_Stat.Text = "Trạng thái";
            // 
            // _lblH_A_Act
            // 
            this._lblH_A_Act.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_A_Act.Location = new System.Drawing.Point(876, 4);
            this._lblH_A_Act.Name = "_lblH_A_Act";
            this._lblH_A_Act.Size = new System.Drawing.Size(83, 23);
            this._lblH_A_Act.TabIndex = 6;
            this._lblH_A_Act.Text = "Hành động";
            // 
            // _activeContainer
            // 
            this._activeContainer.AutoScroll = true;
            this._activeContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._activeContainer.Location = new System.Drawing.Point(20, 95);
            this._activeContainer.Name = "_activeContainer";
            this._activeContainer.Size = new System.Drawing.Size(974, 173);
            this._activeContainer.TabIndex = 3;
            this._activeContainer.WrapContents = false;
            // 
            // _comboStatus
            // 
            this._comboStatus.BackColor = System.Drawing.Color.Transparent;
            this._comboStatus.BorderRadius = 8;
            this._comboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboStatus.FocusedColor = System.Drawing.Color.Empty;
            this._comboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._comboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._comboStatus.ItemHeight = 30;
            this._comboStatus.Location = new System.Drawing.Point(829, 11);
            this._comboStatus.Name = "_comboStatus";
            this._comboStatus.Size = new System.Drawing.Size(150, 36);
            this._comboStatus.StartIndex = 0;
            this._comboStatus.TabIndex = 2;
            this._comboStatus.SelectedIndexChanged += new System.EventHandler(this._comboStatus_SelectedIndexChanged);
            // 
            // ShopsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1034, 640);
            this.Controls.Add(this._cardAllShops);
            this.Controls.Add(this._cardPending);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "ShopsForm";
            this.Text = "Shop Management";
            this.Load += new System.EventHandler(this.ShopsForm_Load);
            this._cardPending.ResumeLayout(false);
            this._cardPending.PerformLayout();
            this._headerPending.ResumeLayout(false);
            this._cardAllShops.ResumeLayout(false);
            this._cardAllShops.PerformLayout();
            this._headerActive.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _pageTitle;
        private System.Windows.Forms.Label _pageSub;

        // Pending Controls
        private Guna.UI2.WinForms.Guna2Panel _cardPending;
        private System.Windows.Forms.Label _lblPendingTitle;
        private System.Windows.Forms.FlowLayoutPanel _pendingContainer;
        private System.Windows.Forms.Panel _headerPending;
        private System.Windows.Forms.Label _lblH_P_Id, _lblH_P_Name, _lblH_P_Owner, _lblH_P_Email, _lblH_P_Sub, _lblH_P_Act;

        // Active Controls
        private Guna.UI2.WinForms.Guna2Panel _cardAllShops;
        private System.Windows.Forms.Label _lblAllShopsTitle;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox _comboStatus;
        private System.Windows.Forms.FlowLayoutPanel _activeContainer;
        private System.Windows.Forms.Panel _headerActive;
        private System.Windows.Forms.Label _lblH_A_Id, _lblH_A_Name, _lblH_A_Owner, _lblH_A_Rate, _lblH_A_Prod, _lblH_A_Stat, _lblH_A_Act;
    }
}