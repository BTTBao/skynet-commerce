namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcProductRow
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
            this._picImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this._lblName = new System.Windows.Forms.Label();
            this._lblId = new System.Windows.Forms.Label();
            this._lblShop = new System.Windows.Forms.Label();
            this._lblCategory = new System.Windows.Forms.Label();
            this._lblPrice = new System.Windows.Forms.Label();
            this._lblStock = new System.Windows.Forms.Label();
            this._badgeStatus = new Guna.UI2.WinForms.Guna2Button();
            this._btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this._btnToggle = new Guna.UI2.WinForms.Guna2Button();
            this._btnDelete = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this._picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _picImage
            // 
            this._picImage.BorderRadius = 8;
            this._picImage.FillColor = System.Drawing.Color.LightGray;
            this._picImage.ImageRotate = 0F;
            this._picImage.Location = new System.Drawing.Point(20, 10);
            this._picImage.Name = "_picImage";
            this._picImage.Size = new System.Drawing.Size(50, 50);
            this._picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picImage.TabIndex = 0;
            this._picImage.TabStop = false;
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblName.Location = new System.Drawing.Point(85, 15);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(126, 15);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "Wireless Headphones";
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._lblId.ForeColor = System.Drawing.Color.Gray;
            this._lblId.Location = new System.Drawing.Point(85, 35);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(50, 13);
            this._lblId.TabIndex = 2;
            this._lblId.Text = "PRD-001";
            // 
            // _lblShop
            // 
            this._lblShop.AutoSize = true;
            this._lblShop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblShop.Location = new System.Drawing.Point(260, 25);
            this._lblShop.Name = "_lblShop";
            this._lblShop.Size = new System.Drawing.Size(58, 15);
            this._lblShop.TabIndex = 3;
            this._lblShop.Text = "TechStore";
            // 
            // _lblCategory
            // 
            this._lblCategory.AutoSize = true;
            this._lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblCategory.Location = new System.Drawing.Point(390, 25);
            this._lblCategory.Name = "_lblCategory";
            this._lblCategory.Size = new System.Drawing.Size(64, 15);
            this._lblCategory.TabIndex = 4;
            this._lblCategory.Text = "Electronics";
            // 
            // _lblPrice
            // 
            this._lblPrice.AutoSize = true;
            this._lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblPrice.Location = new System.Drawing.Point(500, 25);
            this._lblPrice.Name = "_lblPrice";
            this._lblPrice.Size = new System.Drawing.Size(52, 15);
            this._lblPrice.TabIndex = 5;
            this._lblPrice.Text = "$129.99";
            // 
            // _lblStock
            // 
            this._lblStock.AutoSize = true;
            this._lblStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblStock.Location = new System.Drawing.Point(589, 25);
            this._lblStock.Name = "_lblStock";
            this._lblStock.Size = new System.Drawing.Size(19, 15);
            this._lblStock.TabIndex = 6;
            this._lblStock.Text = "45";
            // 
            // _badgeStatus
            // 
            this._badgeStatus.BorderRadius = 10;
            this._badgeStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._badgeStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._badgeStatus.ForeColor = System.Drawing.Color.White;
            this._badgeStatus.Location = new System.Drawing.Point(653, 22);
            this._badgeStatus.Name = "_badgeStatus";
            this._badgeStatus.Size = new System.Drawing.Size(90, 24);
            this._badgeStatus.TabIndex = 7;
            this._badgeStatus.Text = "Còn hàng";
            // 
            // _btnEdit
            // 
            this._btnEdit.FillColor = System.Drawing.Color.Transparent;
            this._btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnEdit.ForeColor = System.Drawing.Color.DimGray;
            this._btnEdit.Location = new System.Drawing.Point(763, 20);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(65, 30);
            this._btnEdit.TabIndex = 8;
            this._btnEdit.Text = "✎ Sửa";
            // 
            // _btnToggle
            // 
            this._btnToggle.FillColor = System.Drawing.Color.Transparent;
            this._btnToggle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnToggle.ForeColor = System.Drawing.Color.DimGray;
            this._btnToggle.Location = new System.Drawing.Point(839, 20);
            this._btnToggle.Name = "_btnToggle";
            this._btnToggle.Size = new System.Drawing.Size(56, 30);
            this._btnToggle.TabIndex = 9;
            this._btnToggle.Text = "Ø Ẩn";
            // 
            // _btnDelete
            // 
            this._btnDelete.FillColor = System.Drawing.Color.Transparent;
            this._btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._btnDelete.Location = new System.Drawing.Point(895, 20);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(66, 30);
            this._btnDelete.TabIndex = 10;
            this._btnDelete.Text = "🗑 Xoá";
            // 
            // UcProductRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnToggle);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._badgeStatus);
            this.Controls.Add(this._lblStock);
            this.Controls.Add(this._lblPrice);
            this.Controls.Add(this._lblCategory);
            this.Controls.Add(this._lblShop);
            this.Controls.Add(this._lblId);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._picImage);
            this.Name = "UcProductRow";
            this.Size = new System.Drawing.Size(1010, 70);
            ((System.ComponentModel.ISupportInitialize)(this._picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox _picImage;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblShop;
        private System.Windows.Forms.Label _lblCategory;
        private System.Windows.Forms.Label _lblPrice;
        private System.Windows.Forms.Label _lblStock;
        private Guna.UI2.WinForms.Guna2Button _badgeStatus;
        private Guna.UI2.WinForms.Guna2Button _btnEdit;
        private Guna.UI2.WinForms.Guna2Button _btnToggle;
        private Guna.UI2.WinForms.Guna2Button _btnDelete;
    }
}