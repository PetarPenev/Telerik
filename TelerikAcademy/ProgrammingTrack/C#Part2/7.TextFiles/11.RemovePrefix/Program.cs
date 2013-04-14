using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that deletes from a text file all words that start with the prefix "test". */

namespace _11.RemovePrefix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the source file.");
            string file = Console.ReadLine();
            Console.WriteLine("Please enter the destination file.");
            string destination = Console.ReadLine();
            string line="";
            using (StreamReader reader = new StreamReader(file, Encoding.Default))
            {
                using (StreamWriter writer = new StreamWriter(destination, false, Encoding.Default))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        line = Regex.Replace(line, "\\btest[A-Za-z0-9_]*?\\b", "");
                        if (!String.IsNullOrEmpty(line))
                        {
                            writer.WriteLine(line);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
