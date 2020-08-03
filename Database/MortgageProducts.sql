CREATE TABLE [dbo].[MortgageProducts]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [LenderId] BIGINT FOREIGN KEY REFERENCES Lenders(Id),
    [InterestRate] DECIMAL(18, 4) NULL,
    [CreationDate] DATETIME NOT NULL DEFAULT GETDATE()
)
