using System;
/* You are given a sequence of positive integer values written into a string, separated by spaces.
 * Write a function that reads these values from given string and calculates their sum. */

namespace _06.SumOfValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = "";
            Console.WriteLine("Please enter the values.");
            values = Console.ReadLine();
            // Делим ги в стринг масив.
            string[] array = values.Split(' ');
            // Създаваме int масив със същата дължина.
            int[] intArray = new int[array.Length];
            // Парсваме всички числа в масива.
            for (int i=0;i<array.Length;i++)
                intArray[i] = int.Parse(array[i]);
            int sum=0;
            // Събираме ги, смятаме сумата и извеждаме.
            foreach (int v in intArray)
                sum += v;
            Console.WriteLine("The sum is equal to {0}.",sum);
        }
    }
}
