USE Skynet_commerce;
GO

/* =====================================================
   TẠO DỮ LIỆU MẪU THỰC TẾ CHO HỆ THỐNG E-COMMERCE
   Bao gồm đầy đủ các nghiệp vụ và case đặc biệt
===================================================== */
-- Ngăn chặn trigger tự động tạo dữ liệu (ví dụ: tạo UserRole khi insert Account)
EXEC sp_msforeachtable 'ALTER TABLE ? DISABLE TRIGGER all';

-- Level: Chat & Flash Sales & Notifications
DELETE FROM ChatMessages;
DELETE FROM ChatRooms;
DELETE FROM FlashSaleProducts;
DELETE FROM FlashSales;
DELETE FROM Notifications;

-- Level: Order Processing & History
DELETE FROM OrderStatusHistory;
DELETE FROM OrderShippingInfo;
DELETE FROM Payments;
DELETE FROM Reviews;
DELETE FROM Wishlists;

-- Level: Order Details & Cart
DELETE FROM OrderDetails;
DELETE FROM CartItems;
DELETE FROM Carts;

-- Level: Orders & Vouchers
DELETE FROM Orders;
DELETE FROM OrderGroups;
DELETE FROM Vouchers;

-- Level: Products & Inventory
DELETE FROM ProductImages;
DELETE FROM ProductVariants;
DELETE FROM Products;
DELETE FROM Categories;

-- Level: Shops & Business
DELETE FROM Shops;
DELETE FROM ShopRegistrations;
DELETE FROM ShippingPartners;

-- Level: User Info
DELETE FROM UserAddresses;
DELETE FROM UserRoles;
DELETE FROM Users;

-- Level: Root
DELETE FROM Accounts;

