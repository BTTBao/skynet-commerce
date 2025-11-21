namespace Skynet_Commerce.GUI.Forms.User
{
    partial class Form1
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
            this.ucOrderHistory1 = new Skynet_Commerce.GUI.UserControls.Pages.User.UcOrderHistory();
            this.SuspendLayout();
            // 
            // ucOrderHistory1
            // 
            this.ucOrderHistory1.Location = new System.Drawing.Point(35, 59);
            this.ucOrderHistory1.Name = "ucOrderHistory1";
            this.ucOrderHistory1.Size = new System.Drawing.Size(1000, 732);
            this.ucOrderHistory1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 880);
            this.Controls.Add(this.ucOrderHistory1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Pages.User.UcOrderHistory ucOrderHistory1;
    }
}