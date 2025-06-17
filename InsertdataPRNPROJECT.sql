-- Insert data into Users table
INSERT INTO Users (FullName, Email, Password, Role, Phone, Address) VALUES
('Nguyen Van A', 'vana@example.com', 'password123', 'Citizen', '0123456789', '123 Street Name'),
('Administrator', 'admin@gmail.com', 'admin123', 'Admin', '0987654321', NULL),
('Le Van C', 'vanc@example.com', 'password789', 'TrafficPolice', '0123456780', '456 Another St'),
('Hoang D', 'hoangd@example.com', 'password012', 'Citizen', '0123456781', NULL),
('Pham E', 'phame@example.com', 'password345', 'Citizen', '0987654322', NULL),
('Bui Xuan Bac', 'bacb436@gmail.com', 'bac123', 'Citizen', '0913459668', 'Lai Chau'),
('Vu Minh Đuc', 'mduc@gmail.com', 'duc123', 'TrafficPolice', '09999988888', NULL),
('Nguyen Vo Thai Bao', 'bacntv@ggg.com', '123bao', 'TrafficPolice', '0911119999', 'Hoa Lac'),
('Bui Thi Huong', 'buihuong868@gmail.com', 'huong123', 'Citizen', '0832038989', 'Lai Chau'),
('Bui Van Huan', 'huanbv@gmail.com', '123456huan', 'Citizen', '0945044838', 'Lai Chau'),
('Tran Trung Kien', 'kientt@gmail.com', 'kien123', 'Citizen', '0983812328', 'Ha noi'),
('Bui Thi Lan', 'lanbt@gmail.com', 'lan123', 'Citizen', '0916813567', 'Lai Chau');


-- Insert data into Vehicles table
INSERT INTO Vehicles (PlateNumber, OwnerID, Brand, Model, ManufactureYear) VALUES
('30A-12345', 1, 'Toyota', 'Camry', 2020),
('29B-67890', 2, 'Honda', 'Civic', 2019),
('30C-11223', 3, 'Yamaha', 'Exciter', 2021),
('29D-44556', 4, 'Audi', 'A5', 2019),
('30E-78901', 5, 'Hyundai', 'SantaFe', 2022),
('25B1-11746', 5, 'Honda', 'Wave', 2008),
('30F-23456', 7, 'Ford', 'Focus', 2018),
('31G-34567', 8, 'Chevrolet', 'Malibu', 2017),
('32H-45678', 9, 'BMW', 'X5', 2020),
('33I-56789', 10, 'Audi', 'A4', 2019);


-- Insert data into Notifications table
INSERT INTO Notifications (UserID, Message, PlateNumber) VALUES
(1, 'Your speeding report has been submitted.', '30A-12345'),
(2, 'Your report on parking violation is approved.', '29B-67890'),
(3, 'Your report was rejected.', '30F-23456'),
(4, 'Pending processing on your speeding report.', '29D-44556'),
(5, 'Helmet violation submitted successfully.', '30E-78901');
