
--1. Write an SQL query to find the names and salaries of the employees that take the minimal salary in the company.
USE TelerikAcademy;
SELECT e.FirstName + ' ' + e.LastName as EmployeeName, e.Salary
FROM Employees e
WHERE e.Salary = (
	SELECT MIN(e.Salary)
	FROM Employees e);

--2. Write an SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
USE TelerikAcademy;
SELECT e.FirstName + ' ' + e.LastName as EmployeeName, e.Salary
FROM Employees e
WHERE e.Salary 
	BETWEEN (
		SELECT MIN(e.Salary)
		FROM Employees e) 
	AND (
		SELECT (MIN(e.Salary)*110)/100
		FROM Employees e);

--3. Write an SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
USE TelerikAcademy;
SELECT e.FirstName + ' ' + e.LastName as 'Employee Name', e.Salary, d.Name as 'Department Name'
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (
	SELECT MIN(emp.Salary) 
	FROM Employees emp
	WHERE emp.DepartmentID = e.DepartmentID)
ORDER BY e.Salary;

--4. Write an SQL query to find the average salary in the department #1.
USE TelerikAcademy;
SELECT AVG(e.Salary) as AverageSalary, d.Name as DepartmentName, d.DepartmentID
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = (
	SELECT TOP 1 d.DepartmentID
	FROM Departments d
	ORDER BY d.DepartmentID)
GROUP BY d.Name, d.DepartmentID

--5. Write an SQL query to find the average salary in the "Sales" department.
USE TelerikAcademy;
SELECT AVG(e.Salary) as AverageSalary, d.Name as DepartmentName
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name;

--6. Write an SQL query to find the number of employees in the "Sales" department.
USE TelerikAcademy;
SELECT COUNT(e.EmployeeID) as EmployeesCount, d.Name as DepartmentName
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name;

--7. Write an SQL query to find the number of all employees that have manager.
USE TelerikAcademy;
SELECT COUNT(e.EmployeeID) as 'Number of Employees having a Manager'
FROM Employees e
WHERE e.ManagerID IS NOT NULL;

--8. Write an SQL query to find the number of all employees that have no manager.
USE TelerikAcademy;
SELECT COUNT(e.EmployeeID) as 'Number of Employees that does not have a Manager'
FROM Employees e
WHERE e.ManagerID IS NULL;

--9. Write an SQL query to find all departments and the average salary for each of them.
USE TelerikAcademy;
SELECT CAST(ROUND(AVG(e.Salary), 2) AS DECIMAL(15,2)) as 'Average Salary', d.Name as 'Department Name'
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY 'Average Salary' DESC;

--10. Write an SQL query to find the count of all employees in each department and for each town.
USE TelerikAcademy;
SELECT COUNT(e.EmployeeID) as 'Employees Count', d.Name as 'Department Name', t.Name as 'Town Name'
FROM Employees e 
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t on a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY 'Employees Count' DESC;

--11. Write an SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
USE TelerikAcademy;
SELECT	m.FirstName + ' ' + m.LastName AS 'Manager Name',
		COUNT(e.EmployeeID) AS [Employees Count]
FROM Employees m INNER JOIN Employees e ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(e.EmployeeID) = 5;

--12. Write an SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
USE TelerikAcademy;
SELECT	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS 'Manager Name',
		e.FirstName + ' ' + e.LastName AS 'Employee Name'
FROM Employees m RIGHT JOIN Employees e ON m.EmployeeID = e.ManagerID

--13. Write aí SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
USE TelerikAcademy;
SELECT	e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName AS 'Employee Name'
FROM Employees e
WHERE LEN(e.LastName) = 5;

--14. Write an SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
USE TelerikAcademy;
SELECT CONVERT(VARCHAR(10), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(8), GETDATE(), 108) AS [Date and Time]

--15. Write an SQL statement to create a table Users. Users should have username, password, full name and last login time.
GO
USE TelerikAcademy
IF EXISTS (
	SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = 'Users')
DROP TABLE Users
CREATE TABLE Users (
	Username VARCHAR(50),
	Pass VARCHAR(50),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	LastLogin datetime
	CONSTRAINT PK_Users PRIMARY KEY(Username),
	CONSTRAINT Pass CHECK (LEN(Pass)>=5))

--16. Write an SQL statement to create a view that displays the users from the Users table that have been in the system today.
GO
USE TelerikAcademy
IF EXISTS (
	SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS 
	WHERE TABLE_NAME = 'AllUsersFromToday')
DROP VIEW AllUsersFromToday

GO
CREATE VIEW AllUsersFromToday AS
	SELECT *
	FROM Users u
	WHERE YEAR(u.LastLogin) = YEAR(GETDATE())
	AND MONTH(u.LastLogin) = MONTH(GETDATE())
	AND DAY(u.LastLogin) = DAY(GETDATE());

----17. Write an SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
GO
USE TelerikAcademy
IF EXISTS (
	SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = 'Groups')
DROP TABLE Groups

CREATE TABLE Groups (
	ID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL UNIQUE, 
	CONSTRAINT PK_Groups PRIMARY KEY(ID))

--18. Write an SQL statement to add a column GroupID to the table Users.
GO
USE TelerikAcademy
ALTER TABLE Users
ADD GroupId INT FOREIGN KEY REFERENCES Groups(ID)

--19. Write SQL statements to insert several records in the Users and Groups tables.
GO
USE TelerikAcademy
INSERT INTO Groups (ID, Name)
VALUES	(1, 'Men'),
		(2, 'Women'),
		(3, 'Children')

