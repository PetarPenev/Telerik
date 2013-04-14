using System;

/* Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order. */

namespace _24.AlphabeticallyListedWords
{
    class Program
    {
        static void Main()
        {
            // Четем списъка, делим го по интервали и го записваме в масив, сортираме масива и го извеждаме.
            Console.WriteLine("Please enter the list of words");
            string input = Console.ReadLine();
            string[] array = input.Split(' ');
            Array.Sort(array);
            foreach (string c in array)
                Console.WriteLine(c);
        }
    }
}