-- 2. RESET IDENTITY (Để ID bắt đầu lại từ 1)
DBCC CHECKIDENT ('ChatMessages', RESEED, 0);
DBCC CHECKIDENT ('ChatRooms', RESEED, 0);
DBCC CHECKIDENT ('FlashSaleProducts', RESEED, 0);
DBCC CHECKIDENT ('FlashSales', RESEED, 0);
DBCC CHECKIDENT ('Notifications', RESEED, 0);
DBCC CHECKIDENT ('OrderStatusHistory', RESEED, 0);
DBCC CHECKIDENT ('OrderShippingInfo', RESEED, 0);
DBCC CHECKIDENT ('Payments', RESEED, 0);
DBCC CHECKIDENT ('Reviews', RESEED, 0);
DBCC CHECKIDENT ('Wishlists', RESEED, 0);
DBCC CHECKIDENT ('OrderDetails', RESEED, 0);
DBCC CHECKIDENT ('CartItems', RESEED, 0);
DBCC CHECKIDENT ('Carts', RESEED, 0);
DBCC CHECKIDENT ('Orders', RESEED, 0);
DBCC CHECKIDENT ('OrderGroups', RESEED, 0);
DBCC CHECKIDENT ('Vouchers', RESEED, 0);
DBCC CHECKIDENT ('ProductImages', RESEED, 0);
DBCC CHECKIDENT ('ProductVariants', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Shops', RESEED, 0);
DBCC CHECKIDENT ('ShopRegistrations', RESEED, 0);
DBCC CHECKIDENT ('ShippingPartners', RESEED, 0);
DBCC CHECKIDENT ('UserAddresses', RESEED, 0);
DBCC CHECKIDENT ('UserRoles', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);
DBCC CHECKIDENT ('Accounts', RESEED, 0);

PRINT '=== CLEANUP COMPLETED ===';
GO

-- ===== 1. ACCOUNTS =====
SET IDENTITY_INSERT Accounts ON;

INSERT INTO Accounts (AccountID, PasswordHash, Email, Phone, CreatedAt, IsActive) VALUES
-- Admin
(1, '123123', 'admin@skynet.vn', '0123456789', '2024-01-15 08:00:00', 1),

-- Sellers (Chủ Shop)
(2, '123123', 'contact@techzone.vn', '0901234567', '2024-02-10 09:30:00', 1),
(3, '123123', 'miumiu.fashion@gmail.com', '0912345678', '2024-02-15 10:15:00', 1),
(4, '123123', 'giadung.smart@outlook.com', '0923456789', '2024-03-01 11:00:00', 1),
(5, '123123', 'bookstore.hanoibook@gmail.com', '0934567890', '2024-03-10 14:20:00', 1),
(6, '123123', 'mypham.nature@gmail.com', '0945678901', '2024-03-20 15:30:00', 1),

-- Buyers (Người mua)
(7, '123123', 'khoi.tran2000@gmail.com', '0956789012', '2024-04-01 08:00:00', 1),
(8, '123123', 'huong.le.design@outlook.com', '0967890123', '2024-04-05 09:15:00', 1),
(9, '123123', 'anh.pham.dev@gmail.com', '0978901234', '2024-04-10 10:30:00', 1),
(10, '123123', 'tam.nguyen89@gmail.com', '0989012345', '2024-04-15 11:45:00', 1),
(11, '123123', 'linh.vo.student@gmail.com', '0990123456', '2024-04-20 13:00:00', 1),
(12, '123123', 'quang.hoang.photo@gmail.com', '0991234567', '2024-04-25 14:15:00', 1),
(13, '123123', 'mai.tran.makeup@outlook.com', '0992345678', '2024-05-01 15:30:00', 1),

-- User hủy đơn nhiều (cho fraud detection)
(14, '123123', 'hung.dao.fake@gmail.com', '0993456789', '2024-05-05 16:00:00', 1),

-- User clone account (dùng chung SĐT nhận hàng)
(15, '123123', 'clone1.user@gmail.com', '0994567890', '2024-05-10 17:00:00', 1),
(16, '123123', 'clone2.user@gmail.com', '0995678901', '2024-05-15 18:00:00', 1);

SET IDENTITY_INSERT Accounts OFF;


-- ===== 2. USERS =====
SET IDENTITY_INSERT Users ON;

INSERT INTO Users (UserID, AccountID, FullName, Gender, DateOfBirth, AvatarURL) VALUES
(1, 1, N'Nguyễn Hoàng Admin', 'Male', '1990-05-15', 'https://api.dicebear.com/7.x/avataaars/svg?seed=admin'),
(2, 2, N'Trần Minh Khôi', 'Male', '1995-03-20', 'https://api.dicebear.com/7.x/avataaars/svg?seed=khoi'),
(3, 3, N'Lê Thị Hương', 'Female', '1998-07-12', 'https://api.dicebear.com/7.x/avataaars/svg?seed=huong'),
(4, 4, N'Phạm Đức Anh', 'Male', '1992-11-08', 'https://api.dicebear.com/7.x/avataaars/svg?seed=anh'),
(5, 5, N'Nguyễn Thanh Tâm', 'Female', '1996-09-25', 'https://api.dicebear.com/7.x/avataaars/svg?seed=tam'),
(6, 6, N'Võ Minh Thu', 'Female', '1994-06-18', 'https://api.dicebear.com/7.x/avataaars/svg?seed=thu'),
(7, 7, N'Trần Minh Khôi', 'Male', '2000-01-15', 'https://api.dicebear.com/7.x/avataaars/svg?seed=khoi7'),
(8, 8, N'Lê Hương Giang', 'Female', '1999-04-22', 'https://api.dicebear.com/7.x/avataaars/svg?seed=giang'),
(9, 9, N'Phạm Anh Tuấn', 'Male', '1997-08-30', 'https://api.dicebear.com/7.x/avataaars/svg?seed=tuan'),
(10, 10, N'Nguyễn Thanh Tâm', 'Female', '1989-12-10', 'https://api.dicebear.com/7.x/avataaars/svg?seed=tam10'),
(11, 11, N'Võ Thanh Linh', 'Female', '2001-03-05', 'https://api.dicebear.com/7.x/avataaars/svg?seed=linh'),
(12, 12, N'Hoàng Văn Quang', 'Male', '1993-07-20', 'https://api.dicebear.com/7.x/avataaars/svg?seed=quang'),
(13, 13, N'Trần Phương Mai', 'Female', '1995-11-11', 'https://api.dicebear.com/7.x/avataaars/svg?seed=mai'),
(14, 14, N'Đào Minh Hùng', 'Male', '2002-02-28', 'https://api.dicebear.com/7.x/avataaars/svg?seed=hung'),
(15, 15, N'Nguyễn Thị Lan', 'Female', '2000-05-17', 'https://api.dicebear.com/7.x/avataaars/svg?seed=lan'),
(16, 16, N'Trần Văn Long', 'Male', '2001-09-09', 'https://api.dicebear.com/7.x/avataaars/svg?seed=long');

SET IDENTITY_INSERT Users OFF;

-- ===== 3. USER ROLES =====
SET IDENTITY_INSERT UserRoles ON;

INSERT INTO UserRoles (UserRoleID, AccountID, RoleName, CreatedAt) VALUES
-- Admin
(1, 1, 'Admin', '2024-01-15 08:00:00'),
(2, 1, 'Buyer', '2024-01-15 08:00:00'),

-- Sellers
(3, 2, 'Seller', '2024-02-10 09:30:00'),
(4, 2, 'Buyer', '2024-02-10 09:30:00'),
(5, 3, 'Seller', '2024-02-15 10:15:00'),
(6, 3, 'Buyer', '2024-02-15 10:15:00'),
(7, 4, 'Seller', '2024-03-01 11:00:00'),
(8, 4, 'Buyer', '2024-03-01 11:00:00'),
(9, 5, 'Seller', '2024-03-10 14:20:00'),
(10, 5, 'Buyer', '2024-03-10 14:20:00'),
(11, 6, 'Seller', '2024-03-20 15:30:00'),
(12, 6, 'Buyer', '2024-03-20 15:30:00'),

-- Buyers only
(13, 7, 'Buyer', '2024-04-01 08:00:00'),
(14, 8, 'Buyer', '2024-04-05 09:15:00'),
(15, 9, 'Buyer', '2024-04-10 10:30:00'),
(16, 10, 'Buyer', '2024-04-15 11:45:00'),
(17, 11, 'Buyer', '2024-04-20 13:00:00'),
(18, 12, 'Buyer', '2024-04-25 14:15:00'),
(19, 13, 'Buyer', '2024-05-01 15:30:00'),
(20, 14, 'Buyer', '2024-05-05 16:00:00'),
(21, 15, 'Buyer', '2024-05-10 17:00:00'),
(22, 16, 'Buyer', '2024-05-15 18:00:00');

SET IDENTITY_INSERT UserRoles OFF;


-- ===== 4. USER ADDRESSES =====
SET IDENTITY_INSERT UserAddresses ON;

INSERT INTO UserAddresses (AddressID, AccountID, AddressName, ReceiverFullName, ReceiverPhone, AddressLine, Ward, District, Province, IsDefault) VALUES
-- Admin
(1, 1, N'Nhà riêng', N'Nguyễn Hoàng Admin', '0123456789', N'123 Nguyễn Trãi', N'Phường Thượng Đình', N'Quận Thanh Xuân', N'Hà Nội', 1),

-- Sellers
(2, 2, N'Văn phòng', N'Trần Minh Khôi', '0901234567', N'45 Lê Duẩn', N'Phường Bến Nghé', N'Quận 1', N'TP. Hồ Chí Minh', 1),
(3, 3, N'Shop', N'Lê Thị Hương', '0912345678', N'78 Trần Phú', N'Phường Hải Châu 1', N'Quận Hải Châu', N'Đà Nẵng', 1),
(4, 4, N'Kho hàng', N'Phạm Đức Anh', '0923456789', N'234 Hoàng Quốc Việt', N'Phường Nghĩa Đô', N'Quận Cầu Giấy', N'Hà Nội', 1),
(5, 5, N'Cửa hàng', N'Nguyễn Thanh Tâm', '0934567890', N'567 Lý Thường Kiệt', N'Phường 14', N'Quận 10', N'TP. Hồ Chí Minh', 1),
(6, 6, N'Showroom', N'Võ Minh Thu', '0945678901', N'89 Hai Bà Trưng', N'Phường Bến Nghé', N'Quận 1', N'TP. Hồ Chí Minh', 1),

-- Buyers
(7, 7, N'Nhà riêng', N'Trần Minh Khôi', '0956789012', N'12 Nguyễn Văn Linh', N'Phường Gia Thụy', N'Quận Long Biên', N'Hà Nội', 1),
(8, 8, N'Văn phòng', N'Lê Hương Giang', '0967890123', N'34 Lê Lợi', N'Phường Bến Thành', N'Quận 1', N'TP. Hồ Chí Minh', 1),
(9, 9, N'Nhà riêng', N'Phạm Anh Tuấn', '0978901234', N'56 Nguyễn Huệ', N'Phường Bến Nghé', N'Quận 1', N'TP. Hồ Chí Minh', 1),
(10, 10, N'Nhà riêng', N'Nguyễn Thanh Tâm', '0989012345', N'78 Trường Chinh', N'Phường Phương Liệt', N'Quận Thanh Xuân', N'Hà Nội', 1),
(11, 11, N'Ký túc xá', N'Võ Thanh Linh', '0990123456', N'Khu A, ĐHQG', N'Phường Đông Hòa', N'Quận Dĩ An', N'Bình Dương', 1),
(12, 12, N'Studio', N'Hoàng Văn Quang', '0991234567', N'90 Pasteur', N'Phường Nguyễn Thái Bình', N'Quận 1', N'TP. Hồ Chí Minh', 1),
(13, 13, N'Nhà riêng', N'Trần Phương Mai', '0992345678', N'123 Lạc Long Quân', N'Phường Nghĩa Đô', N'Quận Cầu Giấy', N'Hà Nội', 1),
(14, 14, N'Nhà riêng', N'Đào Minh Hùng', '0993456789', N'45 Hoàng Diệu', N'Phường 12', N'Quận 4', N'TP. Hồ Chí Minh', 1),

-- Clone accounts - dùng CHUNG SĐT nhận hàng (0888888888)
(15, 15, N'Địa chỉ 1', N'Người nhận A', '0888888888', N'67 Nguyễn Thị Minh Khai', N'Phường Bến Thành', N'Quận 1', N'TP. Hồ Chí Minh', 1),
(16, 16, N'Địa chỉ 2', N'Người nhận B', '0888888888', N'89 Lê Thánh Tôn', N'Phường Bến Nghé', N'Quận 1', N'TP. Hồ Chí Minh', 1);

SET IDENTITY_INSERT UserAddresses OFF;


-- ===== 5. SHOP REGISTRATIONS =====
SET IDENTITY_INSERT ShopRegistrations ON;

INSERT INTO ShopRegistrations (RegistrationID, AccountID, ShopName, Description, Status, CreatedAt, ReviewedAt, CitizenID, CitizenImageURL) VALUES
-- Approved
(1, 2, N'TechZone Official', N'Chuyên cung cấp thiết bị điện tử chính hãng', 'Approved', '2024-02-10 09:30:00', '2024-02-11 10:00:00', '001095012345', 'https://cdn.example.com/citizen/001.jpg'),
(2, 3, N'Thời Trang MiuMiu', N'Thời trang nữ cao cấp, phong cách Hàn Quốc', 'Approved', '2024-02-15 10:15:00', '2024-02-16 11:00:00', '001096023456', 'https://cdn.example.com/citizen/002.jpg'),
(3, 4, N'Gia Dụng Thông Minh', N'Thiết bị gia dụng hiện đại, tiện lợi', 'Approved', '2024-03-01 11:00:00', '2024-03-02 14:00:00', '001092034567', 'https://cdn.example.com/citizen/003.jpg'),
(4, 5, N'Nhà Sách Hà Nội Book', N'Sách văn học, kinh tế, kỹ năng sống', 'Approved', '2024-03-10 14:20:00', '2024-03-11 15:00:00', '001094045678', 'https://cdn.example.com/citizen/004.jpg'),
(5, 6, N'Mỹ Phẩm Nature Beauty', N'Mỹ phẩm thiên nhiên, organic', 'Approved', '2024-03-20 15:30:00', '2024-03-21 16:00:00', '001093056789', 'https://cdn.example.com/citizen/005.jpg'),

-- Pending (chờ duyệt)
(6, 7, N'Shop Phụ Kiện XiTrum', N'Phụ kiện điện thoại, tai nghe, sạc dự phòng', 'Pending', '2025-01-20 10:00:00', NULL, '001097067890', 'https://cdn.example.com/citizen/006.jpg'),

-- Rejected (bị từ chối)
(7, 8, N'Shop Hàng Fake Pro', N'Chuyên hàng replica', 'Rejected', '2025-01-15 09:00:00', '2025-01-16 10:00:00', '001098078901', NULL);

SET IDENTITY_INSERT ShopRegistrations OFF;


-- ===== 6. SHOPS =====
SET IDENTITY_INSERT Shops ON;

INSERT INTO Shops (ShopID, AccountID, ShopName, Description, AvatarURL, CoverImageURL, IsActive, CreatedAt, RatingAverage) VALUES
(1, 2, N'TechZone Official', N'Cửa hàng điện tử uy tín với hơn 5 năm kinh nghiệm. Cam kết 100% hàng chính hãng, bảo hành đầy đủ.', 
    'https://api.dicebear.com/7.x/shapes/svg?seed=techzone', 
    'https://images.unsplash.com/photo-1519389950473-47ba0277781c?w=1200', 
    1, '2024-02-11 10:30:00', 4.8),

(2, 3, N'Thời Trang MiuMiu', N'Thương hiệu thời trang nữ phong cách Hàn Quốc. Hàng mới về mỗi tuần, giá cả phải chăng.', 
    'https://api.dicebear.com/7.x/shapes/svg?seed=miumiu', 
    'https://images.unsplash.com/photo-1441986300917-64674bd600d8?w=1200', 
    1, '2024-02-16 11:30:00', 4.7),

(3, 4, N'Gia Dụng Thông Minh', N'Thiết bị gia dụng cao cấp, công nghệ hiện đại. Giao hàng toàn quốc, lắp đặt tận nhà.', 
    'https://api.dicebear.com/7.x/shapes/svg?seed=giadung', 
    'https://images.unsplash.com/photo-1556910103-1c02745aae4d?w=1200', 
    1, '2024-03-02 14:30:00', 4.6),

(4, 5, N'Nhà Sách Hà Nội Book', N'Kho sách phong phú với hơn 10,000 đầu sách. Hỗ trợ đặt sách theo yêu cầu.', 
    'https://api.dicebear.com/7.x/shapes/svg?seed=bookstore', 
    'https://images.unsplash.com/photo-1507842217343-583bb7270b66?w=1200', 
    1, '2024-03-11 15:30:00', 4.9),

(5, 6, N'Mỹ Phẩm Nature Beauty', N'Mỹ phẩm thiên nhiên, không chứa hóa chất độc hại. An toàn cho mọi loại da.', 
    'https://api.dicebear.com/7.x/shapes/svg?seed=beauty', 
    'https://images.unsplash.com/photo-1596462502278-27bfdc403348?w=1200', 
    1, '2024-03-21 16:30:00', 4.5);

SET IDENTITY_INSERT Shops OFF;


-- ===== 7. CATEGORIES =====
SET IDENTITY_INSERT Categories ON;

INSERT INTO Categories (CategoryID, CategoryName, ParentCategoryID) VALUES
-- Level 1
(1, N'Điện tử - Công nghệ', NULL),
(2, N'Thời trang', NULL),
(3, N'Gia dụng', NULL),
(4, N'Sách - Văn phòng phẩm', NULL),
(5, N'Làm đẹp - Sức khỏe', NULL),

-- Level 2 - Điện tử
(6, N'Điện thoại', 1),
(7, N'Laptop', 1),
(8, N'Phụ kiện', 1),
(9, N'Tai nghe', 1),

-- Level 2 - Thời trang
(10, N'Thời trang nữ', 2),
(11, N'Thời trang nam', 2),
(12, N'Giày dép', 2),
(13, N'Túi xách', 2),

-- Level 2 - Gia dụng
(14, N'Nhà bếp', 3),
(15, N'Đồ dùng nhà tắm', 3),
(16, N'Trang trí nội thất', 3),

-- Level 2 - Sách
(17, N'Sách văn học', 4),
(18, N'Sách kinh tế', 4),
(19, N'Sách kỹ năng', 4),

-- Level 2 - Làm đẹp
(20, N'Chăm sóc da', 5),
(21, N'Trang điểm', 5),
(22, N'Chăm sóc tóc', 5);

SET IDENTITY_INSERT Categories OFF;


-- ===== 8. PRODUCTS =====
SET IDENTITY_INSERT Products ON;

INSERT INTO Products (ProductID, ShopID, CategoryID, Name, Description, Price, StockQuantity, SoldCount, Status, CreatedAt) VALUES
-- TechZone Official (ShopID = 1)
(1, 1, 6, N'iPhone 15 Pro Max 256GB', N'iPhone 15 Pro Max chính hãng VN/A, mới 100%, nguyên seal. Chip A17 Pro mạnh mẽ, camera 48MP, pin trâu.', 29990000, 50, 125, 'Active', '2024-02-15 10:00:00'),
(2, 1, 6, N'Samsung Galaxy S24 Ultra', N'Samsung S24 Ultra bản Snapdragon, RAM 12GB, màn hình Dynamic AMOLED 2X 6.8 inch.', 27990000, 35, 89, 'Active', '2024-02-20 11:00:00'),
(3, 1, 7, N'MacBook Air M3 13 inch', N'MacBook Air M3 chip mới nhất, RAM 16GB, SSD 512GB. Mỏng nhẹ, pin 18 giờ.', 31990000, 25, 67, 'Active', '2024-03-01 09:00:00'),
(4, 1, 7, N'Dell XPS 13 Plus', N'Dell XPS 13 Plus Core i7-13700H, RAM 16GB, SSD 512GB, màn hình 13.4 inch FHD+.', 28990000, 20, 34, 'Active', '2024-03-10 10:00:00'),
(5, 1, 9, N'AirPods Pro 2023', N'AirPods Pro Gen 2 với chip H2, chống ồn chủ động, hộp sạc USB-C.', 5990000, 100, 256, 'Active', '2024-02-25 14:00:00'),
(6, 1, 9, N'Sony WH-1000XM5', N'Tai nghe Sony WH-1000XM5 chống ồn hàng đầu, âm thanh Hi-Res, pin 30 giờ.', 7990000, 45, 112, 'Active', '2024-03-05 15:00:00'),

-- Thời Trang MiuMiu (ShopID = 2)
(7, 2, 10, N'Áo thun nữ basic cotton', N'Áo thun nữ cotton 100%, form rộng phong cách Hàn Quốc. Có 5 màu: trắng, đen, be, xanh, hồng.', 129000, 200, 487, 'Active', '2024-02-20 10:00:00'),
(8, 2, 10, N'Váy maxi hoa nhí', N'Váy maxi dài chất voan mềm mại, họa tiết hoa nhí vintage. Thích hợp dạo phố, đi biển.', 359000, 80, 234, 'Active', '2024-03-01 11:00:00'),
(9, 2, 10, N'Quần jeans nữ ống rộng', N'Quần jeans ống rộng phong cách Hàn Quốc, vải denim cao cấp, không phai màu.', 449000, 120, 345, 'Active', '2024-03-10 12:00:00'),
(10, 2, 12, N'Giày sneaker nữ trắng', N'Giày sneaker nữ da trắng tinh khôi, đế cao 3cm. Dễ phối đồ, đi êm chân.', 289000, 150, 412, 'Active', '2024-02-25 13:00:00'),
(11, 2, 13, N'Túi tote vải canvas', N'Túi tote vải canvas dày dặn, in hình thỏ xinh xắn. Đựng vừa laptop 14 inch.', 159000, 180, 523, 'Active', '2024-03-15 14:00:00'),

-- Gia Dụng Thông Minh (ShopID = 3)
(12, 3, 14, N'Nồi cơm điện Panasonic 1.8L', N'Nồi cơm điện Panasonic 1.8L, công nghệ nấu 3D, giữ ấm 24h. Bảo hành 12 tháng.', 1590000, 60, 178, 'Active', '2024-03-05 10:00:00'),
(13, 3, 14, N'Máy xay sinh tố Philips', N'Máy xay sinh tố Philips công suất 700W, cối thủy tinh 2L, 6 lưỡi dao.', 1290000, 45, 134, 'Active', '2024-03-10 11:00:00'),
(14, 3, 14, N'Bếp từ đôi Sunhouse', N'Bếp từ đôi Sunhouse 4000W, mặt kính Schott Ceran Đức, 10 mức công suất.', 3590000, 30, 89, 'Active', '2024-03-15 12:00:00'),
(15, 3, 15, N'Máy lọc nước RO Kangaroo', N'Máy lọc nước RO Kangaroo 10 lõi, công nghệ Hydrogen, LED UV. Bảo hành 3 năm.', 4990000, 40, 67, 'Active', '2024-03-20 13:00:00'),

-- Nhà Sách Hà Nội Book (ShopID = 4)
(16, 4, 17, N'Nhà Giả Kim - Paulo Coelho', N'Bản dịch mới nhất của Nhà Giả Kim, bìa cứng cao cấp. Tiểu thuyết triết lý nổi tiếng thế giới.', 89000, 200, 1234, 'Active', '2024-03-15 10:00:00'),
(17, 4, 18, N'Đắc Nhân Tâm - Dale Carnegie', N'Cuốn sách kinh điển về kỹ năng giao tiếp và làm việc với con người.', 79000, 250, 1567, 'Active', '2024-03-16 11:00:00'),
(18, 4, 19, N'Atomic Habits - James Clear', N'Hướng dẫn xây dựng thói quen tốt và loại bỏ thói quen xấu một cách khoa học.', 135000, 180, 892, 'Active', '2024-03-17 12:00:00'),
(19, 4, 17, N'Sapiens - Yuval Noah Harari', N'Lược sử loài người - cuốn sách bán chạy nhất thế giới về lịch sử nhân loại.', 189000, 120, 678, 'Active', '2024-03-18 13:00:00'),

-- Mỹ Phẩm Nature Beauty (ShopID = 5)
(20, 5, 20, N'Kem dưỡng ẩm Cocoon', N'Kem dưỡng ẩm Cocoon chiết xuất dừa Bến Tre, phù hợp mọi loại da.', 179000, 150, 456, 'Active', '2024-03-25 10:00:00'),
(21, 5, 20, N'Serum Vitamin C Klairs', N'Serum Vitamin C Klairs làm sáng da, mờ thâm nám. Không gây kích ứng.', 449000, 100, 334, 'Active', '2024-03-26 11:00:00'),
(22, 5, 21, N'Son kem lì 3CE', N'Son kem lì 3CE màu cam đất, lâu trôi, không khô môi. Phù hợp da vàng.', 299000, 200, 678, 'Active', '2024-03-27 12:00:00'),
(23, 5, 22, N'Dầu gội Argan Oil', N'Dầu gội Argan Oil phục hồi tóc hư tổn, mềm mượt, không chứa paraben.', 259000, 120, 234, 'Active', '2024-03-28 13:00:00');

SET IDENTITY_INSERT Products OFF;


-- ===== 9. PRODUCT IMAGES =====
SET IDENTITY_INSERT ProductImages ON;

INSERT INTO ProductImages (ImageID, ProductID, ImageURL, IsPrimary) VALUES
-- iPhone 15 Pro Max
(1, 1, 'https://cdn.tgdd.vn/Products/Images/42/305658/iphone-15-pro-max-blue-1.jpg', 1),
(2, 1, 'https://cdn.tgdd.vn/Products/Images/42/305658/iphone-15-pro-max-blue-2.jpg', 0),

-- Samsung S24 Ultra
(3, 2, 'https://cdn.tgdd.vn/Products/Images/42/307174/samsung-galaxy-s24-ultra-grey-1.jpg', 1),
(4, 2, 'https://cdn.tgdd.vn/Products/Images/42/307174/samsung-galaxy-s24-ultra-grey-2.jpg', 0),

-- MacBook Air M3
(5, 3, 'https://cdn.tgdd.vn/Products/Images/44/322095/macbook-air-13-inch-m3-2024-1.jpg', 1),

-- Dell XPS 13
(6, 4, 'https://cdn.tgdd.vn/Products/Images/44/303891/dell-xps-13-plus-9320-i7-u.jpg', 1),

-- AirPods Pro
(7, 5, 'https://cdn.tgdd.vn/Products/Images/54/289780/airpods-pro-2-usb-c-1.jpg', 1),

-- Sony WH-1000XM5
(8, 6, 'https://cdn.tgdd.vn/Products/Images/54/247508/sony-wh-1000xm5-1.jpg', 1),

-- Áo thun nữ
(9, 7, 'https://m.yodycdn.com/products/ao-thun-nu-cotton-yody-9.jpg', 1),

-- Váy maxi
(10, 8, 'https://m.yodycdn.com/products/vay-maxi-nu-cotton-yody-1.jpg', 1),

-- Quần jeans
(11, 9, 'https://m.yodycdn.com/products/quan-jeans-nu-yody-1.jpg', 1),

-- Giày sneaker
(12, 10, 'https://m.yodycdn.com/products/giay-sneaker-nu-yody-1.jpg', 1),

-- Túi tote
(13, 11, 'https://m.yodycdn.com/products/tui-tote-vai-canvas-yody-1.jpg', 1),

-- Nồi cơm điện
(14, 12, 'https://cdn.tgdd.vn/Products/Images/1922/78499/noi-com-dien-panasonic-1.jpg', 1),

-- Máy xay sinh tố
(15, 13, 'https://cdn.tgdd.vn/Products/Images/1920/88886/may-xay-sinh-to-philips-1.jpg', 1),

-- Bếp từ
(16, 14, 'https://cdn.tgdd.vn/Products/Images/1982/245678/bep-tu-sunhouse-1.jpg', 1),

-- Máy lọc nước
(17, 15, 'https://cdn.tgdd.vn/Products/Images/4385/234567/may-loc-nuoc-kangaroo-1.jpg', 1),

-- Sách
(18, 16, 'https://salt.tikicdn.com/cache/w1200/ts/product/e6/04/e6/nha-gia-kim.jpg', 1),
(19, 17, 'https://salt.tikicdn.com/cache/w1200/ts/product/10/97/59/dac-nhan-tam.jpg', 1),
(20, 18, 'https://salt.tikicdn.com/cache/w1200/ts/product/c4/f9/b2/atomic-habits.jpg', 1),
(21, 19, 'https://salt.tikicdn.com/cache/w1200/ts/product/45/3b/fc/sapiens.jpg', 1),

-- Mỹ phẩm
(22, 20, 'https://cocoonvietnam.com/wp-content/uploads/kem-duong-am-1.jpg', 1),
(23, 21, 'https://klairscosmetics.com/wp-content/uploads/vitamin-c-serum.jpg', 1),
(24, 22, 'https://3ce.com/wp-content/uploads/son-kem-3ce.jpg', 1),
(25, 23, 'https://cdn.tgdd.vn/Products/Images/1553/234567/dau-goi-argan-1.jpg', 1);

SET IDENTITY_INSERT ProductImages OFF;


-- ===== 10. PRODUCT VARIANTS =====
SET IDENTITY_INSERT ProductVariants ON;

INSERT INTO ProductVariants (VariantID, ProductID, Size, Color, SKU, Price, StockQuantity) VALUES
-- iPhone 15 Pro Max
(1, 1, '256GB', N'Titan Xanh', 'IP15PM-256-BLUE', 29990000, 20),
(2, 1, '256GB', N'Titan Đen', 'IP15PM-256-BLACK', 29990000, 15),
(3, 1, '512GB', N'Titan Xanh', 'IP15PM-512-BLUE', 34990000, 10),
(4, 1, '512GB', N'Titan Tự nhiên', 'IP15PM-512-NATURAL', 34990000, 5),

-- Samsung S24 Ultra
(5, 2, '256GB', N'Xám Titan', 'S24U-256-GRAY', 27990000, 15),
(6, 2, '512GB', N'Đen', 'S24U-512-BLACK', 30990000, 10),
(7, 2, '512GB', N'Tím', 'S24U-512-PURPLE', 30990000, 10),

-- Áo thun nữ
(8, 7, 'S', N'Trắng', 'AOTHUN-S-WHITE', 129000, 40),
(9, 7, 'M', N'Trắng', 'AOTHUN-M-WHITE', 129000, 50),
(10, 7, 'L', N'Trắng', 'AOTHUN-L-WHITE', 129000, 30),
(11, 7, 'S', N'Đen', 'AOTHUN-S-BLACK', 129000, 35),
(12, 7, 'M', N'Đen', 'AOTHUN-M-BLACK', 129000, 45),

-- Váy maxi
(13, 8, 'S', N'Hoa cam', 'VAYMAXI-S-ORANGE', 359000, 20),
(14, 8, 'M', N'Hoa cam', 'VAYMAXI-M-ORANGE', 359000, 30),
(15, 8, 'L', N'Hoa cam', 'VAYMAXI-L-ORANGE', 359000, 30),

-- Quần jeans
(16, 9, '26', N'Xanh nhạt', 'JEANS-26-LIGHT', 449000, 30),
(17, 9, '27', N'Xanh nhạt', 'JEANS-27-LIGHT', 449000, 40),
(18, 9, '28', N'Xanh nhạt', 'JEANS-28-LIGHT', 449000, 30),
(19, 9, '29', N'Xanh đậm', 'JEANS-29-DARK', 449000, 20),

-- Giày sneaker
(20, 10, '36', N'Trắng', 'GIAY-36-WHITE', 289000, 30),
(21, 10, '37', N'Trắng', 'GIAY-37-WHITE', 289000, 40),
(22, 10, '38', N'Trắng', 'GIAY-38-WHITE', 289000, 40),
(23, 10, '39', N'Trắng', 'GIAY-39-WHITE', 289000, 40);

SET IDENTITY_INSERT ProductVariants OFF;


-- ===== 11. CARTS =====
SET IDENTITY_INSERT Carts ON;

INSERT INTO Carts (CartID, AccountID, CreatedAt) VALUES
(1, 7, '2024-04-01 08:30:00'),
(2, 8, '2024-04-05 09:30:00'),
(3, 9, '2024-04-10 11:00:00'),
(4, 10, '2024-04-15 12:00:00'),
(5, 11, '2024-04-20 13:30:00'),
(6, 12, '2024-04-25 14:45:00'),
(7, 13, '2024-05-01 16:00:00');

SET IDENTITY_INSERT Carts OFF;


-- ===== 12. CART ITEMS =====
SET IDENTITY_INSERT CartItems ON;

INSERT INTO CartItems (CartItemID, CartID, ProductID, VariantID, Quantity, AddedAt) VALUES
(1, 1, 5, NULL, 1, '2026-01-27 10:00:00'),
(2, 1, 7, 9, 2, '2026-01-27 10:05:00'),
(3, 2, 16, NULL, 3, '2026-01-26 14:00:00'),
(4, 2, 17, NULL, 2, '2026-01-26 14:10:00'),
(5, 3, 20, NULL, 1, '2026-01-25 16:00:00'),
(6, 4, 1, 1, 1, '2026-01-24 09:00:00'),
(7, 5, 10, 21, 1, '2026-01-23 11:00:00');

SET IDENTITY_INSERT CartItems OFF;


-- ===== 13. ORDER GROUPS =====
SET IDENTITY_INSERT OrderGroups ON;

INSERT INTO OrderGroups (OrderGroupID, AccountID, TotalAmount, CreatedAt) VALUES
-- Các đơn đã hoàn thành (Delivered) - chờ Settlement
(1, 7, 6119000, '2025-12-15 10:00:00'),
(2, 8, 168000, '2025-12-18 11:00:00'),
(3, 9, 4990000, '2025-12-20 14:00:00'),
(4, 10, 29990000, '2025-12-22 09:00:00'),
(5, 11, 289000, '2025-12-25 10:30:00'),
(6, 12, 224000, '2025-12-28 15:00:00'),
(7, 13, 908000, '2026-01-02 11:00:00'),
(8, 7, 1590000, '2026-01-05 12:00:00'),

-- Các đơn đang xử lý (Shipping, Processing)
(9, 8, 5990000, '2026-01-15 10:00:00'),
(10, 9, 258000, '2026-01-16 11:00:00'),
(11, 10, 7990000, '2026-01-17 14:00:00'),
(12, 11, 449000, '2026-01-18 15:00:00'),
(13, 12, 189000, '2026-01-19 16:00:00'),

-- Đơn của user "Bom hàng" (AccountID = 14) - nhiều đơn Cancelled
(14, 14, 29990000, '2026-01-10 10:00:00'),
(15, 14, 27990000, '2026-01-11 11:00:00'),
(16, 14, 5990000, '2026-01-12 12:00:00'),
(17, 14, 31990000, '2026-01-13 13:00:00'),
(18, 14, 7990000, '2026-01-14 14:00:00'),
(19, 14, 129000, '2026-01-15 15:00:00'),
(20, 14, 359000, '2026-01-16 16:00:00'),
(21, 14, 449000, '2026-01-17 17:00:00');

SET IDENTITY_INSERT OrderGroups OFF;


-- ===== 14. ORDERS =====
SET IDENTITY_INSERT Orders ON;

INSERT INTO Orders (OrderID, OrderGroupID, ShopID, AccountID, AddressID, TotalAmount, Status, CreatedAt, IsReviewed) VALUES
-- Delivered orders (chờ Settlement) - ShopID 1 (TechZone)
(1, 1, 1, 7, 7, 5990000, 'Delivered', '2025-12-15 10:00:00', 1),
(2, 1, 2, 7, 7, 129000, 'Delivered', '2025-12-15 10:00:00', 1),
(3, 2, 2, 8, 8, 168000, 'Delivered', '2025-12-18 11:00:00', 1),

-- Delivered orders - ShopID 3 (Gia Dụng)
(4, 3, 3, 9, 9, 4990000, 'Delivered', '2025-12-20 14:00:00', 0),

-- Delivered orders - ShopID 1 (TechZone) - Nhiều đơn để test Settlement
(5, 4, 1, 10, 10, 29990000, 'Delivered', '2025-12-22 09:00:00', 1),
(6, 5, 2, 11, 11, 289000, 'Delivered', '2025-12-25 10:30:00', 1),
(7, 6, 4, 12, 12, 224000, 'Delivered', '2025-12-28 15:00:00', 1),

-- Delivered orders - ShopID 5 (Mỹ Phẩm)
(8, 7, 5, 13, 13, 908000, 'Delivered', '2026-01-02 11:00:00', 0),

-- Delivered orders - ShopID 3 (Gia Dụng)
(9, 8, 3, 7, 7, 1590000, 'Delivered', '2026-01-05 12:00:00', 0),

-- Shipping orders (đang giao)
(10, 9, 1, 8, 8, 5990000, 'Shipping', '2026-01-15 10:00:00', 0),
(11, 10, 2, 9, 9, 258000, 'Shipping', '2026-01-16 11:00:00', 0),

-- Processing orders (đang chuẩn bị)
(12, 11, 1, 10, 10, 7990000, 'Processing', '2026-01-17 14:00:00', 0),
(13, 12, 2, 11, 11, 449000, 'Processing', '2026-01-18 15:00:00', 0),

-- Pending orders (chờ xác nhận)
(14, 13, 4, 12, 12, 189000, 'Pending', '2026-01-19 16:00:00', 0),

-- Cancelled orders (user "Bom hàng" - AccountID 14)
(15, 14, 1, 14, 14, 29990000, 'Cancelled', '2026-01-10 10:00:00', 0),
(16, 15, 1, 14, 14, 27990000, 'Cancelled', '2026-01-11 11:00:00', 0),
(17, 16, 1, 14, 14, 5990000, 'Cancelled', '2026-01-12 12:00:00', 0),
(18, 17, 1, 14, 14, 31990000, 'Cancelled', '2026-01-13 13:00:00', 0),
(19, 18, 1, 14, 14, 7990000, 'Cancelled', '2026-01-14 14:00:00', 0),
(20, 19, 2, 14, 14, 129000, 'Delivered', '2026-01-15 15:00:00', 0),
(21, 20, 2, 14, 14, 359000, 'Delivered', '2026-01-16 16:00:00', 0),
(22, 21, 2, 14, 14, 449000, 'Cancelled', '2026-01-17 17:00:00', 0);

SET IDENTITY_INSERT Orders OFF;


-- ===== 15. ORDER DETAILS =====
SET IDENTITY_INSERT OrderDetails ON;

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, VariantID, Quantity, UnitPrice) VALUES
-- Order 1 (Delivered - TechZone)
(1, 1, 5, NULL, 1, 5990000),

