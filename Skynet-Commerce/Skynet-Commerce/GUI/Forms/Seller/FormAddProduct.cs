using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Skynet_Commerce
{
    public partial class FormAddProduct : Form
    {
        private List<string> uploadedImages = new List<string>();
        private const int MAX_IMAGES = 5;
        private const int THUMBNAIL_SIZE = 100;
        private const int THUMBNAIL_MARGIN = 10;
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
            decimal price = decimal.Parse(numericPrice.Text.ToString());
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


        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (panelImages.Controls.Count >= MAX_IMAGES)
            {
                MessageBox.Show($"Chỉ được phép tải lên tối đa {MAX_IMAGES} hình ảnh.", "Giới hạn ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Chọn ảnh sản phẩm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                AddImageThumbnail(imagePath);
            }
        }

        private void AddImageThumbnail(string imagePath)
        {
            // 1. Tạo PictureBox Guna2 để chứa ảnh
            Guna2PictureBox pb = new Guna2PictureBox();
            pb.Size = new Size(THUMBNAIL_SIZE, THUMBNAIL_SIZE);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderRadius = 8;
            pb.Cursor = Cursors.Hand;
            pb.Tag = imagePath; // Lưu đường dẫn file vào Tag

            try
            {
                // Sử dụng Stream để tạo ảnh, tránh khóa file
                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    pb.Image = new Bitmap(Image.FromStream(fs));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Gán sự kiện Click để Xóa ảnh
            pb.Click += ImageThumbnail_Click;

            // 3. Thêm vào Panel và sắp xếp
            panelImages.Controls.Add(pb);
            RelayoutImageControls();

            uploadedImages.Add(imagePath);
        }

        private void ImageThumbnail_Click(object sender, EventArgs e)
        {
            // Sự kiện này dùng để xóa ảnh khi click vào thumbnail
            Guna2PictureBox clickedImage = sender as Guna2PictureBox;
            if (clickedImage != null)
            {
                var result = MessageBox.Show("Bạn có muốn xóa ảnh này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 1. Xóa khỏi danh sách theo dõi
                    string imagePath = clickedImage.Tag.ToString();
                    uploadedImages.Remove(imagePath);

                    // 2. Xóa khỏi Panel và giải phóng tài nguyên
                    panelImages.Controls.Remove(clickedImage);
                    clickedImage.Dispose();

                    // 3. Sắp xếp lại
                    RelayoutImageControls();
                }
            }
        }

        private void RelayoutImageControls()
        {
            int x = THUMBNAIL_MARGIN;
            int y = THUMBNAIL_MARGIN;

            // Kích thước của Panel chứa ảnh là 450. 
            // 450 / 110 (100 size + 10 margin) = 4 ảnh/hàng
            int controlsPerRow = (panelImages.Width - THUMBNAIL_MARGIN) / (THUMBNAIL_SIZE + THUMBNAIL_MARGIN);

            if (controlsPerRow < 1) controlsPerRow = 1; // Bảo vệ

            int count = 0;

            foreach (Control control in panelImages.Controls.OfType<Guna2PictureBox>())
            {
                control.Location = new Point(x, y);

                x += THUMBNAIL_SIZE + THUMBNAIL_MARGIN;
                count++;

                // Nếu đủ số ảnh trên một hàng, chuyển sang hàng mới
                if (count % controlsPerRow == 0)
                {
                    x = THUMBNAIL_MARGIN;
                    y += THUMBNAIL_SIZE + THUMBNAIL_MARGIN;
                }
            }
        }

        private void numericPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số (0-9) và Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không phải số
            }
        }

    }
}
