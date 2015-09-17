using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class PersonComponent
    {
        protected PersonComponent(string name)
        {
            this.Name = name;
        }

        protected string Name { get; set; }

        public abstract void Add(PersonComponent component);

        public abstract void Remove(PersonComponent component);

        public abstract void DisplayHierarchy(int depth);
    }
}
