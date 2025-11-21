using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcCategoryRow : UserControl
    {
        // Định nghĩa sự kiện
        public event EventHandler OnEditClicked;
        public event EventHandler OnDeleteClicked;

        // Lưu ID
        public int CategoryID { get; private set; }
        public UcCategoryRow()
        {
            InitializeComponent();
            // Kẻ đường gạch chân mờ
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };
            // Gắn sự kiện
            _btnEdit.Click += (s, e) => OnEditClicked?.Invoke(this, EventArgs.Empty);
            _btnDelete.Click += (s, e) => OnDeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetData(int id, string name, string totalProducts, string subcategories)
        {
            this.CategoryID = id;

            _lblId.Text = id.ToString();
            _lblName.Text = name;
            _lblProducts.Text = totalProducts;
            _lblSubcats.Text = subcategories;
        }
    }
}