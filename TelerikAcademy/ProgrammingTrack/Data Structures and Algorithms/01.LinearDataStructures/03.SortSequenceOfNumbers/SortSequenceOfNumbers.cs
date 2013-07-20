namespace _03.SortSequenceOfNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortSequenceOfNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a sequence of numbers ending with an empty line.");

            List<int> sequence = new List<int>();
            string nextLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(nextLine))
            {
                int nextNumber = 0;
                bool isValidNumber = int.TryParse(nextLine, out nextNumber);
                while (!isValidNumber)
                {
                    Console.WriteLine("Please enter a valid integer number or an empty line.");
                    nextLine = Console.ReadLine();
                    isValidNumber = int.TryParse(nextLine, out nextNumber);
                    if (string.IsNullOrEmpty(nextLine))
                    {
                        isValidNumber = true;
                    }
                }

                if (!string.IsNullOrEmpty(nextLine))
                {
                    sequence.Add(nextNumber);
                    nextLine = Console.ReadLine();
                }
            }

            sequence.Sort((first, second) => first.CompareTo(second));

            Console.WriteLine("The sorted numbers are:");
            foreach (var number in sequence)
            {
                Console.Write("{0} ", number);
            }
        }
    }
}
