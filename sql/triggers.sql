USE CoffeeShopManagement;
GO

/* Cập nhật điểm của khách hàng khi xuất bill */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_Customer_UpdateRewardPoint_onBillInsert' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_Customer_UpdateRewardPoint_onBillInsert;
GO

CREATE TRIGGER tr_Customer_UpdateRewardPoint_onBillInsert
ON OrderBill
AFTER INSERT
AS
BEGIN
    -- Update reward points for each customer based on the bill
    DECLARE @customerId UNIQUEIDENTIFIER, @totalSpent DECIMAL(10, 2), @rewardPoints DECIMAL(10, 2);

    -- Debug: Kiểm tra dữ liệu trong bảng inserted
    PRINT 'Trigger is running!';
    SELECT * FROM inserted;

    -- Tính tổng số tiền được giảm giá của từng khách hàng
    SELECT @customerId = customerId, @totalSpent = SUM(initialBill - finalBill)
    FROM inserted
    GROUP BY customerId;

    -- Tính reward points dựa trên tổng số tiền giảm giá
    SET @rewardPoints = @totalSpent * 0.1; -- 10% của tổng số tiền

    -- Cập nhật reward points cho khách hàng
    UPDATE Customer
    SET rewardPoint = rewardPoint + @rewardPoints
    WHERE customerId = @customerId;

    PRINT 'Trigger has updated successfully reward point!';
END;
GO

/* Cập nhật điểm của khách khi họ sử dụng điểm để thanh toán */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_Customer_UpdateRewardPoint_onBillUpdate' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_Customer_UpdateRewardPoint_onBillUpdate;
GO

CREATE TRIGGER tr_Customer_UpdateRewardPoint_onBillUpdate
ON OrderBill
AFTER UPDATE
AS
BEGIN
    -- Update reward points for each customer when they use points for payment
    DECLARE @customerId UNIQUEIDENTIFIER, @usedPoints DECIMAL(10, 2);

    -- Calculate total used points for each customer in the updated orders
    SELECT @customerId = customerId, @usedPoints = SUM(rewardPointsUsed) 
    FROM inserted 
    GROUP BY customerId;

    -- Deduct used points from the customer's reward points
    UPDATE Customer
    SET rewardPoint = CASE
                        WHEN rewardPoint - @usedPoints >= 0 THEN rewardPoint - @usedPoints
                        ELSE 0
                      END
    WHERE customerId = @customerId;
END;
GO

/* Tự tạo tài khoản cho nhân viên khi thêm một nhân viên */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_Employee_AfterInsert' AND [type] = 'TR')
    DROP TRIGGER [dbo].[tr_Employee_AfterInsert];
GO

CREATE TRIGGER tr_Employee_AfterInsert
ON Employee
AFTER INSERT
AS
BEGIN
    -- Create accounts for employees who ARE working, accounts are ENABLED
    INSERT INTO Account (employeeId, username, password, role, createdAt, updatedAt, isDeleted)
    SELECT employeeId, email, phoneNumber, 'Employee', GETDATE(), GETDATE(), 0
    FROM inserted
    WHERE isWorking = 1;

    -- Create accounts for employees who ARE NOT working, accounts are DISABLED
    INSERT INTO Account (employeeId, username, password, role, createdAt, updatedAt, isDeleted)
    SELECT employeeId, email, phoneNumber, 'Employee', GETDATE(), GETDATE(), 1
    FROM inserted
    WHERE isWorking = 0;
END;
GO

/* Khóa/Mở tài khoản của nhân viên khi cập nhật trạng thái đang làm việc của nhân viên đấy */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_Employee_AfterUpdateIsWorking' AND [type] = 'TR')
    DROP TRIGGER [dbo].[tr_Employee_AfterUpdateIsWorking];
GO

