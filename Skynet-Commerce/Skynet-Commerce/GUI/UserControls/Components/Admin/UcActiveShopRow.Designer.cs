namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcActiveShopRow
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
            this._lblName = new System.Windows.Forms.Label();
            this._lblOwner = new System.Windows.Forms.Label();
            this._lblRating = new System.Windows.Forms.Label();
            this._lblProducts = new System.Windows.Forms.Label();
            this._badgeStatus = new Guna.UI2.WinForms.Guna2Button();
            this._btnView = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblId.Location = new System.Drawing.Point(20, 18);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(61, 15);
            this._lblId.TabIndex = 0;
            this._lblId.Text = "SHOP-001";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblName.Location = new System.Drawing.Point(120, 18);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(64, 15);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "TechStore";
            // 
            // _lblOwner
            // 
            this._lblOwner.AutoSize = true;
            this._lblOwner.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblOwner.Location = new System.Drawing.Point(300, 18);
            this._lblOwner.Name = "_lblOwner";
            this._lblOwner.Size = new System.Drawing.Size(56, 15);
            this._lblOwner.TabIndex = 2;
            this._lblOwner.Text = "John Doe";
            // 
            // _lblRating
            // 
            this._lblRating.AutoSize = true;
            this._lblRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblRating.ForeColor = System.Drawing.Color.Orange;
            this._lblRating.Location = new System.Drawing.Point(480, 18);
            this._lblRating.Name = "_lblRating";
            this._lblRating.Size = new System.Drawing.Size(38, 15);
            this._lblRating.TabIndex = 3;
            this._lblRating.Text = "★ 4.8";
            // 
            // _lblProducts
            // 
            this._lblProducts.AutoSize = true;
            this._lblProducts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblProducts.Location = new System.Drawing.Point(580, 18);
            this._lblProducts.Name = "_lblProducts";
            this._lblProducts.Size = new System.Drawing.Size(25, 15);
            this._lblProducts.TabIndex = 4;
            this._lblProducts.Text = "234";
            // 
            // _badgeStatus
            // 
            this._badgeStatus.BorderRadius = 10;
            this._badgeStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._badgeStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._badgeStatus.ForeColor = System.Drawing.Color.White;
            this._badgeStatus.Location = new System.Drawing.Point(700, 14);
            this._badgeStatus.Name = "_badgeStatus";
            this._badgeStatus.Size = new System.Drawing.Size(80, 22);
            this._badgeStatus.TabIndex = 5;
            this._badgeStatus.Text = "Active";
            // 
            // _btnView
            // 
            this._btnView.BorderColor = System.Drawing.Color.Transparent;
            this._btnView.FillColor = System.Drawing.Color.Transparent;
            this._btnView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnView.ForeColor = System.Drawing.Color.Gray;
            this._btnView.Location = new System.Drawing.Point(884, 14);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(73, 30);
            this._btnView.TabIndex = 6;
            this._btnView.Text = "👁 View Details";
            this._btnView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UcActiveShopRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._badgeStatus);
            this.Controls.Add(this._lblProducts);
            this.Controls.Add(this._lblRating);
            this.Controls.Add(this._lblOwner);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._lblId);
            this.Name = "UcActiveShopRow";
            this.Size = new System.Drawing.Size(974, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblOwner;
        private System.Windows.Forms.Label _lblRating;
        private System.Windows.Forms.Label _lblProducts;
        private Guna.UI2.WinForms.Guna2Button _badgeStatus;
        private Guna.UI2.WinForms.Guna2Button _btnView;
    }
}