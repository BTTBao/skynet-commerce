using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopsForm : Form
    {
        private readonly ShopService _shopService;

        public ShopsForm()
        {
            InitializeComponent();
            _shopService = new ShopService();

            SetupStatusFilter();
        }


        private void SetupStatusFilter()
        {
            // A. Gỡ sự kiện để tránh lỗi Timing (sự kiện chạy khi chưa load xong data)
            _comboStatus.SelectedIndexChanged -= _comboStatus_SelectedIndexChanged;

            // B. Tạo danh sách tùy chọn
            var statusList = new List<ShopStatusOption>()
            {
                new ShopStatusOption { DisplayName = "Tất cả trạng thái", Value = "All Status" },
                new ShopStatusOption { DisplayName = "Đang hoạt động",    Value = "Active" },
                new ShopStatusOption { DisplayName = "Bị đình chỉ",       Value = "Suspended" }
            };

            // C. Gán dữ liệu (Binding)
            _comboStatus.DataSource = statusList;
            _comboStatus.DisplayMember = "DisplayName"; // Hiển thị tiếng Việt
            _comboStatus.ValueMember = "Value";         // Giá trị tiếng Anh

            // Chọn mặc định dòng đầu
            _comboStatus.StartIndex = 0;

            // D. Gán lại sự kiện sau khi đã setup xong
            _comboStatus.SelectedIndexChanged += _comboStatus_SelectedIndexChanged;
        }

        private void ShopsForm_Load(object sender, EventArgs e)
        {
            LoadPendingShops();
            LoadActiveShops();
        }

        private void LoadPendingShops()
        {
            _pendingContainer.Controls.Clear();

            // 1. Gọi Service lấy danh sách từ bảng ShopRegistration
            List<PendingShopViewModel> pendingList = _shopService.GetPendingRegistrations();

            if (pendingList.Count == 0)
            {
                // Ẩn card Pending
                _cardPending.Visible = false;

                // Kéo cardAllShops lên vị trí của pending
                _cardAllShops.Location = _cardPending.Location;

                // Tăng chiều cao cho cardAllShops nếu muốn
                _cardAllShops.Height += _cardPending.Height;
                _activeContainer.Height += _cardPending.Height;
                return;
            }

            // Nếu có pending thì hiển thị bình thường
            _cardPending.Visible = true;
            // 2. Duyệt và hiển thị lên giao diện
            foreach (var item in pendingList)
            {
                var row = new UcPendingShopRow();

                string dateStr = item.RequestDate.ToString("dd/MM/yyyy");

                // Truyền dữ liệu vào UserControl
                // Lưu ý: Bạn nên truyền cả item.RegistrationID gốc vào một biến ẩn trong UC để dùng cho nút Duyệt/Từ chối sau này
                row.SetData(item.RegistrationID, item.ShopName, item.OwnerName, item.Email, dateStr);

                // --- XỬ LÝ SỰ KIỆN DUYỆT ---
                row.OnApproveClicked += (sender, args) =>
                {
                    var uc = sender as UcPendingShopRow;
                    if (MessageBox.Show($"Bạn có chắc muốn duyệt đơn đăng ký của '{item.ShopName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            _shopService.ApproveShopRegistration(uc.RegistrationID);
                            MessageBox.Show("Đã duyệt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload lại cả 2 danh sách vì Shop Active sẽ tăng lên 1
                            LoadPendingShops();
                            LoadActiveShops();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                };

                // --- XỬ LÝ SỰ KIỆN TỪ CHỐI ---
                row.OnRejectClicked += (sender, args) =>
                {
                    var uc = sender as UcPendingShopRow;
                    if (MessageBox.Show($"Từ chối đơn đăng ký này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            _shopService.RejectShopRegistration(uc.RegistrationID);
                            MessageBox.Show("Đã từ chối đơn đăng ký.", "Thông báo");
                            LoadPendingShops();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                };
                // Gắn Tag để sau này dễ lấy ID khi click nút
                //row.Tag = item.RegistrationID;

                _pendingContainer.Controls.Add(row);
            }
        }
        
        // -- PHẦN ACTIVE SHOPS(ASYNC + FILTER) ---
        private void LoadActiveShops()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // 1. Lấy tham số từ UI
                string keyword = _txtSearch.Text.Trim();
                string status = "All Status";

                if (_comboStatus.SelectedValue != null)
                {
                    // Kiểm tra kiểu dữ liệu để tránh crash nếu SelectedValue trả về object
                    if (_comboStatus.SelectedValue is ShopStatusOption opt)
                    {
                        status = opt.Value;
                    }
                    else
                    {
                        status = _comboStatus.SelectedValue.ToString();
                    }
                }

                // 2. Gọi Service ở Background Thread
                ShopService service = new ShopService();
                List<ShopViewModel> shops = service.GetShops(keyword, status);

                // 3. Cập nhật UI
                _activeContainer.SuspendLayout(); // Chống giật khi vẽ lại
                _activeContainer.Controls.Clear();

                if (shops.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Không tìm thấy cửa hàng nào.",
                        AutoSize = true,
                        Padding = new Padding(20),
                        Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Italic),
                        ForeColor = System.Drawing.Color.Gray
                    };
                    _activeContainer.Controls.Add(lblEmpty);
                }
                else
                {
                    foreach (var shop in shops)
                    {
                        var row = new UcActiveShopRow();
                        row.SetData(shop);

                        // --- XỬ LÝ SỰ KIỆN XEM CHI TIẾT ---
                        row.OnViewClicked += (sender, args) =>
                        {
                            var uc = sender as UcActiveShopRow;

                            // Tạo form chi tiết
                            using (var detailForm = new ShopDetailForm(uc.ShopID))
                            {
                                // Hiện form và chờ kết quả trả về
                                var result = detailForm.ShowDialog();

                                // [QUAN TRỌNG] Kiểm tra nếu Form con trả về OK (tức là có thay đổi dữ liệu)
                                if (result == DialogResult.OK)
                                {
                                    // Thì load lại danh sách ở Form cha
                                    LoadActiveShops();
                                }
                            }
                        };

                        _activeContainer.Controls.Add(row);
                    }
                }
                _activeContainer.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách cửa hàng: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Chặn tiếng bip hệ thống
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
        public string DisplayName { get; set; } // Tiếng Việt
        public string Value { get; set; }       // Tiếng Anh (Logic/DB)
    }

}