-- Order 2 (Delivered - MiuMiu)
(2, 2, 7, 9, 1, 129000),

-- Order 3 (Delivered - MiuMiu)
(3, 3, 7, 9, 1, 129000),
(4, 3, 10, 21, 1, 289000),

-- Order 4 (Delivered - Gia Dụng)
(5, 4, 15, NULL, 1, 4990000),

-- Order 5 (Delivered - TechZone)
(6, 5, 1, 1, 1, 29990000),

-- Order 6 (Delivered - MiuMiu)
(7, 6, 10, 21, 1, 289000),

-- Order 7 (Delivered - Hà Nội Book)
(8, 7, 16, NULL, 1, 89000),
(9, 7, 17, NULL, 1, 79000),
(10, 7, 18, NULL, 1, 135000),

-- Order 8 (Delivered - Nature Beauty)
(11, 8, 20, NULL, 2, 179000),
(12, 8, 21, NULL, 1, 449000),
(13, 8, 23, NULL, 1, 259000),

-- Order 9 (Delivered - Gia Dụng)
(14, 9, 12, NULL, 1, 1590000),

-- Order 10 (Shipping - TechZone)
(15, 10, 5, NULL, 1, 5990000),

-- Order 11 (Shipping - MiuMiu)
(16, 11, 7, 9, 2, 129000),

