USE CoffeeShopManagement
GO
--PROCEDURES
--@UpdateType là dùng để định chức năng của Procedures
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddEmployeeProc')
DROP PROCEDURE AddEmployeeProc
GO
CREATE PROCEDURE AddEmployeeProc
    @FullName NVARCHAR(100),
    @PhoneNumber VARCHAR(15),
    @Address NVARCHAR(255),
    @Email VARCHAR(255),
    @IsWorking BIT
AS
BEGIN
    INSERT INTO Employee (fullName, phoneNumber, address, email, isWorking, joinedAt, updatedAt)
		VALUES (@FullName, @PhoneNumber, @Address, @Email, @IsWorking, GETDATE(), GETDATE());
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateEmployeeProc')
    DROP PROCEDURE UpdateEmployeeProc;
GO

CREATE PROCEDURE UpdateEmployeeProc
    @EmployeeId UNIQUEIDENTIFIER,
    @FullName NVARCHAR(100),
    @PhoneNumber VARCHAR(15),
    @Address NVARCHAR(255),
    @Email VARCHAR(255),
    @IsWorking BIT,
    @UpdateType VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON; -- Tránh lỗi khi chạy batch SQL

    IF @UpdateType = 'update'
    BEGIN
        UPDATE Employee
        SET FullName = @FullName,
            PhoneNumber = @PhoneNumber,
            Address = @Address,
            Email = @Email,
            isWorking = @IsWorking,
            updatedAt = GETDATE()
        WHERE employeeId = @EmployeeId;

        -- Nếu isWorking = 0, cập nhật bảng Account
        IF @IsWorking = 0
        BEGIN
            UPDATE Account
            SET isDeleted = 1,
                updatedAt = GETDATE()
            WHERE employeeId = @EmployeeId;
        END;
    END;
END;
GO



IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddAccountProc')
DROP PROCEDURE AddAccountProc
GO
CREATE PROCEDURE AddAccountProc
	@EmployeeId UNIQUEIDENTIFIER,
	@Passwords VarChar(255),
	@UserName VarChar(255),
	@Role VarChar(20)
AS
BEGIN
	INSERT INTO Account(username, password, updatedAt, createdAt, role, isDeleted) 
		VALUES (@UserName, @Passwords, GETDATE(), GETDATE(), @Role, 0);
END;
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateAccountProc')
DROP PROCEDURE UpdateAccountProc
GO
CREATE PROCEDURE UpdateAccountProc
	@AccountId UNIQUEIDENTIFIER,
	@EmployeeId UNIQUEIDENTIFIER,
	@Passwords VarChar(255),
	@UserName VarChar(255),
	@Role VarChar(20),
	@IsDeleted BIT
AS
BEGIN
	UPDATE Account
		SET password = @Passwords,
			updatedAt = GETDATE(),
			role = @Role,
			isDeleted = @IsDeleted
		WHERE accountId = @AccountId;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddOrderBillProc')
DROP PROCEDURE AddOrderBillProc
GO
CREATE PROCEDURE AddOrderBillProc
	@CustomerId UNIQUEIDENTIFIER,
    @EmployeeId UNIQUEIDENTIFIER,
	@RewardPointsUsed DECIMAL(10, 2)
AS
BEGIN
	INSERT INTO OrderBill (customerId, employeeId, rewardPointsUsed, createdAt, isDeleted)
		VALUES (@CustomerId, @EmployeeId, @RewardPointsUsed, GETDATE(), 0);
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateOrderBillProc')
DROP PROCEDURE UpdateOrderBillProc
GO
CREATE PROCEDURE UpdateOrderBillProc
    @CustomerId UNIQUEIDENTIFIER,
    @EmployeeId UNIQUEIDENTIFIER,
    @BillId UNIQUEIDENTIFIER,
    @RewardPointsUsed DECIMAL(10, 2),
    @UpdateType VARCHAR(20)
AS
BEGIN
	IF @UpdateType = 'update'
	BEGIN
	UPDATE OrderBill
	SET customerId = @CustomerId, 
		employeeId = @EmployeeId, 
		rewardPointsUsed = @RewardPointsUsed
	Where billId = @BillId;
	END;
	ELSE
	BEGIN
		UPDATE OrderBill
		set isDeleted = 1
		WHERE billId = @BillId;
	END;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddOrderBillDetailsProc')
DROP PROCEDURE AddOrderBillDetailsProc
GO
CREATE PROCEDURE AddOrderBillDetailsProc
	@BillId UNIQUEIDENTIFIER,
   	@ProductId UNIQUEIDENTIFIER,
    @Quantity INT
AS
BEGIN
	INSERT INTO OrderBillDetails (billId, productId, quantity)
	VALUES (@BillId, @ProductId, @Quantity);
END;

GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateOrderBillDetialsProc')
DROP PROCEDURE UpdateOrderBillDetialsProc
GO
CREATE PROCEDURE UpdateOrderBillDetialsProc
	@BillId UNIQUEIDENTIFIER,
	@ProductId UNIQUEIDENTIFIER,
	@Quantity INT,
	@UpdateType VARCHAR(20)
AS
BEGIN
	IF @UpdateType = 'update'
	BEGIN
		UPDATE OrderBillDetails
		set quantity = @quantity
		WHERE billId = @BillId and productId = @ProductId
	END;
	ELSE
	BEGIN
		DELETE FROM OrderBillDetails WHERE billId = @BillId and productId = @ProductId 
	END;
END;
GO
