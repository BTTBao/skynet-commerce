/* =====================================================
   Dữ liệu mẫu cho ACCOUNTS – USERS – ADDRESS
===================================================== */
SET DATEFORMAT dmy;
-- 1. Accounts (10 bản ghi)
INSERT INTO Accounts (PasswordHash, Email, Phone, IsActive) VALUES
('hash123', 'admin@skynet.com', '0901111111', 1), ('hash124', 'seller1@shop.com', '0902222222', 1),
('hash125', 'seller2@shop.com', '0903333333', 1), ('hash126', 'buyer1@user.com', '0904444444', 1),
('hash127', 'buyer2@user.com', '0905555555', 1), ('hash128', 'buyer3@user.com', '0906666666', 1),
('hash129', 'buyer4@user.com', '0907777777', 1), ('hash130', 'inactive@user.com', '0908888888', 0),
('hash131', 'buyer5@user.com', '0909999999', 1), ('hash132', 'seller3@shop.com', '0910101010', 1);

-- 2. Users (10 bản ghi)
INSERT INTO Users (AccountID, FullName, Gender, DateOfBirth) VALUES
(1, N'Nguyễn Văn Admin', 'Male', '15-05-1990'), (2, N'Lê Thị Bán Hàng 1', 'Female', '20-08-1995'),
(3, N'Phạm Văn Bán Hàng 2', 'Male', '10-12-1988'), (4, N'Trần Thị Mua Hàng 1', 'Female', '01-01-2000'),
(5, N'Hoàng Văn Mua Hàng 2', 'Male', '12-04-1997'), (6, N'Đỗ Thị Mua Hàng 3', 'Female', '25-11-1999'),
(7, N'Vũ Văn Mua Hàng 4', 'Male', '03-07-2001'), (8, N'Mai Thị Tạm Ngưng', 'Female', '18-02-1996'),
(9, N'Bùi Văn Mua Hàng 5', 'Male', '09-06-1993'), (10, N'Cao Thị Bán Hàng 3', 'Female', '22-10-1991');

-- 3. UserRoles
INSERT INTO UserRoles (AccountID, RoleName) VALUES
(1, 'Admin'), (2, 'Seller'), (3, 'Seller'), (10, 'Seller');

-- 4. UserAddresses (10 bản ghi)
INSERT INTO UserAddresses (AccountID, ReceiverFullName, ReceiverPhone, AddressLine, Ward, District, Province, IsDefault) VALUES
(4, N'Trần Thị Mua Hàng 1', '0904444444', N'1A Đường Dịch Vọng', N'Phường Dịch Vọng', N'Quận Cầu Giấy', N'Hà Nội', 1),
(5, N'Hoàng Văn Mua Hàng 2', '0905555555', N'2B Đường Lê Lợi', N'Phường Bến Nghé', N'Quận 1', N'TP. Hồ Chí Minh', 1),
(6, N'Đỗ Thị Mua Hàng 3', '0906666666', N'3C Đường Hai Bà Trưng', N'Phường 6', N'Quận 3', N'TP. Hồ Chí Minh', 1),
(7, N'Vũ Văn Mua Hàng 4', '0907777777', N'4D Đường Nguyễn Văn Cừ', N'Phường An Khánh', N'Quận Ninh Kiều', N'Cần Thơ', 1),
(4, N'Trần Thị Mua Hàng 1', '0904444444', N'5E Đường Láng', N'Phường Láng Thượng', N'Quận Đống Đa', N'Hà Nội', 0),
(9, N'Bùi Văn Mua Hàng 5', '0909999999', N'6F Đường Trần Phú', N'Phường 7', N'Quận 5', N'TP. Hồ Chí Minh', 1),
(2, N'Lê Thị Bán Hàng 1', '0902222222', N'7G Đường Hoàng Diệu', N'Phường 12', N'Quận 4', N'TP. Hồ Chí Minh', 1),
(3, N'Phạm Văn Bán Hàng 2', '0903333333', N'8H Đường Phạm Hùng', N'Phường Mỹ Đình 1', N'Quận Nam Từ Liêm', N'Hà Nội', 1),
(10, N'Cao Thị Bán Hàng 3', '0910101010', N'9I Đường Trường Chinh', N'Phường 13', N'Quận Tân Bình', N'TP. Hồ Chí Minh', 1),
(5, N'Hoàng Văn Mua Hàng 2', '0905555555', N'10K Đường Cách Mạng Tháng Tám', N'Phường 11', N'Quận 10', N'TP. Hồ Chí Minh', 0);