GO
USE TelerikAcademy
INSERT INTO Users
VALUES	('Samurai1', '11111', 'Sam1', 'Nin1', GetDate(), 1),
		('Samurai2', '22222', 'Sam2', 'Nin2', GetDate(), 2),
		('Samurai3', '33333', 'Sam3', 'Nin3', GetDate(), 3)

--20. Write SQL statements to update some of the records in the Users and Groups tables.
GO
USE TelerikAcademy
UPDATE Users 
SET Username = 'New User name'
WHERE Username = 'Samurai1'

--21. Write SQL statements to delete some of the records from the Users and Groups tables.
GO
USE TelerikAcademy
DELETE Users
WHERE Username = 'Samurai2'

GO
USE TelerikAcademy
DELETE Groups
WHERE Name = 'Women'

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
GO
USE TelerikAcademy
INSERT INTO  Users (FirstName, LastName, Username, Pass, LastLogin)
	(SELECT e.FirstName, e.LastName, 
			LOWER(LEFT(e.FirstName, 1)) + 
			LOWER(LEFT(e.LastName, 1)), 
			e.EmployeeID + '12345', NULL
	FROM Employees e)

--23. Write aí SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
GO
USE TelerikAcademy
UPDATE Users
SET Pass = NULL
WHERE DATEDIFF(day, LastLogin, '2010-3-10 00:00:00') > 0

--24. Write an SQL statement that deletes all users without passwords (NULL password).
GO
USE TelerikAcademy
DELETE Users
WHERE Pass IS  NULL

--25. Write an SQL query to display the average employee salary by department and job title.
USE TelerikAcademy
SELECT AVG(e.Salary), e.JobTitle , d.Name 
FROM Employees e JOIN Departments d ON d.DepartmentID =e.DepartmentID
GROUP BY e.JobTitle, d.Name;

--26. Write an SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
USE TelerikAcademy
SELECT	ROUND(MIN(e.Salary), 2) AS [MinSalary],
        MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee Name],
        d.Name AS [Department],
        e.JobTitle
FROM Employees e JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY [MinSalary]

--27. Write a SQL query to display the town where maximal number of employees work.
USE TelerikAcademy
SELECT TOP 1 COUNT(a.TownID) AS [Employees Count], t.Name as 'Town Name'
FROM Addresses a 
	JOIN Employees e ON e.AddressID = a.AddressID
	JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name 
ORDER BY [Employees Count] DESC;

--28. Write an SQL query to display the number of managers from each town.
USE TelerikAcademy
SELECT t.Name AS [Town], COUNT(DISTINCT m.EmployeeID) AS [No. of Managers]
FROM Employees e, Employees m, Addresses a, Towns t
WHERE e.ManagerID = m.EmployeeID AND
	  m.AddressID = a.AddressID AND
	  a.TownID = t.TownID
GROUP BY t.Name

--29. Write an SQL script to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours (
    WorkReportId int IDENTITY,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    CONSTRAINT PK_Id PRIMARY KEY(WorkReportId),
    CONSTRAINT FK_Employees_WorkHours 
		FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId)
) 

-- INSERT
GO
DECLARE @counter int;
SET @counter = 20;
WHILE @counter > 0
BEGIN
    INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
    VALUES (@counter, GETDATE(), 'TASK: ' + CONVERT(varchar(10), @counter), @counter)
    SET @counter = @counter - 1
END

--- UPDATE
UPDATE WorkHours
SET Comments = 'This homework makes me sick'
WHERE [Hours] > 10

--- DELETE
DELETE FROM WorkHours
WHERE EmployeeId IN (1, 3, 5, 7, 13)

--- TABLE: WorkHoursLogs
CREATE TABLE WorkHoursLogs (
    WorkLogId int,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    [Action] nvarchar(50) NOT NULL,
    CONSTRAINT FK_Employees_WorkHoursLogs
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId),
    CONSTRAINT [CC_WorkReportsLogs] CHECK ([Action] IN ('Insert', 'Delete', 'DeleteUpdate', 'InsertUpdate'))
) 
GO

--- TRIGGER FOR INSERT
CREATE TRIGGER tr_InsertWorkReports ON WorkHours 
FOR INSERT
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Insert'
    FROM inserted
GO

--- TRIGGER FOR DELETE
CREATE TRIGGER tr_DeleteWorkReports ON WorkHours 
FOR DELETE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Delete'
    FROM deleted
GO

--- TRIGGER FOR UPDATE
CREATE TRIGGER tr_UpdateWorkReports ON WorkHours 
FOR UPDATE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'InsertUpdate'
    FROM inserted

INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'DeleteUpdate'
    FROM deleted
GO

--- TEST TRIGGERS
--TRUNCATE TABLE WorkHoursLogs
DELETE FROM WorkHoursLogs

INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
	VALUES (25, GETDATE(), 'TASK: 25', 25)

DELETE FROM WorkHours
WHERE EmployeeId = 25

UPDATE WorkHours
SET Comments = 'Updated'
WHERE EmployeeId = 2
    


--30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--At the end rollback the transaction.

BEGIN TRAN
    ALTER TABLE Departments
    DROP CONSTRAINT FK_Departments_Employees

    GO
    DELETE e 
	FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
ROLLBACK TRAN


--31. Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN

--32. Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
USE TelerikAcademy

BEGIN TRAN
	SELECT *  
	INTO  #TempTable_EmployeesProjects
	FROM EmployeesProjects

	DROP TABLE EmployeesProjects

	SELECT * 
	INTO EmployeesProjects
	FROM #TempTable_EmployeesProjects
ROLLBACK TRAN