-- Order 12 (Processing - TechZone)
(17, 12, 6, NULL, 1, 7990000),

-- Order 13 (Processing - MiuMiu)
(18, 13, 9, 17, 1, 449000),

-- Order 14 (Pending - Hà Nội Book)
(19, 14, 19, NULL, 1, 189000),

-- Orders của user "Bom hàng" (14-22)
(20, 15, 1, 1, 1, 29990000),
(21, 16, 2, 5, 1, 27990000),
(22, 17, 5, NULL, 1, 5990000),
(23, 18, 3, NULL, 1, 31990000),
(24, 19, 6, NULL, 1, 7990000),
(25, 20, 7, 9, 1, 129000),
(26, 21, 8, 13, 1, 359000),
(27, 22, 9, 17, 1, 449000);

SET IDENTITY_INSERT OrderDetails OFF;


-- ===== 16. PAYMENTS =====
SET IDENTITY_INSERT Payments ON;

INSERT INTO Payments (PaymentID, OrderGroupID, Method, Amount, PaymentStatus, CreatedAt) VALUES
(1, 1, 'COD', 6119000, 'Completed', '2025-12-15 10:05:00'),
(2, 2, 'VNPay', 168000, 'Completed', '2025-12-18 11:05:00'),
(3, 3, 'COD', 4990000, 'Completed', '2025-12-20 14:05:00'),
(4, 4, 'VNPay', 29990000, 'Completed', '2025-12-22 09:05:00'),
(5, 5, 'COD', 289000, 'Completed', '2025-12-25 10:35:00'),
(6, 6, 'VNPay', 224000, 'Completed', '2025-12-28 15:05:00'),
(7, 7, 'COD', 908000, 'Completed', '2026-01-02 11:05:00'),
(8, 8, 'VNPay', 1590000, 'Completed', '2026-01-05 12:05:00'),
(9, 9, 'VNPay', 5990000, 'Pending', '2026-01-15 10:05:00'),
(10, 10, 'COD', 258000, 'Pending', '2026-01-16 11:05:00'),
(11, 11, 'VNPay', 7990000, 'Pending', '2026-01-17 14:05:00'),
(12, 12, 'COD', 449000, 'Pending', '2026-01-18 15:05:00'),
(13, 13, 'VNPay', 189000, 'Pending', '2026-01-19 16:05:00'),
(14, 14, 'VNPay', 29990000, 'Cancelled', '2026-01-10 10:05:00'),
(15, 15, 'VNPay', 27990000, 'Cancelled', '2026-01-11 11:05:00'),
(16, 16, 'VNPay', 5990000, 'Cancelled', '2026-01-12 12:05:00'),
(17, 17, 'VNPay', 31990000, 'Cancelled', '2026-01-13 13:05:00'),
(18, 18, 'VNPay', 7990000, 'Cancelled', '2026-01-14 14:05:00'),
(19, 19, 'COD', 129000, 'Completed', '2026-01-15 15:05:00'),
(20, 20, 'COD', 359000, 'Completed', '2026-01-16 16:05:00'),
(21, 21, 'VNPay', 449000, 'Cancelled', '2026-01-17 17:05:00');

