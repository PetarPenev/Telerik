namespace _13.QueueImplementation
{
    using System;
    using System.Text;
    using _11.LinkedListImplementation;

    public class NewQueue<T>
    {
        // We are using the linked list class we implemented in task 11. Ergo, we are adding reference to 
        // the project and a using directive for the namespace.
        private NewLinkedList<T> queueList;

        public NewQueue()
        {
            this.queueList = new NewLinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.queueList.Count;
            }
        }

        public void Enqueue(T elementToAdd)
        {
            this.queueList.AddLast(elementToAdd);
        }

        public T Dequeue()
        {
            return this.queueList.RemoveFirst();
        }

        public T Peek()
        {
            T valueToReturn = this.queueList.RemoveFirst();
            this.queueList.AddFirst(valueToReturn);
            return valueToReturn;
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder("From first to last:" + Environment.NewLine);
            representation.Append(this.queueList.ToString());
            if (this.queueList.Count == 0)
            {
                representation.Append("Empty");
            }

            return representation.ToString();
        }

        public void Clear()
        {
            this.queueList.Clear();
        }

        public bool Contains(T valueToFind)
        {
            return this.queueList.Contains(valueToFind);
        }
    }
}
