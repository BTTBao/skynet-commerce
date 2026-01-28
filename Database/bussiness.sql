/* =====================================================
   DROP VIEWS
===================================================== */

IF OBJECT_ID('v_Fraud_HighCancelRate', 'V') IS NOT NULL DROP VIEW v_Fraud_HighCancelRate;
IF OBJECT_ID('v_Fraud_ReviewSpam', 'V') IS NOT NULL DROP VIEW v_Fraud_ReviewSpam;
IF OBJECT_ID('v_Fraud_DuplicateInfo', 'V') IS NOT NULL DROP VIEW v_Fraud_DuplicateInfo;

IF OBJECT_ID('v_Admin_ShopBalances', 'V') IS NOT NULL DROP VIEW v_Admin_ShopBalances;
IF OBJECT_ID('v_Admin_Dashboard_Overview', 'V') IS NOT NULL DROP VIEW v_Admin_Dashboard_Overview;
IF OBJECT_ID('v_Admin_Revenue_ByMonth', 'V') IS NOT NULL DROP VIEW v_Admin_Revenue_ByMonth;
IF OBJECT_ID('v_Admin_TopProducts', 'V') IS NOT NULL DROP VIEW v_Admin_TopProducts;
IF OBJECT_ID('v_Admin_OrderStatus_Stats', 'V') IS NOT NULL DROP VIEW v_Admin_OrderStatus_Stats;
IF OBJECT_ID('v_Admin_TopShops', 'V') IS NOT NULL DROP VIEW v_Admin_TopShops;
IF OBJECT_ID('v_Admin_UserRole_Stats', 'V') IS NOT NULL DROP VIEW v_Admin_UserRole_Stats;
IF OBJECT_ID('v_Admin_PaymentHistory', 'V') IS NOT NULL DROP VIEW v_Admin_PaymentHistory;
IF OBJECT_ID('v_Admin_CloneAccounts_Detail', 'V') IS NOT NULL DROP VIEW v_Admin_CloneAccounts_Detail;
GO

/* =====================================================
   DROP FUNCTIONS & PROCEDURES
===================================================== */

IF OBJECT_ID('fn_Admin_GetUserDetails', 'IF') IS NOT NULL DROP FUNCTION fn_Admin_GetUserDetails;
IF OBJECT_ID('fn_Admin_GetShopRequestDetails', 'IF') IS NOT NULL DROP FUNCTION fn_Admin_GetShopRequestDetails;
GO

IF OBJECT_ID('sp_Admin_SettlePayment', 'P') IS NOT NULL DROP PROCEDURE sp_Admin_SettlePayment;
IF OBJECT_ID('sp_Admin_BanAccount', 'P') IS NOT NULL DROP PROCEDURE sp_Admin_BanAccount;
IF OBJECT_ID('sp_Admin_UnbanAccount', 'P') IS NOT NULL DROP PROCEDURE sp_Admin_UnbanAccount;
GO

/* =====================================================
   STORED PROCEDURE: SETTLE PAYMENT
===================================================== */
CREATE PROCEDURE sp_Admin_SettlePayment
    @ShopID INT,
    @AdminID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        -- 1. Lấy danh sách OrderID cần update
        DECLARE @OrdersToSettle TABLE (OrderID INT);
        
        INSERT INTO @OrdersToSettle (OrderID)
        SELECT OrderID 
        FROM Orders 
        WHERE ShopID = @ShopID AND Status = 'Delivered';

        IF NOT EXISTS (SELECT 1 FROM @OrdersToSettle)
        BEGIN
            COMMIT TRANSACTION;
            SELECT 0 AS Result; 
            RETURN;
        END

        -- 2. Update status -> 'Settled'
        UPDATE Orders
        SET Status = 'Settled'
        WHERE OrderID IN (SELECT OrderID FROM @OrdersToSettle);

        -- 3. Insert into OrderStatusHistory
        INSERT INTO OrderStatusHistory (OrderID, OldStatus, NewStatus, ChangedAt)
        SELECT OrderID, 'Delivered', 'Settled', GETDATE()
        FROM @OrdersToSettle;

        COMMIT TRANSACTION;
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 0 AS Result;
    END CATCH
END;
GO

/* =====================================================
   FRAUD DETECTION VIEWS
===================================================== */

CREATE VIEW v_Fraud_HighCancelRate AS
SELECT 
    u.UserID,
    u.FullName,
    a.Phone,
    COUNT(o.OrderID) AS TotalOrders,
    SUM(CASE WHEN o.Status = 'Cancelled' THEN 1 ELSE 0 END) AS CancelledOrders,
    CAST(SUM(CASE WHEN o.Status = 'Cancelled' THEN 1 ELSE 0 END) AS DECIMAL(5,2))
        / NULLIF(COUNT(o.OrderID), 0) * 100 AS CancelRate