SET IDENTITY_INSERT Payments OFF;


-- ===== 17. REVIEWS (Bao gồm case Buff đánh giá) =====
SET IDENTITY_INSERT Reviews ON;

INSERT INTO Reviews (ReviewID, ProductID, AccountID, ShopID, Rating, Comment, CreatedAt, Status, OrderDetailID) VALUES
-- Reviews bình thường
(1, 5, 7, 1, 5, N'AirPods Pro chất lượng tuyệt vời! Âm thanh trong, chống ồn cực tốt. Ship nhanh, đóng gói cẩn thận.', '2025-12-20 10:00:00', 'Approved', 1),
(2, 7, 7, 2, 5, N'Áo đẹp, chất cotton mềm mịn, đúng như mô tả. Sẽ ủng hộ shop lâu dài.', '2025-12-20 11:00:00', 'Approved', 2),
(3, 7, 8, 2, 4, N'Áo đẹp nhưng hơi nhỏ so với size. Nên order lên 1 size.', '2025-12-23 14:00:00', 'Approved', 3),
(4, 10, 8, 2, 5, N'Giày đi êm chân lắm, trắng tinh rất đẹp. Phù hợp với mọi outfit.', '2025-12-23 14:05:00', 'Approved', 4),
(5, 15, 9, 3, 5, N'Máy lọc nước chất lượng cao, nước trong vắt. Lắp đặt tận nhà rất chuyên nghiệp.', '2025-12-25 16:00:00', 'Approved', 5),
(6, 1, 10, 1, 5, N'iPhone 15 Pro Max quá đỉnh! Màn hình đẹp, camera sắc nét, pin trâu. Giá hợp lý.', '2025-12-27 11:00:00', 'Approved', 6),

