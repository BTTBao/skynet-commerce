drop database Skynet_commerce;
create database Skynet_commerce;

use skynet_commerce;
CREATE TABLE Accounts (
  AccountID INT AUTO_INCREMENT PRIMARY KEY,
  Username VARCHAR(100) UNIQUE NOT NULL,
  Password VARCHAR(255) NOT NULL,
  Email VARCHAR(150) UNIQUE,
  Phone VARCHAR(20),
  Status ENUM('Active','Locked') DEFAULT 'Active',

  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  LastLogin DATETIME,
  LastPasswordChange DATETIME
);

CREATE TABLE Roles (
  RoleID INT AUTO_INCREMENT PRIMARY KEY,
  RoleName VARCHAR(50) NOT NULL,
  Description TEXT
);

CREATE TABLE AccountRoles (
  AccountRoleID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT,
  RoleID INT,
  AssignedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
  FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE Users (
  UserID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT UNIQUE,
  FullName VARCHAR(150),
  Gender ENUM('Male','Female','Other'),
  DOB DATE,
  AvatarURL VARCHAR(255),
  LoyaltyPoints INT DEFAULT 0,
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE UserAddresses (
  AddressID INT AUTO_INCREMENT PRIMARY KEY,
  UserID INT,
  AddressLine VARCHAR(255),
  City VARCHAR(100),
  Province VARCHAR(100),
  PostalCode VARCHAR(20),
  IsDefault BOOLEAN DEFAULT FALSE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Shops (
  ShopID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT,
  ShopName VARCHAR(150),
  Description TEXT,
  LogoURL VARCHAR(255),
  CoverImageURL VARCHAR(255),
  RatingAvg DECIMAL(3,2) DEFAULT 0,
  RatingCount INT DEFAULT 0,
  Status ENUM('Active','Locked','Pending') DEFAULT 'Pending',
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Categories (
  CategoryID INT AUTO_INCREMENT PRIMARY KEY,
  CategoryName VARCHAR(150),
  ParentCategoryID INT NULL,
  IconURL VARCHAR(255),
  FOREIGN KEY (ParentCategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Products (
  ProductID INT AUTO_INCREMENT PRIMARY KEY,
  ShopID INT,
  CategoryID INT,
  Name VARCHAR(200),
  Description TEXT,
  Price DECIMAL(12,2),
  SoldCount INT DEFAULT 0,
  StockQuantity INT,
  Status ENUM('Active','OutOfStock','Hidden') DEFAULT 'Active',
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (ShopID) REFERENCES Shops(ShopID),
  FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE ProductImages (
  ImageID INT AUTO_INCREMENT PRIMARY KEY,
  ProductID INT,
  ImageURL VARCHAR(255),
  IsPrimary BOOLEAN DEFAULT FALSE,
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE ProductVariants (
  VariantID INT AUTO_INCREMENT PRIMARY KEY,
  ProductID INT,
  SKU VARCHAR(100),
  VariantName VARCHAR(150),
  Price DECIMAL(12,2),
  StockQuantity INT,
  ImageURL VARCHAR(255),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);



CREATE TABLE Promotions (
  PromotionID INT AUTO_INCREMENT PRIMARY KEY,
  ProductID INT,
  DiscountPercent DECIMAL(5,2),
  StartDate DATETIME,
  EndDate DATETIME,
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Orders (
  OrderID INT AUTO_INCREMENT PRIMARY KEY,
  BuyerAccountID INT,
  AddressID INT,
  ShippingMethod VARCHAR(100),
  TrackingCode VARCHAR(100),
  TotalAmount DECIMAL(12,2),
  Status ENUM('Pending','Confirmed','Shipped','Delivered','Cancelled','Returned') DEFAULT 'Pending',
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (BuyerAccountID) REFERENCES Accounts(AccountID),
  FOREIGN KEY (AddressID) REFERENCES UserAddresses(AddressID)
);

CREATE TABLE OrderDetails (
  OrderDetailID INT AUTO_INCREMENT PRIMARY KEY,
  OrderID INT,
  ProductID INT,
  VariantID INT NULL,
  Quantity INT,
  UnitPrice DECIMAL(12,2),
  SubTotal DECIMAL(12,2),
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
  FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);

CREATE TABLE Payments (
  PaymentID INT AUTO_INCREMENT PRIMARY KEY,
  OrderID INT,
  Method ENUM('COD','CreditCard','eWallet','BankTransfer'),
  Amount DECIMAL(12,2),
  TransactionCode VARCHAR(100),
  PaymentStatus ENUM('Pending','Paid','Failed') DEFAULT 'Pending',
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

CREATE TABLE Reviews (
  ReviewID INT AUTO_INCREMENT PRIMARY KEY,
  ProductID INT,
  AccountID INT,
  Rating INT CHECK (Rating BETWEEN 1 AND 5),
  Comment TEXT,
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE ReviewImages (
  ReviewImageID INT AUTO_INCREMENT PRIMARY KEY,
  ReviewID INT,
  ImageURL VARCHAR(255),
  FOREIGN KEY (ReviewID) REFERENCES Reviews(ReviewID)
);

CREATE TABLE SellerRequests (
  RequestID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT,
  ShopName VARCHAR(150),
  Description TEXT,
  Status ENUM('Pending','Approved','Rejected') DEFAULT 'Pending',
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);


CREATE TABLE Carts (
  CartID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT,
  ProductID INT,
  VariantID INT NULL,
  Quantity INT,
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
  FOREIGN KEY (VariantID) REFERENCES ProductVariants(VariantID)
);

CREATE TABLE Wishlists (
  WishlistID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT,
  ProductID INT,
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Notifications (
  NotificationID INT AUTO_INCREMENT PRIMARY KEY,
  AccountID INT,
  Title VARCHAR(200),
  Message TEXT,
  IsRead BOOLEAN DEFAULT FALSE,
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Vouchers (
  VoucherID INT AUTO_INCREMENT PRIMARY KEY,
  Code VARCHAR(50) UNIQUE,
  Description TEXT,
  DiscountPercent DECIMAL(5,2),
  MaxDiscountAmount DECIMAL(12,2),
  MinOrderAmount DECIMAL(12,2),
  StartDate DATETIME,
  EndDate DATETIME,
  UsageLimit INT
);

CREATE TABLE VoucherUsages (
  UsageID INT AUTO_INCREMENT PRIMARY KEY,
  VoucherID INT,
  AccountID INT,
  OrderID INT,
  UsedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (VoucherID) REFERENCES Vouchers(VoucherID),
  FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- CREATE TABLE Conversations (
--   ConversationID INT AUTO_INCREMENT PRIMARY KEY,
--   CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
-- );

-- CREATE TABLE ConversationMembers (
--   MemberID INT AUTO_INCREMENT PRIMARY KEY,
--   ConversationID INT,
--   AccountID INT,
--   JoinedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
--   FOREIGN KEY (ConversationID) REFERENCES Conversations(ConversationID),
--   FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
-- );

-- CREATE TABLE ChatMessages (
--   MessageID INT AUTO_INCREMENT PRIMARY KEY,
--   ConversationID INT,
--   SenderAccountID INT,
--   Message TEXT,
--   MessageType ENUM('text','image','file','system') DEFAULT 'text',
--   IsRead BOOLEAN DEFAULT FALSE,
--   CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
--   FOREIGN KEY (ConversationID) REFERENCES Conversations(ConversationID),
--   FOREIGN KEY (SenderAccountID) REFERENCES Accounts(AccountID)
-- );

-- CREATE TABLE MessageAttachments (
--   AttachmentID INT AUTO_INCREMENT PRIMARY KEY,
--   MessageID INT,
--   FileURL VARCHAR(255),
--   FileType VARCHAR(50),
--   FOREIGN KEY (MessageID) REFERENCES ChatMessages(MessageID)
-- );

-- luot mua trong product
