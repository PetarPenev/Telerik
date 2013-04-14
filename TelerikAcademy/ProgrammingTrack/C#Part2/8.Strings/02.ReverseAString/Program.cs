using System;
using System.Text;

/* Write a program that reads a string, reverses it and prints the result at the console. */

// Това е решението със StringBuilder.

namespace _02.ReverseAString
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the string.");
            StringBuilder input = new StringBuilder(Console.ReadLine());
            char intermediateChar = 'a';
            for (int i = 0; i < input.Length / 2; i++)
            {
                intermediateChar = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = intermediateChar;
            }
            Console.WriteLine(input);
        }
    }
}
