use CoffeeShopManagement
GO
EXEC sp_helptext 'UpdateEmployeeProc'

SELECT name FROM sys.database_principals WHERE type = 'R';

go
Grant Select, Update, Insert on OrderBill to employee;
Grant Select, Update, Insert on OrderBillDetails to employee;
Grant Select, Update, Insert on RestockBill to employee;
Grant Select, Update, Insert on RestockBillDetails to employee;
Grant Select, Update, Insert on Customer to employee;
Grant Select on Inventory to employee;
Grant Select on Employee to employee;
Grant Select, Update, Insert on InventoryCheck to employee;
Grant Select, Update, Insert on InventoryCheckDetails to employee;
Grant Select on Product to employee;
Grant Select on Ingredient to employee;

Grant EXEC on AddOrderBillDetailsProc to employee;
Grant EXEC on AddOrderBillProc to employee;
Grant EXEC on InsertCustomerProc to employee;
Grant EXEC on InsertInventoryCheckProc to employee;
Grant EXEC on InsertInventoryCheckDetailsProc to employee;
Grant EXEC on InsertRestockBillProc to employee;
Grant EXEC on InsertRestockBillDetailsProc to employee;

Grant EXEC on UpdateCustomerProc to employee;
Grant EXEC on UpdateInventoryCheckDetailsProc to employee;
Grant EXEC on UpdateInventoryCheckProc to employee;
Grant EXEC on UpdateRestockBillDetailsProc to employee;
Grant EXEC on UpdateRestockBillProc to employee;

Grant EXEC on DeleteRestockBillDetailsProc to employee;
Grant EXEC on DeleteInventoryCheckDetailsProc to employee;

Grant select on dbo.findAccountByUserNameFunction to employee;
Grant select on dbo.findCustomerByNameFunction to employee;
Grant select on dbo.findCustomerByPhoneNumberFunction to employee;
Grant select on dbo.findEmployeeByNameFunction to employee;
Grant select on dbo.FindProductByNameFunction to employee;
Grant select on dbo.FindProductViewByNameFunction to employee;
Grant select on dbo.findRestockBillByIdFunction to employee;

GRANT select on GetOrderBillDetailsView  to employee;
GRANT select on GetRestockBillView   to employee;
GRANT select on GetInventoryCheckView   to employee;
GRANT select on GetInventoryCheckDetailsView  to employee;
GRANT select on ListProductView  to employee;


go
Grant Exec, Select, Delete, Update, Insert, Delete on database::CoffeeShopManagement to manager WITH GRANT OPTION;
Grant select on dbo.findAccountByUserNameFunction to manager WITH GRANT OPTION;
Grant select on dbo.findCustomerByNameFunction to manager WITH GRANT OPTION;
Grant select on dbo.findCustomerByPhoneNumberFunction to manager WITH GRANT OPTION;
Grant select on dbo.findEmployeeByNameFunction to manager WITH GRANT OPTION;
Grant select on dbo.FindProductByNameFunction to manager WITH GRANT OPTION;
Grant select on dbo.FindProductViewByNameFunction to manager WITH GRANT OPTION;
Grant select on dbo.findRestockBillByIdFunction to manager WITH GRANT OPTION;
Grant EXEC on dbo.CalculateRestockCostFunction to manager WITH GRANT OPTION;
Grant EXEC on dbo.CalculateShopRevenueFunction to manager WITH GRANT OPTION;