CREATE TRIGGER tr_Employee_AfterUpdateIsWorking
ON Employee
AFTER UPDATE
AS
BEGIN
    -- Check if isWorking is updated in any row
    IF UPDATE(isWorking)
    BEGIN
        DECLARE @employeeId UNIQUEIDENTIFIER, @isWorking BIT;

        -- Get the employeeId and isWorking value for each updated row
        SELECT @employeeId = employeeId, @isWorking = isWorking 
        FROM inserted;

        -- Update isDeleted for the corresponding account
        UPDATE Account
        SET isDeleted = CASE 
                            WHEN @isWorking = 1 THEN 0
                            ELSE 1
                        END
        WHERE employeeId = @employeeId;
    END;
END;
GO

/* Cập nhật số tiền tổng của OrderBill khi thêm một sản phẩm trong OrderBillDetails */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_OrderBill_AfterInsert' AND [type] = 'TR')
    DROP TRIGGER [dbo].[tr_OrderBill_AfterInsert];
GO

CREATE TRIGGER tr_OrderBill_AfterInsert
ON OrderBillDetails
AFTER INSERT
AS
BEGIN
    -- Get billId and calculate the new price we need to add to the OrderBill
    DECLARE @billId UNIQUEIDENTIFIER, @addedPrice DECIMAL(10, 2);

    SELECT @billId = billId, @addedPrice = SUM(quantity * productPrice) 
    FROM inserted 
    INNER JOIN Product ON inserted.productId = Product.productId 
    GROUP BY billId;

    -- Update the initialBill in the OrderBill
    UPDATE OrderBill
    SET initialBill = initialBill + @addedPrice
    WHERE billId = @billId;

    -- Update the finalBill in the OrderBill
    UPDATE OrderBill
    SET finalBill = initialBill - rewardPointsUsed
    WHERE billId = @billId;
END;
GO

/* Cập nhật số tiền tổng của RestockBill khi thêm một sản phẩm trong RestockBillDetails */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_RestockBill_AfterInsert' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_RestockBill_AfterInsert;
GO

CREATE TRIGGER tr_RestockBill_AfterInsert
ON RestockBillDetails
AFTER INSERT
AS
BEGIN
    -- Get billId and calculate the new price we need to add to the RestockBill
    DECLARE @restockBillId UNIQUEIDENTIFIER, @addedPrice DECIMAL(10, 2);

    SELECT @restockBillId = restockBillId, @addedPrice = SUM(quantity * price) 
    FROM inserted 
    GROUP BY restockBillId;

    -- Update the totalBill in the RestockBill
    UPDATE RestockBill
    SET totalBill = totalBill + @addedPrice
    WHERE restockBillId = @restockBillId;
END;
GO

/* Cập nhật số tiền tổng của RestockBill khi sửa một sản phẩm trong RestockBillDetails */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_RestockBill_AfterUpdate' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_RestockBill_AfterUpdate;
GO

CREATE TRIGGER tr_RestockBill_AfterUpdate
ON RestockBillDetails
AFTER UPDATE
AS
BEGIN
    -- Get billId and calculate the new price we need to add to the RestockBill
    DECLARE @restockBillId UNIQUEIDENTIFIER, @oldAmount DECIMAL(10, 2), @newAmount DECIMAL(10, 2), @amountDifference DECIMAL(10, 2);

    SELECT @restockBillId = deleted.restockBillId, 
           @oldAmount = deleted.quantity * deleted.price,
           @newAmount = inserted.quantity * inserted.price 
    FROM deleted
    JOIN inserted ON deleted.ingredientId = inserted.ingredientId AND deleted.restockBillId = inserted.restockBillId;

    -- Calculate the difference in amount
    SET @amountDifference = @newAmount - @oldAmount;

    -- Update the totalBill in the RestockBill
    UPDATE RestockBill
    SET totalBill = totalBill + @amountDifference
    WHERE restockBillId = @restockBillId;
END;
GO

/* Cập nhật số tiền tổng của RestockBill khi xóa một sản phẩm trong RestockBillDetails */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_RestockBill_AfterDelete' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_RestockBill_AfterDelete;
GO

CREATE TRIGGER tr_RestockBill_AfterDelete
ON RestockBillDetails
AFTER DELETE
AS
BEGIN
    -- Get billId and calculate the new price we need to subtract from the RestockBill
    DECLARE @restockBillId UNIQUEIDENTIFIER, @subtractedAmount DECIMAL(10, 2);

    SELECT @restockBillId = restockBillId, @subtractedAmount = SUM(quantity * price) 
    FROM deleted 
    GROUP BY restockBillId;

    -- Update the totalBill in the RestockBill
    UPDATE RestockBill
    SET totalBill = totalBill - @subtractedAmount
    WHERE restockBillId = @restockBillId;
