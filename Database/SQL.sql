/* =====================================================
   DROP & CREATE
===================================================== */
DROP DATABASE IF EXISTS Skynet_commerce;
GO
CREATE DATABASE Skynet_commerce;
GO
USE Skynet_commerce;
GO


/* =====================================================
   1. ACCOUNTS – USERS – ADDRESS
===================================================== */
CREATE TABLE Accounts (
    AccountID INT IDENTITY PRIMARY KEY,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(150) UNIQUE,
    Phone NVARCHAR(10) UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,

    CHECK (Email LIKE '%@%.%' OR Email IS NULL),
    CHECK (Phone NOT LIKE '%[^0-9]%' OR Phone IS NULL)
);

CREATE TABLE Users (
    UserID INT IDENTITY PRIMARY KEY,
    AccountID INT UNIQUE,
    FullName NVARCHAR(150),
    Gender NVARCHAR(10) CHECK (Gender IN ('Male','Female','Other')),
    AvatarURL NVARCHAR(500),
    AvatarPublicId NVARCHAR(255),
    DateOfBirth DATE,

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);

CREATE TABLE UserAddresses (
    AddressID INT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    AddressName NVARCHAR(100) DEFAULT N'Địa chỉ',
    ReceiverFullName NVARCHAR(150) NOT NULL,
    ReceiverPhone NVARCHAR(10) NOT NULL,
    AddressLine NVARCHAR(255) NOT NULL,
    Ward NVARCHAR(100) NOT NULL,
    District NVARCHAR(100) NOT NULL,
    Province NVARCHAR(100) NOT NULL,
    IsDefault BIT DEFAULT 0,

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);


/* =====================================================
   2. USER ROLES (NEW)
===================================================== */
CREATE TABLE UserRoles (
    UserRoleID INT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    RoleName NVARCHAR(50) NOT NULL 
        CHECK (RoleName IN ('Buyer','Seller','Admin')),
    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT UQ_UserRole UNIQUE (AccountID, RoleName),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);

-- Trigger auto gán Buyer cho account mới
/*
CREATE TRIGGER trg_AutoAssignBuyerRole
ON Accounts
AFTER INSERT
AS
BEGIN
    INSERT INTO UserRoles (AccountID, RoleName)
    SELECT AccountID, 'Buyer' 
    FROM inserted;
END;
*/


/* =====================================================
   3. SHOP REGISTRATION (NEW)
===================================================== */
CREATE TABLE ShopRegistrations (
    RegistrationID INT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    ShopName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Status NVARCHAR(20) DEFAULT 'Pending'
        CHECK (Status IN ('Pending','Approved','Rejected')),
    CreatedAt DATETIME DEFAULT GETDATE(),
    ReviewedAt DATETIME NULL,

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);

ALTER TABLE ShopRegistrations
ADD CitizenID NVARCHAR(20), 
    CitizenImageURL NVARCHAR(500);

