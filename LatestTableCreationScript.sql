/*
Author: Ashwin Kannalath
ISC 567
Date: 2/16/2015
TABLE CREATION SCRIPT


/*************************
CREATE DATABASE AND TABLES
**************************/
*/

PRINT 'BEGIN SCRIPT EXECUTION'
GO

--Don't display number of rows inserted. Restricts Messages to print statements
SET NOCOUNT ON
GO

USE master
GO

-- Check if database exists and drop it if it does
IF EXISTS (SELECT * FROM sysdatabases WHERE name='ISC567_SSRS_Database')
      BEGIN
	     DROP DATABASE ISC567_SSRS_Database;
	     PRINT 'Dropped database (Database with name ISC567_SSRS_Database Existed)';
      END
GO

/* Create the Database */

--DROP DATABASE ISC567_SSRS_Database
CREATE DATABASE ISC567_SSRS_Database
GO
PRINT 'Database Created'

USE ISC567_SSRS_Database
GO

/* Create tables with appropriate attributes and data types */

--DROP TABLE Employee
CREATE TABLE Employee (
	EmployeeID INT IDENTITY (1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(30) NOT NULL,
	Supervisor BIT NULL,
	ContractLabor BIT NULL,
	WageRateRT MONEY NULL,
	WageRateOT MONEY NULL,
	HomePhone CHAR(15) NULL,
	CellPhone CHAR(15) NULL,
	Address VARCHAR(100) NULL,
	EmailAddress VARCHAR(60) NULL,
	Notes VARCHAR(100) NULL
	)
GO

--DROP TABLE Customer
CREATE TABLE Customer (
	CustomerID INT IDENTITY (1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Company VARCHAR(30) NULL,
	Title VARCHAR(30) NULL,
	BusinessPhone CHAR(15) NULL,
	HomePhone CHAR(15) NULL,
	CellPhone CHAR(15) NULL,
	FaxNumber CHAR(15) NULL,
	EmailAddress VARCHAR(60) NULL,
	Notes VARCHAR(100) NULL
	)
GO

--DROP TABLE Rate
CREATE TABLE Rate (
	RateID INT IDENTITY (1,1) PRIMARY KEY,
	JobType NVARCHAR(40) NOT NULL,
	Supervisor Bit,
	RateRT MONEY NOT NULL,
	RateOT MONEY NOT NULL,
	LaborHourlyCost DECIMAL NULL
	)
GO

--DROP TABLE Attendance
CREATE TABLE Attendance (
	AttendanceID INT IDENTITY (1,1) PRIMARY KEY,
	EmployeeID INT NOT NULL,
	Date DATETIME NOT NULL,
	Attendance VARCHAR(15) NULL,
	HoursMissed DECIMAL NULL,
	Reason NVARCHAR(100) NULL,
	Excused BIT NULL
	)
GO

--DROP TABLE WageHistory
CREATE TABLE WageHistory (
	WageHistoryID INT IDENTITY (1,1) PRIMARY KEY,
	EmployeeID INT NOT NULL,
	WageRT INT NOT NULL,
	WageOT INT NOT NULL,
	DateStart DATE NULL, 
	DateEnd DATE NULL,
	IsCurrent BIT NOT NULL
	)
GO

--DROP TABLE HoursWorked
CREATE TABLE HoursWorked (
	HoursWorkedID INT IDENTITY (1,1) PRIMARY KEY,
	EmployeeID INT NOT NULL,
	JobID INT NOT NULL,
	ItemNumber INT NULL,
	WageHistoryID INT NULL,
	Date DATETIME NOT NULL,
	HoursWorkedRT DECIMAL NULL,
	HoursWorkedOT DECIMAL NULL,
	JobDescription NVARCHAR (255) null
	)
GO

--DROP TABLE Job
CREATE TABLE Job (
	JobID INT IDENTITY (1,1) PRIMARY KEY,
	JobNumber VARCHAR(100) NOT NULL,
	CustomerID INT NOT NULL,
	RateID INT NOT NULL,
	VesselName VARCHAR(100) NOT NULL,
	ItemNumber INT NULL,
	Priority NVARCHAR NULL,
	Status Nvarchar(255) NULL,
	Description nVARCHAR(max) NULL,
	StartDate DATETIME NULL,
	EndDate DATETIME NULL
	)
GO


--DROP TABLE MaterialsExpense
CREATE TABLE MaterialsExpense (
	MaterialsExpenseID INT IDENTITY (1,1) PRIMARY KEY,
	Expense MONEY NOT NULL,
	JobID INT NOT NULL,
	ItemNumber INT NULL, 
	ExpenseDate DATETIME Null,
	InvoiceReceived BIT Null,
	ExpenseDescription NVARCHAR(50) NULL,
	PONumber CHAR(7) NULL,
	InvoiceNumber CHAR(8) NULL,
	TaxIncluded BIT NULL,
	TaxPercentage DECIMAL NULL,
	MarkupPercentage DECIMAL NULL
	)
GO

--DROP TABLE LoginAudit
CREATE TABLE LoginAudit (
	LoginAuditID INT IDENTITY (1,1) PRIMARY KEY,
	UserName NVARCHAR(MAX) NULL,
	Activity NVARCHAR(20) NULL,
	TimeRecorded DATETIME NULL
	)
GO


PRINT 'Tables Created'


--Insert data into Tables
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('DNU_In-house',0,46.00,46.00);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Billable Hours', 0, 57.00,70.00);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Affiliated',0,40,40);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Billable Hours',0,57,70);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Machine In-house',0,46,46);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Machine Billable Hours',0,66.50,81.50);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('DNU_Machine In-house',0,55,65);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('DNU_Machine Billable Hours',0,60,70);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Paid Time Off',0,0,0);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Crescent Towing',0,50,50);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('Crescent Towing',0,62,62);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('DNU_New In-house',0,46,46);
INSERT INTO Rate(JobType,Supervisor,RateRT,RateOT) 
VALUES ('In-house',0,49,49);
PRINT ('table Rate Inserted');
SELECT * FROM Rate;

