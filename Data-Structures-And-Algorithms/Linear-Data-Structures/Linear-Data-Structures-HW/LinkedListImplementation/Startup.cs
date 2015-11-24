namespace LinkedListImplementation
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var list = new LinkedList<string>();

            var mouse = new ListItem<string>("Mussy");

            list.FirstItem = mouse;

            var cat = new ListItem<string>("Pussy");

            mouse.NextItem = cat;

            var dog = new ListItem<string>("Dussy");

            cat.NextItem = dog;

            Console.Write(string.Join(" --> ", list));
            Console.WriteLine();
        }
    }
}
