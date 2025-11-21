namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcInfoCard
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
            this._bgPanel = new Guna.UI2.WinForms.Guna2Panel();
            this._picIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this._lblTitle = new System.Windows.Forms.Label();
            this._lblValue = new System.Windows.Forms.Label();
            this._btnPercent = new Guna.UI2.WinForms.Guna2Button();
            this._bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // _bgPanel
            // 
            this._bgPanel.BackColor = System.Drawing.Color.White;
            this._bgPanel.BorderRadius = 12;
            this._bgPanel.Controls.Add(this._picIcon);
            this._bgPanel.Controls.Add(this._lblTitle);
            this._bgPanel.Controls.Add(this._lblValue);
            this._bgPanel.Controls.Add(this._btnPercent);
            this._bgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bgPanel.FillColor = System.Drawing.Color.White;
            this._bgPanel.Location = new System.Drawing.Point(0, 0);
            this._bgPanel.Name = "_bgPanel";
            this._bgPanel.ShadowDecoration.Depth = 10;
            this._bgPanel.ShadowDecoration.Enabled = true;
            this._bgPanel.Size = new System.Drawing.Size(220, 130);
            this._bgPanel.TabIndex = 0;
            // 
            // _picIcon
            // 
            this._picIcon.BorderRadius = 10;
            this._picIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this._picIcon.ImageRotate = 0F;
            this._picIcon.Location = new System.Drawing.Point(160, 15);
            this._picIcon.Name = "_picIcon";
            this._picIcon.Size = new System.Drawing.Size(45, 45);
            this._picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picIcon.TabIndex = 3;
            this._picIcon.TabStop = false;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblTitle.ForeColor = System.Drawing.Color.Gray;
            this._lblTitle.Location = new System.Drawing.Point(15, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(29, 15);
            this._lblTitle.TabIndex = 1;
            this._lblTitle.Text = "Title";
            // 
            // _lblValue
            // 
            this._lblValue.AutoSize = true;
            this._lblValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this._lblValue.ForeColor = System.Drawing.Color.Black;
            this._lblValue.Location = new System.Drawing.Point(15, 45);
            this._lblValue.Name = "_lblValue";
            this._lblValue.Size = new System.Drawing.Size(26, 30);
            this._lblValue.TabIndex = 2;
            this._lblValue.Text = "0";
            // 
            // _btnPercent
            // 
            this._btnPercent.BorderRadius = 10;
            this._btnPercent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._btnPercent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._btnPercent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._btnPercent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._btnPercent.FillColor = System.Drawing.Color.Transparent;
            this._btnPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnPercent.ForeColor = System.Drawing.Color.White;
            this._btnPercent.Location = new System.Drawing.Point(15, 85);
            this._btnPercent.Name = "_btnPercent";
            this._btnPercent.Size = new System.Drawing.Size(150, 25);
            this._btnPercent.TabIndex = 4;
            this._btnPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._btnPercent.TextOffset = new System.Drawing.Point(-5, 0);
            // 
            // UcInfoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._bgPanel);
            this.Name = "UcInfoCard";
            this.Size = new System.Drawing.Size(220, 130);
            this._bgPanel.ResumeLayout(false);
            this._bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel _bgPanel;
        private Guna.UI2.WinForms.Guna2PictureBox _picIcon;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblValue;
        private Guna.UI2.WinForms.Guna2Button _btnPercent;
    }
}