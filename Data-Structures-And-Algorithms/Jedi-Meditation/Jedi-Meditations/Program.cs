namespace Jedi_Meditations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            string chars = "fasfnufnasfinqfsanaksfffasfasffafsfffefefnfmfkfkfkfmfnf";

            var result = chars.GroupBy(x => x).ToDictionary(x => x.Key, v => v.Count()).OrderByDescending(x => x.Value).FirstOrDefault();
            Console.WriteLine(result.Key + " --> " + result.Value);
            //    var lines = int.Parse(Console.ReadLine());
            //    var jedis = Console.ReadLine().Trim().Split(' ');

            //    var mQueue = new Queue<string>();
            //    var kQueue = new Queue<string>();
            //    var pQueue = new Queue<string>();

            //    foreach(var jedi in jedis)
            //    {
            //        switch(jedi[0])
            //        {
            //            case 'm':
            //                {
            //                    mQueue.Enqueue(jedi);
            //                    break;
            //                }
            //            case 'k':
            //                {
            //                    kQueue.Enqueue(jedi);
            //                    break;
            //                }
            //            case 'p':
            //                {
            //                    pQueue.Enqueue(jedi);
            //                    break;
            //                }
            //        }
            //    }

            //    var result = new StringBuilder();

            //    while(mQueue.Count>0)
            //    {
            //        result.Append(mQueue.Dequeue() + ' ');
            //    }
            //    while (kQueue.Count > 0)
            //    {
            //        result.Append(kQueue.Dequeue() + ' ');
            //    }
            //    while (pQueue.Count > 0)
            //    {
            //        result.Append(pQueue.Dequeue() + ' ');
            //    }

            //    Console.WriteLine(result.ToString());
            //}
        }
    }
}
