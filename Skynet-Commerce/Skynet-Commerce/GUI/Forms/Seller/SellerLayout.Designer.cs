using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skynet_Commerce
{
    partial class SellerLayout
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

        private Image LoadImage(string fileName)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource");
            string fullPath = Path.Combine(basePath, fileName);

            if (File.Exists(fullPath))
                return Image.FromFile(fullPath);
            else
                return null;
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnOverview = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.White;
            this.sidebar.Controls.Add(this.btnSettings);
            this.sidebar.Controls.Add(this.btnOrders);
            this.sidebar.Controls.Add(this.btnProducts);
            this.sidebar.Controls.Add(this.btnOverview);
            this.sidebar.Controls.Add(this.titleLabel);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(350, 600);
            this.sidebar.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.Font = new System.Drawing.Font("Times New Roman", 16F);
            //this.btnSettings.Image = LoadImage("settings.png");
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 265);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(350, 55);
            this.btnSettings.Text = "    Cài đặt shop";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.BackColor = System.Drawing.Color.White;
            this.btnOrders.Font = new System.Drawing.Font("Times New Roman", 16F);
            //this.btnOrders.Image = LoadImage("order.png");
            this.btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.Location = new System.Drawing.Point(0, 210);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOrders.Size = new System.Drawing.Size(350, 55);
            this.btnOrders.Text = "    Quản lý đơn hàng";
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.BackColor = System.Drawing.Color.White;
            this.btnProducts.Font = new System.Drawing.Font("Times New Roman", 16F);
            //this.btnProducts.Image = LoadImage("product.png");
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(0, 155);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(350, 55);
            this.btnProducts.Text = "    Quản lý sản phẩm";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnOverview
            // 
            this.btnOverview.FlatAppearance.BorderSize = 0;
            this.btnOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverview.BackColor = System.Drawing.Color.White;
            this.btnOverview.Font = new System.Drawing.Font("Times New Roman", 16F);
            //this.btnOverview.Image = LoadImage("overview.png");
            this.btnOverview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOverview.Location = new System.Drawing.Point(0, 100);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOverview.Size = new System.Drawing.Size(350, 55);
            this.btnOverview.Text = "    Tổng quan shop";
            this.btnOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(0, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(350, 40);
            this.titleLabel.Text = "Kênh người bán";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleLabel.ForeColor = System.Drawing.Color.Orange;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(350, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1050, 600);

            // **btnLogout**
            // **Cấu hình nút Đăng xuất ở dưới cùng của sidebar**
            //
            this.btnLogout = new System.Windows.Forms.Button(); // Khởi tạo
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.BackColor = System.Drawing.Color.Red; // Màu nền đỏ nổi bật cho Đăng xuất
            this.btnLogout.ForeColor = System.Drawing.Color.White; // Màu chữ trắng
            this.btnLogout.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold); // In đậm
            //this.btnLogout.Image = LoadImage("logout.png"); // Có thể thêm icon
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, this.sidebar.Size.Height + 330); // Đặt ở vị trí dưới cùng (600 - 55 = 545)
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(350, 55);
            this.btnLogout.Text = "    Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click); // Gắn sự kiện Click

            // **Thêm nút vào sidebar**
            this.sidebar.Controls.Add(this.btnLogout);
            this.sidebar.Controls.SetChildIndex(this.btnLogout, 0); // Đảm bảo nút này nằm trên cùng
            // 
            // SellerLayout
            // 
            this.ClientSize = new System.Drawing.Size(1400, 600);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebar);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.sidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel contentPanel;
    }
}
