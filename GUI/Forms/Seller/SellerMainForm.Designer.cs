using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerMainForm
    {
        private System.ComponentModel.IContainer components = null;
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
            if (disposing && (components != null)) components.Dispose();
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

            // panelSidebar
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.FillColor = Color.FromArgb(31, 30, 68);
            this.panelSidebar.Size = new Size(220, 750);
            this.panelSidebar.Controls.Add(this.btnShopInfo);
            this.panelSidebar.Controls.Add(this.btnVoucher);
            this.panelSidebar.Controls.Add(this.btnOrder);
            this.panelSidebar.Controls.Add(this.btnProduct);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.logoPictureBox);
            this.panelSidebar.Controls.Add(this.btnLogout);

            // logoPictureBox
            this.logoPictureBox.Size = new Size(220, 120);
            this.logoPictureBox.Location = new Point(0, 0);
            this.logoPictureBox.Image = Properties.Resources.LOGO;
            this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.BackColor = Color.Transparent;

            // Hàm hỗ trợ thiết lập Style chung cho các nút Sidebar
            void ConfigureButtonStyle(Guna2Button btn, int yPos, string text)
            {
                btn.Text = text;
                btn.Size = new Size(220, 50);
                btn.Location = new Point(0, yPos);
                btn.FillColor = Color.FromArgb(31, 30, 68);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F);
                btn.TextAlign = HorizontalAlignment.Left;
                btn.TextOffset = new Point(20, 0);
                btn.Cursor = Cursors.Hand;
                btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton; // Chế độ chọn 1

                // Trạng thái khi được chọn (Active)
                btn.CheckedState.FillColor = Color.FromArgb(45, 45, 120); // Xanh đậm hơn
                btn.CheckedState.ForeColor = Color.White;
                btn.CheckedState.Font = new Font("Segoe UI", 10F, FontStyle.Bold); // Chữ in đậm

                // Trạng thái khi di chuột qua (Hover)
                btn.HoverState.FillColor = Color.FromArgb(45, 45, 100);
            }

            ConfigureButtonStyle(btnDashboard, 120, "Dashboard");
            ConfigureButtonStyle(btnProduct, 170, "Sản phẩm");
            ConfigureButtonStyle(btnOrder, 220, "Đơn hàng");
            ConfigureButtonStyle(btnShopInfo, 270, "Thông tin Shop");

            // btnLogout
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.FillColor = Color.FromArgb(255, 82, 82);
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Size = new Size(220, 50);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // panelContainer
            this.panelContainer.Dock = DockStyle.Fill;
            this.panelContainer.BackColor = Color.FromArgb(240, 242, 245);

            // SellerMainForm
            this.ClientSize = new Size(1300, 750);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelSidebar);
            this.Name = "SellerMainForm";
            this.Text = "Skynet Ecommerce - Seller Panel";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }
    }
}