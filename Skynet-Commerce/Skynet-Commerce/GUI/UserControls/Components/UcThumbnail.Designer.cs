// Trong UcThumbnail.Designer.cs (Đã xóa khai báo Field trùng lặp)

using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    // UcThumbnail sẽ kế thừa từ Guna2Panel trong file code-behind (.cs)
    partial class UcThumbnail
    {
        private System.ComponentModel.IContainer components = null;
        // KHÔNG CẦN KHAI BÁO pbThumbnail Ở ĐÂY NỮA

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
            this.thumbnailBox = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).BeginInit();
            this.SuspendLayout();

            // thumbnailBox
            this.thumbnailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thumbnailBox.Name = "thumbnailBox";
            this.thumbnailBox.TabStop = false;

            // Add Controls
            this.Controls.Add(this.thumbnailBox);

            ((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).EndInit();
            this.ResumeLayout(false);
        }
        private Guna2PictureBox thumbnailBox;

        #endregion
    }
}