using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_DbContext_From_Existing_DB
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new NorthEntities())
            {
                var customersNames = dbContext.Customers
                    .Select(e => e.ContactName)
                    .ToList();

                foreach (var employeeName in customersNames)
                {
                    Console.WriteLine(employeeName.ToString());
                }
            }
           
        }
    }
}
