USE TelerikAcademy;

SELECT e.FirstName as EmployeeName, m.FirstName as ManagerName
FROM Employees e LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID;