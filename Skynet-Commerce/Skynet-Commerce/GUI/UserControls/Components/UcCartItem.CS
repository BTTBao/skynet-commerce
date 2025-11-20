using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcCartItem : UserControl
    {
        // ----------------------------------------------------------------------
        // I. EVENTS AND PROPERTIES
        // ----------------------------------------------------------------------

        public event EventHandler ItemDataChanged; // Dùng cho cả Số lượng và CheckBox
        public event EventHandler ItemRemoved;

        private decimal _unitPrice;

        public int Quantity
        {
            get
            {
                if (int.TryParse(txtQuantity.Text, out int qty))
                    return qty;
                return 1;
            }
            set
            {
                if (value >= 1)
                {
                    txtQuantity.Text = value.ToString();
                    UpdatePrice();
                }
            }
        }

        // Thuộc tính kiểm tra xem item có được chọn hay không
        public bool IsSelected
        {
            get { return chkSelect.Checked; }
            set { chkSelect.Checked = value; }
        }

        public decimal TotalPrice { get; private set; }
        public int ProductId { get; set; }

        // Thuộc tính để gán Text cho Label Biến thể
        public string VariantText
        {
            set { lblVariant.Text = value; }
        }

        // ----------------------------------------------------------------------
        // II. CONSTRUCTORS
        // ----------------------------------------------------------------------

        public UcCartItem()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        /// <summary>
        /// Constructor đầy đủ
        /// </summary>
        public UcCartItem(int productId, string name, decimal price, int initialQuantity, Image image, string imagePath = null) : this()
        {
            this.ProductId = productId;
            this.lblProductName.Text = name;
            this.lblPrice.Text = $"{price:N0}₫";
            this._unitPrice = price;
            this.txtQuantity.Text = initialQuantity.ToString();

            // Thiết lập kích thước cố định để tránh lỗi hiển thị
            this.Size = new Size(800, 110);
            this.MinimumSize = new Size(800, 110);
            this.Visible = true;

            // Xử lý ảnh
            if (image != null) { this.pbProductImage.Image = image; }
            else if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath)) { this.pbProductImage.ImageLocation = imagePath; }

            UpdatePrice();
        }

        // ----------------------------------------------------------------------
        // III. EVENT HANDLING
        // ----------------------------------------------------------------------

        private void SetupEventHandlers()
        {
            btnIncrease.Click += (s, e) => Quantity++;
            btnDecrease.Click += (s, e) => Quantity--;

            txtQuantity.TextChanged += txtQuantity_TextChanged;
            txtQuantity.Leave += txtQuantity_Leave;

            btnRemove.Click += btnRemove_Click;

            // Xử lý sự kiện CheckBox
            this.chkSelect.Click += (s, e) =>
            {
                // Khi check thay đổi -> Bắn sự kiện ItemDataChanged để tính lại tổng tiền
                ItemDataChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ItemRemoved?.Invoke(this, EventArgs.Empty);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out _))
            {
                // Optional: Allow empty temporarily while typing
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 1)
            {
                Quantity = 1;
            }
            else
            {
                Quantity = qty;
            }
        }

        private void UpdatePrice()
        {
            this.TotalPrice = _unitPrice * Quantity;
            this.lblTotalPrice.Text = $"{this.TotalPrice:N0}₫";

            ItemDataChanged?.Invoke(this, EventArgs.Empty);

            btnDecrease.Enabled = (Quantity > 1);
        }
    }
}