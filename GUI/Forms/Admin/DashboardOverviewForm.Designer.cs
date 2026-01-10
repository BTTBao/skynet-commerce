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
            this._statsContainer = new System.Windows.Forms.TableLayoutPanel();
            this._chartsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _statsContainer
            // 
            this._statsContainer.AutoScroll = true;
            this._statsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._statsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this._statsContainer.Location = new System.Drawing.Point(20, 20);
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
            this._chartsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chartsContainer.Location = new System.Drawing.Point(20, 180);
            this._chartsContainer.Name = "_chartsContainer";
            this._chartsContainer.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this._chartsContainer.RowCount = 1;
            this._chartsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._chartsContainer.Size = new System.Drawing.Size(1010, 479);
            this._chartsContainer.TabIndex = 1;
            // 
            // DashboardOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1050, 679);
            this.Controls.Add(this._chartsContainer);
            this.Controls.Add(this._statsContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardOverviewForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "DashboardOverviewForm";
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo biến Public/Private để bên code truy cập được
        public System.Windows.Forms.TableLayoutPanel _statsContainer;
        public System.Windows.Forms.TableLayoutPanel _chartsContainer;
    }
}