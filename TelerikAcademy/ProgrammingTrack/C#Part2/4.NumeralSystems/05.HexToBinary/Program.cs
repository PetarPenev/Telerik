using System;

/* Write a program to convert hexadecimal numbers to binary numbers (directly). */

namespace _05.HexToBinary
{
    class Program
    {
        static void Main()
        {
            string numInHex;
            string result = "";
            Console.WriteLine("Please enter the number in hex.");
            numInHex = Console.ReadLine();
            result = Convert(numInHex);
            Console.WriteLine("The number in binary is {0}.",result);
        }
        // Използваме директно алгоритъма, описан в учебника на Наков.
        static string Convert(string hexString)
        {
            bool isNegative = false,check=false;
            int intValue=0,intNumber=0;
            string result="",tempResult="";
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
                while (!check)
                {
                    intNumber = intValue % 2;
                    tempResult = intNumber+tempResult;
                    intValue = intValue / 2;
                    if (intValue == 0)
                        check = true;
                }
                if (tempResult.Length < 4)
                    tempResult=tempResult.PadLeft(4, '0');
                result = tempResult + result;
                check = false;
                tempResult = "";
            }
            if (isNegative)
                result = "1 " + result;
            return result;
        }
    }
}
