namespace Count_Occurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var occurencesCount = list.GroupBy(x => x).ToDictionary(k => k.Key, v => v.Count());

            foreach (var pair in occurencesCount)
            {
                Console.WriteLine("Key{{{0}}} --> Value{{{1}}}", pair.Key, pair.Value);
            }
        }
    }
}
