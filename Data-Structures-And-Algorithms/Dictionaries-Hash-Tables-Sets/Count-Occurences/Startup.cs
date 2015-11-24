namespace Count_Occurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main(string[] args)
        {
            double[] array = new double[9] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var result = array.GroupBy(x => x).OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Count());

            foreach (var pair in result)
            {
                if (pair.Value == 1)
                {
                    Console.WriteLine("Value: {0} --> {1} time", pair.Key, pair.Value);
                }
                else
                {
                    Console.WriteLine("Value: {0} --> {1} times", pair.Key, pair.Value);
                }
            }
        }
    }
}