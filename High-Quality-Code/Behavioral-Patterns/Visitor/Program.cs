using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var monastery = new Monastery(300.00M, 300000.00M);
            var castle = new Castle(621.00M, 12000000.00M);
            var house = new House(128.00M, 150000.00M);

            var owner = new RealEstateOwner("Rahzel");

            owner.BuyProperty(monastery);
            owner.BuyProperty(castle);
            owner.BuyProperty(house);

            Console.WriteLine("Credit amount before visit: {0} $.{1}", owner.CreditAmount, Environment.NewLine);

            owner.Accept(new TaxVisitor());
            Console.WriteLine("Credit amount on first visit: {0} $.{1}", owner.CreditAmount, Environment.NewLine);

            castle.AreaSquareMetters += 2000.00M;

            owner.Accept(new TaxVisitor());
            Console.WriteLine("Credit amount on second visit after castle expansion: {0} $.{1}", owner.CreditAmount, Environment.NewLine);

        }
    }
}
