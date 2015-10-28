USE TelerikAcademy;

SELECT (Employees.FirstName + ' ' + Employees.MiddleName + ' ' + Employees.LastName) as 'Full Name'
FROM Employees
WHERE Employees.MiddleName IS NOT NULL;