END;
GO

/* Authorization Trigger */
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_AccountAuthorizaton_onInsert' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_AccountAuthorizaton_onInsert;
GO

CREATE TRIGGER tr_AccountAuthorizaton_onInsert
ON Account
AFTER INSERT
AS
BEGIN
    -- Khai báo các biến để lưu thông tin từ bảng inserted
    DECLARE @UserName VARCHAR(255), @Password VARCHAR(255), @Role VARCHAR(20);

    -- Lấy thông tin username, password và role từ bảng inserted (bản ghi vừa được thêm vào)
    SELECT @UserName = inserted.username, @Password = inserted.password, @Role = inserted.role 
    FROM inserted;

    -- Tạo một Login mới trên SQL Server với username và password từ bảng Account
    EXEC('CREATE LOGIN [' + @UserName + '] WITH PASSWORD = ''' + @Password + ''', DEFAULT_DATABASE=[CoffeeShop], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF');
    
    -- Tạo một User mới trong database CoffeeShop liên kết với Login vừa tạo
    EXEC('CREATE USER [' + @UserName + '] FOR LOGIN [' + @UserName + ']');

    -- Phân quyền cho User dựa trên Role
    IF @Role = 'Employee'
    BEGIN
        -- Nếu Role là Employee, thêm User vào Role employee
        EXEC('ALTER ROLE employee ADD MEMBER [' + @UserName + ']');
    END;
    ELSE IF @Role = 'Manager'
    BEGIN
        -- Nếu Role là Manager, thêm User vào Role manager và cấp quyền sysadmin
        EXEC('ALTER ROLE manager ADD MEMBER [' + @UserName + ']');
        EXEC('ALTER SERVER ROLE sysadmin ADD MEMBER [' + @UserName + ']');
    END;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'tr_AccountAuthorizaton_onUpdate' AND [type] = 'TR')
    DROP TRIGGER [dbo].tr_AccountAuthorizaton_onUpdate;
GO

CREATE TRIGGER tr_AccountAuthorizaton_onUpdate
ON Account
AFTER UPDATE
AS
BEGIN
    -- Khai báo các biến để lưu thông tin từ bảng inserted
    DECLARE @UserName VARCHAR(255), @Password VARCHAR(255), @Role VARCHAR(20);

    -- Lấy thông tin username, password và role từ bảng inserted (bản ghi vừa được cập nhật)
    SELECT @UserName = username, @Password = password, @Role = role 
    FROM inserted;

    -- Cập nhật thông tin đăng nhập (Login) với mật khẩu mới
    EXEC('ALTER LOGIN [' + @UserName + '] WITH PASSWORD = ''' + @Password + '''');
    
    -- Cập nhật thông tin User trong database để liên kết với Login
    EXEC('ALTER USER [' + @UserName + '] FOR LOGIN [' + @UserName + ']');

    -- Phân quyền lại cho User dựa trên Role mới
    IF @Role = 'Employee'
    BEGIN
        -- Nếu Role là Employee, xóa User khỏi Role manager (nếu có) và thêm vào Role employee
        EXEC('ALTER ROLE manager DROP MEMBER [' + @UserName + ']');
        EXEC('ALTER ROLE employee ADD MEMBER [' + @UserName + ']');
    END;
    ELSE IF @Role = 'Manager'
    BEGIN
        -- Nếu Role là Manager, xóa User khỏi Role employee (nếu có) và thêm vào Role manager
        EXEC('ALTER ROLE employee DROP MEMBER [' + @UserName + ']');
        EXEC('ALTER ROLE manager ADD MEMBER [' + @UserName + ']');
        
        -- Cấp quyền sysadmin cho Manager
        EXEC('ALTER SERVER ROLE sysadmin ADD MEMBER [' + @UserName + ']');
    END;
END;
GO