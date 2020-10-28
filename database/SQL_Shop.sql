CREATE DATABASE QL_Shop

USE QL_Shop
GO

--- TẠO BẢNG ---
CREATE TABLE CATEGORY
(
	CateID INT IDENTITY PRIMARY KEY,
	CateName NVARCHAR(50),
	Images VARCHAR(50)
)
CREATE TABLE STORE
(
	StoreID INT IDENTITY PRIMARY KEY,
	Location NVARCHAR(MAX),
	Phone CHAR(10),
	City NVARCHAR(50),
	Images VARCHAR(50)
)
CREATE TABLE MEMBERSHIP
(
	MemID CHAR(10) PRIMARY KEY,
	MemName NVARCHAR(50),
	MinPrice INT,
	MaxPrice INT,
	Sale INT DEFAULT 0
)
CREATE TABLE CUSTOMER
(
	CustomID INT IDENTITY PRIMARY KEY,
	CustomName NVARCHAR(100),
	Phone CHAR(10),
	Email VARCHAR(50),
	Location NVARCHAR(MAX),
	Pass VARCHAR(50),
	Statu BIT DEFAULT 1,--1 là đang hoạt động, 0 là bị chặn
	TotalPrice INT DEFAULT 0,
	MemID CHAR(10) FOREIGN KEY (MemID) REFERENCES MEMBERSHIP(MemID)
)
CREATE TABLE VOUCHER
(
	VoucherID CHAR(15) PRIMARY KEY,
	Title NVARCHAR(MAX),
	Sale INT,
	EndDate DATE,
	Images VARCHAR(50)
)
CREATE TABLE ROLES
(
	RoleID INT IDENTITY PRIMARY KEY,
	RoleName VARCHAR(30)
)
CREATE TABLE PRODUCT
(
	ProductID INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(100),
	Price INT,
	Quantity INT,
	Images VARCHAR(50),
	Statu BIT DEFAULT 1, -- 0 là hết bán, 1 là đang bán
	CategoryID INT FOREIGN KEY (ProductID) REFERENCES PRODUCT(ProductID)
)
CREATE TABLE GROUPADMIN
(
	GroupID CHAR(10) PRIMARY KEY,
	GroupName NVARCHAR(50) 
)
CREATE TABLE EMPLOYEE
(
	EmployID INT IDENTITY PRIMARY KEY,
	EmployName VARCHAR(MAX),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Pass CHAR(50),
	Statu BIT DEFAULT 1,--1 đang làm việc, 0 đã nghỉ việc
	GroupID CHAR(10) FOREIGN KEY (GroupID) REFERENCES GROUPADMIN(GroupID)
)
CREATE TABLE NEWS
(
	NewsID INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(100),
	Images VARCHAR(50),
	Descrip NVARCHAR(MAX),
	PublishDate DATE DEFAULT GETDATE()
)
CREATE TABLE BILL
(
	BillID INT IDENTITY PRIMARY KEY,
	PublishDate DATE DEFAULT GETDATE(),
	ToTalPrice INT,
	CustomID INT FOREIGN KEY (CustomID) REFERENCES CUSTOMER(CustomID),
	EmployID INT FOREIGN KEY (EmployID) REFERENCES EMPLOYEE(EmployID),
	DeliveryDate DATE,
	Sale INT DEFAULT 0,
	VoucherID CHAR(15) FOREIGN KEY (VoucherID) REFERENCES VOUCHER(VoucherID)
)
CREATE TABLE BILLINFO
(
	BillID INT FOREIGN KEY (BillID) REFERENCES BILL(BillID),
	ProductID INT FOREIGN KEY (ProductID) REFERENCES PRODUCT(ProductID),
	Quantity INT DEFAULT 1,
	Price INT,
	PRIMARY KEY(BillID, ProductID)
)
CREATE TABLE PERMISION
(
	RoleID INT FOREIGN KEY (RoleID) REFERENCES ROLES(RoleID),
	GroupID CHAR(10) FOREIGN KEY (GroupID) REFERENCES GROUPADMIN(GroupID),
	PerID BIT DEFAULT 0, -- 1 là có quyền, 0 là không có quyền
	PRIMARY KEY (RoleID, GroupID)
)

--- NHẬP LIỆU ---

