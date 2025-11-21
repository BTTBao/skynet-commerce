namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcPendingShopRow
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
            this._lblEmail = new System.Windows.Forms.Label();
            this._lblDate = new System.Windows.Forms.Label();
            this._btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this._btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblId.Location = new System.Drawing.Point(35, 18);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(62, 15);
            this._lblId.TabIndex = 0;
            this._lblId.Text = "SHOP-P01";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblName.Location = new System.Drawing.Point(120, 18);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(101, 15);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "TechGadgets Pro";
            // 
            // _lblOwner
            // 
            this._lblOwner.AutoSize = true;
            this._lblOwner.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblOwner.Location = new System.Drawing.Point(280, 18);
            this._lblOwner.Name = "_lblOwner";
            this._lblOwner.Size = new System.Drawing.Size(80, 15);
            this._lblOwner.TabIndex = 2;
            this._lblOwner.Text = "Alice Johnson";
            // 
            // _lblEmail
            // 
            this._lblEmail.AutoSize = true;
            this._lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblEmail.ForeColor = System.Drawing.Color.DimGray;
            this._lblEmail.Location = new System.Drawing.Point(420, 18);
            this._lblEmail.Name = "_lblEmail";
            this._lblEmail.Size = new System.Drawing.Size(134, 15);
            this._lblEmail.TabIndex = 3;
            this._lblEmail.Text = "alice@techgadgets.com";
            // 
            // _lblDate
            // 
            this._lblDate.AutoSize = true;
            this._lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblDate.Location = new System.Drawing.Point(599, 18);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(65, 15);
            this._lblDate.TabIndex = 4;
            this._lblDate.Text = "2025-11-15";
            // 
            // _btnApprove
            // 
            this._btnApprove.BorderRadius = 6;
            this._btnApprove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this._btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnApprove.ForeColor = System.Drawing.Color.White;
            this._btnApprove.Location = new System.Drawing.Point(779, 10);
            this._btnApprove.Name = "_btnApprove";
            this._btnApprove.Size = new System.Drawing.Size(97, 30);
            this._btnApprove.TabIndex = 5;
            this._btnApprove.Text = "✓ Chấp nhận";
            this._btnApprove.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // _btnReject
            // 
            this._btnReject.BorderRadius = 6;
            this._btnReject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnReject.ForeColor = System.Drawing.Color.White;
            this._btnReject.Location = new System.Drawing.Point(882, 10);
            this._btnReject.Name = "_btnReject";
            this._btnReject.Size = new System.Drawing.Size(82, 30);
            this._btnReject.TabIndex = 6;
            this._btnReject.Text = "✕ Từ chối";
            // 
            // UcPendingShopRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnReject);
            this.Controls.Add(this._btnApprove);
            this.Controls.Add(this._lblDate);
            this.Controls.Add(this._lblEmail);
            this.Controls.Add(this._lblOwner);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._lblId);
            this.Name = "UcPendingShopRow";
            this.Size = new System.Drawing.Size(1008, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblOwner;
        private System.Windows.Forms.Label _lblEmail;
        private System.Windows.Forms.Label _lblDate;
        private Guna.UI2.WinForms.Guna2Button _btnApprove;
        private Guna.UI2.WinForms.Guna2Button _btnReject;
    }
}