/* =====================================================
   Dữ liệu mẫu cho SHOPS – CATEGORIES – PRODUCTS
===================================================== */
-- 1. Shops (10 bản ghi)
INSERT INTO Shops (AccountID, ShopName, Description, RatingAverage) VALUES
(2, N'Shop Thời Trang A', N'Chuyên cung cấp quần áo thời trang nam nữ.', 4.50), (3, N'Siêu Thị Điện Tử B', N'Các sản phẩm điện tử, gia dụng chính hãng.', 4.75),
(10, N'Nhà Sách C', N'Sách, văn phòng phẩm, đồ lưu niệm.', 4.20), (1, N'Skynet Official Store', N'Shop của Admin', 5.00),
(4, N'Shop Giày Dép D', N'Giày dép các loại.', 4.10), (5, N'Shop Mỹ Phẩm E', N'Sản phẩm chăm sóc da và trang điểm.', 4.80),
(6, N'Shop Đồ Gia Dụng F', N'Dụng cụ nhà bếp và gia đình.', 3.90), (7, N'Shop Đồ Chơi G', N'Đồ chơi trẻ em an toàn.', 4.60),
(8, N'Shop Thể Thao H', N'Quần áo và dụng cụ thể thao.', 4.30), (9, N'Shop Phụ Kiện I', N'Phụ kiện điện thoại và máy tính.', 4.40);


-- 2. Categories (10 bản ghi)
INSERT INTO Categories (CategoryName, ParentCategoryID) VALUES
(N'Thời Trang', NULL), (N'Điện Tử', NULL), (N'Sách & Văn Phòng Phẩm', NULL), (N'Thời Trang Nam', 1), (N'Thời Trang Nữ', 1),
(N'Điện Thoại & Phụ Kiện', 2), (N'Máy Tính & Laptop', 2), (N'Sách Văn Học', 3), (N'Sách Kinh Tế', 3), (N'Đồ Gia Dụng', NULL);


-- 3. Products (10 bản ghi)
INSERT INTO Products (ShopID, CategoryID, Name, Description, Price, StockQuantity, SoldCount, Status) VALUES
(1, 4, N'Áo thun Polo Nam', N'Áo thun cotton co giãn 4 chiều.', 150000.00, 100, 50, 'Active'), (2, 6, N'Điện thoại Smart X', N'Điện thoại thông minh đời mới.', 8000000.00, 50, 20, 'Active'),
(3, 8, N'Tiểu thuyết Trăm Năm', N'Sách văn học kinh điển.', 95000.00, 200, 150, 'Active'), (1, 5, N'Váy maxi Nữ', N'Váy maxi đi biển chất liệu voan.', 300000.00, 80, 40, 'Active'),
(2, 7, N'Laptop Gaming Y', N'Laptop chuyên dụng cho game thủ.', 25000000.00, 20, 5, 'Active'), (3, 9, N'Sách Khởi Nghiệp', N'Cẩm nang dành cho người khởi nghiệp.', 120000.00, 150, 80, 'Active'),
(1, 4, N'Quần Jeans Nam', N'Quần Jeans slim fit cao cấp.', 450000.00, 60, 30, 'Active'), (2, 6, N'Tai nghe Bluetooth Z', N'Tai nghe không dây chống ồn.', 1500000.00, 120, 60, 'Active'),
(10, 3, N'Bút Bi Thiên Long', N'Hộp 20 cây bút bi.', 25000.00, 500, 100, 'Active'), (10, 3, N'Vở Kẻ Ngang', N'Combo 10 cuốn vở học sinh.', 80000.00, 300, 150, 'Active');


-- 4. ProductVariants (10 bản ghi - ĐÃ SỬA LỖI UNIQUE KEY SKU)
INSERT INTO ProductVariants (ProductID, Size, Color, SKU, Price, StockQuantity) VALUES
(1, 'M', 'Đen', 'P1-M-D', 150000.00, 50), (1, 'L', 'Đen', 'P1-L-D', 150000.00, 50),
(2, '128GB', 'Xanh', 'P2-128G-X', 8000000.00, 25), (2, '256GB', 'Đen', 'P2-256G-D', 8500000.00, 25),
(4, 'S', 'Trắng', 'P4-S-T', 300000.00, 40), (4, 'M', 'Trắng', 'P4-M-T', 300000.00, 40),
(7, '29', 'Xanh đậm', 'P7-29-XD', 450000.00, 30), (7, '30', 'Xanh đậm', 'P7-30-XD', 450000.00, 30),
(8, NULL, 'Trắng', 'P8-TS-T', 1500000.00, 60), (8, NULL, 'Đen', 'P8-TS-D', 1550000.00, 60);

