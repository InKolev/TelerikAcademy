USE TelerikAcademy;

SELECT e.FirstName + ' ' + e.LastName as Name
FROM Employees e
WHERE e.LastName LIKE '%ei%';