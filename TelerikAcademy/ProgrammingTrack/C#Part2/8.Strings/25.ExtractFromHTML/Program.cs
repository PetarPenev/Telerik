using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. */


/* Тъй като се чете от файл, във файла с резултатите се получават резултати ред по ред, тоест 
    <а> Телерик
 *      академия</а>
 *      
 * ще върне като резултат
 *     Телерик
 *     академия
 * на два реда. */
namespace _25.ExtractFromHTML
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the path to the file containing the HTML.");
            string path = Console.ReadLine();
            string destination = @"c:\output.txt";
            string line = "";
            bool reachBody=false;
            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            using (StreamWriter writer = new StreamWriter(destination, false, Encoding.Default))
            {
                line = reader.ReadLine();
                // Въртим цикъла докато не свършим файла.
                while (line != null)
                {
                    if (!reachBody)
                    {
                        foreach (Match c in Regex.Matches(line, @"<title>.*?</title>"))
                            writer.WriteLine(c.Value.Substring(7, c.Value.IndexOf("</title>")-7));
                        if (line.IndexOf("<body>") != -1)
                        {
                            reachBody = true;
                            line=line.Substring(line.IndexOf("<body>") + 6);
                        }
                    }
                    if (reachBody)
                    {
                        foreach (Match c in Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)"))
                        {
                            writer.WriteLine(c.Value);
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
