CREATE TABLE [dbo].[HoursWorked]
(
	[HoursWorkedID] INT IDENTITY (1,1) PRIMARY KEY,
	[EmployeeID] INT NOT NULL,
	[JobID] INT NOT NULL,
	[ItemNumberID] INT NULL,
	[Date] DATE NOT NULL,
	[HoursWorkedRT] DECIMAL NULL,
	[HoursWorkedOT] DECIMAL NULL,
	CONSTRAINT [FK_dbo.HoursWorked_dbo.Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
        REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.HoursWorked_dbo.Job_JobID] FOREIGN KEY ([JobID]) 
        REFERENCES [dbo].[Job] ([JobID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.HoursWorked_dbo.ItemNumber_ItemNumberID] FOREIGN KEY ([ItemNumberID]) 
        REFERENCES [dbo].[ItemNumber] ([ItemNumberID]) ON DELETE CASCADE
)
