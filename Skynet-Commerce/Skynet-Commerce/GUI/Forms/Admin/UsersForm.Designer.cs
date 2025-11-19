namespace Skynet_Commerce.GUI.Forms
{
    partial class UsersForm
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
            this._mainCard = new Guna.UI2.WinForms.Guna2Panel();
            this._userListContainer = new System.Windows.Forms.FlowLayoutPanel();
            this._panelListHeader = new System.Windows.Forms.Panel();
            this._labelH7 = new System.Windows.Forms.Label();
            this._labelH6 = new System.Windows.Forms.Label();
            this._labelH5 = new System.Windows.Forms.Label();
            this._labelH4 = new System.Windows.Forms.Label();
            this._labelH3 = new System.Windows.Forms.Label();
            this._labelH2 = new System.Windows.Forms.Label();
            this._labelH1 = new System.Windows.Forms.Label();
            this._cardHeaderLine = new System.Windows.Forms.Panel();
            this._comboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._lblAllUsers = new System.Windows.Forms.Label();
            this._mainCard.SuspendLayout();
            this._panelListHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pageTitle
            // 
            this._pageTitle.AutoSize = true;
            this._pageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._pageTitle.Location = new System.Drawing.Point(20, 20);
            this._pageTitle.Name = "_pageTitle";
            this._pageTitle.Size = new System.Drawing.Size(175, 25);
            this._pageTitle.TabIndex = 0;
            this._pageTitle.Text = "User Management";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(312, 19);
            this._pageSub.TabIndex = 1;
            this._pageSub.Text = "Manage and monitor all users in the marketplace.";
            // 
            // _mainCard
            // 
            this._mainCard.BackColor = System.Drawing.Color.Transparent;
            this._mainCard.BorderRadius = 12;
            this._mainCard.Controls.Add(this._userListContainer);
            this._mainCard.Controls.Add(this._panelListHeader);
            this._mainCard.Controls.Add(this._cardHeaderLine);
            this._mainCard.Controls.Add(this._comboRole);
            this._mainCard.Controls.Add(this._txtSearch);
            this._mainCard.Controls.Add(this._lblAllUsers);
            this._mainCard.FillColor = System.Drawing.Color.White;
            this._mainCard.Location = new System.Drawing.Point(25, 90);
            this._mainCard.Name = "_mainCard";
            this._mainCard.ShadowDecoration.Depth = 5;
            this._mainCard.ShadowDecoration.Enabled = true;
            this._mainCard.Size = new System.Drawing.Size(997, 538);
            this._mainCard.TabIndex = 2;
            // 
            // _userListContainer
            // 
            this._userListContainer.AutoScroll = true;
            this._userListContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._userListContainer.Location = new System.Drawing.Point(20, 125);
            this._userListContainer.Name = "_userListContainer";
            this._userListContainer.Size = new System.Drawing.Size(974, 400);
            this._userListContainer.TabIndex = 5;
            this._userListContainer.WrapContents = false;
            // 
            // _panelListHeader
            // 
            this._panelListHeader.Controls.Add(this._labelH7);
            this._panelListHeader.Controls.Add(this._labelH6);
            this._panelListHeader.Controls.Add(this._labelH5);
            this._panelListHeader.Controls.Add(this._labelH4);
            this._panelListHeader.Controls.Add(this._labelH3);
            this._panelListHeader.Controls.Add(this._labelH2);
            this._panelListHeader.Controls.Add(this._labelH1);
            this._panelListHeader.Location = new System.Drawing.Point(20, 80);
            this._panelListHeader.Name = "_panelListHeader";
            this._panelListHeader.Size = new System.Drawing.Size(974, 40);
            this._panelListHeader.TabIndex = 4;
            // 
            // _labelH7
            // 
            this._labelH7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH7.Location = new System.Drawing.Point(890, 10);
            this._labelH7.Name = "_labelH7";
            this._labelH7.Size = new System.Drawing.Size(100, 23);
            this._labelH7.TabIndex = 0;
            this._labelH7.Text = "Actions";
            // 
            // _labelH6
            // 
            this._labelH6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH6.Location = new System.Drawing.Point(720, 10);
            this._labelH6.Name = "_labelH6";
            this._labelH6.Size = new System.Drawing.Size(100, 23);
            this._labelH6.TabIndex = 1;
            this._labelH6.Text = "Status";
            // 
            // _labelH5
            // 
            this._labelH5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH5.Location = new System.Drawing.Point(600, 10);
            this._labelH5.Name = "_labelH5";
            this._labelH5.Size = new System.Drawing.Size(100, 23);
            this._labelH5.TabIndex = 2;
            this._labelH5.Text = "Role";
            // 
            // _labelH4
            // 
            this._labelH4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH4.Location = new System.Drawing.Point(450, 10);
            this._labelH4.Name = "_labelH4";
            this._labelH4.Size = new System.Drawing.Size(100, 23);
            this._labelH4.TabIndex = 3;
            this._labelH4.Text = "Phone";
            // 
            // _labelH3
            // 
            this._labelH3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH3.Location = new System.Drawing.Point(250, 10);
            this._labelH3.Name = "_labelH3";
            this._labelH3.Size = new System.Drawing.Size(100, 23);
            this._labelH3.TabIndex = 4;
            this._labelH3.Text = "Email";
            // 
            // _labelH2
            // 
            this._labelH2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH2.Location = new System.Drawing.Point(100, 10);
            this._labelH2.Name = "_labelH2";
            this._labelH2.Size = new System.Drawing.Size(100, 23);
            this._labelH2.TabIndex = 5;
            this._labelH2.Text = "Name";
            // 
            // _labelH1
            // 
            this._labelH1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelH1.Location = new System.Drawing.Point(20, 10);
            this._labelH1.Name = "_labelH1";
            this._labelH1.Size = new System.Drawing.Size(100, 23);
            this._labelH1.TabIndex = 6;
            this._labelH1.Text = "User ID";
            // 
            // _cardHeaderLine
            // 
            this._cardHeaderLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this._cardHeaderLine.Location = new System.Drawing.Point(0, 75);
            this._cardHeaderLine.Name = "_cardHeaderLine";
            this._cardHeaderLine.Size = new System.Drawing.Size(1200, 1);
            this._cardHeaderLine.TabIndex = 3;
            // 
            // _comboRole
            // 
            this._comboRole.BackColor = System.Drawing.Color.Transparent;
            this._comboRole.BorderRadius = 8;
            this._comboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboRole.FocusedColor = System.Drawing.Color.Empty;
            this._comboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._comboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._comboRole.ItemHeight = 30;
            this._comboRole.Items.AddRange(new object[] {
            "All Roles",
            "Buyer",
            "Seller",
            "Admin"});
            this._comboRole.Location = new System.Drawing.Point(836, 20);
            this._comboRole.Name = "_comboRole";
            this._comboRole.Size = new System.Drawing.Size(140, 36);
            this._comboRole.StartIndex = 0;
            this._comboRole.TabIndex = 2;
            // 
            // _txtSearch
            // 
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(565, 20);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Search users...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            // 
            // _lblAllUsers
            // 
            this._lblAllUsers.AutoSize = true;
            this._lblAllUsers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblAllUsers.Location = new System.Drawing.Point(25, 30);
            this._lblAllUsers.Name = "_lblAllUsers";
            this._lblAllUsers.Size = new System.Drawing.Size(71, 20);
            this._lblAllUsers.TabIndex = 0;
            this._lblAllUsers.Text = "All Users";
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1034, 640);
            this.Controls.Add(this._mainCard);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "UsersForm";
            this.Text = "Users Management";
            this._mainCard.ResumeLayout(false);
            this._mainCard.PerformLayout();
            this._panelListHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _pageTitle;
        private System.Windows.Forms.Label _pageSub;
        private Guna.UI2.WinForms.Guna2Panel _mainCard;
        private System.Windows.Forms.Label _lblAllUsers;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox _comboRole;
        private System.Windows.Forms.Panel _cardHeaderLine;
        private System.Windows.Forms.Panel _panelListHeader;
        private System.Windows.Forms.FlowLayoutPanel _userListContainer;
        private System.Windows.Forms.Label _labelH1, _labelH2, _labelH3, _labelH4, _labelH5, _labelH6, _labelH7;
    }
}