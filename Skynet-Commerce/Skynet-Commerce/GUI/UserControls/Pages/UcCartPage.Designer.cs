namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcCartPage
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
            this.pnlContent.AutoScroll = true; // Cho phép cuộn dọc
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent"; // Tên phải khớp với tìm kiếm trong code logic
            this.pnlContent.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.TabIndex = 0;

            // 
            // UcCartPage (UserControl gốc)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent); // THÊM pnlContent VÀO USERCONTROL
            this.Name = "UcCartPage";
            this.Size = new System.Drawing.Size(1200, 800);
            this.ResumeLayout(false);
        }

        #endregion

        // Không cần khai báo lại pnlContent ở cuối file vì đã khai báo ở trên

    }
}