-- 5. ProductImages (10 bản ghi)
INSERT INTO ProductImages (ProductID, ImageURL, IsPrimary) VALUES
(1, 'url_ao_polo_1', 1), (1, 'url_ao_polo_2', 0), (2, 'url_smart_x_1', 1), (2, 'url_smart_x_2', 0),
(3, 'url_tieu_thuyet_1', 1), (4, 'url_vay_maxi_1', 1), (5, 'url_laptop_y_1', 1), (7, 'url_jeans_nam_1', 1),
(8, 'url_tai_nghe_z_1', 1), (10, 'url_vo_ke_ngang_1', 1);

/* =====================================================
   Dữ liệu mẫu cho CART & WISHLIST
===================================================== */
-- 1. Carts (3 bản ghi cho 3 người dùng mua hàng)
INSERT INTO Carts (AccountID) VALUES (4), (5), (6);

-- 2. CartItems (10 bản ghi)
INSERT INTO CartItems (CartID, ProductID, VariantID, Quantity) VALUES
(1, 1, 1, 2), (1, 3, NULL, 1), (2, 2, 3, 1), (3, 4, 5, 3), (1, 7, 7, 1),
(2, 8, 9, 2), (3, 9, NULL, 5), (1, 5, NULL, 1), (2, 10, NULL, 10), (3, 6, NULL, 1);

-- 3. Wishlists (10 bản ghi)
INSERT INTO Wishlists (AccountID, ProductID) VALUES
(4, 2), (4, 5), (5, 1), (5, 7), (6, 8), (7, 3), (7, 6), (9, 4), (9, 9), (4, 10);

/* =====================================================
   Dữ liệu mẫu cho ORDER & PAYMENT
===================================================== */
-- 1. OrderGroups (4 bản ghi)
INSERT INTO OrderGroups (AccountID, TotalAmount) VALUES
(4, 845000.00), (5, 9620000.00), (6, 30300000.00), (4, 1950000.00);


-- 2. Orders (10 bản ghi)
INSERT INTO Orders (OrderGroupID, ShopID, AccountID, AddressID, TotalAmount, Status) VALUES
(1, 1, 4, 1, 300000.00, 'Delivered'), (1, 3, 4, 1, 95000.00, 'Delivered'), (1, 10, 4, 5, 450000.00, 'Shipping'),
(2, 2, 5, 2, 8000000.00, 'Processing'), (2, 2, 5, 2, 1620000.00, 'Processing'),
(3, 1, 6, 3, 900000.00, 'Pending'), (3, 2, 6, 3, 29400000.00, 'Pending'),
(4, 1, 4, 5, 450000.00, 'Delivered'), (4, 2, 4, 1, 1500000.00, 'Delivered'),
(1, 10, 4, 1, 200000.00, 'Delivered');


-- 3. OrderDetails (10 bản ghi)
INSERT INTO OrderDetails (OrderID, ProductID, VariantID, Quantity, UnitPrice) VALUES
(1, 1, 1, 2, 150000.00), (2, 3, NULL, 1, 95000.00), (4, 2, 3, 1, 8000000.00),
(6, 4, 5, 3, 300000.00), (8, 7, 7, 1, 450000.00), (9, 8, 9, 1, 1500000.00),
(10, 9, NULL, 3, 25000.00), (10, 10, NULL, 1, 80000.00),
(5, 6, NULL, 1, 120000.00), (7, 5, NULL, 1, 25000000.00);


-- 4. Payments (4 bản ghi)
INSERT INTO Payments (OrderGroupID, Method, Amount, PaymentStatus) VALUES
(1, 'COD', 845000.00, 'Paid'), (2, 'Credit Card', 9620000.00, 'Pending'),
(3, 'COD', 30300000.00, 'Pending'), (4, 'COD', 1950000.00, 'Paid');

