using Guna.UI2.WinForms;
using OfficeOpenXml;
using Skynet_Commerce.DAL.Entities;
using Skynet_Ecommerce.BLL.Services.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class SettlementForm : Form
    {
        private readonly SettlementService _settlementService;
        private List<ShopBalanceDTO> _allShops;
        private int _selectedShopId = 0;

        public SettlementForm()
        {
            InitializeComponent();
            _settlementService = new SettlementService();
        }

        private void SettlementForm_Load(object sender, EventArgs e)
        {
            LoadShopsData();
            SetupDataGridView();
            btnSettle.Enabled = false;
        }

        private void SetupDataGridView()
        {
            dgvShops.AutoGenerateColumns = false;
            dgvShops.Columns.Clear();

            // Cột ID
            dgvShops.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShopID",
                HeaderText = "ID",
                DataPropertyName = "ShopID",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột Tên Shop
            dgvShops.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShopName",
                HeaderText = "Tên Cửa Hàng",
                DataPropertyName = "ShopName",
                Width = 250
            });

            // Cột SĐT
            dgvShops.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShopOwnerPhone",
                HeaderText = "SĐT Chủ Shop",
                DataPropertyName = "ShopOwnerPhone",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột Tiền Bị Giữ
            dgvShops.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LockedBalance",
                HeaderText = "Tiền Bị Giữ (đ)",
                DataPropertyName = "LockedBalance",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    ForeColor = Color.FromArgb(255, 152, 0)
                }
            });

            // Cột Số Dư Khả Dụng
            dgvShops.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AvailableBalance",
                HeaderText = "Số Dư Khả Dụng (đ)",
                DataPropertyName = "AvailableBalance",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    ForeColor = Color.FromArgb(0, 150, 136)
                }
            });

            dgvShops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadShopsData()
        {
            try
            {
                _allShops = _settlementService.GetShopBalances();
                dgvShops.DataSource = _allShops;

                // Reset panel thông tin
                ResetActionPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetActionPanel()
        {
            lblShopInfo.Text = "Chưa chọn Shop nào...";
            lblOrderCount.Text = "0";
            lblAmount.Text = "0 đ";
            btnSettle.Enabled = false;
            _selectedShopId = 0;
        }

        private void dgvShops_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShops.SelectedRows.Count == 0)
            {
                ResetActionPanel();
                return;
            }

            var selectedRow = dgvShops.SelectedRows[0];
            int shopId = Convert.ToInt32(selectedRow.Cells["ShopID"].Value);

            _selectedShopId = shopId;

            try
            {
                // Lấy chi tiết thanh toán
                var detail = _settlementService.GetSettlementDetail(shopId);

                // Hiển thị thông tin
                lblShopInfo.Text = $"{detail.ShopName} (ID: {detail.ShopID})";
                lblOrderCount.Text = $"{detail.DeliveredOrdersCount} đơn hàng";
                lblAmount.Text = $"{detail.AvailableBalance:N0} đ";

                // Enable nút thanh toán nếu có số dư
                btnSettle.Enabled = detail.AvailableBalance > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết Shop: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (_selectedShopId == 0)
            {
                MessageBox.Show("Vui lòng chọn Shop cần thanh toán!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi thanh toán
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn THANH TOÁN cho Shop này?\n\n" +
                $"Shop: {lblShopInfo.Text}\n" +
                $"Số tiền: {lblAmount.Text}\n\n" +
                $"Lưu ý: Các đơn hàng 'Delivered' sẽ chuyển sang 'Settled' và không thể hoàn tác!",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                // Lấy AdminID từ Session
                int adminId = AppSession.Instance.AccountID;

                // Gọi service thực hiện thanh toán
                bool success = _settlementService.SettleForShop(_selectedShopId, adminId);

                if (success)
                {
                    MessageBox.Show(
                        "Thanh toán thành công!\n\nCác đơn hàng đã được chuyển sang trạng thái 'Settled'.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Reload lại dữ liệu
                    LoadShopsData();
                }
                else
                {
                    MessageBox.Show(
                        "Thanh toán thất bại! Vui lòng thử lại.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực hiện thanh toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    dgvShops.DataSource = _allShops;
                }
                else
                {
                    var filtered = _settlementService.SearchShops(searchTerm);
                    dgvShops.DataSource = filtered;
                }

                ResetActionPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkFilterBalance_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkFilterBalance.Checked)
                {
                    // Chỉ hiển thị Shop có số dư > 0
                    var filtered = _settlementService.FilterShopsWithBalance();
                    dgvShops.DataSource = filtered;
                }
                else
                {
                    // Hiển thị tất cả
                    dgvShops.DataSource = _allShops;
                }

                ResetActionPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thiết lập EPPlus License Context
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = $"DanhSachDoiSoat_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    sfd.Title = "Xuất danh sách đối soát ra Excel";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Danh Sách Đối Soát");

                            // Header
                            worksheet.Cells[1, 1].Value = "ID";
                            worksheet.Cells[1, 2].Value = "Tên Cửa Hàng";
                            worksheet.Cells[1, 3].Value = "SĐT Chủ Shop";
                            worksheet.Cells[1, 4].Value = "Tiền Bị Giữ (đ)";
                            worksheet.Cells[1, 5].Value = "Số Dư Khả Dụng (đ)";

                            // Style header
                            using (var range = worksheet.Cells[1, 1, 1, 5])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(20, 30, 50));
                                range.Style.Font.Color.SetColor(Color.White);
                                range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            }

                            // Data
                            var currentData = (List<ShopBalanceDTO>)dgvShops.DataSource;
                            int row = 2;
                            foreach (var shop in currentData)
                            {
                                worksheet.Cells[row, 1].Value = shop.ShopID;
                                worksheet.Cells[row, 2].Value = shop.ShopName;
                                worksheet.Cells[row, 3].Value = shop.ShopOwnerPhone;
                                worksheet.Cells[row, 4].Value = shop.LockedBalance;
                                worksheet.Cells[row, 5].Value = shop.AvailableBalance;

                                // Format số tiền
                                worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0";
                                worksheet.Cells[row, 5].Style.Numberformat.Format = "#,##0";

                                row++;
                            }

                            // Auto-fit columns
                            worksheet.Cells.AutoFitColumns();

                            // Lưu file
                            FileInfo fileInfo = new FileInfo(sfd.FileName);
                            package.SaveAs(fileInfo);

                            MessageBox.Show($"Xuất Excel thành công!\n\nĐường dẫn: {sfd.FileName}",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở file sau khi xuất (tùy chọn)
                            var result = MessageBox.Show("Bạn có muốn mở file Excel vừa xuất không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            
                            if (result == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(sfd.FileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
