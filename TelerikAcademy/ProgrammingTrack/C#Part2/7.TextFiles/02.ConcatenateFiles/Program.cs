using System;
using System.IO;
using System.Text;
/* Write a program that concatenates two text files into another text file. */

namespace _02.ConcatenateFiles
{
    class Program
    {
        static void Main()
        {
            string path1, path2, text="";
            Console.WriteLine("Please enter the first path.");
            path1 = Console.ReadLine();
            Console.WriteLine("Please enter the second path.");
            path2 = Console.ReadLine();
            try
            {
                using (StreamReader firstReader = new StreamReader(path1, Encoding.Default))
                {
                    using (StreamReader secondReader = new StreamReader(path2, Encoding.Default))
                    {
                        // Резултатът се записва в папката bin/Debug на проекта.
                        using (StreamWriter writer = new StreamWriter("newfile.txt", false, Encoding.Default))
                        {
                            text = firstReader.ReadToEnd();
                            writer.WriteLine(text);
                            text = secondReader.ReadToEnd();
                            writer.Write(text);
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
