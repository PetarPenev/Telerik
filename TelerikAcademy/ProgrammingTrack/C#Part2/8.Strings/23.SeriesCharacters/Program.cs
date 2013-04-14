using System;
using System.Text.RegularExpressions;
/* Write a program that reads a string from the console and replaces all series of 
 * consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".*/


namespace _23.SeriesCharacters
{
    class Program
    {
        static void Main()
        {
            // Решение с регулярен израз, с който хващаме всички последователни повторения на 1 символ 2 или повече пъти
            // и ги заменяме със символа.
            Console.WriteLine("Please enter the string");
            string input = Console.ReadLine();
            input = Regex.Replace(input,@"(.)\1+","$1");
            Console.WriteLine(input);
        }
    }
}
