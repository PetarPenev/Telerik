namespace _09.First50MembersOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class First50MembersOfSequence
    {
        public static void Main()
        {
            Queue<int> sequenceNumbers = new Queue<int>();
            Console.WriteLine("Please enter n.");
            int startNumber = 0;
            bool isValidNumber = int.TryParse(Console.ReadLine(), out startNumber);
            while (!isValidNumber)
            {
                Console.WriteLine("Please enter a valid integer number.");
                isValidNumber = int.TryParse(Console.ReadLine(), out startNumber);
            }

            sequenceNumbers.Enqueue(startNumber);
            int numberOfMembersDisplayed = 50;

            for (int i = 0; i < numberOfMembersDisplayed; i++)
            {
                int nextNumber = sequenceNumbers.Dequeue();
                sequenceNumbers.Enqueue(nextNumber + 1);
                sequenceNumbers.Enqueue(2 * nextNumber + 1);
                sequenceNumbers.Enqueue(nextNumber + 2);
                Console.Write("{0} ", nextNumber);
            }
        }
    }
}
