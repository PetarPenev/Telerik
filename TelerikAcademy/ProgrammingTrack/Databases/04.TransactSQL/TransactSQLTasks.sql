--1.Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), 
--PersonId(FK), Balance). Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.

USE master
CREATE DATABASE PersonalAccounts

USE PersonalAccounts

CREATE TABLE Persons(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(40),
	LastName nvarchar(40),
	SSN nvarchar(40)
)

CREATE TABLE Accounts(
	Id int IDENTITY PRIMARY KEY,
	PersonId int FOREIGN KEY REFERENCES Persons(Id),
	Balance money 
)

INSERT INTO Persons
VALUES ('Hristo', 'Ivanov', '123456')

INSERT INTO Persons
VALUES ('Stoil', 'Mitev', '234567')

INSERT INTO Persons
VALUES ('Ivelin', 'Hristov', '23141141')

INSERT INTO Accounts
VALUES(1, 356)

INSERT INTO Accounts
VALUES(2, 2345677)
GO

CREATE PROC dbo.usp_SelectFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Persons
GO

EXEC usp_SelectFullName
GO

--2. Create a stored procedure that accepts a number as a parameter and returns all persons who
-- have more money in their accounts than the supplied number.

CREATE PROC dbo.usp_GetRicherPeople(@minWealth int = 1000)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
	FROM Persons p INNER JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE a.Balance >= @minWealth
Go

EXEC usp_GetRicherPeople 2000
GO

--3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
--It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.


-- I am using the formula for simple interest rate.
CREATE FUNCTION ufn_CalculateInvestedSum(@sum money, @yearlyInterest decimal(5, 2), @numberOfMonths real)
	RETURNS money
AS
BEGIN
	DECLARE @moneyFromInterest money;
	SET @moneyFromInterest = @sum * @numberOfMonths/12 * @yearlyInterest;
	RETURN @sum + @moneyFromInterest;
END

select dbo.ufn_CalculateInvestedSum(12, 0.08, 12)

--4. Create a stored procedure that uses the function from the previous example to give an interest 
-- to a person's account for one month. It should take the AccountId and the interest rate as parameters.


DROP PROC dbo.usp_GiveMonthlyInterest

CREATE PROC dbo.usp_GiveMonthlyInterest(@accountId int, @interestRate decimal(5,2) = 0.05)
AS
	BEGIN TRAN
	UPDATE Accounts
	SET Balance = dbo.ufn_CalculateInvestedSum(Balance, @interestRate, 1)
	WHERE Id = @accountId
	COMMIT TRAN
	GO
GO

EXEC usp_GiveMonthlyInterest 1, 0.1
GO

--5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money)
-- that operate in transactions.


CREATE PROC dbo.usp_WithdrawMoney(@accountId int, @moneyToWithdraw money)
AS
	BEGIN TRAN
	DECLARE @balanceOfAccount money;
	SET @balanceOfAccount = (SELECT Balance FROM Accounts WHERE Id = @accountId);
	IF @balanceOfAccount < @moneyToWithdraw
	BEGIN
		RAISERROR(N'Cannot withdraw more than the available money', 10, 1);
	END
	ELSE
	BEGIN
		UPDATE Accounts
		SET Balance = Balance - @moneyToWithdraw
		WHERE Id = @accountId
	END
	COMMIT TRAN
	GO
GO

EXEC usp_WithdrawMoney 1, 300
GO

CREATE PROC dbo.usp_DepositMoney(@accountId int, @moneyToDeposit money)
AS
	BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance + @moneyToDeposit
	WHERE Id = @accountId
	COMMIT TRAN
	GO
GO

EXEC usp_DepositMoney 1, 150
GO

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time 
-- the sum on an account changes.

CREATE TABLE Logs(
	LogId int IDENTITY PRIMARY KEY,
	AccountId int,
	OldSum money,
	NewSum money
)

GO

CREATE TRIGGER dbo.LogTrigger
ON dbo.Accounts FOR UPDATE
AS
	DECLARE @changedEntries TABLE(Id int, oldSum money, newSum money);
	INSERT INTO @changedEntries 
	SELECT i.Id, d.Balance, i.Balance FROM inserted i JOIN deleted d ON (i.Id = d.Id AND i.Balance <> d.Balance)

	INSERT INTO Logs
	SELECT Id, oldSum, newSum FROM @changedEntries
