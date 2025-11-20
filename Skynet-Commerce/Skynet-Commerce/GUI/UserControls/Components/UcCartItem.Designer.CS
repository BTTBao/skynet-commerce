using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    partial class UcCartItem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chkSelect = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVariant = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnlQuantity = new System.Windows.Forms.Panel();
            this.btnDecrease = new Guna.UI2.WinForms.Guna2Button();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnIncrease = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.separator = new Guna.UI2.WinForms.Guna2Separator();
            this.pbProductImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.pnlQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSelect
            // 
            this.chkSelect.Checked = true;
            this.chkSelect.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.chkSelect.CheckedState.BorderRadius = 2;
            this.chkSelect.CheckedState.BorderThickness = 0;
            this.chkSelect.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.chkSelect.Location = new System.Drawing.Point(15, 45);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(20, 20);
            this.chkSelect.TabIndex = 10;
            this.chkSelect.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSelect.UncheckedState.BorderRadius = 2;
            this.chkSelect.UncheckedState.BorderThickness = 0;
            this.chkSelect.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProductName.Location = new System.Drawing.Point(150, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(220, 45);
            this.lblProductName.TabIndex = 11;
            this.lblProductName.Text = "Áo khoác denim thời trang";
            // 
            // lblVariant
            // 
            this.lblVariant.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVariant.ForeColor = System.Drawing.Color.Gray;
            this.lblVariant.Location = new System.Drawing.Point(150, 65);
            this.lblVariant.Name = "lblVariant";
            this.lblVariant.Size = new System.Drawing.Size(200, 20);
            this.lblVariant.TabIndex = 12;
            this.lblVariant.Text = "Phân loại: Xanh, Size M";
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(380, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 20);
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "450.000₫";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlQuantity
            // 
            this.pnlQuantity.Controls.Add(this.btnDecrease);
            this.pnlQuantity.Controls.Add(this.txtQuantity);
            this.pnlQuantity.Controls.Add(this.btnIncrease);
            this.pnlQuantity.Location = new System.Drawing.Point(500, 40);
            this.pnlQuantity.Name = "pnlQuantity";
            this.pnlQuantity.Size = new System.Drawing.Size(100, 30);
            this.pnlQuantity.TabIndex = 14;
            // 
            // btnDecrease
            // 
            this.btnDecrease.BorderColor = System.Drawing.Color.Silver;
            this.btnDecrease.BorderThickness = 1;
            this.btnDecrease.FillColor = System.Drawing.Color.White;
            this.btnDecrease.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDecrease.ForeColor = System.Drawing.Color.Black;
            this.btnDecrease.Location = new System.Drawing.Point(0, 0);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(30, 30);
            this.btnDecrease.TabIndex = 0;
            this.btnDecrease.Text = "-";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderColor = System.Drawing.Color.Silver;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "1";
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuantity.Location = new System.Drawing.Point(29, 0);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PlaceholderText = "";
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.Size = new System.Drawing.Size(42, 30);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnIncrease
            // 
            this.btnIncrease.BorderColor = System.Drawing.Color.Silver;
            this.btnIncrease.BorderThickness = 1;
            this.btnIncrease.FillColor = System.Drawing.Color.White;
            this.btnIncrease.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIncrease.ForeColor = System.Drawing.Color.Black;
            this.btnIncrease.Location = new System.Drawing.Point(70, 0);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(30, 30);
            this.btnIncrease.TabIndex = 2;
            this.btnIncrease.Text = "+";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(620, 45);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(120, 20);
            this.lblTotalPrice.TabIndex = 15;
            this.lblTotalPrice.Text = "900.000₫";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // separator
            // 
            this.separator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.separator.Location = new System.Drawing.Point(0, 100);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(800, 10);
            this.separator.TabIndex = 17;
            // 
            // pbProductImage
            // 
            this.pbProductImage.BorderRadius = 5;
            this.pbProductImage.ImageRotate = 0F;
            this.pbProductImage.Location = new System.Drawing.Point(50, 15);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(80, 80);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProductImage.TabIndex = 0;
            this.pbProductImage.TabStop = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = global::Skynet_Commerce.Properties.Resources.trash;
            this.btnRemove.FillColor = System.Drawing.Color.Transparent;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Image = global::Skynet_Commerce.Properties.Resources.trash;
            this.btnRemove.Location = new System.Drawing.Point(746, 29);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(45, 41);
            this.btnRemove.TabIndex = 16;
            // 
            // UcCartItem
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.pbProductImage);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblVariant);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.pnlQuantity);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.separator);
            this.Name = "UcCartItem";
            this.Size = new System.Drawing.Size(800, 110);
            this.pnlQuantity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        // KHAI BÁO BIẾN
        private Guna2CustomCheckBox chkSelect; // <<< Biến mới
        private Guna2PictureBox pbProductImage;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblVariant;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Panel pnlQuantity;
        private Guna2Button btnDecrease;
        private Guna2TextBox txtQuantity;
        private Guna2Button btnIncrease;
        private System.Windows.Forms.Label lblTotalPrice;
        private Guna2Button btnRemove;
        private Guna2Separator separator;
    }
}