create database PharmacyMgtSys
go

use PharmacyMgtSys
go

Create table EMPLOYEE
(
	EmployeeID varchar(5),
	EmployeeName nvarchar(200) not null,
	Sex char(1) default 'F' check(Sex in('M','F')),
	Contact varchar(10),
	Birthday date,
	EmployeeAddress nvarchar(200),
	primary key (EmployeeID)
)
Go

Create table CATEGORIES
(
	CategoryID tinyint identity(1,1) primary key,
	CategoryName nvarchar(50) not null unique
)
Go

Create table COMMODITY
(
	CommodityID varchar(5) check (CommodityID like 'MD[0-9][0-9][0-9]' or CommodityID like 'IN[0-9][0-9][0-9]'),
	CommodityName nvarchar(200) not null unique,
	Manufacturer nvarchar(200) not null,
	Quantity int default 0,
	BaseUnit nvarchar(30) not null,
	PurchasePrice money default 0,
	SellingPrice money default 0,
	MfgDate date,
	ExpDate date,
	CategoryID tinyint,
	primary key (CommodityID),
	foreign key (CategoryID) references CATEGORIES(CategoryID)
)
Go
/*insert into Commodity values()

go*/


Create table ACCOUNT
(
	AccountID tinyint identity(1,1),
	Username varchar(50) not null unique,
	UserPassword varchar(50) not null,
	UserRole varchar(5) default 'user' check(UserRole in('user','admin', 'guest')),
	EmployeeID varchar(5),
	primary key (AccountID),
	foreign key (EmployeeID) references EMPLOYEE(EmployeeID)
)
Go

Create table CUSTOMER
(
	CustomerID varchar(5),
	CustomerName nvarchar(200) not null,
	Sex char(1) default 'F' check(Sex in('M','F')),
	Contact varchar(10),
	Birthday date,
	CustomerAddress nvarchar(200),
	primary key (CustomerID)
)
Go

Create table INVOICE
(
	InvoiceID varchar(5),
	CreatedDate Datetime not null,
	Note nvarchar(200),
	EmployeeID varchar(5),
	CustomerID varchar(5),
	primary key (InvoiceID),
	foreign key (EmployeeID) references EMPLOYEE(EmployeeID),
	foreign key (CustomerID) references CUSTOMER(CustomerID)
)
Go

Create table INVOICEDETAILS
(
	Quantity int default 0,
	UnitPrice Money default 0,
	Amount Money default 0,
	InvoiceID varchar(5),
	CommodityID varchar(5),
	primary key (InvoiceID, CommodityID),
	foreign key (InvoiceID) references INVOICE(InvoiceID),
	foreign key (CommodityID) references COMMODITY(CommodityID)
)
Go

-- Insert data to Employee
INSERT INTO EMPLOYEE (EmployeeID, EmployeeName, Sex, Contact, Birthday, EmployeeAddress)
VALUES 
('E001', N'Nguyễn Văn An', 'M', '0912345678', '1985-05-20', N'123 Đường Láng, Hà Nội'),
('E002', N'Lê Thị Hồng', 'F', '0918765432', '1990-08-15', N'456 Cầu Giấy, Hà Nội'),
('E003', N'Trần Quang Minh', 'M', '0987654321', '1988-12-10', N'789 Tôn Đức Thắng, TP.HCM'),
('E004', N'Phạm Thu Hà', 'F', '0934567890', '1992-03-22', N'123 Nguyễn Văn Cừ, Đà Nẵng'),
('E005', N'Hoàng Thị Lan', 'F', '0976543210', '1995-07-07', N'12 Lý Thường Kiệt, Huế'),
('E006', N'Ngô Văn Hải', 'M', '0911122233', '1987-11-11', N'45 Trần Hưng Đạo, Hà Nội'),
('E007', N'Bùi Thị Hoa', 'F', '0945566778', '1993-06-25', N'78 Nguyễn Huệ, TP.HCM'),
('E008', N'Lý Văn Tùng', 'M', '0923344556', '1984-09-30', N'23 Đinh Tiên Hoàng, Đà Nẵng'),
('E009', N'Phan Thị Kim', 'F', '0912345689', '1991-04-18', N'90 Lê Duẩn, Hà Nội'),
('E010', N'Doãn Thanh Bình', 'M', '0931122334', '1986-02-14', N'50 Hai Bà Trưng, Hải Phòng'),
('E011', N'Lương Thị Hạnh', 'F', '0978899001', '1994-12-24', N'15 Phan Đình Phùng, Huế'),
('E012', N'Phùng Văn Khánh', 'M', '0903344556', '1983-07-19', N'72 Võ Thị Sáu, TP.HCM'),
('E013', N'Vũ Thị Mai', 'F', '0934455667', '1990-05-05', N'68 Điện Biên Phủ, Hà Nội'),
('E014', N'Đinh Công Thắng', 'M', '0988877665', '1989-08-09', N'99 Nguyễn Trãi, Đà Nẵng'),
('E015', N'Phạm Thị Thu', 'F', '0922233445', '1992-10-30', N'25 Trường Chinh, Huế'),
('E016', N'Tô Văn Hoàng', 'M', '0912233445', '1981-03-03', N'10 Lê Lợi, TP.HCM'),
('E017', N'Trịnh Thị Ngọc', 'F', '0944455667', '1996-01-17', N'85 Nguyễn Văn Trỗi, Đà Nẵng'),
('E018', N'Hoàng Minh Đức', 'M', '0905566778', '1985-11-22', N'37 Hùng Vương, Hà Nội'),
('E019', N'Lê Thị Thanh', 'F', '0928899001', '1993-09-09', N'12 Bà Triệu, Hải Phòng'),
('E020', N'Nguyễn Quang Huy', 'M', '0913344556', '1982-06-06', N'19 Phạm Văn Đồng, Hà Nội'),
('E021', N'Châu Thị Ngọc Loan', 'F', '0398451112', '2002-12-25', N'Châu Phú, An Giang'),
('E022', N'Nguyễn Thị Bích Quân', 'F', '0398154414', '2003-07-06', N'Phú Tân, An Giang');

