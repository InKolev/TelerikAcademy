using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager("Mr. Manager");
            var employee = new Employee("Greg Plitt", manager);

            manager.Add(employee);
            manager.Add(new Employee("Ivan Ivanov", manager));
            manager.Add(new Employee("Manya Maneva", manager));
            manager.Add(new Employee("Peter Petrov", manager));
            manager.Add(new Employee("Nikolay Nikolov", manager));
            manager.Add(new Employee("Brad Bradanov", manager));

            employee.Send(new Message("Hello, my friend.", employee.Name, "Nikolay Nikolov"));
            employee.SendToAll(new Message("We have a meeting at 9:00 AM in the big hall. Urgent!", employee.Name));
        }
    }
}
