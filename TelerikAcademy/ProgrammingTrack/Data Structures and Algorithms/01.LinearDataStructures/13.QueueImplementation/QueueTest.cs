namespace _13.QueueImplementation
{
    using System;

    public class QueueTest
    {
        public static void Main()
        {
            NewQueue<int> queue = new NewQueue<int>();

            Console.WriteLine("Testing enqueueing:");
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine("Count of elements: {0}", queue.Count);
            Console.WriteLine(queue);
            Console.WriteLine();

            Console.WriteLine("Testing dequeueing:");
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("Count of elements: {0}", queue.Count);
            Console.WriteLine(queue);
            Console.WriteLine();

            Console.WriteLine("Testing peeking:");
            Console.WriteLine("Peeked element: {0}", queue.Peek());
            Console.WriteLine("Count of elements: {0}", queue.Count);
            Console.WriteLine(queue);
            Console.WriteLine();

            Console.WriteLine("Testing contains:");
            Console.WriteLine("The queue contains 4: {0}", queue.Contains(4));
            Console.WriteLine("The queue contains 164: {0}", queue.Contains(164));
            Console.WriteLine();

            Console.WriteLine("Testing clearing:");
            queue.Clear();
            Console.WriteLine("Count of elements: {0}", queue.Count);
            Console.WriteLine(queue);
        }
    }
}
