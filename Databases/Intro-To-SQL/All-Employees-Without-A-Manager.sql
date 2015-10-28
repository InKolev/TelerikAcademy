USE TelerikAcademy;

SELECT e.FirstName, e.ManagerID
FROM Employees e
WHERE e.ManagerID IS NULL;