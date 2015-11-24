using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Sequence
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var values = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3, 1, 1 };

            values.Sort();

            foreach (var value in values)
            {
                Console.Write("{0} ", value);
            }
        }
    }
}
