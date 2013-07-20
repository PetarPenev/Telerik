namespace _02.ReverseNNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            Stack<int> numbersToReverse = new Stack<int>();

            Console.WriteLine("Please enter the number of elements to enter.");
            int numberOfElements = 0;
            bool isValidNumber = int.TryParse(Console.ReadLine(), out numberOfElements);
            while (!isValidNumber)
            {
                Console.WriteLine("Please enter a valid integer number.");
                isValidNumber = int.TryParse(Console.ReadLine(), out numberOfElements);
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                int nextElement = 0;
                string nextNumber = Console.ReadLine();
                isValidNumber = int.TryParse(nextNumber, out nextElement);
                while (!isValidNumber)
                {
                    Console.WriteLine("Please enter a valid integer number.");
                    nextNumber = Console.ReadLine();
                    isValidNumber = int.TryParse(nextNumber, out nextElement);
                }

                numbersToReverse.Push(nextElement);
            }

            Console.WriteLine("The reversed elements are:");
            for (int i = 0; i < numberOfElements; i++)
            {
                Console.WriteLine("{0} ", numbersToReverse.Pop());
            }
        }
    }
}
