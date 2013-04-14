using System;
using System.Collections.Generic;
using System.Diagnostics;

/* We are given an array of integers and a number S.
 * Write a program to find if there exists a subset of the elements of the array that has a sum S. */
namespace _16.SumOfSubsets
{
    class Program
    {
        // Използваме няколко глобални променливи с цел да не се налага непрекъснато да ги подаваме на метода.
        // В списъка запазваме всички комбинации от числа, чиято сума е равна на търсената. Целта е да не повтаряме
        // комбинации при извеждането в случай, че в масива има много повтарящи се елементи.
        static List<string> results = new List<string>();
        // Търсената сума.
        static long sum=14;
        // Флагова променлива дали сме намерили комбинация с търсената сума.
        static bool flag=false;
        static void Main()
        {
            string result="ba";
            int[] array = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
            int n=array.Length;
            // Сортираме масива.
            Array.Sort(array);
            // Викаме метода за всички възможни дължини на подмножества (между 0 и n).
            for (int i = 1; i <= n; i++)
                    Combinations(array, i, 0,"",0);
            // Ако нищо не е намерено, извеждане "Не".
            if (!flag)
                Console.WriteLine("No.");
        }
        // Този метод запазва всички подмножества с дадена дължина от масива и проверява дали сумата на елементите им е
        // равна на търсената сума. Ако да и ако те вече не са изведени на конзолата, се извеждат. Методът се прилага 
        // рекурсивно. Важно е да се отбележи, че множества с еднакви елементи не се извеждат по повече от веднъж.
        static void Combinations(int[] array, int length, int index, string currentSet, long result)
        {
            // Ако дължината на търсената последователност е едно, просто минаваме през всички оставащи елементи на масива.
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
            // Ако не е едно, добавяме текущия елемент и извикваме метода от следващия индекс в масива и да 
            // търси последователност, чиято дължина е с 1 по-къса. След това премахваме последния елемент и викаме 
            // метода със същата дължина, но от следващия индекс.
            if (length > 1)
            {
                currentSet += array[index]+",";
                result += array[index];
                Combinations(array, length - 1, index + 1, currentSet, result);
                currentSet = currentSet.Substring(0, currentSet.Length - Convert.ToString(array[index]).Length-1);
                result -= array[index];
                if (array.Length-index-1>=length)
                    Combinations(array, length, index + 1, currentSet, result);
            }

        }
     }
}
        
