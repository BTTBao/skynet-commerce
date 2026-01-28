namespace Skynet_Commerce.GUI.Forms
{
    partial class CategoryDetailForm
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
            this.components = new System.ComponentModel.Container();
            this._dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this._lblTitle = new System.Windows.Forms.Label();
            this._btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cboParent = new Guna.UI2.WinForms.Guna2ComboBox();
            this._btnSave = new Guna.UI2.WinForms.Guna2Button();
            this._btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _dragControl
            // 
            this._dragControl.TargetControl = this;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(20, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(188, 25);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Thông tin danh mục";
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.FillColor = System.Drawing.Color.Transparent;
            this._btnClose.IconColor = System.Drawing.Color.Gray;
            this._btnClose.Location = new System.Drawing.Point(350, 10);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(40, 29);
            this._btnClose.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên danh mục";
            // 
            // _txtName
            // 
            this._txtName.BorderRadius = 6;
            this._txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtName.DefaultText = "";
            this._txtName.Location = new System.Drawing.Point(30, 90);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(340, 36);
            this._txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh mục cha";
            // 
            // _cboParent
            // 
            this._cboParent.BackColor = System.Drawing.Color.Transparent;
            this._cboParent.BorderRadius = 6;
            this._cboParent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboParent.FocusedColor = System.Drawing.Color.Empty;
            this._cboParent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cboParent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._cboParent.ItemHeight = 30;
            this._cboParent.Location = new System.Drawing.Point(30, 160);
            this._cboParent.Name = "_cboParent";
            this._cboParent.Size = new System.Drawing.Size(340, 36);
            this._cboParent.TabIndex = 5;
            // 
            // _btnSave
            // 
            this._btnSave.BorderRadius = 6;
            this._btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnSave.ForeColor = System.Drawing.Color.White;
            this._btnSave.Location = new System.Drawing.Point(30, 230);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(160, 40);
            this._btnSave.TabIndex = 6;
            this._btnSave.Text = "Lưu lại";
            // 
            // _btnCancel
            // 
            this._btnCancel.BorderColor = System.Drawing.Color.Silver;
            this._btnCancel.BorderRadius = 6;
            this._btnCancel.BorderThickness = 1;
            this._btnCancel.FillColor = System.Drawing.Color.Transparent;
            this._btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this._btnCancel.Location = new System.Drawing.Point(210, 230);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(160, 40);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Hủy";
            // 
            // CategoryDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._cboParent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "CategoryDetailForm";
            this.Text = "CategoryDetailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl _dragControl;
        private Guna.UI2.WinForms.Guna2ControlBox _btnClose;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox _txtName;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox _cboParent;
        private Guna.UI2.WinForms.Guna2Button _btnSave;
        private Guna.UI2.WinForms.Guna2Button _btnCancel;
    }
}