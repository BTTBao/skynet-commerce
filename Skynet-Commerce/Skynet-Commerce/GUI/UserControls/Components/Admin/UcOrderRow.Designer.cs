namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcOrderRow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this._lblId = new System.Windows.Forms.Label();
            this._lblBuyer = new System.Windows.Forms.Label();
            this._lblShop = new System.Windows.Forms.Label();
            this._lblItems = new System.Windows.Forms.Label();
            this._lblAmount = new System.Windows.Forms.Label();
            this._lblDate = new System.Windows.Forms.Label();
            this._badgeStatus = new Guna.UI2.WinForms.Guna2Button();
            this._btnView = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblId.Location = new System.Drawing.Point(20, 18);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(73, 15);
            this._lblId.TabIndex = 0;
            this._lblId.Text = "#ORD-2341";
            // 
            // _lblBuyer
            // 
            this._lblBuyer.AutoSize = true;
            this._lblBuyer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblBuyer.Location = new System.Drawing.Point(130, 18);
            this._lblBuyer.Name = "_lblBuyer";
            this._lblBuyer.Size = new System.Drawing.Size(56, 15);
            this._lblBuyer.TabIndex = 1;
            this._lblBuyer.Text = "John Doe";
            // 
            // _lblShop
            // 
            this._lblShop.AutoSize = true;
            this._lblShop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblShop.Location = new System.Drawing.Point(280, 18);
            this._lblShop.Name = "_lblShop";
            this._lblShop.Size = new System.Drawing.Size(58, 15);
            this._lblShop.TabIndex = 2;
            this._lblShop.Text = "TechStore";
            // 
            // _lblItems
            // 
            this._lblItems.AutoSize = true;
            this._lblItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblItems.Location = new System.Drawing.Point(420, 18);
            this._lblItems.Name = "_lblItems";
            this._lblItems.Size = new System.Drawing.Size(13, 15);
            this._lblItems.TabIndex = 3;
            this._lblItems.Text = "2";
            // 
            // _lblAmount
            // 
            this._lblAmount.AutoSize = true;
            this._lblAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblAmount.Location = new System.Drawing.Point(500, 18);
            this._lblAmount.Name = "_lblAmount";
            this._lblAmount.Size = new System.Drawing.Size(52, 15);
            this._lblAmount.TabIndex = 4;
            this._lblAmount.Text = "$234.50";
            // 
            // _lblDate
            // 
            this._lblDate.AutoSize = true;
            this._lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblDate.ForeColor = System.Drawing.Color.DimGray;
            this._lblDate.Location = new System.Drawing.Point(606, 18);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(65, 15);
            this._lblDate.TabIndex = 5;
            this._lblDate.Text = "2025-11-15";
            // 
            // _badgeStatus
            // 
            this._badgeStatus.BorderRadius = 10;
            this._badgeStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._badgeStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._badgeStatus.ForeColor = System.Drawing.Color.White;
            this._badgeStatus.Location = new System.Drawing.Point(719, 14);
            this._badgeStatus.Name = "_badgeStatus";
            this._badgeStatus.Size = new System.Drawing.Size(100, 24);
            this._badgeStatus.TabIndex = 6;
            this._badgeStatus.Text = "Hoàn thành";
            // 
            // _btnView
            // 
            this._btnView.BorderColor = System.Drawing.Color.Transparent;
            this._btnView.FillColor = System.Drawing.Color.Transparent;
            this._btnView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._btnView.Location = new System.Drawing.Point(847, 12);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(111, 30);
            this._btnView.TabIndex = 7;
            this._btnView.Text = "👁 Xem chi tiết";
            this._btnView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UcOrderRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._badgeStatus);
            this.Controls.Add(this._lblDate);
            this.Controls.Add(this._lblAmount);
            this.Controls.Add(this._lblItems);
            this.Controls.Add(this._lblShop);
            this.Controls.Add(this._lblBuyer);
            this.Controls.Add(this._lblId);
            this.Name = "UcOrderRow";
            this.Size = new System.Drawing.Size(974, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblBuyer;
        private System.Windows.Forms.Label _lblShop;
        private System.Windows.Forms.Label _lblItems;
        private System.Windows.Forms.Label _lblAmount;
        private System.Windows.Forms.Label _lblDate;
        private Guna.UI2.WinForms.Guna2Button _badgeStatus;
        private Guna.UI2.WinForms.Guna2Button _btnView;
    }
}