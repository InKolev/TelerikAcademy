using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Director : PersonComponent
    {
        public Director(string name)
            : base(name) 
        {
            this.Teachers = new List<PersonComponent>();
        }

        private List<PersonComponent> Teachers { get; set; }

        public override void Add(PersonComponent component)
        {
            this.Teachers.Add(component);
        }

        public override void Remove(PersonComponent component)
        {
            this.Teachers.Remove(component);
        }

        public override void DisplayHierarchy(int depth)
        {
            Console.WriteLine(String.Format("{0} {1}: {2}",
                new String('-', depth),
                this.GetType().Name,
                this.Name));

            foreach (var person in this.Teachers)
            {
                person.DisplayHierarchy(depth + 4);
            }
        }

    }
}
