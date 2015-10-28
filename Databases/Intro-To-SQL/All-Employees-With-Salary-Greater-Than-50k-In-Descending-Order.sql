USE TelerikAcademy;

SELECT e.FirstName, e.Salary
FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC;