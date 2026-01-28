using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Services.Admin;
using OfficeOpenXml;
using System.IO;

namespace Skynet_Commerce.GUI.Forms.Admin
{
    public partial class PaymentHistoryForm : Form
    {
        private PaymentHistoryService _service;
        private List<PaymentHistoryDTO> _currentData;

        public PaymentHistoryForm()
        {
            InitializeComponent();
            _service = new PaymentHistoryService();
            _currentData = new List<PaymentHistoryDTO>();
        }

        private void PaymentHistoryForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadShopsDropdown();
            LoadPaymentHistory();
        }
        private void SetupDataGridView()
        {
            dgvPaymentHistory.Columns.Clear();
            dgvPaymentHistory.AutoGenerateColumns = false;

            // Cấu hình chung để dùng lại cho gọn (căn giữa toàn bộ)
            var centerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            var moneyStyle = new DataGridViewCellStyle
            {
                Format = "N0",
                Alignment = DataGridViewContentAlignment.MiddleCenter, // SỬA: Canh giữa số tiền
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            var feeStyle = new DataGridViewCellStyle
            {
                Format = "N0",
                Alignment = DataGridViewContentAlignment.MiddleCenter, // SỬA: Canh giữa phí
                ForeColor = Color.FromArgb(239, 68, 68)
            };

            var netStyle = new DataGridViewCellStyle
            {
                Format = "N0",
                Alignment = DataGridViewContentAlignment.MiddleCenter, // SỬA: Canh giữa thực nhận
                ForeColor = Color.FromArgb(0, 150, 136),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            // 1. SettlementID
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SettlementID",
                HeaderText = "ID",
                Name = "colSettlementID",
                Width = 60,
                DefaultCellStyle = centerStyle
            });

            // 2. SettlementDate
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SettlementDate",
                HeaderText = "Ngày thanh toán",
                Name = "colSettlementDate",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // 3. ShopName
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ShopName",
                HeaderText = "Cửa hàng",
                Name = "colShopName",
                Width = 180,
                DefaultCellStyle = centerStyle
            });

            // 4. ShopOwnerPhone
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ShopOwnerPhone",
                HeaderText = "SĐT Chủ shop",
                Name = "colShopOwnerPhone",
                Width = 120,
                DefaultCellStyle = centerStyle
            });

            // 5. OrderCount
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderCount",
                HeaderText = "Số đơn",
                Name = "colOrderCount",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(59, 130, 246)
                }
            });

            // 6. TotalAmount (Tiền)
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Tổng giá trị",
                Name = "colTotalAmount",
                Width = 130,
                DefaultCellStyle = moneyStyle // Đã set canh giữa ở trên
            });

            // 7. PlatformFee (Tiền)
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PlatformFee",
                HeaderText = "Phí nền tảng",
                Name = "colPlatformFee",
                Width = 130,
                DefaultCellStyle = feeStyle // Đã set canh giữa ở trên
            });

            // 8. NetAmount (Tiền)
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NetAmount",
                HeaderText = "Thực thanh toán",
                Name = "colNetAmount",
                Width = 150,
                DefaultCellStyle = netStyle // Đã set canh giữa ở trên
            });

            // 9. ProcessedBy
            dgvPaymentHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProcessedBy",
                HeaderText = "Người xử lý",
                Name = "colProcessedBy",
                Width = 150,
                DefaultCellStyle = centerStyle
            });

            dgvPaymentHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadShopsDropdown()
        {
            var shops = _service.GetShopsWithPaymentHistory();
            
            // Add "All" option
            var allShops = new List<ShopDropdownDTO>
            {
                new ShopDropdownDTO { ShopID = 0, ShopName = "-- Tất cả cửa hàng --" }
            };
            allShops.AddRange(shops);

            cboShop.DataSource = allShops;
            cboShop.DisplayMember = "ShopName";
            cboShop.ValueMember = "ShopID";
        }

        private void LoadPaymentHistory()
        {
            _currentData = _service.GetAllPaymentHistory();
            dgvPaymentHistory.DataSource = _currentData;
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            lblTotalRecords.Text = $"Tổng: {_currentData.Count} bản ghi";
            
            decimal totalAmount = _currentData.Sum(x => x.TotalAmount);
            decimal totalFee = _currentData.Sum(x => x.PlatformFee);
            decimal totalNet = _currentData.Sum(x => x.NetAmount);

            lblTotalAmount.Text = $"Tổng giá trị: {totalAmount:N0} ₫";
            lblTotalFee.Text = $"Phí nền tảng: {totalFee:N0} ₫";
            lblTotalNet.Text = $"Thực thanh toán: {totalNet:N0} ₫";
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            int selectedShopId = (int)cboShop.SelectedValue;

            // Apply filters
            var filtered = _service.FilterByDateRange(startDate, endDate);

            if (selectedShopId > 0)
            {
                filtered = filtered.Where(x => x.ShopID == selectedShopId).ToList();
            }

            _currentData = filtered;
            dgvPaymentHistory.DataSource = _currentData;
            UpdateSummary();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadPaymentHistory();
            }
            else
            {
                _currentData = _service.SearchByShopName(searchTerm);
                dgvPaymentHistory.DataSource = _currentData;
                UpdateSummary();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Lịch sử thanh toán");

                    // Headers
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "Ngày thanh toán";
                    worksheet.Cells[1, 3].Value = "Cửa hàng";
                    worksheet.Cells[1, 4].Value = "SĐT Chủ shop";
                    worksheet.Cells[1, 5].Value = "Số đơn";
                    worksheet.Cells[1, 6].Value = "Tổng giá trị";
                    worksheet.Cells[1, 7].Value = "Phí nền tảng";
                    worksheet.Cells[1, 8].Value = "Thực thanh toán";
                    worksheet.Cells[1, 9].Value = "Người xử lý";

                    // Style header
                    using (var range = worksheet.Cells[1, 1, 1, 9])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(20, 30, 50));
                        range.Style.Font.Color.SetColor(Color.White);
                    }

                    // Data
                    for (int i = 0; i < _currentData.Count; i++)
                    {
                        var item = _currentData[i];
                        int row = i + 2;

                        worksheet.Cells[row, 1].Value = item.SettlementID;
                        worksheet.Cells[row, 2].Value = item.SettlementDate.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cells[row, 3].Value = item.ShopName;
                        worksheet.Cells[row, 4].Value = item.ShopOwnerPhone;
                        worksheet.Cells[row, 5].Value = item.OrderCount;
                        worksheet.Cells[row, 6].Value = item.TotalAmount;
                        worksheet.Cells[row, 7].Value = item.PlatformFee;
                        worksheet.Cells[row, 8].Value = item.NetAmount;
                        worksheet.Cells[row, 9].Value = item.ProcessedBy;
                    }

                    // Summary row
                    int summaryRow = _currentData.Count + 3;
                    worksheet.Cells[summaryRow, 5].Value = "TỔNG:";
                    worksheet.Cells[summaryRow, 5].Style.Font.Bold = true;
                    worksheet.Cells[summaryRow, 6].Value = _currentData.Sum(x => x.TotalAmount);
                    worksheet.Cells[summaryRow, 7].Value = _currentData.Sum(x => x.PlatformFee);
                    worksheet.Cells[summaryRow, 8].Value = _currentData.Sum(x => x.NetAmount);

                    // Format currency columns
                    worksheet.Cells[2, 6, _currentData.Count + 1, 8].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow, 6, summaryRow, 8].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow, 6, summaryRow, 8].Style.Font.Bold = true;

                    worksheet.Cells.AutoFitColumns();

                    // Save dialog
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = $"LichSuThanhToan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
