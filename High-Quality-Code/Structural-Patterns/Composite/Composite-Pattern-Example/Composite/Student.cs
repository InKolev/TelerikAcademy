using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Student : PersonComponent
    {
        public Student(string name)
            : base(name) { }

        public override void Add(PersonComponent component)
        {
            Console.WriteLine("Class of type \"Student\" is not able to manage other Person Components.");
        }

        public override void Remove(PersonComponent component)
        {
            Console.WriteLine("Class of type \"Student\" is not able to manage other Person Components.");
        }

        public override void DisplayHierarchy(int depth)
        {
            Console.WriteLine(String.Format("{0} {1}: {2}", 
                new String('-', depth), 
                this.GetType().Name, 
                this.Name));
        }
    }
}