-- Insert data to Account 
INSERT INTO ACCOUNT (Username, UserPassword, UserRole, EmployeeID)
VALUES
('nguyenvana', '12345', 'user', 'E001'),
('lethihong', '12345', 'user', 'E002'),
('tranquangminh', '12345', 'user', 'E003'),
('phamthuha', '12345', 'user', 'E004'),
('hoangthilan', '12345', 'admin', 'E005'),
('ngovanhai', '12345', 'user', 'E006'),
('buithihoa', '12345', 'user', 'E007'),
('lyvantung', '12345', 'user', 'E008'),
('phanthikim', '12345', 'user', 'E009'),
('doanthanhbinh', '12345', 'user', 'E010'),
('luongthihanh', '12345', 'user', 'E011'),
('phungvankhanh', '12345', 'user', 'E012'),
('vuthimai', '12345', 'user', 'E013'),
('dinhcongthang', '12345', 'user', 'E014'),
('phamthithu', '12345', 'user', 'E015'),
('tovanhoang', '12345', 'user', 'E016'),
('trinhthingoc', '12345', 'user', 'E017'),
('hoangminhduc', '12345', 'user', 'E018'),
('lethithanh', '12345', 'user', 'E019'),
('nguyenquanghuy', '12345', 'admin', 'E020'),
('ctnloan', '12345', 'admin', 'E021'),
('ngquan','12345','admin', 'E022');

-- Insert data to Customer
INSERT INTO CUSTOMER (CustomerID, CustomerName, Sex, Contact, Birthday, CustomerAddress)
VALUES
('C001', N'Trần Văn Hùng', 'M', '0901234567', '1980-01-15', N'12 Láng Hạ, Hà Nội'),
('C002', N'Lê Thị Nhàn', 'F', '0912345678', '1992-05-20', N'34 Kim Mã, Hà Nội'),
('C003', N'Phạm Ngọc Long', 'M', '0923456789', '1985-03-10', N'56 Nguyễn Huệ, TP.HCM'),
('C004', N'Nguyễn Thị Vân', 'F', '0934567890', '1990-12-25', N'78 Đà Nẵng, Đà Nẵng'),
('C005', N'Hồ Văn Phát', 'M', '0945678901', '1983-09-18', N'90 Lê Lợi, Huế'),
('C006', N'Đặng Thị Phượng', 'F', '0956789012', '1994-07-22', N'12 Trần Phú, Hải Phòng'),
('C007', N'Hoàng Minh Khoa', 'M', '0967890123', '1987-11-05', N'45 Điện Biên Phủ, TP.HCM'),
('C008', N'Lý Ngọc Hân', 'F', '0978901234', '1996-04-17', N'67 Lý Thường Kiệt, Hà Nội'),
('C009', N'Tô Văn Cường', 'M', '0989012345', '1982-02-11', N'89 Tôn Đức Thắng, Đà Nẵng'),
('C010', N'Vũ Thị Hằng', 'F', '0990123456', '1991-08-09', N'123 Hai Bà Trưng, Huế'),
('C011', N'Trần Thanh Bình', 'M', '0902233445', '1984-06-30', N'34 Lý Tự Trọng, Hà Nội'),
('C012', N'Nguyễn Ngọc Bích', 'F', '0913344556', '1993-03-15', N'67 Phạm Ngũ Lão, TP.HCM'),
('C013', N'Phan Văn Tùng', 'M', '0924455667', '1986-07-10', N'23 Võ Văn Kiệt, Đà Nẵng'),
('C014', N'Lê Thị Mai', 'F', '0935566778', '1992-01-25', N'56 Nguyễn Chí Thanh, Huế'),
('C015', N'Hồ Minh Đức', 'M', '0946677889', '1988-10-20', N'89 Trần Quý Cáp, Hải Phòng'),
('C016', N'Vương Thị Thu', 'F', '0957788990', '1990-12-05', N'45 Ngô Quyền, Hà Nội'),
('C017', N'Trịnh Minh Phúc', 'M', '0968899001', '1981-04-12', N'123 Hùng Vương, TP.HCM'),
('C018', N'Ngô Thị Hòa', 'F', '0979900112', '1995-09-18', N'67 Nguyễn Thị Minh Khai, Đà Nẵng'),
('C019', N'Lý Văn Hiếu', 'M', '0980011223', '1987-03-22', N'23 Trường Sa, Huế'),
('C020', N'Phạm Thị Hồng', 'F', '0991122334', '1994-11-11', N'78 Hoàng Diệu, Hải Phòng');


