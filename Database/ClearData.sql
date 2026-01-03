-- Đảm bảo đang sử dụng đúng Database
USE Skynet_commerce;
GO

-- 1. XÓA DỮ LIỆU TỪ BẢNG CON ĐẾN BẢNG CHA
DELETE FROM Notifications;
DELETE FROM ChatAttachments;
DELETE FROM ChatMessages;
DELETE FROM ChatRooms;
DELETE FROM FlashSaleProducts;
DELETE FROM OrderShippingInfo;
DELETE FROM OrderStatusHistory;
DELETE FROM Payments;
DELETE FROM Reviews;
DELETE FROM Wishlists;
DELETE FROM Vouchers;
DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM OrderGroups;
DELETE FROM CartItems;
DELETE FROM Carts;
DELETE FROM ProductImages;
DELETE FROM ProductVariants;
DELETE FROM Products;
DELETE FROM Categories;
DELETE FROM UserAddresses;
DELETE FROM UserRoles;
DELETE FROM ShopRegistrations;
DELETE FROM Shops;
DELETE FROM Users;
DELETE FROM Accounts;
TRUNCATE TABLE ShippingPartners;
GO

-- 2. THIẾT LẬP LẠI IDENTITY VỀ 0 (ID tiếp theo sẽ là 1)
DBCC CHECKIDENT ('Accounts', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);
DBCC CHECKIDENT ('UserAddresses', RESEED, 0);
DBCC CHECKIDENT ('UserRoles', RESEED, 0);
DBCC CHECKIDENT ('ShopRegistrations', RESEED, 0);
DBCC CHECKIDENT ('Shops', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('ProductImages', RESEED, 0);
DBCC CHECKIDENT ('ProductVariants', RESEED, 0);
DBCC CHECKIDENT ('Carts', RESEED, 0);
DBCC CHECKIDENT ('CartItems', RESEED, 0);
DBCC CHECKIDENT ('OrderGroups', RESEED, 0);
DBCC CHECKIDENT ('Orders', RESEED, 0);
DBCC CHECKIDENT ('OrderDetails', RESEED, 0);
DBCC CHECKIDENT ('OrderStatusHistory', RESEED, 0);
DBCC CHECKIDENT ('Payments', RESEED, 0);
DBCC CHECKIDENT ('Reviews', RESEED, 0);
DBCC CHECKIDENT ('Wishlists', RESEED, 0);
DBCC CHECKIDENT ('Vouchers', RESEED, 0);
DBCC CHECKIDENT ('FlashSales', RESEED, 0); -- RẤT QUAN TRỌNG
DBCC CHECKIDENT ('FlashSaleProducts', RESEED, 0);
DBCC CHECKIDENT ('Notifications', RESEED, 0);
DBCC CHECKIDENT ('ChatRooms', RESEED, 0);
DBCC CHECKIDENT ('ChatMessages', RESEED, 0);
DBCC CHECKIDENT ('ChatAttachments', RESEED, 0);
GO