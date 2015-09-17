using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Addressable : Decorator
    {
        public Addressable(FactoryItem factoryItem, string address)
            : base(factoryItem)
        {
            this.Address = address;
        }

        public string Address { get; set; }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("     Address: {0}", this.Address);
        }
    }
}
