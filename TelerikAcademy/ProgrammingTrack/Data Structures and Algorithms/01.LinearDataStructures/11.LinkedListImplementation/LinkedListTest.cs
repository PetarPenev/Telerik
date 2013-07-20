namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedListTest
    {
        public static void Main()
        {
            NewLinkedList<int> testList = new NewLinkedList<int>();
            Console.WriteLine("Testing adding.");
            testList.AddFirst(new ListItem<int>(5));
            testList.AddFirst(new ListItem<int>(6));
            testList.AddFirst(new ListItem<int>(7));
            testList.AddBefore(testList.First.NextItem, 4);
            testList.AddAfter(testList.First.NextItem.NextItem, 1);
            testList.AddLast(17);
            Console.WriteLine(testList);
            Console.WriteLine();

            Console.WriteLine("Testing containing and finding.");
            bool containsItem = testList.Contains(5);
            Console.WriteLine(testList.Find(4));
            Console.WriteLine(testList.Find(165));
            testList.AddLast(new ListItem<int>(4));
            Console.WriteLine(testList.FindLast(4));
            Console.WriteLine();

            Console.WriteLine("Testing removing.");
            Console.WriteLine(testList);
            testList.RemoveFirst();
            testList.RemoveLast();
            Console.WriteLine(testList);

            Console.WriteLine(testList);
            testList.Remove(1);
            Console.WriteLine(testList);
        }
    }
}