FROM Users u
JOIN Accounts a ON u.AccountID = a.AccountID
JOIN Orders o ON a.AccountID = o.AccountID
GROUP BY u.UserID, u.FullName, a.Phone
HAVING COUNT(o.OrderID) >= 5
   AND CAST(SUM(CASE WHEN o.Status = 'Cancelled' THEN 1 ELSE 0 END) AS DECIMAL(5,2))
       / COUNT(o.OrderID) >= 0.5;
GO

CREATE VIEW v_Fraud_ReviewSpam AS
SELECT 
    s.ShopID,
    s.ShopName,
    r.AccountID AS ReviewerID,
    COUNT(r.ReviewID) AS ReviewCount,
    MIN(r.CreatedAt) AS FirstReviewTime,
    MAX(r.CreatedAt) AS LastReviewTime,
    DATEDIFF(MINUTE, MIN(r.CreatedAt), MAX(r.CreatedAt)) AS TimeSpanMinutes
FROM Reviews r
JOIN Shops s ON r.ShopID = s.ShopID
WHERE r.Rating = 5
GROUP BY s.ShopID, s.ShopName, r.AccountID
HAVING COUNT(r.ReviewID) >= 3
   AND DATEDIFF(MINUTE, MIN(r.CreatedAt), MAX(r.CreatedAt)) <= 10;
GO

CREATE VIEW v_Fraud_DuplicateInfo AS
SELECT 
    ua.ReceiverPhone,
    COUNT(DISTINCT ua.AccountID) AS LinkedAccountsCount,
    STRING_AGG(CONVERT(NVARCHAR(MAX), ua.AccountID), ', ') AS AccountIDs
FROM UserAddresses ua
GROUP BY ua.ReceiverPhone
HAVING COUNT(DISTINCT ua.AccountID) > 1;
GO

/* =====================================================
   ADMIN / PAYMENT VIEWS
===================================================== */

CREATE VIEW v_Admin_ShopBalances AS
SELECT 
    s.ShopID,
    s.ShopName,
    a.Phone AS ShopOwnerPhone,
    SUM(CASE WHEN o.Status IN ('Pending','Processing','Shipping','Shipped')
             THEN od.Quantity * od.UnitPrice * 0.95 ELSE 0 END) AS LockedBalance,
    SUM(CASE WHEN o.Status = 'Delivered'
             THEN od.Quantity * od.UnitPrice * 0.95 ELSE 0 END) AS AvailableBalance
FROM Shops s
JOIN Accounts a ON s.AccountID = a.AccountID
JOIN Orders o ON s.ShopID = o.ShopID
JOIN OrderDetails od ON o.OrderID = od.OrderID
GROUP BY s.ShopID, s.ShopName, a.Phone;
GO

CREATE VIEW v_Admin_Dashboard_Overview AS
SELECT
    (SELECT COUNT(*) FROM Users) AS TotalUsers,
    (SELECT COUNT(*) FROM Accounts WHERE CreatedAt >= DATEADD(DAY, -7, GETDATE())) AS NewUsersLast7Days,
    (SELECT COUNT(*) FROM Shops WHERE IsActive = 1) AS TotalActiveShops,
    (SELECT COUNT(*) FROM Shops WHERE CreatedAt >= DATEADD(DAY, -30, GETDATE())) AS NewShopsLast30Days,
    (SELECT COUNT(*) FROM Products WHERE Status = 'Active') AS TotalActiveProducts,
    (SELECT COUNT(*) FROM Orders) AS TotalOrders,
    (SELECT COUNT(*) FROM Orders
        WHERE MONTH(CreatedAt) = MONTH(GETDATE())
          AND YEAR(CreatedAt) = YEAR(GETDATE())) AS OrdersThisMonth,
    (SELECT ISNULL(SUM(TotalAmount),0) FROM Orders
        WHERE Status IN ('Delivered','Settled')
          AND MONTH(CreatedAt) = MONTH(GETDATE())
          AND YEAR(CreatedAt) = YEAR(GETDATE())) AS RevenueThisMonth,
    (SELECT ISNULL(SUM(TotalAmount),0) FROM Orders
        WHERE Status IN ('Delivered','Settled')
          AND MONTH(CreatedAt) = MONTH(DATEADD(MONTH,-1,GETDATE()))
          AND YEAR(CreatedAt) = YEAR(DATEADD(MONTH,-1,GETDATE()))) AS RevenueLastMonth;
GO