-- Insert data to Categories
INSERT INTO CATEGORIES (CategoryName)
VALUES
(N'Thuốc'),
(N'Thiết bị y tế')

-- Insert data to commodity

INSERT INTO COMMODITY (CommodityID, CommodityName, Manufacturer, Quantity, BaseUnit, PurchasePrice, SellingPrice, MfgDate, ExpDate, CategoryID) VALUES
('MD001', N'Augclamox 250', N'Công ty cổ phần dược phẩm Hà Tây', 50, N'Hộp 10 gói x 1,5g', 45000, 48000, '2023-07-15', '2025-07-15', 1),
('MD002', N'Casoran', N'Công ty cổ phần công nghệ cao Traphaco', 30, N'Hộp 10 gói x 1,5g', 50000, 55000, '2023-06-10', '2025-06-10', 1),
('MD003', N'Docetaxel 20mg', N'Teva Pharmaceutical Works Private Limited Company', 20, N'Hộp 10 gói x 1,5g', 60000, 65000, '2023-05-05', '2025-05-05', 1),
('MD004', N'Hà thủ ô', N'Công ty cổ phần dược phẩm Hà Tây', 15, N'Hộp 10 gói x 1,5g', 30000, 35000, '2023-04-20', '2025-04-20', 1),
('MD005', N'1-AL', N'NFDC Limited', 25, N'Hộp 10 gói x 1,5g', 20000, 25000, '2023-03-15', '2025-03-15', 1),
('MD006', N'20% Fat Emulsion Injection', N'Guangdong Otsuka Pharmaceutical Co., Ltd.', 40, N'Hộp 10 gói x 1,5g', 15000, 20000, '2023-02-10', '2025-02-10', 1),
('MD007', N'3B-Medi', N'Công ty cổ phần dược phẩm Me Di Sun', 60, N'Hộp 10 gói x 1,5g', 12000, 15000, '2023-01-05', '2025-01-05', 1),
('MD008', N'3B-Medi tab', N'Công ty cổ phần dược phẩm Me Di Sun', 70, N'Hộp 10 gói x 1,5g', 11000, 14000, '2022-12-01', '2024-12-01', 1),
('MD009', N'3BTP', N'Công ty cổ phần dược phẩm Hà Tây', 80, N'Hộp 10 gói x 1,5g', 13000, 16000, '2022-11-15', '2024-11-15', 1),
('MD010', N'3Bpluzs F', N'Công ty cổ phần Dược phẩm Phương Đông', 90, N'Hộp 10 gói x 1,5g', 14000, 17000, '2022-10-10', '2024-10-10', 1),
('MD011', N'3Bvit ando', N'Công ty cổ phần dược phẩm Hà Tây', 100, N'Hộp 10 gói x 1,5g', 15000, 18000, '2022-09-05', '2024-09-05', 1),
('MD012', N'4-Epeedo-50', N'Naprod Life Sciences Pvt. Ltd.', 110, N'Hộp 10 gói x 1,5g', 16000, 19000, '2022-08-01', '2024-08-01', 1),
('MD013', N'4.2% w/v Sodium Bicarbonate', N'B.Braun Melsungen AG', 120, N'Hộp 10 gói x 1,5g', 17000, 20000, '2022-07-15', '2024-07-15', 1),
('MD014', N'5% Dextrose 500ml inj Infusion', N'Dai Han Pharm. Co., Ltd.', 130, N'Hộp 10 gói x 1,5g', 18000, 21000, '2022-06-10', '2024-06-10', 1),
('MD015', N'5-Fluorouracil "Ebewe"', N'Ebewe Pharma Ges.m.b.H.Nfg.KG', 140, N'Hộp 10 gói x 1,5g', 19000, 22000, '2022-05-05', '2024-05-05', 1),
('MD016', N'8 Horas', N'Laboratorio Elea S.A.C.I.F.yA', 150, N'Hộp 10 gói x 1,5g', 20000, 23000, '2022-04-01', '2024-04-01', 1),
('MD017', N'9PM', N'Cipla Ltd', 160, N'Hộp 10 gói x 1,5g', 21000, 24000, '2022-03-15', '2024-03-15', 1),
('MD018', N'A9 - Cerebrazel', N'Công ty cổ phần dược TW Mediplantex', 170, N'Hộp 10 gói x 1,5g', 22000, 25000, '2022-02-10', '2024-02-10', 1),
('MD019', N'ABAB 500mg', N'Công ty cổ phần dược phẩm IMEXPHARM', 180, N'Hộp 10 gói x 1,5g', 23000, 26000, '2022-01-05', '2024-01-05', 1),
('MD020', N'ACC 200 mg', N'Lindopharm GmbH', 190, N'Hộp 10 gói x 1,5g', 24000, 27000, '2021-12-01', '2023-12-01', 1),
('IN001', N'Băng y tế', N'Công ty TNHH Y tế ABC', 100, N'Hộp 10 cuộn', 5000, 6000, '2023-08-01', '2025-08-01', 2),
('IN002', N'Gạc y tế', N'Công ty TNHH Y tế XYZ', 150, N'Hộp 20 miếng', 3000, 4000, '2023-07-15', '2025-07-15', 2),
('IN003', N'Bông y tế', N'Công ty cổ phần dược phẩm DEF', 200, N'Hộp 100g', 2000, 2500, '2023-06-10', '2025-06-10', 2),
('IN004', N'Bộ kit cấp cứu', N'Công ty TNHH Y tế GHI', 50, N'Bộ', 150000, 160000, '2023-05-05', '2025-05-05', 2),
('IN005', N'Bộ kit chăm sóc vết thương', N'Công ty cổ phần dược phẩm JKL', 75, N'Bộ', 120000, 130000, '2023-04-20', '2025-04-20', 2),
('IN006', N'Chất thử nhóm máu', N'Công ty TNHH MNO', 80, N'Hộp 50 test', 10000, 12000, '2023-03-15', '2025-03-15', 2),
('IN007', N'Dung dịch muối', N'Công ty cổ phần dược phẩm PQR', 90, N'Hộp 500ml', 8000, 9000, '2023-02-10', '2025-02-10', 2),
('IN008', N'Miếng dán sát khuẩn', N'Công ty TNHH STU', 110, N'Hộp 10 miếng', 7000, 8000, '2023-01-05', '2025-01-05', 2),
('IN009', N'Miếng dán hạ sốt', N'Công ty cổ phần dược phẩm VWX', 130, N'Hộp 5 miếng', 12000, 14000, '2022-12-01', '2024-12-01', 2);

