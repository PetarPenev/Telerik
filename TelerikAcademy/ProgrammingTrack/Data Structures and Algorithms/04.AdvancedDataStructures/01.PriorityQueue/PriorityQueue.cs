namespace _01.PriorityQueue
{
    using System;
    using System.Text;

    public class PriorityQueue<T> where T : IComparable
    {
        private BinaryHeap<T> heap;

        public PriorityQueue()
        {
            this.heap = new BinaryHeap<T>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No elements are in the priority queue.");
            }

            return this.heap.Pop();
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder("Top of queue:");
            representation.Append(this.heap.Peek.ToString());
            return representation.ToString();
        }
    }
}
