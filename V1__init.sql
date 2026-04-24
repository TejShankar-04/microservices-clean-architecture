IF DB_ID('orderdb') IS NULL
BEGIN
    EXEC('CREATE DATABASE orderdb');
END;

EXEC('
CREATE TABLE orderdb.dbo.Orders (
    Id INT IDENTITY PRIMARY KEY,
    Amount DECIMAL(18,2),
    Status NVARCHAR(50)
)');

EXEC('
CREATE TABLE orderdb.dbo.OutboxMessages (
    Id INT IDENTITY PRIMARY KEY,
    EventType NVARCHAR(100),
    Payload NVARCHAR(MAX),
    IsProcessed BIT DEFAULT 0
)');