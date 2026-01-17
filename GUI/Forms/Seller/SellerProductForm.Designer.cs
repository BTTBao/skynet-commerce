using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerProductForm : Form
    {
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Guna2Panel panelControls;
        private Guna2TextBox txtSearch;
        private Guna2Button btnAddProduct;
        private Guna2DataGridView dgvProducts;
        private Guna2Panel panelPagination;
        private Guna2Button btnPrevPage;
        private Guna2Button btnNextPage;
        private Label lblPageInfo;



        private void InitializeComponent()
        {
            this.panelHeader = new Guna2Panel();
            this.lblTitle = new Label();
            this.panelControls = new Guna2Panel();
            this.txtSearch = new Guna2TextBox();
            this.btnAddProduct = new Guna2Button();
            this.dgvProducts = new Guna2DataGridView();
            this.panelPagination = new Guna2Panel();
            this.btnPrevPage = new Guna2Button();
            this.btnNextPage = new Guna2Button();
            this.lblPageInfo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();

            // ======================
            // Panel Header (Tiêu đề)
            // ======================
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.FillColor = Color.FromArgb(31, 30, 68);
            this.panelHeader.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "Quản lý Sản phẩm";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 15);

            // ======================
            // Panel Controls (Tìm kiếm + Thêm)
            // ======================
            this.panelControls.Dock = DockStyle.Top;
            this.panelControls.Height = 60;
            this.panelControls.FillColor = Color.Transparent;
            this.panelControls.Padding = new Padding(20, 10, 20, 10);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.btnAddProduct);

            this.txtSearch.PlaceholderText = "Tìm kiếm sản phẩm...";
            this.txtSearch.Size = new Size(300, 40);
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Location = new Point(0, 10);

            this.btnAddProduct.Text = "Thêm sản phẩm";
            this.btnAddProduct.Size = new Size(150, 40);
            this.btnAddProduct.BorderRadius = 10;
            this.btnAddProduct.FillColor = Color.FromArgb(0, 120, 215);
            this.btnAddProduct.ForeColor = Color.White;
            this.btnAddProduct.Location = new Point(320, 10);
            this.btnAddProduct.Click += BtnAddProduct_Click;

            // ======================
            // DataGridView
            // ======================
            this.dgvProducts.Dock = DockStyle.Fill;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = Color.White;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvProducts.RowTemplate.Height = 40;
            this.dgvProducts.GridColor = Color.LightGray;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cột dữ liệu
            this.dgvProducts.Columns.Add("Id", "ID");
            this.dgvProducts.Columns.Add("Name", "Tên sản phẩm");
            this.dgvProducts.Columns.Add("Category", "Danh mục");
            this.dgvProducts.Columns.Add("Price", "Giá");
            this.dgvProducts.Columns.Add("Stock", "Tồn kho");

            // Cột nút ẩn/hiện
            var hideBtn = new DataGridViewImageColumn();
            hideBtn.HeaderText = "";
            hideBtn.Image = Properties.Resources.LOGO; // icon demo
            hideBtn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            hideBtn.Width = 40;
            this.dgvProducts.Columns.Add(hideBtn);

            // Cột nút sửa
            var editBtn = new DataGridViewImageColumn();
            editBtn.HeaderText = "";
            editBtn.Image = Properties.Resources.LOGO; // icon demo
            editBtn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editBtn.Width = 40;
            this.dgvProducts.Columns.Add(editBtn);

            this.dgvProducts.CellClick += DgvProducts_CellClick;

            // ======================
            // Panel Pagination
            // ======================
            this.panelPagination.Dock = DockStyle.Bottom;
            this.panelPagination.Height = 50;
            this.panelPagination.FillColor = Color.Transparent;
            this.panelPagination.Controls.Add(this.btnPrevPage);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNextPage);

            this.btnPrevPage.Text = "<";
            this.btnPrevPage.Size = new Size(40, 30);
            this.btnPrevPage.Location = new Point(300, 10);
            this.btnPrevPage.Click += BtnPrevPage_Click;

            this.btnNextPage.Text = ">";
            this.btnNextPage.Size = new Size(40, 30);
            this.btnNextPage.Location = new Point(380, 10);
            this.btnNextPage.Click += BtnNextPage_Click;

            this.lblPageInfo.Text = "1 / 10";
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new Point(350, 15);
            this.lblPageInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // ======================
            // SellerProductForm
            // ======================
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelHeader);
            this.Text = "Quản lý sản phẩm";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm sản phẩm");
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang trước");
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang sau");
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvProducts.Columns.Count - 2)
            {
                MessageBox.Show("Ẩn/Hiện sản phẩm: " + dgvProducts.Rows[e.RowIndex].Cells["Name"].Value);
            }

            if (e.ColumnIndex == dgvProducts.Columns.Count - 1)
            {
                MessageBox.Show("Sửa sản phẩm: " + dgvProducts.Rows[e.RowIndex].Cells["Name"].Value);
            }
        }
    }
}
