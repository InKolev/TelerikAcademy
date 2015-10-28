USE TelerikAcademy;

SELECT e.FirstName, e.Salary
FROM Employees e
WHERE e.Salary BETWEEN 20000 AND 30000;