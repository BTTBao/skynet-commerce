namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    partial class UcOrderHistory
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTabs = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTabCancelled = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabCompleted = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabShipping = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabPending = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabAll = new Guna.UI2.WinForms.Guna2Button();
            this.separatorHeader = new Guna.UI2.WinForms.Guna2Separator();
            this.flowPanelOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.pnlTabs);
            this.pnlHeader.Controls.Add(this.separatorHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnTabCancelled);
            this.pnlTabs.Controls.Add(this.btnTabCompleted);
            this.pnlTabs.Controls.Add(this.btnTabShipping);
            this.pnlTabs.Controls.Add(this.btnTabPending);
            this.pnlTabs.Controls.Add(this.btnTabAll);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1000, 59);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnTabCancelled
            // 
            this.btnTabCancelled.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabCancelled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCancelled.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCancelled.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabCancelled.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCancelled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabCancelled.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnTabCancelled.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabCancelled.FillColor = System.Drawing.Color.White;
            this.btnTabCancelled.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabCancelled.ForeColor = System.Drawing.Color.Black;
            this.btnTabCancelled.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCancelled.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCancelled.Location = new System.Drawing.Point(640, 0);
            this.btnTabCancelled.Name = "btnTabCancelled";
            this.btnTabCancelled.Size = new System.Drawing.Size(160, 59);
            this.btnTabCancelled.TabIndex = 4;
            this.btnTabCancelled.Text = "Đã hủy";
            this.btnTabCancelled.Click += new System.EventHandler(this.OnTabClick);
            // 
            // btnTabCompleted
            // 
            this.btnTabCompleted.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabCompleted.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCompleted.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCompleted.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabCompleted.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCompleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabCompleted.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnTabCompleted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabCompleted.FillColor = System.Drawing.Color.White;
            this.btnTabCompleted.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabCompleted.ForeColor = System.Drawing.Color.Black;
            this.btnTabCompleted.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCompleted.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabCompleted.Location = new System.Drawing.Point(480, 0);
            this.btnTabCompleted.Name = "btnTabCompleted";
            this.btnTabCompleted.Size = new System.Drawing.Size(160, 59);
            this.btnTabCompleted.TabIndex = 3;
            this.btnTabCompleted.Text = "Hoàn thành";
            this.btnTabCompleted.Click += new System.EventHandler(this.OnTabClick);
            // 
            // btnTabShipping
            // 
            this.btnTabShipping.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabShipping.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabShipping.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabShipping.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabShipping.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabShipping.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabShipping.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnTabShipping.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabShipping.FillColor = System.Drawing.Color.White;
            this.btnTabShipping.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabShipping.ForeColor = System.Drawing.Color.Black;
            this.btnTabShipping.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabShipping.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabShipping.Location = new System.Drawing.Point(320, 0);
            this.btnTabShipping.Name = "btnTabShipping";
            this.btnTabShipping.Size = new System.Drawing.Size(160, 59);
            this.btnTabShipping.TabIndex = 2;
            this.btnTabShipping.Text = "Đang giao";
            this.btnTabShipping.Click += new System.EventHandler(this.OnTabClick);
            // 
            // btnTabPending
            // 
            this.btnTabPending.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabPending.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabPending.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabPending.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabPending.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabPending.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnTabPending.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabPending.FillColor = System.Drawing.Color.White;
            this.btnTabPending.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabPending.ForeColor = System.Drawing.Color.Black;
            this.btnTabPending.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabPending.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabPending.Location = new System.Drawing.Point(160, 0);
            this.btnTabPending.Name = "btnTabPending";
            this.btnTabPending.Size = new System.Drawing.Size(160, 59);
            this.btnTabPending.TabIndex = 1;
            this.btnTabPending.Text = "Chờ xác nhận";
            this.btnTabPending.Click += new System.EventHandler(this.OnTabClick);
            // 
            // btnTabAll
            // 
            this.btnTabAll.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabAll.Checked = true;
            this.btnTabAll.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabAll.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabAll.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabAll.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabAll.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnTabAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabAll.FillColor = System.Drawing.Color.White;
            this.btnTabAll.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabAll.ForeColor = System.Drawing.Color.Black;
            this.btnTabAll.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabAll.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTabAll.Location = new System.Drawing.Point(0, 0);
            this.btnTabAll.Name = "btnTabAll";
            this.btnTabAll.Size = new System.Drawing.Size(160, 59);
            this.btnTabAll.TabIndex = 0;
            this.btnTabAll.Text = "Tất cả";
            this.btnTabAll.Click += new System.EventHandler(this.OnTabClick);
            // 
            // separatorHeader
            // 
            this.separatorHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separatorHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.separatorHeader.Location = new System.Drawing.Point(0, 59);
            this.separatorHeader.Name = "separatorHeader";
            this.separatorHeader.Size = new System.Drawing.Size(1000, 1);
            this.separatorHeader.TabIndex = 0;
            // 
            // flowPanelOrders
            // 
            this.flowPanelOrders.AutoScroll = true;
            this.flowPanelOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.flowPanelOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelOrders.Location = new System.Drawing.Point(0, 60);
            this.flowPanelOrders.Name = "flowPanelOrders";
            this.flowPanelOrders.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelOrders.Size = new System.Drawing.Size(1000, 640);
            this.flowPanelOrders.TabIndex = 1;
            // 
            // UcOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelOrders);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcOrderHistory";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlTabs;
        private Guna.UI2.WinForms.Guna2Button btnTabAll;
        private Guna.UI2.WinForms.Guna2Button btnTabPending;
        private Guna.UI2.WinForms.Guna2Button btnTabShipping;
        private Guna.UI2.WinForms.Guna2Button btnTabCompleted;
        private Guna.UI2.WinForms.Guna2Button btnTabCancelled;
        private Guna.UI2.WinForms.Guna2Separator separatorHeader;
        private System.Windows.Forms.FlowLayoutPanel flowPanelOrders;
    }
}