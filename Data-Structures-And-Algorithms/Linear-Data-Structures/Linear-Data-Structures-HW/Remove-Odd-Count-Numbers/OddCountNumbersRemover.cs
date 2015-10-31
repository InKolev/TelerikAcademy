using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Odd_Count_Numbers
{
    public class OddCountNumbersRemover
    {
        public IEnumerable<int> ValuesForRemoval { get; set; }

        public void Remove()
        {
            var list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Console.WriteLine("Original list");
            foreach (var value in list)
            {
                Console.Write("{0} ", value);
            }

            this.ValuesForRemoval = list
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, v => v.Count())
                .Where(x => x.Value % 2 != 0)
                .Select(x => x.Key);

            list.RemoveAll(ForRemoval);

            Console.WriteLine("\nList after removal");
            foreach (var value in list)
            {
                Console.Write("{0} ", value);
            }
        }

        private bool ForRemoval(int number)
        {
            foreach(var value in this.ValuesForRemoval)
            {
                if(number == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
