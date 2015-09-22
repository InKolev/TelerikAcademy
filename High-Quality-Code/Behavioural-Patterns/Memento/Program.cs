using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Consider storing the statsMemory directly inside the human object for easy access and cleaner code. 
            // Consider that this also increases coupling.

            var statsMemory = new BodyStatisticsMemory();
            var human = new HumanBody(174.00, 74.00, 8.00);

            statsMemory.Add(human.Save());
            Console.WriteLine(human.ToString());

            human.Eat();
            human.Grow();
            human.LoseFat();

            statsMemory.Add(human.Save());
            Console.WriteLine(human.ToString());

            human.Eat();
            human.Grow();
            human.LoseFat();

            statsMemory.Add(human.Save());
            Console.WriteLine(human.ToString());

            human.Restore(statsMemory.Previous());
            Console.WriteLine(human.ToString());

            human.Restore(statsMemory.Previous());
            Console.WriteLine(human.ToString());

            human.Restore(statsMemory.Next());
            Console.WriteLine(human.ToString());
        }
    }
}
