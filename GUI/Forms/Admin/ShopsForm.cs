using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Ecommerce.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopsForm : Form
    {
        private readonly ShopService _shopService;
        // phân trang
        private PaginationHelper _paginationHelper;
        private List<ShopViewModel> _activeShopsCache = new List<ShopViewModel>();
        public ShopsForm()
        {
            InitializeComponent();
            _shopService = new ShopService();

            SetupStatusFilter();
            SetupGrids();

            // phân trang
            _paginationHelper = new PaginationHelper(
                _pnlPagination,
                _cboPageSelect,
                _lblTotalPageText,
                (page) => RenderActiveGrid(), // Callback
                pageSize: 10
            );
        }

        private void SetupGrids()
        {
            // Active Grid
            _dgvActive.CellMouseEnter += (s, e) => { if (e.RowIndex >= 0) _dgvActive.Cursor = Cursors.Hand; };
            _dgvActive.CellMouseLeave += (s, e) => { _dgvActive.Cursor = Cursors.Default; };
            _dgvActive.CellFormatting += _dgvActive_CellFormatting;
            _dgvActive.CellContentClick += _dgvActive_CellContentClick;
        }

        private void SetupStatusFilter()
        {
            _comboStatus.SelectedIndexChanged -= _comboStatus_SelectedIndexChanged;

            var statusList = new List<ShopStatusOption>()
            {
                new ShopStatusOption { DisplayName = "Tất cả trạng thái", Value = "All Status" },
                new ShopStatusOption { DisplayName = "Đang hoạt động",    Value = "Active" },
                new ShopStatusOption { DisplayName = "Bị đình chỉ",       Value = "Suspended" }
            };

            _comboStatus.DataSource = statusList;
            _comboStatus.DisplayMember = "DisplayName";
            _comboStatus.ValueMember = "Value";
            _comboStatus.StartIndex = 0;

            _comboStatus.SelectedIndexChanged += _comboStatus_SelectedIndexChanged;
        }

        private void ShopsForm_Load(object sender, EventArgs e)
        {
            LoadActiveShops();
        }

        // --- XỬ LÝ ACTIVE SHOPS ---
        private void LoadActiveShops()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string keyword = _txtSearch.Text.Trim();
                string status = _comboStatus.SelectedValue?.ToString() ?? "All Status";

                List<ShopViewModel> allShops = _shopService.GetShops(keyword, status);
                _activeShopsCache = allShops;
                _paginationHelper.SetTotalRecords(allShops.Count);
                _paginationHelper.SetPage(1);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }
        // [MỚI] Hàm chỉ nhiệm vụ cắt dữ liệu và hiển thị
        private void RenderActiveGrid()
        {
            // Lấy trang hiện tại từ Helper
            int page = _paginationHelper.CurrentPage;
            int size = _paginationHelper.PageSize;

            // Cắt dữ liệu (Client-side pagination)
            var pagedData = _activeShopsCache
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToList();

            _dgvActive.AutoGenerateColumns = false;
            _dgvActive.DataSource = pagedData;
        }
        private void _dgvActive_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu cột Status
            if (_dgvActive.Columns[e.ColumnIndex].Name == "colA_Status")
            {
                string st = e.Value?.ToString();
                if (st == "Active")
                {
                    e.Value = "● Hoạt động";
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Green
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (st == "Suspended")
                {
                    e.Value = "● Bị đình chỉ";
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68); // Red
                }
            }

            // Đánh giá thêm icon sao (tượng trưng)
            if (_dgvActive.Columns[e.ColumnIndex].Name == "colA_Rate")
            {
                if (e.Value != null)
                    e.Value = $"{e.Value} ★";
                e.CellStyle.ForeColor = Color.FromArgb(245, 158, 11); // Amber
            }

            // Cột Action font đậm
            if (_dgvActive.Columns[e.ColumnIndex].Name == "colA_Action")
            {
                e.CellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            }
        }

        private void _dgvActive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dgvActive.Columns[e.ColumnIndex].Name != "colA_Action") return;

            var shop = _dgvActive.Rows[e.RowIndex].DataBoundItem as ShopViewModel;
            if (shop == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();

            var itemView = menu.Items.Add("Xem chi tiết / Sửa");
            itemView.Image = SystemIcons.Information.ToBitmap();
            itemView.Click += (s, ev) =>
            {
                // Đổi tên FormUserDetails thành ShopDetailForm
                using (var detailForm = new ShopDetailForm(shop.ShopID))
                {
                    if (detailForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadActiveShops(); // Refresh lại lưới bên ngoài nếu có thay đổi
                    }
                }
            };

            Rectangle cellRect = _dgvActive.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvActive, cellRect.Left, cellRect.Bottom);
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadActiveShops();
            }
        }

        private void _comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadActiveShops();
        }
    }

    public class ShopStatusOption
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}