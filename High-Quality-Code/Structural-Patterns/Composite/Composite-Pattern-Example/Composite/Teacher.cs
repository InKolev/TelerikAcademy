using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Teacher : PersonComponent
    {
        public Teacher(string name)
            : base(name) 
        {
            this.Students = new List<PersonComponent>();
        }

        private List<PersonComponent> Students { get; set; }

        public override void Add(PersonComponent component)
        {
            this.Students.Add(component);
        }

        public override void Remove(PersonComponent component)
        {
            this.Students.Remove(component);
        }

        public override void DisplayHierarchy(int depth)
        {
            Console.WriteLine(String.Format("{0} {1}: {2}",
                new String('-', depth),
                this.GetType().Name,
                this.Name));

            foreach(var person in this.Students)
            {
                person.DisplayHierarchy(depth + 4);
            }
        }

    }
}
