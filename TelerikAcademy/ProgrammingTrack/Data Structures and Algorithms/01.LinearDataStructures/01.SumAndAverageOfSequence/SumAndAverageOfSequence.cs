namespace _01.SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverageOfSequence
    {
        public static void Main()
        {
            List<int> sequence = new List<int>();
            string nextLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(nextLine))
            {
                int nextNumber = 0;
                bool isNumber = int.TryParse(nextLine, out nextNumber);
                while (!isNumber)
                {
                    Console.WriteLine("You entered a non-integer number. Please enter a valid number or an empty line.");
                    nextLine = Console.ReadLine();
                    isNumber = int.TryParse(nextLine, out nextNumber);
                    if (string.IsNullOrEmpty(nextLine))
                    {
                        isNumber = true;
                    }
                }

                if (!string.IsNullOrEmpty(nextLine))
                {
                    sequence.Add(nextNumber);
                    nextLine = Console.ReadLine();
                }
            }

            Console.WriteLine("The sum of the elements is {0}", sequence.Sum());
            Console.WriteLine("The average of the elements is {0:F2}", sequence.Average());
        }
    }
}
