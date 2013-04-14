using System;

/* Write a method that counts how many times given number appears in given array. 
 * Write a test program to check if the method is working correctly. */

namespace _04.TimesNumberInArray
{
    class Program
    {
        static int GetTimes(int[] array, int number)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    counter++;
            }
            return counter;
        }
        static void Main()
        {
            int numElements = 0, element=0, numOccurances;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the number of elements in the array.");
                check = int.TryParse(Console.ReadLine(), out numElements);
            }
            check=false;
            int[] array = new int[numElements];
            for (int i = 0; i < numElements; i++)
            {
                while (!check)
                {
                    Console.WriteLine("Please enter the {0} element.", i);
                    check = int.TryParse(Console.ReadLine(), out array[i]);
                }
                check = false;
            }
            check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the number we are searching for.");
                check = int.TryParse(Console.ReadLine(), out element);
            }
            numOccurances = GetTimes(array, element);
            Console.WriteLine("The element appears {0} times in the given array.", numOccurances);

        }
    }
}
