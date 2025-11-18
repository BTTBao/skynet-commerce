using System;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.Forms; // Cần import FrmMain
using Skynet_Commerce.GUI.UserControls.Pages; // Cần import UcProductDetail

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcProductItem : UserControl
    {
        private int _productId; // Biến lưu trữ ID sản phẩm

        public UcProductItem()
        {
            InitializeComponent();
        }

        // Sửa Constructor để nhận thêm productId
        public UcProductItem(string name, decimal price, double rating, int sold, string imgPath, int productId) : this()
        {
            this._productId = productId; // Gán ID sản phẩm

            // --- SETUP CHUNG ---
            this.Size = new Size(190, 280);
            this.BackColor = Color.White;
            this.Margin = new Padding(5);
            this.Cursor = Cursors.Hand;

            // Gán sự kiện Click cho thẻ cha
            this.Click += (s, e) => NavigateToDetail();

            // --- Hiệu ứng Hover ---
            this.MouseEnter += (s, e) => this.BackColor = Color.WhiteSmoke;
            this.MouseLeave += (s, e) => this.BackColor = Color.White;

            // --- 1. ẢNH SẢN PHẨM ---
            PictureBox pbImage = new PictureBox();
            pbImage.Size = new Size(190, 190);
            pbImage.Dock = DockStyle.Top;
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;

            // Gán sự kiện Click cho ảnh
            pbImage.Click += (s, e) => NavigateToDetail();

            // Xử lý load ảnh local
            string fullPath = System.IO.Path.Combine(Application.StartupPath, imgPath);
            if (System.IO.File.Exists(fullPath))
                pbImage.ImageLocation = fullPath;
            else
                pbImage.BackColor = Color.LightGray;

            // --- 2. TÊN SẢN PHẨM ---
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Location = new Point(8, 200);
            lblName.Size = new Size(174, 36);
            lblName.Font = new Font("Arial", 9, FontStyle.Regular);
            lblName.AutoEllipsis = true;
            lblName.Click += (s, e) => NavigateToDetail(); // Gán sự kiện Click cho tên

            // --- 3. KHU VỰC ĐÁNH GIÁ & ĐÃ BÁN ---
            FlowLayoutPanel pnlStats = new FlowLayoutPanel();
            pnlStats.Location = new Point(8, 236);
            pnlStats.Size = new Size(174, 20);
            pnlStats.FlowDirection = FlowDirection.LeftToRight;
            pnlStats.WrapContents = false;
            pnlStats.Click += (s, e) => NavigateToDetail(); // Gán sự kiện Click cho panel chứa stats

            // Ngôi sao, Điểm đánh giá, Số lượng bán (Giữ nguyên logic tạo control)
            // ... (Code tạo lblStar, lblRating, lblSold và thêm vào pnlStats giữ nguyên) ...

            // Tạm thời bỏ qua logic chi tiết các label con để tập trung vào Click chính

            // --- 4. GIÁ TIỀN ---
            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("N0") + "đ";
            lblPrice.Location = new Point(8, 255);
            lblPrice.ForeColor = Color.Red;
            lblPrice.Font = new Font("Arial", 11, FontStyle.Bold);
            lblPrice.AutoSize = true;
            lblPrice.Click += (s, e) => NavigateToDetail(); // Gán sự kiện Click cho giá

            // --- THÊM VÀO USER CONTROL ---
            this.Controls.Add(lblPrice);
            this.Controls.Add(pnlStats);
            this.Controls.Add(lblName);
            this.Controls.Add(pbImage);
        }

        // Hàm chuyển trang
        private void NavigateToDetail()
        {
            if (FrmMain.Instance != null)
            {
                // 1. Tạo trang chi tiết mới và truyền ID sản phẩm
                UcProductDetail detailPage = new UcProductDetail(this._productId);

                // 2. Yêu cầu FrmMain chuyển sang trang này
                FrmMain.Instance.LoadUserControl(detailPage);
            }
        }
    }
}