-- 5. OrderStatusHistory (10 bản ghi)
INSERT INTO OrderStatusHistory (OrderID, OldStatus, NewStatus) VALUES
(1, 'Pending', 'Processing'), (1, 'Processing', 'Shipping'), (1, 'Shipping', 'Delivered'),
(2, 'Pending', 'Processing'), (2, 'Processing', 'Shipping'), (2, 'Shipping', 'Delivered'),
(4, 'Pending', 'Processing'), (6, 'Pending', 'Pending'), (8, 'Pending', 'Delivered'), (9, 'Pending', 'Delivered');


/* =====================================================
   Dữ liệu mẫu cho REVIEWS & VOUCHERS
===================================================== */
-- 1. Reviews (10 bản ghi)
INSERT INTO Reviews (ProductID, AccountID, ShopID, Rating, Comment, OrderDetailID) VALUES
(1, 4, 1, 5, N'Áo đẹp, giao hàng nhanh.', 1), (3, 4, 3, 4, N'Sách nguyên seal, nội dung hay.', 2),
(7, 4, 1, 5, N'Quần jeans mặc rất vừa vặn.', 5), (8, 4, 2, 5, N'Tai nghe chất lượng âm thanh tốt.', 6),
(9, 4, 10, 4, N'Bút viết trơn, đóng gói cẩn thận.', 7), (1, 5, 1, 5, N'Hàng đúng mô tả.', 1),
(3, 6, 3, 3, N'Giao hàng hơi chậm.', 2), (4, 7, 1, 5, N'Váy xinh, giá hợp lý.', 4),
(5, 9, 2, 4, N'Laptop mạnh, hơi nóng khi chơi game.', 10), (6, 4, 3, 5, N'Sách này rất bổ ích.', 9);


-- 2. Vouchers (10 bản ghi)
INSERT INTO Vouchers (ShopID, Code, Description, DiscountPercent, MinOrderAmount, StartDate, EndDate) VALUES
(NULL, 'FREE20K', N'Giảm 20k cho đơn từ 200k', NULL, 200000.00, '01-11-2025', '30-11-2025'), (1, 'SHOP10', N'Giảm 10% tối đa 50k', 10.00, 100000.00, '15-11-2025', '30-11-2025'),
(2, 'DIENTU50', N'Giảm 50k cho đơn từ 1tr', NULL, 1000000.00, '01-11-2025', '31-12-2025'), (3, 'SACH15', N'Giảm 15% cho sách', 15.00, 50000.00, '20-11-2025', '25-11-2025'),
(NULL, 'Freeship', N'Miễn phí vận chuyển toàn quốc', NULL, 0.00, '01-01-2025', '31-12-2025'), (1, 'BIG20', N'Giảm 20% tối đa 100k', 20.00, 300000.00, '20-11-2025', '22-11-2025'),
(2, 'VIPCODE', N'Giảm 200k cho đơn hàng trên 5tr', NULL, 5000000.00, '01-10-2025', '31-12-2025'), (10, 'VANPHONG5', N'Giảm 5% cho văn phòng phẩm', 5.00, 100000.00, '01-11-2025', '30-11-2025'),
(NULL, 'DEAL50', N'Giảm 50% tối đa 50k', 50.00, 0.00, '20-11-2025', '20-11-2025'), (1, 'NEWYEAR', N'Giảm 15% chào năm mới', 15.00, 200000.00, '01-01-2026', '31-01-2026');


/* =====================================================
   Dữ liệu mẫu cho SHIPPING & FLASH SALES
===================================================== */
-- 1. ShippingPartners (10 bản ghi)
INSERT INTO ShippingPartners (Name, IsActive) VALUES
(N'Giao Hàng Nhanh', 1), (N'Viettel Post', 1), (N'Giao Hàng Tiết Kiệm', 1), (N'Vietnam Post', 1), (N'J&T Express', 1),
(N'Best Express', 1), (N'Ninja Van', 1), (N'GrabExpress', 1), (N'AhaMove', 1), (N'FedEx', 0);

-- 2. OrderShippingInfo (7 bản ghi)
INSERT INTO OrderShippingInfo (OrderID, ShipperID, TrackingCode, ShippingFee, Status, EstimatedDeliveryDate) VALUES
(1, 1, 'GHN12345', 30000.00, 'Delivered', '25-11-2025'), (2, 2, 'VT23456', 25000.00, 'Delivered', '26-11-2025'),
(4, 3, 'GHT34567', 40000.00, 'Processing', '28-11-2025'), (8, 1, 'GHN45678', 35000.00, 'Delivered', '27-11-2025'),
(9, 2, 'VT56789', 20000.00, 'Delivered', '28-11-2025'), (10, 3, 'GHT67890', 25000.00, 'Delivered', '29-11-2025'),
(5, 4, 'VNPOST123', 30000.00, 'Processing', '30-11-2025');


