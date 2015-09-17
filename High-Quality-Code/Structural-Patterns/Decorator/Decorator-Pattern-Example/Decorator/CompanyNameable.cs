using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class CompanyNameable : Decorator
    {
        public CompanyNameable(FactoryItem factoryItem, string companyName)
            : base(factoryItem)
        {
            this.CompanyName = companyName;
        }

        public string CompanyName { get; set; }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("     Company Name: {0}", this.CompanyName);
        }
    }
}
