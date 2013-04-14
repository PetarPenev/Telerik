using System;

/* Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).*/

namespace _8.ShortRepresentation
{
    class Program
    {
        static void Main()
        {
            short number = 0;
            int num = 0, intNumber = 0;
            bool check = false, isNegative = false;
            while (!check)
            {
                Console.WriteLine("Please enter a number of type short.");
                check = int.TryParse(Console.ReadLine(), out num);
                // Ако числото не се събира в short, искаме ново въвеждане.
                if ((num < -32768) || (num > 32767))
                    check = false;
                else
                    number = (short)num;
            }
            string binaryRepresentation = "", intermediateString = "";
            if (number < 0)
            {
                isNegative = true;
                number = Math.Abs(number);
            }
            check = false;
            // Правим трансформацията. Обърнете внимание, че трансформацията на положителни числа е елементарна,
            // но за отрицателните трябва да обърнем битовете и да добавим единица към обратния код.
            while (!check)
            {
                intNumber = number % 2;
                if (isNegative)
                {
                    if (intNumber == 0)
                        intNumber = 1;
                    else
                        intNumber = 0;
                }
                binaryRepresentation = intNumber + binaryRepresentation;
                number = (short)(number / 2);
                if (number == 0)
                    check = true;

            }
            if (binaryRepresentation.Length < 15)
            {
                if (isNegative)
                    binaryRepresentation = binaryRepresentation.PadLeft(15, '1');
                else
                    binaryRepresentation = binaryRepresentation.PadLeft(15, '0');
            }
            if (isNegative)
                binaryRepresentation = '1' + binaryRepresentation;
            else
                binaryRepresentation = '0' + binaryRepresentation;
            if (isNegative)
            {
                binaryRepresentation = Reverse(binaryRepresentation);
                binaryRepresentation = Transform(binaryRepresentation);
            }
            Console.WriteLine(binaryRepresentation);
        }

        static string Reverse(string binaryRepresentation)
        {
            string returnString = "";
            foreach (char c in binaryRepresentation)
                returnString = c + returnString;
            return returnString;
        }

        static string Transform(string binaryRepresentation)
        {
            string returnString = "";
            int memory = 1;
            foreach (char c in binaryRepresentation)
            {
                if (memory == 1)
                {
                    if (c == '1')
                        returnString = '0' + returnString;
                    else
                    {
                        returnString = '1' + returnString;
                        memory = 0;
                    }
                }
                else
                    returnString = c + returnString;
            }
            return returnString;


        }

    }
}
