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
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._mainPanel = new System.Windows.Forms.Panel();
            this._header.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sidebar
            // 
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
            this._header.Controls.Add(this._txtSearch);
            this._header.Dock = System.Windows.Forms.DockStyle.Top;
            this._header.FillColor = System.Drawing.Color.White;
            this._header.Location = new System.Drawing.Point(250, 0);
            this._header.Name = "_header";
            this._header.Size = new System.Drawing.Size(1050, 70);
            this._header.TabIndex = 1;
            // 
            // _txtSearch
            // 
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(20, 17);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Search...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(300, 36);
            this._txtSearch.TabIndex = 0;
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
            this._header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo biến (đã có ở đây nên bên .cs không được khai báo lại)
        private Guna.UI2.WinForms.Guna2Panel _sidebar;
        private Guna.UI2.WinForms.Guna2Panel _header;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        public System.Windows.Forms.Panel _mainPanel; // Public để dễ truy cập nếu cần
    }
}