namespace Skynet_Commerce.GUI.Forms
{
    partial class FraudDetectionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlRisk = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabUserRisk = new System.Windows.Forms.TabPage();
            this.gridUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.cboRiskLevel = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.grpAction = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.btnLockAccount = new Guna.UI2.WinForms.Guna2Button();
            this.tabShopRisk = new System.Windows.Forms.TabPage();
            this.gridShops = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpShopAction = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblSelectedShop = new System.Windows.Forms.Label();
            this.btnLockShop = new Guna.UI2.WinForms.Guna2Button();
            this.tabCloneRisk = new System.Windows.Forms.TabPage();
            this.gridClones = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabControlRisk.SuspendLayout();
            this.tabUserRisk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.tabShopRisk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShops)).BeginInit();
            this.grpShopAction.SuspendLayout();
            this.tabCloneRisk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClones)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlRisk
            // 
            this.tabControlRisk.Controls.Add(this.tabUserRisk);
            this.tabControlRisk.Controls.Add(this.tabShopRisk);
            this.tabControlRisk.Controls.Add(this.tabCloneRisk);
            this.tabControlRisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlRisk.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlRisk.Location = new System.Drawing.Point(0, 0);
            this.tabControlRisk.Name = "tabControlRisk";
            this.tabControlRisk.SelectedIndex = 0;
            this.tabControlRisk.Size = new System.Drawing.Size(1000, 600);
            this.tabControlRisk.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlRisk.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.tabControlRisk.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlRisk.TabButtonHoverState.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tabControlRisk.TabButtonHoverState.InnerColor = System.Drawing.Color.RoyalBlue;
            this.tabControlRisk.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlRisk.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tabControlRisk.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlRisk.TabButtonIdleState.ForeColor = System.Drawing.Color.DimGray;
            this.tabControlRisk.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tabControlRisk.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlRisk.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tabControlRisk.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlRisk.TabButtonSelectedState.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tabControlRisk.TabButtonSelectedState.InnerColor = System.Drawing.Color.RoyalBlue;
            this.tabControlRisk.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControlRisk.TabIndex = 0;
            this.tabControlRisk.TabMenuBackColor = System.Drawing.Color.White;
            this.tabControlRisk.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabUserRisk
            // 
            this.tabUserRisk.Controls.Add(this.gridUsers);
            this.tabUserRisk.Controls.Add(this.pnlFilter);
            this.tabUserRisk.Controls.Add(this.grpAction);
            this.tabUserRisk.Location = new System.Drawing.Point(4, 44);
            this.tabUserRisk.Name = "tabUserRisk";
            this.tabUserRisk.Size = new System.Drawing.Size(992, 552);
            this.tabUserRisk.TabIndex = 0;
            this.tabUserRisk.Text = "🚨 User Bom Hàng";
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridUsers.Location = new System.Drawing.Point(0, 60);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.ReadOnly = true;
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.Size = new System.Drawing.Size(992, 362);
            this.gridUsers.TabIndex = 0;
            this.gridUsers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridUsers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridUsers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridUsers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridUsers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridUsers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridUsers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUsers.ThemeStyle.HeaderStyle.Height = 23;
            this.gridUsers.ThemeStyle.ReadOnly = true;
            this.gridUsers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridUsers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridUsers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridUsers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridUsers.ThemeStyle.RowsStyle.Height = 22;
            this.gridUsers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridUsers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cboRiskLevel);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.lblFilterTitle);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(992, 60);
            this.pnlFilter.TabIndex = 1;
            // 
            // cboRiskLevel
            // 
            this.cboRiskLevel.BackColor = System.Drawing.Color.Transparent;
            this.cboRiskLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRiskLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRiskLevel.FocusedColor = System.Drawing.Color.Empty;
            this.cboRiskLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRiskLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboRiskLevel.ItemHeight = 30;
            this.cboRiskLevel.Items.AddRange(new object[] {
            "Tỷ lệ hủy > 30%",
            "Tỷ lệ hủy > 50%",
            "Tỷ lệ hủy > 70%"});
            this.cboRiskLevel.Location = new System.Drawing.Point(120, 12);
            this.cboRiskLevel.Name = "cboRiskLevel";
            this.cboRiskLevel.Size = new System.Drawing.Size(200, 36);
            this.cboRiskLevel.StartIndex = 1;
            this.cboRiskLevel.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.BorderRadius = 5;
            this.btnFilter.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(340, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 36);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Lọc dữ liệu";
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Location = new System.Drawing.Point(20, 22);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(73, 13);
            this.lblFilterTitle.TabIndex = 2;
            this.lblFilterTitle.Text = "Mức độ rủi ro:";
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.lblSelectedUser);
            this.grpAction.Controls.Add(this.btnLockAccount);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpAction.Location = new System.Drawing.Point(0, 422);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(992, 130);
            this.grpAction.TabIndex = 2;
            this.grpAction.Text = "Xử lý User";
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Location = new System.Drawing.Point(20, 51);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(115, 15);
            this.lblSelectedUser.TabIndex = 0;
            this.lblSelectedUser.Text = "Chọn User để xử lý...";
            // 
            // btnLockAccount
            // 
            this.btnLockAccount.BorderRadius = 5;
            this.btnLockAccount.Enabled = false;
            this.btnLockAccount.FillColor = System.Drawing.Color.Firebrick;
            this.btnLockAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLockAccount.ForeColor = System.Drawing.Color.White;
            this.btnLockAccount.Location = new System.Drawing.Point(23, 86);
            this.btnLockAccount.Name = "btnLockAccount";
            this.btnLockAccount.Size = new System.Drawing.Size(150, 36);
            this.btnLockAccount.TabIndex = 1;
            this.btnLockAccount.Text = "KHÓA TÀI KHOẢN";
            // 
            // tabShopRisk
            // 
            this.tabShopRisk.Controls.Add(this.gridShops);
            this.tabShopRisk.Controls.Add(this.grpShopAction);
            this.tabShopRisk.Location = new System.Drawing.Point(4, 44);
            this.tabShopRisk.Name = "tabShopRisk";
            this.tabShopRisk.Size = new System.Drawing.Size(992, 552);
            this.tabShopRisk.TabIndex = 1;
            this.tabShopRisk.Text = "🏪 Shop Buff Ảo";
            // 
            // gridShops
            // 
            this.gridShops.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.gridShops.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridShops.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridShops.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridShops.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridShops.Location = new System.Drawing.Point(0, 0);
            this.gridShops.Name = "gridShops";
            this.gridShops.ReadOnly = true;
            this.gridShops.RowHeadersVisible = false;
            this.gridShops.Size = new System.Drawing.Size(992, 428);
            this.gridShops.TabIndex = 0;
            this.gridShops.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridShops.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridShops.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridShops.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridShops.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridShops.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridShops.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridShops.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridShops.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridShops.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridShops.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridShops.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridShops.ThemeStyle.HeaderStyle.Height = 23;
            this.gridShops.ThemeStyle.ReadOnly = true;
            this.gridShops.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridShops.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridShops.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridShops.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridShops.ThemeStyle.RowsStyle.Height = 22;
            this.gridShops.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridShops.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // grpShopAction
            // 
            this.grpShopAction.Controls.Add(this.lblSelectedShop);
            this.grpShopAction.Controls.Add(this.btnLockShop);
            this.grpShopAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpShopAction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpShopAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpShopAction.Location = new System.Drawing.Point(0, 428);
            this.grpShopAction.Name = "grpShopAction";
            this.grpShopAction.Size = new System.Drawing.Size(992, 124);
            this.grpShopAction.TabIndex = 1;
            this.grpShopAction.Text = "Xử lý Shop";
            // 
            // lblSelectedShop
            // 
            this.lblSelectedShop.AutoSize = true;
            this.lblSelectedShop.Location = new System.Drawing.Point(20, 50);
            this.lblSelectedShop.Name = "lblSelectedShop";
            this.lblSelectedShop.Size = new System.Drawing.Size(119, 15);
            this.lblSelectedShop.TabIndex = 0;
            this.lblSelectedShop.Text = "Chọn Shop để xử lý...";
            // 
            // btnLockShop
            // 
            this.btnLockShop.BorderRadius = 5;
            this.btnLockShop.Enabled = false;
            this.btnLockShop.FillColor = System.Drawing.Color.Firebrick;
            this.btnLockShop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLockShop.ForeColor = System.Drawing.Color.White;
            this.btnLockShop.Location = new System.Drawing.Point(23, 80);
            this.btnLockShop.Name = "btnLockShop";
            this.btnLockShop.Size = new System.Drawing.Size(150, 36);
            this.btnLockShop.TabIndex = 1;
            this.btnLockShop.Text = "KHÓA SHOP";
            // 
            // tabCloneRisk
            // 
            this.tabCloneRisk.Controls.Add(this.gridClones);
            this.tabCloneRisk.Location = new System.Drawing.Point(4, 44);
            this.tabCloneRisk.Name = "tabCloneRisk";
            this.tabCloneRisk.Size = new System.Drawing.Size(992, 552);
            this.tabCloneRisk.TabIndex = 2;
            this.tabCloneRisk.Text = "👥 Tài khoản Clone";
            // 
            // gridClones
            // 
            this.gridClones.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.gridClones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridClones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridClones.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridClones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridClones.Location = new System.Drawing.Point(0, 0);
            this.gridClones.Name = "gridClones";
            this.gridClones.ReadOnly = true;
            this.gridClones.RowHeadersVisible = false;
            this.gridClones.Size = new System.Drawing.Size(992, 552);
            this.gridClones.TabIndex = 0;
            this.gridClones.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridClones.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridClones.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridClones.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridClones.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridClones.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridClones.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridClones.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            this.gridClones.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridClones.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridClones.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridClones.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridClones.ThemeStyle.HeaderStyle.Height = 23;
            this.gridClones.ThemeStyle.ReadOnly = true;
            this.gridClones.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridClones.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridClones.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridClones.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridClones.ThemeStyle.RowsStyle.Height = 22;
            this.gridClones.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridClones.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FraudDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControlRisk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FraudDetectionForm";
            this.Text = "Quản lý rủi ro";
            this.tabControlRisk.ResumeLayout(false);
            this.tabUserRisk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.tabShopRisk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridShops)).EndInit();
            this.grpShopAction.ResumeLayout(false);
            this.grpShopAction.PerformLayout();
            this.tabCloneRisk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridClones)).EndInit();
            this.ResumeLayout(false);

        }

        // --- Component Declarations ---
        private Guna.UI2.WinForms.Guna2TabControl tabControlRisk;
        private System.Windows.Forms.TabPage tabUserRisk, tabShopRisk, tabCloneRisk;

        // Tab 1 Components
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboRiskLevel;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private System.Windows.Forms.Label lblFilterTitle;
        private Guna.UI2.WinForms.Guna2DataGridView gridUsers;
        private Guna.UI2.WinForms.Guna2GroupBox grpAction;
        private System.Windows.Forms.Label lblSelectedUser;
        private Guna.UI2.WinForms.Guna2Button btnLockAccount;

        // Tab 2 Components
        private Guna.UI2.WinForms.Guna2DataGridView gridShops;
        private Guna.UI2.WinForms.Guna2GroupBox grpShopAction;
        private System.Windows.Forms.Label lblSelectedShop;
        private Guna.UI2.WinForms.Guna2Button btnLockShop;

        // Tab 3 Components
        private Guna.UI2.WinForms.Guna2DataGridView gridClones;
    }
}