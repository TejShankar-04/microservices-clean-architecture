-- V2__create_orders_table.sql
USE paymentdb;
GO
CREATE TABLE payments (
    Id INT PRIMARY KEY IDENTITY,
    OrderId INT NOT NULL DEFAULT 0,
    Amount DECIMAL(10,2) NOT NULL DEFAULT 0,
    Status NVARCHAR(50) NOT NULL DEFAULT ''
);
GO