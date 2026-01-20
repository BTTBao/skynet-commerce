using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerMainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        // Các thành phần giao diện
        private Guna2Panel panelSidebar;
        private Guna2Panel panelContainer;
        private Guna2Button btnDashboard;
        private Guna2Button btnProduct;
        private Guna2Button btnOrder;
        private Guna2Button btnVoucher;
        private Guna2Button btnShopInfo;
        private Guna2Button btnLogout;
        private Guna2PictureBox logoPictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new Guna2Panel();
            this.panelContainer = new Guna2Panel();
            this.logoPictureBox = new Guna2PictureBox();
            this.btnDashboard = new Guna2Button();
            this.btnProduct = new Guna2Button();
            this.btnOrder = new Guna2Button();
            this.btnVoucher = new Guna2Button();
            this.btnShopInfo = new Guna2Button();
            this.btnLogout = new Guna2Button();

            this.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();

            // 
            // panelSidebar
            // 
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.FillColor = Color.FromArgb(31, 30, 68);
            this.panelSidebar.Size = new Size(220, 650);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnShopInfo);
            this.panelSidebar.Controls.Add(this.btnVoucher);
            this.panelSidebar.Controls.Add(this.btnOrder);
            this.panelSidebar.Controls.Add(this.btnProduct);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.logoPictureBox); // logo trên cùng

            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Size = new Size(220, 120); // full chiều ngang của sidebar
            this.logoPictureBox.Location = new Point(0, 0); // top-left của sidebar
            this.logoPictureBox.Image = Properties.Resources.LOGO; // ảnh từ Resources
            this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // fill toàn bộ khối
            this.logoPictureBox.BackColor = Color.Transparent;

            // 
            // btnDashboard
            // 
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Size = new Size(220, 50);
            this.btnDashboard.Location = new Point(0, 120); // ngay dưới logo
            this.btnDashboard.FillColor = Color.Transparent;
            this.btnDashboard.ForeColor = Color.White;
            this.btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDashboard.HoverState.FillColor = Color.FromArgb(45, 45, 100);
            this.btnDashboard.TextAlign = HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new Point(20, 0);
            this.btnDashboard.Cursor = Cursors.Hand;

            // 
            // btnProduct
            // 
            this.btnProduct.Text = "Sản phẩm";
            this.btnProduct.Size = new Size(220, 50);
            this.btnProduct.Location = new Point(0, 170);
            this.btnProduct.FillColor = Color.Transparent;
            this.btnProduct.ForeColor = Color.White;
            this.btnProduct.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnProduct.HoverState.FillColor = Color.FromArgb(45, 45, 100);
            this.btnProduct.TextAlign = HorizontalAlignment.Left;
            this.btnProduct.TextOffset = new Point(20, 0);
            this.btnProduct.Cursor = Cursors.Hand;

            // 
            // btnOrder
            // 
            this.btnOrder.Text = "Đơn hàng";
            this.btnOrder.Size = new Size(220, 50);
            this.btnOrder.Location = new Point(0, 220);
            this.btnOrder.FillColor = Color.Transparent;
            this.btnOrder.ForeColor = Color.White;
            this.btnOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnOrder.HoverState.FillColor = Color.FromArgb(45, 45, 100);
            this.btnOrder.TextAlign = HorizontalAlignment.Left;
            this.btnOrder.TextOffset = new Point(20, 0);
            this.btnOrder.Cursor = Cursors.Hand;

            // 
            // btnVoucher
            // 
            this.btnVoucher.Text = "Voucher";
            this.btnVoucher.Size = new Size(220, 50);
            this.btnVoucher.Location = new Point(0, 270);
            this.btnVoucher.FillColor = Color.Transparent;
            this.btnVoucher.ForeColor = Color.White;
            this.btnVoucher.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnVoucher.HoverState.FillColor = Color.FromArgb(45, 45, 100);
            this.btnVoucher.TextAlign = HorizontalAlignment.Left;
            this.btnVoucher.TextOffset = new Point(20, 0);
            this.btnVoucher.Cursor = Cursors.Hand;

            // 
            // btnShopInfo
            // 
            this.btnShopInfo.Text = "Thông tin Shop";
            this.btnShopInfo.Size = new Size(220, 50);
            this.btnShopInfo.Location = new Point(0, 320);
            this.btnShopInfo.FillColor = Color.Transparent;
            this.btnShopInfo.ForeColor = Color.White;
            this.btnShopInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnShopInfo.HoverState.FillColor = Color.FromArgb(45, 45, 100);
            this.btnShopInfo.TextAlign = HorizontalAlignment.Left;
            this.btnShopInfo.TextOffset = new Point(20, 0);
            this.btnShopInfo.Cursor = Cursors.Hand;

            // 
            // btnLogout
            // 
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.FillColor = Color.FromArgb(255, 82, 82);
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Size = new Size(220, 50);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogout.Cursor = Cursors.Hand;

            // 
            // panelContainer
            // 
            this.panelContainer.Dock = DockStyle.Fill;
            this.panelContainer.BackColor = Color.FromArgb(240, 242, 245);

            // 
            // SellerMainForm
            // 
            this.ClientSize = new Size(1100, 650);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelSidebar);
            this.Name = "SellerMainForm";
            this.Text = "Skynet Ecommerce - Seller Panel";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
