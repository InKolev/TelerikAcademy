USE TelerikAcademy;

SELECT e.Salary as 'Salary Group'
FROM Employees e
GROUP BY e.Salary
ORDER BY e.Salary;