-- Reviews BUFF ĐÁNH GIÁ - User AccountID=11 đánh giá Shop 2 (MiuMiu) 5 sao liên tục trong 10 phút
-- Đây là dấu hiệu bất thường: Cùng 1 user, cùng 1 shop, 5 sao, trong thời gian ngắn
(7, 7, 11, 2, 5, N'Shop uy tín, đóng gói đẹp!', '2026-01-10 10:00:00', 'Pending', NULL),
(8, 8, 11, 2, 5, N'Váy đẹp lắm ạ, chất lượng tốt!', '2026-01-10 10:03:00', 'Pending', NULL),
(9, 9, 11, 2, 5, N'Quần jeans đẹp, form chuẩn!', '2026-01-10 10:06:00', 'Pending', NULL),
(10, 10, 11, 2, 5, N'Giày xịn, giá rẻ!', '2026-01-10 10:08:00', 'Pending', NULL),

-- Reviews khác
(11, 16, 12, 4, 5, N'Nhà Giả Kim là cuốn sách hay nhất tôi từng đọc. Ý nghĩa sâu sắc về cuộc sống.', '2026-01-03 16:00:00', 'Approved', 8),
(12, 17, 12, 4, 5, N'Đắc Nhân Tâm kinh điển rồi không cần bàn. Must read cho mọi người.', '2026-01-03 16:05:00', 'Approved', 9),
(13, 20, 13, 5, 4, N'Kem dưỡng ẩm Cocoon mùi dừa thơm, thấm nhanh không dính. Mùa đông dùng hơi nhẹ.', '2026-01-07 12:00:00', 'Approved', 11),
(14, 21, 13, 5, 5, N'Serum Vitamin C Klairs dùng thấy da sáng lên sau 2 tuần. Không kích ứng da nhạy cảm.', '2026-01-07 12:10:00', 'Approved', 12);

