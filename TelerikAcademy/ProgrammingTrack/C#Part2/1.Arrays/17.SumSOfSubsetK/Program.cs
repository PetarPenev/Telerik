using System;
using System.Collections.Generic;

/* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
 * Find in the array a subset of K elements that have sum S or indicate about its absence. */

namespace _17.SumSOfSubsetK
{
    class Program
    {
        // Решението на задачата е аналогично с това на предишната. В коментарите ще посоча само разликите.
        static List<string> results = new List<string>();
        static long sum;
        static bool flag=false;
        static void Main()
        {
            Console.WriteLine("Please enter n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter k.");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Please enter the {0} element.", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Please enter s");
            sum = long.Parse(Console.ReadLine());
            Array.Sort(array);
            for (int i = 0; i < n-k; i++)
                    // Тук се генерират всички комбинации с дължина к от елементи.
                    Combinations(array, k, i,"",0);
            if (!flag)
                Console.WriteLine("No.");
}

        static void Combinations(int[] array, int length, int index, string currentSet, long result)
        {
            if (length == 0) return;
            if (length == 1)
            {
                for (int j = index; j < array.Length; j++)
                {
                    currentSet += array[j];
                    result += array[j];
                    if ((result == sum) && (!results.Contains(currentSet)))
                    {
                        if (flag == false)
                        {
                            Console.WriteLine("Yes:");
                            flag = true;
                        }
                        results.Add(currentSet);
                        Console.WriteLine(currentSet);
                    }
                    currentSet = currentSet.Substring(0, currentSet.Length - Convert.ToString(array[j]).Length);
                    result -= array[j];
                }
            }
            if (length > 1)
            {
                currentSet += array[index]+",";
                result += array[index];
                // Отново имаме рекурсивно извикване.
                Combinations(array, length - 1, index + 1, currentSet, result);
                currentSet = currentSet.Substring(0, currentSet.Length - Convert.ToString(array[index]).Length-1);
                result -= array[index];
                // Тук се прави проверка дали в масива са останали достатъчно елементи след текущия индекс, за да
                // се генерира комбинация с нужната дължина.
                if (array.Length-index-1>=length)
                    Combinations(array, length, index + 1, currentSet, result);
            }

        }
    }
}
