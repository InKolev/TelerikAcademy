using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        public static void Main(string[] args)
        {
            Elha(30, 1, '*', ' ', new StringBuilder());
        }

        public static void Elha(int height, int width, char symbol, char space, StringBuilder result)
        {
            if ((height - width / 2) <= 0)
            {
                Console.WriteLine(result.ToString());
                return;
            }

            result.Append(new String(space, (height - width / 2)));
            result.Append(new String(symbol, (width * 2)));
            result.Append(Environment.NewLine);

            Elha(height -= 1, width += 2, symbol, space, result);
        }
    }
}
