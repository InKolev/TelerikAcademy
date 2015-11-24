namespace First_50_Members
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main(string[] args)
        {
            Queue<int> line = new Queue<int>();

            var length = 50;
            var n = 2;

            line.Enqueue(n);

            var previousFirst = n;
            var firstMember = 0;
            var secondMember = 0;
            var thirdMember = 0;

            for (int i = 1; i < length-2; i+=3)
            {
                firstMember = previousFirst + 1;
                secondMember = (2 * previousFirst) + 1;
                thirdMember = previousFirst + 2;

                previousFirst = firstMember;

                line.Enqueue(firstMember);
                line.Enqueue(secondMember);
                line.Enqueue(thirdMember);
            }

            for (int i = 0; i < length - 2; i++)
            {
                Console.Write("{0}, ", line.Dequeue());
            }
        }
    }
}
