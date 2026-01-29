namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerWalletForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvSettledOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblSettledOrders = new System.Windows.Forms.Label();
            this.dgvTransactionHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTransactionHistory = new System.Windows.Forms.Label();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.panelNetAmount = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNetAmountValue = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.panelSettledCount = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSettledCountValue = new System.Windows.Forms.Label();
            this.lblSettledCount = new System.Windows.Forms.Label();
            this.panelTotalRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.iconNetAmount = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.iconSettledCount = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.iconTotalRevenue = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettledOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelNetAmount.SuspendLayout();
            this.panelSettledCount.SuspendLayout();
            this.panelTotalRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSettledCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconTotalRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1044, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.guna2Button1);
            this.panelBottom.Controls.Add(this.dgvSettledOrders);
            this.panelBottom.Controls.Add(this.lblSettledOrders);
            this.panelBottom.Controls.Add(this.dgvTransactionHistory);
            this.panelBottom.Controls.Add(this.lblTransactionHistory);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(20, 230);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1004, 450);
            this.panelBottom.TabIndex = 2;
            // 
            // dgvSettledOrders
            // 
            this.dgvSettledOrders.AllowUserToAddRows = false;
            this.dgvSettledOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvSettledOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSettledOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSettledOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSettledOrders.ColumnHeadersHeight = 40;
            this.dgvSettledOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSettledOrders.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSettledOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSettledOrders.Location = new System.Drawing.Point(436, 61);
            this.dgvSettledOrders.Name = "dgvSettledOrders";
            this.dgvSettledOrders.ReadOnly = true;
            this.dgvSettledOrders.RowHeadersVisible = false;
            this.dgvSettledOrders.RowHeadersWidth = 51;
            this.dgvSettledOrders.RowTemplate.Height = 35;
            this.dgvSettledOrders.Size = new System.Drawing.Size(534, 369);
            this.dgvSettledOrders.TabIndex = 3;
            this.dgvSettledOrders.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSettledOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSettledOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSettledOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSettledOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSettledOrders.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSettledOrders.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSettledOrders.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSettledOrders.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSettledOrders.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSettledOrders.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSettledOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSettledOrders.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvSettledOrders.ThemeStyle.ReadOnly = true;
            this.dgvSettledOrders.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSettledOrders.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSettledOrders.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSettledOrders.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSettledOrders.ThemeStyle.RowsStyle.Height = 35;
            this.dgvSettledOrders.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSettledOrders.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblSettledOrders
            // 
            this.lblSettledOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSettledOrders.AutoSize = true;
            this.lblSettledOrders.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSettledOrders.Location = new System.Drawing.Point(431, 30);
            this.lblSettledOrders.Name = "lblSettledOrders";
            this.lblSettledOrders.Size = new System.Drawing.Size(222, 25);
            this.lblSettledOrders.TabIndex = 2;
            this.lblSettledOrders.Text = "Đơn hàng đã quyết toán";
            // 
            // dgvTransactionHistory
            // 
            this.dgvTransactionHistory.AllowUserToAddRows = false;
            this.dgvTransactionHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvTransactionHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTransactionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTransactionHistory.ColumnHeadersHeight = 40;
            this.dgvTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactionHistory.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTransactionHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTransactionHistory.Location = new System.Drawing.Point(10, 61);
            this.dgvTransactionHistory.Name = "dgvTransactionHistory";
            this.dgvTransactionHistory.ReadOnly = true;
            this.dgvTransactionHistory.RowHeadersVisible = false;
            this.dgvTransactionHistory.RowHeadersWidth = 51;
            this.dgvTransactionHistory.RowTemplate.Height = 35;
            this.dgvTransactionHistory.Size = new System.Drawing.Size(398, 369);
            this.dgvTransactionHistory.TabIndex = 1;
            this.dgvTransactionHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTransactionHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTransactionHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTransactionHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTransactionHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTransactionHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTransactionHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTransactionHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTransactionHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTransactionHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTransactionHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTransactionHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTransactionHistory.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTransactionHistory.ThemeStyle.ReadOnly = true;
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.Height = 35;
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTransactionHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblTransactionHistory
            // 
            this.lblTransactionHistory.AutoSize = true;
            this.lblTransactionHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTransactionHistory.Location = new System.Drawing.Point(14, 30);
            this.lblTransactionHistory.Name = "lblTransactionHistory";
            this.lblTransactionHistory.Size = new System.Drawing.Size(154, 25);
            this.lblTransactionHistory.TabIndex = 0;
            this.lblTransactionHistory.Text = "Lịch sử giao dịch";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelNetAmount);
            this.panelTop.Controls.Add(this.panelSettledCount);
            this.panelTop.Controls.Add(this.panelTotalRevenue);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 60);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1004, 170);
            this.panelTop.TabIndex = 1;
            // 
            // panelNetAmount
            // 
            this.panelNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNetAmount.BackColor = System.Drawing.Color.Transparent;
            this.panelNetAmount.BorderRadius = 15;
            this.panelNetAmount.Controls.Add(this.lblNetAmountValue);
            this.panelNetAmount.Controls.Add(this.lblNetAmount);
            this.panelNetAmount.Controls.Add(this.iconNetAmount);
            this.panelNetAmount.FillColor = System.Drawing.Color.White;
            this.panelNetAmount.Location = new System.Drawing.Point(680, 10);
            this.panelNetAmount.Name = "panelNetAmount";
            this.panelNetAmount.ShadowDecoration.BorderRadius = 15;
            this.panelNetAmount.ShadowDecoration.Depth = 10;
            this.panelNetAmount.ShadowDecoration.Enabled = true;
            this.panelNetAmount.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.panelNetAmount.Size = new System.Drawing.Size(290, 150);
            this.panelNetAmount.TabIndex = 2;
            // 
            // lblNetAmountValue
            // 
            this.lblNetAmountValue.AutoSize = true;
            this.lblNetAmountValue.BackColor = System.Drawing.Color.Transparent;
            this.lblNetAmountValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNetAmountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblNetAmountValue.Location = new System.Drawing.Point(25, 80);
            this.lblNetAmountValue.Name = "lblNetAmountValue";
            this.lblNetAmountValue.Size = new System.Drawing.Size(124, 46);
            this.lblNetAmountValue.TabIndex = 2;
            this.lblNetAmountValue.Text = "0 VNĐ";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblNetAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNetAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblNetAmount.Location = new System.Drawing.Point(25, 25);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(138, 25);
            this.lblNetAmount.TabIndex = 1;
            this.lblNetAmount.Text = "Tiền thực nhận";
            // 
            // panelSettledCount
            // 
            this.panelSettledCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelSettledCount.BackColor = System.Drawing.Color.Transparent;
            this.panelSettledCount.BorderRadius = 15;
            this.panelSettledCount.Controls.Add(this.lblSettledCountValue);
            this.panelSettledCount.Controls.Add(this.lblSettledCount);
            this.panelSettledCount.Controls.Add(this.iconSettledCount);
            this.panelSettledCount.FillColor = System.Drawing.Color.White;
            this.panelSettledCount.Location = new System.Drawing.Point(345, 10);
            this.panelSettledCount.Name = "panelSettledCount";
            this.panelSettledCount.ShadowDecoration.BorderRadius = 15;
            this.panelSettledCount.ShadowDecoration.Depth = 10;
            this.panelSettledCount.ShadowDecoration.Enabled = true;
            this.panelSettledCount.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.panelSettledCount.Size = new System.Drawing.Size(306, 150);
            this.panelSettledCount.TabIndex = 1;
            // 
            // lblSettledCountValue
            // 
            this.lblSettledCountValue.AutoSize = true;
            this.lblSettledCountValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSettledCountValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSettledCountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblSettledCountValue.Location = new System.Drawing.Point(25, 80);
            this.lblSettledCountValue.Name = "lblSettledCountValue";
            this.lblSettledCountValue.Size = new System.Drawing.Size(113, 46);
            this.lblSettledCountValue.TabIndex = 2;
            this.lblSettledCountValue.Text = "0 đơn";
            // 
            // lblSettledCount
            // 
            this.lblSettledCount.AutoSize = true;
            this.lblSettledCount.BackColor = System.Drawing.Color.Transparent;
            this.lblSettledCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSettledCount.ForeColor = System.Drawing.Color.Gray;
            this.lblSettledCount.Location = new System.Drawing.Point(25, 25);
            this.lblSettledCount.Name = "lblSettledCount";
            this.lblSettledCount.Size = new System.Drawing.Size(192, 25);
            this.lblSettledCount.TabIndex = 1;
            this.lblSettledCount.Text = "Số đơn đã quyết toán";
            // 
            // panelTotalRevenue
            // 
            this.panelTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.panelTotalRevenue.BorderRadius = 15;
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenueValue);
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelTotalRevenue.Controls.Add(this.iconTotalRevenue);
            this.panelTotalRevenue.FillColor = System.Drawing.Color.White;
            this.panelTotalRevenue.Location = new System.Drawing.Point(10, 10);
            this.panelTotalRevenue.Name = "panelTotalRevenue";
            this.panelTotalRevenue.ShadowDecoration.BorderRadius = 15;
            this.panelTotalRevenue.ShadowDecoration.Depth = 10;
            this.panelTotalRevenue.ShadowDecoration.Enabled = true;
            this.panelTotalRevenue.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.panelTotalRevenue.Size = new System.Drawing.Size(303, 150);
            this.panelTotalRevenue.TabIndex = 0;
            // 
            // lblTotalRevenueValue
            // 
            this.lblTotalRevenueValue.AutoSize = true;
            this.lblTotalRevenueValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(25, 80);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(124, 46);
            this.lblTotalRevenueValue.TabIndex = 2;
            this.lblTotalRevenueValue.Text = "0 VNĐ";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalRevenue.Location = new System.Drawing.Point(25, 25);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(176, 25);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "Tổng tiền bán được";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1004, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ví Người Bán";
            // 
            // iconNetAmount
            // 
            this.iconNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconNetAmount.BackColor = System.Drawing.Color.Transparent;
            this.iconNetAmount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.iconNetAmount.ImageRotate = 0F;
            this.iconNetAmount.Location = new System.Drawing.Point(210, 25);
            this.iconNetAmount.Name = "iconNetAmount";
            this.iconNetAmount.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.iconNetAmount.Size = new System.Drawing.Size(60, 60);
            this.iconNetAmount.TabIndex = 0;
            this.iconNetAmount.TabStop = false;
            // 
            // iconSettledCount
            // 
            this.iconSettledCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconSettledCount.BackColor = System.Drawing.Color.Transparent;
            this.iconSettledCount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(178)))));
            this.iconSettledCount.ImageRotate = 0F;
            this.iconSettledCount.Location = new System.Drawing.Point(226, 25);
            this.iconSettledCount.Name = "iconSettledCount";
            this.iconSettledCount.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.iconSettledCount.Size = new System.Drawing.Size(60, 60);
            this.iconSettledCount.TabIndex = 0;
            this.iconSettledCount.TabStop = false;
            // 
            // iconTotalRevenue
            // 
            this.iconTotalRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.iconTotalRevenue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.iconTotalRevenue.ImageRotate = 0F;
            this.iconTotalRevenue.Location = new System.Drawing.Point(223, 25);
            this.iconTotalRevenue.Name = "iconTotalRevenue";
            this.iconTotalRevenue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.iconTotalRevenue.Size = new System.Drawing.Size(60, 60);
            this.iconTotalRevenue.TabIndex = 0;
            this.iconTotalRevenue.TabStop = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(290, 17);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(118, 38);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Rút tiền";
            // 
            // SellerWalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 700);
            this.Controls.Add(this.panelMain);
            this.Name = "SellerWalletForm";
            this.Text = "Ví Người Bán - Skynet Ecommerce";
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettledOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelNetAmount.ResumeLayout(false);
            this.panelNetAmount.PerformLayout();
            this.panelSettledCount.ResumeLayout(false);
            this.panelSettledCount.PerformLayout();
            this.panelTotalRevenue.ResumeLayout(false);
            this.panelTotalRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSettledCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconTotalRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel panelTotalRevenue;
        private Guna.UI2.WinForms.Guna2CirclePictureBox iconTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private Guna.UI2.WinForms.Guna2Panel panelSettledCount;
        private System.Windows.Forms.Label lblSettledCountValue;
        private System.Windows.Forms.Label lblSettledCount;
        private Guna.UI2.WinForms.Guna2CirclePictureBox iconSettledCount;
        private Guna.UI2.WinForms.Guna2Panel panelNetAmount;
        private System.Windows.Forms.Label lblNetAmountValue;
        private System.Windows.Forms.Label lblNetAmount;
        private Guna.UI2.WinForms.Guna2CirclePictureBox iconNetAmount;
        private Guna.UI2.WinForms.Guna2Panel panelBottom;
        private System.Windows.Forms.Label lblTransactionHistory;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactionHistory;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSettledOrders;
        private System.Windows.Forms.Label lblSettledOrders;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}