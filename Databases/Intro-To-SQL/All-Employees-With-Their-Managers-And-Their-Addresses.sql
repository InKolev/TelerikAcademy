USE TelerikAcademy;

SELECT e.FirstName as EmployeeName, a.AddressText as Address, m.FirstName as ManagerName
FROM Employees e 
	INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Addresses a ON e.AddressID = a.AddressID;