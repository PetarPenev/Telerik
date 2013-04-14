using System;
using System.Net;

/* Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and 
 * stores it the current directory. Find in Google how to download files in C#.
 * Be sure to catch all exceptions and to free any used resources in the finally block. */


namespace _04.DownloadAFile
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the url of the file.");
            string url = Console.ReadLine();
            Console.WriteLine("Please enter the name and extension for the file to be created.");
            string fileName = Console.ReadLine();
            WebClient downloadClient = new WebClient();
            // Ако въведете само име на файл (например pic.jpg), то той ще се запише в директорията на проекта /bin/debug.
            try
            {
                downloadClient.DownloadFile(url, fileName);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Address was null.");
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Method called simultaneously on multiple threads.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                downloadClient.Dispose();
            }
        }
    }
}
