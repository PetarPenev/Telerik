namespace _01.PriorityQueue
{
    using System;

    public class Test
    {
        public static void Main()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(234);
            queue.Enqueue(1);
            queue.Enqueue(14);
            queue.Enqueue(11);
            queue.Enqueue(-1);
            Console.WriteLine(queue);
            Console.WriteLine("Dequeueing {0}", queue.Dequeue()); 
            Console.WriteLine(queue);
            Console.WriteLine("Dequeueing {0}", queue.Dequeue());
            Console.WriteLine(queue);
            queue.Enqueue(1000);
            Console.WriteLine(queue);
            Console.WriteLine("Dequeueing {0}", queue.Dequeue());
            Console.WriteLine(queue);
        }
    }
}
