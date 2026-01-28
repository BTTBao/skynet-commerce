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
            this._pnlFraudAlert.Location = new System.Drawing.Point(30, 31);
            this._pnlFraudAlert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._pnlFraudAlert.Name = "_pnlFraudAlert";
            this._pnlFraudAlert.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this._pnlFraudAlert.Size = new System.Drawing.Size(1489, 92);
            this._pnlFraudAlert.TabIndex = 2;
            this._pnlFraudAlert.Visible = false;
            // 
            // _lblFraudAlert
            // 
            this._lblFraudAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblFraudAlert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblFraudAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this._lblFraudAlert.Location = new System.Drawing.Point(30, 15);
            this._lblFraudAlert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblFraudAlert.Name = "_lblFraudAlert";
            this._lblFraudAlert.Size = new System.Drawing.Size(1429, 62);
            this._lblFraudAlert.TabIndex = 0;
            this._lblFraudAlert.Text = "⚠️ Cảnh báo gian lận";
            this._lblFraudAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _statsContainer
            // 
            this._statsContainer.AutoScroll = true;
            this._statsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1515F));
            this._statsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this._statsContainer.Location = new System.Drawing.Point(30, 123);
            this._statsContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._statsContainer.Name = "_statsContainer";
            this._statsContainer.Size = new System.Drawing.Size(1489, 246);
            this._statsContainer.TabIndex = 0;
            // 
            // _chartsContainer
            // 
            this._chartsContainer.BackColor = System.Drawing.Color.Transparent;
            this._chartsContainer.ColumnCount = 2;
            this._chartsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._chartsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._chartsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this._chartsContainer.Location = new System.Drawing.Point(30, 369);
            this._chartsContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._chartsContainer.MinimumSize = new System.Drawing.Size(0, 769);
            this._chartsContainer.Name = "_chartsContainer";
            this._chartsContainer.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this._chartsContainer.RowCount = 1;
            this._chartsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 769F));
            this._chartsContainer.Size = new System.Drawing.Size(1489, 800);
            this._chartsContainer.TabIndex = 1;
            // 
            // DashboardOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1575, 1045);
            this.Controls.Add(this._chartsContainer);
            this.Controls.Add(this._statsContainer);
            this.Controls.Add(this._pnlFraudAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DashboardOverviewForm";
            this.Padding = new System.Windows.Forms.Padding(30, 31, 30, 31);
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