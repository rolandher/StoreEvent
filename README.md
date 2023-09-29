# StoreEvent
Aplicación utilizando arquitectura limpia.

# Script SQL

CREATE DATABASE StoreHomeApi; use StoreHomeApi;

CREATE TABLE Branchs
(
    BranchId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    BranchName NVARCHAR(40) NOT NULL,
    BranchCountry NVARCHAR(50) NOT NULL,
    BranchCity NVARCHAR(50) NOT NULL
);

CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    BranchId INT NOT NULL,
    UserName NVARCHAR(40) NOT NULL,
    UserPassword NVARCHAR(40) NOT NULL,
    UserEmail NVARCHAR(40) NOT NULL,
    UserRole NVARCHAR(30) NOT NULL,
    FOREIGN KEY (BranchId) REFERENCES Branchs(BranchId)
);

CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    BranchId INT NOT NULL,
    ProductName NVARCHAR(50) NOT NULL,
    ProductDescription NVARCHAR(255) NOT NULL,
    ProductPrice DECIMAL(18, 2) NOT NULL,
    ProductInventoryStock INT NOT NULL,
    ProductCategory NVARCHAR(30) NOT NULL,
    FOREIGN KEY (BranchId) REFERENCES Branchs(BranchId)
);

#Endpoints 

#Eventos
