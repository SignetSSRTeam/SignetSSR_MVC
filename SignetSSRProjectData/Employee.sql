CREATE TABLE [dbo].[Employee]
(
	[EmployeeID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [JobTitle] VARCHAR(30) NOT NULL, 
    [SuperVisor] BIT NULL, 
    [ContractLabor] BIT NULL, 
    [WageRateRT] MONEY NULL, 
    [WageRateOT] MONEY NULL, 
    [HomePhone] CHAR(15) NULL, 
    [CellPhone] CHAR(15) NULL, 
    [Address] VARCHAR(100) NULL, 
    [EmailAddress] VARCHAR(60) NULL, 
    [Notes] VARCHAR(100) NULL
)
