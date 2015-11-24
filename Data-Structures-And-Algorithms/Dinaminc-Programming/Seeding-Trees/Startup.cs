namespace Seeding_Trees
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static long[,,,,] memo = new long[11, 11, 11, 11, 5];
        static int ATreesCount;
        static int BTreesCount;
        static int CTreesCount;
        static int DTreesCount;

        static void Main(string[] args)
        {
            memo[0, 0, 0, 0, 0] = 1;
            memo[0, 0, 0, 0, 1] = 1;
            memo[0, 0, 0, 0, 2] = 1;
            memo[0, 0, 0, 0, 3] = 1;

            ATreesCount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            BTreesCount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            CTreesCount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            DTreesCount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int invalidTreeType = 4;

            long count = SeedTreesRecursive(ATreesCount, BTreesCount, CTreesCount, DTreesCount, invalidTreeType);

            Console.WriteLine(count);
        }

        private static long SeedTreesRecursive(int a, int b, int c, int d, int lastTreeTypeSeeded)
        {
            long count = 0;

            if (a + b + c + d == 0)
            {
                return 1;
            }

            if (memo[a, b, c, d, lastTreeTypeSeeded] != 0)
            {
                return memo[a, b, c, d, lastTreeTypeSeeded];
            }

            if (a > 0 && lastTreeTypeSeeded != 0)
            {
                count += SeedTreesRecursive(a - 1, b, c, d, 0);
            }

            if (b > 0 && lastTreeTypeSeeded != 1)
            {
                count += SeedTreesRecursive(a, b - 1, c, d, 1);
            }

            if (c > 0 && lastTreeTypeSeeded != 2)
            {
                count += SeedTreesRecursive(a, b, c - 1, d, 2);
            }

            if (d > 0 && lastTreeTypeSeeded != 3)
            {
                count += SeedTreesRecursive(a, b, c, d - 1, 3);
            }

            memo[a, b, c, d, lastTreeTypeSeeded] = count;

            return count;
        }
    }
}