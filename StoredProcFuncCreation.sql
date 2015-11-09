
--****************************************
-- EMPLOYEE HOURS WORKED WEEKLY

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
GO

--****************************************
-- PROJECT HOURS WORKED WEEKLY

CREATE PROCEDURE projecthoursworkedweekly
	-- Add the parameters for the stored procedure here
	@Date [Date]
AS
BEGIN
	 SET NOCOUNT ON;
	DECLARE @WeekStart Date = DATEADD(dd, -(DATEPART(dw, @Date)-2), @Date) 
    DECLARE @WeekEnd Date = DATEADD(dd, 7-(DATEPART(dw, @Date)-1), @Date)
	SELECT        Job.VesselName, SUM(HoursWorked.HoursWorkedRT) AS TotalHoursRT, SUM(HoursWorked.HoursWorkedOT) AS TotalHoursOT, HoursWorked.Date, Job.JobNumber
FROM            Job INNER JOIN
                         HoursWorked ON Job.JobID = HoursWorked.JobID
WHERE [Date] BETWEEN @WeekStart AND @WeekEnd
GROUP BY Job.VesselName, HoursWorked.Date, Job.JobNumber
END;
GO

--****************************************
-- PROJECT PROFIT SUMMARY

CREATE PROCEDURE [dbo].[uspProfitSummary]
    @CostOption INT,
	@Status NVARCHAR(256),
	@BeginDate Date,
	@EndDate Date,
	@JobID NVARCHAR(256)

AS
BEGIN
    SET NOCOUNT ON;
	SELECT ISNULL(J.JobID, M.JobID) AS JobID,
	   ISNULL(J.VesselName, M.VesselName) AS VesselName,
	   ISNULL(J.JobNumber, M.JobNumber) AS JobNumber,
	   ISNULL(HW.ItemNumber, M.ItemNumber) AS ItemNumber,
	   SUM(ISNULL(WH.WageRT, 0)) AS WageRT,
	   SUM(ISNULL(WH.WageOT, 0)) AS WageOT,
	   SUM(ISNULL(HW.HoursWorkedRT, 0)) AS HoursWorkedRT,
	   SUM(ISNULL(HW.HoursWorkedOT, 0)) AS HoursWorkedOT,
	   SUM(ISNULL(R.RateRT, 0)* ISNULL(HW.HoursWorkedRT, 0)) AS ChargesRT,
	   SUM(ISNULL(R.RateOT, 0)* ISNULL(HW.HoursWorkedOT, 0)) AS ChargesOT,
	   CASE WHEN @CostOption = 1
	   THEN 
			SUM((ISNULL(WH.WageRT,0) + ISNULL(WH.WageOT,0)) + (20 * (ISNULL(HW.HoursWorkedRT,0) + ISNULL(HW.HoursWorkedOT, 0))))
	   ELSE
	        SUM((49 * (ISNULL(HW.HoursWorkedRT,0) + ISNULL(HW.HoursWorkedOT, 0))))
	   END AS LaborCost, 
	   CASE WHEN @CostOption = 1
	   THEN 
			SUM((ISNULL(R.RateRT, 0) + ISNULL(R.RateOT, 0)) - (ISNULL(WH.WageRT,0) + ISNULL(WH.WageOT,0)) - (20 * (ISNULL(HW.HoursWorkedRT,0) + ISNULL(HW.HoursWorkedOT, 0))))
	   ELSE
	        SUM((ISNULL(R.RateRT, 0) + ISNULL(R.RateOT, 0)) - (49 * (ISNULL(HW.HoursWorkedRT,0) + ISNULL(HW.HoursWorkedOT, 0))))
	   END AS LaborProfit, 
	   SUM(ISNULL(M.Expense, 0)) AS MaterialsExpense,
	   SUM(ISNULL(M.[Materials + Tax], 0)) AS [Materials + Tax],
	   SUM(ISNULL(M.[Materials + Markup], 0)) AS [Materials + Markup]
	      
FROM HoursWorked HW
INNER JOIN Job J
	ON J.JobID = HW.JobID
INNER JOIN WageHistory WH
	ON WH.WageHistoryID = HW.WageHistoryID
