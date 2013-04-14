using System;
using System.IO;
using System.Text;

/* Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file.  */

namespace _07.ReplaceAllOccurances
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the path to the file");
            string file = Console.ReadLine();
            string line="";
            Console.WriteLine("Please enter the destination file.");
            string destination = Console.ReadLine();
            Console.WriteLine("Please enter the start substring");
            string start=Console.ReadLine();
            Console.WriteLine("Please enter the finish substring");
            string finish = Console.ReadLine();
            try
            {
                using (StreamReader reader = new StreamReader(file, Encoding.Default))
                {
                    using (StreamWriter writer = new StreamWriter(destination, false, Encoding.Default))
                    {
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            line = line.Replace(start, finish);
                            writer.WriteLine(line);
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
