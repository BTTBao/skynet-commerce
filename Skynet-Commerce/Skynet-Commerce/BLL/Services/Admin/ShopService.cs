// Skynet_Commerce.BLL.Services.ShopService.cs
using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class ShopService
{
    private readonly ApplicationDbContext _context; // Giả sử tên Context là SkynetContext

    public ShopService()
    {
        _context = new ApplicationDbContext();
    }

    // Hàm lấy chi tiết Shop và chuyển đổi sang ViewModel
    public ShopViewModel GetShopDetail(int shopId)
    {
        // Sử dụng LINQ Query để join bảng
        var query = from s in _context.Shops
                    join u in _context.Users on s.AccountID equals u.AccountID // Điểm mấu chốt: Join qua AccountID
                    where s.ShopID == shopId
                    select new
                    {
                        Shop = s,
                        OwnerName = u.FullName, // Lấy tên từ bảng User
                        ProductCount = s.Products.Count() // Đếm số sản phẩm
                    };

        var data = query.FirstOrDefault();

        if (data == null) return null;

        // Mapping sang ViewModel
        return new ShopViewModel
        {
            ShopID = data.Shop.ShopID,
            ShopName = data.Shop.ShopName,
            AccountID = data.Shop.AccountID,

            // Lấy OwnerName từ kết quả Join
            OwnerName = data.OwnerName,

            RatingAverage = data.Shop.RatingAverage ?? 0,

            // Lấy số lượng đã đếm
            StockQuantity = data.ProductCount,

            Status = (data.Shop.IsActive == true) ? "Active" : "Suspended"
        };
    }

    // Lấy danh sách Shop
    // Cập nhật hàm này để nhận tham số lọc
    public List<ShopViewModel> GetShops(string keyword = "", string status = "All Status")
    {
        // 1. Khởi tạo Query cơ bản
        var query = from s in _context.Shops
                    join u in _context.Users on s.AccountID equals u.AccountID
                    select new
                    {
                        Shop = s,
                        OwnerName = u.FullName,
                        ProductCount = s.Products.Count()
                    };

        // 2. Lọc theo Keyword (Tên Shop hoặc Tên Chủ Shop)
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.Shop.ShopName.Contains(keyword) || x.OwnerName.Contains(keyword));
        }

        // 3. Lọc theo Status
        if (status == "Active")
        {
            query = query.Where(x => x.Shop.IsActive == true);
        }
        else if (status == "Suspended") // Giả sử Suspended là IsActive = false
        {
            query = query.Where(x => x.Shop.IsActive == false);
        }

        // 4. Thực thi và Mapping (Projection)
        return query.ToList().Select(x => new ShopViewModel
        {
            ShopID = x.Shop.ShopID,
            ShopName = x.Shop.ShopName,
            OwnerName = x.OwnerName,
            RatingAverage = x.Shop.RatingAverage ?? 0,
            StockQuantity = x.ProductCount,
            Status = (x.Shop.IsActive == true) ? "Active" : "Suspended"
        }).ToList();
    }

    // Lấy danh sách Active (đã duyệt)
    public List<ShopViewModel> GetActiveShops()
    {
        // Logic: Lấy shop có IsActive = true
        var query = from s in _context.Shops
                    join u in _context.Users on s.AccountID equals u.AccountID
                    where s.IsActive == true
                    select new
                    {
                        Shop = s,
                        OwnerName = u.FullName,
                        ProductCount = s.Products.Count()
                    };

        // Query DB và convert sang ViewModel
        return query.ToList().Select(x => new ShopViewModel
        {
            ShopID = x.Shop.ShopID,
            ShopName = x.Shop.ShopName,
            OwnerName = x.OwnerName,
            RatingAverage = x.Shop.RatingAverage ?? 0,
            StockQuantity = x.ProductCount,
            Status = "Active"
        }).ToList();
    }

    public List<PendingShopViewModel> GetPendingRegistrations()
    {
        // Query cú pháp LINQ
        var query = from r in _context.ShopRegistrations
                    join a in _context.Accounts on r.AccountID equals a.AccountID
                    join u in _context.Users on r.AccountID equals u.AccountID

                    // ĐIỀU KIỆN LỌC QUAN TRỌNG NHẤT: Status là "pending"
                    where r.Status == "pending"

                    // Sắp xếp: Mới nhất lên đầu (tùy chọn)
                    orderby r.CreatedAt descending

                    select new PendingShopViewModel
                    {
                        RegistrationID = r.RegistrationID,
                        ShopName = r.ShopName,

                        // Lấy tên chủ từ bảng User
                        OwnerName = u.FullName,

                        // Lấy email từ bảng Account
                        Email = a.Email,

                        // Xử lý ngày tạo (nếu null thì lấy ngày hiện tại)
                        RequestDate = r.CreatedAt ?? DateTime.Now,

                        Status = r.Status
                    };

        return query.ToList();
    }

    public void ApproveShopRegistration(int registrationId)
    {
        var reg = _context.ShopRegistrations.FirstOrDefault(r => r.RegistrationID == registrationId);
        if (reg == null) throw new Exception("Không tìm thấy đơn đăng ký.");

        if (!reg.Status.Equals("pending", StringComparison.OrdinalIgnoreCase))
            throw new Exception("Đơn này đã được xử lý trước đó.");

        if (_context.Shops.Any(s => s.AccountID == reg.AccountID))
        {
            throw new Exception($"Tài khoản {reg.AccountID} đã sở hữu một cửa hàng rồi.");
        }

        try
        {
            // 1. Tạo Shop mới
            var newShop = new Shop
            {
                ShopName = reg.ShopName,
                AccountID = reg.AccountID,
                IsActive = true,
                RatingAverage = 0,
                CreatedAt = DateTime.Now,
                Description = reg.Description
            };
            _context.Shops.Add(newShop);

            // ==========================================================
            // [MỚI] 2. THÊM ROLE SELLER CHO ACCOUNT
            // ==========================================================
            // Kiểm tra xem user đã có role Seller chưa (để tránh lỗi UNIQUE KEY)
            var existingSellerRole = _context.UserRoles.FirstOrDefault(r =>
                r.AccountID == reg.AccountID && r.RoleName == "Seller"
            );

            if (existingSellerRole == null)
            {
                var newRole = new UserRole
                {
                    AccountID = reg.AccountID,
                    RoleName = "Seller", // Gán vai trò Seller
                    CreatedAt = DateTime.Now
                };
                _context.UserRoles.Add(newRole);
            }

            // 3. Cập nhật trạng thái đơn đăng ký
            reg.Status = "Approved";

            // 4. Lưu tất cả các thay đổi (Tạo Shop, Thêm Role, Cập nhật trạng thái)
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Kiểm tra lỗi UNIQUE KEY (nếu việc thêm Role bị lỗi)
            throw new Exception($"Lỗi trong quá trình duyệt: {ex.Message}");
        }
    }

    public void RejectShopRegistration(int registrationId)
    {
        var reg = _context.ShopRegistrations.FirstOrDefault(r => r.RegistrationID == registrationId);
        if (reg == null) throw new Exception("Không tìm thấy đơn đăng ký.");

        // Cập nhật trạng thái
        reg.Status = "Rejected";
        _context.SaveChanges();
    }

    public void ToggleShopStatus(int shopId)
    {
        var shop = _context.Shops.FirstOrDefault(s => s.ShopID == shopId);
        if (shop == null) throw new Exception("Không tìm thấy cửa hàng.");

        // Đảo ngược trạng thái: Nếu đang True (Active) -> False (Suspended) và ngược lại
        bool currentStatus = shop.IsActive ?? false;
        shop.IsActive = !currentStatus;

        _context.SaveChanges();
    }
}