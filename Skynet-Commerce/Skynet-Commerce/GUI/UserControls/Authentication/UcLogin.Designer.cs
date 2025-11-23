namespace Skynet_Commerce.GUI.Forms.User
{
    partial class UcLogin
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.userLb = new Guna.UI2.WinForms.Guna2TextBox();
            this.passLb = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegis = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.BorderColor = System.Drawing.Color.White;
            this.pnlContainer.BorderRadius = 10;
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.userLb);
            this.pnlContainer.Controls.Add(this.passLb);
            this.pnlContainer.Controls.Add(this.btnLogin);
            this.pnlContainer.Controls.Add(this.btnRegis);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.pnlContainer.ShadowDecoration.Depth = 10;
            this.pnlContainer.ShadowDecoration.Enabled = true;
            this.pnlContainer.Size = new System.Drawing.Size(400, 500);
            this.pnlContainer.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 140);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // userLb
            // 
            this.userLb.BorderRadius = 5;
            this.userLb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userLb.DefaultText = "";
            this.userLb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.userLb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.userLb.Location = new System.Drawing.Point(50, 200);
            this.userLb.Name = "userLb";
            this.userLb.PlaceholderText = "Email hoặc Tên đăng nhập";
            this.userLb.SelectedText = "";
            this.userLb.Size = new System.Drawing.Size(300, 45);
            this.userLb.TabIndex = 2;
            // 
            // passLb
            // 
            this.passLb.BorderRadius = 5;
            this.passLb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passLb.DefaultText = "";
            this.passLb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.passLb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.passLb.Location = new System.Drawing.Point(50, 260);
            this.passLb.Name = "passLb";
            this.passLb.PasswordChar = '●';
            this.passLb.PlaceholderText = "Mật khẩu";
            this.passLb.SelectedText = "";
            this.passLb.Size = new System.Drawing.Size(300, 45);
            this.passLb.TabIndex = 3;
            this.passLb.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(70)))), ((int)(((byte)(20)))));
            this.btnLogin.Location = new System.Drawing.Point(50, 330);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 45);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegis
            // 
            this.btnRegis.AutoSize = true;
            this.btnRegis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.btnRegis.ForeColor = System.Drawing.Color.Gray;
            this.btnRegis.Location = new System.Drawing.Point(115, 400);
            this.btnRegis.Name = "btnRegis";
            this.btnRegis.Size = new System.Drawing.Size(183, 15);
            this.btnRegis.TabIndex = 5;
            this.btnRegis.Text = "Chưa có tài khoản? Đăng ký ngay";
            this.btnRegis.Click += new System.EventHandler(this.btnRegis_Click);
            // 
            // UcLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlContainer);
            this.Name = "UcLogin";
            this.Size = new System.Drawing.Size(400, 500);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox userLb;
        private Guna.UI2.WinForms.Guna2TextBox passLb;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label btnRegis;
    }
}