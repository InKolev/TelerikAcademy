using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class BusinessCardsFactory
    {
        public static void Main(string[] args)
        {
            RunSample();
        }

        public static void RunSample()
        {
            var businessCard = new BusinessCard("Aneliya Koleva", "+359888003801");
            businessCard.Display();
            Console.WriteLine(new String('*', 90));

            var businessCardWithFullFeatures =
                new Addressable(
                    new Descriptable(
                        new CompanyNameable(
                            new BusinessCard("Ivan Nikolaev Kolev", "+359887482485"),
                            "Stark Industries"),
                            "This business card suits as an example of the Decorator pattern."),
                            "Rue de Rivoli, 180");
            businessCardWithFullFeatures.Display();
            Console.WriteLine(new String('*', 90));
        }
    }
}
