using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Visitor
{
    internal class TaxVisitor : IVisitor
    {
        public void Visit(RealEstateOwner owner)
        {
            Console.WriteLine("Tax visitor is doing some calculations...");
            Thread.Sleep(1000);

            foreach (var property in owner.Properties)
            {
                if (property.GetType().Name.Equals("Monastery"))
                {
                    owner.CreditAmount += 0.00M;
                }
                else if (property.GetType().Name.Equals("Castle"))
                {
                    if (property.AreaSquareMetters >= 520 && property.AreaSquareMetters <= 2080)
                    {
                        owner.CreditAmount += 1260.00M;
                    }
                    else if (property.AreaSquareMetters > 2080)
                    {
                        owner.CreditAmount += 15060.00M;
                    }
                    else
                    {
                        owner.CreditAmount += (property.AreaSquareMetters * 1.20M);
                    }
                }
                else
                {
                    owner.CreditAmount += (property.AreaSquareMetters * 0.80M);
                }
            }
        }
    }
}
