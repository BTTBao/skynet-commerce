namespace Skynet_Commerce.GUI.Forms
{
    partial class ShopDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._pnlHeader = new System.Windows.Forms.Panel();
            this._lblStatus = new System.Windows.Forms.Label();
            this._btnBan = new Guna.UI2.WinForms.Guna2Button();
            this._btnSave = new Guna.UI2.WinForms.Guna2Button();
            this._lblTitle = new System.Windows.Forms.Label();
            this._picAvatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this._tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this._tabInfo = new System.Windows.Forms.TabPage();
            this._pnlStats3 = new Guna.UI2.WinForms.Guna2Panel();
            this._lblRatingVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._pnlStats2 = new Guna.UI2.WinForms.Guna2Panel();
            this._lblTotalOrderVal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._pnlStats1 = new Guna.UI2.WinForms.Guna2Panel();
            this._lblRevenueVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._txtOwner = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tabProducts = new System.Windows.Forms.TabPage();
            this._gridProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this._tabOrders = new System.Windows.Forms.TabPage();
            this._gridOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            this._pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picAvatar)).BeginInit();
            this._tabControl.SuspendLayout();
            this._tabInfo.SuspendLayout();
            this._pnlStats3.SuspendLayout();
            this._pnlStats2.SuspendLayout();
            this._pnlStats1.SuspendLayout();
            this._tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridProducts)).BeginInit();
            this._tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // _pnlHeader
            // 
            this._pnlHeader.BackColor = System.Drawing.Color.White;
            this._pnlHeader.Controls.Add(this._lblStatus);
            this._pnlHeader.Controls.Add(this._btnBan);
            this._pnlHeader.Controls.Add(this._btnSave);
            this._pnlHeader.Controls.Add(this._lblTitle);
            this._pnlHeader.Controls.Add(this._picAvatar);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.Location = new System.Drawing.Point(0, 0);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.Size = new System.Drawing.Size(900, 80);
            this._pnlHeader.TabIndex = 0;
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblStatus.ForeColor = System.Drawing.Color.Green;
            this._lblStatus.Location = new System.Drawing.Point(92, 45);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(125, 19);
            this._lblStatus.TabIndex = 4;
            this._lblStatus.Text = "● Đang hoạt động";
            // 
            // _btnBan
            // 
            this._btnBan.BorderRadius = 5;
            this._btnBan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this._btnBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnBan.ForeColor = System.Drawing.Color.White;
            this._btnBan.Location = new System.Drawing.Point(595, 20);
            this._btnBan.Name = "_btnBan";
            this._btnBan.Size = new System.Drawing.Size(130, 40);
            this._btnBan.TabIndex = 3;
            this._btnBan.Text = "Đình chỉ";
            this._btnBan.Click += new System.EventHandler(this._btnBan_Click);
            // 
            // _btnSave
            // 
            this._btnSave.BorderRadius = 5;
            this._btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnSave.ForeColor = System.Drawing.Color.White;
            this._btnSave.Location = new System.Drawing.Point(743, 20);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(130, 40);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Lưu thay đổi";
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(90, 15);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(182, 30);
            this._lblTitle.TabIndex = 1;
            this._lblTitle.Text = "Hồ sơ cửa hàng";
            // 
            // _picAvatar
            // 
            this._picAvatar.BorderRadius = 30;
            this._picAvatar.FillColor = System.Drawing.Color.LightGray;
            this._picAvatar.Location = new System.Drawing.Point(20, 10);
            this._picAvatar.Name = "_picAvatar";
            this._picAvatar.Size = new System.Drawing.Size(60, 60);
            this._picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picAvatar.TabIndex = 0;
            this._picAvatar.TabStop = false;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabInfo);
            this._tabControl.Controls.Add(this._tabProducts);
            this._tabControl.Controls.Add(this._tabOrders);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.ItemSize = new System.Drawing.Size(180, 40);
            this._tabControl.Location = new System.Drawing.Point(0, 80);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(900, 570);
            this._tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this._tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this._tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this._tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this._tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this._tabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this._tabControl.TabIndex = 1;
            this._tabControl.TabMenuBackColor = System.Drawing.Color.White;
            this._tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // _tabInfo
            // 
            this._tabInfo.BackColor = System.Drawing.Color.White;
            this._tabInfo.Controls.Add(this._pnlStats3);
            this._tabInfo.Controls.Add(this._pnlStats2);
            this._tabInfo.Controls.Add(this._pnlStats1);
            this._tabInfo.Controls.Add(this._txtPhone);
            this._tabInfo.Controls.Add(this.label9);
            this._tabInfo.Controls.Add(this._txtEmail);
            this._tabInfo.Controls.Add(this.label8);
            this._tabInfo.Controls.Add(this._txtOwner);
            this._tabInfo.Controls.Add(this.label7);
            this._tabInfo.Controls.Add(this._txtDesc);
            this._tabInfo.Controls.Add(this.label3);
            this._tabInfo.Controls.Add(this._txtName);
            this._tabInfo.Controls.Add(this.label2);
            this._tabInfo.Location = new System.Drawing.Point(4, 44);
            this._tabInfo.Name = "_tabInfo";
            this._tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this._tabInfo.Size = new System.Drawing.Size(892, 522);
            this._tabInfo.TabIndex = 0;
            this._tabInfo.Text = "Thông tin chung";
            // 
            // _pnlStats3
            // 
            this._pnlStats3.BorderRadius = 10;
            this._pnlStats3.Controls.Add(this._lblRatingVal);
            this._pnlStats3.Controls.Add(this.label6);
            this._pnlStats3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this._pnlStats3.Location = new System.Drawing.Point(470, 20);
            this._pnlStats3.Name = "_pnlStats3";
            this._pnlStats3.Size = new System.Drawing.Size(200, 80);
            this._pnlStats3.TabIndex = 12;
            // 
            // _lblRatingVal
            // 
            this._lblRatingVal.AutoSize = true;
            this._lblRatingVal.BackColor = System.Drawing.Color.Transparent;
            this._lblRatingVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblRatingVal.ForeColor = System.Drawing.Color.Orange;
            this._lblRatingVal.Location = new System.Drawing.Point(10, 35);
            this._lblRatingVal.Name = "_lblRatingVal";
            this._lblRatingVal.Size = new System.Drawing.Size(60, 25);
            this._lblRatingVal.TabIndex = 1;
            this._lblRatingVal.Text = "5.0 ★";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Đánh giá";
            // 
            // _pnlStats2
            // 
            this._pnlStats2.BorderRadius = 10;
            this._pnlStats2.Controls.Add(this._lblTotalOrderVal);
            this._pnlStats2.Controls.Add(this.label4);
            this._pnlStats2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this._pnlStats2.Location = new System.Drawing.Point(245, 20);
            this._pnlStats2.Name = "_pnlStats2";
            this._pnlStats2.Size = new System.Drawing.Size(200, 80);
            this._pnlStats2.TabIndex = 11;
            // 
            // _lblTotalOrderVal
            // 
            this._lblTotalOrderVal.AutoSize = true;
            this._lblTotalOrderVal.BackColor = System.Drawing.Color.Transparent;
            this._lblTotalOrderVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTotalOrderVal.ForeColor = System.Drawing.Color.Blue;
            this._lblTotalOrderVal.Location = new System.Drawing.Point(10, 35);
            this._lblTotalOrderVal.Name = "_lblTotalOrderVal";
            this._lblTotalOrderVal.Size = new System.Drawing.Size(23, 25);
            this._lblTotalOrderVal.TabIndex = 1;
            this._lblTotalOrderVal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tổng đơn hàng";
            // 
            // _pnlStats1
            // 
            this._pnlStats1.BorderRadius = 10;
            this._pnlStats1.Controls.Add(this._lblRevenueVal);
            this._pnlStats1.Controls.Add(this.label1);
            this._pnlStats1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this._pnlStats1.Location = new System.Drawing.Point(20, 20);
            this._pnlStats1.Name = "_pnlStats1";
            this._pnlStats1.Size = new System.Drawing.Size(200, 80);
            this._pnlStats1.TabIndex = 10;
            // 
            // _lblRevenueVal
            // 
            this._lblRevenueVal.AutoSize = true;
            this._lblRevenueVal.BackColor = System.Drawing.Color.Transparent;
            this._lblRevenueVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblRevenueVal.ForeColor = System.Drawing.Color.Green;
            this._lblRevenueVal.Location = new System.Drawing.Point(10, 35);
            this._lblRevenueVal.Name = "_lblRevenueVal";
            this._lblRevenueVal.Size = new System.Drawing.Size(23, 25);
            this._lblRevenueVal.TabIndex = 1;
            this._lblRevenueVal.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doanh thu";
            // 
            // _txtPhone
            // 
            this._txtPhone.BorderRadius = 5;
            this._txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtPhone.DefaultText = "";
            this._txtPhone.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtPhone.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtPhone.Location = new System.Drawing.Point(470, 295);
            this._txtPhone.Name = "_txtPhone";
            this._txtPhone.ReadOnly = true;
            this._txtPhone.Size = new System.Drawing.Size(300, 36);
            this._txtPhone.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(470, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Số điện thoại";
            // 
            // _txtEmail
            // 
            this._txtEmail.BorderRadius = 5;
            this._txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmail.DefaultText = "";
            this._txtEmail.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtEmail.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtEmail.Location = new System.Drawing.Point(470, 225);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.ReadOnly = true;
            this._txtEmail.Size = new System.Drawing.Size(300, 36);
            this._txtEmail.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(470, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Email";
            // 
            // _txtOwner
            // 
            this._txtOwner.BorderRadius = 5;
            this._txtOwner.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtOwner.DefaultText = "";
            this._txtOwner.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtOwner.FillColor = System.Drawing.Color.WhiteSmoke;
            this._txtOwner.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtOwner.Location = new System.Drawing.Point(470, 155);
            this._txtOwner.Name = "_txtOwner";
            this._txtOwner.ReadOnly = true;
            this._txtOwner.Size = new System.Drawing.Size(300, 36);
            this._txtOwner.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(470, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Chủ sở hữu";
            // 
            // _txtDesc
            // 
            this._txtDesc.BorderRadius = 5;
            this._txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtDesc.DefaultText = "";
            this._txtDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtDesc.Location = new System.Drawing.Point(20, 225);
            this._txtDesc.Multiline = true;
            this._txtDesc.Name = "_txtDesc";
            this._txtDesc.Size = new System.Drawing.Size(400, 106);
            this._txtDesc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(20, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả";
            // 
            // _txtName
            // 
            this._txtName.BorderRadius = 5;
            this._txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtName.DefaultText = "";
            this._txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtName.Location = new System.Drawing.Point(20, 155);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(400, 36);
            this._txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(20, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Shop";
            // 
            // _tabProducts
            // 
            this._tabProducts.BackColor = System.Drawing.Color.White;
            this._tabProducts.Controls.Add(this._gridProducts);
            this._tabProducts.Location = new System.Drawing.Point(4, 44);
            this._tabProducts.Name = "_tabProducts";
            this._tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this._tabProducts.Size = new System.Drawing.Size(892, 522);
            this._tabProducts.TabIndex = 1;
            this._tabProducts.Text = "Danh sách sản phẩm";
            // 
            // _gridProducts
            // 
            this._gridProducts.AllowUserToAddRows = false;
            this._gridProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._gridProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridProducts.BackgroundColor = System.Drawing.Color.White;
            this._gridProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._gridProducts.ColumnHeadersHeight = 40;
            this._gridProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this._gridProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridProducts.EnableHeadersVisualStyles = false;
            this._gridProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridProducts.Location = new System.Drawing.Point(3, 3);
            this._gridProducts.Name = "_gridProducts";
            this._gridProducts.ReadOnly = true;
            this._gridProducts.RowHeadersVisible = false;
            this._gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridProducts.Size = new System.Drawing.Size(886, 516);
            this._gridProducts.TabIndex = 0;
            this._gridProducts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._gridProducts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._gridProducts.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._gridProducts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._gridProducts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._gridProducts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._gridProducts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridProducts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._gridProducts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._gridProducts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._gridProducts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._gridProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this._gridProducts.ThemeStyle.HeaderStyle.Height = 40;
            this._gridProducts.ThemeStyle.ReadOnly = true;
            this._gridProducts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._gridProducts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridProducts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._gridProducts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._gridProducts.ThemeStyle.RowsStyle.Height = 22;
            this._gridProducts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridProducts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // _tabOrders
            // 
            this._tabOrders.BackColor = System.Drawing.Color.White;
            this._tabOrders.Controls.Add(this._gridOrders);
            this._tabOrders.Location = new System.Drawing.Point(4, 44);
            this._tabOrders.Name = "_tabOrders";
            this._tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this._tabOrders.Size = new System.Drawing.Size(892, 522);
            this._tabOrders.TabIndex = 2;
            this._tabOrders.Text = "Lịch sử đơn hàng";
            // 
            // _gridOrders
            // 
            this._gridOrders.AllowUserToAddRows = false;
            this._gridOrders.AllowUserToDeleteRows = false;
            this._gridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridOrders.BackgroundColor = System.Drawing.Color.White;
            this._gridOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._gridOrders.ColumnHeadersHeight = 40;
            this._gridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridOrders.EnableHeadersVisualStyles = false;
            this._gridOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridOrders.Location = new System.Drawing.Point(3, 3);
            this._gridOrders.Name = "_gridOrders";
            this._gridOrders.ReadOnly = true;
            this._gridOrders.RowHeadersVisible = false;
            this._gridOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridOrders.Size = new System.Drawing.Size(886, 516);
            this._gridOrders.TabIndex = 1;
            this._gridOrders.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._gridOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._gridOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._gridOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._gridOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._gridOrders.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._gridOrders.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridOrders.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._gridOrders.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._gridOrders.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._gridOrders.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._gridOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this._gridOrders.ThemeStyle.HeaderStyle.Height = 40;
            this._gridOrders.ThemeStyle.ReadOnly = true;
            this._gridOrders.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._gridOrders.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridOrders.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._gridOrders.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._gridOrders.ThemeStyle.RowsStyle.Height = 22;
            this._gridOrders.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridOrders.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ShopDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShopDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết cửa hàng";
            this._pnlHeader.ResumeLayout(false);
            this._pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picAvatar)).EndInit();
            this._tabControl.ResumeLayout(false);
            this._tabInfo.ResumeLayout(false);
            this._tabInfo.PerformLayout();
            this._pnlStats3.ResumeLayout(false);
            this._pnlStats3.PerformLayout();
            this._pnlStats2.ResumeLayout(false);
            this._pnlStats2.PerformLayout();
            this._pnlStats1.ResumeLayout(false);
            this._pnlStats1.PerformLayout();
            this._tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridProducts)).EndInit();
            this._tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlHeader;
        private Guna.UI2.WinForms.Guna2PictureBox _picAvatar;
        private System.Windows.Forms.Label _lblTitle;
        private Guna.UI2.WinForms.Guna2Button _btnSave;
        private Guna.UI2.WinForms.Guna2Button _btnBan;
        private System.Windows.Forms.Label _lblStatus;
        private Guna.UI2.WinForms.Guna2TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabInfo;
        private System.Windows.Forms.TabPage _tabProducts;
        private System.Windows.Forms.TabPage _tabOrders;
        private Guna.UI2.WinForms.Guna2TextBox _txtName;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox _txtDesc;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox _txtOwner;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox _txtPhone;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox _txtEmail;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Panel _pnlStats1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblRevenueVal;
        private Guna.UI2.WinForms.Guna2Panel _pnlStats3;
        private System.Windows.Forms.Label _lblRatingVal;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel _pnlStats2;
        private System.Windows.Forms.Label _lblTotalOrderVal;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DataGridView _gridProducts;
        private Guna.UI2.WinForms.Guna2DataGridView _gridOrders;
    }
}