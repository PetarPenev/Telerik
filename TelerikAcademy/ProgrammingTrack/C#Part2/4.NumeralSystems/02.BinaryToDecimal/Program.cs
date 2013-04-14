using System;

/* Write a program to convert binary numbers to their decimal representation.*/

/* Отново използваме прав код. */

namespace _02.BinaryToDecimal
{
    class Program
    {
        static void Main()
        {
            string numberInBinary = "";
            bool isNegative = false;
            int result = 0;
            Console.WriteLine("Please enter the binary number");
            numberInBinary = Console.ReadLine();
            Console.WriteLine("Please enter the sign of the number.");
            string sign = Console.ReadLine();
            if (sign == "-")
                isNegative = true;
            result = Convert(numberInBinary);
            if (isNegative)
                result = -result;
            Console.WriteLine("The number in decimal is {0}.",result);
        }

        static int Convert(string numberInBinary)
        {
            int result = 0,power=0;
            for (int i = numberInBinary.Length-1; i >= 0; i--)
            {
                if (numberInBinary[i] == '1')
                    result += (int)Math.Pow(2, power);
                power++;
            }
            return result;
        }
    }
}
