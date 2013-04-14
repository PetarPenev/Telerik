using System;
using System.IO;

/* Write a program that finds how many times a substring is contained in a given text (perform case insensitive search). */

// Реших да чета входа от файл ред по ред, тъй като няма спецификация за кода в задачата. 
// В случай, че получаваме входа като стринг, решението е дори по-лесно.

namespace _04.CaseInsensitiveSearch
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the file path.");
            string file = Console.ReadLine();
            Console.WriteLine("Please enter the substring.");
            string sub = Console.ReadLine();
            string line = "";
            int index = 0, counter = 0;
            using (StreamReader reader = new StreamReader(file))
            {
                // Четем последователно редовете и добавяме бройката на срещания на стринга във всеки ред, като игнорираме
                // дали е изписан с главни или малки букви, както е по условие.
                line = reader.ReadLine();
                while (line != null)
                {
                    index = line.IndexOf(sub, StringComparison.OrdinalIgnoreCase);
                    while (index != -1)
                    {
                        counter++;
                        index = line.IndexOf(sub, index + sub.Length, StringComparison.OrdinalIgnoreCase);
                    }
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine(counter);
        }
    }
}