INSERT INTO Employee (FirstName,LastName, JobTitle, SuperVisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes)
VALUES('Donnie','Tibbetts', 'Welder',0,1,40.00,60.00,'(123)-234-2344','(456)-543-5697','12,cdr street,Pascagoula,MS-39581','xjcijjcdc@aol.com','');
INSERT INTO Employee (FirstName,LastName, JobTitle, SuperVisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes)
VALUES('Liza','Guzman',  'Programmer',0,1,60.00,80.00,'(123)-264-2944','(456)-533-5297','3452,abc street,Pascagoula,MS-39581','tyjcijdc@aol.com','');
INSERT INTO Employee (FirstName,LastName, JobTitle, SuperVisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes)
VALUES('Phil','Catlett', 'Cutter',0,1,42.00,62.00,'(123)-234-2394','(456)-243-5197','4562,vfdt street,Pascagoula,MS-39581','mnijjcdc@aol.com','');
GO
PRINT ('table Employee Inserted');
GO

INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Ashwin', 'Kannalath','ABC Inc','Manager','(434)-374-9098',null,null,null,'npcijjcdc@aol.com','' );
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Sridhar Reddy','Mallu', 'XYZ Ltd.','CEO','(356)-462-4362',null,null,null,'lsjcijdc@aol.com','');
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Srisairamreddy','Menakuru','PDQ Org.','Project Manager','(836)-414-7676',null,null,null,'rrijjcdc@aol.com','');
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Karthik Chandra','Cherukuri','CTS Org.','CEO','(836)-454-7676',null,null,null,'rcndkjneioucdc@aol.com','' );
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Kamalnadh','Nimmagadda','EFG Org.','Manager','(836)-494-7676',null,null,null,'rsieudc@aol.com','');
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Lindsey','Cerkovnik','IRS Org.','Project Manager','(836)-424-7676',null,null,null,'rqwwerdc@aol.com','');
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Nisha','Patel','USA Org.','Manager','(836)-484-7676',null,null,null,'rrwjxeunbdc@aol.com','');
INSERT INTO Customer(FirstName,LastName,Company,Title, BusinessPhone,HomePhone,CellPhone,FaxNumber,EmailAddress,Notes)
VALUES('Ramya Keerthi','Katta','PPL Org.','Project Manager','(836)-334-7676',null,null,null,'rocirjdc@aol.com','');
GO
PRINT ('table Customer Inserted');
GO

INSERT INTO Attendance(EmployeeID,Date,Attendance,HoursMissed,Reason,Excused)
VALUES (1,'3-4-2015','7.5 Hours',0.5,'Late',1);
INSERT INTO Attendance(EmployeeID,Date,Attendance,HoursMissed,Reason,Excused)
VALUES (2,'3-4-2015','7.75 Hours',0.25,'Left Early',0);
INSERT INTO Attendance(EmployeeID,Date,Attendance,HoursMissed,Reason,Excused)
VALUES (3,'3-4-2015','7.90 Hours',0.10,'Traffic',1);
GO
PRINT ('table Attendence Inserted');
GO

INSERT INTO WageHistory(EmployeeID,WageRT,WageOT,DateStart,DateEnd,IsCurrent) 
VALUES(1,40,60,'1-1-2015',Null,1);
INSERT INTO WageHistory(EmployeeID,WageRT,WageOT,DateStart,DateEnd,IsCurrent) 
VALUES(2,60,80,'1-1-2015',Null,1);
INSERT INTO WageHistory(EmployeeID,WageRT,WageOT,DateStart,DateEnd,IsCurrent) 
VALUES(3,42,62,'1-1-2015',Null,1);
GO
PRINT ('table WageHistory Inserted');
GO

