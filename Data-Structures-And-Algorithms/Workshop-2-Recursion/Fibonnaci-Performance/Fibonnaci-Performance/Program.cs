namespace Fibonnaci_Performance
{
    using System;
    using System.Numerics;

    // USE MATRIX 
    public class Program
    {
        public static int Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("1");
                return 1;
            }

            if (n < 0)
            {
                throw new Exception();
            }

            var nthFib = Fibonacci(n);
            Console.WriteLine("{0}", nthFib);
            return 0;
        }


        private static BigInteger Fibonacci(BigInteger n)
        {
            BigInteger a = BigInteger.Zero;
            BigInteger b = BigInteger.One;

            for (int i = 31; i >= 0; i--)
            {
                BigInteger d = a * (b * 2 - a);
                BigInteger e = a * a + b * b;
                a = d;
                b = e;
                if ((((BigInteger)n >> i) & 1) != 0)
                {
                    BigInteger c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a % 1000000007;
        }
    }
}
