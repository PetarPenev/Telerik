--1. Write a SQL query to find the names and salaries of the employees that
--take the minimal salary in the company. 
--Use a nested SELECT statement.

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--2. Write a SQL query to find the names and salaries of the employees that 
--have a salary that is up to 10% higher than the minimal salary for the company.

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary <= 1.1 * (SELECT MIN(Salary) FROM Employees)

--3. Write a SQL query to find the full name, salary and department of the employees that
--take the minimal salary in their department. Use a nested SELECT statement.

SELECT COALESCE(FirstName, '') + ' ' + COALESCE(MiddleName, '') + ' ' + COALESCE(LastName, ''), Salary, d.Name
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = (SELECT MIN(Salary) FROM Employees emp WHERE emp.DepartmentID = e.DepartmentID)

--4. Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary) AS [Average Salary]
FROM Employees
WHERE DepartmentID = 1

--5. Write a SQL query to find the average salary  in the "Sales" department.

SELECT AVG(e.Salary) AS [Average Salary]
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--6. Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(*) AS [Number of Employees]
FROM Employees
WHERE DepartmentId = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

--7. Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(*) AS [Number of Managed Employees]
FROM Employees
WHERE ManagerID IS NOT NULL

--8. Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) AS [Number of Unmanaged Employees]
FROM Employees
WHERE ManagerID IS NULL

--9. Write a SQL query to find all departments and the average salary for each of them.

SELECT d.Name, AVG(e.Salary)
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name

--10. Write a SQL query to find the count of all employees in each department and for each town.

SELECT d.Name, t.Name, COUNT(*) AS [Number Of Employees]
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
INNER JOIN Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID
GROUP BY d.Name, t.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. 
--Display their first name and last name.

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE 5 = (SELECT COUNT(*) FROM Employees WHERE ManagerID = e.EmployeeID)

--12. Write a SQL query to find all employees along with their managers. 
--For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], 
COALESCE(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager Name]
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
-- Use the built-in LEN(str) function.

SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE LEN(LastName) = 5

--14. Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds".
--Search in  Google to find how to format dates in SQL Server.

SELECT FORMAT(GETDATE(),'dd.MM.yyyy hh:mm:ss:fff') AS [Formatted Date]


--15. Write a SQL statement to create a table Users. 

CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(100) NOT NULL UNIQUE,
  FullName nvarchar(200) NOT NULL,
  Password nvarchar(50), CHECK(LEN(Password) >= 5),
  LastLoginTime DateTime,
  CONSTRAINT PK_Users PRIMARY KEY(UserID)
)

--16. Write a SQL statement to create a view that displays the users from the Users table 
--that have been in the system today. Test if the view works correctly.

-- First we add two users that have been logged in different times - one today, one before.

INSERT INTO Users
VALUES('EvgPopov', 'Evgeni Popov', 'droopy', '11.11.2011')

INSERT INTO Users
VALUES('Gogi', 'Georgi Popov', 'thevroom', GETDATE())
GO

CREATE VIEW UsersLoggedToday
AS
SELECT * 
FROM Users
WHERE DATEPART(DAYOFYEAR, LastLoginTime) = DATEPART(DAYOFYEAR, GETDATE()) 
AND DATEPART(YEAR, LastLoginTime) = DATEPART(YEAR, GETDATE());
GO

SELECT *
FROM UsersLoggedToday

--17. Write a SQL statement to create a table Groups. 

CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)

--18. Write a SQL statement to add a column GroupID to the table Users. 
-- Fill some data in this new column and as well in the Groups table. 
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users
ADD GroupId INT FOREIGN KEY REFERENCES Groups(GroupId);

INSERT Groups VALUES ('Players');
INSERT Groups VALUES ('Watchers');
INSERT Groups VALUES ('Referees');

UPDATE Users SET GroupId = 1;

INSERT Users VALUES ('Balalaicho', 'Ivan Vezlov', 'baidalai', GETDATE(), 2);
INSERT Users VALUES ('kurtiamivkivzalalight', 'John Snow', 'thewall', GETDATE(), 3);

--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT Groups VALUES ('Audience');
INSERT Groups VALUES ('Retirees');

INSERT Users VALUES ('baimircho', 'Miroslav Petkanov', 'vlezsega', GETDATE(), 4);
INSERT Users VALUES('1o0 Kila', 'Sto Kila', 'klati', GETDATE(), 5);

--20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users 
SET UserName = 'batkata' + UserName
WHERE UserName LIKE '%bai%'

UPDATE Groups
SET Name = Name + Name
WHERE GroupID = 2

--21. Write SQL statements to delete some of the records from the Users and Groups tables.

-- I have not resolved the conflicts as this will require deeper changes to the database
-- and is not the point of the task.

DELETE FROM Groups WHERE GroupId = 1;
DELETE FROM Users WHERE UserName LIKE '%bai%';

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 

-- Please execute the whole query. If you omit the 'COMMIT TRANSACTION' part, it is possible
-- for Management Server to hang with an uncommited transaction.

BEGIN TRAN

INSERT USERS
SELECT
	LOWER(LEFT(FirstName, 1) + LastName) + CONVERT(nvarchar(10), ROW_NUMBER() OVER (ORDER BY FirstName)),
	FirstName + ' ' + LastName,
	FirstName + ' ' + LastName,
	NULL,
	NULL
FROM Employees

