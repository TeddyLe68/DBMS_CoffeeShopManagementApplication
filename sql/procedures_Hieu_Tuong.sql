USE CoffeeShopManagement
/* Procedure insert vào bảng Ingredient*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertIngredientProc')
DROP PROCEDURE InsertIngredientProc
GO
CREATE PROCEDURE InsertIngredientProc
    @ingredientName NVARCHAR(100),
    @manufacturerName NVARCHAR(50)
AS
BEGIN
    INSERT INTO Ingredient (ingredientName, manufacturerName, updatedAt)
    VALUES (@ingredientName, @manufacturerName, GETDATE());
END;

--GO
--EXEC InsertIngredientProc N'Nguyên liệu 1', N'Trung Nguyên';
--Go
--select * from Ingredient

/* Procedure update vào bảng Ingredient*/
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateIngredientProc')
DROP PROCEDURE UpdateIngredientProc
GO
CREATE PROCEDURE UpdateIngredientProc
    @ingredientId UNIQUEIDENTIFIER,
    @ingredientName NVARCHAR(100),
    @manufacturerName NVARCHAR(50),
	@isDeleted BIT
AS
BEGIN
    UPDATE Ingredient
    SET ingredientName = @ingredientName,
        manufacturerName = @manufacturerName,
        updatedAt = GETDATE(),
		isDeleted = @isDeleted
    WHERE ingredientId = @ingredientId;
END;

GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteIngredientProc')
DROP PROCEDURE DeleteIngredientProc
GO
CREATE PROCEDURE DeleteIngredientProc
    @ingredientId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Ingredient
	WHERE ingredientId = @ingredientId;
END;

GO
--GO
--EXEC UpdateIngredientProc '5EE8A239-92ED-499F-9E69-9113FBA03A8A',N'Bột năng', N'Trung Nguyên', 0;
--Go
--select * from Ingredient

/* Procedure delete vào bảng Ingredient */

/* Procedure Insert vào bảng Inventory */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertInventoryProc')
DROP PROCEDURE InsertInventoryProc
GO
CREATE PROCEDURE InsertInventoryProc
    @name NVARCHAR(255)
AS
BEGIN
    INSERT INTO Inventory (name)
    VALUES (@name);
END;

--GO
--EXEC InsertInventoryProc N'Phòng 3A03';
-- select * from Inventory
/* Procedure Update vào bảng Inventory */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateInventoryProc')
DROP PROCEDURE UpdateInventoryProc
GO
CREATE PROCEDURE UpdateInventoryProc
    @inventoryId UNIQUEIDENTIFIER,
    @name NVARCHAR(255),
	@isDeleted BIT
AS
BEGIN
    UPDATE Inventory
    SET name = @name,
		isDeleted = @isDeleted
    WHERE inventoryId = @inventoryId;
END;
/* Procedure Delete vào bảng Inventory */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteInventoryProc')
DROP PROCEDURE DeleteInventoryProc
GO
CREATE PROCEDURE DeleteInventoryProc
    @inventoryId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Inventory
	WHERE inventoryId = @inventoryId;
END;
--GO
--EXEC UpdateInventoryProc 'D48642D8-D205-4A1A-ACEE-A934E6A5829F', 'Phòng 2B01';

/* Procedure Insert vào bảng RestockBill */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertRestockBillProc')
DROP PROCEDURE InsertRestockBillProc
GO
CREATE PROCEDURE InsertRestockBillProc
    @date DATE,
    @supplierName NVARCHAR(50)
AS
BEGIN
    INSERT INTO RestockBill (date, supplierName)
    VALUES (@date, @supplierName);
END;

--GO
--EXEC InsertRestockBillProc '2/28/2024', @supplierName = 'Bách Hóa Xanh', @totalBill = '100000.00';

/* Procedure Update vào bảng RestockBill */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateRestockBillProc')
DROP PROCEDURE UpdateRestockBillProc
GO
CREATE PROCEDURE UpdateRestockBillProc
    @restockBillId UNIQUEIDENTIFIER,
    @date DATE,
    @supplierName NVARCHAR(50)
AS
BEGIN
    UPDATE RestockBill
    SET date = @date,
        supplierName = @supplierName
    WHERE restockBillId = @restockBillId;
END;

--select * from RestockBill

--select * from Ingredient

--select * from  RestockBillDetails
--GO
--EXEC UpdateRestockBillProc 'DCEE2B02-6AA9-4F1C-8342-A87DADF34217', '2024-03-14', 'COOP', '200000.00';

/* Procedure Delete vào bảng RestockBill */

GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteRestockBillProc')
DROP PROCEDURE DeleteRestockBillProc
GO
CREATE PROCEDURE DeleteRestockBillProc
    @restockBillId UNIQUEIDENTIFIER
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION;
    
    -- Delete from RestockBillDetails where restockBillId matches
    DELETE FROM RestockBillDetails
    WHERE restockBillId = @restockBillId;
    
    -- Delete from RestockBill where restockBillId matches
    DELETE FROM RestockBill
    WHERE restockBillId = @restockBillId;
    
    -- Commit the transaction if everything goes well
    COMMIT TRANSACTION;
    
    -- Handle any errors that might occur during the transaction
    EXCEPTION:
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
END;

--EXEC DeleteRestockBillProc '9B17B37A-BC97-4236-A19B-E6AD5C9102B2';

/* Procedure Insert vào bảng RestockBillDetails */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertRestockBillDetailsProc')
DROP PROCEDURE InsertRestockBillDetailsProc
GO
CREATE PROCEDURE InsertRestockBillDetailsProc
	@ingredientId UNIQUEIDENTIFIER,
	@restockBillId UNIQUEIDENTIFIER,
    @quantity INT,
    @price DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO RestockBillDetails (ingredientId, restockBillId, quantity, price)
    VALUES (@ingredientId, @restockBillId, @quantity, @price);
END;

--EXEC InsertRestockBillDetailsProc '27AD7C35-3175-4E90-89D0-1A5E1BFC94E0', 'BB0C6C15-45CD-4FD1-BC1A-D786E09A7B4F', '2','25000.00'; 

/* Procedure Update vào bảng RestockBillDetails */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateRestockBillDetailsProc')
DROP PROCEDURE UpdateRestockBillDetailsProc
GO
CREATE PROCEDURE UpdateRestockBillDetailsProc
    @ingredientId UNIQUEIDENTIFIER,
    @restockBillId UNIQUEIDENTIFIER,
    @quantity INT,
    @price DECIMAL(10, 2)
AS
BEGIN
    UPDATE RestockBillDetails
    SET quantity = @quantity,
        price = @price
    WHERE ingredientId = @ingredientId
    AND restockBillId = @restockBillId;
END;

--EXEC UpdateRestockBillDetailsProc '441E3AC0-4AB2-4BEF-AF15-95FE84C44EE0', 'DCEE2B02-6AA9-4F1C-8342-A87DADF34217', '4','30000.00'; 

/* Procedure Delete vào bảng RestockBillDetails */
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteRestockBillDetailsProc')
DROP PROCEDURE DeleteRestockBillDetailsProc
GO
CREATE PROCEDURE DeleteRestockBillDetailsProc
    @ingredientId UNIQUEIDENTIFIER,
    @restockBillId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM RestockBillDetails
    WHERE ingredientId = @ingredientId
    AND restockBillId = @restockBillId;
END;

--EXEC DeleteRestockBillDetailsProc 'BB0C6C15-45CD-4FD1-BC1A-D786E09A7B4F', '27AD7C35-3175-4E90-89D0-1A5E1BFC94E0';


