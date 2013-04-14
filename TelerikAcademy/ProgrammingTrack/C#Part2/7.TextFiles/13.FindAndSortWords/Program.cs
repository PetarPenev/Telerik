using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that reads a list of words from a file words.txt and finds how many times 
 * each of the words is contained in another file test.txt. 
 * The result should be written in the file result.txt and the words should be sorted by the number of their occurrences 
 * in descending order. Handle all possible exceptions in your methods. */

// На моята машина програмата не работи с файлове, записани на кирилица, но функционира коректно при файлове на латиница.


namespace _13.FindAndSortWords
{
    class Program
    {
        static void Main()
        {
            // Използваме предварително определени файлове, за тестовете могат да се сменят, естествено.
            string words=@"C:\words.txt";
            string text = @"C:\text.txt";
            string result = @"C:\result.txt";
            string word = "";
            int count=0;
            Dictionary<string, int> keyValuePair = new Dictionary<string, int>();
            try
            {
                using (StreamReader readerWords = new StreamReader(words, Encoding.Default))
                {
                    // Четем всички думи, определяме за всяка броя срещания и ги записваме в речник.
                    word = readerWords.ReadLine();
                    while (word != null)
                    {
                        count = WordOccurances(word, text);
                        keyValuePair.Add(word, count);
                        word = readerWords.ReadLine();
                    }
                }
                int maxCount = int.MinValue;
                string element = "";
                using (StreamWriter writer = new StreamWriter(result, false, Encoding.Default))
                {
                    // Взимаме последователно думата от речника с най-голям брой срещания, записваме я във файла с 
                    // резултати и я трием от речника, като въртим цикъла докато не завършат думите.
                    while (keyValuePair.Count != 0)
                    {
                        foreach (var c in keyValuePair.Keys)
                        {
                            if (keyValuePair[c] > maxCount)
                            {
                                element = c;
                                maxCount = keyValuePair[c];
                            }
                        }
                        if (maxCount > 0)
                            writer.WriteLine(element);
                        keyValuePair.Remove(element);
                        maxCount = int.MinValue;
                        element = "";
                    }

                }
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.Security.SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
                

        static int WordOccurances(string word, string text)
        {
            string line="";
            int count=0;
            using (StreamReader readerText = new StreamReader(text))
            {
                line = readerText.ReadLine();
                while (line != null)
                {
                    foreach (var c in Regex.Matches(line, "\\b"+word+"\\b"))
                        count++;
                    line = readerText.ReadLine();
                }
            }
            return count;
        }
    }
}
