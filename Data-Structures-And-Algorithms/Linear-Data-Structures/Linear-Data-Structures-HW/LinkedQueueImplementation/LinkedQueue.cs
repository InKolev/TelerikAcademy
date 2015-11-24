namespace LinkedQueueImplementation
{
    using System.Collections.Generic;

    public class Queuee<T>
    {
        private LinkedList<T> list;

        public Queuee()
        {
            this.list = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            this.list.AddFirst(item);
        }

        public T Dequeue()
        {
            var it = this.list.Last;
            this.list.RemoveLast();
            return it.Value;
        }
    }
}
