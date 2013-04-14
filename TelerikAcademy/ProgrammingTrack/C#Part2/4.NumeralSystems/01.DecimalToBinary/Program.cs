using System;
/* Write a program to convert decimal numbers to their binary representation. */

/* !!!Връщаме числото в прав код с 1 отпред само ако знакът е отрицателен */

namespace _01.DecimalToBinary
{
    class Program
    {
        static void Main()
        {
            int number = 0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the number to be converted.");
                check = int.TryParse(Console.ReadLine(), out number);
            }
            Console.WriteLine("The number in decimal is {0}.",number);
            string result = Convert(number);
            Console.WriteLine("The number in binary is {0}.",result);
        }

        static string Convert(int number)
        {
            bool check = false, isNegative=false;
            int intermediateNumber=0;
            string result="";
            // Правим проверка за отрицателност.
            if (number < 0)
            {
                number = Math.Abs(number);
                isNegative = true;
            }
            // Натрупваме резултати в стринг.
            while (!check)
            {
                intermediateNumber = number % 2;
                result += intermediateNumber;
                number /= 2;
                if (number == 0)
                    check = true;
            }
            // Обръщаме ги.
            result = Reverse(result);
            // Ако числото е отрицателно, му добавяме една единица отпред + интервал.
            if (isNegative)
                result = "1 " + result;
            return result;
        }

        static string Reverse(string initialString)
        {
            string reversedString = "";
            for (int i = initialString.Length - 1; i >= 0; i--)
                reversedString += initialString[i];
            return reversedString;
        }
    }
}
