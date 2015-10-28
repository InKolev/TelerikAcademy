USE TelerikAcademy;

SELECT (Employees.FirstName + '.' + Employees.LastName) + '@telerik.com' as 'Full Email Address'
FROM Employees;