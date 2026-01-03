using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Ecommerce.BLL.Helpers
{
    public class PaginationHelper
    {
        // Các control UI được truyền vào từ Form
        private readonly FlowLayoutPanel _pnlPagination;
        private readonly Guna2ComboBox _cboPageSelect;
        private readonly Label _lblTotalPageText;

        // Sự kiện callback khi trang thay đổi (để Form tải lại dữ liệu)
        private readonly Action<int> _onPageChanged;

        // Trạng thái
        public int CurrentPage { get; private set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; private set; } = 1;
        private bool _isSystemChanging = false; // Cờ chặn sự kiện lặp

        public PaginationHelper(
            FlowLayoutPanel pnlPagination,
            Guna2ComboBox cboPageSelect,
            Label lblTotalPageText,
            Action<int> onPageChanged,
            int pageSize = 10)
        {
            _pnlPagination = pnlPagination;
            _cboPageSelect = cboPageSelect;
            _lblTotalPageText = lblTotalPageText;
            _onPageChanged = onPageChanged;
            PageSize = pageSize;

            // Đăng ký sự kiện cho ComboBox ngay khi khởi tạo
            SetupEvents();
        }

        private void SetupEvents()
        {
            if (_cboPageSelect != null)
            {
                _cboPageSelect.SelectedIndexChanged += (s, e) =>
                {
                    if (_isSystemChanging) return;
                    if (int.TryParse(_cboPageSelect.SelectedItem?.ToString(), out int p))
                        SetPage(p);
                };

                _cboPageSelect.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        e.SuppressKeyPress = true;
                        if (int.TryParse(_cboPageSelect.Text.Trim(), out int p))
                            SetPage(p);
                        else
                            _cboPageSelect.Text = CurrentPage.ToString(); // Reset nếu nhập sai
                    }
                };
            }
        }

        // Hàm chính: Tính toán số trang dựa trên tổng số bản ghi
        public void SetTotalRecords(int totalRecords)
        {
            TotalPages = (int)Math.Ceiling((double)totalRecords / PageSize);
            if (TotalPages < 1) TotalPages = 1;

            // Update ComboBox list
            _isSystemChanging = true;
            if (_cboPageSelect != null)
            {
                _cboPageSelect.Items.Clear();
                if (TotalPages > 0)
                    _cboPageSelect.Items.AddRange(Enumerable.Range(1, TotalPages).Cast<object>().ToArray());
                else
                    _cboPageSelect.Items.Add(1);
            }

            if (_lblTotalPageText != null)
                _lblTotalPageText.Text = $"of {TotalPages}";

            _isSystemChanging = false;

            // Render lại nút
            RenderPaginationControls();
        }

        // Hàm chuyển trang (có kiểm tra hợp lệ)
        public void SetPage(int newPage)
        {
            if (newPage < 1) newPage = 1;
            if (newPage > TotalPages) newPage = TotalPages;

            CurrentPage = newPage;

            // Sync ComboBox
            _isSystemChanging = true;
            if (_cboPageSelect != null && _cboPageSelect.Items.Count >= CurrentPage)
                _cboPageSelect.SelectedIndex = CurrentPage - 1;
            _isSystemChanging = false;

            // Render lại nút
            RenderPaginationControls();

            // Gọi callback để Form xử lý dữ liệu
            _onPageChanged?.Invoke(CurrentPage);
        }

        // Logic vẽ nút (Mang từ UsersForm sang)
        private void RenderPaginationControls()
        {
            _pnlPagination.Controls.Clear();
            if (TotalPages <= 1) return;

            // Nút Previous
            _pnlPagination.Controls.Add(CreatePageButton("<", CurrentPage > 1, () => SetPage(CurrentPage - 1)));

            // Smart Pagination Logic
            int startPage = Math.Max(1, CurrentPage - 2);
            int endPage = Math.Min(TotalPages, CurrentPage + 2);

            if (startPage > 1)
            {
                _pnlPagination.Controls.Add(CreatePageButton("1", true, () => SetPage(1)));
                if (startPage > 2) _pnlPagination.Controls.Add(CreateDots());
            }

            for (int i = startPage; i <= endPage; i++)
            {
                int p = i;
                bool isActive = (p == CurrentPage);
                _pnlPagination.Controls.Add(CreatePageButton(p.ToString(), true, () => SetPage(p), isActive));
            }

            if (endPage < TotalPages)
            {
                if (endPage < TotalPages - 1) _pnlPagination.Controls.Add(CreateDots());
                _pnlPagination.Controls.Add(CreatePageButton(TotalPages.ToString(), true, () => SetPage(TotalPages)));
            }

            // Nút Next
            _pnlPagination.Controls.Add(CreatePageButton(">", CurrentPage < TotalPages, () => SetPage(CurrentPage + 1)));
        }

        // Helper tạo nút
        private Guna2Button CreatePageButton(string text, bool enabled, Action onClick, bool isActive = false)
        {
            Guna2Button btn = new Guna2Button();
            btn.Text = text;
            btn.Enabled = enabled;
            btn.Cursor = enabled ? Cursors.Hand : Cursors.Default;
            btn.Size = new Size(45, 36); // Kích thước chuẩn
            btn.BorderRadius = 8;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Margin = new Padding(3, 0, 3, 0);

            if (isActive)
            {
                btn.FillColor = Color.FromArgb(37, 99, 235); // Blue active
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.FillColor = Color.White;
                btn.ForeColor = Color.DimGray;
                btn.BorderColor = Color.LightGray;
                btn.BorderThickness = 1;
                btn.HoverState.FillColor = Color.WhiteSmoke;
            }

            if (!enabled) btn.FillColor = Color.WhiteSmoke; // Disabled style

            btn.Click += (s, e) => onClick?.Invoke();
            return btn;
        }

        private Label CreateDots()
        {
            return new Label()
            {
                Text = "...",
                AutoSize = false,
                Size = new Size(30, 36),
                TextAlign = ContentAlignment.BottomCenter,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Margin = new Padding(0)
            };
        }
    }
}