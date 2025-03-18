USE CoffeeShopManagement
/* Procedure insert vào bảng Customer*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertCustomerProc')
DROP PROCEDURE InsertCustomerProc
GO
CREATE PROCEDURE InsertCustomerProc
    @customerName NVARCHAR(100),
    @phoneNumber VARCHAR(15)
AS
BEGIN
    INSERT INTO Customer (customerName, phoneNumber, createdAt, updatedAt)
    VALUES (@customerName, @phoneNumber, GETDATE(), GETDATE());
END;
/* Procedure update vào bảng Customer*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateCustomerProc')
DROP PROCEDURE UpdateCustomerProc
GO
CREATE PROCEDURE UpdateCustomerProc
    @customerId UNIQUEIDENTIFIER,
    @customerName NVARCHAR(100),
    @phoneNumber VARCHAR(15),
    @isDeleted BIT
AS
BEGIN
    UPDATE Customer
    SET customerName = @customerName,
        phoneNumber = @phoneNumber,
        updatedAt = GETDATE(),
		isDeleted = @isDeleted
    WHERE customerId = @customerId;
END;
/* Procedure delete vào bảng Customer*/
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteCustomerProc')
DROP PROCEDURE DeleteCustomerProc
GO

CREATE PROCEDURE DeleteCustomerProc
    @customerId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Customer
    WHERE customerId = @customerId;
END;
/* Procedure insert vào bảng Product*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertProductProc')
DROP PROCEDURE InsertProductProc
GO
CREATE PROCEDURE InsertProductProc
    @productName NVARCHAR(100),
    @productSize NVARCHAR(50),
    @productPrice DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Product (productName, productSize, productPrice, createdAt, updatedAt)
    VALUES (@productName, @productSize, @productPrice, GETDATE(), GETDATE());
END;
/* Procedure update vào bảng Product*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateProductProc')
DROP PROCEDURE UpdateProductProc
GO
CREATE PROCEDURE UpdateProductProc
    @productId UNIQUEIDENTIFIER,
    @productName NVARCHAR(100),
    @productSize NVARCHAR(50),
    @productPrice DECIMAL(10, 2),
    @isDeleted BIT
AS
BEGIN
    UPDATE Product
    SET productName = @productName,
        productSize = @productSize,
        productPrice = @productPrice,
        updatedAt = GETDATE(),
		isDeleted = @isDeleted
    WHERE productId = @productId;
END;
/* Procedure delete vào bảng Product*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteProductProc')
DROP PROCEDURE DeleteProductProc
GO
CREATE PROCEDURE DeleteProductProc
    @productId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Product
	WHERE productId = @productId;
END;
/* Procedure insert vào bảng InventoryCheck*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertInventoryCheckProc')
DROP PROCEDURE InsertInventoryCheckProc
GO
CREATE PROCEDURE InsertInventoryCheckProc
    @employeeId UNIQUEIDENTIFIER,
    @inventoryId UNIQUEIDENTIFIER,
    @checkDate DATE
AS
BEGIN
    INSERT INTO InventoryCheck (employeeId, inventoryId, checkDate)
    VALUES (@employeeId, @inventoryId, @checkDate);
END;
/* Procedure update vào bảng InventoryCheck*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateInventoryCheckProc')
DROP PROCEDURE UpdateInventoryCheckProc
GO
CREATE PROCEDURE UpdateInventoryCheckProc
    @checkId UNIQUEIDENTIFIER,
    @employeeId UNIQUEIDENTIFIER,
    @inventoryId UNIQUEIDENTIFIER,
    @checkDate DATE
AS
BEGIN
    UPDATE InventoryCheck
    SET employeeId = @employeeId,
        inventoryId = @inventoryId,
        checkDate = @checkDate
    WHERE checkId = @checkId;
END;
/* Procedure delete vào bảng InventoryCheck*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteInventoryCheckProc')
DROP PROCEDURE DeleteInventoryCheckProc
GO
CREATE PROCEDURE DeleteInventoryCheckProc
    @checkId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM InventoryCheck
    WHERE checkId = @checkId;
END;
/* Procedure insert vào bảng InventoryCheckDetails*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertInventoryCheckDetailsProc')
DROP PROCEDURE InsertInventoryCheckDetailsProc
GO
CREATE PROCEDURE InsertInventoryCheckDetailsProc
    @checkId UNIQUEIDENTIFIER,
    @ingredientId UNIQUEIDENTIFIER,
    @quantity INT
AS
BEGIN
    INSERT INTO InventoryCheckDetails (checkId, ingredientId, quantity)
    VALUES (@checkId, @ingredientId, @quantity);
END;
/* Procedure update vào bảng InventoryCheckDetails*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateInventoryCheckDetailsProc')
DROP PROCEDURE UpdateInventoryCheckDetailsProc
GO
CREATE PROCEDURE UpdateInventoryCheckDetailsProc
    @checkId UNIQUEIDENTIFIER,
    @ingredientId UNIQUEIDENTIFIER,
    @quantity INT
AS
BEGIN
    UPDATE InventoryCheckDetails
    SET quantity = @quantity
    WHERE checkId = @checkId AND ingredientId = @ingredientId;
END;
/* Procedure delete vào bảng InventoryCheckDetails*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteInventoryCheckDetailsProc')
DROP PROCEDURE DeleteInventoryCheckDetailsProc
GO
CREATE PROCEDURE DeleteInventoryCheckDetailsProc
    @checkId UNIQUEIDENTIFIER,
    @ingredientId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM InventoryCheckDetails
    WHERE checkId = @checkId AND ingredientId = @ingredientId;
END;