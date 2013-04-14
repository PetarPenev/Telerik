using System;
/* Write a program that shows the internal binary representation of 
 * given 32-bit signed floating-point number in IEEE 754 format (the C# type float). */

namespace _09.FloatRepresentation
{
    class Program
    {
        static void Main()
        {
            float number;
            Console.WriteLine("Please enter a number of type float.");
            number = float.Parse(Console.ReadLine());
            // Директно приложение на алгоритъма за записване.
            string representation = "",mantissa="",exponent="";
            int numberMovementsPoint=0;
            if (number < 0)
                representation = "1";
            else
                representation = "0";
            number = Math.Abs(number);
            // Вземаме и нормализираме мантисата.
            mantissa = GetMantissa(number);
            numberMovementsPoint = NormalizeMantissa(numberMovementsPoint, ref mantissa);
            // Вземаме експонентата.
            exponent = GetExponent(numberMovementsPoint);
            representation += exponent + mantissa;
            Console.WriteLine("The number is:");
            Console.WriteLine(representation);

        }

        static string GetMantissa(float number)
        {
            int wholePart = 0,intermediateNumber=0;
            float fractionalPart = 0;
            string result = "";
            wholePart = (int)number;
            fractionalPart = (number - wholePart);
            if (wholePart == 0)
                result = "0";
            // Вземаме двоичното представяне на цялата част.
            while (wholePart != 0)
            {
                intermediateNumber = wholePart % 2;
                result = intermediateNumber + result;
                wholePart = wholePart / 2;
            }
            // Слагаме десетична запетайка.
            result += ",";
            // Вземаме дробната част и я представяме по алгоритъма: умножаваме по 2 и вземаме цялата част 
            // от новото число, като я вадим от него след това и въртим цикъла, докато не получим 0 за числото.
            while (fractionalPart!=0f)
            {
                fractionalPart *= 2;
                intermediateNumber = (int)fractionalPart;
                result += intermediateNumber;
                fractionalPart = fractionalPart - intermediateNumber;
            }
            /*numberMovementsPoint = result.IndexOf(',') - 1;
            if (result[0]!='1')
                numberMovementsPoint=result.IndexOf('1');
            result=result.Substring(0,result.Length-(result.Length-result.IndexOf(',')))+result.Substring(result.IndexOf(',')+1);*/
            return result;
        }

        static int NormalizeMantissa(int numberMovementsPoint, ref string mantissa)
        {
            bool checkLeadingOne = false;
            if (mantissa[0] == '1')
                checkLeadingOne = true;
            // Ако в мантисата има 1 в цялата част, то определяме каква трябва да е степента на експонентата и преобразуваме.
            if (checkLeadingOne)
            {
                numberMovementsPoint = mantissa.IndexOf(',') - 1;
                mantissa = mantissa.Substring(1, mantissa.IndexOf(',')-1) + mantissa.Substring(mantissa.IndexOf(',') + 1);
            }
            // Същото правим и ако нямаме цяла част.
            else
            {
                numberMovementsPoint = -(mantissa.IndexOf('1') - 1);
                mantissa = mantissa.Substring(mantissa.IndexOf('1')+1);
            }
            mantissa = mantissa.PadRight(23, '0');
            return numberMovementsPoint;

        }

        static string GetExponent(int exponentAdjustment)
        {
            // Променяме adjustment-a. След това записваме експонентата и я допълваме.
            exponentAdjustment = exponentAdjustment + 127;
            string exponent = "";
            int intermediateNumber = 0;
            while (exponentAdjustment != 0)
            {
                intermediateNumber = exponentAdjustment % 2;
                exponent = intermediateNumber + exponent;
                exponentAdjustment = exponentAdjustment / 2;
            }
            return exponent.PadLeft(8, '0');
        }
    }
}
