using System;

/* Write a program that reads a year from the console and checks whether it is a leap. Use DateTime */

namespace _01.LeapYear
{
    class Program
    {
        static void Main()
        {
            bool check = false;
            int year = 0;
            while (!check)
            {
                Console.WriteLine("Please enter an year.");
                check = int.TryParse(Console.ReadLine(), out year);
            }
            check = DateTime.IsLeapYear(year);
            Console.WriteLine(check);
        }
    }
}
