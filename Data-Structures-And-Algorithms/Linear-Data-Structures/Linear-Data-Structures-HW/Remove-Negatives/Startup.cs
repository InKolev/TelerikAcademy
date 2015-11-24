using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Negatives
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var values = new List<int>() { 2, 2, 3, 3, 2, 3, -1, -2, 3, 3, 3, -5, -10, 3, 3, -12, 4, 3, -15, 3, 1, 1 };

            var result = values
                .Where(x => x >= 0)
                .Select(x => x)
                .ToList();

            foreach (var value in values)
            {
                Console.Write("{0}, ", value);
            }

            Console.WriteLine();

            foreach (var value in result)
            {
                Console.Write("{0}, ", value);
            }
        }
    }
}
