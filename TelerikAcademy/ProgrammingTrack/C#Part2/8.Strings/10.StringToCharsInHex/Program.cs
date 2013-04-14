using System;

/* Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. */

namespace _10.StringToCharsInHex
{
    class Program
    {
        static void Main()
        {
            // Четем стринга и за всеки чар в него го конвертираме в hex, като му добавяме нули отляво, ако е необходимо,
            // и добавяме \u пред него.
            Console.WriteLine("Please enter the string.");
            string input = Console.ReadLine();
            foreach (char c in input)
                Console.Write("\\u"+Convert.ToInt32(c).ToString("X").PadLeft(4,'0'));
            Console.WriteLine();
        }
    }
}
