-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
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
END
GO
