namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcProductDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            
            // 
            // pnlContent (Panel chính chứa toàn bộ nội dung, giúp dễ dàng cuộn)
            // 
            this.pnlContent.AutoScroll = true; 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 800); // Kích thước khung nhìn
            this.pnlContent.TabIndex = 0;
            
            // 
            // UcProductDetail (UserControl gốc)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "UcProductDetail";
            this.Size = new System.Drawing.Size(1200, 800);
            this.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
    }
}