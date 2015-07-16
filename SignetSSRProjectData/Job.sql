CREATE TABLE [dbo].[Job]
(
	[JobID] INT IDENTITY (1,1) PRIMARY KEY,
	[JobNumber] VARCHAR(100) NOT NULL,
	[CustomerID] INT NOT NULL,
	[RateID] INT NOT NULL,
	[VesselName] VARCHAR(100) NOT NULL,
	[Priority] INT NULL,
	[Status] BIT NULL,
	[Description] VARCHAR(100) NULL,
	[StartDate] DATE NULL,
	[EndDate] DATE NULL,
	CONSTRAINT [FK_dbo.Job_dbo.Rate_RateID] FOREIGN KEY ([RateID]) 
        REFERENCES [dbo].[Rate] ([RateID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Job_dbo.Customer_CustomerID] FOREIGN KEY ([CustomerID]) 
        REFERENCES [dbo].[Customer] ([CustomerID]) ON DELETE CASCADE
)
