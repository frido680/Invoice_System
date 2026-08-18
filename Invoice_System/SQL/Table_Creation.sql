CREATE TABLE Products
(
    Id INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL,
    IsHazardous BIT NOT NULL,
    IsFragile BIT NOT NULL,
    Discount DECIMAL(18,2) NOT NULL,
    IsDiscountEligible BIT NOT NULL,

    CONSTRAINT PK_Products
        PRIMARY KEY (Id)
);


CREATE TABLE Customers
(
    Id INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    Address NVARCHAR(300) NOT NULL,

    CONSTRAINT PK_Customers
        PRIMARY KEY (Id)
);


CREATE TABLE Orders
(
    Id INT IDENTITY(1,1) NOT NULL,
    CustomerId INT NOT NULL,
    OrderDate DATETIME2 NOT NULL,

    CONSTRAINT PK_Orders
        PRIMARY KEY (Id),

    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerId)
        REFERENCES Customers(Id)
);


CREATE TABLE OrderItems
(
    Id INT IDENTITY(1,1) NOT NULL,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPriceAtOrder DECIMAL(18,2) NOT NULL,

    CONSTRAINT PK_OrderItems
        PRIMARY KEY (Id),

    CONSTRAINT FK_OrderItems_Orders
        FOREIGN KEY (OrderId)
        REFERENCES Orders(Id),

    CONSTRAINT FK_OrderItems_Products
        FOREIGN KEY (ProductId)
        REFERENCES Products(Id)
);