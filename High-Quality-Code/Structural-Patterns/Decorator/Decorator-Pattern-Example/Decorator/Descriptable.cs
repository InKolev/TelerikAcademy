using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Descriptable : Decorator
    {
        public Descriptable(FactoryItem factoryItem, string additionalInfo)
            : base(factoryItem)
        {
            this.AdditionalInfo = additionalInfo;
        }

        public string AdditionalInfo { get; set; }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("     Additional Info: {0}", this.AdditionalInfo);
        }
    }
}
