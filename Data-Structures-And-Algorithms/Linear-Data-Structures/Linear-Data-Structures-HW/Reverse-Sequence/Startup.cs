namespace Reverse_Sequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main(string[] args)
        {
            var sequence = "1 2 3 4 5 6 7 8 9 10";
            var numbers = sequence.Split(' ');
            var length = numbers.Length;

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < length; i++)
            {
                stack.Push(numbers[i]);
            }

            var numbersReversed = new string[length];

            for (int i = 0; i < length; i++)
            {
                numbersReversed[i] = stack.Pop();

                Console.Write("{0} ", numbersReversed[i]);
            }
        }
    }
}