GO
COMMIT TRANSACTION;
GO

--23. Write a SQL statement that changes the password to NULL for all users that 
--have not been in the system since 10.03.2010.

UPDATE Users
SET Password = NULL
WHERE LastLoginTime IS NULL
OR DATEPART(DAYOFYEAR, LastLoginTime) <= DATEPART(DAYOFYEAR, '10.03.2010') 
AND DATEPART(YEAR, LastLoginTime) <= DATEPART(YEAR, '10.03.2010');

--24. Write a SQL statement that deletes all users without passwords (NULL password).

DELETE 
FROM Users
WHERE Password IS NULL

--25. Write a SQL query to display the average employee salary by department and job title.

SELECT d.Name, e.JobTitle, AVG(Salary)
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name, e.JobTitle

--26. Write a SQL query to display the minimal employee salary by department and 
--job title along with the name of some of the employees that take it.

SELECT FirstName, LastName, d.Name, Salary
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE SALARY = (SELECT MIN(Salary) FROM Employees emp WHERE e.DepartmentID = emp.DepartmentID)

--27. Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name, COUNT(*)
FROM Employees e INNER JOIN Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--28. Write a SQL query to display the number of managers from each town.

SELECT t.Name, COUNT(DISTINCT m.EmployeeID)
FROM Employees e INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a
ON m.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.TownID, t.Name
ORDER BY COUNT(DISTINCT m.EmployeeID) DESC

--29. Write a SQL to create table WorkHours to store work reports 
--for each employee (employee id, date, task, hours, comments).

CREATE TABLE WorkHours (
  ReportID int IDENTITY PRIMARY KEY,
  EmployeeID int FOREIGN KEY REFERENCES Employees (EmployeeID),
  ReportDate DateTime,
  Task nvarchar(50),
  TaskHours decimal(5,2),
  Comments nvarchar(200)
)

INSERT INTO WorkHours
VALUES (1, '01.01.2013', 'Cleaning', 44.1, 'Very good');

INSERT INTO WorkHours
VALUES(2, '01.02.2013', 'Programming', 12, 'Excellent');

INSERT INTO WorkHours
VALUES(3, '01.03.2013', 'Writing', 3, 'Acceptable');

UPDATE WorkHours
SET Comments = 'Bad'
WHERE EmployeeID = 1

DELETE FROM WorkHours
WHERE EmployeeID = 3

CREATE TABLE WorkHourLogs(
	ChangeID int IDENTITY PRIMARY KEY,
	OldEmployeeID int NULL,
	OldReportDate DateTime NULL,
	OldTask nvarchar(50) NULL,
	OldTaskHours decimal(5,2) NULL,
	OldComments nvarchar(200) NULL,
	NewEmployeeID int NULL,
	NewReportDate DateTime NULL,
	NewTask nvarchar(50) NULL,
	NewTaskHours decimal(5,2) NULL,
	NewComments nvarchar(200) NULL,
	Command nvarchar(20)
)

CREATE TRIGGER dbo.InsertTrigger
on dbo.WorkHours FOR INSERT
AS
	INSERT INTO WorkHourLogs
	SELECT NULL, NULL, NULL, NULL, NULL, i.EmployeeID, i.ReportDate,
	i.Task, i.TaskHours, i.Comments, 'insert'
	FROM inserted i
GO

CREATE TRIGGER dbo.UpdateTrigger
on dbo.WorkHours FOR UPDATE
AS
	INSERT INTO WorkHourLogs
	SELECT d.EmployeeID, d.ReportDate, d.Task, d.TaskHours, d.Comments, i.EmployeeID, i.ReportDate,
	i.Task, i.TaskHours, i.Comments, 'update'
	FROM inserted i, deleted d
GO

CREATE TRIGGER dbo.DeleteTrigger
on dbo.WorkHours FOR DELETE
AS
	INSERT INTO WorkHourLogs
	SELECT d.EmployeeID, d.ReportDate, d.Task, d.TaskHours, d.Comments, NULL, NULL,
	NULL, NULL, NULL, 'delete'
	FROM deleted d
GO

--30. Start a database transaction, delete all employees from the 'Sales' department 
--along with all dependent records from the pother tables. At the end rollback the transaction.

BEGIN TRAN

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_CASCADE_1 FOREIGN KEY (EmployeeID)
REFERENCES Employees (EmployeeID)
ON DELETE CASCADE;

-- ManagerId has to be nullable
ALTER TABLE Departments
ALTER COLUMN ManagerId int NULL

ALTER TABLE Departments
ADD CONSTRAINT FK_CASCADE_2 FOREIGN KEY (ManagerId)
REFERENCES Employees (EmployeeID)
ON DELETE SET NULL;

DELETE
FROM Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

ROLLBACK TRAN

GO

--31. Start a database transaction and drop the table EmployeesProjects.

-- Please copy the script in new query as it may give you an error during execution
BEGIN TRAN

DROP TABLE EmployeesProjects;

ROLLBACK TRAN

GO

--32. Using temporary tables backup all records from EmployeesProjects and
-- restore them back after dropping and re-creating the table.

SELECT * INTO #TemporaryEmployeeProjects
FROM EmployeesProjects

DROP TABLE EmployeeProjects

SELECT * INTO EmployeeProjects
FROM #TemporaryEmployeeProjects

DROP TABLE #TemporaryEmployeeProjects