using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Minister : PersonComponent
    {
        public Minister(string name) 
            : base(name)
        {
            this.Directors = new List<PersonComponent>();
        }

        private List<PersonComponent> Directors { get; set; }


        public override void Add(PersonComponent component)
        {
            this.Directors.Add(component);
        }

        public override void Remove(PersonComponent component)
        {
            this.Directors.Remove(component);
        }

        public override void DisplayHierarchy(int depth)
        {
            Console.WriteLine(String.Format("{0} {1}: {2}",
               new String('-', depth),
               this.GetType().Name,
               this.Name));

            foreach (var person in this.Directors)
            {
                person.DisplayHierarchy(depth + 4);
            }
        }

    }
}
