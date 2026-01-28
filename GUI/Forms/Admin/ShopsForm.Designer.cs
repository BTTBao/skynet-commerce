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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._lblTitle = new System.Windows.Forms.Label();
            this._mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._comboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this._dgvActive = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colA_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_Prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this._pnlPageInfo = new System.Windows.Forms.FlowLayoutPanel();
            this._lblPageText = new System.Windows.Forms.Label();
            this._cboPageSelect = new Guna.UI2.WinForms.Guna2ComboBox();
            this._lblTotalPageText = new System.Windows.Forms.Label();
            this._pnlPagination = new System.Windows.Forms.FlowLayoutPanel();
            this._mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvActive)).BeginInit();
            this._pnlPageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(20, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(235, 25);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Danh Sách Các Cửa Hàng";
            // 
            // _mainPanel
            // 
            this._mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mainPanel.BackColor = System.Drawing.Color.Transparent;
            this._mainPanel.BorderRadius = 12;
            this._mainPanel.Controls.Add(this._txtSearch);
            this._mainPanel.Controls.Add(this._comboStatus);
            this._mainPanel.Controls.Add(this._dgvActive);
            this._mainPanel.Controls.Add(this._pnlPageInfo);
            this._mainPanel.Controls.Add(this._pnlPagination);
            this._mainPanel.FillColor = System.Drawing.Color.White;
            this._mainPanel.Location = new System.Drawing.Point(25, 60);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.ShadowDecoration.Depth = 5;
            this._mainPanel.ShadowDecoration.Enabled = true;
            this._mainPanel.Size = new System.Drawing.Size(1015, 620);
            this._mainPanel.TabIndex = 1;
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(530, 20);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Tìm kiếm và nhấn Enter...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            this._txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // _comboStatus
            // 
            this._comboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._comboStatus.BackColor = System.Drawing.Color.Transparent;
            this._comboStatus.BorderRadius = 8;
            this._comboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboStatus.FocusedColor = System.Drawing.Color.Empty;
            this._comboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._comboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._comboStatus.ItemHeight = 30;
            this._comboStatus.Location = new System.Drawing.Point(806, 20);
            this._comboStatus.Name = "_comboStatus";
            this._comboStatus.Size = new System.Drawing.Size(180, 36);
            this._comboStatus.TabIndex = 2;
            this._comboStatus.SelectedIndexChanged += new System.EventHandler(this._comboStatus_SelectedIndexChanged);
            // 
            // _dgvActive
            // 
            this._dgvActive.AllowUserToAddRows = false;
            this._dgvActive.AllowUserToDeleteRows = false;
            this._dgvActive.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._dgvActive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvActive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this._dgvActive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvActive.ColumnHeadersHeight = 45;
            this._dgvActive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colA_Name,
            this.colA_Owner,
            this.colA_Rate,
            this.colA_Prod,
            this.colA_Status,
            this.colA_Action});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvActive.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvActive.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvActive.Location = new System.Drawing.Point(20, 70);
            this._dgvActive.MultiSelect = false;
            this._dgvActive.Name = "_dgvActive";
            this._dgvActive.ReadOnly = true;
            this._dgvActive.RowHeadersVisible = false;
            this._dgvActive.RowTemplate.Height = 55;
            this._dgvActive.Size = new System.Drawing.Size(975, 480);
            this._dgvActive.TabIndex = 3;
            this._dgvActive.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvActive.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._dgvActive.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._dgvActive.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._dgvActive.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._dgvActive.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._dgvActive.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvActive.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._dgvActive.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dgvActive.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dgvActive.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._dgvActive.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dgvActive.ThemeStyle.HeaderStyle.Height = 45;
            this._dgvActive.ThemeStyle.ReadOnly = true;
            this._dgvActive.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvActive.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvActive.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dgvActive.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvActive.ThemeStyle.RowsStyle.Height = 55;
            this._dgvActive.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvActive.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvActive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvActive_CellContentClick);
            this._dgvActive.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvActive_CellFormatting);
            // 
            // colA_Name
            // 
            this.colA_Name.DataPropertyName = "ShopName";
            this.colA_Name.HeaderText = "TÊN SHOP";
            this.colA_Name.Name = "colA_Name";
            this.colA_Name.ReadOnly = true;
            // 
            // colA_Owner
            // 
            this.colA_Owner.DataPropertyName = "OwnerName";
            this.colA_Owner.HeaderText = "CHỦ SỞ HỮU";
            this.colA_Owner.Name = "colA_Owner";
            this.colA_Owner.ReadOnly = true;
            // 
            // colA_Rate
            // 
            this.colA_Rate.DataPropertyName = "RatingAverage";
            this.colA_Rate.FillWeight = 50F;
            this.colA_Rate.HeaderText = "ĐÁNH GIÁ";
            this.colA_Rate.Name = "colA_Rate";
            this.colA_Rate.ReadOnly = true;
            // 
            // colA_Prod
            // 
            this.colA_Prod.DataPropertyName = "StockQuantity";
            this.colA_Prod.FillWeight = 50F;
            this.colA_Prod.HeaderText = "SẢN PHẨM";
            this.colA_Prod.Name = "colA_Prod";
            this.colA_Prod.ReadOnly = true;
            // 
            // colA_Status
            // 
            this.colA_Status.DataPropertyName = "Status";
            this.colA_Status.FillWeight = 60F;
            this.colA_Status.HeaderText = "TRẠNG THÁI";
            this.colA_Status.Name = "colA_Status";
            this.colA_Status.ReadOnly = true;
            // 
            // colA_Action
            // 
            this.colA_Action.FillWeight = 40F;
            this.colA_Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_Action.HeaderText = "THAO TÁC";
            this.colA_Action.Name = "colA_Action";
            this.colA_Action.ReadOnly = true;
            this.colA_Action.Text = "•••";
            this.colA_Action.UseColumnTextForButtonValue = true;
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
            this._pnlPageInfo.Size = new System.Drawing.Size(200, 42);
            this._pnlPageInfo.TabIndex = 6;
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
            this._cboPageSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._cboPageSelect.ItemHeight = 30;
            this._cboPageSelect.Location = new System.Drawing.Point(47, 3);
            this._cboPageSelect.Name = "_cboPageSelect";
            this._cboPageSelect.Size = new System.Drawing.Size(70, 36);
            this._cboPageSelect.TabIndex = 1;
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
            this._pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this._pnlPagination.Location = new System.Drawing.Point(500, 560);
            this._pnlPagination.Name = "_pnlPagination";
            this._pnlPagination.Size = new System.Drawing.Size(200, 40);
            this._pnlPagination.TabIndex = 5;
            this._pnlPagination.WrapContents = false;
            // 
            // ShopsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1066, 710);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopsForm";
            this.Text = "ShopListForm";
            this.Load += new System.EventHandler(this.ShopsForm_Load);
            this._mainPanel.ResumeLayout(false);
            this._mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvActive)).EndInit();
            this._pnlPageInfo.ResumeLayout(false);
            this._pnlPageInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblTitle;
        private Guna.UI2.WinForms.Guna2Panel _mainPanel;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox _comboStatus;
        private Guna.UI2.WinForms.Guna2DataGridView _dgvActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_Prod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_Status;
        private System.Windows.Forms.DataGridViewButtonColumn colA_Action;
        private System.Windows.Forms.FlowLayoutPanel _pnlPageInfo;
        private System.Windows.Forms.Label _lblPageText;
        private Guna.UI2.WinForms.Guna2ComboBox _cboPageSelect;
        private System.Windows.Forms.Label _lblTotalPageText;
        private System.Windows.Forms.FlowLayoutPanel _pnlPagination;
    }
}