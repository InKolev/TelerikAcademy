USE TelerikAcademy;

SELECT e.FirstName as EmployeeName, m.FirstName as ManagerName
FROM Employees m RIGHT OUTER JOIN Employees e ON e.ManagerID = m.EmployeeID;