-- View: Doanh thu theo tháng (12 tháng gần nhất)
CREATE VIEW v_Admin_Revenue_ByMonth AS
SELECT 
    FORMAT(o.CreatedAt, 'yyyy-MM') AS YearMonth,
    YEAR(o.CreatedAt) AS Year,
    MONTH(o.CreatedAt) AS Month,
    COUNT(o.OrderID) AS TotalOrders,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalRevenue,
    ISNULL(SUM(o.TotalAmount) * 0.05, 0) AS PlatformFee
FROM Orders o
WHERE o.Status IN ('Delivered', 'Settled')
AND o.CreatedAt >= DATEADD(MONTH, -12, GETDATE())
GROUP BY FORMAT(o.CreatedAt, 'yyyy-MM'), YEAR(o.CreatedAt), MONTH(o.CreatedAt);
GO

-- View: Top sản phẩm bán chạy
CREATE VIEW v_Admin_TopProducts AS
SELECT TOP 10
    p.ProductID,
    p.Name AS ProductName,
    s.ShopName,
    p.SoldCount,
    p.Price,
    p.SoldCount * p.Price AS TotalRevenue
FROM Products p
JOIN Shops s ON p.ShopID = s.ShopID
ORDER BY p.SoldCount DESC;
GO

-- View: Thống kê đơn hàng theo trạng thái
CREATE VIEW v_Admin_OrderStatus_Stats AS
SELECT 
    Status,
    COUNT(*) AS OrderCount,
    ISNULL(SUM(TotalAmount), 0) AS TotalAmount
FROM Orders
GROUP BY Status;
GO

-- View: Top Shop bán chạy
CREATE VIEW v_Admin_TopShops AS
SELECT TOP 10
    s.ShopID,
    s.ShopName,
    COUNT(DISTINCT o.OrderID) AS TotalOrders,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalRevenue,
    s.RatingAverage
FROM Shops s
LEFT JOIN Orders o ON s.ShopID = o.ShopID AND o.Status IN ('Delivered', 'Settled')
WHERE s.IsActive = 1
GROUP BY s.ShopID, s.ShopName, s.RatingAverage
ORDER BY TotalRevenue DESC;
GO

-- View: Thống kê người dùng theo vai trò
CREATE VIEW v_Admin_UserRole_Stats AS
SELECT 
    ur.RoleName,
    COUNT(DISTINCT ur.AccountID) AS UserCount
FROM UserRoles ur
GROUP BY ur.RoleName;
GO

/* =====================================================
   PAYMENT HISTORY - LỊCH SỬ THANH TOÁN
===================================================== */

-- View: Lịch sử thanh toán (từ OrderStatusHistory)
CREATE VIEW v_Admin_PaymentHistory AS
SELECT 
    osh.HistoryID AS SettlementID,
    osh.ChangedAt AS SettlementDate,
    o.ShopID,
    s.ShopName,
    sa.Phone AS ShopOwnerPhone,
    o.TotalAmount,
    o.TotalAmount * 0.05 AS PlatformFee,
    o.TotalAmount * 0.95 AS NetAmount,
    1 AS OrderCount,
    N'Admin' AS ProcessedBy
FROM OrderStatusHistory osh
JOIN Orders o ON osh.OrderID = o.OrderID
JOIN Shops s ON o.ShopID = s.ShopID
LEFT JOIN Accounts sa ON s.AccountID = sa.AccountID
WHERE osh.NewStatus = 'Settled'
AND osh.OldStatus = 'Delivered';
GO

/* =====================================================
   USER DETAILS - CHI TIẾT USER
===================================================== */

-- Function: Lấy thông tin chi tiết User
CREATE FUNCTION fn_Admin_GetUserDetails(@UserID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        u.UserID,
        u.FullName,
        u.Gender,
        u.DateOfBirth,
        u.AvatarURL,
        a.AccountID,
        a.Email,
        a.Phone,
        a.CreatedAt AS AccountCreatedAt,
        a.IsActive AS AccountStatus,
        -- Số địa chỉ
        (SELECT COUNT(*) FROM UserAddresses WHERE AccountID = a.AccountID) AS TotalAddresses,
        -- Vai trò
        (SELECT STRING_AGG(RoleName, ', ') FROM UserRoles WHERE AccountID = a.AccountID) AS Roles,
        -- Thống kê đơn hàng
        (SELECT COUNT(*) FROM Orders WHERE AccountID = a.AccountID) AS TotalOrders,
        (SELECT COUNT(*) FROM Orders WHERE AccountID = a.AccountID AND Status = 'Delivered') AS DeliveredOrders,
        (SELECT COUNT(*) FROM Orders WHERE AccountID = a.AccountID AND Status = 'Cancelled') AS CancelledOrders,
        (SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE AccountID = a.AccountID AND Status IN ('Delivered', 'Settled')) AS TotalSpent,
        -- Thống kê đánh giá
        (SELECT COUNT(*) FROM Reviews WHERE AccountID = a.AccountID) AS TotalReviews,
        -- Shop (nếu có)
        (SELECT ShopID FROM Shops WHERE AccountID = a.AccountID) AS ShopID,
        (SELECT ShopName FROM Shops WHERE AccountID = a.AccountID) AS ShopName
    FROM Users u
    JOIN Accounts a ON u.AccountID = a.AccountID
    WHERE u.UserID = @UserID
);
GO

