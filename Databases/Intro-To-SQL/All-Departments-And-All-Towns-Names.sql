USE TelerikAcademy;

SELECT d.Name
FROM Departments d
UNION
SELECT t.Name
FROM Towns t
ORDER BY d.Name;