using System;

/* Write a method that returns the index of the first element in array 
 * that is bigger than its neighbors, or -1, if there’s no such element.*/

namespace _06.FirstElementBiggerThanNeighbours
{
    class Program
    {
        static int BiggerThanNeighbours(int[] array)
        {
            // Ако имаме само 1 елемент, то той е търсеният.
            if (array.Length == 1)
                return 0;
            // Ако са два, проверяваме кой е по- голям и връщаме индекса му; ако са равни, връщаме -1.
            if (array.Length == 2)
            {
                if (array[0] > array[1])
                    return 0;
                else if (array[1] > array[0])
                    return 1;
                else return -1;
            }
                // В противен случай правим стандартна проверка.
            else
            {
                if (array[0] > array[1])
                    return 0;
                for (int i = 1; i < array.Length - 1; i++)
                {
                    if ((array[i] > array[i - 1]) && (array[i] > array[i + 1]))
                        return i;
                }
                if (array[array.Length - 1] > array[array.Length - 2])
                    return array.Length-1;
                return -1;
            }
        }

        static void Main()
        {
            int[] array = new int[10] {1,2,3,4,5,6,11,11,9,8};

            int index;
            index=BiggerThanNeighbours(array);
            Console.WriteLine(index);
            
        }
    }
}
