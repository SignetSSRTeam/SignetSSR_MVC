USE [ISC567_SSRS_Database]
GO
/****** Object:  StoredProcedure [dbo].[uspGetSalesInfo]    Script Date: 6/27/2015 12:56:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetHoursWorkedWeekly]
    @ContractLaborer [bit],
	@Date [Date]

AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @WeekStart Date = DATEADD(dd, -(DATEPART(dw, @Date)-2), @Date) 
    DECLARE @WeekEnd Date = DATEADD(dd, 7-(DATEPART(dw, @Date)-1), @Date)

	IF (@ContractLaborer = 1)
		SELECT FirstName + ' ' + LastName AS EmployeeName,
			   [Date],
			   Datename(dw,[Date]) AS Day,
			   HoursWorkedRT,
			   HoursWorkedOT
		FROM HoursWorked HW
		INNER JOIN Employee E
			ON E.EmployeeID = HW.EmployeeID
		WHERE [Date] BETWEEN @WeekStart AND @WeekEnd
	ELSE
		SELECT FirstName + ' ' + LastName AS EmployeeName,
			   [Date],
			   Datename(dw,[Date]) AS Day,
			   HoursWorkedRT,
			   HoursWorkedOT
		FROM HoursWorked HW
		INNER JOIN Employee E
			ON E.EmployeeID = HW.EmployeeID
		WHERE [Date] BETWEEN @WeekStart AND @WeekEnd
		AND ContractLabor = 0

    
	
	
END;