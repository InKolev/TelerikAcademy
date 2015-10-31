namespace Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var values = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var majorant = values
                .GroupBy(x => x)
                .ToDictionary(k => k.Key, v => v.Count())
                .First(x => x.Value >= values.Count / 2 + 1)
                .Key;

            Console.WriteLine("Majorant --> {0}", majorant);
        }
    }
}
