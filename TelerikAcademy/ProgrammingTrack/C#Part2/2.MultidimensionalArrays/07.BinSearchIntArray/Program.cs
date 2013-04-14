using System;

/* Write a program, that reads from the console an array of N integers and an integer K, sorts the array and 
 * using the method Array.BinSearch() finds the largest number in the array which is ≤ K. */

namespace _07.BinSearchIntArray
{
    class Program
    {
        static void Main()
        {
            int n = 0, k = 0;
            bool check = false, flag=false;
            while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            check = false;
            while (!check)
            {
                Console.WriteLine("Please enter k.");
                check = int.TryParse(Console.ReadLine(), out k);
            }
            check = false;
            int[] mass = new int[n];
            for (int i = 0; i < n; i++)
            {
                while (!check)
                {
                    Console.WriteLine("Please enter the {0} element.", i+1);
                    check = int.TryParse(Console.ReadLine(), out mass[i]);
                }
                check = false;
            }
            // Сортираме масива.
            Array.Sort(mass);
            int index=0, element=0;
            // Ако първият елемент е по-голям от к, няма нужда да правим проверка - няма числа, по-малки или равни на К.
            if (mass[0] > k)
            {
                Console.WriteLine("All elements are greater than k.");
            }
            // Ако последният елемент от сортирания масив е по-малък от К, то той е търсеният елемент.
            else if (mass[mass.Length - 1] < k)
            {
                Console.WriteLine("The element is {0} at index {1}.", mass[mass.Length - 1], mass.Length - 1);
            }
            else
            {
                // Прилагаме метода.
                index = Array.BinarySearch(mass, k);
                // Ако връща отрицателен резултат, то, тъй като покрихме случайте, в които нямаме по-малки елементи
                // в масива, то методът ни връща bitwise complement на индекса на първия по-голям от К елемент.
                // Тогава просто взимаме индекса преди върнатия индекс.
                if (index < 0)
                {
                    index = ~index;
                    Console.WriteLine("The element is {0} at index {1}.", mass[index - 1], index - 1);
                }
                // Ако връща положителен резултат, то сме намерили К в масива.
                else
                    Console.WriteLine("The element is {0} at index {1}.", mass[index], index);
            }
        }
    }
}
