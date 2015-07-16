CREATE TABLE [dbo].[Attendance]
(
	[AttendanceID] INT IDENTITY (1,1) PRIMARY KEY,
	[EmployeeID] INT NOT NULL,
	[Date] DATE NOT NULL,
	[Attendance] VARCHAR(15) NULL,
	[HoursMissed] DECIMAL NULL,
	[Reason] VARCHAR(100) NULL,
	[Excused] BIT NULL,
	CONSTRAINT [FK_dbo.Attence_dbo.Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
        REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE
)
