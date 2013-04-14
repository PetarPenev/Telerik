using System;
/* Write a program to convert hexadecimal numbers to their decimal representation. */

// Отрицателни числа при входа се записват като -0х..., а положителни - 0х...

namespace _04.HexadecimalToDecimal
{
    class Program
    {
        static void Main()
        {
            string numberInHex;
            int result = 0;
            Console.WriteLine("Please enter the hexadecimal number.");
            numberInHex = Console.ReadLine();
            result = Convert(numberInHex);
            Console.WriteLine("The decimal number is {0}.",result);

        }

        static int Convert(string hexString)
        {
            int result = 0,intValue=0,power=0;
            bool isNegative=false;
            if (hexString[0] == '-')
            {
                isNegative = true;
                hexString = hexString.Substring(3);
            }
            else
                hexString = hexString.Substring(2);
            for (int i = hexString.Length - 1; i >= 0; i--)
            {
                switch (hexString[i])
                {
                    case '0':
                        intValue = 0;
                        break;
                    case '1':
                        intValue = 1;
                        break;
                    case '2':
                        intValue = 2;
                        break;
                    case '3':
                        intValue = 3;
                        break;
                    case '4':
                        intValue = 4;
                        break;
                    case '5':
                        intValue = 5;
                        break;
                    case '6':
                        intValue = 6;
                        break;
                    case '7':
                        intValue = 7;
                        break;
                    case '8':
                        intValue = 8;
                        break;
                    case '9':
                        intValue = 9;
                        break;
                    case 'A':
                        intValue = 10;
                        break;
                    case 'B':
                        intValue = 11;
                        break;
                    case 'C':
                        intValue = 12;
                        break;
                    case 'D':
                        intValue = 13;
                        break;
                    case 'E':
                        intValue = 14;
                        break;
                    case 'F':
                        intValue = 15;
                        break;
                }
                result += intValue*(int)Math.Pow(16,power);
                power++;
            }
            if (isNegative)
                result = -result;
            return result;
        }
    }
}
