using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that extracts from given XML file all the text without the tags. */

namespace _10.RemoveTags
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the file.");
            string file = Console.ReadLine();
            Console.WriteLine("Please enter the path to the output file");
            string destination = Console.ReadLine();
            string line="";
            using (StreamReader reader = new StreamReader(file, Encoding.Default))
            {
                using (StreamWriter writer = new StreamWriter(destination, false, Encoding.Default))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        // С регулярен израз махаме таговете.
                        line = Regex.Replace(line, "<.*?>", String.Empty);
                        // Ако редът не се е състоял само от тагове, го записваме в новия файл.
                        if (!String.IsNullOrEmpty(line))
                            writer.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
