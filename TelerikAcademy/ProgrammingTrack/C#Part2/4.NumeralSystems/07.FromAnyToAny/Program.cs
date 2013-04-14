using System;

/* Write a program to convert from any numeral system of given base s to
 * any other numeral system of base d (2 ≤ s, d ≤  16).*/
namespace _07.FromAnyToAny
{
    class Program
    {
        static void Main()
        {
            bool isNegative=false;
            int s, d;
            Console.WriteLine("Please enter s - the base of the first numeral system.");
            s = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter d - the base of the second numeral system.");
            d = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number to be converted.");
            string number = Console.ReadLine();
            // Знакът се въвежда отделно.
            Console.WriteLine("Please enter the sign of the number.");
            string sign = Console.ReadLine();
            if (sign=="-")
                isNegative=true;
            int inDecimal = ConvertToBase10(number,s);
            string finalResult = ConvertFromBase10(inDecimal, d);
            if (isNegative)
                Console.WriteLine("The number is negative and its positive counterpart is {0}.", finalResult);
            else
                Console.WriteLine("The number is {0}", finalResult);



        }
        // Първо ще конвентираме до база 10.
        static int ConvertToBase10(string number, int baseOfNumber)
        {
            // Ако числото вече е в 10-ична бройна система, няма нужда да правим трансформация.
            if (baseOfNumber == 10)
                return int.Parse(number);
            int result = 0,power=0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] < 'A')
                    result += (int)Math.Pow(baseOfNumber, power) * (int)Char.GetNumericValue(number[i]);
                else
                    result += (int)Math.Pow(baseOfNumber, power) * (number[i] - 'A' + 10);
                power++;

            }
            return result;
        }

        static string ConvertFromBase10(int inDecimal, int newBase)
        {
            string result = "";
            int intermediateValue=0;
            bool check = false;
            // Разглеждаме всички възможни случай, получени при използването на % с новата база.
            while (!check)
            {
                intermediateValue = inDecimal % newBase;
                switch (intermediateValue)
                {
                    case 0:
                        result = "0" + result;
                        break;
                    case 1:
                        result = "1" + result;
                        break;
                    case 2:
                        result = "2" + result;
                        break;
                    case 3:
                        result = "3" + result;
                        break;
                    case 4:
                        result = "4" + result;
                        break;
                    case 5:
                        result = "5" + result;
                        break;
                    case 6:
                        result = "6" + result;
                        break;
                    case 7:
                        result = "7" + result;
                        break;
                    case 8:
                        result = "8" + result;
                        break;
                    case 9:
                        result = "9" + result;
                        break;
                    case 10:
                        result = "A" + result;
                        break;
                    case 11:
                        result = "B" + result;
                        break;
                    case 12:
                        result = "C" + result;
                        break;
                    case 13:
                        result = "D" + result;
                        break;
                    case 14:
                        result = "E" + result;
                        break;
                    case 15:
                        result = "F" + result;
                        break;
                }
                inDecimal = inDecimal / newBase;
                if (inDecimal == 0)
                    check = true;
            }
            return result;
        }

    }
}
