namespace Skynet_Commerce.GUI.Forms
{
    partial class DashboardOverviewForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pnlFraudAlert = new Guna.UI2.WinForms.Guna2Panel();
            this._lblFraudAlert = new System.Windows.Forms.Label();
            this._statsContainer = new System.Windows.Forms.TableLayoutPanel();
            this._chartsContainer = new System.Windows.Forms.TableLayoutPanel();
            this._pnlFraudAlert.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlFraudAlert
            // 
            this._pnlFraudAlert.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this._pnlFraudAlert.BorderThickness = 2;
            this._pnlFraudAlert.Controls.Add(this._lblFraudAlert);
            this._pnlFraudAlert.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlFraudAlert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this._pnlFraudAlert.Location = new System.Drawing.Point(20, 20);
            this._pnlFraudAlert.Name = "_pnlFraudAlert";
            this._pnlFraudAlert.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this._pnlFraudAlert.Size = new System.Drawing.Size(1010, 60);
            this._pnlFraudAlert.TabIndex = 2;
            this._pnlFraudAlert.Visible = false;
            // 
            // _lblFraudAlert
            // 
            this._lblFraudAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblFraudAlert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblFraudAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this._lblFraudAlert.Location = new System.Drawing.Point(20, 10);
            this._lblFraudAlert.Name = "_lblFraudAlert";
            this._lblFraudAlert.Size = new System.Drawing.Size(970, 40);
            this._lblFraudAlert.TabIndex = 0;
            this._lblFraudAlert.Text = "⚠️ Cảnh báo gian lận";
            this._lblFraudAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _statsContainer
            // 
            this._statsContainer.AutoScroll = true;
            this._statsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._statsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this._statsContainer.Location = new System.Drawing.Point(20, 80);
            this._statsContainer.Name = "_statsContainer";
            this._statsContainer.Size = new System.Drawing.Size(1010, 160);
            this._statsContainer.TabIndex = 0;
            // 
            // _chartsContainer
            // 
            this._chartsContainer.BackColor = System.Drawing.Color.Transparent;
            this._chartsContainer.ColumnCount = 2;
            this._chartsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._chartsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._chartsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this._chartsContainer.Location = new System.Drawing.Point(20, 240);
            this._chartsContainer.MinimumSize = new System.Drawing.Size(0, 500);
            this._chartsContainer.Name = "_chartsContainer";
            this._chartsContainer.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this._chartsContainer.RowCount = 1;
            this._chartsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this._chartsContainer.Size = new System.Drawing.Size(1010, 520);
            this._chartsContainer.TabIndex = 1;
            // 
            // DashboardOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1050, 679);
            this.Controls.Add(this._chartsContainer);
            this.Controls.Add(this._statsContainer);
            this.Controls.Add(this._pnlFraudAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardOverviewForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "DashboardOverviewForm";
            this._pnlFraudAlert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo biến Public/Private để bên code truy cập được
        private Guna.UI2.WinForms.Guna2Panel _pnlFraudAlert;
        private System.Windows.Forms.Label _lblFraudAlert;
        public System.Windows.Forms.TableLayoutPanel _statsContainer;
        public System.Windows.Forms.TableLayoutPanel _chartsContainer;
    }
}