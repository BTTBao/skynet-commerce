using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.BLL.Services; // [QUAN TRỌNG] Nhớ thêm cái này
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcSearchResult : UserControl
    {
        // UI Controls
        private FlowLayoutPanel flpProducts;
        private string _keyword;

        // Service để gọi Database
        private readonly ProductService _productService;

        // Các biến lưu trạng thái bộ lọc
        private List<ProductDTO> _allProducts; // Danh sách gốc lấy từ DB
        private string _selectedCategory = "Tất cả";
        private string _selectedPriceRange = "Tất cả";
        private string _selectedRating = "Tất cả";
        private string _selectedSort = "Liên quan";

        public UcSearchResult(string keyword)
        {
            InitializeComponent();
            _keyword = keyword;
            _productService = new ProductService(); // Khởi tạo Service

            // 1. Setup giao diện trước
            SetupLayout();

            // 2. Lấy dữ liệu thật từ DB
            LoadDataFromDatabase();
        }

        // --- HÀM LẤY DỮ LIỆU TỪ DB ---
        private void LoadDataFromDatabase()
        {
            try
            {
                // Gọi Service tìm kiếm theo từ khóa
                // Hàm này bạn cần viết trong ProductService (xem Phần 2 bên dưới)
                _allProducts = _productService.SearchProducts(_keyword);

                if (_allProducts == null) _allProducts = new List<ProductDTO>();

                // Sau khi lấy về, áp dụng các bộ lọc mặc định
                ApplyFiltersAndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // ... (Giữ nguyên SetupLayout, SetupSidebarFilters, SetupSortBar không đổi) ...
        private void SetupLayout()
        {
            this.BackColor = Color.FromArgb(248, 248, 248);
            this.Size = new Size(1200, 850);
            this.AutoScroll = true;

            Label lblHeader = new Label
            {
                Text = $"Kết quả tìm kiếm cho \"{_keyword}\"",
                Font = new Font("Segoe UI", 16, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblHeader);

            Panel pnlSidebar = new Panel { Location = new Point(20, 100), Size = new Size(220, 600), BackColor = Color.Transparent };
            SetupSidebarFilters(pnlSidebar);
            this.Controls.Add(pnlSidebar);

            Guna2Panel pnlSort = new Guna2Panel { Location = new Point(260, 100), Size = new Size(900, 60), FillColor = Color.FromArgb(237, 237, 237), BorderRadius = 4 };
            SetupSortBar(pnlSort);
            this.Controls.Add(pnlSort);

            flpProducts = new FlowLayoutPanel
            {
                Location = new Point(260, 170),
                Size = new Size(920, 700),
                BackColor = Color.Transparent,
                AutoScroll = true,
                Padding = new Padding(0, 0, 0, 20)
            };
            this.Controls.Add(flpProducts);
        }

        private void SetupSidebarFilters(Panel pnl)
        {
            Label lblTitle = new Label { Text = "Bộ lọc tìm kiếm", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(0, 0), AutoSize = true };
            pnl.Controls.Add(lblTitle);

            int y = 40;

            // --- 1. Danh mục ---
            pnl.Controls.Add(new Label { Text = "Danh mục", Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(0, y), AutoSize = true });
            y += 30;
            string[] categories = { "Tất cả", "Thời trang", "Điện tử", "Nhà cửa", "Làm đẹp" };
            foreach (var cat in categories)
            {
                var rb = CreateFilterRadioButton(cat, 0, y);
                rb.CheckedChanged += (s, e) => { if (rb.Checked) { _selectedCategory = cat; ApplyFiltersAndSort(); } };
                if (cat == "Tất cả") rb.Checked = true;
                pnl.Controls.Add(rb);
                pnl.Controls.Add(new Label { Text = cat, Location = new Point(25, y - 2), AutoSize = true, Font = new Font("Segoe UI", 9) });
                y += 30;
            }

            // --- 2. Khoảng giá ---
            y += 20;
            pnl.Controls.Add(new Label { Text = "Khoảng giá", Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(0, y), AutoSize = true });
            y += 30;
            string[] prices = { "Tất cả", "Dưới 100K", "100K - 500K", "500K - 1M", "Trên 1M" };
            foreach (var price in prices)
            {
                var rb = CreateFilterRadioButton(price, 0, y);
                rb.CheckedChanged += (s, e) => { if (rb.Checked) { _selectedPriceRange = price; ApplyFiltersAndSort(); } };
                if (price == "Tất cả") rb.Checked = true;
                pnl.Controls.Add(rb);
                pnl.Controls.Add(new Label { Text = price, Location = new Point(25, y - 2), AutoSize = true, Font = new Font("Segoe UI", 9) });
                y += 30;
            }

            // --- 3. Đánh giá ---
            y += 20;
            pnl.Controls.Add(new Label { Text = "Đánh giá", Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(0, y), AutoSize = true });
            y += 30;
            string[] ratings = { "Tất cả", "5 sao", "4 sao trở lên", "3 sao trở lên" };
            foreach (var rate in ratings)
            {
                var rb = CreateFilterRadioButton(rate, 0, y);
                rb.CheckedChanged += (s, e) => { if (rb.Checked) { _selectedRating = rate; ApplyFiltersAndSort(); } };
                if (rate == "Tất cả") rb.Checked = true;
                pnl.Controls.Add(rb);
                string displayMap = rate == "5 sao" ? "⭐⭐⭐⭐⭐" : rate;
                Label lblRate = new Label { Text = displayMap, Location = new Point(25, y - 2), AutoSize = true, Font = new Font("Segoe UI", 9) };
                if (rate.Contains("sao")) lblRate.ForeColor = Color.Orange;
                pnl.Controls.Add(lblRate);
                y += 30;
            }

            Guna2Button btnClear = new Guna2Button
            {
                Text = "Xóa tất cả",
                FillColor = Color.White,
                ForeColor = Color.Black,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                BorderRadius = 4,
                Location = new Point(0, y + 20),
                Size = new Size(150, 35),
                Cursor = Cursors.Hand
            };
            btnClear.Click += (s, e) =>
            {
                _selectedCategory = "Tất cả"; _selectedPriceRange = "Tất cả"; _selectedRating = "Tất cả"; _selectedSort = "Liên quan";
                ApplyFiltersAndSort();
                MessageBox.Show("Đã xóa bộ lọc!");
            };
            pnl.Controls.Add(btnClear);
        }

        private Guna2CustomRadioButton CreateFilterRadioButton(string tag, int x, int y)
        {
            return new Guna2CustomRadioButton
            {
                Location = new Point(x, y),
                Size = new Size(18, 18),
                CheckedState = { BorderColor = Color.OrangeRed, FillColor = Color.OrangeRed },
                UncheckedState = { BorderColor = Color.Gray, FillColor = Color.White },
                Tag = tag,
                Cursor = Cursors.Hand
            };
        }

        private void SetupSortBar(Panel pnl)
        {
            Label lblLabel = new Label { Text = "Sắp xếp theo:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Regular) };
            pnl.Controls.Add(lblLabel);

            string[] sorts = { "Liên quan", "Mới nhất", "Bán chạy", "Giá thấp đến cao", "Giá cao đến thấp" };
            int x = 120;
            foreach (var sort in sorts)
            {
                Guna2Button btn = new Guna2Button
                {
                    Text = sort,
                    Location = new Point(x, 10),
                    Size = new Size(120, 40),
                    BorderRadius = 4,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Cursor = Cursors.Hand,
                    FillColor = (sort == "Liên quan") ? Color.OrangeRed : Color.White,
                    ForeColor = (sort == "Liên quan") ? Color.White : Color.Black
                };
                btn.Click += (s, e) =>
                {
                    foreach (Control c in pnl.Controls) if (c is Guna2Button b) { b.FillColor = Color.White; b.ForeColor = Color.Black; }
                    ((Guna2Button)s).FillColor = Color.OrangeRed; ((Guna2Button)s).ForeColor = Color.White;
                    _selectedSort = sort;
                    ApplyFiltersAndSort();
                };
                pnl.Controls.Add(btn); x += 130;
            }
        }

        private void ApplyFiltersAndSort()
        {
            if (_allProducts == null || _allProducts.Count == 0) return;

            // 1. Lọc trên RAM (Từ danh sách đã tải về)
            var filteredList = _allProducts.AsEnumerable();

            // Danh mục (Tạm thời lọc theo tên vì DB chưa chắc có CategoryID khớp UI)
            if (_selectedCategory != "Tất cả")
            {
                filteredList = filteredList.Where(p => p.Name.IndexOf(_selectedCategory, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // Giá
            switch (_selectedPriceRange)
            {
                case "Dưới 100K": filteredList = filteredList.Where(p => p.Price < 100000); break;
                case "100K - 500K": filteredList = filteredList.Where(p => p.Price >= 100000 && p.Price <= 500000); break;
                case "500K - 1M": filteredList = filteredList.Where(p => p.Price >= 500000 && p.Price <= 1000000); break;
                case "Trên 1M": filteredList = filteredList.Where(p => p.Price > 1000000); break;
            }

            // Đánh giá
            if (_selectedRating != "Tất cả")
            {
                double minRate = _selectedRating == "5 sao" ? 4.9 : (_selectedRating == "4 sao trở lên" ? 4.0 : 3.0);
                filteredList = filteredList.Where(p => (p.Rating ?? 0) >= minRate);
            }

            // Sắp xếp
            switch (_selectedSort)
            {
                case "Giá thấp đến cao": filteredList = filteredList.OrderBy(p => p.Price); break;
                case "Giá cao đến thấp": filteredList = filteredList.OrderByDescending(p => p.Price); break;
                case "Bán chạy": filteredList = filteredList.OrderByDescending(p => p.SoldQuantity); break;
                case "Mới nhất": filteredList = filteredList.OrderByDescending(p => p.ProductId); break;
            }

            RenderProductList(filteredList.ToList());
        }

        private void RenderProductList(List<ProductDTO> products)
        {
            if (flpProducts == null) return;
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();

            if (products.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không tìm thấy sản phẩm phù hợp!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Red,
                    Margin = new Padding(20)
                };
                flpProducts.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var p in products)
                {
                    UcProductCard card = new UcProductCard();
                    card.LoadData(p.ProductId, p.Name, p.Price, p.Rating ?? 0, p.SoldQuantity ?? 0, p.ImagePath);
                    card.CardClicked += (s, e) =>
                    {
                        FrmMain main = this.FindForm() as FrmMain;
                        if (main != null) main.LoadPage("ProductDetail", p);
                    };
                    flpProducts.Controls.Add(card);
                }
            }
            flpProducts.ResumeLayout();
        }
    }
}