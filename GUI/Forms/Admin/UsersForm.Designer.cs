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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._pageTitle = new System.Windows.Forms.Label();
            this._pageSub = new System.Windows.Forms.Label();
            this._mainCard = new Guna.UI2.WinForms.Guna2Panel();
            this._btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this._dgvUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cardHeaderLine = new System.Windows.Forms.Panel();
            this._comboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._lblAllUsers = new System.Windows.Forms.Label();
            this._pnlPageInfo = new System.Windows.Forms.FlowLayoutPanel();
            this._lblPageText = new System.Windows.Forms.Label();
            this._cboPageSelect = new Guna.UI2.WinForms.Guna2ComboBox();
            this._lblTotalPageText = new System.Windows.Forms.Label();
            this._pnlPagination = new System.Windows.Forms.FlowLayoutPanel();
            this._btnView = new Guna.UI2.WinForms.Guna2Button();
            this._btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this._btnBan = new Guna.UI2.WinForms.Guna2Button();
            this._mainCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsers)).BeginInit();
            this._pnlPageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pageTitle
            // 
            this._pageTitle.AutoSize = true;
            this._pageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._pageTitle.Location = new System.Drawing.Point(20, 20);
            this._pageTitle.Name = "_pageTitle";
            this._pageTitle.Size = new System.Drawing.Size(192, 25);
            this._pageTitle.TabIndex = 0;
            this._pageTitle.Text = "Quản lý người dùng";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(345, 19);
            this._pageSub.TabIndex = 1;
            this._pageSub.Text = "Quản lý và giám sát tất cả người dùng trong hệ thống.";
            // 
            // _mainCard
            // 
            this._mainCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mainCard.BackColor = System.Drawing.Color.Transparent;
            this._mainCard.BorderRadius = 12;
            this._mainCard.Controls.Add(this._btnExportExcel);
            this._mainCard.Controls.Add(this._dgvUsers);
            this._mainCard.Controls.Add(this._cardHeaderLine);
            this._mainCard.Controls.Add(this._comboRole);
            this._mainCard.Controls.Add(this._txtSearch);
            this._mainCard.Controls.Add(this._lblAllUsers);
            this._mainCard.Controls.Add(this._pnlPageInfo);
            this._mainCard.Controls.Add(this._pnlPagination);
            this._mainCard.FillColor = System.Drawing.Color.White;
            this._mainCard.Location = new System.Drawing.Point(25, 90);
            this._mainCard.Name = "_mainCard";
            this._mainCard.ShadowDecoration.Depth = 5;
            this._mainCard.ShadowDecoration.Enabled = true;
            this._mainCard.Size = new System.Drawing.Size(1045, 608);
            this._mainCard.TabIndex = 2;
            // 
            // _btnExportExcel
            // 
            this._btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExportExcel.BorderRadius = 8;
            this._btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._btnExportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(114)))), ((int)(((byte)(71)))));
            this._btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnExportExcel.ForeColor = System.Drawing.Color.White;
            this._btnExportExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._btnExportExcel.Location = new System.Drawing.Point(493, 20);
            this._btnExportExcel.Name = "_btnExportExcel";
            this._btnExportExcel.Size = new System.Drawing.Size(120, 36);
            this._btnExportExcel.TabIndex = 5;
            this._btnExportExcel.Text = "Xuất Excel";
            this._btnExportExcel.Click += new System.EventHandler(this._btnExportExcel_Click);
            // 
            // _dgvUsers
            // 
            this._dgvUsers.AllowUserToAddRows = false;
            this._dgvUsers.AllowUserToDeleteRows = false;
            this._dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this._dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvUsers.ColumnHeadersHeight = 45;
            this._dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colEmail,
            this.colPhone,
            this.colRole,
            this.colStatus});
            this._dgvUsers.DefaultCellStyle = dataGridViewCellStyle6;
            this._dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvUsers.Location = new System.Drawing.Point(20, 82);
            this._dgvUsers.MultiSelect = false;
            this._dgvUsers.Name = "_dgvUsers";
            this._dgvUsers.ReadOnly = true;
            this._dgvUsers.RowHeadersVisible = false;
            this._dgvUsers.RowTemplate.Height = 55;
            this._dgvUsers.Size = new System.Drawing.Size(1016, 460);
            this._dgvUsers.TabIndex = 4;
            this._dgvUsers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._dgvUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._dgvUsers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._dgvUsers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvUsers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._dgvUsers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dgvUsers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._dgvUsers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._dgvUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dgvUsers.ThemeStyle.HeaderStyle.Height = 45;
            this._dgvUsers.ThemeStyle.ReadOnly = true;
            this._dgvUsers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvUsers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvUsers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dgvUsers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvUsers.ThemeStyle.RowsStyle.Height = 55;
            this._dgvUsers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvUsers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvUsers_CellFormatting);
            this._dgvUsers.SelectionChanged += new System.EventHandler(this._dgvUsers_SelectionChanged);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "FullName";
            this.colName.FillWeight = 50F;
            this.colName.HeaderText = "HỌ VÀ TÊN";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.FillWeight = 60F;
            this.colEmail.HeaderText = "EMAIL";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.FillWeight = 35F;
            this.colPhone.HeaderText = "SĐT";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.DataPropertyName = "RoleName";
            this.colRole.FillWeight = 30F;
            this.colRole.HeaderText = "VAI TRÒ";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.colStatus.FillWeight = 30F;
            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
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
            this._comboRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._comboRole.BackColor = System.Drawing.Color.Transparent;
            this._comboRole.BorderRadius = 8;
            this._comboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboRole.FocusedColor = System.Drawing.Color.Empty;
            this._comboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._comboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._comboRole.ItemHeight = 30;
            this._comboRole.Location = new System.Drawing.Point(891, 20);
            this._comboRole.Name = "_comboRole";
            this._comboRole.Size = new System.Drawing.Size(140, 36);
            this._comboRole.TabIndex = 2;
            this._comboRole.SelectedIndexChanged += new System.EventHandler(this._comboRole_SelectedIndexChanged);
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(626, 20);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Tìm kiếm và nhấn Enter...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            this._txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // _lblAllUsers
            // 
            this._lblAllUsers.AutoSize = true;
            this._lblAllUsers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblAllUsers.Location = new System.Drawing.Point(25, 30);
            this._lblAllUsers.Name = "_lblAllUsers";
            this._lblAllUsers.Size = new System.Drawing.Size(136, 20);
            this._lblAllUsers.TabIndex = 0;
            this._lblAllUsers.Text = "Tất cả người dùng";
            // 
            // _pnlPageInfo
            // 
            this._pnlPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlPageInfo.AutoSize = true;
            this._pnlPageInfo.BackColor = System.Drawing.Color.Transparent;
            this._pnlPageInfo.Controls.Add(this._lblPageText);
            this._pnlPageInfo.Controls.Add(this._cboPageSelect);
            this._pnlPageInfo.Controls.Add(this._lblTotalPageText);
            this._pnlPageInfo.Location = new System.Drawing.Point(300, 560);
            this._pnlPageInfo.Name = "_pnlPageInfo";
            this._pnlPageInfo.Size = new System.Drawing.Size(200, 40);
            this._pnlPageInfo.TabIndex = 6;
            this._pnlPageInfo.WrapContents = false;
            // 
            // _lblPageText
            // 
            this._lblPageText.AutoSize = true;
            this._lblPageText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblPageText.ForeColor = System.Drawing.Color.DimGray;
            this._lblPageText.Location = new System.Drawing.Point(0, 8);
            this._lblPageText.Margin = new System.Windows.Forms.Padding(0, 8, 5, 0);
            this._lblPageText.Name = "_lblPageText";
            this._lblPageText.Size = new System.Drawing.Size(39, 19);
            this._lblPageText.TabIndex = 0;
            this._lblPageText.Text = "Page";
            // 
            // _cboPageSelect
            // 
            this._cboPageSelect.BackColor = System.Drawing.Color.Transparent;
            this._cboPageSelect.BorderColor = System.Drawing.Color.LightGray;
            this._cboPageSelect.BorderRadius = 6;
            this._cboPageSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboPageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboPageSelect.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cboPageSelect.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cboPageSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._cboPageSelect.ForeColor = System.Drawing.Color.Black;
            this._cboPageSelect.ItemHeight = 25;
            this._cboPageSelect.Location = new System.Drawing.Point(47, 3);
            this._cboPageSelect.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this._cboPageSelect.Name = "_cboPageSelect";
            this._cboPageSelect.Size = new System.Drawing.Size(70, 31);
            this._cboPageSelect.TabIndex = 1;
            this._cboPageSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _lblTotalPageText
            // 
            this._lblTotalPageText.AutoSize = true;
            this._lblTotalPageText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblTotalPageText.ForeColor = System.Drawing.Color.DimGray;
            this._lblTotalPageText.Location = new System.Drawing.Point(122, 8);
            this._lblTotalPageText.Margin = new System.Windows.Forms.Padding(0, 8, 20, 0);
            this._lblTotalPageText.Name = "_lblTotalPageText";
            this._lblTotalPageText.Size = new System.Drawing.Size(41, 19);
            this._lblTotalPageText.TabIndex = 2;
            this._lblTotalPageText.Text = "of 10";
            // 
            // _pnlPagination
            // 
            this._pnlPagination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlPagination.AutoSize = true;
            this._pnlPagination.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this._pnlPagination.Location = new System.Drawing.Point(1036, 595);
            this._pnlPagination.Name = "_pnlPagination";
            this._pnlPagination.Size = new System.Drawing.Size(0, 0);
            this._pnlPagination.TabIndex = 5;
            this._pnlPagination.WrapContents = false;
            // 
            // _btnView
            // 
            this._btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnView.BorderRadius = 8;
            this._btnView.Enabled = false;
            this._btnView.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this._btnView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnView.ForeColor = System.Drawing.Color.White;
            this._btnView.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._btnView.Location = new System.Drawing.Point(711, 33);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(100, 36);
            this._btnView.TabIndex = 6;
            this._btnView.Text = "Xem";
            this._btnView.Click += new System.EventHandler(this._btnView_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEdit.BorderRadius = 8;
            this._btnEdit.Enabled = false;
            this._btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this._btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnEdit.ForeColor = System.Drawing.Color.White;
            this._btnEdit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._btnEdit.Location = new System.Drawing.Point(832, 33);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(100, 36);
            this._btnEdit.TabIndex = 7;
            this._btnEdit.Text = "Sửa";
            this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
            // 
            // _btnBan
            // 
            this._btnBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBan.BorderRadius = 8;
            this._btnBan.Enabled = false;
            this._btnBan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this._btnBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnBan.ForeColor = System.Drawing.Color.White;
            this._btnBan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._btnBan.Location = new System.Drawing.Point(953, 33);
            this._btnBan.Name = "_btnBan";
            this._btnBan.Size = new System.Drawing.Size(100, 36);
            this._btnBan.TabIndex = 8;
            this._btnBan.Text = "Khoá";
            this._btnBan.Click += new System.EventHandler(this._btnBan_Click);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1066, 710);
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._mainCard);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._btnBan);
            this.Controls.Add(this._pageTitle);
            this.Name = "UsersForm";
            this.Text = "Users Management";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this._mainCard.ResumeLayout(false);
            this._mainCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsers)).EndInit();
            this._pnlPageInfo.ResumeLayout(false);
            this._pnlPageInfo.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2Button _btnExportExcel;

        // --- KHAI BÁO GRIDVIEW VÀ CÁC CỘT TẠI ĐÂY ---
        private Guna.UI2.WinForms.Guna2DataGridView _dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.FlowLayoutPanel _pnlPagination; // phân trang
        private System.Windows.Forms.FlowLayoutPanel _pnlPageInfo;
        private System.Windows.Forms.Label _lblPageText;
        private Guna.UI2.WinForms.Guna2ComboBox _cboPageSelect;
        private System.Windows.Forms.Label _lblTotalPageText;
        private Guna.UI2.WinForms.Guna2Button _btnView;
        private Guna.UI2.WinForms.Guna2Button _btnEdit;
        private Guna.UI2.WinForms.Guna2Button _btnBan;
    }
}