SET IDENTITY_INSERT Reviews OFF;


-- ===== 18. WISHLISTS =====
SET IDENTITY_INSERT Wishlists ON;

INSERT INTO Wishlists (WishlistID, AccountID, ProductID, CreatedAt) VALUES
(1, 7, 3, '2026-01-20 10:00:00'),
(2, 7, 4, '2026-01-20 10:05:00'),
(3, 8, 1, '2026-01-21 11:00:00'),
(4, 8, 2, '2026-01-21 11:05:00'),
(5, 9, 12, '2026-01-22 14:00:00'),
(6, 10, 16, '2026-01-23 15:00:00'),
(7, 11, 20, '2026-01-24 16:00:00'),
(8, 12, 21, '2026-01-25 17:00:00'),
(9, 13, 22, '2026-01-26 18:00:00');

SET IDENTITY_INSERT Wishlists OFF;


-- ===== 19. VOUCHERS =====
SET IDENTITY_INSERT Vouchers ON;

INSERT INTO Vouchers (VoucherID, ShopID, Code, Description, DiscountPercent, MinOrderAmount, StartDate, EndDate) VALUES
-- Platform vouchers (ShopID = NULL)
(1, NULL, 'WELCOME2024', N'Mã giảm giá 10% cho khách hàng mới', 10.00, 0, '2024-01-01', '2024-12-31'),
(2, NULL, 'FREESHIP50K', N'Miễn phí ship đơn từ 50k', 0.00, 50000, '2024-01-01', '2024-12-31'),

-- Shop vouchers
(3, 1, 'TECHZONE15', N'Giảm 15% cho đơn từ 5 triệu tại TechZone', 15.00, 5000000, '2026-01-01', '2026-02-28'),
(4, 2, 'FASHION20', N'Giảm 20% toàn bộ thời trang nữ', 20.00, 200000, '2026-01-15', '2026-02-15'),
(5, 3, 'GIADUNG100K', N'Giảm 100k cho đơn từ 2 triệu', 0.00, 2000000, '2026-01-10', '2026-03-31'),
(6, 4, 'BOOK30', N'Giảm 30% cho đơn sách từ 300k', 30.00, 300000, '2026-01-01', '2026-12-31'),
(7, 5, 'BEAUTY25', N'Giảm 25% mỹ phẩm organic', 25.00, 500000, '2026-01-20', '2026-02-20');

SET IDENTITY_INSERT Vouchers OFF;


-- ===== 20. SHIPPING PARTNERS =====
SET IDENTITY_INSERT ShippingPartners ON;

INSERT INTO ShippingPartners (ShipperID, Name, LogoURL, IsActive) VALUES
(1, N'Giao Hàng Nhanh', 'https://cdn.ghn.vn/logo/ghn.png', 1),
(2, N'Giao Hàng Tiết Kiệm', 'https://cdn.ghtk.vn/logo/ghtk.png', 1),
(3, N'J&T Express', 'https://cdn.jtexpress.vn/logo/jt.png', 1),
(4, N'VNPost', 'https://cdn.vnpost.vn/logo/vnpost.png', 1),
(5, N'Shopee Express', 'https://cdn.shopee.vn/logo/spx.png', 1);

SET IDENTITY_INSERT ShippingPartners OFF;


-- ===== 21. ORDER SHIPPING INFO =====
SET IDENTITY_INSERT OrderShippingInfo ON;

INSERT INTO OrderShippingInfo (ShippingInfoID, OrderID, ShipperID, TrackingCode, ShippingFee, Status, EstimatedDeliveryDate) VALUES
-- Delivered orders
(1, 1, 1, 'GHN-20251215-001', 30000, 'Delivered', '2025-12-17'),
(2, 2, 2, 'GHTK-20251215-002', 25000, 'Delivered', '2025-12-17'),
(3, 3, 1, 'GHN-20251218-003', 25000, 'Delivered', '2025-12-20'),
(4, 4, 3, 'JT-20251220-004', 35000, 'Delivered', '2025-12-23'),
(5, 5, 1, 'GHN-20251222-005', 40000, 'Delivered', '2025-12-25'),
(6, 6, 2, 'GHTK-20251225-006', 25000, 'Delivered', '2025-12-27'),
(7, 7, 4, 'VNP-20251228-007', 20000, 'Delivered', '2025-12-30'),
(8, 8, 1, 'GHN-20260102-008', 30000, 'Delivered', '2026-01-05'),
(9, 9, 3, 'JT-20260105-009', 35000, 'Delivered', '2026-01-08'),

-- Shipping orders
(10, 10, 1, 'GHN-20260115-010', 30000, 'InTransit', '2026-01-17'),
(11, 11, 2, 'GHTK-20260116-011', 25000, 'InTransit', '2026-01-18'),

-- Processing orders
(12, 12, 1, 'GHN-20260117-012', 40000, 'WaitingForPickup', '2026-01-20'),
(13, 13, 2, 'GHTK-20260118-013', 25000, 'WaitingForPickup', '2026-01-21'),

-- Cancelled orders
(15, 15, 1, 'GHN-20260110-015', 40000, 'Cancelled', NULL),
(16, 16, 1, 'GHN-20260111-016', 40000, 'Cancelled', NULL),
(17, 17, 1, 'GHN-20260112-017', 30000, 'Cancelled', NULL),
(18, 18, 1, 'GHN-20260113-018', 40000, 'Cancelled', NULL),
(19, 19, 1, 'GHN-20260114-019', 40000, 'Cancelled', NULL);

SET IDENTITY_INSERT OrderShippingInfo OFF;


-- ===== 22. ORDER STATUS HISTORY =====
SET IDENTITY_INSERT OrderStatusHistory ON;

