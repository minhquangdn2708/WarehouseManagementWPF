-- Tạo cơ sở dữ liệu
CREATE DATABASE QuanLiKho;
USE QuanLiKho;

-- Tạo bảng Unit
CREATE TABLE Units (
    UnitId INT PRIMARY KEY IDENTITY(1,1),
    UnitName NVARCHAR(255) NOT NULL
);

-- Tạo bảng Supplier
CREATE TABLE Suppliers (
    SupplierId INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    ContractDate DATE
);

-- Tạo bảng Object
CREATE TABLE Objectss (
    ObjectId INT PRIMARY KEY IDENTITY(1,1),
    ObjectName NVARCHAR(255) NOT NULL,
    UnitId INT NOT NULL,
    SupplierId INT NOT NULL,
    FOREIGN KEY (UnitId) REFERENCES Units(UnitId),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
);


-- Tạo bảng InputInfo
CREATE TABLE InputInfos (
    InputInfoId INT PRIMARY KEY IDENTITY(1,1),
    ObjectId INT NOT NULL,
    Count INT NOT NULL,
    InputPrice INT NOT NULL,
    OutputPrice INT NOT NULL,
	InputDate DATE NOT NULL,
    Status NVARCHAR(50),
    FOREIGN KEY (ObjectId) REFERENCES Objectss(ObjectId)
);


-- Tạo bảng Customer
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone VARCHAR(50),
    Email VARCHAR(50),
    ContractDate DATE
);

-- Tạo bảng OutputInfo
CREATE TABLE OutputInfos (
    OutputInfoId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    ObjectId INT NOT NULL,
    InputInfoId INT NOT NULL,
    Count INT NOT NULL,
	OutputDate DATE NOT NULL,
    Status NVARCHAR(50),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (ObjectId) REFERENCES Objectss(ObjectId),
    FOREIGN KEY (InputInfoId) REFERENCES InputInfos(InputInfoId)
);


-----------------------------------------------
USE QuanLiKho;

-- Import dữ liệu mẫu cho bảng Units
INSERT INTO Units (UnitName) VALUES ('Kilo');
INSERT INTO Units (UnitName) VALUES ('Lít');
INSERT INTO Units (UnitName) VALUES ('Chai');
INSERT INTO Units (UnitName) VALUES ('Thùng');
INSERT INTO Units (UnitName) VALUES ('Lốc');
INSERT INTO Units (UnitName) VALUES ('Hộp');
INSERT INTO Units (UnitName) VALUES ('Cái');


-- Import dữ liệu mẫu cho bảng Suppliers
INSERT INTO Suppliers (SupplierName, Address, Phone, Email, ContractDate) VALUES
('VinaMilk', '123 Main St', '0123456789', 'vinamilkvn@gmail.com', '2022-01-15'),
('Coca Cola', '123 Main St', '0123456789', 'vinamilkvn@gmail.com', '2021-01-15'),
('Viet Thang', '123 Main St', '0123456789', 'thang@gmail.com', '2024-01-15'),
('Minh Quang', '456 Central Ave', '0987654321', 'quang@yahoo.com', '2023-02-20');

-- Import dữ liệu mẫu cho bảng Objectss
INSERT INTO Objectss (ObjectName, UnitId, SupplierId) VALUES
('Bim Bim', 4, 3),
('Sữa', 5, 1),
('Bánh đậu xanh', 6, 4),
('Bánh cốm', 6, 3),
('Bao rác', 5, 4),
('Ấm đun nước', 7, 1),
('Thịt gà đông lạnh', 1, 1);

-- Import dữ liệu mẫu cho bảng InputInfos
INSERT INTO InputInfos (ObjectId, Count, InputPrice, OutputPrice, InputDate, Status) VALUES
(1, 100, 5000, 7000, '2023-10-01', 'Available'),
(2, 200, 3000, 4500, '2023-10-05', 'Available'),
(3, 150, 2000, 3500, '2023-11-10', 'Available'),
(4, 120, 1000, 2000, '2023-11-15', 'Available'),
(5, 150, 2000, 3500, '2023-11-10', 'Available'),
(6, 50, 1000, 3500, '2023-11-10', 'Available'),
(7, 200, 500, 3500, '2023-11-10', 'Available');

-- Import dữ liệu mẫu cho bảng Customers
INSERT INTO Customers (CustomerName, Address, Phone, Email, ContractDate) VALUES
('Customer A', '789 South St', '0167891234', 'customerA@example.com', '2022-06-10'),
('Customer A1', '789 South St', '0167891234', 'customerA1@example.com', '2022-06-10'),
('Customer A2', '789 South St', '0167891234', 'customerA2@example.com', '2022-06-10'),
('Customer A3', '789 South St', '0167891234', 'customerA3@example.com', '2022-06-10'),
('Customer B', '321 North Ave', '0176543210', 'customerB@example.com', '2023-04-12');

-- Import dữ liệu mẫu cho bảng OutputInfos
INSERT INTO OutputInfos (CustomerId, ObjectId, InputInfoId, Count, OutputDate, Status) VALUES
(1, 1, 1, 50, '2023-11-12', 'Shipped'),
(2, 2, 2, 80, '2023-11-13', 'Shipped'),
(1, 3, 3, 30, '2023-11-14', 'Pending'),
(2, 4, 4, 60, '2023-11-15', 'Pending'),
(1, 1, 1, 40, '2024-01-15', 'Shipped'),
(2, 2, 2, 60, '2024-02-10', 'Pending'),
(3, 3, 3, 50, '2024-03-05', 'Shipped'),
(4, 4, 4, 30, '2024-04-20', 'Pending'),
(5, 5, 5, 70, '2024-05-25', 'Shipped'),
(1, 6, 6, 25, '2024-06-15', 'Pending'),
(2, 7, 7, 80, '2024-07-10', 'Shipped'),
(3, 1, 1, 35, '2024-08-05', 'Pending'),
(4, 2, 2, 55, '2024-09-15', 'Shipped'),
(5, 3, 3, 45, '2024-10-20', 'Pending');
