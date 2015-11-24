using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Subsequence
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var values = new List<int>() { 2, 2, 3, 3, 2, 3, 3, 3, 3, 3, 3, 4, 3, 3, 1, 1 };

            var maxSequenceLength = 0;
            var maxSequenceNumber = 0;

            var currentSequenceLength = 0;
            var currentSequenceNumber = 0;

            foreach (var value in values)
            {
                if (value == currentSequenceNumber)
                {
                    currentSequenceLength += 1;
                }
                else
                {
                    if (currentSequenceLength > maxSequenceLength)
                    {
                        maxSequenceNumber = currentSequenceNumber;
                        maxSequenceLength = currentSequenceLength;
                        currentSequenceLength = 0;
                    }
                }

                currentSequenceNumber = value;
            }

            var result = new List<int>(maxSequenceLength);

            for (int i = 0; i < maxSequenceLength; i++)
            {
                result.Add(maxSequenceNumber);
            }

            Console.WriteLine("Element: {0} --> {1} times.", maxSequenceNumber, maxSequenceLength);
        }
    }
}
