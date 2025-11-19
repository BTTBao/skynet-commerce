using Skynet_Commerce.Properties;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    partial class UcCategoryItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlIconContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pbIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.pnlIconContainer.SuspendLayout();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCategoryItem));
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIconContainer
            // 
            this.pnlIconContainer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlIconContainer.BorderRadius = 8;
            this.pnlIconContainer.Controls.Add(this.pbIcon);
            this.pnlIconContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlIconContainer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(230))))); // Màu nền ví dụ (Hồng nhạt)
            this.pnlIconContainer.Location = new System.Drawing.Point(30, 5); // Căn giữa 120 - 60 / 2 = 30
            this.pnlIconContainer.Name = "pnlIconContainer";
            this.pnlIconContainer.ShadowDecoration.BorderRadius = 8;
            this.pnlIconContainer.ShadowDecoration.Enabled = true;
            this.pnlIconContainer.ShadowDecoration.Parent = this.pnlIconContainer;
            this.pnlIconContainer.Size = new System.Drawing.Size(60, 60);
            this.pnlIconContainer.TabIndex = 0;
            // 
            // pbIcon
            // 
            this.pbIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
       
            this.pbIcon.Location = new System.Drawing.Point(15, 15);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.ShadowDecoration.Parent = this.pbIcon;
            this.pbIcon.Size = new System.Drawing.Size(30, 30);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategoryName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(5, 75);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(110, 35);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "Thời trang";
            this.lblCategoryName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UcCategoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.pnlIconContainer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UcCategoryItem";
            this.Size = new System.Drawing.Size(120, 120);
            this.pnlIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlIconContainer;
        private Guna.UI2.WinForms.Guna2PictureBox pbIcon;
        private System.Windows.Forms.Label lblCategoryName;
    }
}