using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Ivan", 23);
            var type = person.GetType();
         
            Console.WriteLine(person.GetType().Name.Equals("Person"));
        }
    }
}