-- MEMBERSHIP
INSERT INTO MEMBERSHIP(MemID,MemName,MinPrice,MaxPrice,Sale) VALUES ('MB01','Copper',0,4999999,0)
INSERT INTO MEMBERSHIP(MemID,MemName,MinPrice,MaxPrice,Sale) VALUES ('MB02','Silver',5000000,9999999,5)
INSERT INTO MEMBERSHIP(MemID,MemName,MinPrice,MaxPrice,Sale) VALUES ('MB03','Golden',10000000,19999999,10)
INSERT INTO MEMBERSHIP(MemID,MemName,MinPrice,MaxPrice,Sale) VALUES ('MB04','Plantinum',20000000,49999999,15)
INSERT INTO MEMBERSHIP(MemID,MemName,MinPrice,MaxPrice,Sale) VALUES ('MB05','Diamond',50000000,999999999,20)

-- STORE---
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'140 Lê Trọng Tấn','0911234568','HCM','hcm1.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'133 Ni Sư Huỳnh Liên','0911234568','HCM','hcm2.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'781 Lê Thúc Hoạch','0911234568','HCM','hcm3.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'817 Lạc Long Quân','0911234568','HCM','hcm4.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'140 Hàng Đẫy','0911234568','HN','hn1.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'133 Trần Duy Hưng','0911234568','HN','hn2.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'781 Chùa Bộc','0911234568','HN','hn3.jpg')
INSERT INTO STORE(Location,Phone,City,Images) VALUES (N'817 Thái Hà','0911234568','HN','hn4.jpg')

-- ROLES
INSERT INTO ROLES(RoleName) VALUES('CATEGORY')--1
INSERT INTO ROLES(RoleName) VALUES('STORE')
INSERT INTO ROLES(RoleName) VALUES('MEMBERSHIP')--3
INSERT INTO ROLES(RoleName) VALUES('CUSTOMER')
INSERT INTO ROLES(RoleName) VALUES('VOUCHER')--5
INSERT INTO ROLES(RoleName) VALUES('ROLES')
INSERT INTO ROLES(RoleName) VALUES('PRODUCT')--7
INSERT INTO ROLES(RoleName) VALUES('EMPLOYEE')
INSERT INTO ROLES(RoleName) VALUES('GROUPADMIN')--9
INSERT INTO ROLES(RoleName) VALUES('BILL')
INSERT INTO ROLES(RoleName) VALUES('NEWS')--11
INSERT INTO ROLES(RoleName) VALUES('BILLINFO')
INSERT INTO ROLES(RoleName) VALUES('PERMISION')--13

-- CATEGORY
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Gấu bông và túi','btnTuiQua.png')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Trang điểm','btnSacDep.png')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Du lịch','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Đồ chơi','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Trang trí','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Văn phòng phẩm','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Đồ gia dụng','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Túi ví','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Điện tử & điện thoại','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Phụ kiện thời trang','')
INSERT INTO CATEGORY(CateName,Images) VALUES(N'Hoa sáp','btnHoaSap.png')

-- GROUP ADMIN
INSERT INTO GROUPADMIN(GroupID, GroupName) VALUES('SALE',N'Nhân viên bán hàng')
INSERT INTO GROUPADMIN(GroupID, GroupName) VALUES('MANA',N'Quản lý')
INSERT INTO GROUPADMIN(GroupID, GroupName) VALUES('CEO',N'Giám đốc')
INSERT INTO GROUPADMIN(GroupID, GroupName) VALUES('SRTR',N'Thư kí')
INSERT INTO GROUPADMIN(GroupID, GroupName) VALUES('HR',N'Nhân sự')

-- PRODUCT 
INSERT INTO PRODUCT(ProductName, Price,Quantity,Images,Statu,CategoryID) VALUES
(N'Gấu bông chó Shiba cute',120000,50,'gau1.jpg',1,1),
(N'Gấu bông vịt trắng 40cm',110000,60,'gau2.jpg',1,1),
(N'Gấu bông khủng long xanh lè',150000,70,'gau3.jpg',1,1),
(N'Gấu bông ba chú gấu nằm đè lên nhau',140000,80,'gau4.jpg',1,1),
(N'Gấu bông cá sấu nằm xanh lè',130000,90,'gau5.jpg',1,1),
(N'Gấu bông heo hồng siêu cute',120000,70,'gau6.jpg',1,1),
(N'Gấu bông Stitch và bạn gái',140000,50,'gau7.jpg',1,1),
(N'Gối ôm dài thòn xanh lè',140000,60,'gau8.jpg',1,1),
(N'Sổ tay ghi chép từ vựng anh văn',40000,50,'so1.jpg',1,6),
(N'Sổ tay ghi kế hoạch đủ màu',50000,60,'so2.jpg',1,6),
(N'Sổ vở chó Shiba đáng yêu',60000,40,'so3.jpg',1,6),
(N'Sổ tay khủng long xanh đủ màu',30000,50,'so4.jpg',1,6),
(N'Sổ vở học tập màu hồng bling bling',40000,30,'so5.jpg',1,6),
(N'Sổ tay hình máy game xanh chuối',70000,50,'so6.jpg',1,6)

