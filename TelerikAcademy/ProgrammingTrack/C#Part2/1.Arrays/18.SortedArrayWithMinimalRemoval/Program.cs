using System;
using System.Collections.Generic;

/* Write a program that reads an array of integers and removes from it a minimal number of elements 
 * in such way that the remaining array is sorted in increasing order. */

namespace _18.SortedArrayWithMinimalRemoval
{
    class Program
    {
        static List<string> results = new List<string>();
        static int resultGlobalLength = 0;
        static string resultGlobal="";
        static void Main()
        {
            Console.WriteLine("Please enter n");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Please enter the {0} element", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            // Генерираме всички възможни множества от елементи на масива
            for (int i = 0; i < n; i++)
                Combinations(array, i, 0, "", 0, int.MinValue);
            Console.Write("{");
            Console.Write(resultGlobal);
            Console.WriteLine("}");
        }

        static void Combinations(int[] array, int length, int index, string currentSet, int result, int lastElement)
        {
            if (length == 0) return;
            if (length == 1)
            {
                for (int j = index; j < array.Length; j++)
                {
                    if (array[j] >= lastElement)
                    {
                        currentSet += array[j];
                        result += 1;

                        if (result > resultGlobalLength)
                        {
                            resultGlobal = currentSet;
                            resultGlobalLength = result;
                        }
                        currentSet = currentSet.Substring(0, currentSet.Length - Convert.ToString(array[j]).Length);
                        result--;
                    }
                }
            }

            
            if (length > 1)
            {
                // Взема се текущия елемент, добавя се към комбинацията и се търсят всички възможни комбинации
                // за следващите елементи рекурсивно. След това елемента се премахва от комбинацията.
                if (array[index] >= lastElement)
                {
                    currentSet += array[index] + ",";
                    result += 1;
                    Combinations(array, length - 1, index + 1, currentSet, result, array[index]);
                    currentSet = currentSet.Substring(0, currentSet.Length - Convert.ToString(array[index]).Length - 1);
                    result -= 1;
                }
                // Ако е възможно да се продължи от следващия елемент и да се състави комбинация с необходимата дължина,
                // се прави.
                if (array.Length - index - 1 >= length)
                    Combinations(array, length, index + 1, currentSet, result, lastElement);
            }

        }
    }
}