-- Insert data into INVOICE
INSERT INTO INVOICE (InvoiceID, CreatedDate, Note, EmployeeID, CustomerID)
VALUES
('I001', '2023-08-01', N'Hóa đơn bán thuốc', 'E001', 'C001'),
('I002', '2023-08-02', N'Hóa đơn bán thiết bị y tế', 'E002', 'C002'),
('I003', '2023-08-03', N'Hóa đơn bán thuốc', 'E003', 'C003'),
('I004', '2023-08-04', N'Hóa đơn bán thuốc', 'E004', 'C004'),
('I005', '2023-08-05', N'Hóa đơn bán thiết bị y tế', 'E005', 'C005'),
('I006', '2023-08-06', N'Hóa đơn bán thuốc', 'E006', 'C006'),
('I007', '2023-08-07', N'Hóa đơn bán thiết bị y tế', 'E007', 'C007'),
('I008', '2023-08-08', N'Hóa đơn bán thuốc', 'E008', 'C008'),
('I009', '2023-08-09', N'Hóa đơn bán thuốc', 'E009', 'C009'),
('I010', '2023-08-10', N'Hóa đơn bán thiết bị y tế', 'E010', 'C010');

-- Insert data into INVOICEDETAILS
INSERT INTO INVOICEDETAILS (InvoiceID, CommodityID, Quantity, UnitPrice, Amount)
VALUES
('I001', 'MD001', 2, 48000, 96000),
('I002', 'MD002', 1, 55000, 55000),
('I003', 'IN003', 4, 2500, 10000),
('I004', 'IN004', 1, 160000, 160000),
('I005', 'MD005', 3, 25000, 75000),
('I006', 'MD006', 1, 20000, 20000),
('I007', 'MD007', 4, 15000, 60000),
('I008', 'IN008', 6, 8000, 48000),
('I009', 'MD009', 1, 16000, 16000),
('I010', 'MD010', 3, 17000, 51000);
