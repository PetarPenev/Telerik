using System;

/* Write a method that returns the last digit of given integer as an English word. 
 * Examples: 512 : "two", 1024 : "four", 12309 : "nine". */

namespace _03.PrintLastDigit
{
    class Program
    {
        static string GetLastDigit(int number)
        {
            if (number < 0)
                number = Math.Abs(number);
            int intDigit = number % 10;
            string stringDigit="";
            switch (intDigit)
            {
                case 0: stringDigit = "zero"; break;
                case 1: stringDigit = "one"; break;
                case 2: stringDigit = "two"; break;
                case 3: stringDigit = "three"; break;
                case 4: stringDigit = "four"; break;
                case 5: stringDigit = "five"; break;
                case 6: stringDigit = "six"; break;
                case 7: stringDigit = "seven"; break;
                case 8: stringDigit = "eight"; break;
                case 9: stringDigit = "nine"; break;
            }
            return stringDigit;

        }
        static void Main()
        {
            int number=0;
            bool check = false;
            // Продължава, докато не парснем успешно. 
            while (!check)
            {
                Console.WriteLine("Please enter the number.");
                check = int.TryParse(Console.ReadLine(), out number);
            }
            string toPrint = GetLastDigit(number);
            Console.WriteLine(toPrint);
        }
    }
}