INSERT INTO Job(JobNumber,CustomerID,RateID,VesselName,ItemNumber,Priority,Status,Description,StartDate,EndDate)
VALUES(1,1,1,'VesselA',123,'1',0,Null,'3-4-2015',Null);
INSERT INTO Job(JobNumber,CustomerID,RateID,VesselName,ItemNumber,Priority,Status,Description,StartDate,EndDate)
VALUES(2,2,6,'VesselB',null,'2',1,Null,'3-4-2015',null);
INSERT INTO Job(JobNumber,CustomerID,RateID,VesselName,ItemNumber,Priority,Status,Description,StartDate,EndDate)
VALUES(3,3,4,'VesselC',null,'3',0,null,'3-4-2015',null);
GO
PRINT ('table Job Inserted');
GO

INSERT INTO HoursWorked(EmployeeID,JobID,ItemNumber,WageHistoryID,Date,HoursWorkedRT, HoursWorkedOT,JobDescription) 
VALUES(1,1,1,1,'3-4-2015',7.5,0,'description1');
INSERT INTO HoursWorked(EmployeeID,JobID,ItemNumber,WageHistoryID,Date,HoursWorkedRT, HoursWorkedOT,JobDescription) 
VALUES(2,2,2,2,'3-4-2015',7.75,0,'description2');
INSERT INTO HoursWorked(EmployeeID,JobID,ItemNumber,WageHistoryID,Date,HoursWorkedRT, HoursWorkedOT,JobDescription) 
VALUES(3,3,3,3,'3-4-2015',7.90,0,'description3');
GO
PRINT ('table HoursWorked Inserted');
GO

INSERT INTO MaterialsExpense(Expense,JobID,ItemNumber,ExpenseDate,InvoiceReceived,ExpenseDescription,PONumber,InvoiceNumber,TaxIncluded,TaxPercentage,MarkUpPercentage)
VALUES(1000,1,1,3/3/2015,1,Null,'1234567','00003746',1,6,15);
INSERT INTO MaterialsExpense(Expense,JobID,ItemNumber,ExpenseDate,InvoiceReceived,ExpenseDescription,PONumber,InvoiceNumber,TaxIncluded,TaxPercentage,MarkUpPercentage)
VALUES(20000,2,2,4/4/2014,0,Null,'3747367','93847612',1,6,12);
INSERT INTO MaterialsExpense(Expense,JobID,ItemNumber,ExpenseDate,InvoiceReceived,ExpenseDescription,PONumber,InvoiceNumber,TaxIncluded,TaxPercentage,MarkUpPercentage)
VALUES(333333,3,3,3/3/2015,Null,'description1','1237654','09090909',1,6,15);
GO
PRINT ('table MaterialsExpense Inserted');
GO
PRINT ('All tables Inserted');
GO


--------------------------------------------------------------------------------------------------------


/******************
CREATE CONSTRAINTS
*******************/

/* Create foreign key constraints */

--ALTER TABLE Job DROP CONSTRAINT FK_Job_Rate
ALTER TABLE Job
ADD CONSTRAINT FK_Job_Rate
FOREIGN KEY (RateID) REFERENCES Rate(RateID)
GO

--ALTER TABLE Job DROP CONSTRAINT FK_Job_Customer
ALTER TABLE Job
ADD CONSTRAINT FK_Job_Customer
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
GO

--ALTER TABLE HoursWorked DROP CONSTRAINT FK_HoursWorked_Employee
ALTER TABLE HoursWorked
ADD CONSTRAINT FK_HoursWorked_Employee
FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
GO

--ALTER TABLE HoursWorked DROP CONSTRAINT FK_HoursWorked_Job
ALTER TABLE HoursWorked
ADD CONSTRAINT FK_HoursWorked_Job
FOREIGN KEY (JobID) REFERENCES Job(JobID)
GO

--ALTER TABLE HoursWorked DROP CONSTRAINT FK_HoursWorked_WageHistory
ALTER TABLE HoursWorked
ADD CONSTRAINT FK_HoursWorked_WageHistory
FOREIGN KEY (WageHistoryID) REFERENCES WageHistory(WageHistoryID)
GO

--ALTER TABLE MaterialsExpense DROP CONSTRAINT FK_MaterialsExpense_Job
ALTER TABLE MaterialsExpense
ADD CONSTRAINT FK_MaterialsExpense_Job
FOREIGN KEY (JobID) REFERENCES Job(JobID)
GO


--ALTER TABLE Attendance DROP CONSTRAINT FK_Attendance_Employee
ALTER TABLE Attendance
ADD CONSTRAINT FK_Attendance_Employee
FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
GO

--ALTER TABLE WageHistory DROP CONSTRAINT FK_WageHistory_Employee
ALTER TABLE WageHistory
ADD CONSTRAINT FK_WageHistory_Employee
FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
GO

PRINT 'Foreign Key Constraints Created'

