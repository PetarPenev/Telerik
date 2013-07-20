namespace _03.Cables
{
    using System;
    using Wintellect.PowerCollections;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private OrderedBag<T> bag;

        public PriorityQueue()
        {
            this.bag = new OrderedBag<T>();
        }

        public int Count
        {
            get
            {
                return this.bag.Count;
            }

            private set
            {
            }
        }

        public void Enqueue(T element)
        {
            this.bag.Add(element);
        }

        public T Dequeue()
        {
            var element = this.bag.GetFirst();
            this.bag.RemoveFirst();
            return element;
        }

        public void Clear()
        {
            this.bag.Clear();
        }

        public T Peek()
        {
            var element = this.bag.GetFirst();
            return element;
        }

        public bool Contains(T element)
        {
            return this.bag.Contains(element);
        }
    }
}