GO

EXEC usp_DepositMoney 1, 150
GO

--7. Define a function in the database TelerikAcademy that returns all Employee's names
-- (first or middle or last name) and all town's names that are comprised of given set of letters. 

-- This may seem somehow overly complicated but it is the best way to ensure that we do not use
-- a single instance of a letter more than once.
CREATE FUNCTION ufn_CheckAvailability(@values nvarchar(50), @name nvarchar(50))
RETURNS BIT
AS
BEGIN
DECLARE @allAreFound BIT;
SET @allAreFound = 1;

DECLARE @position int;
SET @position = 1;
DECLARE @currentLetter nvarchar(1);
WHILE (@position <= LEN(@name))
BEGIN
SET @currentLetter = SUBSTRING(@name, @position, 1);
IF CHARINDEX(@currentLetter, @values, 1) = 0
BEGIN
	SET @allAreFound = 0;
	BREAK;
END
ELSE
BEGIN
	SET @position = @position + 1;
	SET @values = STUFF(@values, CHARINDEX(@currentLetter, @values, 1), 1, '@'); 
END
END

RETURN @allAreFound;
END
GO

CREATE FUNCTION ufn_CheckNamesCompositionVersusSet(@values nvarchar(50))
RETURNS TABLE
AS
RETURN(
SELECT FirstName AS Name
FROM Employees
WHERE FirstName IS NOT NULL AND 1 = dbo.ufn_checkAvailability(@values, FirstName)
UNION
SELECT MiddleName AS Name
FROM Employees
WHERE MiddleName IS NOT NULL AND 1 = dbo.ufn_checkAvailability(@values, MiddleName)
UNION
SELECT LastName AS Name
FROM Employees
WHERE LastName IS NOT NULL AND 1 = dbo.ufn_checkAvailability(@values, LastName)
UNION
SELECT Name FROM Towns
WHERE Name IS NOT NULL AND 1 = dbo.ufn_checkAvailability(@values, Name)
)
GO

SELECT * FROM dbo.ufn_CheckNamesCompositionVersusSet('oistmiahf');

--8.Using database cursor write a T-SQL script that scans all employees and their addresses
-- and prints all pairs of employees that live in the same town.

--Solution with a cursor.

DECLARE EmployeeCursor CURSOR READ_ONLY FOR
	SELECT e1.FirstName + ' ' + e1.LastName, e2.FirstName + ' ' + e2.LastName, t1.Name
	FROM Employees e1 INNER JOIN Addresses a1
	ON e1.AddressId = a1.AddressId
	INNER JOIN  Towns t1
	ON a1.TownId = t1.TownId
	,
	Employees e2 INNER JOIN Addresses a2
	ON e2.AddressId = a2.AddressId
	INNER JOIN  Towns t2
	ON a2.TownId = t2.TownId
	WHERE t1.TownId = t2.TownId AND e1.EmployeeId <> e2.EmployeeId

OPEN EmployeeCursor
DECLARE @firstEmployeeName nvarchar(100), @secondEmployeeName nvarchar(100), @townName nvarchar(50);
FETCH NEXT FROM EmployeeCursor INTO @firstEmployeeName, @secondEmployeeName, @townName;

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstEmployeeName + ' and ' + @secondEmployeeName + ' live in ' + @townName + '.';
		FETCH NEXT FROM EmployeeCursor INTO @firstEmployeeName, @secondEmployeeName, @townName;
	END

CLOSE EmployeeCursor
DEALLOCATE EmployeeCursor

--Second solution with a cursor.
DECLARE @firstEmployeeTable TABLE(EmployeeId int, Name nvarchar(100), TownId int);
INSERT INTO @firstEmployeeTable 
SELECT e.EmployeeId, e.FirstName + ' ' + e.LastName AS [Full name of First Employee], t.TownId AS TownId
FROM Employees e INNER JOIN Addresses a
ON e.AddressId = a.AddressId
INNER JOIN Towns t
ON a.TownId = t.TownId

