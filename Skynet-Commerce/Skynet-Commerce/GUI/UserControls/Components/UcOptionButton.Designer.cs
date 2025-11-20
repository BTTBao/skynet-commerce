using Guna.UI2.WinForms;
using System.Drawing;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    partial class UcOptionButton
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button btnOption;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        // Trong UcOptionButton.Designer.cs (Đã sửa lỗi)

        private void InitializeComponent()
        {
            this.btnOption = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnOption
            // 
            this.btnOption.BorderColor = System.Drawing.Color.Gray;
            this.btnOption.BorderRadius = 5;
            this.btnOption.BorderThickness = 1;
            this.btnOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOption.FillColor = System.Drawing.Color.White;
            this.btnOption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOption.ForeColor = System.Drawing.Color.Black;
            this.btnOption.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnOption.Location = new System.Drawing.Point(0, 0);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(80, 34);
            this.btnOption.TabIndex = 0;
            this.btnOption.Text = "Size X";
            // 
            // UcOptionButton
            // 
            this.Controls.Add(this.btnOption); // <<< GIỮ Controls.Add
            this.Name = "UcOptionButton";
            this.Size = new System.Drawing.Size(80, 34);
            this.ResumeLayout(false);

        }

        #endregion
    }
}