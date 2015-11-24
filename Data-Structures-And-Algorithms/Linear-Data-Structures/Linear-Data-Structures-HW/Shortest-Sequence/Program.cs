using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortest_Sequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayShortestSequence(5, 16);
            DisplayShortestSequence(5, 20);
            DisplayShortestSequence(1, 6);
        }

        private static void DisplayShortestSequence(int start, int target)
        {
            var sequence = new Queue<int>();

            while (start <= target)
            {
                sequence.Enqueue(target);

                if (target / 2 >= start)
                {
                    if (target % 2 == 0)
                    {
                        target /= 2;
                    }
                    else
                    {
                        target--;
                    }
                }
                else
                {
                    if (target - 2 >= start)
                    {
                        target -= 2;
                    }
                    else
                    {
                        target--;
                    }
                }
            }

            Console.WriteLine(string.Join(" -> ", sequence.Reverse()));
        }
    }
}
