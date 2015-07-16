/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Employee AS Target
USING (VALUES 
        ( 1,'Donnie','Tibbetts', 'Welder',0,1,40.00,60.00,'(123)-234-2344','(456)-543-5697','12,cdr street,Pascagoula,MS-39581','xjcijjcdc@aol.com',''), 
        (2,'Liza','Guzman',  'Programmer',0,1,60.00,80.00,'(123)-264-2944','(456)-533-5297','3452,abc street,Pascagoula,MS-39581','tyjcijdc@aol.com',''), 
		(3,'Phil','Catlett', 'Cutter',0,1,42.00,62.00,'(123)-234-2394','(456)-243-5197','4562,vfdt street,Pascagoula,MS-39581','mnijjcdc@aol.com','')
)
AS Source (EmployeeID,FirstName,LastName, JobTitle, SuperVisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes)
ON Target.EmployeeID = Source.EmployeeID
WHEN NOT MATCHED BY TARGET THEN
INSERT (FirstName,LastName, JobTitle, SuperVisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes)
VALUES (FirstName,LastName, JobTitle, SuperVisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes);


MERGE INTO Attendance AS Target 
USING (VALUES 
        (1,1,'3-4-2015','7.5 Hours',0.5,'Late',1), 
        (2,2,'3-4-2015','7.75 Hours',0.25,'Left Early',0), 
        (3,3,'3-4-2015','7.90 Hours',0.10,'Traffic',1)
) 
AS Source (AttendanceID,EmployeeID,Date,Attendance,HoursMissed,Reason,Excused) 
ON Target.AttendanceID = Source.AttendanceID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (EmployeeID,Date,Attendance,HoursMissed,Reason,Excused)
VALUES (EmployeeID,Date,Attendance,HoursMissed,Reason,Excused);


MERGE INTO WageHistory AS Target 
USING (VALUES 
        (1,1,40,60,'1-1-2015',Null,1), 
        (2,2,60,80,'1-1-2015',Null,1), 
        (3,3,42,62,'1-1-2015',Null,1)
) 
AS Source (WageHistoryID,EmployeeID,WageRT,WageOT,DateStart,DateEnd,IsCurrent) 
ON Target.WageHistoryID = Source.WageHistoryID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (EmployeeID,WageRT,WageOT,DateStart,DateEnd,IsCurrent) 
VALUES (EmployeeID,WageRT,WageOT,DateStart,DateEnd,IsCurrent);


MERGE INTO Customer AS Target
USING (VALUES 
        (1, 'Nisha','Patel', 'ABC Inc','Manager','(434)-374-9098','npcijjcdc@aol.com',''), 
        (2, 'Lindsey','Smith',  'XYZ Ltd.','CEO','(356)-462-4362','lsjcijdc@aol.com',''), 
		(3, 'Ramya','Raval', 'PDQ Org.','Project Manager','(836)-444-7676','rrijjcdc@aol.com','')
)
AS Source (CustomerID,FirstName,LastName,Company,Title, BusinessPhone,EmailAddress,Notes)
ON Target.CustomerID = Source.CustomerID
WHEN NOT MATCHED BY TARGET THEN
INSERT (FirstName,LastName,Company,Title, BusinessPhone,EmailAddress,Notes)
VALUES (FirstName,LastName,Company,Title, BusinessPhone,EmailAddress,Notes);


MERGE INTO Rate AS Target 
USING (VALUES 
        (1,'JobA',1,60.00,90.00), 
        (2,'JobB',0,40.00,60.00), 
        (3,'Jobc',0,45.00,65.00)
) 
AS Source (RateID,JobType,Supervisor,RateRT,RateOT) 
ON Target.RateID = Source.RateID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (JobType,Supervisor,RateRT,RateOT) 
VALUES (JobType,Supervisor,RateRT,RateOT);


MERGE INTO Job AS Target 
USING (VALUES 
        (1,1,1,1,'VesselA',1,0,Null,'3-4-2015',Null), 
        (2,2,2,2,'VesselB',2,1,Null,'3-4-2015',null), 
        (3,3,3,3,'VesselC',3,0,null,'3-4-2015',null)
) 
AS Source (JobID,JobNumber,CustomerID,RateID,VesselName,Priority,Status,Description,StartDate,EndDate)
ON Target.JobID = Source.JobID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (JobNumber,CustomerID,RateID,VesselName,Priority,Status,Description,StartDate,EndDate)
VALUES (JobNumber,CustomerID,RateID,VesselName,Priority,Status,Description,StartDate,EndDate);


MERGE INTO ItemNumber AS Target 
USING (VALUES 
        (1,1,'ItemA'), 
        (2,2,'ItemB'), 
        (3,3,'Itemc')
) 
AS Source (ItemNumberID,ItemNumber,Description) 
ON Target.ItemNumberID = Source.ItemNumberID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (ItemNumber,Description) 
VALUES (ItemNumber,Description);



MERGE INTO HoursWorked AS Target 
USING (VALUES 
        (1,1,1,1,'3-4-2015',7.5,0), 
        (2,2,2,2,'3-4-2015',7.75,0), 
        (3,3,3,3,'3-4-2015',7.90,0)
) 
AS Source (HoursWorkedID,EmployeeID,JobID,ItemNumberID,Date,HoursWorkedRT, HoursWorkedOT) 
ON Target.HoursWorkedID = Source.HoursWorkedID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (EmployeeID,JobID,ItemNumberID,Date,HoursWorkedRT, HoursWorkedOT) 
VALUES (EmployeeID,JobID,ItemNumberID,Date,HoursWorkedRT, HoursWorkedOT);


MERGE INTO MaterialExpense AS Target 
USING (VALUES 
        (1,1000,1,1,Null,'1234567','00003746',1,6,15), 
        (2,20000,2,2,Null,'3747367','93847612',1,6,12), 
        (3,333333,3,3,Null,'1237654','09090909',1,6,15)
) 
AS Source (MaterialExpenseID,Expense,JobID,ItemNumberID,ExpenseDescription,PONumber,InvoiceNumber,TaxIncluded,TaxPercentage,MarkUpPercentage) 
ON Target.MaterialExpenseID = Source.MaterialExpenseID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Expense,JobID,ItemNumberID,ExpenseDescription,PONumber,InvoiceNumber,TaxIncluded,TaxPercentage,MarkUpPercentage)
VALUES (Expense,JobID,ItemNumberID,ExpenseDescription,PONumber,InvoiceNumber,TaxIncluded,TaxPercentage,MarkUpPercentage);

