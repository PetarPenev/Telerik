using System;

/* Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
 * Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
 * find the smallest from the rest, move it at the second position, etc.
*/

namespace _07.SortingArray
{
    class Program
    {
        static void Main()
        {
            int numUnsorted, currentIndex=0,minValue=0,minIndex=0;
            int[] mass = new int[] { 16, 33, -44, 124, 2312, 23, 34, 11, 2 };
            // Броят несортирани елементи го определяме като броят елементи в масива -1. Това -1 е необходимо, за да
            // можем да използваме променливата за индексиране.
            numUnsorted = mass.Length-1;
            /* Докато имаме несортирани елементи в масива, правим следното:
             * Започваме от текущия индекс (в началото 0, защото никой елемент не е сортиран) и присвояваме 
             * като минимален елемент елемента с този индекс.
             * Обхождаме масива и, когато намерим по-малък елемент, променяме съответните променливи.
             * Когато приключим с обхождането, имаме най-малкия елемент и го разменяме с първия несортиран елемент (този с 
             * currentIndex. Увеличаваме currentIndex с 1, а numUnsorted намаляваме с 1.*/
            while (numUnsorted >= 1)
            {
                minValue = mass[currentIndex];
                minIndex = currentIndex;
                for (int i = currentIndex + 1; i < mass.Length; i++)
                {
                    if (mass[i] < minValue)
                    {
                        minValue = mass[i];
                        minIndex = i;
                    }
                }
                mass[minIndex] = mass[mass.Length - numUnsorted-1];
                mass[mass.Length - numUnsorted - 1] = minValue;
                currentIndex = mass.Length - numUnsorted;
                numUnsorted-=1;
             }
            //Извеждаме сортирания масив.
            Console.WriteLine("The sorted array is:");
            for (int i = 0; i < mass.Length - 1; i++)
            {
                Console.Write("{0} ", mass[i]);
            }
            Console.Write(mass[mass.Length - 1]);
            Console.WriteLine();

            
        }
    }
}
