namespace StackImplementation
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var stack = new Stacky<int>();

            stack.Push(50);
            Console.WriteLine("Pop: " + stack.Pop());

            stack.Push(12);
            stack.Push(200);
            stack.Push(65);
            stack.Push(35);
            Console.WriteLine("Peek: " + stack.Peek());

            Console.WriteLine(string.Join(" --> ", stack));
        }
    }
}