/* =====================================================
   SHOP REQUEST DETAILS - CHI TIẾT ĐƠN ĐĂNG KÝ SHOP
===================================================== */

-- Function: Lấy chi tiết đơn đăng ký Shop
CREATE FUNCTION fn_Admin_GetShopRequestDetails(@RegistrationID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        sr.RegistrationID,
        sr.ShopName,
        sr.Description,
        sr.Status,
        sr.CreatedAt,
        sr.ReviewedAt,
        sr.CitizenID,
        sr.CitizenImageURL,
        -- Thông tin Account
        a.AccountID,
        a.Email,
        a.Phone,
        a.CreatedAt AS AccountCreatedAt,
        a.IsActive AS AccountStatus,
        -- Thông tin User
        u.UserID,
        u.FullName,
        u.Gender,
        u.DateOfBirth,
        u.AvatarURL,
        -- Thống kê Account
        (SELECT COUNT(*) FROM Orders WHERE AccountID = a.AccountID) AS TotalOrdersAsBuyer,
        (SELECT STRING_AGG(RoleName, ', ') FROM UserRoles WHERE AccountID = a.AccountID) AS CurrentRoles
    FROM ShopRegistrations sr
    JOIN Accounts a ON sr.AccountID = a.AccountID
    LEFT JOIN Users u ON a.AccountID = u.AccountID
    WHERE sr.RegistrationID = @RegistrationID
);
GO

/* =====================================================
   FRAUD DETECTION ENHANCED - PHÁT HIỆN GIAN LẬN NÂNG CAO
===================================================== */

-- View: Chi tiết Clone Accounts (bổ sung AccountID cụ thể)
CREATE VIEW v_Admin_CloneAccounts_Detail AS
SELECT 
    ua.ReceiverPhone,
    ua.AccountID,
    u.FullName,
    a.Email,
    a.IsActive AS AccountStatus,
    (SELECT COUNT(*) FROM Orders WHERE AccountID = ua.AccountID) AS TotalOrders,
    (SELECT COUNT(*) FROM Orders WHERE AccountID = ua.AccountID AND Status = 'Cancelled') AS CancelledOrders,
    COUNT(ua.AddressID) AS AddressCount
FROM UserAddresses ua
JOIN Accounts a ON ua.AccountID = a.AccountID
LEFT JOIN Users u ON a.AccountID = u.AccountID
WHERE ua.ReceiverPhone IN (
    SELECT ReceiverPhone 
    FROM UserAddresses 
    GROUP BY ReceiverPhone 
    HAVING COUNT(DISTINCT AccountID) > 1
)
GROUP BY ua.ReceiverPhone, ua.AccountID, u.FullName, a.Email, a.IsActive;
GO

-- Procedure: Khóa tài khoản (Admin action)
CREATE PROCEDURE sp_Admin_BanAccount
    @AccountID INT,
    @AdminID INT,
    @Reason NVARCHAR(500) = NULL
AS
BEGIN
    BEGIN TRY
        UPDATE Accounts 
        SET IsActive = 0 
        WHERE AccountID = @AccountID;

        -- Log vào Notifications
        INSERT INTO Notifications (AccountID, Title, Message, CreatedAt)
        VALUES (@AccountID, N'Tài khoản bị khóa', 
                ISNULL(@Reason, N'Tài khoản của bạn đã bị khóa do vi phạm chính sách.'), 
                GETDATE());

        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        SELECT 0 AS Result;
    END CATCH
END;
GO

-- Procedure: Mở khóa tài khoản
CREATE PROCEDURE sp_Admin_UnbanAccount
    @AccountID INT,
    @AdminID INT
AS
BEGIN
    BEGIN TRY
        UPDATE Accounts 
        SET IsActive = 1 
        WHERE AccountID = @AccountID;

        INSERT INTO Notifications (AccountID, Title, Message, CreatedAt)
        VALUES (@AccountID, N'Tài khoản đã được mở khóa', 
                N'Tài khoản của bạn đã được kích hoạt lại.', 
                GETDATE());

        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        SELECT 0 AS Result;
    END CATCH
END;
GO