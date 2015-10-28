using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_NET_Telerik_Example
{
    public class Program
    {

        static void Main(string[] args)
        {
            string querySelectEmployeesCount = 
                "SELECT COUNT(*) " + 
                "FROM Employees";

            string querySelectTheHighestSalary = 
                "SELECT MAX(Salary) " +
                "FROM Employees";

            string querySelectAllManagers = 
                "SELECT m.FirstName + ' ' + m.LastName as [Manager Name] " +
                "FROM Employees m JOIN Employees e ON m.EmployeeID = e.ManagerID " +
                "GROUP BY m.FirstName + m.LastName";

            string querySelectFirstDepartment = 
                "SELECT d.Name " + 
                "FROM Departments d " + 
                "ORDER BY d.DepartmentID";

            //ConnectionStringSettings dbConnectionString = ConfigurationManager.ConnectionStrings["MSSQLDB"];
            //SqlConnection dbConnection = new SqlConnection(dbConnectionString.ConnectionString);

            SqlConnection dbConnection = new SqlConnection("Server=IKOLEV-PC;Database=TelerikAcademy;Integrated Security=true");
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command;

                command = new SqlCommand(querySelectEmployeesCount, dbConnection);
                int employeesCount = (int) command.ExecuteScalar();

                command = new SqlCommand(querySelectTheHighestSalary, dbConnection);
                decimal highestSalary = (decimal) command.ExecuteScalar();

                command = new SqlCommand(querySelectFirstDepartment, dbConnection);
                string firstDepartment = (string) command.ExecuteScalar();

                command = new SqlCommand(querySelectAllManagers, dbConnection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine(reader["Manager Name"]);
                }

                Console.WriteLine("Employees Count: {0}", employeesCount);
                Console.WriteLine("Highest Salary: {0}", highestSalary);
                Console.WriteLine("First department: {0}", firstDepartment);

            }
        }
    }
}
