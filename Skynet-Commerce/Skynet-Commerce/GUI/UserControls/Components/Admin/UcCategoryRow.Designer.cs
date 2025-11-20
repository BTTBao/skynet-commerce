namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcCategoryRow
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
            this._lblProducts = new System.Windows.Forms.Label();
            this._lblSubcats = new System.Windows.Forms.Label();
            this._btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this._btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblId.Location = new System.Drawing.Point(20, 18);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(52, 15);
            this._lblId.TabIndex = 0;
            this._lblId.Text = "CAT-001";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblName.Location = new System.Drawing.Point(150, 18);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(64, 15);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "Electronics";
            // 
            // _lblProducts
            // 
            this._lblProducts.AutoSize = true;
            this._lblProducts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblProducts.Location = new System.Drawing.Point(400, 18);
            this._lblProducts.Name = "_lblProducts";
            this._lblProducts.Size = new System.Drawing.Size(31, 15);
            this._lblProducts.TabIndex = 2;
            this._lblProducts.Text = "1234";
            // 
            // _lblSubcats
            // 
            this._lblSubcats.AutoSize = true;
            this._lblSubcats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblSubcats.Location = new System.Drawing.Point(600, 18);
            this._lblSubcats.Name = "_lblSubcats";
            this._lblSubcats.Size = new System.Drawing.Size(13, 15);
            this._lblSubcats.TabIndex = 3;
            this._lblSubcats.Text = "8";
            // 
            // _btnEdit
            // 
            this._btnEdit.FillColor = System.Drawing.Color.Transparent;
            this._btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._btnEdit.Location = new System.Drawing.Point(880, 10);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(70, 30);
            this._btnEdit.TabIndex = 4;
            this._btnEdit.Text = "📝 Edit";
            // 
            // _btnDelete
            // 
            this._btnDelete.FillColor = System.Drawing.Color.Transparent;
            this._btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._btnDelete.Location = new System.Drawing.Point(960, 10);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(80, 30);
            this._btnDelete.TabIndex = 5;
            this._btnDelete.Text = "🗑 Delete";
            // 
            // UcCategoryRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._lblSubcats);
            this.Controls.Add(this._lblProducts);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._lblId);
            this.Name = "UcCategoryRow";
            this.Size = new System.Drawing.Size(1050, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblProducts;
        private System.Windows.Forms.Label _lblSubcats;
        private Guna.UI2.WinForms.Guna2Button _btnEdit;
        private Guna.UI2.WinForms.Guna2Button _btnDelete;
    }
}