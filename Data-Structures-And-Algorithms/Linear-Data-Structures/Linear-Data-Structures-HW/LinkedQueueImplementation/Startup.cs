namespace LinkedQueueImplementation
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var queue = new Queuee<int>();

            queue.Enqueue(5);
            queue.Enqueue(12);
            queue.Enqueue(30);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