DECLARE @secondEmployeeTable TABLE(EmployeeId int, Name nvarchar(100));
INSERT INTO @secondEmployeeTable 
SELECT e.EmployeeId, e.FirstName + ' ' + e.LastName AS [Full name of First Employee]
FROM Employees e INNER JOIN Addresses a
ON e.AddressId = a.AddressId
INNER JOIN Towns t
ON a.TownId = t.TownId

DECLARE @jointTable TABLE(Name nvarchar(100), SecondName nvarchar(100), TownId int);
INSERT INTO @jointTable
SELECT a.Name, b.Name, a.TownId
FROM @firstEmployeeTable a INNER JOIN @firstEmployeeTable b
ON a.EmployeeId <> b.EmployeeId AND a.TownId = b.TownId

DECLARE EmployeeCursor CURSOR READ_ONLY FOR
SELECT j.Name, j.SecondName, t.Name
FROM @jointTable j INNER JOIN Towns t
ON j.TownId = t.TownId

OPEN EmployeeCursor
DECLARE @firstName nvarchar(100), @secondName nvarchar(100), @townName nvarchar(50);

FETCH NEXT FROM EmployeeCursor
INTO @firstName, @secondName, @townName

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstName + ' and ' + @secondName + ' live in ' + @townName + '.';
		FETCH NEXT FROM EmployeeCursor INTO @firstName, @secondName, @townName;
	END

CLOSE EmployeeCursor
DEALLOCATE EmployeeCursor

--9. Write a T-SQL script that shows for each town a list of all employees that live in it. 

DECLARE TownCursor CURSOR READ_ONLY FOR
SELECT Name
FROM Towns

OPEN TownCursor
DECLARE @townName nvarchar(50);
FETCH NEXT FROM TownCursor INTO @townName;

DECLARE @counter int, @employeeName nvarchar(100), @townNameInsideCycle nvarchar(50);
SET @counter = 1;

DECLARE @currentSequence nvarchar(MAX);

WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @currentSequence = '';
		SET @currentSequence = @currentSequence + @townName + ' -> ';

		DECLARE EmployeeCursor CURSOR READ_ONLY FOR
			SELECT e.FirstName + ' ' + e.LastName, t.Name
			FROM Employees e INNER JOIN Addresses a
			ON e.AddressId = a.AddressId
			INNER JOIN Towns t
			ON a.TownId = t.TownId

		OPEN EmployeeCursor
		FETCH NEXT FROM EmployeeCursor INTO @employeeName, @townNameInsideCycle;
		WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @townName = @townNameInsideCycle
				BEGIN
					SET @currentSequence = @currentSequence + @employeeName + ', ';
				END
				FETCH NEXT FROM EmployeeCursor INTO @employeeName, @townNameInsideCycle;
			END		
		
		CLOSE EmployeeCursor;
		DEALLOCATE EmployeeCursor;

		SET @currentSequence = RTRIM(@currentSequence);
		SET @currentSequence = SUBSTRING(@currentSequence, 1, LEN(@currentSequence) - 1);
		PRINT @currentSequence;
		SET @counter = @counter + 1;
		FETCH NEXT FROM TownCursor INTO @townName;
	END

CLOSE TownCursor
DEALLOCATE TownCursor

--10. Define a .NET aggregate function StrConcat that takes as input a sequence of
--  strings and return a single string that consists of the input strings separated by ','.

--Run this to correctly configure SQL Server.
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

-- Go to TelerikAcademy - Programmability - Assemblies. Right Click and select new
-- assembly. Then specify the correct path to the .dll file - it is in the bin/debug folder
-- of the VS project in the homework.

--Concatenation with default separator as comma.
CREATE AGGREGATE STRCONCAT (@input nvarchar(200))
RETURNS nvarchar(max)
EXTERNAL NAME [ConcatenationFunction].[ConcatenationFunction.Concatenation]
GO

SELECT dbo.STRCONCAT(FirstName + ' ' + LastName) FROM Employees

--Concatenation with custom separator.
CREATE AGGREGATE CUSTOMSTRCONCAT (@input nvarchar(200), @seperator nvarchar(10))
RETURNS nvarchar(max)
EXTERNAL NAME [ConcatenationFunction].[ConcatenationFunction.CustomConcatenation]
GO

SELECT dbo.CUSTOMSTRCONCAT(FirstName + ' ' + LastName, ':') FROM Employees