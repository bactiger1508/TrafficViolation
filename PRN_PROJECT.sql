CREATE DATABASE PRN_PROJECT

CREATE TABLE Users ( 
    UserID INT PRIMARY KEY IDENTITY(1,1), 
    FullName NVARCHAR(100) NOT NULL, 
    Email NVARCHAR(100) NOT NULL UNIQUE, 
    Password NVARCHAR(255) NOT NULL, 
    Role NVARCHAR(20) NOT NULL DEFAULT 'Citizen' CHECK (Role IN ('Admin', 'Citizen', 'TrafficPolice')), 
    Phone NVARCHAR(15) NOT NULL, 
    Address NVARCHAR(MAX)
);

CREATE TABLE Vehicles ( 
    VehicleID INT PRIMARY KEY IDENTITY(1,1), 
    PlateNumber NVARCHAR(15) NOT NULL UNIQUE, 
    OwnerID INT NOT NULL, 
    Brand NVARCHAR(50), 
    Model NVARCHAR(50), 
    ManufactureYear SMALLINT, 
    FOREIGN KEY (OwnerID) REFERENCES Users(UserID) 
); 

CREATE TABLE Reports ( 
    ReportID INT PRIMARY KEY IDENTITY(1,1), 
    ReporterID INT NOT NULL, 
    ViolationType NVARCHAR(50) NOT NULL, 
    Description NVARCHAR(MAX) NOT NULL, 
    PlateNumber NVARCHAR(15) NOT NULL, 
    ImageURL NVARCHAR(MAX), 
    VideoURL NVARCHAR(MAX), 
    Location NVARCHAR(255) NOT NULL, 
    ReportDate DATETIME DEFAULT GETDATE(), 
    Status NVARCHAR(20) DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Approved', 'Rejected')), 
    ProcessedBy INT, 
    FOREIGN KEY (ReporterID) REFERENCES Users(UserID), 
    FOREIGN KEY (ProcessedBy) REFERENCES Users(UserID), 
    FOREIGN KEY (PlateNumber) REFERENCES Vehicles(PlateNumber) 
); 

CREATE TABLE Violations ( 
    ViolationID INT PRIMARY KEY IDENTITY(1,1), 
    ReportID INT NOT NULL, 
    PlateNumber NVARCHAR(15) NOT NULL, 
    ViolatorID INT, 
    FineAmount DECIMAL(10,2) NOT NULL, 
    FineDate DATETIME DEFAULT GETDATE(), 
    PaidStatus BIT DEFAULT 0, 
    FOREIGN KEY (ReportID) REFERENCES Reports(ReportID), 
    FOREIGN KEY (PlateNumber) REFERENCES Vehicles(PlateNumber), 
    FOREIGN KEY (ViolatorID) REFERENCES Users(UserID) 
); 

CREATE TABLE Notifications ( 
    NotificationID INT PRIMARY KEY IDENTITY(1,1), 
    UserID INT NOT NULL, 
    Message NVARCHAR(MAX) NOT NULL, 
    PlateNumber NVARCHAR(15), 
    SentDate DATETIME DEFAULT GETDATE(), 
    IsRead BIT DEFAULT 0, 
    FOREIGN KEY (UserID) REFERENCES Users(UserID), 
    FOREIGN KEY (PlateNumber) REFERENCES Vehicles(PlateNumber) 
);
