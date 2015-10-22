-- 01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
-- Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.

CREATE DATABASE BankSystem

CREATE TABLE [BankSystem].[dbo].[People](
	PersonId INT IDENTITY,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	SSN NVARCHAR(50)
	CONSTRAINT PK_People PRIMARY KEY(PersonId)
)

CREATE TABLE [BankSystem].[dbo].[Accounts](
	AccountId INT IDENTITY,
	PersonId INT NOT NULL,
	Balance MONEY NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
	CONSTRAINT FK_Accounts_People_PersonID FOREIGN KEY (PersonID) 
	REFERENCES [BankSystem].[dbo].[People](PersonID)
)

INSERT INTO [BankSystem].[dbo].[People] (FirstName, LastName, SSN)
VALUES 
	('Albena', 'Georgieva', '410965744'),
	('Petar', 'Andonov', '130700864'),
	('Georgi', 'Kostov', '087443965'),
	('Elena', 'Minkova', '774861001'),
	('Maria', 'Hristova', '621035558')

INSERT INTO [BankSystem].[dbo].[Accounts](PersonId, Balance)
VALUES
	(1, 25310.41),
	(2, 30122.00),
	(3, 1200.14),
	(4, 10885.72),
	(5, 31002.11)

GO
CREATE PROCEDURE dbo.usp_SelectFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM [BankSystem].[dbo].[People]
GO

-- 02. Create a stored procedure that accepts a number as a parameter and returns all persons 
-- who have more money in their accounts than the supplied number.

--Create procedure

GO
CREATE PROCEDURE dbo.usp_GetPersonsWithMoreMoneyInTheirAccounts(@minMoney MONEY = 0)
AS
	SELECT p.FirstName, p.LastName, a.Balance
	FROM [BankSystem].[dbo].[People] p
		JOIN [BankSystem].[dbo].[Accounts] a
			ON p.PersonId = a.PersonId
	WHERE a.Balance > @minMoney
GO

--Test the procedure

EXEC dbo.usp_GetPersonsWithMoreMoneyInTheirAccounts @minMoney = 30000

-- 03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum.
-- Write a SELECT to test whether the function works as expected.

GO
CREATE FUNCTION dbo.usp_CalculateSumWithInterest(@sum MONEY, @yearInterest DECIMAL, @months INT)
RETURNS MONEY
AS
	BEGIN
		RETURN (@sum + @sum * (@yearInterest / 100) * @months / 12)
	END
GO

DECLARE @sum MONEY = (SELECT Balance FROM [BankSystem].[dbo].[Accounts] WHERE AccountId = 1)
PRINT dbo.usp_CalculateSumWithInterest(@sum,5,5)

-- 04. Create a stored procedure that uses the function from the previous example 
-- to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.

GO
CREATE PROCEDURE dbo.usp_AddInterestForOneMonth(@accountId INT, @interest DECIMAL)
AS
	DECLARE @sum MONEY = (SELECT Balance FROM [BankSystem].[dbo].[Accounts] WHERE AccountID = @accountID)
	UPDATE [BankSystem].[dbo].[Accounts]
SET Balance = (@sum + @sum * (@interest / 100) / 12)
WHERE AccountID = @accountID
GO

EXEC dbo.usp_AddInterestForOneMonth 4, 5

-- 05. Add two more stored procedures WithdrawMoney(AccountId, money) and 
-- DepositMoney(AccountId, money) that operate in transactions.

GO	
CREATE PROCEDURE dbo.usp_WithdrawMoney(@accountId INT, @money MONEY)
AS	
	DECLARE @currentBalanace MONEY = (SELECT Balance FROM [BankSystem].[dbo].[Accounts] WHERE AccountID = @accountID)
	IF(@money<=@currentBalanace)
		BEGIN
			UPDATE [BankSystem].[dbo].[Accounts]
			SET Balance = Balance-@money
			WHERE AccountID = @accountID
		END
	ELSE
		BEGIN
			PRINT 'Not enough money in account'
		END 
GO

GO
CREATE PROCEDURE dbo.usp_DepositMoney(@accountId INT, @money MONEY)
AS
	UPDATE [BankSystem].[dbo].[Accounts]
	SET Balance = Balance+@money
	WHERE AccountID = @accountID
GO

