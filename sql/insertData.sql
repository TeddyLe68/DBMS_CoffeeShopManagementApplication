use CoffeeShopManagement
GO

INSERT INTO [CoffeeShopManagement].[dbo].[Account] 
    ([accountId], [employeeId], [username], [password], [role], [createdAt], [updatedAt], [isDeleted])
VALUES 
    (NEWID(), NULL, 'adminn', 'admin1234', 'Manager', GETDATE(), GETDATE(), 0);


DELETE FROM Account
WHERE accountId = 'b6d3be50-b0e1-4232-a28f-c6d3670d8828';

UPDATE Account
SET role = 'Manager', updatedAt = CURRENT_TIMESTAMP
WHERE accountId = '246189d0-8dec-4a28-94f9-e6af8dff6b45';



GRANT UPDATE ON Account TO [Admin User]
GO
SELECT HAS_PERMS_BY_NAME(DB_NAME(), 'DATABASE', 'UPDATE');

INSERT INTO Employee (fullName, phoneNumber, address, email, isWorking, joinedAt, updatedAt)
VALUES
	(N'Tất Thắng', '0933344455', N'2 Võ Văn Ngân, TP.HCM', 'thang@gmail.com', 1, CONVERT(DATE, '11/02/2024', 103), GETDATE());
GO
INSERT INTO Employee (fullName, phoneNumber, address, email, isWorking, joinedAt, updatedAt)
VALUES
	(N'Thành Hiếu', '0987654321', N'1 Võ Văn Ngân, TP.HCM', 'hieu@gmail.com', 1, CONVERT(DATE, GETDATE(), 103), GETDATE());
GO
INSERT INTO Employee (fullName, phoneNumber, address, email, isWorking, joinedAt, updatedAt)
VALUES
	(N'Phi Tường', '0988877766', N'3 Võ Văn Ngân, TP.HCM', 'tuong@gmail.com', 0, CONVERT(DATE, '30/11/2023', 103), GETDATE());
GO
INSERT INTO Employee (fullName, phoneNumber, address, email, isWorking, joinedAt, updatedAt)
VALUES
	(N'Minh Đức', '0933355577', N'4 Võ Văn Ngân, TP.HCM', 'duc@gmail.com', 0, CONVERT(DATE, '12/09/2023', 103), GETDATE());
GO

INSERT INTO Customer (customerName, phoneNumber, createdAt, updatedAt)
VALUES 
    (N'Trúc Nga', '123456789', GETDATE(), GETDATE()),
    (N'Thanh Tuấn', '987654321', GETDATE(), GETDATE()),
	(N'Ngọc Mai', '089876656', GETDATE(), GETDATE()),
    (N'Cao Kha', '09083636', GETDATE(), GETDATE()),
	(N'Trúc Nga', '098878767', GETDATE(), GETDATE()),
    (N'Điệp Khúc', '096126322', GETDATE(), GETDATE()),
    (N'Hiệp', '555123456', GETDATE(), GETDATE());

GO
INSERT INTO Product (productName, productSize, productPrice, createdAt, updatedAt)
VALUES 
    (N'Cà phê đen', N'Nhỏ', 20.000, GETDATE(), GETDATE()),
    (N'Cà phê đen', N'Vừa', 25.000, GETDATE(), GETDATE()),
    (N'Cà phê sữa', N'Nhỏ', 25.000, GETDATE(), GETDATE()),
    (N'Cà phê sữa', N'Vừa', 30.000, GETDATE(), GETDATE()),
    (N'Bạc Sĩu', N'Nhỏ', 25.000, GETDATE(), GETDATE()),
    (N'Bạc Sĩu', N'Vừa', 30.000, GETDATE(), GETDATE()),
	(N'Sinh tố Bơ', N'Vừa', 35.000, GETDATE(), GETDATE()),
    (N'Sinh tố Bơ', N'Lớn', 40.000, GETDATE(), GETDATE()),
	(N'Sinh tố Dâu', N'Vừa', 35.000, GETDATE(), GETDATE()),
    (N'Sinh tố Dâu', N'Lớn', 40.000, GETDATE(), GETDATE());
GO

-- Chạy từng câu và sửa employeeeId, customerId, billId lại
INSERT INTO OrderBill (rewardPointsUsed, createdAt, employeeId, customerId)
VALUES (25.000 , GETDATE(), 'CE8198DA-05EC-46A9-A3F8-E5E64ECE8864', '1E155C77-BD6E-4B65-B030-0ACE23F14887'),
		(0, GETDATE(), 'CE8198DA-05EC-46A9-A3F8-E5E64ECE8864', '1E155C77-BD6E-4B65-B030-0ACE23F14887'),
		(0, GETDATE(), 'CE8198DA-05EC-46A9-A3F8-E5E64ECE8864', '1E155C77-BD6E-4B65-B030-0ACE23F14887');
GO
INSERT INTO OrderBillDetails (billId, productId, quantity)
VALUES ('6FDD5347-7377-4A0E-BD3A-12D1DC009B4D', '1A19CC39-53BC-4006-AE8C-294E43D2BD12', 2),
		('6FDD5347-7377-4A0E-BD3A-12D1DC009B4D', '5CC62243-38A7-43C6-BF20-67293635503D', 2);

GO
INSERT INTO OrderBillDetails (billId, productId, quantity)
VALUES ('9847D318-FDD5-4772-8133-AD688C4A6D87', '8CF7DCE7-DE32-4619-9642-71F1C47FA42F', 2),
		('9847D318-FDD5-4772-8133-AD688C4A6D87', 'DF8FA6FF-741D-4006-BD6D-7EFCC9231BCB', 1),
		('9847D318-FDD5-4772-8133-AD688C4A6D87', '19F4909C-95C6-45F5-9239-84D60B9BF570', 3),
		('9847D318-FDD5-4772-8133-AD688C4A6D87', 'E6B176FE-622F-431F-9512-9C3092A43DC6', 2);

GO
INSERT INTO OrderBillDetails (billid, productId, quantity)
VALUES ('FACAF814-15AC-460E-957B-EEDAAF11C3DC', 'DEC1F5A1-DBE6-467A-9C28-A6B8CAA7597F', 3);
