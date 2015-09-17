using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Decorator : FactoryItem
    {
        protected Decorator(FactoryItem factoryItem)
        {
            this.FactoryItem = factoryItem;
        }

        protected FactoryItem FactoryItem { get; set; }

        public override void Display()
        {
            this.FactoryItem.Display();
        }
    }
}
