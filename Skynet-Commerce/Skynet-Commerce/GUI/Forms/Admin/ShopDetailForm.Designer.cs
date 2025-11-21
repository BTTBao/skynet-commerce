namespace Skynet_Commerce.GUI.Forms
{
    partial class ShopDetailForm
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
            this.components = new System.ComponentModel.Container();
            this._dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this._lblTitle = new System.Windows.Forms.Label();
            this._btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this._pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txtShopId = new Guna.UI2.WinForms.Guna2TextBox();
            this._txtShopName = new Guna.UI2.WinForms.Guna2TextBox();
            this._txtOwner = new Guna.UI2.WinForms.Guna2TextBox();
            this._lblRating = new System.Windows.Forms.Label();
            this._lblStock = new System.Windows.Forms.Label();
            this._badgeStatus = new Guna.UI2.WinForms.Guna2Button();
            this._btnToggleStatus = new Guna.UI2.WinForms.Guna2Button();
            this._btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this._pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dragControl
            // 
            this._dragControl.DockIndicatorTransparencyValue = 0.6D;
            this._dragControl.TargetControl = this;
            this._dragControl.UseTransparentDrag = true;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(20, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(161, 25);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Chi tiết cửa hàng";
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.FillColor = System.Drawing.Color.Transparent;
            this._btnClose.IconColor = System.Drawing.Color.Gray;
            this._btnClose.Location = new System.Drawing.Point(450, 10);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(40, 30);
            this._btnClose.TabIndex = 1;
            // 
            // _pnlInfo
            // 
            this._pnlInfo.Controls.Add(this.label1);
            this._pnlInfo.Controls.Add(this.label2);
            this._pnlInfo.Controls.Add(this.label3);
            this._pnlInfo.Controls.Add(this.label4);
            this._pnlInfo.Controls.Add(this.label5);
            this._pnlInfo.Controls.Add(this._txtShopId);
            this._pnlInfo.Controls.Add(this._txtShopName);
            this._pnlInfo.Controls.Add(this._txtOwner);
            this._pnlInfo.Controls.Add(this._lblRating);
            this._pnlInfo.Controls.Add(this._lblStock);
            this._pnlInfo.Controls.Add(this._badgeStatus);
            this._pnlInfo.Controls.Add(this._btnToggleStatus);
            this._pnlInfo.Controls.Add(this._btnCancel);
            this._pnlInfo.Location = new System.Drawing.Point(12, 60);
            this._pnlInfo.Name = "_pnlInfo";
            this._pnlInfo.Size = new System.Drawing.Size(476, 378);
            this._pnlInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã cửa hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên cửa hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(30, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chủ sở hữu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(30, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đánh giá & SP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(250, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Trạng thái";
            // 
            // _txtShopId
            // 
            this._txtShopId.BorderRadius = 6;
            this._txtShopId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtShopId.DefaultText = "";
            this._txtShopId.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this._txtShopId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtShopId.Location = new System.Drawing.Point(30, 35);
            this._txtShopId.Name = "_txtShopId";
            this._txtShopId.PlaceholderText = "";
            this._txtShopId.ReadOnly = true;
            this._txtShopId.SelectedText = "";
            this._txtShopId.Size = new System.Drawing.Size(200, 36);
            this._txtShopId.TabIndex = 7;
            // 
            // _txtShopName
            // 
            this._txtShopName.BorderRadius = 6;
            this._txtShopName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtShopName.DefaultText = "";
            this._txtShopName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this._txtShopName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtShopName.Location = new System.Drawing.Point(30, 105);
            this._txtShopName.Name = "_txtShopName";
            this._txtShopName.PlaceholderText = "";
            this._txtShopName.ReadOnly = true;
            this._txtShopName.SelectedText = "";
            this._txtShopName.Size = new System.Drawing.Size(410, 36);
            this._txtShopName.TabIndex = 8;
            // 
            // _txtOwner
            // 
            this._txtOwner.BorderRadius = 6;
            this._txtOwner.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtOwner.DefaultText = "";
            this._txtOwner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this._txtOwner.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtOwner.Location = new System.Drawing.Point(30, 175);
            this._txtOwner.Name = "_txtOwner";
            this._txtOwner.PlaceholderText = "";
            this._txtOwner.ReadOnly = true;
            this._txtOwner.SelectedText = "";
            this._txtOwner.Size = new System.Drawing.Size(410, 36);
            this._txtOwner.TabIndex = 9;
            // 
            // _lblRating
            // 
            this._lblRating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblRating.ForeColor = System.Drawing.Color.Orange;
            this._lblRating.Location = new System.Drawing.Point(30, 245);
            this._lblRating.Name = "_lblRating";
            this._lblRating.Size = new System.Drawing.Size(64, 25);
            this._lblRating.TabIndex = 10;
            this._lblRating.Text = "★ 0.0";
            // 
            // _lblStock
            // 
            this._lblStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblStock.ForeColor = System.Drawing.Color.Gray;
            this._lblStock.Location = new System.Drawing.Point(113, 248);
            this._lblStock.Name = "_lblStock";
            this._lblStock.Size = new System.Drawing.Size(100, 25);
            this._lblStock.TabIndex = 11;
            this._lblStock.Text = "(0 sản phẩm)";
            // 
            // _badgeStatus
            // 
            this._badgeStatus.BorderRadius = 10;
            this._badgeStatus.Enabled = false;
            this._badgeStatus.FillColor = System.Drawing.Color.Gray;
            this._badgeStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._badgeStatus.ForeColor = System.Drawing.Color.White;
            this._badgeStatus.Location = new System.Drawing.Point(250, 245);
            this._badgeStatus.Name = "_badgeStatus";
            this._badgeStatus.Size = new System.Drawing.Size(120, 30);
            this._badgeStatus.TabIndex = 12;
            // 
            // _btnToggleStatus
            // 
            this._btnToggleStatus.BorderRadius = 8;
            this._btnToggleStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._btnToggleStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnToggleStatus.ForeColor = System.Drawing.Color.White;
            this._btnToggleStatus.Location = new System.Drawing.Point(30, 310);
            this._btnToggleStatus.Name = "_btnToggleStatus";
            this._btnToggleStatus.Size = new System.Drawing.Size(150, 40);
            this._btnToggleStatus.TabIndex = 13;
            this._btnToggleStatus.Text = "Khóa cửa hàng";
            this._btnToggleStatus.Click += new System.EventHandler(this._btnToggleStatus_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.BorderColor = System.Drawing.Color.Silver;
            this._btnCancel.BorderRadius = 8;
            this._btnCancel.BorderThickness = 1;
            this._btnCancel.FillColor = System.Drawing.Color.Transparent;
            this._btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this._btnCancel.Location = new System.Drawing.Point(310, 310);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(130, 40);
            this._btnCancel.TabIndex = 14;
            this._btnCancel.Text = "Đóng";
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // ShopDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this._pnlInfo);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShopDetailForm";
            this._pnlInfo.ResumeLayout(false);
            this._pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl _dragControl;
        private Guna.UI2.WinForms.Guna2ControlBox _btnClose;
        private System.Windows.Forms.Label _lblTitle;
        private Guna.UI2.WinForms.Guna2Panel _pnlInfo;

        private System.Windows.Forms.Label label1, label2, label3, label4, label5;
        private Guna.UI2.WinForms.Guna2TextBox _txtShopId;
        private Guna.UI2.WinForms.Guna2TextBox _txtShopName;
        private Guna.UI2.WinForms.Guna2TextBox _txtOwner;
        private System.Windows.Forms.Label _lblRating;
        private System.Windows.Forms.Label _lblStock;
        private Guna.UI2.WinForms.Guna2Button _badgeStatus;

        private Guna.UI2.WinForms.Guna2Button _btnToggleStatus;
        private Guna.UI2.WinForms.Guna2Button _btnCancel;
    }
}