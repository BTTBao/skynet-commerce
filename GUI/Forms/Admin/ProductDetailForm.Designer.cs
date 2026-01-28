namespace Skynet_Commerce.GUI.Forms
{
    partial class ProductDetailForm
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
            this._pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this._btnAction = new Guna.UI2.WinForms.Guna2Button();
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblTitle = new System.Windows.Forms.Label();
            this._tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this._tabGeneral = new System.Windows.Forms.TabPage();
            this.lblDesc = new System.Windows.Forms.Label();
            this._txtDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this._txtCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblShop = new System.Windows.Forms.Label();
            this._txtShop = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this._txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this._tabVariants = new System.Windows.Forms.TabPage();
            this._dgvVariants = new Guna.UI2.WinForms.Guna2DataGridView();
            this._tabImages = new System.Windows.Forms.TabPage();
            this._flowImages = new System.Windows.Forms.FlowLayoutPanel();
            this._pnlHeader.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._tabGeneral.SuspendLayout();
            this._tabVariants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvVariants)).BeginInit();
            this._tabImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlHeader
            // 
            this._pnlHeader.Controls.Add(this._btnAction);
            this._pnlHeader.Controls.Add(this._lblStatus);
            this._pnlHeader.Controls.Add(this._lblTitle);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.FillColor = System.Drawing.Color.WhiteSmoke;
            this._pnlHeader.Location = new System.Drawing.Point(0, 0);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.Size = new System.Drawing.Size(800, 60);
            this._pnlHeader.TabIndex = 0;
            // 
            // _btnAction
            // 
            this._btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAction.BorderRadius = 5;
            this._btnAction.FillColor = System.Drawing.Color.OrangeRed;
            this._btnAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnAction.ForeColor = System.Drawing.Color.White;
            this._btnAction.Location = new System.Drawing.Point(668, 12);
            this._btnAction.Name = "_btnAction";
            this._btnAction.Size = new System.Drawing.Size(120, 36);
            this._btnAction.TabIndex = 2;
            this._btnAction.Text = "Action";
            this._btnAction.Click += new System.EventHandler(this._btnAction_Click);
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.BackColor = System.Drawing.Color.Transparent;
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblStatus.Location = new System.Drawing.Point(16, 37);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(61, 19);
            this._lblStatus.TabIndex = 1;
            this._lblStatus.Text = "Status...";
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.BackColor = System.Drawing.Color.Transparent;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(12, 9);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(164, 25);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Chi tiết sản phẩm";
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabGeneral);
            this._tabControl.Controls.Add(this._tabVariants);
            this._tabControl.Controls.Add(this._tabImages);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.ItemSize = new System.Drawing.Size(180, 40);
            this._tabControl.Location = new System.Drawing.Point(0, 60);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(800, 540);
            this._tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this._tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this._tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this._tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this._tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this._tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this._tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this._tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this._tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this._tabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this._tabControl.TabIndex = 1;
            this._tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this._tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // _tabGeneral
            // 
            this._tabGeneral.BackColor = System.Drawing.Color.White;
            this._tabGeneral.Controls.Add(this.lblDesc);
            this._tabGeneral.Controls.Add(this._txtDesc);
            this._tabGeneral.Controls.Add(this.lblCategory);
            this._tabGeneral.Controls.Add(this._txtCategory);
            this._tabGeneral.Controls.Add(this.lblShop);
            this._tabGeneral.Controls.Add(this._txtShop);
            this._tabGeneral.Controls.Add(this.lblName);
            this._tabGeneral.Controls.Add(this._txtName);
            this._tabGeneral.Location = new System.Drawing.Point(4, 44);
            this._tabGeneral.Name = "_tabGeneral";
            this._tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this._tabGeneral.Size = new System.Drawing.Size(792, 492);
            this._tabGeneral.TabIndex = 0;
            this._tabGeneral.Text = "Thông tin chung";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesc.ForeColor = System.Drawing.Color.DimGray;
            this.lblDesc.Location = new System.Drawing.Point(20, 260);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(81, 15);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "Mô tả chi tiết";
            // 
            // _txtDesc
            // 
            this._txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this._txtDesc.BorderRadius = 5;
            this._txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtDesc.DefaultText = "";
            this._txtDesc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._txtDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._txtDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtDesc.ForeColor = System.Drawing.Color.Black;
            this._txtDesc.Location = new System.Drawing.Point(20, 285);
            this._txtDesc.Multiline = true;
            this._txtDesc.Name = "_txtDesc";
            this._txtDesc.PlaceholderText = "";
            this._txtDesc.ReadOnly = true;
            this._txtDesc.SelectedText = "";
            this._txtDesc.Size = new System.Drawing.Size(750, 190);
            this._txtDesc.TabIndex = 8;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.DimGray;
            this.lblCategory.Location = new System.Drawing.Point(20, 180);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 15);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Danh mục";
            // 
            // _txtCategory
            // 
            this._txtCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this._txtCategory.BorderRadius = 5;
            this._txtCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtCategory.DefaultText = "";
            this._txtCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._txtCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._txtCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtCategory.ForeColor = System.Drawing.Color.Black;
            this._txtCategory.Location = new System.Drawing.Point(20, 205);
            this._txtCategory.Name = "_txtCategory";
            this._txtCategory.PlaceholderText = "";
            this._txtCategory.ReadOnly = true;
            this._txtCategory.SelectedText = "";
            this._txtCategory.Size = new System.Drawing.Size(300, 40);
            this._txtCategory.TabIndex = 6;
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblShop.ForeColor = System.Drawing.Color.DimGray;
            this.lblShop.Location = new System.Drawing.Point(20, 100);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(127, 15);
            this.lblShop.TabIndex = 3;
            this.lblShop.Text = "Cửa hàng / Người bán";
            // 
            // _txtShop
            // 
            this._txtShop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this._txtShop.BorderRadius = 5;
            this._txtShop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtShop.DefaultText = "";
            this._txtShop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._txtShop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._txtShop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtShop.ForeColor = System.Drawing.Color.Black;
            this._txtShop.Location = new System.Drawing.Point(20, 125);
            this._txtShop.Name = "_txtShop";
            this._txtShop.PlaceholderText = "";
            this._txtShop.ReadOnly = true;
            this._txtShop.SelectedText = "";
            this._txtShop.Size = new System.Drawing.Size(500, 40);
            this._txtShop.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên sản phẩm";
            // 
            // _txtName
            // 
            this._txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this._txtName.BorderRadius = 5;
            this._txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtName.DefaultText = "";
            this._txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtName.ForeColor = System.Drawing.Color.Black;
            this._txtName.Location = new System.Drawing.Point(20, 45);
            this._txtName.Name = "_txtName";
            this._txtName.PlaceholderText = "";
            this._txtName.ReadOnly = true;
            this._txtName.SelectedText = "";
            this._txtName.Size = new System.Drawing.Size(500, 40);
            this._txtName.TabIndex = 2;
            // 
            // _tabVariants
            // 
            this._tabVariants.Controls.Add(this._dgvVariants);
            this._tabVariants.Location = new System.Drawing.Point(4, 44);
            this._tabVariants.Name = "_tabVariants";
            this._tabVariants.Padding = new System.Windows.Forms.Padding(3);
            this._tabVariants.Size = new System.Drawing.Size(792, 492);
            this._tabVariants.TabIndex = 1;
            this._tabVariants.Text = "Biến thể (Variants)";
            this._tabVariants.UseVisualStyleBackColor = true;
            // 
            // _dgvVariants
            // 
            this._dgvVariants.AllowUserToAddRows = false;
            this._dgvVariants.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this._dgvVariants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvVariants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvVariants.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvVariants.DefaultCellStyle = dataGridViewCellStyle6;
            this._dgvVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvVariants.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvVariants.Location = new System.Drawing.Point(3, 3);
            this._dgvVariants.Name = "_dgvVariants";
            this._dgvVariants.ReadOnly = true;
            this._dgvVariants.RowHeadersVisible = false;
            this._dgvVariants.RowTemplate.Height = 35;
            this._dgvVariants.Size = new System.Drawing.Size(786, 486);
            this._dgvVariants.TabIndex = 0;
            this._dgvVariants.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvVariants.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._dgvVariants.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._dgvVariants.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._dgvVariants.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._dgvVariants.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._dgvVariants.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvVariants.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._dgvVariants.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dgvVariants.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._dgvVariants.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._dgvVariants.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dgvVariants.ThemeStyle.HeaderStyle.Height = 40;
            this._dgvVariants.ThemeStyle.ReadOnly = true;
            this._dgvVariants.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvVariants.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvVariants.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._dgvVariants.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvVariants.ThemeStyle.RowsStyle.Height = 35;
            this._dgvVariants.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvVariants.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // _tabImages
            // 
            this._tabImages.Controls.Add(this._flowImages);
            this._tabImages.Location = new System.Drawing.Point(4, 44);
            this._tabImages.Name = "_tabImages";
            this._tabImages.Size = new System.Drawing.Size(792, 492);
            this._tabImages.TabIndex = 2;
            this._tabImages.Text = "Hình ảnh";
            this._tabImages.UseVisualStyleBackColor = true;
            // 
            // _flowImages
            // 
            this._flowImages.AutoScroll = true;
            this._flowImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowImages.Location = new System.Drawing.Point(0, 0);
            this._flowImages.Name = "_flowImages";
            this._flowImages.Padding = new System.Windows.Forms.Padding(10);
            this._flowImages.Size = new System.Drawing.Size(792, 492);
            this._flowImages.TabIndex = 0;
            // 
            // ProductDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._pnlHeader);
            this.Name = "ProductDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết sản phẩm";
            this._pnlHeader.ResumeLayout(false);
            this._pnlHeader.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._tabGeneral.ResumeLayout(false);
            this._tabGeneral.PerformLayout();
            this._tabVariants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvVariants)).EndInit();
            this._tabImages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel _pnlHeader;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblStatus;
        private Guna.UI2.WinForms.Guna2Button _btnAction;
        private Guna.UI2.WinForms.Guna2TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabGeneral;
        private System.Windows.Forms.TabPage _tabVariants;
        private System.Windows.Forms.TabPage _tabImages;
        private Guna.UI2.WinForms.Guna2DataGridView _dgvVariants;
        private System.Windows.Forms.FlowLayoutPanel _flowImages;

        // Expanded controls
        private System.Windows.Forms.Label lblName, lblShop, lblCategory, lblDesc;
        private Guna.UI2.WinForms.Guna2TextBox _txtName, _txtShop, _txtCategory, _txtDesc;
    }
}