namespace Skynet_Commerce.GUI.Forms
{
    partial class ProductsForm
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
            this._comboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this._pnlPageInfo = new System.Windows.Forms.FlowLayoutPanel();
            this._lblPageText = new System.Windows.Forms.Label();
            this._cboPageSelect = new Guna.UI2.WinForms.Guna2ComboBox();
            this._lblTotalPageText = new System.Windows.Forms.Label();
            this._pnlPagination = new System.Windows.Forms.FlowLayoutPanel();
            this._dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this._cardMain.SuspendLayout();
            this._pnlPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // _pageTitle
            // 
            this._pageTitle.AutoSize = true;
            this._pageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._pageTitle.Location = new System.Drawing.Point(20, 20);
            this._pageTitle.Name = "_pageTitle";
            this._pageTitle.Size = new System.Drawing.Size(170, 25);
            this._pageTitle.TabIndex = 2;
            this._pageTitle.Text = "Quản lý sản phẩm";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(274, 19);
            this._pageSub.TabIndex = 1;
            this._pageSub.Text = "Quản lý tất cả các sản phẩm trên hệ thống.";
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
            this._cardMain.Controls.Add(this._comboCategory);
            this._cardMain.Controls.Add(this._pnlPageInfo);
            this._cardMain.Controls.Add(this._pnlPagination);
            this._cardMain.Controls.Add(this._dgvProducts);
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
            this._lblCardTitle.Size = new System.Drawing.Size(123, 20);
            this._lblCardTitle.TabIndex = 0;
            this._lblCardTitle.Text = "Tất cả sản phẩm";
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(558, 18);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Tìm kiếm và nhấn Enter...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            this._txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // _comboCategory
            // 
            this._comboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._comboCategory.BackColor = System.Drawing.Color.Transparent;
            this._comboCategory.BorderRadius = 8;
            this._comboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboCategory.FocusedColor = System.Drawing.Color.Empty;
            this._comboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._comboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._comboCategory.ItemHeight = 30;
            this._comboCategory.Location = new System.Drawing.Point(827, 18);
            this._comboCategory.Name = "_comboCategory";
            this._comboCategory.Size = new System.Drawing.Size(190, 36);
            this._comboCategory.TabIndex = 2;
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
            // _dgvProducts
            // 
            this._dgvProducts.AllowUserToAddRows = false;
            this._dgvProducts.AllowUserToDeleteRows = false;
            this._dgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this._dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvProducts.ColumnHeadersHeight = 45;
            this._dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colShop,
            this.colCategory,
            this.colPrice,
            this.colStock,
            this.colStatus,
            this.colAction});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvProducts.Location = new System.Drawing.Point(20, 80);
            this._dgvProducts.MultiSelect = false;
            this._dgvProducts.Name = "_dgvProducts";
            this._dgvProducts.ReadOnly = true;
            this._dgvProducts.RowHeadersVisible = false;
            this._dgvProducts.RowTemplate.Height = 55;
            this._dgvProducts.Size = new System.Drawing.Size(1005, 460);
            this._dgvProducts.TabIndex = 4;
            this._dgvProducts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvProducts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._dgvProducts.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._dgvProducts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._dgvProducts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvProducts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._dgvProducts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dgvProducts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._dgvProducts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._dgvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dgvProducts.ThemeStyle.HeaderStyle.Height = 45;
            this._dgvProducts.ThemeStyle.ReadOnly = true;
            this._dgvProducts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvProducts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvProducts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dgvProducts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvProducts.ThemeStyle.RowsStyle.Height = 55;
            this._dgvProducts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvProducts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ProductName";
            this.colName.FillWeight = 80F;
            this.colName.HeaderText = "TÊN SẢN PHẨM";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colShop
            // 
            this.colShop.DataPropertyName = "ShopName";
            this.colShop.FillWeight = 50F;
            this.colShop.HeaderText = "CỬA HÀNG";
            this.colShop.Name = "colShop";
            this.colShop.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "CategoryName";
            this.colCategory.FillWeight = 40F;
            this.colCategory.HeaderText = "DANH MỤC";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.FillWeight = 40F;
            this.colPrice.HeaderText = "GIÁ";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "StockQuantity";
            this.colStock.FillWeight = 30F;
            this.colStock.HeaderText = "KHO";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 40F;
            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.FillWeight = 25F;
            this.colAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAction.HeaderText = "THAO TÁC";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Text = "•••";
            this.colAction.UseColumnTextForButtonValue = true;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1066, 710);
            this.Controls.Add(this._cardMain);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "ProductsForm";
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this._cardMain.ResumeLayout(false);
            this._cardMain.PerformLayout();
            this._pnlPageInfo.ResumeLayout(false);
            this._pnlPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _pageTitle;
        private System.Windows.Forms.Label _pageSub;
        private Guna.UI2.WinForms.Guna2Panel _cardMain;
        private System.Windows.Forms.Label _lblCardTitle;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox _comboCategory;

        // New GridView Controls
        private Guna.UI2.WinForms.Guna2DataGridView _dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;

        // phân trang
        private System.Windows.Forms.FlowLayoutPanel _pnlPagination;
        private System.Windows.Forms.FlowLayoutPanel _pnlPageInfo;
        private System.Windows.Forms.Label _lblPageText;
        private Guna.UI2.WinForms.Guna2ComboBox _cboPageSelect;
        private System.Windows.Forms.Label _lblTotalPageText;
    }
}