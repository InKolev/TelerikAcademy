

namespace Entity_Framework_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class EFDemo
    {
        static void Main()
        {
            //Expression<Func<Project, bool>> expression = pr => pr.Name == "Ivan";
            //Console.WriteLine(expression.Name);
            //Console.WriteLine(expression.Body);
            //Console.WriteLine(expression.Parameters);
            //Console.WriteLine(expression.ReturnType);
            //Console.WriteLine(expression.TailCall);

            var dbEntities = new TelerikAcademyEntities();

            //string nativeSqlQuery = "SELECT count(*) FROM dbo.Employees";
            //var queryResult = dbEntities.Database.SqlQuery<int>(nativeSqlQuery);
            //int customersCount = queryResult.FirstOrDefault();

            //Console.WriteLine(customersCount);

            //var emp =
            //    dbEntities.Employees
            //    .Select(e => new
            //    {
            //        FullName = e.FirstName + " " + e.LastName,
            //        Town = e.Address.Town.Name,
            //        Address = e.Address.AddressText 
            //    });

            //var employeeGroups =
            //    dbEntities.Employees
            //    .GroupBy(emp => emp.Department.Name)
            //    .ToList();

            //foreach (var employeeGroup in employeeGroups)
            //{
            //    Console.WriteLine(employeeGroup.Key);

            //    foreach (var employee in employeeGroup)
            //    {
            //        Console.WriteLine(employee.FirstName);
            //    }

            //    Console.WriteLine(new String('*', 60));
            //}

            // Workaround hacks.
            dbEntities.Employees.GroupBy(e => true).Select(gr => new
            {
                EmployeesCount = gr.Count()
            });


            dbEntities.Employees.Select(e => new
            {
                Name = e.FirstName + " " + e.LastName,
                Age = e.HireDate
            });
            //OR
            var empFiltered = dbEntities
                 .Employees
                 .Select(e => new
                 {
                     e.FirstName,
                     e.HireDate
                 })
                 .ToList();
        }
    }
}
