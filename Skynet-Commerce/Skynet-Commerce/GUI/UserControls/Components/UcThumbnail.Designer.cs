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
            // SỬA: BỎ KHAI BÁO NÀY KHỎI PHẦN FIELD (VÌ NÓ TỰ ĐỘNG KHAI BÁO LẠI BÊN DƯỚI)
            // this.pbThumbnail = new Guna.UI2.WinForms.Guna2PictureBox(); 

            // LƯU Ý: Nếu Designer Host cần khai báo, nó sẽ tự thêm lại, 
            // nhưng lỗi Ambiguity thường xuất phát từ việc thêm thủ công

            // ... (Phần InitializeComponent giữ nguyên)
        }

        #endregion
    }
}