using System;

/* Write a program to convert binary numbers to hexadecimal numbers (directly). */



namespace _06.BinToHex
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the binary number.");
            string binaryNumber = Console.ReadLine();
            string hexNumber = "";
            hexNumber = Convert(binaryNumber);
            Console.WriteLine("The hexadecimal number is {0}.",hexNumber);

        }

        static string Convert(string binNumber)
        {
            bool isNegative = false;
            Console.WriteLine("Please enter the sign of the number");
            string sign = Console.ReadLine();
            if (sign == "-")
                isNegative = true;
            binNumber = binNumber.TrimStart('0');
            int l = binNumber.Length % 4;
            int value=0;
            string result="";
            if (l != 0)
                binNumber = new string('0', 4-l) + binNumber;
            for (int i = 0; i < binNumber.Length; i += 4)
            {
                value = (int)Char.GetNumericValue(binNumber[i]) * 8 + (int)Char.GetNumericValue(binNumber[i + 1]) * 4 + (int)Char.GetNumericValue(binNumber[i + 2]) * 2 + (int)Char.GetNumericValue(binNumber[i + 3]) * 1;
                switch (value)
                {
                    case 0:
                        result += "0";
                        break;
                    case 1:
                        result += "1";
                        break;
                    case 2:
                        result += "2";
                        break;
                    case 3:
                        result += "3";
                        break;
                    case 4:
                        result += "4";
                        break;
                    case 5:
                        result += "5";
                        break;
                    case 6:
                        result += "6";
                        break;
                    case 7:
                        result += "7";
                        break;
                    case 8:
                        result += "8";
                        break;
                    case 9:
                        result += "9";
                        break;
                    case 10:
                        result += "A";
                        break;
                    case 11:
                        result += "B";
                        break;
                    case 12:
                        result += "C";
                        break;
                    case 13:
                        result += "D";
                        break;
                    case 14:
                        result += "E";
                        break;
                    case 15:
                        result += "F";
                        break;
                }
            }
            if (isNegative)
                result = "-0x" + result;
            else
                result = "0x" + result;
            return result;

        }
    }
}
