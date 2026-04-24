USE orderdb;
GO

CREATE TABLE orderdb.dbo.Orders (
    Id INT IDENTITY PRIMARY KEY,
    Amount DECIMAL(18,2),
    Status NVARCHAR(50)
)

CREATE TABLE orderdb.dbo.OutboxMessages (
    Id INT IDENTITY PRIMARY KEY,
    EventType NVARCHAR(100),
    Payload NVARCHAR(MAX),
    IsProcessed BIT DEFAULT 0
)
GO