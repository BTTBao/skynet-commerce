using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.BLL.Services;
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

        private readonly ProductService _productService;

        // Các biến lưu trạng thái bộ lọc
        private List<ProductDTO> _allProducts;
        private string _selectedCategory = "Tất cả";
        private string _selectedPriceRange = "Tất cả";
        private string _selectedRating = "Tất cả";
        private string _selectedSort = "Liên quan";

        // [QUAN TRỌNG] Dùng để khóa sự kiện CheckedChanged trong quá trình reset UI
        private bool _isSettingFilter = false;

        public UcSearchResult(string keyword)
        {
            InitializeComponent();
            _keyword = keyword;
            _productService = new ProductService();

            SetupLayout();
            LoadDataFromDatabase();
        }

        // --- HÀM LẤY DỮ LIỆU TỪ DB ---
        private void LoadDataFromDatabase()
        {
            try
            {
                _allProducts = _productService.SearchProducts(_keyword);
                if (_allProducts == null) _allProducts = new List<ProductDTO>();
                ApplyFiltersAndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- HÀM CẤU HÌNH UI (SetupLayout, SetupSortBar, RenderProductList giữ nguyên) ---
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

            // Cấu hình pnlSidebar để chứa các nhóm lọc
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

        // --- [SỬA LỖI] HÀM CẤU HÌNH SIDEBAR (Tạo nhóm Radio Button) ---
        private void SetupSidebarFilters(Panel pnlSidebar)
        {
            pnlSidebar.Controls.Clear();
            _isSettingFilter = true; // [MỚI] Bật cờ khóa sự kiện

            Label lblTitle = new Label { Text = "Bộ lọc tìm kiếm", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(0, 0), AutoSize = true };
            pnlSidebar.Controls.Add(lblTitle);

            // Dùng FlowLayoutPanel để quản lý vị trí các nhóm lọc (dễ hơn tính Y thủ công)
            FlowLayoutPanel flpGroups = new FlowLayoutPanel
            {
                Location = new Point(0, 40),
                Size = new Size(220, 560),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(flpGroups);

            // --- 1. Danh mục ---
            string[] categories = { "Tất cả", "Thời trang", "Điện tử", "Nhà cửa", "Làm đẹp" };
            flpGroups.Controls.Add(CreateFilterGroupPanel("Danh mục", categories, _selectedCategory, (val) => { _selectedCategory = val; ApplyFiltersAndSort(); }));

            // --- 2. Khoảng giá ---
            string[] prices = { "Tất cả", "Dưới 100K", "100K - 500K", "500K - 1M", "Trên 1M" };
            flpGroups.Controls.Add(CreateFilterGroupPanel("Khoảng giá", prices, _selectedPriceRange, (val) => { _selectedPriceRange = val; ApplyFiltersAndSort(); }));

            // --- 3. Đánh giá ---
            string[] ratings = { "Tất cả", "5 sao", "4 sao trở lên", "3 sao trở lên" };
            flpGroups.Controls.Add(CreateFilterGroupPanel("Đánh giá", ratings, _selectedRating, (val) => { _selectedRating = val; ApplyFiltersAndSort(); }, isRating: true));

            // --- Nút Xóa bộ lọc ---
            Guna2Button btnClear = new Guna2Button
            {
                Text = "Xóa tất cả",
                FillColor = Color.White,
                ForeColor = Color.Black,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                BorderRadius = 4,
                Size = new Size(150, 35),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 10, 0, 0)
            };
            btnClear.Click += (s, e) =>
            {
                _selectedCategory = "Tất cả"; _selectedPriceRange = "Tất cả"; _selectedRating = "Tất cả"; _selectedSort = "Liên quan";
                SetupSidebarFilters(pnlSidebar);
                ApplyFiltersAndSort();
                MessageBox.Show("Đã xóa bộ lọc!");
            };
            flpGroups.Controls.Add(btnClear);

            _isSettingFilter = false; // [MỚI] Tắt cờ khóa sự kiện
        }

        // [MỚI] Hàm Helper để tạo Container cho nhóm lọc (Radio Button Grouping Fix)
        private Panel CreateFilterGroupPanel(string title, string[] items, string selectedValue, Action<string> onChange, bool isRating = false)
        {
            // Panel này là CHÍNH LÀ CONTAINER cha của các Radio Button trong nhóm này
            int groupHeight = items.Length * 25 + 50;
            Panel pnlGroup = new Panel
            {
                Size = new Size(220, groupHeight),
                BackColor = Color.Transparent,
                Margin = new Padding(0, 10, 0, 10)
            };

            pnlGroup.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(0, 0), AutoSize = true });

            int y = 30; // Vị trí Y bắt đầu cho Radio Button đầu tiên

            foreach (var item in items)
            {
                var rb = CreateFilterRadioButton(item, 0, y);

                // [FIX LỖI] Kiểm tra cờ khóa trước khi chạy ApplyFiltersAndSort
                rb.CheckedChanged += (s, e) => { if (rb.Checked && !_isSettingFilter) onChange(item); };

                if (item == selectedValue) rb.Checked = true;

                // Label handling
                Label lbl = new Label { Text = item, Location = new Point(25, y), AutoSize = true, Font = new Font("Segoe UI", 9) };
                if (isRating)
                {
                    lbl.Text = item == "5 sao" ? "⭐⭐⭐⭐⭐" : item;
                    lbl.ForeColor = Color.Orange;
                }

                // [CRUCIAL FIX] Thêm Radio Button và Label TRỰC TIẾP vào Group Panel
                pnlGroup.Controls.Add(rb);
                pnlGroup.Controls.Add(lbl);

                y += 30; // Tăng vị trí Y cho dòng tiếp theo
            }

            return pnlGroup;
        }


        private Guna2CustomRadioButton CreateFilterRadioButton(string tag, int x, int y)
        {
            // Hàm này giữ nguyên
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

        // --- CÁC HÀM SẮP XẾP VÀ LỌC KHÁC (Giữ nguyên) ---

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
            if (_allProducts == null || _allProducts.Count == 0)
            {
                RenderProductList(new List<ProductDTO>());
                return;
            }

            var filteredList = _allProducts.AsEnumerable();

            // Danh mục
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