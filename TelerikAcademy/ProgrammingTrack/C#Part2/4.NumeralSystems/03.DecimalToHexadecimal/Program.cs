using System;
/* Write a program to convert decimal numbers to their hexadecimal representation */

// Отрицателните числа в 16-ична бройна система могат да се запишат и като -0х... 
namespace _03.DecimalToHexadecimal
{
    class Program
    {
        static void Main()
        {
            int number = 0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the decimal number.");
                check = int.TryParse(Console.ReadLine(), out number);
            }
            string result = Convert(number);
            Console.WriteLine("The hexadecimal number is {0}.",result);
        }

        static string Convert(int number)
        {
            bool check=false, isNegative=false;
            int intermediateNumber=0;
            char symbol='0';
            if (number < 0)
            {
                isNegative = true;
                number = (int)Math.Abs(number);
            }
            string result = "";
            while (!check)
            {
                intermediateNumber = number % 16;
                switch (intermediateNumber)
                {
                    case 0:
                        symbol = '0';
                        break;
                    case 1:
                        symbol = '1';
                        break;
                    case 2:
                        symbol = '2';
                        break;
                    case 3:
                        symbol = '3';
                        break;
                    case 4:
                        symbol = '4';
                        break;
                    case 5:
                        symbol = '5';
                        break;
                    case 6:
                        symbol = '6';
                        break;
                    case 7:
                        symbol = '7';
                        break;
                    case 8:
                        symbol = '8';
                        break;
                    case 9:
                        symbol = '9';
                        break;
                    case 10:
                        symbol = 'A';
                        break;
                    case 11:
                        symbol = 'B';
                        break;
                    case 12:
                        symbol = 'C';
                        break;
                    case 13:
                        symbol = 'D';
                        break;
                    case 14:
                        symbol = 'E';
                        break;
                    case 15:
                        symbol = 'F';
                        break;
                }
                result += symbol;
                number /= 16;
                if (number == 0)
                    check = true;
            }
            result = Reverse(result);
            result = "0x"+result;
           if (isNegative)
                result = "-" + result;
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
