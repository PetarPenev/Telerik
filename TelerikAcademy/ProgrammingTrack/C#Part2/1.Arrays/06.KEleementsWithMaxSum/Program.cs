using System;

/* Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.
*/

namespace _06.KEleementsWithMaxSum
{
    class Program
    {
        static void Main()
        {
            int n=0, k=0;
            bool check = false;
            string result;
            // Четем n,k и стойностите на масива.
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
            check=false;
            int[] mass=new int[n];
            for (int i = 0; i < n; i++)
            {
                while (!check)
                {
                    Console.WriteLine("Please enter the {0} element of the array.", i + 1);
                    check = int.TryParse(Console.ReadLine(), out mass[i]);
                }
                check = false;
            }
            // Сортираме масива. Максимална сума от всички множества от k елемента имат последните k елемента
            // в сортирания масив.
            Array.Sort(mass);
            // Създаваме стринга на резултата, състоящ се от множеството на последните k елемента.
            result="{";
            for (int i = n - k; i < n; i++)
                result += mass[i]+" ";
            result += "}";
            Console.WriteLine(result);
        }
    }
}