INNER JOIN Rate R
	ON R.RateID = J.RateID

FULL OUTER JOIN (SELECT MaterialsExpense.*, Job.VesselName, Job.JobNumber, Job.Status,
				 CASE WHEN MaterialsExpense.TaxIncluded = 1
				   THEN 
						(ISNULL(MaterialsExpense.Expense,0) + (ISNULL(MaterialsExpense.Expense,0) * (ISNULL(MaterialsExpense.TaxPercentage,0)/100)))
					ELSE 
						(ISNULL(MaterialsExpense.Expense, 0))
					END AS [Materials + Tax],
				  CASE WHEN MaterialsExpense.TaxIncluded = 1
					THEN 
						((ISNULL(MaterialsExpense.Expense,0) + (ISNULL(MaterialsExpense.Expense,0) * (ISNULL(MaterialsExpense.TaxPercentage,0)/100))) + ((ISNULL(MaterialsExpense.Expense,0) + (ISNULL(MaterialsExpense.Expense,0) * (ISNULL(MaterialsExpense.TaxPercentage,0)/100))) * (ISNULL(MaterialsExpense.MarkupPercentage,0)/100)))
					ELSE 
						(ISNULL(MaterialsExpense.Expense,0) + (ISNULL(MaterialsExpense.Expense,0) * (ISNULL(MaterialsExpense.MarkupPercentage,0)/100)))
					END AS [Materials + Markup]
				 FROM MaterialsExpense
				 INNER JOIN Job
					ON MaterialsExpense.JobID = Job.JobID
				 WHERE (MaterialsExpense.ExpenseDate BETWEEN @BeginDate AND @EndDate)
				 AND Job.Status IN (SELECT DelimitedValue FROM dbo.udf_split(@Status, ','))
				 AND MaterialsExpense.JOBID IN (SELECT DelimitedValue FROM dbo.udf_split(@JobID, ','))) M
	ON (M.JobID = J.JobID AND M.ItemNumber = HW.ItemNumber)

WHERE (J.Status IN (SELECT DelimitedValue FROM dbo.udf_split(@Status, ',')) OR M.Status IN (SELECT DelimitedValue FROM dbo.udf_split(@Status, ',')))
AND (J.JobID IN (SELECT DelimitedValue FROM dbo.udf_split(@JobID, ',')) OR M.JobID IN (SELECT DelimitedValue FROM dbo.udf_split(@JobID, ',')))
AND (HW.Date BETWEEN @BeginDate AND @EndDate  OR M.ExpenseDate BETWEEN @BeginDate AND @EndDate)

GROUP BY ISNULL(J.JobID, M.JobID),
	   ISNULL(J.VesselName, M.VesselName),
	   ISNULL(J.JobNumber, M.JobNumber),
	   ISNULL(HW.ItemNumber, M.ItemNumber)
	
	
END;
GO

--****************************************
-- UDF SPLIT
-- Udf Split function to accept delimiter separated

CREATE FUNCTION [dbo].[udf_Split]
(
      @ColumnData NVARCHAR(MAX)
    , @SplitDelimiter NVARCHAR(5)
)  
RETURNS @TblDelimitedValue TABLE 
(
    ID INT IDENTITY(1,1),
    DelimitedValue NVARCHAR(100)
) 
AS  
BEGIN 

    WHILE (CHARINDEX(@SplitDelimiter,@ColumnData)>0)
    BEGIN
        INSERT INTO @TblDelimitedValue (DelimitedValue)
        VALUES (ltrim(rtrim(Substring(@ColumnData,1,Charindex(@SplitDelimiter,@ColumnData)-1))))

		-- Update @ColumnData by removing the data we just added to the table
        SET @ColumnData = Substring(@ColumnData,Charindex(@SplitDelimiter,@ColumnData)+1,len(@ColumnData))
    END

	-- At this point @ColumnData will not have any @SplitDelimited character(s)
	-- Insert any remaining data to our resulting table
    INSERT INTO @TblDelimitedValue(DelimitedValue)
    VALUES (ltrim(rtrim(@ColumnData)))

    Return
END