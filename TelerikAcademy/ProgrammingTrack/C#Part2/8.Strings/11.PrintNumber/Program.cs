using System;

/* Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
 * percentage and in scientific notation. 
 * Format the output aligned right in 15 symbols. */

namespace _11.PrintNumber
{
    class Program
    {
        static void Main()
        {
            // Четем числото и го форматираме по подходящ начин.
            Console.WriteLine("Please enter the number.");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The decimal number is:");
            Console.WriteLine("{0,15:D}",number);
            Console.WriteLine("The hexadecimal number is:");
            Console.WriteLine("{0,15:X}", number);
            Console.WriteLine("The number as a percentage is:");
            Console.WriteLine("{0,15:p2}", number);
            Console.WriteLine("The number in scientific notation is");
            Console.WriteLine("{0,15:e2}",number);
        }
    }
}
