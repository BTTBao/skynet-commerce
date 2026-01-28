using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerProductDetailForm : Form
    {
        private Product _currentProduct;

        public SellerProductDetailForm(Product product)
        {
            InitializeComponent();
            this._currentProduct = product;

            LoadProductData();
        }

        private void LoadProductData()
        {
            if (_currentProduct == null) return;

            // 1. Load thông tin cơ bản
            lblProductName.Text = _currentProduct.Name;
            lblSoldCount.Text = $"Đã bán: {_currentProduct.SoldCount}";

            // Tính đánh giá trung bình
            double avgRating = (double)(_currentProduct.Reviews.Any()
                   ? _currentProduct.Reviews.Average(r => r.Rating)
                   : 0);
            lblRating.Text = $"⭐ {avgRating:F1}/5";
            decimal price = _currentProduct.Price ?? 0;

            // Hiển thị giá
            lblPrice.Text = price.ToString("N0") + " đ";

            // Hiển thị mô tả
            txtDescription.Text = _currentProduct.Description ?? "Không có mô tả";

            // 2. Load DataGridView - Variants
            LoadVariants();

            // 3. Load Hình ảnh
            LoadProductImages();

            // 4. Load Đánh giá
            LoadReviews();
        }

        private void LoadVariants()
        {
            // Cấu hình DataGridView
            dgvVariants.Columns.Clear();
            dgvVariants.AutoGenerateColumns = false;

            // Thêm các cột
            dgvVariants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Color",
                HeaderText = "Màu sắc",
                DataPropertyName = "Color"
            });

            dgvVariants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Size",
                HeaderText = "Kích thước",
                DataPropertyName = "Size"
            });

            dgvVariants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SKU",
                HeaderText = "SKU",
                DataPropertyName = "SKU"
            });

            dgvVariants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockQuantity",
                HeaderText = "Số lượng",
                DataPropertyName = "StockQuantity"
            });

            dgvVariants.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Giá",
                DataPropertyName = "Price"
            });

            // Bind dữ liệu
            if (_currentProduct.ProductVariants != null && _currentProduct.ProductVariants.Any())
            {
                dgvVariants.DataSource = _currentProduct.ProductVariants.Select(v => new
                {
                    Color = v.Color ?? "N/A",
                    Size = v.Size ?? "N/A",
                    SKU = v.SKU ?? "N/A",
                    StockQuantity = v.StockQuantity,
                    Price = (decimal)v.Price
                }).ToList();
            }
            else
            {
                // Nếu không có variant, hiển thị thông tin sản phẩm chính
                dgvVariants.DataSource = new List<object>
                {
                    new
                    {
                        Color = "Mặc định",
                        Size = "Mặc định",
                        SKU = "N/A",
                        StockQuantity = _currentProduct.StockQuantity,
                        Price = (decimal) _currentProduct.Price
                    }
                };
            }
        }

        private void LoadProductImages()
        {
            if (_currentProduct.ProductImages == null || !_currentProduct.ProductImages.Any())
                return;

            // Load ảnh chính (ảnh primary)
            var primaryImage = _currentProduct.ProductImages.FirstOrDefault(img => img.IsPrimary == true);
            if (primaryImage != null)
            {
                picMain.ImageLocation = primaryImage.ImageURL;
            }
            else if (_currentProduct.ProductImages.Any())
            {
                // Nếu không có ảnh primary, lấy ảnh đầu tiên
                picMain.ImageLocation = _currentProduct.ProductImages.First().ImageURL;
            }

            // Load thumbnails
            LoadThumbnails();
        }

        private void LoadThumbnails()
        {
            pnlThumbnails.Controls.Clear();

            foreach (var imgUrl in _currentProduct.ProductImages)
            {
                Guna2PictureBox thumb = new Guna2PictureBox
                {
                    Size = new Size(70, 70),
                    ImageLocation = imgUrl.ImageURL,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(5),
                    BorderRadius = 5,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Click ảnh nhỏ để đổi ảnh lớn
                thumb.Click += (s, e) =>
                {
                    picMain.ImageLocation = thumb.ImageLocation;
                };

                pnlThumbnails.Controls.Add(thumb);
            }
        }

        private void LoadReviews()
        {
            pnlReviews.Controls.Clear();

            if (_currentProduct.Reviews == null || !_currentProduct.Reviews.Any())
            {
                // Hiển thị thông báo chưa có đánh giá
                Label lblNoReview = new Label
                {
                    Text = "Chưa có đánh giá nào cho sản phẩm này",
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 20),
                    AutoSize = true
                };
                pnlReviews.Controls.Add(lblNoReview);
                return;
            }

            // Load các đánh giá
            foreach (var review in _currentProduct.Reviews.OrderByDescending(r => r.CreatedAt).Take(10))
            {
                CreateReviewItem(
                    review.Account.Users.FirstOrDefault().FullName ?? "Khách hàng",
                    (int)review.Rating,
                    review.Comment ?? "",
                    review.CreatedAt
                );
            }
        }

        private void CreateReviewItem(string user, int star, string comment, DateTime? createdAt)
        {
            Guna2Panel item = new Guna2Panel
            {
                Size = new Size(pnlReviews.Width - 40, 90),
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                BorderThickness = 0,
                CustomBorderColor = Color.FromArgb(240, 240, 240),
                CustomBorderThickness = new Padding(0, 0, 0, 1),
                Margin = new Padding(0, 0, 0, 5)
            };

            Label lblUser = new Label
            {
                Text = user,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = createdAt?.ToString("dd/MM/yyyy") ?? "",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(200, 12),
                AutoSize = true
            };

            Label lblStar = new Label
            {
                Text = new string('⭐', star),
                ForeColor = Color.Orange,
                Location = new Point(15, 35),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            Label lblCmt = new Label
            {
                Text = comment,
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 60),
                Size = new Size(item.Width - 30, 25),
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            item.Controls.AddRange(new Control[] { lblUser, lblDate, lblStar, lblCmt });
            pnlReviews.Controls.Add(item);
        }
    }
}