USE TelerikAcademy;

SELECT e.FirstName as EmployeeName, m.FirstName as ManagerName
FROM Employees e INNER JOIN Employees m ON e.ManagerID = m.EmployeeID;