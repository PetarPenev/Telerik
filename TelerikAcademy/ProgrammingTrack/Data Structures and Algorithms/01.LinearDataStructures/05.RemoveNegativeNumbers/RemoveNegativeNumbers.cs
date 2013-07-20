namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNegativeNumbers
    {
        public static void Main()
        {
            // We are using Linked List as the removal will be faster than with regular list.
            LinkedList<int> sequence = new LinkedList<int>();
            Console.WriteLine("Please enter a sequence of numbers that ends with an empty line.");

            string nextLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(nextLine))
            {
                int nextNumber = 0;
                bool isValidNumber = int.TryParse(nextLine, out nextNumber);
                while (!isValidNumber)
                {
                    Console.WriteLine("Please enter a valid number or an empty line.");
                    nextLine = Console.ReadLine();
                    isValidNumber = int.TryParse(nextLine, out nextNumber);
                    if (string.IsNullOrEmpty(nextLine))
                    {
                        isValidNumber = true;
                    }
                }

                if (!string.IsNullOrEmpty(nextLine))
                {
                    sequence.AddLast(nextNumber);
                    nextLine = Console.ReadLine();
                }
            }

            var currentNumber = sequence.First;
            while (currentNumber != null)
            {
                var nextNumber = currentNumber.Next;

                if (currentNumber.Value < 0)
                {
                    sequence.Remove(currentNumber);
                }

                currentNumber = nextNumber;
            }

            Console.WriteLine("The sequence of non-negative numbers is:");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
