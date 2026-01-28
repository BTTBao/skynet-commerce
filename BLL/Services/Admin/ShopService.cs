// Skynet_Commerce.BLL.Services.ShopService.cs
using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Ecommerce;
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

    public ShopFullDetailViewModel GetShopFullDetail(int shopId)
    {
        // 1. Lấy thông tin cơ bản + Chủ shop
        var shopData = (from s in _context.Shops
                        join u in _context.Users on s.AccountID equals u.AccountID
                        join a in _context.Accounts on s.AccountID equals a.AccountID
                        where s.ShopID == shopId
                        select new { s, u, a }).FirstOrDefault();

        if (shopData == null) return null;

        // 2. Lấy danh sách sản phẩm (Top 50)
        var products = _context.Products
                        .Where(p => p.ShopID == shopId)
                        .Select(p => new SimpleProductViewModel
                        {
                            ProductID = p.ProductID,
                            Name = p.Name,
                            Price = p.Price ?? 0,
                            Stock = p.StockQuantity ?? 0,
                            Sold = p.SoldCount ?? 0
                        }).OrderByDescending(p => p.Sold).Take(50).ToList();

        // 3. Lấy danh sách đơn hàng (Gần đây nhất)
        var orders = _context.Orders
                        .Where(o => o.ShopID == shopId)
                        .OrderByDescending(o => o.CreatedAt)
                        .Take(20)
                        .Select(o => new SimpleOrderViewModel
                        {
                            OrderID = o.OrderID,
                            TotalAmount = o.TotalAmount ?? 0,
                            Status = o.Status,
                            Date = o.CreatedAt ?? DateTime.Now
                        }).ToList();

        // 4. Tính toán thống kê
        // Giả sử Status = "Completed" mới tính doanh thu
        decimal revenue = _context.Orders
                            .Where(o => o.ShopID == shopId && o.Status == "Completed")
                            .Sum(o => o.TotalAmount) ?? 0;

        int totalOrderCount = _context.Orders.Count(o => o.ShopID == shopId);

        // 5. Map sang ViewModel
        return new ShopFullDetailViewModel
        {
            ShopID = shopData.s.ShopID,
            ShopName = shopData.s.ShopName,
            Description = shopData.s.Description,
            AvatarURL = shopData.s.AvatarURL,
            Status = (shopData.s.IsActive == true) ? "Active" : "Suspended",
            CreatedAt = shopData.s.CreatedAt ?? DateTime.Now,
            Rating = shopData.s.RatingAverage ?? 0,

            OwnerName = shopData.u.FullName,
            Email = shopData.a.Email,
            Phone = shopData.a.Phone, // Nếu Account có cột Phone

            TotalProducts = products.Count, // Hoặc count DB nếu list quá dài
            TotalOrders = totalOrderCount,
            TotalRevenue = revenue,

            TopProducts = products,
            RecentOrders = orders
        };
    }

    // Hàm update thông tin cơ bản (cho nút Lưu)
    public void UpdateShopBasicInfo(int shopId, string newName, string newDesc)
    {
        var shop = _context.Shops.Find(shopId);
        if (shop != null)
        {
            shop.ShopName = newName;
            shop.Description = newDesc;
            _context.SaveChanges();
        }
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

        // Chú ý: Kiểm tra kỹ chữ hoa/thường trong DB ("Pending" hay "pending")
        if (!reg.Status.Equals("pending", StringComparison.OrdinalIgnoreCase))
            throw new Exception("Đơn này đã được xử lý trước đó.");

        // KIỂM TRA LOGIC: 1 Account chỉ 1 Shop
        if (_context.Shops.Any(s => s.AccountID == reg.AccountID))
        {
            throw new Exception($"Tài khoản {reg.AccountID} đã sở hữu một cửa hàng rồi.");
        }

        try
        {
            // 2. Tạo Shop mới
            var newShop = new Shop
            {
                ShopName = reg.ShopName,
                AccountID = reg.AccountID,
                IsActive = true, // Shop hoạt động luôn
                RatingAverage = 0,
                CreatedAt = DateTime.Now,
                Description = reg.Description
                // Map thêm các field khác nếu có (Description, Address...)
            };
            _context.Shops.Add(newShop);

            // 3. Cập nhật trạng thái đơn đăng ký
            reg.Status = "Approved";
            // reg.UpdatedAt = DateTime.Now; // Nếu có cột này

            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
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