-- PERMISION
INSERT INTO PERMISION (GroupID, RoleID,PerID) VALUES('SALE',1,0)
INSERT INTO PERMISION (GroupID, RoleID,PerID) VALUES('SALE',2,0)
INSERT INTO PERMISION (GroupID, RoleID,PerID) VALUES('SALE',3,0)
INSERT INTO PERMISION (GroupID, RoleID,PerID) VALUES('SALE',4,1)
INSERT INTO PERMISION (GroupID, RoleID,PerID) VALUES('SALE',10,1)
INSERT INTO PERMISION (GroupID, RoleID,PerID) VALUES('SALE',12,1)

-- EMPLOYEE
INSERT INTO EMPLOYEE(EmployName,FirstName,LastName,Pass,Statu,GroupID) VALUES
('hai.bui',N'Hải',N'Bùi','123',1,'SALE'),
('uyen.nguyen',N'Uyên',N'Nguyễn','123',1,'MANA'),
('toan.le',N'Toàn',N'Lê','123',1,'SRTR')

-- VOUCHER
SET DATEFORMAT DMY
INSERT INTO VOUCHER(VoucherID,Title,Images,Sale,EndDate) VALUES
('HAPPYWOMAN',N'Chào mừng ngày 20-10','baner1.jpg',3,'20-10-2020'),
('WOMAN0803',N'Chào mừng ngày 08-03','',3,'08-03-2021')

-- CUSTOMER
INSERT INTO CUSTOMER(CustomName,Phone,Email,Location,Pass,Statu,TotalPrice) VALUES
(N'Nguyễn Xuân Nghi','0917320031','xuannghi@gmail.com',N'307 Nguyễn Văn Trỗi','123',1,0)

--- TRIGGER ---
-- Cập nhật lại tổng tiền khách hàng khi có hóa đơn mới
GO
CREATE TRIGGER CapNhat_TheKhachHang ON BILL
FOR UPDATE,INSERT
AS
	BEGIN
		UPDATE CUSTOMER
		SET TotalPrice = CUSTOMER.TotalPrice+ (SELECT TotalPrice FROM inserted WHERE CustomID=CUSTOMER.CustomID)
	END;

-- Cập nhật lại số lượng sản phẩm khi có đơn đặt hàng
GO
CREATE TRIGGER CapNhat_SoLuongSP ON BILLINFO
FOR INSERT 
AS
	BEGIN
		UPDATE PRODUCT
		SET Quantity=PRODUCT.Quantity-(SELECT Quantity FROM INSERTED WHERE ProductID=PRODUCT.ProductID)
		FROM PRODUCT
		JOIN inserted ON PRODUCT.ProductID=inserted.ProductID
	END;

-- Cập nhật tổng tiền hóa đơn khi thêm, xóa, sửa chi tiết hóa đơn
GO
CREATE TRIGGER CapNhat_TongTienHoaDon ON BILLINFO
FOR INSERT, UPDATE
AS
	BEGIN
	UPDATE BILL SET ToTalPrice =(Select SUM(Quantity* Price) *(1-Sale/100.0) From BILLINFO
						WHERE ProductID=(Select ProductID From inserted))
				 Where BillID=(Select BillID From inserted)
	UPDATE BILL SET ToTalPrice =(Select SUM(Quantity* Price) *(1-Sale/100.0) From BILLINFO
						WHERE BillID=(Select BillID From deleted))
				 Where BillID=(Select BillID From deleted)
	END;

-- Cập nhật lại loại thẻ khách hàng khi thay đổi tổng tiền khách hàng
GO
CREATE TRIGGER CapNhat_TongTienKhachHang ON CUSTOMER
FOR INSERT, UPDATE
AS
	BEGIN
		UPDATE CUSTOMER SET MemID=(SELECT MEMBERSHIP.MemID FROM inserted, MEMBERSHIP WHERE MinPrice<=inserted.TotalPrice AND MaxPrice>=inserted.TotalPrice)
		
		FROM CUSTOMER
	END;

--- CÂU LỆNH ---
SELECT * FROM PRODUCT
SELECT * FROM MEMBERSHIP
SELECT * FROM STORE
SELECT * FROM CUSTOMER
SELECT * FROM VOUCHER
SELECT * FROM ROLES
SELECT * FROM CATEGORY
SELECT * FROM PERMISION
SELECT * FROM BILL
SELECT * FROM BILLINFO
SELECT * FROM GROUPADMIN
SELECT * FROM EMPLOYEE
SELECT * FROM NEWS
