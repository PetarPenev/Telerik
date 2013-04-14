using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that removes from a text file all words listed in given another text file. 
 * Handle all possible exceptions in your methods. */


namespace _12.RemoveAllWords
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the path to the file containing the text.");
            string textFile = Console.ReadLine();
            Console.WriteLine("Please enter the path to the file containing the words.");
            string wordsFile=Console.ReadLine();
            Console.WriteLine("Please enter the destination file.");
            string destination = Console.ReadLine();
            string line="",word="";
            bool check=false;
            string regularExpression = "\\b(";
            using (StreamReader readerWords = new StreamReader(wordsFile, Encoding.Default))
            {
                // Изграждаме си регулярен израз за всички думи във файла с думи.
                word = readerWords.ReadLine();
                while (word != null)
                {
                    if (check == false)
                    {
                        regularExpression += "(" + word + ")";
                        check = true;
                    }
                    else
                    {
                        regularExpression += "|(" + word + ")";
                    }
                    word = readerWords.ReadLine();
                }
                regularExpression += ")\\b";
            }
            using (StreamReader readText = new StreamReader(textFile))
            {
                using (StreamWriter writer = new StreamWriter(destination))
                {
                    line = readText.ReadLine();
                    while (line != null)
                    {
                        // Премахваме думите.
                        line = Regex.Replace(line, regularExpression, String.Empty);
                        writer.WriteLine(line);
                        line = readText.ReadLine();
                    }
                }
            }
        }
    }
}
