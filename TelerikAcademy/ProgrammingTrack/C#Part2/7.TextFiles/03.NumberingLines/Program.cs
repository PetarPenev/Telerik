using System;
using System.IO;
using System.Text;

/* Write a program that reads a text file and inserts line numbers in front of each of its lines. 
 * The result should be written to another text file. */

namespace _03.NumberingLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "", path;
            int number = 0;
            Console.WriteLine("Please enter the path to the file.");
            path=Console.ReadLine();
            try
            {
                StreamReader reader = new StreamReader(path, Encoding.Default);
                // Резултатът се записва в папката bin/Debug на проекта. 
                StreamWriter writer = new StreamWriter("numberedlines.txt", false, Encoding.Default);
                using (reader)
                {
                    using (writer)
                    {
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            number++;
                            line = number + " " + line;
                            writer.WriteLine(line);
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path is null.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path is an empty string.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Invali path.");
            }
            catch (IOException)
            {
                Console.WriteLine("Path includes incorrect syntax.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access not authorized.");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("StreamWriter buffer is full.");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }
        
        }
    }
}
