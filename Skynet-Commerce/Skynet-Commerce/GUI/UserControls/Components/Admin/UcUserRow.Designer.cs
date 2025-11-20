namespace Skynet_Commerce.GUI.UserControls
{
    partial class UcUserRow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this._lblId = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._lblEmail = new System.Windows.Forms.Label();
            this._lblPhone = new System.Windows.Forms.Label();
            this._btnRole = new Guna.UI2.WinForms.Guna2Button();
            this._btnStatus = new Guna.UI2.WinForms.Guna2Button();
            this._btnView = new Guna.UI2.WinForms.Guna2Button();
            this._btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this._btnBan = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblId.ForeColor = System.Drawing.Color.Black;
            this._lblId.Location = new System.Drawing.Point(20, 18);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(51, 15);
            this._lblId.TabIndex = 0;
            this._lblId.Text = "USR-001";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblName.ForeColor = System.Drawing.Color.Black;
            this._lblName.Location = new System.Drawing.Point(100, 18);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(56, 15);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "John Doe";
            // 
            // _lblEmail
            // 
            this._lblEmail.AutoSize = true;
            this._lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmail.ForeColor = System.Drawing.Color.Black;
            this._lblEmail.Location = new System.Drawing.Point(250, 18);
            this._lblEmail.Name = "_lblEmail";
            this._lblEmail.Size = new System.Drawing.Size(114, 15);
            this._lblEmail.TabIndex = 2;
            this._lblEmail.Text = "john@example.com";
            // 
            // _lblPhone
            // 
            this._lblPhone.AutoSize = true;
            this._lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblPhone.ForeColor = System.Drawing.Color.Black;
            this._lblPhone.Location = new System.Drawing.Point(450, 18);
            this._lblPhone.Name = "_lblPhone";
            this._lblPhone.Size = new System.Drawing.Size(75, 15);
            this._lblPhone.TabIndex = 3;
            this._lblPhone.Text = "+1234567890";
            // 
            // _btnRole
            // 
            this._btnRole.BorderRadius = 10;
            this._btnRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._btnRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._btnRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._btnRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._btnRole.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this._btnRole.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._btnRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this._btnRole.Location = new System.Drawing.Point(578, 14);
            this._btnRole.Name = "_btnRole";
            this._btnRole.Size = new System.Drawing.Size(74, 24);
            this._btnRole.TabIndex = 4;
            this._btnRole.Text = "Buyer";
            // 
            // _btnStatus
            // 
            this._btnStatus.BorderRadius = 10;
            this._btnStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._btnStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._btnStatus.ForeColor = System.Drawing.Color.White;
            this._btnStatus.Location = new System.Drawing.Point(720, 14);
            this._btnStatus.Name = "_btnStatus";
            this._btnStatus.Size = new System.Drawing.Size(60, 24);
            this._btnStatus.TabIndex = 5;
            this._btnStatus.Text = "Active";
            // 
            // _btnView
            // 
            this._btnView.BorderColor = System.Drawing.Color.Transparent;
            this._btnView.FillColor = System.Drawing.Color.Transparent;
            this._btnView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._btnView.ForeColor = System.Drawing.Color.Black;
            this._btnView.Location = new System.Drawing.Point(830, 14);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(60, 24);
            this._btnView.TabIndex = 6;
            this._btnView.Text = "View";
            // 
            // _btnEdit
            // 
            this._btnEdit.FillColor = System.Drawing.Color.Transparent;
            this._btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._btnEdit.ForeColor = System.Drawing.Color.Black;
            this._btnEdit.Location = new System.Drawing.Point(890, 14);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(50, 24);
            this._btnEdit.TabIndex = 7;
            this._btnEdit.Text = "Edit";
            // 
            // _btnBan
            // 
            this._btnBan.FillColor = System.Drawing.Color.Transparent;
            this._btnBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._btnBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._btnBan.Location = new System.Drawing.Point(940, 14);
            this._btnBan.Name = "_btnBan";
            this._btnBan.Size = new System.Drawing.Size(50, 24);
            this._btnBan.TabIndex = 8;
            this._btnBan.Text = "Ban";
            // 
            // UcUserRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnBan);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._btnStatus);
            this.Controls.Add(this._btnRole);
            this.Controls.Add(this._lblPhone);
            this.Controls.Add(this._lblEmail);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._lblId);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UcUserRow";
            this.Size = new System.Drawing.Size(1020, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblEmail;
        private System.Windows.Forms.Label _lblPhone;
        private Guna.UI2.WinForms.Guna2Button _btnRole;
        private Guna.UI2.WinForms.Guna2Button _btnStatus;
        private Guna.UI2.WinForms.Guna2Button _btnView;
        private Guna.UI2.WinForms.Guna2Button _btnEdit;
        private Guna.UI2.WinForms.Guna2Button _btnBan;
    }
}