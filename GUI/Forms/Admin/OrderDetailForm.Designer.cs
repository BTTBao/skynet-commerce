namespace Skynet_Commerce.GUI.Forms
{
    partial class OrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this._btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this._lblTitle = new System.Windows.Forms.Label();
            this._tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this._tabGeneral = new System.Windows.Forms.TabPage();
            this._gridItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this._tabShipping = new System.Windows.Forms.TabPage();
            this._tabHistory = new System.Windows.Forms.TabPage();
            this._gridHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this._pnlHeader.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridItems)).BeginInit();
            this._tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // _pnlHeader
            // 
            this._pnlHeader.Controls.Add(this._btnClose);
            this._pnlHeader.Controls.Add(this._lblTitle);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this._pnlHeader.Location = new System.Drawing.Point(0, 0);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.ShadowDecoration.Depth = 5;
            this._pnlHeader.ShadowDecoration.Enabled = true;
            this._pnlHeader.Size = new System.Drawing.Size(1000, 60);
            this._pnlHeader.TabIndex = 0;
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.BorderRadius = 5;
            this._btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this._btnClose.IconColor = System.Drawing.Color.White;
            this._btnClose.Location = new System.Drawing.Point(943, 12);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(45, 35);
            this._btnClose.TabIndex = 1;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.BackColor = System.Drawing.Color.Transparent;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.White;
            this._lblTitle.Location = new System.Drawing.Point(20, 15);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(165, 25);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Chi tiết đơn hàng";
            // 
            // _tabControl
            // 
            this._tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this._tabControl.Controls.Add(this._tabGeneral);
            this._tabControl.Controls.Add(this._tabShipping);
            this._tabControl.Controls.Add(this._tabHistory);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.ItemSize = new System.Drawing.Size(180, 45);
            this._tabControl.Location = new System.Drawing.Point(0, 60);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1000, 640);
            this._tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this._tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this._tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this._tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this._tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
            this._tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this._tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this._tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this._tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this._tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this._tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this._tabControl.TabButtonSize = new System.Drawing.Size(180, 45);
            this._tabControl.TabIndex = 1;
            this._tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // _tabGeneral
            // 
            this._tabGeneral.BackColor = System.Drawing.Color.White;
            this._tabGeneral.Controls.Add(this._gridItems);
            this._tabGeneral.Location = new System.Drawing.Point(184, 4);
            this._tabGeneral.Name = "_tabGeneral";
            this._tabGeneral.Size = new System.Drawing.Size(812, 632);
            this._tabGeneral.TabIndex = 0;
            this._tabGeneral.Text = "Thông tin chung";
            // 
            // _gridItems
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._gridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._gridItems.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridItems.DefaultCellStyle = dataGridViewCellStyle3;
            this._gridItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._gridItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridItems.Location = new System.Drawing.Point(0, 282);
            this._gridItems.Name = "_gridItems";
            this._gridItems.ReadOnly = true;
            this._gridItems.RowHeadersVisible = false;
            this._gridItems.RowTemplate.Height = 35;
            this._gridItems.Size = new System.Drawing.Size(812, 350);
            this._gridItems.TabIndex = 0;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._gridItems.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._gridItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._gridItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gridItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._gridItems.ThemeStyle.HeaderStyle.Height = 40;
            this._gridItems.ThemeStyle.ReadOnly = true;
            this._gridItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gridItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._gridItems.ThemeStyle.RowsStyle.Height = 35;
            this._gridItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // _tabShipping
            // 
            this._tabShipping.BackColor = System.Drawing.Color.White;
            this._tabShipping.Location = new System.Drawing.Point(184, 4);
            this._tabShipping.Name = "_tabShipping";
            this._tabShipping.Size = new System.Drawing.Size(812, 632);
            this._tabShipping.TabIndex = 1;
            this._tabShipping.Text = "Giao hàng & Địa chỉ";
            // 
            // _tabHistory
            // 
            this._tabHistory.BackColor = System.Drawing.Color.White;
            this._tabHistory.Controls.Add(this._gridHistory);
            this._tabHistory.Location = new System.Drawing.Point(184, 4);
            this._tabHistory.Name = "_tabHistory";
            this._tabHistory.Padding = new System.Windows.Forms.Padding(10);
            this._tabHistory.Size = new System.Drawing.Size(812, 632);
            this._tabHistory.TabIndex = 2;
            this._tabHistory.Text = "Lịch sử trạng thái";
            // 
            // _gridHistory
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this._gridHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            this._gridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._gridHistory.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridHistory.DefaultCellStyle = dataGridViewCellStyle6;
            this._gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridHistory.Location = new System.Drawing.Point(10, 10);
            this._gridHistory.Name = "_gridHistory";
            this._gridHistory.ReadOnly = true;
            this._gridHistory.RowHeadersVisible = false;
            this._gridHistory.RowTemplate.Height = 35;
            this._gridHistory.Size = new System.Drawing.Size(792, 612);
            this._gridHistory.TabIndex = 0;
            this._gridHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._gridHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._gridHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._gridHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._gridHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._gridHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._gridHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._gridHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._gridHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gridHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._gridHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._gridHistory.ThemeStyle.HeaderStyle.Height = 40;
            this._gridHistory.ThemeStyle.ReadOnly = true;
            this._gridHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._gridHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gridHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._gridHistory.ThemeStyle.RowsStyle.Height = 35;
            this._gridHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // OrderDetailForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết đơn hàng";
            this._pnlHeader.ResumeLayout(false);
            this._pnlHeader.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._tabGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridItems)).EndInit();
            this._tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel _pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox _btnClose;
        private System.Windows.Forms.Label _lblTitle;
        private Guna.UI2.WinForms.Guna2TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabGeneral;
        private System.Windows.Forms.TabPage _tabShipping;
        private System.Windows.Forms.TabPage _tabHistory;
        private Guna.UI2.WinForms.Guna2DataGridView _gridItems;
        private Guna.UI2.WinForms.Guna2DataGridView _gridHistory;
        #endregion
    }
}