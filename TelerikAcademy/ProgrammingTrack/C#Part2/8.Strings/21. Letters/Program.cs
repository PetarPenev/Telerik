using System;
using System.Collections.Generic;

/* Write a program that reads a string from the console and prints all different letters
 * in the string along with information how many times each letter is found. */

namespace _21.Letters
{
    class Program
    {
        static void Main()
        {
            // Четем стринга.
            Console.WriteLine("Please enter the string.");
            string input = Console.ReadLine();
            // Използваме речник, в който ключове са буквите, а стойности - броят на срещанията им.
            Dictionary<char, int> letters = new Dictionary<char, int>();
            // За всеки знак от стринга проверяваме дали е буква и, ако да - ако се съдържа в речника, увеличаваме 
            // стойността с 1, ако не се съдържа, го създаваме със стойност 1.
            foreach (char c in input)
                if (Char.IsLetter(c))
                {
                    if (letters.ContainsKey(c))
                        letters[c] += 1;
                    else
                        letters.Add(c, 1);
                }
            foreach (char c in letters.Keys)
            {
                Console.WriteLine("{0} : {1}", c, letters[c]);
            }

        }
    }
}
