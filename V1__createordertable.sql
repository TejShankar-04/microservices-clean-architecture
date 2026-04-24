
USE orderdb;

CREATE TABLE Orders (
    Id INT IDENTITY PRIMARY KEY identity(1,1),
    Orderno varchar(20) not null default '',
    ItemNo varchar(20) not null default '',
    Amount DECIMAL(18,2) not null default 0,
    Status NVARCHAR(50) not null default ''
);

CREATE TABLE OutboxMessages (
    Id INT IDENTITY PRIMARY KEY,
    EventType NVARCHAR(100),
    Payload NVARCHAR(MAX),
    IsProcessed BIT DEFAULT 0
);