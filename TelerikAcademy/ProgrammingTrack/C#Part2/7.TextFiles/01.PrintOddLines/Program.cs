using System;
using System.IO;
using System.Text;

/* Write a program that reads a text file and prints on the console its odd lines. */

namespace _01.PrintOddLines
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the path to the file.");
            string filePath = Console.ReadLine(),line="";
            int counter=0;
            try
            {
                StreamReader reader = new StreamReader(filePath, Encoding.Default);
                using (reader)
                {
                    line=reader.ReadLine();
                    while (line!=null)
                    {
                        counter++;
                        if (counter%2==1)
                            // Извеждаме и номера на реда.
                            Console.WriteLine("{0}:{1}",counter,line);
                        line=reader.ReadLine();
                    }
                }
            }
            // Хващаме изключенията.
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
                Console.WriteLine("Invaliд path.");
            }
            catch (IOException)
            {
                Console.WriteLine("Path includes incorrect syntax.");
            }
        }
    }
}
