using System;

/* Write a program that reads a string, reverses it and prints the result at the console. */

// Това е решението със String.

namespace _02.ReverseAStringSecondVersion
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the string.");
            string text = Console.ReadLine(), newString = "";
            for (int i = 0; i < text.Length; i++)
                newString = text[i] + newString;
            Console.WriteLine(newString);
        }
    }
}

