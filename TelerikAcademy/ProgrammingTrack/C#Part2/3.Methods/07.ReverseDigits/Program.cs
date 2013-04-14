using System;

/* Write a method that reverses the digits of given decimal number. Example: 256 : 652 */

namespace _07.ReverseDigits
{
    class Program
    {
        static void Main()
        {
            decimal number=0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the number");
                check = decimal.TryParse(Console.ReadLine(), out number);
            }
            string reversedNumber = Reverse(Convert.ToString(number));
            Console.WriteLine(reversedNumber);
        }

        // Използваме рекурсивен метод, чрез който връщаме обърнатото число, което преди това сме прехвърлили като стринг.
        static string Reverse(string current)
        {
            if (current.Length == 1)
            {
                return current;
            }
            else
                return current[current.Length-1]+Reverse(current.Substring(0,current.Length-1));
        }
        
    }
}
