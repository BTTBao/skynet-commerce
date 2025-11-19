using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcActiveShopRow : UserControl
    {
        public UcActiveShopRow()
        {
            InitializeComponent();
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        public void SetData(string id, string name, string owner, string rating, string products, string status)
        {
            _lblId.Text = id;
            _lblName.Text = name;
            _lblOwner.Text = owner;
            _lblRating.Text = "★ " + rating;
            _lblProducts.Text = products;
            _badgeStatus.Text = status;

            if (status == "Active")
            {
                _badgeStatus.FillColor = Color.FromArgb(79, 70, 229); // Xanh tím
            }
            else // Suspended
            {
                _badgeStatus.FillColor = Color.FromArgb(220, 38, 38); // Đỏ
            }
        }
    }
}