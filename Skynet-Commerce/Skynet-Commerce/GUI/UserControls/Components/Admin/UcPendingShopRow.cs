using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcPendingShopRow : UserControl
    {
        public UcPendingShopRow()
        {
            InitializeComponent();
            // Kẻ đường line mờ dưới đáy
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        public void SetData(string id, string name, string owner, string email, string date)
        {
            _lblId.Text = id;
            _lblName.Text = name;
            _lblOwner.Text = owner;
            _lblEmail.Text = email;
            _lblDate.Text = date;
        }
    }
}