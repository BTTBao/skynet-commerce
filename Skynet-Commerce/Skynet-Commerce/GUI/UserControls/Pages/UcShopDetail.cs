using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models; // Đảm bảo đã có lớp này
using Skynet_Commerce.GUI.UserControls.Components;
using Guna.UI2.WinForms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    // Lớp giả lập cho dữ liệu Shop
    public class ShopDTO
    {
        public string Name { get; set; } = "FashionStore";
        public string Address { get; set; } = "TP. Hồ Chí Minh";
        public int Followers { get; set; } = 12500;
        public int ProductsCount { get; set; } = 156;
    }

    public partial class UcShopDetail : UserControl
    {
        private List<ProductDTO> allProducts;
        private ShopDTO shopData;
        private int currentShopId;

        public UcShopDetail()
        {
            InitializeComponent();
            this.Load += UcShopDetail_Load;
            SetupEventHandlers();
        }

        private void UcShopDetail_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định cho trang khi tải
            currentShopId = 1;
            LoadShopData(currentShopId);

            // Tự động kích hoạt nút "Tất cả sản phẩm"
            if (btnFilterTatCa != null)
            {
                ApplyFilterStyle(btnFilterTatCa);
            }
        }

        // ----------------------------------------------------------------------
        // II. LOGIC TẢI DỮ LIỆU CHÍNH
        // ----------------------------------------------------------------------

        public void LoadShopData(int shopId)
        {
            // 1. Lấy dữ liệu Shop và Sản phẩm mẫu
            shopData = new ShopDTO();
            allProducts = GetSampleProducts();

            // 2. Cập nhật thông tin Shop Header
            lblShopName.Text = shopData.Name;
            lblFollowers.Text = $"{shopData.Followers:N0} người theo dõi";
            lblShopAddress.Text = $"TP. {shopData.Address}";
            statProducts.Text = shopData.ProductsCount.ToString();

            // 3. Tải danh sách sản phẩm ban đầu
            LoadProductsToFlowLayout(allProducts);
        }

        // Tạo sản phẩm mẫu (ĐÃ CẬP NHẬT sử dụng SoldQuantity)
        private List<ProductDTO> GetSampleProducts()
        {
            return new List<ProductDTO>
            {
                new ProductDTO { ProductId = 1, Name = "Áo khoác denim thời trang", Price = 450000, InitialQuantity = 1, ImagePath = @"img\product1.jpg", Rating = 4.8, SoldQuantity = 1234 },
                new ProductDTO { ProductId = 2, Name = "Áo thun nam basic", Price = 149000, InitialQuantity = 2, ImagePath = @"img\product2.jpg", Rating = 4.5, SoldQuantity = 2456 },
                new ProductDTO { ProductId = 3, Name = "Quần jean nữ skinny", Price = 390000, InitialQuantity = 1, ImagePath = @"img\product3.jpg", Rating = 4.8, SoldQuantity = 890 },
                new ProductDTO { ProductId = 4, Name = "Giày thể thao nam", Price = 1200000, InitialQuantity = 1, ImagePath = @"img\product4.jpg", Rating = 4.8, SoldQuantity = 456 }
            };
        }

        // ----------------------------------------------------------------------
        // III. LOGIC SẢN PHẨM & LAYOUT
        // ----------------------------------------------------------------------

        private void LoadProductsToFlowLayout(List<ProductDTO> products)
        {
            flpProducts.Controls.Clear();

            foreach (var product in products)
            {
                // <<< CẬP NHẬT QUAN TRỌNG TẠI ĐÂY >>>
                // Sử dụng Constructor MỚI (public UcProductItem(ProductDTO productData))
                // Thay vì gọi constructor mặc định và sau đó gọi SetData

                UcProductItem item = new UcProductItem(product);

                // Thiết lập kích thước cho item (Giữ nguyên)
                item.Width = 200;
                item.Margin = new Padding(5);

                flpProducts.Controls.Add(item);
            }
        }

        // ----------------------------------------------------------------------
        // IV. XỬ LÝ SỰ KIỆN & LỌC
        // ----------------------------------------------------------------------

        private void SetupEventHandlers()
        {
            // Gán sự kiện cho các nút lọc
            btnFilterTatCa.Click += FilterButton_Click;
            btnFilterMoiNhat.Click += FilterButton_Click;
            btnFilterBanChay.Click += FilterButton_Click;
            btnFilterGiaThap.Click += FilterButton_Click;
            btnFilterGiaCao.Click += FilterButton_Click;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            if (clickedButton == null) return;

            // 1. Reset Style của tất cả các nút
            ResetFilterStyles();

            // 2. Áp dụng Style cho nút được chọn
            ApplyFilterStyle(clickedButton);

            // 3. Thực hiện lọc dữ liệu
            string filterType = clickedButton.Text;
            List<ProductDTO> filteredList = new List<ProductDTO>();

            switch (filterType)
            {
                case "Mới nhất":
                    // Sắp xếp theo ID giảm dần
                    filteredList = allProducts.OrderByDescending(p => p.ProductId).ToList();
                    break;
                case "Bán chạy":
                    // Sắp xếp theo SoldQuantity giảm dần (?? 0 để xử lý trường hợp SoldQuantity là null)
                    filteredList = allProducts.OrderByDescending(p => p.SoldQuantity ?? 0).ToList();
                    break;
                case "Giá thấp":
                    filteredList = allProducts.OrderBy(p => p.Price).ToList();
                    break;
                case "Giá cao":
                    filteredList = allProducts.OrderByDescending(p => p.Price).ToList();
                    break;
                case "Tất cả sản phẩm":
                default:
                    filteredList = allProducts;
                    break;
            }

            LoadProductsToFlowLayout(filteredList);
        }

        private void ResetFilterStyles()
        {
            // Đặt lại tất cả nút về FillColor.Transparent và ForeColor.Black
            Guna2Button[] buttons = { btnFilterTatCa, btnFilterMoiNhat, btnFilterBanChay, btnFilterGiaThap, btnFilterGiaCao };
            foreach (var btn in buttons)
            {
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }
        }

        private void ApplyFilterStyle(Guna2Button btn)
        {
            // Style cho nút đang được chọn (Màu cam)
            btn.FillColor = Color.FromArgb(255, 87, 34);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
    }
}