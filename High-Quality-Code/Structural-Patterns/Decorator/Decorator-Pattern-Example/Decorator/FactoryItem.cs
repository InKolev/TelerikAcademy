using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal abstract class FactoryItem
    {
        public string PhoneNumber { get; set; }

        public abstract void Display();
    }
}
