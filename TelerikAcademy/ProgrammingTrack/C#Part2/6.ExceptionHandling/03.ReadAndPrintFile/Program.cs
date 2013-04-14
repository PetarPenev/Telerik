using System;
using System.IO;
using System.Security;

/* Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
 * reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
 * Be sure to catch all possible exceptions and print user-friendly error messages. */


namespace _03.ReadAndPrintFile
{
    class Program
    {
        static void Main()
        {
            string filePath="", readText="";
            Console.WriteLine("Please enter the path to the file.");
            filePath = Console.ReadLine();
            try
            {
                readText = File.ReadAllText(filePath);
                Console.WriteLine("The file contains the following data:");
                Console.WriteLine(readText);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path to file is an empty string.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path to file contains invalid characters.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("File path is too long (above system limit) and therefore invalid.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified path is not valid.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("There was an I/O error while opening the file.");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Invalid format of file.");
            }
            catch (SecurityException)
            {
                Console.WriteLine("The caller does not have the necessary permission.");
            }
        }
    }
}
