namespace Traverse_Directories_Recursively
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class Startup
    {
        private static Queue<string> queue = new Queue<string>();
        static void Main(string[] args)
        {
            string sourcePath = @"C:\\Windows\\";
            Console.Write("Searching");

            GetFiles(sourcePath);

            Console.WriteLine("Files count: {0} ", queue.Count);
            Thread.Sleep(4000);

            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void GetFiles(string searchDirectory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(searchDirectory))
                {
                    if(file.IndexOf(".exe") != -1)
                    {
                        queue.Enqueue(file);
                    }
                }

                Console.Write(".");

                foreach (string directory in Directory.GetDirectories(searchDirectory))
                {
                    GetFiles(directory);
                }
            }
            catch (System.Exception ex)
            {
                queue.Enqueue(ex.Message);
            }
        }
    }
}