EXEC dbo.usp_WithdrawMoney 4, 5000
EXEC dbo.usp_DepositMoney 4,5000

-- 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs table 
-- every time the sum on an account changes.

CREATE TABLE Logs(
LogID INT IDENTITY,
AccountID INT,
OldSum MONEY,
NewSum MONEY,
CONSTRAINT PK_LogID PRIMARY KEY (LogID))
GO

CREATE TRIGGER Tr_AccountUpdate
ON [BankSystem].[dbo].[Accounts]
FOR UPDATE
AS
SET NOCOUNT ON
INSERT INTO Logs
SELECT
i.AccountID,
d.Balance,
i.Balance
FROM INSERTED i, DELETED d
GO

-- 07. Define a function in the database TelerikAcademy that returns all Employee's names 
-- (first or middle or last name) and all town's names that are comprised of given set of letters.
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

USE TelerikAcademy
GO
CREATE FUNCTION ufn_CheckName (@nameToCheck NVARCHAR(50),@letters NVARCHAR(50)) RETURNS INT
AS
BEGIN
        DECLARE @i INT = 1
		DECLARE @currentChar NVARCHAR(1)
        WHILE (@i <= LEN(@nameToCheck))
			BEGIN
				SET @currentChar = SUBSTRING(@nameToCheck,@i,1)
					IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
						BEGIN  
							RETURN 0
						END
				SET @i = @i + 1
			END
        RETURN 1
END
GO


--WITH WHERE AS TABLE
SELECT e.FirstName, e.LastName,t.Name FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID=t.TownID
WHERE 
dbo.ufn_CheckName(e.FirstName,'oistmiahf') = 1 OR 
dbo.ufn_CheckName(e.LastName,'oistmiahf') = 1 OR
dbo.ufn_CheckName(t.Name,'oistmiahf') = 1

--WITH CURSOR AS PRINT
DECLARE employeeTownCursor CURSOR READ_ONLY FOR
  (SELECT e.FirstName, e.LastName, t.Name FROM Employees e
  JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID=t.TownID)

OPEN employeeTownCursor
DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50), @town NVARCHAR(50)
DECLARE @searchString NVARCHAR(50) ='oistmiahf'
FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName, @town

WHILE @@FETCH_STATUS = 0
  BEGIN
    IF(dbo.ufn_CheckName(@firstName,@searchString)=1)
		BEGIN
			PRINT 'First name: ' + @firstName
		END
	IF(dbo.ufn_CheckName(@lastName,@searchString)=1)
		BEGIN
			PRINT 'Last name: ' + @lastName
		END
	IF(dbo.ufn_CheckName(@town,@searchString)=1)
		BEGIN
			PRINT 'Town: ' + @town
		END
	FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName, @town
  END

CLOSE employeeTownCursor
DEALLOCATE employeeTownCursor

-- 08. Using database cursor write a T-SQL script that scans all employees and 
-- their addresses and prints all pairs of employees that live in the same town.

DECLARE employeeTownCursor CURSOR READ_ONLY FOR
  (SELECT e.FirstName, e.LastName, t.Name FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID=t.TownID)


OPEN employeeTownCursor
DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50), @town NVARCHAR(50)

FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName,@town

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE employeeTownCursor1 CURSOR READ_ONLY FOR
		(SELECT e.FirstName, e.LastName, t.Name FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID=t.TownID)
	OPEN employeeTownCursor1
		DECLARE @firstName1 NVARCHAR(50), @lastName1 NVARCHAR(50), @town1 NVARCHAR(50)
		FETCH NEXT FROM employeeTownCursor1 INTO @firstName1, @lastName1,@town1
			WHILE @@FETCH_STATUS = 0
			BEGIN
		
				IF(@town = @town1)
				BEGIN
					PRINT @lastname1 + ': ' + @firstname + ' ' +  @lastname + ' ' + @town + ' ' + @firstname1 
				END

			FETCH NEXT FROM employeeTownCursor1 INTO @firstName1, @lastName1,@town1
			END

	CLOSE employeeTownCursor1
	DEALLOCATE employeeTownCursor1

FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName,@town
END

CLOSE employeeTownCursor
DEALLOCATE employeeTownCursor

--10.Define a .NET aggregate function
IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO