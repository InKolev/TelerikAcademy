using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class RealEstateOwner
    {
        public RealEstateOwner(string name)
        {
            this.Properties = new List<IRealEstate>();
        }

        public ICollection<IRealEstate> Properties { get; set; }

        public string Name { get; set; }

        public decimal CreditAmount { get; set; } = 0M;

        public void BuyProperty(IRealEstate property)
        {
            this.Properties.Add(property);
        }

        public void SellProperty(IRealEstate property)
        {
            this.Properties.Remove(property);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
