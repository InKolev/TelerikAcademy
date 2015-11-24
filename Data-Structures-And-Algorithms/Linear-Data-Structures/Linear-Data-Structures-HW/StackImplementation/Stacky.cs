namespace StackImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stacky<T> : IEnumerable<T>
    {
        private const int InitialSize = 4;
        private const int SizeDelta = 4;

        private T[] items;
        private int size;

        public Stacky()
        {
            this.items = new T[InitialSize];
            this.size = 0;
        }

        public T Peek()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return this.items[size-1];
        }

        public void Push(T item)
        {
            if (size == this.Capacity())
            {
                this.items = this.ResizeArray();
            }

            this.items[size] = item;

            this.size++;
        }

        public T Pop()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            this.size--;

            var item = this.items[this.size];

            this.items[this.size] = default(T);

            return item;
        }

        public int Count()
        {
            return this.size;
        }

        public int Capacity()
        {
            return this.items.Length;
        }

        private T[] ResizeArray()
        {
            var newArr = new T[this.Capacity() + SizeDelta];

            for (int i = 0; i < this.Capacity(); i++)
            {
                newArr[i] = this.items[i];
            }

            return newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var i = 0;

            while (i < this.size)
            {
                yield return this.items[i];

                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
