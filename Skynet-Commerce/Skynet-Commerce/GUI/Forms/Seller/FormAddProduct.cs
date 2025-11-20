using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp11
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void btnAddVariant_Click(object sender, EventArgs e)
        {
            // Tạo một phân loại mới
            VariantControl vc = new VariantControl();
            vc.Dock = DockStyle.Top; // xếp chồng lên nhau
            panelVariants.Controls.Add(vc);
            panelVariants.Controls.SetChildIndex(vc, 0);
            vc.DeleteRequested += Variant_DeleteRequested;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sản phẩm
            string name = txtName.Text;
            string category = cmbCategory.Text;
            decimal price = numericPrice.Value;
            int stock = (int)numericStock.Value;
            string description = txtDescription.Text;

            // Lấy thông tin phân loại
            foreach (VariantControl vc in panelVariants.Controls)
            {
                string size = vc.SizeValue;
                string color = vc.ColorValue;
                string sku = vc.SKUValue;
                int quantity = vc.StockValue;
                decimal variantPrice = vc.PriceValue;

                // Xử lý lưu dữ liệu...
            }

            MessageBox.Show("Sản phẩm đã được thêm!");
        }

        private void Variant_DeleteRequested(object sender, EventArgs e)
        {
            // 1. Lấy ra UserControl cần xóa
            VariantControl variantToDelete = sender as VariantControl;

            if (variantToDelete != null)
            {
                // 2. Xóa control khỏi Panel
                panelVariants.Controls.Remove(variantToDelete);
                variantToDelete.Dispose(); // Giải phóng tài nguyên
            }
        }

    }
}
