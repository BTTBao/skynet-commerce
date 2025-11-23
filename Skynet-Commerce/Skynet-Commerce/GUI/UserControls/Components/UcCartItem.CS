using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcCartItem : UserControl
    {
        public event EventHandler ItemDataChanged;
        public event EventHandler ItemRemoved;

        private decimal _unitPrice;

        public int Quantity
        {
            get
            {
                if (int.TryParse(txtQuantity.Text, out int qty)) return qty;
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

        public bool IsSelected
        {
            get { return chkSelect.Checked; }
            set { chkSelect.Checked = value; }
        }

        public decimal TotalPrice { get; private set; }
        public int ProductId { get; set; }

        public UcCartItem()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        /// <summary>
        /// Constructor đầy đủ (Đã thêm tham số variantName)
        /// </summary>
        public UcCartItem(int productId, string name, decimal price, int initialQuantity, Image image, string imagePath = null, string variantName = "") : this()
        {
            this.ProductId = productId;
            this.lblProductName.Text = name;
            this.lblPrice.Text = $"{price:N0}₫";
            this._unitPrice = price;
            this.txtQuantity.Text = initialQuantity.ToString();

            // [CẬP NHẬT] Hiển thị biến thể
            if (!string.IsNullOrEmpty(variantName))
            {
                this.lblVariant.Text = "Phân loại: " + variantName;
                this.lblVariant.Visible = true;
            }
            else
            {
                this.lblVariant.Text = "Phân loại: Mặc định";
                // Hoặc ẩn đi: this.lblVariant.Visible = false;
            }

            this.Size = new Size(800, 110);
            this.Visible = true;

            // Xử lý ảnh
            if (image != null) { this.pbProductImage.Image = image; }
            else if (!string.IsNullOrEmpty(imagePath))
            {
                if (imagePath.StartsWith("http")) this.pbProductImage.ImageLocation = imagePath;
                else if (File.Exists(imagePath)) this.pbProductImage.ImageLocation = imagePath;
            }

            UpdatePrice();
        }

        private void SetupEventHandlers()
        {
            btnIncrease.Click += (s, e) => Quantity++;
            btnDecrease.Click += (s, e) => Quantity--;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            txtQuantity.Leave += txtQuantity_Leave;
            btnRemove.Click += btnRemove_Click;
            this.chkSelect.Click += (s, e) => ItemDataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnRemove_Click(object sender, EventArgs e) => ItemRemoved?.Invoke(this, EventArgs.Empty);

        private void txtQuantity_TextChanged(object sender, EventArgs e) { if (!int.TryParse(txtQuantity.Text, out _)) { } }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 1) Quantity = 1;
            else Quantity = qty;
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