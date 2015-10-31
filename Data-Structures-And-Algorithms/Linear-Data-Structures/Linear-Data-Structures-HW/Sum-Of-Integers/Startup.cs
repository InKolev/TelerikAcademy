namespace Sum_Of_Integers
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var sequence = "1 2 3 4 5 6 7 8 9 10";
            var numbers = sequence.Split(' ').ToList();
            var sum = 0;

            foreach(var number in numbers)
            {
                sum += int.Parse(number, CultureInfo.InvariantCulture);
            }

            Console.WriteLine(sum);
        }
    }
}
