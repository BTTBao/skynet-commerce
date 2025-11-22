namespace Skynet_Commerce.GUI.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this._sidebar = new Guna.UI2.WinForms.Guna2Panel();
            this._header = new Guna.UI2.WinForms.Guna2Panel();
            this._mainPanel = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this._sidebar.SuspendLayout();
            this._header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _sidebar
            // 
            this._sidebar.Controls.Add(this.guna2PictureBox1);
            this._sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this._sidebar.FillColor = System.Drawing.Color.White;
            this._sidebar.Location = new System.Drawing.Point(0, 0);
            this._sidebar.Name = "_sidebar";
            this._sidebar.ShadowDecoration.Depth = 10;
            this._sidebar.ShadowDecoration.Enabled = true;
            this._sidebar.Size = new System.Drawing.Size(250, 749);
            this._sidebar.TabIndex = 0;
            // 
            // _header
            // 
            this._header.Controls.Add(this.guna2HtmlLabel1);
            this._header.Dock = System.Windows.Forms.DockStyle.Top;
            this._header.FillColor = System.Drawing.Color.White;
            this._header.Location = new System.Drawing.Point(250, 0);
            this._header.Name = "_header";
            this._header.Size = new System.Drawing.Size(1050, 70);
            this._header.TabIndex = 1;
            // 
            // _mainPanel
            // 
            this._mainPanel.BackColor = System.Drawing.Color.Transparent;
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(250, 70);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(1050, 679);
            this._mainPanel.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(296, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(498, 51);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "ShopViet Admin Dashboard";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(13, 8);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(231, 58);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1300, 749);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._header);
            this.Controls.Add(this._sidebar);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarketPlace Admin";
            this._sidebar.ResumeLayout(false);
            this._header.ResumeLayout(false);
            this._header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo biến (đã có ở đây nên bên .cs không được khai báo lại)
        private Guna.UI2.WinForms.Guna2Panel _sidebar;
        private Guna.UI2.WinForms.Guna2Panel _header;
        public System.Windows.Forms.Panel _mainPanel; // Public để dễ truy cập nếu cần
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}