-- 3. FlashSales (3 bản ghi)
INSERT INTO FlashSales (Title, StartTime, EndTime, IsActive) VALUES
(N'Flash Sale Cuối Tháng', '20-11-2025 12:00:00', '20-11-2025 15:00:00', 1),
(N'Giảm Sốc Ngày Đôi', '11-11-2025 00:00:00', '11-11-2025 23:59:59', 0),
(N'Siêu Sale Black Friday', '29-11-2025 00:00:00', '29-11-2025 23:59:59', 1);

-- 4. FlashSaleProducts (10 bản ghi)
INSERT INTO FlashSaleProducts (FlashSaleID, ProductID, VariantID, FlashSalePrice, TotalStock, SoldCount) VALUES
(1, 1, 1, 120000.00, 20, 5), (1, 4, 5, 250000.00, 10, 2), (1, 9, NULL, 20000.00, 50, 10),
(2, 2, 3, 7500000.00, 5, 5), (2, 5, NULL, 20000000.00, 2, 2),
(3, 7, 7, 350000.00, 30, 0), (3, 8, 9, 1200000.00, 15, 0),
(3, 1, 2, 120000.00, 20, 0), (1, 3, NULL, 75000.00, 40, 5), (2, 6, NULL, 90000.00, 10, 8);


/* =====================================================
   Dữ liệu mẫu cho CHAT & NOTIFICATION
===================================================== */
-- 1. ChatRooms (3 bản ghi)
INSERT INTO ChatRooms (BuyerID, ShopID) VALUES (4, 1), (5, 2), (6, 3);

-- 2. ChatMessages (10 bản ghi)
INSERT INTO ChatMessages (RoomID, SenderID, MessageText) VALUES
(1, 4, N'Áo này còn màu xanh không?'), (1, 2, N'Chào bạn, hiện chỉ còn màu đen và trắng.'),
(2, 5, N'Điện thoại có trả góp 0% không?'), (2, 3, N'Chào bạn, có hỗ trợ trả góp qua thẻ tín dụng.'),
(3, 6, N'Sách có được bọc plastic không?'), (3, 10, N'Chào bạn, có ạ. Chúng tôi sẽ bọc cẩn thận.'),
(1, 4, N'Ok, mình lấy màu đen nhé.'), (2, 5, N'Cảm ơn shop.'), (3, 6, N'Tuyệt vời!'), (1, 2, N'Cảm ơn bạn đã ủng hộ!');

-- 3. Notifications (10 bản ghi)
INSERT INTO Notifications (AccountID, Title, Message, LinkURL, IsRead) VALUES
(4, N'Đơn hàng đã giao', N'Đơn hàng #12345 đã được giao thành công.', '/orders/1', 1), (5, N'Đơn hàng đang xử lý', N'Đơn hàng #56789 của bạn đang được Shop chuẩn bị.', '/orders/4', 0),
(4, N'Shop đã trả lời tin nhắn', N'Shop Thời Trang A đã trả lời tin nhắn của bạn.', '/chat/1', 0), (6, N'Sản phẩm mới', N'Shop yêu thích của bạn vừa ra mắt sản phẩm mới!', '/products/11', 0),
(4, N'Flash Sale sắp diễn ra', N'Siêu Sale Black Friday sẽ bắt đầu vào 29/11!', '/flashsale/3', 1), (2, N'Có đơn hàng mới', N'Bạn có 1 đơn hàng mới đang chờ xử lý.', '/seller/orders/6', 0),
(3, N'Đánh giá mới', N'Bạn vừa nhận được một đánh giá 5 sao!', '/seller/reviews', 0), (4, N'Thông báo từ Admin', N'Hệ thống đã cập nhật chính sách bảo mật mới.', '/policies', 1),
(7, N'Mã giảm giá', N'Tặng bạn mã giảm giá 20k cho đơn hàng tiếp theo.', '/vouchers', 0), (8, N'Tài khoản bị khóa', N'Tài khoản của bạn đã bị tạm khóa do vi phạm chính sách.', '/help', 1);