using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class BusinessCard : FactoryItem
    {
        public BusinessCard(string owner, string phoneNumber)
        {
            this.Owner = owner;
            this.PhoneNumber = phoneNumber;
        }

        public string Owner { get; set; }

        public override void Display()
        {
            Console.WriteLine("Business Card: ");
            Console.WriteLine("     Owner: {0}", this.Owner);
            Console.WriteLine("     Phone Number: {0}", this.PhoneNumber);
        }
    }
}
