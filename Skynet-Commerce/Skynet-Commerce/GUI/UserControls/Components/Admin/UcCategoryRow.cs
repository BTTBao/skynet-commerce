using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcCategoryRow : UserControl
    {
        public UcCategoryRow()
        {
            InitializeComponent();
            // Kẻ đường gạch chân mờ
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
        }

        public void SetData(string id, string name, string totalProducts, string subcategories)
        {
            _lblId.Text = id;
            _lblName.Text = name;
            _lblProducts.Text = totalProducts;
            _lblSubcats.Text = subcategories;
        }
    }
}