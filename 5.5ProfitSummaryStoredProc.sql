

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