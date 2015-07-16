CREATE TABLE [dbo].[Customer]
(
	[CustomerID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Company] VARCHAR(30) NULL, 
    [Title] VARCHAR(30) NULL, 
    [BusinessPhone] CHAR(15) NULL, 
    [CellPhone] CHAR(15) NULL, 
    [HomePhone] CHAR(15) NULL, 
    [FaxNumber] CHAR(15) NULL, 
    [EmailAddress] VARCHAR(60) NULL, 
    [Notes] VARCHAR(100) NULL
)
