USE CoffeeShopManagement
GO
-- 1. Function findEmployeeByName
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findEmployeeByNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findEmployeeByNameFunction
GO
CREATE FUNCTION findEmployeeByNameFunction 
( 
    @employeeName NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Employee WHERE fullName LIKE '%'+  @employeeName + '%'
);
GO
-- Xóa function nếu đã tồn tại
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findEmployeeByPhoneNumberFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findEmployeeByPhoneNumberFunction
GO

-- Tạo function mới để tìm nhân viên theo số điện thoại
CREATE FUNCTION findEmployeeByPhoneNumberFunction 
( 
    @phoneNumber VARCHAR(15)
)
RETURNS TABLE
AS
RETURN (
    SELECT employeeId, fullName, phoneNumber, address, email, isWorking, joinedAt, updatedAt,isDeleted -- Cần liệt kê cột cụ thể
    FROM Employee 
    WHERE phoneNumber LIKE '%' + @phoneNumber + '%'
);
GO


-- 2. Function findOrderBillById
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findOrderBillByIdFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findOrderBillByIdFunction
GO
CREATE FUNCTION findOrderBillByIdFunction 
( 
    @orderBillId NVARCHAR(36)
)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM OrderBill WHERE CAST( billId as NVARCHAR(36)) like '%' + @orderBillId + '%'
);
GO

--Function findRestockBillById
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findRestockBillByIdFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findRestockBillByIdFunction
GO
CREATE FUNCTION findRestockBillByIdFunction 
( 
    @restockBillId NVARCHAR(36)
)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM RestockBill WHERE CAST( restockBillId as NVARCHAR(36)) like '%' + @restockBillId + '%'
);
GO

-- 3. Function findCustomerByPhoneNumber
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findCustomerByPhoneNumberFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findCustomerByPhoneNumberFunction
GO

CREATE FUNCTION findCustomerByPhoneNumberFunction 
( 
    @PhoneNumber VARCHAR(15)
)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Customer WHERE phoneNumber = @PhoneNumber
);
GO

--new Customer Function
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findCustomerByNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findCustomerByNameFunction
GO

CREATE FUNCTION findCustomerByNameFunction
( 
    @CustomerName VARCHAR(15)
)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Customer WHERE customerName LIKE '%' + @CustomerName + '%'
);
GO
-- Function Find Account By User Name
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'findAccountByUserNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION findAccountByUserNameFunction
GO

CREATE FUNCTION findAccountByUserNameFunction 
( 
    @userName NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Account WHERE username LIKE '%' + @userName + '%' AND isDeleted = 0
);
GO

-- 4. Function findProductByName
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'FindProductByNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION FindProductByNameFunction
GO

CREATE FUNCTION FindProductByNameFunction
(
    @productName NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT productId, productName, productSize, productPrice, createdAt, updatedAt,isDeleted
    FROM Product
    WHERE productName LIKE '%' + @productName + '%' AND isDeleted = 0
);
GO

-- Function findListProductByName
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'FindProductViewByNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION FindProductViewByNameFunction
GO

CREATE FUNCTION FindProductViewByNameFunction
(
    @productName NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT productName, productId
    FROM ListProductView
    WHERE productName LIKE '%' + @productName + '%'
);

GO

-- 5. Function findInventoryByName
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'FindInventoryByNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION FindInventoryByNameFunction
GO
CREATE FUNCTION FindInventoryByNameFunction
(
    @inventoryName NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT inventoryId, name
    FROM Inventory
    WHERE name LIKE '%' + @inventoryName + '%'
);
GO
-- 6. Function findInventoryCheckByDate
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'FindInventoryCheckByDateFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION FindInventoryCheckByDateFunction
GO

CREATE FUNCTION FindInventoryCheckByDateFunction
(
    @checkDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT checkId, employeeId, inventoryId, checkDate
    FROM InventoryCheck
    WHERE CAST(checkDate AS DATE) = CAST(@checkDate AS DATE)
);
--6.1. Function findInventoryCheckByDateFromView
GO
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'FindInventoryCheckByDateFromViewFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION FindInventoryCheckByDateFromViewFunction
GO

CREATE FUNCTION FindInventoryCheckByDateFromViewFunction
(
    @checkDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT checkId, [check date], [inventory name], [employee name]
    FROM getInventoryCheckView
    WHERE CAST([check date] AS DATE) = CAST(@checkDate AS DATE)
);
GO
-- 7. Function findIngredientByName
GO
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'FindIngredientByNameFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION FindIngredientByNameFunction
GO

CREATE FUNCTION FindIngredientByNameFunction
(
    @ingredientName NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT ingredientId, ingredientName, manufacturerName, updatedAt
    FROM Ingredient
    WHERE isDeleted = 0 AND ingredientName LIKE '%' + @ingredientName + '%'
);
GO

-- 8. Function CalculateShopRevenueFunction
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'CalculateShopRevenueFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION CalculateShopRevenueFunction
GO

CREATE FUNCTION CalculateShopRevenueFunction
(
    @startDate DATE,
    @endDate DATE
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @revenue DECIMAL(10, 2)

    SET @revenue = (SELECT ISNULL(SUM(finalBill), 0)
    FROM OrderBill
    WHERE CONVERT(DATE, createdAt) BETWEEN @startDate AND @endDate)

    RETURN @revenue
END
GO

-- 9. Function CalculateRestockCostFunction
IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'CalculateRestockCostFunction') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
    DROP FUNCTION CalculateRestockCostFunction
GO

CREATE FUNCTION CalculateRestockCostFunction
(
    @startDate DATE,
    @endDate DATE
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @cost DECIMAL(10, 2)
    SET @cost = 0

    SET @cost = (SELECT ISNULL(SUM(finalBill), 0)
    FROM OrderBill
    WHERE CONVERT(DATE, createdAt) BETWEEN @startDate AND @endDate)

    RETURN @cost
END