INSERT INTO OrderStatusHistory (HistoryID, OrderID, OldStatus, NewStatus, ChangedAt) VALUES
-- Order 1 history
(1, 1, NULL, 'Pending', '2025-12-15 10:00:00'),
(2, 1, 'Pending', 'Processing', '2025-12-15 11:00:00'),
(3, 1, 'Processing', 'Shipping', '2025-12-16 09:00:00'),
(4, 1, 'Shipping', 'Delivered', '2025-12-18 14:00:00'),

-- Order 2 history
(5, 2, NULL, 'Pending', '2025-12-15 10:00:00'),
(6, 2, 'Pending', 'Processing', '2025-12-15 12:00:00'),
(7, 2, 'Processing', 'Shipping', '2025-12-16 10:00:00'),
(8, 2, 'Shipping', 'Delivered', '2025-12-17 15:00:00'),

-- Order 10 history (Shipping)
(9, 10, NULL, 'Pending', '2026-01-15 10:00:00'),
(10, 10, 'Pending', 'Processing', '2026-01-15 11:00:00'),
(11, 10, 'Processing', 'Shipping', '2026-01-15 14:00:00'),

-- Cancelled orders history
(12, 15, NULL, 'Pending', '2026-01-10 10:00:00'),
(13, 15, 'Pending', 'Cancelled', '2026-01-10 15:00:00'),
(14, 16, NULL, 'Pending', '2026-01-11 11:00:00'),
(15, 16, 'Pending', 'Cancelled', '2026-01-11 16:00:00'),
(16, 17, NULL, 'Pending', '2026-01-12 12:00:00'),
(17, 17, 'Pending', 'Cancelled', '2026-01-12 17:00:00');

SET IDENTITY_INSERT OrderStatusHistory OFF;


-- ===== 23. NOTIFICATIONS =====
SET IDENTITY_INSERT Notifications ON;

INSERT INTO Notifications (NotificationID, AccountID, Title, Message, LinkURL, IsRead, CreatedAt) VALUES
(1, 7, N'Đơn hàng đã giao', N'Đơn hàng #1 đã được giao thành công. Cảm ơn bạn đã mua hàng!', '/orders/1', 1, '2025-12-18 14:05:00'),
(2, 7, N'Đánh giá sản phẩm', N'Hãy đánh giá sản phẩm AirPods Pro để nhận 50 xu!', '/reviews/new/1', 1, '2025-12-19 10:00:00'),
(3, 8, N'Đơn hàng đã giao', N'Đơn hàng #3 đã được giao thành công.', '/orders/3', 1, '2025-12-20 15:05:00'),
(4, 9, N'Đơn hàng đã giao', N'Đơn hàng #4 đã được giao thành công.', '/orders/4', 0, '2025-12-23 16:05:00'),
(5, 10, N'Đơn hàng đã giao', N'Đơn hàng #5 đã được giao thành công.', '/orders/5', 1, '2025-12-25 14:05:00'),
(6, 8, N'Đơn hàng đang giao', N'Đơn hàng #10 đang trên đường giao đến bạn.', '/orders/10', 0, '2026-01-15 14:05:00'),
(7, 14, N'Đơn hàng bị hủy', N'Đơn hàng #15 đã bị hủy do không xác nhận.', '/orders/15', 0, '2026-01-10 15:05:00'),
(8, 1, N'Shop mới đăng ký', N'Có đơn đăng ký shop mới "Shop Phụ Kiện XiTrum" cần duyệt.', '/admin/shop-requests', 0, '2025-01-20 10:05:00');

SET IDENTITY_INSERT Notifications OFF;


-- ===== 24. FLASH SALES =====
SET IDENTITY_INSERT FlashSales ON;

INSERT INTO FlashSales (FlashSaleID, Title, StartTime, EndTime, IsActive) VALUES
(1, N'Flash Sale Tết 2026', '2026-01-25 00:00:00', '2026-02-10 23:59:59', 1),
(2, N'Ngày Công Nghệ', '2026-02-15 00:00:00', '2026-02-17 23:59:59', 0),
(3, N'Giảm Giá Cuối Tuần', '2026-01-31 00:00:00', '2026-02-02 23:59:59', 1);

SET IDENTITY_INSERT FlashSales OFF;


-- ===== 25. FLASH SALE PRODUCTS =====
SET IDENTITY_INSERT FlashSaleProducts ON;

INSERT INTO FlashSaleProducts (FlashSaleProductID, FlashSaleID, ProductID, VariantID, FlashSalePrice, TotalStock, SoldCount) VALUES
-- Flash Sale Tết
(1, 1, 5, NULL, 4990000, 50, 23),
(2, 1, 7, 9, 99000, 100, 67),
(3, 1, 16, NULL, 69000, 200, 145),
(4, 1, 20, NULL, 149000, 100, 56),

-- Ngày Công Nghệ
(5, 2, 1, 1, 27990000, 20, 0),
(6, 2, 3, NULL, 29990000, 15, 0),

-- Giảm Giá Cuối Tuần
(7, 3, 12, NULL, 1390000, 30, 12),
(8, 3, 14, NULL, 3290000, 20, 8);

SET IDENTITY_INSERT FlashSaleProducts OFF;


-- ===== 26. CHAT ROOMS =====
SET IDENTITY_INSERT ChatRooms ON;

INSERT INTO ChatRooms (RoomID, BuyerID, ShopID, CreatedAt, IsClosed) VALUES
(1, 7, 1, '2025-12-14 09:00:00', 0),
(2, 8, 2, '2025-12-17 10:00:00', 0),
(3, 9, 3, '2025-12-19 11:00:00', 0),
(4, 10, 1, '2025-12-21 14:00:00', 0),
(5, 11, 2, '2025-12-24 15:00:00', 0),
(6, 12, 4, '2025-12-27 16:00:00', 1),
(7, 13, 5, '2026-01-01 17:00:00', 0);

SET IDENTITY_INSERT ChatRooms OFF;


-- ===== 27. CHAT MESSAGES =====
SET IDENTITY_INSERT ChatMessages ON;

INSERT INTO ChatMessages (MessageID, RoomID, SenderID, MessageType, MessageText, CreatedAt) VALUES
-- Room 1 (Buyer 7 - Shop 1)
(1, 1, 7, 'Text', N'Cho mình hỏi AirPods Pro còn hàng không ạ?', '2025-12-14 09:00:00'),
(2, 1, 2, 'Text', N'Dạ vẫn còn hàng bạn nhé. Bạn muốn đặt màu nào?', '2025-12-14 09:02:00'),
(3, 1, 7, 'Text', N'Mình đặt 1 cái màu trắng nhé shop', '2025-12-14 09:05:00'),
(4, 1, 2, 'Text', N'Ok bạn, mình xác nhận đơn ngay nhé!', '2025-12-14 09:06:00'),

-- Room 2 (Buyer 8 - Shop 2)
(5, 2, 8, 'Text', N'Shop ơi, áo thun có size XL không?', '2025-12-17 10:00:00'),
(6, 2, 3, 'Text', N'Dạ hiện tại shop chỉ có đến size L thôi bạn ạ.', '2025-12-17 10:03:00'),
(7, 2, 8, 'Text', N'Vậy mình lấy size L nhé. Mình cao 1m7 cân nặng 65kg có vừa không shop?', '2025-12-17 10:05:00'),
(8, 2, 3, 'Text', N'Size L vừa vặn với số đo của bạn ạ. Form rộng nên mặc thoải mái lắm!', '2025-12-17 10:07:00');

SET IDENTITY_INSERT ChatMessages OFF;

-- Bật lại trigger để hệ thống hoạt động bình thường sau khi nạp dữ liệu
EXEC sp_msforeachtable 'ALTER TABLE ? ENABLE TRIGGER all';

PRINT N'===== HOÀN TẤT TẠO DỮ LIỆU MẪU =====';