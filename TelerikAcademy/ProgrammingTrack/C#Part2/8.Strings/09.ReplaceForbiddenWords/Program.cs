using System;
using System.IO;
using System.Text.RegularExpressions;

/* We are given a string containing a list of forbidden words and a text containing some of these words. 
 * Write a program that replaces the forbidden words with asterisks. */

namespace _09.ReplaceForbiddenWords
{
    class Program
    {
        static void Main()
        {
            // Направил съм вход от конзолата, възможно е и да се хардкодне за по-лесно тестване.
            Console.WriteLine("Please enter the list of words, seperated by \",\".");
            string forbiddenWords = Console.ReadLine();
            Console.WriteLine("Please enter the text.");
            string text = Console.ReadLine();
            string[] array = forbiddenWords.Split(',');
            // За да подсигурим правилния вход и намиране на думите, премахваме всички спейсове в началото и края.
            for (int i = 0; i < array.Length; i++)
                array[i] = array[i].Trim(' ');
            string mask="";
            // За всяка от думите я заместваме в стринга със звездички с помощта на регулярен израз.
            foreach (string c in array)
            {
                mask = new string('*', c.Length);
                text = Regex.Replace(text,"\\b"+c+"\\b",mask);
            }
            Console.WriteLine(text);
                
        }
    }
}
