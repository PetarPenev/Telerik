using System;

/* Write a program to calculate n! for each n in the range [1..100]. */

namespace _10.Factorials
{
    class Program
    {
        static int[] array = new int[1] { 1 };
        static void Main()
        {
            
            Console.Write("0!=");
            PrintArray(array);
            // За всеки следващ факториел умножаваме масива от цифри със следващото число.
            for (int i = 1; i <= 100; i++)
            {
                Console.Write("{0}!=", i);
                array=MultiplyArrayOfDigitsByNumber(array, i);
                PrintArray(array);
            }

        }

        static int[] MultiplyArrayOfDigitsByNumber(int[] array, int number)
        {
            int memory=0;
            // Умножаваме всеки елемент с числото и правим пренасяния с memory.
            for (int i=array.Length-1;i>=0;i--)
            {
                array[i]=array[i]*number+memory;
                if (array[i] >= 10)
                {
                    memory = array[i] / 10;
                    array[i] %= 10;
                }
                else
                    memory = 0;
            }
            // Ако финалната стойност на memory не е 0, преоразмеряваме масива и я записваме отпред.
            if (memory!=0)
            {
                string mem=Convert.ToString(memory);
                Array.Resize(ref array, array.Length+mem.Length);
                for (int i=array.Length-mem.Length-1; i>=0; i--)
                    array[i+mem.Length]=array[i];
                for (int i = 0; i < mem.Length; i++)
                    array[i] = (int)Char.GetNumericValue(mem[i]);
            }
            return array;

        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                Console.Write("{0}", array[i]);
            Console.Write(array[array.Length - 1]);
            Console.WriteLine();
        }
    }
}