/* =====================================================
   4. CATEGORIES – SHOPS – PRODUCTS
===================================================== */
CREATE TABLE Categories (
    CategoryID INT IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(150) NOT NULL,
    ParentCategoryID INT NULL,
    FOREIGN KEY (ParentCategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Shops (
    ShopID INT IDENTITY PRIMARY KEY,
    AccountID INT UNIQUE NOT NULL,
    ShopName NVARCHAR(200) UNIQUE NOT NULL,
    Description NVARCHAR(MAX),
    AvatarURL NVARCHAR(500),
    CoverImageURL NVARCHAR(500),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    RatingAverage DECIMAL(3,2) DEFAULT 0,

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Products (
    ProductID INT IDENTITY PRIMARY KEY,
    ShopID INT,
    CategoryID INT,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(12,2) CHECK (Price >= 0),
    StockQuantity INT DEFAULT 0 CHECK (StockQuantity >= 0),
    SoldCount INT DEFAULT 0,
    Status NVARCHAR(20) CHECK (Status IN ('Active','Hidden','OutOfStock')) DEFAULT 'Active',
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (ShopID) REFERENCES Shops(ShopID) ON DELETE NO ACTION,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE SET NULL
);

CREATE TABLE ProductImages (
    ImageID INT IDENTITY PRIMARY KEY,
    ProductID INT NOT NULL,
    ImageURL NVARCHAR(500) NOT NULL,
    ImagePublicId NVARCHAR(255),
    IsPrimary BIT DEFAULT 0,

    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
);

CREATE TABLE ProductVariants (
    VariantID INT IDENTITY PRIMARY KEY,
    ProductID INT NOT NULL,
    Size NVARCHAR(50),
    Color NVARCHAR(50),
    SKU NVARCHAR(100) UNIQUE,
    Price DECIMAL(12,2),
    StockQuantity INT DEFAULT 0,

    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
);


/* =====================================================
   5. CART
===================================================== */
CREATE TABLE Carts (
    CartID INT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);

CREATE TABLE CartItems (
    CartItemID INT IDENTITY PRIMARY KEY,
    CartID INT NOT NULL,
    ProductID INT NOT NULL,
    VariantID INT NULL,
    Quantity INT CHECK (Quantity > 0),
    AddedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (CartID) REFERENCES Carts(CartID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);


/* =====================================================
   6. ORDER GROUP – ORDERS – ORDER DETAILS
===================================================== */
CREATE TABLE OrderGroups (
    OrderGroupID INT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    TotalAmount DECIMAL(12,2) CHECK (TotalAmount >= 0),
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Orders (
    OrderID INT IDENTITY PRIMARY KEY,
    OrderGroupID INT NOT NULL,
    ShopID INT NOT NULL,
    AccountID INT NOT NULL,
    AddressID INT,
    TotalAmount DECIMAL(12,2),
    Status NVARCHAR(20) DEFAULT 'Pending',
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsReviewed BIT DEFAULT 0,

    FOREIGN KEY (OrderGroupID) REFERENCES OrderGroups(OrderGroupID) ON DELETE CASCADE,
    FOREIGN KEY (ShopID) REFERENCES Shops(ShopID),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE,
    FOREIGN KEY (AddressID) REFERENCES UserAddresses(AddressID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    VariantID INT NULL,
    Quantity INT CHECK (Quantity > 0),
    UnitPrice DECIMAL(12,2) CHECK (UnitPrice >= 0),
    SubTotal AS (Quantity * UnitPrice) PERSISTED,

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);


/* =====================================================
   7. PAYMENT
===================================================== */
CREATE TABLE Payments (
    PaymentID INT IDENTITY PRIMARY KEY,
    OrderGroupID INT NOT NULL,
    Method NVARCHAR(20) DEFAULT 'COD',
    Amount DECIMAL(12,2),
    PaymentStatus NVARCHAR(20) DEFAULT 'Pending',
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (OrderGroupID) REFERENCES OrderGroups(OrderGroupID) ON DELETE CASCADE
);


/* =====================================================
   8. REVIEWS
===================================================== */
CREATE TABLE Reviews (
    ReviewID INT IDENTITY PRIMARY KEY,
    ProductID INT NOT NULL,
    AccountID INT NOT NULL,
    ShopID INT NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) DEFAULT 'Pending',
    OrderDetailID INT,

    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE,
    FOREIGN KEY (ShopID) REFERENCES Shops(ShopID),
    FOREIGN KEY (OrderDetailID) REFERENCES OrderDetails(OrderDetailID)
);


/* =====================================================
   9. WISHLIST
===================================================== */
CREATE TABLE Wishlists (
    WishlistID INT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    ProductID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT UQ_Wishlist UNIQUE (AccountID, ProductID)
);


/* =====================================================
   10. VOUCHERS
===================================================== */
CREATE TABLE Vouchers (
    VoucherID INT IDENTITY PRIMARY KEY,
    ShopID INT NULL,
    Code NVARCHAR(50) UNIQUE NOT NULL,
    Description NVARCHAR(MAX),
    DiscountPercent DECIMAL(5,2),
    MinOrderAmount DECIMAL(12,2) DEFAULT 0,
    StartDate DATETIME,
    EndDate DATETIME,

    FOREIGN KEY (ShopID) REFERENCES Shops(ShopID) ON DELETE CASCADE
);


/* =====================================================
   11. CHAT SYSTEM
===================================================== */
CREATE TABLE ChatRooms (
    RoomID INT IDENTITY PRIMARY KEY,
    BuyerID INT NOT NULL,
    ShopID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsClosed BIT DEFAULT 0,

    FOREIGN KEY (BuyerID) REFERENCES Accounts(AccountID) ON DELETE CASCADE,
    FOREIGN KEY (ShopID) REFERENCES Shops(ShopID) ON DELETE CASCADE,
    CONSTRAINT UQ_Chat UNIQUE (BuyerID, ShopID)
);

CREATE TABLE ChatMessages (
    MessageID INT IDENTITY PRIMARY KEY,
    RoomID INT NOT NULL,
    SenderID INT NOT NULL,
    MessageType NVARCHAR(20) DEFAULT 'Text',
    MessageText NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (RoomID) REFERENCES ChatRooms(RoomID) ON DELETE CASCADE,
    FOREIGN KEY (SenderID) REFERENCES Accounts(AccountID)
);

CREATE TABLE ChatAttachments (
    AttachmentID INT IDENTITY PRIMARY KEY,
    MessageID INT NOT NULL,
    FileURL NVARCHAR(500),
    FilePublicId NVARCHAR(255),
    FileType NVARCHAR(50),

    FOREIGN KEY (MessageID) REFERENCES ChatMessages(MessageID) ON DELETE CASCADE
);


/* =====================================================
   12. SHIPPING
===================================================== */
CREATE TABLE ShippingPartners (
    ShipperID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    LogoURL NVARCHAR(500),
    IsActive BIT DEFAULT 1
);

CREATE TABLE OrderShippingInfo (
    ShippingInfoID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    ShipperID INT NULL,
    TrackingCode NVARCHAR(100),
    ShippingFee DECIMAL(12,2) DEFAULT 0,
    Status NVARCHAR(50) DEFAULT 'WaitingForPickup',
    EstimatedDeliveryDate DATE,

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ShipperID) REFERENCES ShippingPartners(ShipperID) ON DELETE SET NULL
);


/* =====================================================
   13. FLASH SALES
===================================================== */
CREATE TABLE FlashSales (
    FlashSaleID INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    StartTime DATETIME2 NOT NULL,
    EndTime DATETIME2 NOT NULL,
    IsActive BIT DEFAULT 1
);

CREATE TABLE FlashSaleProducts (
    FlashSaleProductID INT IDENTITY PRIMARY KEY,
    FlashSaleID INT NOT NULL,
    ProductID INT NOT NULL,
    VariantID INT NULL,
    FlashSalePrice DECIMAL(12,2),
    TotalStock INT,
    SoldCount INT DEFAULT 0,

    FOREIGN KEY (FlashSaleID) REFERENCES FlashSales(FlashSaleID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE,
    FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);


/* =====================================================
   14. NOTIFICATION
===================================================== */
CREATE TABLE Notifications (
    NotificationID BIGINT IDENTITY PRIMARY KEY,
    AccountID INT NOT NULL,
    Title NVARCHAR(100),
    Message NVARCHAR(500),
    LinkURL NVARCHAR(500),
    IsRead BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
);


/* =====================================================
   15. ORDER STATUS HISTORY
===================================================== */
CREATE TABLE OrderStatusHistory (
    HistoryID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    OldStatus NVARCHAR(20),
    NewStatus NVARCHAR(20),
    ChangedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE
);

use skynet_commerce;
-- Thêm cột CCCD và Ảnh vào bảng đăng ký
ALTER TABLE ShopRegistrations
ADD CitizenID NVARCHAR(20), 
    CitizenImageURL NVARCHAR(500);
GO
ALTER TABLE ShopRegistrations
ADD RejectionReason NVARCHAR(MAX);
GO
/* =====================================================
   16. INDEXES
===================================================== */
CREATE INDEX IX_Product_CategoryID ON Products(CategoryID);
CREATE INDEX IX_Product_ShopID ON Products(ShopID);
CREATE INDEX IX_Order_AccountID ON Orders(AccountID);
CREATE INDEX IX_OrderDetail_OrderID ON OrderDetails(OrderID);
CREATE INDEX IX_CartItems_CartID ON CartItems(CartID);
CREATE INDEX IX_ProductImages_ProductID ON ProductImages(ProductID);

select * from orders

select * from Accounts;