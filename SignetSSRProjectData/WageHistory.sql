CREATE TABLE [dbo].[WageHistory]
(
	[WageHistoryID] INT IDENTITY (1,1) PRIMARY KEY,
	[EmployeeID] INT NOT NULL,
	[WageRT] INT NOT NULL,
	[WageOT] INT NOT NULL,
	[DateStart] DATE NULL, 
	[DateEnd] DATE NULL,
	[IsCurrent] BIT NOT NULL,
	CONSTRAINT [FK_dbo.WageHistory_dbo.Employee_EmployeeID] FOREIGN KEY ([EmployeeID])
		REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE
)
