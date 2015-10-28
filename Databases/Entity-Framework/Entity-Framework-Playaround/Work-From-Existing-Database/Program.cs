using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_From_Existing_Database
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

                Console.WriteLine(customersNames.Count);

                dbContext.Customers.Add(new Customer()
                    {
                        ContactName = "Ivan Kolev",
                        Phone = "0887482485",
                        Orders = new List<Order>(),
                        CustomerDemographics = new List<CustomerDemographic>()

                    });

                dbContext.SaveChanges();

                var customer = dbContext.Customers.Where(cust => cust.ContactName.Equals("Ivan Kolev"))
                    .Select(cust => cust.Phone)
                    .ToList();

                Console.WriteLine(customer);
            }
        }
    }
}
