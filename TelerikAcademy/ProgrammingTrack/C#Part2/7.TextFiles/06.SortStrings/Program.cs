using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/* Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.  */

namespace _06.SortStrings
{
    class Program
    {
        static void Main()
        {
            // Четем последователно всички редове от файла, записваме ги в списък, сортираме го и ги записваме в изходния файл.
            Console.WriteLine("Please enter the path to the file.");
            string file = Console.ReadLine();
            Console.WriteLine("Please enter the path to the destination file.");
            string destination = Console.ReadLine();
            List<string> theList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(file, Encoding.Default))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        theList.Add(line);
                        line = reader.ReadLine();
                    }
                }
                theList.Sort();
                using (StreamWriter writer = new StreamWriter(destination, false, Encoding.Default))
                {
                    foreach (var c in theList)
                        writer.Write("{0}\n", c);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
