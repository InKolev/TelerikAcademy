namespace Extract_Strings
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
            var array = new string[6] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var result = array
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, v => v.Count())
                .Where(x => x.Value % 2 != 0)
                .Select(x => x.Key)
                .ToArray();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}