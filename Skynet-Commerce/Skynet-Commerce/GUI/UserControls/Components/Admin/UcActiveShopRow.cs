using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcActiveShopRow : UserControl
    {
        // Định nghĩa Event xem chi tiết
        public event EventHandler OnViewClicked;
        public int ShopID { get; private set; }

        public UcActiveShopRow()
        {
            InitializeComponent();
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };

            // Gắn sự kiện
            _btnView.Click += (s, e) => OnViewClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetData(ShopViewModel shop)
        {
            if (shop == null) return;
            this.ShopID = shop.ShopID;

            // 1. Gán dữ liệu từ ViewModel vào các Label
            _lblId.Text = shop.ShopID.ToString();
            _lblName.Text = shop.ShopName;

            // Giả sử bạn đã thêm OwnerName vào ViewModel như Bước 1
            // Nếu chưa có, bạn có thể tạm dùng AccountID: shop.AccountID.ToString();
            _lblOwner.Text = shop.OwnerName;

            _lblRating.Text = "★ " + (shop.RatingAverage.HasValue ? Math.Round(shop.RatingAverage.Value, 1).ToString() : "0");

            _lblProducts.Text = shop.StockQuantity.HasValue ? shop.StockQuantity.ToString() + "" : "0";

            _badgeStatus.Text = shop.Status == "Active" ? "Hoạt động" : "Khoá" ;

            // 2. Xử lý màu sắc dựa trên Status
            if (shop.Status == "Active")
            {
                _badgeStatus.FillColor = Color.FromArgb(79, 70, 229); // Xanh tím
                _badgeStatus.ForeColor = Color.White;
            }
            else // Suspended hoặc Inactive
            {
                _badgeStatus.FillColor = Color.FromArgb(220, 38, 38); // Đỏ
                _badgeStatus.ForeColor = Color.White;
            }
        }
    
    }
}