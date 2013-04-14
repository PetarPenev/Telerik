using System;

/* Write a program that finds all prime numbers in the range [1...10 000 000]. 
 * Use the sieve of Eratosthenes algorithm (find it in Wikipedia). */


namespace _15.PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Директно прилагаме алгоритъма на Ератостен. За всяко число от 2 до корен квадратен от 10 000 000 (това е 
            // оптимизация, не е нужно да се проверява за следващите числа) проверяваме дали вече е отбелязано като
            // непросто (използваме bool масив, където true e отбелязано число, а самото число е индекса на масива).
            // Ако не е отбелязано, то маркираме като отбелязани всички числа, които се делят на това число. Ако е 
            // отбелязано, не е нужно да го правим, защото всички делящи се на него числа вече са маркирани като отбелязани.
            int z=(int)Math.Sqrt(10000000);
            bool[] massBool = new bool[10000000];
            for (int i = 2; i < z; i++)
            {
                if (massBool[i] == false)
                {
                    for (int j = i*2; j < 10000000; j=j+i)
                        if (j % i == 0)
                            massBool[j] = true;
                }
            }
            // Печатането на конзолата е много бавна операция.
            for (int i = 2; i < 10000000; i++)
                if (massBool[i] == false)
                    Console.Write("{0} ", i);
        }
    }
}

