CREATE TABLE [dbo].[MaterialExpense]
(
	[MaterialExpenseID] INT IDENTITY (1,1) PRIMARY KEY,
	[Expense] MONEY NOT NULL,
	[JobID] INT NOT NULL,
	[ItemNumberID] INT NULL, -- Remember an assumption/requirement is that each expense can be related to a particular task/ItemNumber
	[ExpenseDescription] VARCHAR(50) NULL,
	[PONumber] CHAR(7) NULL,
	[InvoiceNumber] CHAR(8) NULL,
	[TaxIncluded] BIT NULL,
	[TaxPercentage] DECIMAL NULL,
	[MarkupPercentage] DECIMAL NULL,
	CONSTRAINT [FK_dbo.MaterialExpense_dbo.Job_JobID] FOREIGN KEY ([JobID]) 
        REFERENCES [dbo].[Job] ([JobID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.MaterialExpense_dbo.ItemNumber_ItemNumberID] FOREIGN KEY ([ItemNumberID]) 
        REFERENCES [dbo].[ItemNumber] ([ItemNumberID]) ON DELETE CASCADE
)
