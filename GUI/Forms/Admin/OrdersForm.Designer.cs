namespace Skynet_Commerce.GUI.Forms
{
    partial class OrdersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._pageTitle = new System.Windows.Forms.Label();
            this._pageSub = new System.Windows.Forms.Label();
            this._cardMain = new Guna.UI2.WinForms.Guna2Panel();
            this._lblCardTitle = new System.Windows.Forms.Label();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this._pnlPageInfo = new System.Windows.Forms.FlowLayoutPanel();
            this._lblPageText = new System.Windows.Forms.Label();
            this._cboPageSelect = new Guna.UI2.WinForms.Guna2ComboBox();
            this._lblTotalPageText = new System.Windows.Forms.Label();
            this._pnlPagination = new System.Windows.Forms.FlowLayoutPanel();
            this._dgvOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this._cardMain.SuspendLayout();
            this._pnlPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // _pageTitle
            // 
            this._pageTitle.AutoSize = true;
            this._pageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._pageTitle.Location = new System.Drawing.Point(20, 20);
            this._pageTitle.Name = "_pageTitle";
            this._pageTitle.Size = new System.Drawing.Size(171, 25);
            this._pageTitle.TabIndex = 2;
            this._pageTitle.Text = "Quản lý đơn hàng";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(369, 19);
            this._pageSub.TabIndex = 1;
            this._pageSub.Text = "Theo dõi và quản lý tất cả các đơn đặt hàng trên hệ thống.";
            // 
            // _cardMain
            // 
            this._cardMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cardMain.BackColor = System.Drawing.Color.Transparent;
            this._cardMain.BorderRadius = 12;
            this._cardMain.Controls.Add(this._lblCardTitle);
            this._cardMain.Controls.Add(this._txtSearch);
            this._cardMain.Controls.Add(this._cboStatus);
            this._cardMain.Controls.Add(this._pnlPageInfo);
            this._cardMain.Controls.Add(this._pnlPagination);
            this._cardMain.Controls.Add(this._dgvOrders);
            this._cardMain.FillColor = System.Drawing.Color.White;
            this._cardMain.Location = new System.Drawing.Point(25, 90);
            this._cardMain.Name = "_cardMain";
            this._cardMain.ShadowDecoration.Depth = 5;
            this._cardMain.ShadowDecoration.Enabled = true;
            this._cardMain.Size = new System.Drawing.Size(1045, 608);
            this._cardMain.TabIndex = 0;
            // 
            // _lblCardTitle
            // 
            this._lblCardTitle.AutoSize = true;
            this._lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblCardTitle.Location = new System.Drawing.Point(25, 25);
            this._lblCardTitle.Name = "_lblCardTitle";
            this._lblCardTitle.Size = new System.Drawing.Size(121, 20);
            this._lblCardTitle.TabIndex = 0;
            this._lblCardTitle.Text = "Tất cả đơn hàng";
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(531, 20);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Tìm kiếm và Nhấn Enter...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            this._txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // _cboStatus
            // 
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.BackColor = System.Drawing.Color.Transparent;
            this._cboStatus.BorderRadius = 8;
            this._cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cboStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._cboStatus.ItemHeight = 30;
            this._cboStatus.Location = new System.Drawing.Point(809, 20);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(180, 36);
            this._cboStatus.TabIndex = 2;
            this._cboStatus.SelectedIndexChanged += new System.EventHandler(this._cboStatus_SelectedIndexChanged);
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
            this._cboPageSelect.FocusedColor = System.Drawing.Color.Empty;
            this._cboPageSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._cboPageSelect.ForeColor = System.Drawing.Color.Black;
            this._cboPageSelect.ItemHeight = 25;
            this._cboPageSelect.Location = new System.Drawing.Point(47, 3);
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
            this._lblTotalPageText.Location = new System.Drawing.Point(120, 8);
            this._lblTotalPageText.Margin = new System.Windows.Forms.Padding(0, 8, 20, 0);
            this._lblTotalPageText.Name = "_lblTotalPageText";
            this._lblTotalPageText.Size = new System.Drawing.Size(33, 19);
            this._lblTotalPageText.TabIndex = 2;
            this._lblTotalPageText.Text = "of 0";
            // 
            // _pnlPagination
            // 
            this._pnlPagination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlPagination.AutoSize = true;
            this._pnlPagination.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this._pnlPagination.Location = new System.Drawing.Point(1036, 560);
            this._pnlPagination.Name = "_pnlPagination";
            this._pnlPagination.Size = new System.Drawing.Size(0, 0);
            this._pnlPagination.TabIndex = 5;
            this._pnlPagination.WrapContents = false;
            // 
            // _dgvOrders
            // 
            this._dgvOrders.AllowUserToAddRows = false;
            this._dgvOrders.AllowUserToDeleteRows = false;
            this._dgvOrders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvOrders.ColumnHeadersHeight = 45;
            this._dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colBuyer,
            this.colShop,
            this.colItems,
            this.colAmount,
            this.colDate,
            this.colStatus,
            this.colAction});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvOrders.Location = new System.Drawing.Point(20, 80);
            this._dgvOrders.MultiSelect = false;
            this._dgvOrders.Name = "_dgvOrders";
            this._dgvOrders.ReadOnly = true;
            this._dgvOrders.RowHeadersVisible = false;
            this._dgvOrders.RowTemplate.Height = 55;
            this._dgvOrders.Size = new System.Drawing.Size(1005, 460);
            this._dgvOrders.TabIndex = 4;
            this._dgvOrders.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._dgvOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._dgvOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._dgvOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._dgvOrders.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._dgvOrders.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvOrders.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._dgvOrders.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dgvOrders.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._dgvOrders.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._dgvOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dgvOrders.ThemeStyle.HeaderStyle.Height = 45;
            this._dgvOrders.ThemeStyle.ReadOnly = true;
            this._dgvOrders.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvOrders.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvOrders.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dgvOrders.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvOrders.ThemeStyle.RowsStyle.Height = 55;
            this._dgvOrders.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvOrders.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colId
            // 
            this.colId.DataPropertyName = "OrderID";
            this.colId.FillWeight = 30F;
            this.colId.HeaderText = "MÃ ĐƠN";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colBuyer
            // 
            this.colBuyer.DataPropertyName = "BuyerDisplay";
            this.colBuyer.FillWeight = 60F;
            this.colBuyer.HeaderText = "NGƯỜI MUA";
            this.colBuyer.Name = "colBuyer";
            this.colBuyer.ReadOnly = true;
            // 
            // colShop
            // 
            this.colShop.DataPropertyName = "ShopName";
            this.colShop.FillWeight = 60F;
            this.colShop.HeaderText = "CỬA HÀNG";
            this.colShop.Name = "colShop";
            this.colShop.ReadOnly = true;
            // 
            // colItems
            // 
            this.colItems.DataPropertyName = "TotalItems";
            this.colItems.FillWeight = 40F;
            this.colItems.HeaderText = "SỐ LƯỢNG";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "AmountDisplay";
            this.colAmount.FillWeight = 50F;
            this.colAmount.HeaderText = "TỔNG TIỀN";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "DateDisplay";
            this.colDate.FillWeight = 50F;
            this.colDate.HeaderText = "NGÀY ĐẶT";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 50F;
            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.FillWeight = 30F;
            this.colAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAction.HeaderText = "THAO TÁC";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Text = "•••";
            this.colAction.UseColumnTextForButtonValue = true;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1066, 710);
            this.Controls.Add(this._cardMain);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "OrdersForm";
            this.Text = "Order Management";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this._cardMain.ResumeLayout(false);
            this._cardMain.PerformLayout();
            this._pnlPageInfo.ResumeLayout(false);
            this._pnlPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _pageTitle;
        private System.Windows.Forms.Label _pageSub;
        private Guna.UI2.WinForms.Guna2Panel _cardMain;
        private System.Windows.Forms.Label _lblCardTitle;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox _cboStatus;

        // New GridView Controls
        private Guna.UI2.WinForms.Guna2DataGridView _dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;

        //phân trang
        private System.Windows.Forms.FlowLayoutPanel _pnlPagination;
        private System.Windows.Forms.FlowLayoutPanel _pnlPageInfo;
        private System.Windows.Forms.Label _lblPageText;
        private Guna.UI2.WinForms.Guna2ComboBox _cboPageSelect;
        private System.Windows.Forms.Label _lblTotalPageText;
    }
}