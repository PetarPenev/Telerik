using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
/* Write a program that deletes from given text file all odd lines. The result should be in the same file. */

namespace _09.DeleteOddLines
{
    class Program
    {
        static void Main()
        {
            Encoding enc = Encoding.Default;
            Console.WriteLine("Please enter the path to the file");
            string file = Console.ReadLine();
            List<string> theList = new List<string>();
            // Отваряме файла, записваме в списък само четните линии от него, след това го отваряме за писане и ги записваме.
            try
            {
                using (StreamReader reader = new StreamReader(file, Encoding.Default))
                {
                    string line = reader.ReadLine();
                    int counter = 0;
                    while (line != null)
                    {
                        counter++;
                        if (counter % 2 == 0)
                            theList.Add(line);
                        line = reader.ReadLine();
                    }
                }
                using (StreamWriter writer = new StreamWriter(file, false, Encoding.Default))
                {
                    foreach (var c in theList)
                        writer.WriteLine(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
        
        }
    }
}
