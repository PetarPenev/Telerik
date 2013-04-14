using System;

/* Write a method that return the maximal element in a portion of array of integers starting at given index. 
 * Using it write another method that sorts an array in ascending / descending order. */
namespace _09.MaximalElementAndSorting
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[10] { 23, 453, 2123, 23, 455, 32, -21, -21231332, 23123, 22 };
            PrintArray(SortDescending(array));
            PrintArray(SortAscending(array));
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                Console.Write("{0},", array[i]);
            Console.Write(array[array.Length - 1]);
            Console.WriteLine();
        }

        static int MaximalElement(int[] array, int index, int length)
        {
            int maxElement=int.MinValue;
            for (int i = index; i < index+length; i++)
            {
                if (array[i] > maxElement)
                    maxElement = array[i];
            }
            return maxElement;
        }

        static int[] SortDescending(int[] array)
        {
            int element = 0, index = 0;
            // В този цикъл намираме най-големия елемент от несортираната част от масива и, ако не е текущия, ги разменяме.
            for (int i = 0; i < array.Length - 1; i++)
            {
                element = MaximalElement(array, i, array.Length-i);
                index = Array.IndexOf(array, element, i);
                if (i != index)
                {
                    array[i] += array[index];
                    array[index] = array[i] - array[index];
                    array[i] -= array[index];
                }
            }
            return array;
        }

            static int[] SortAscending(int[] array)
        {
            int element=0,index=0;
            // Съшото като в горния метод, но започваме отзад напред.
            for (int i = 0; i < array.Length - 1; i++)
            {
                element = MaximalElement(array, 0 , array.Length - i);
                index = Array.IndexOf(array, element, 0);
                if ((array.Length-i-1) != index)
                {
                    array[array.Length-i-1] += array[index];
                    array[index] = array[array.Length-1-i] - array[index];
                    array[array.Length-1-i] -= array[index];
                }
            }
            return array;
        }
    }
}
