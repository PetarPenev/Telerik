using System;
using System.IO;
using System.Text.RegularExpressions;

// Решение на 5 задача с регулярни изрази.

namespace _05.WithRegularExpressions
{
    class Program
    {
        static void Main()
        {
            MatchCollection expressions;
            //Console.WriteLine("Please enter the path to the file.");
            //string file = Console.ReadLine();
            string file = "C:\\text.txt";
            //Console.WriteLine("Please enter the path to the output file");
            //string destination = Console.ReadLine();
            string destination = "C:\\output.txt";
            string line = "",s="";
            using (StreamReader reader = new StreamReader(file))
            {
                using (StreamWriter writer = new StreamWriter(destination))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        expressions = Regex.Matches(line, "(<upcase>)(.*?)(</upcase>)");
                        foreach (Match match in expressions)
                            foreach (Capture capture in match.Captures)
                                line=line.Replace(capture.Value, capture.Value.Substring(capture.Value.IndexOf("<upcase>")+8,capture.Value.IndexOf("</upcase>")-(capture.Value.IndexOf("<upcase>")+8)));
                        expressions = Regex.Matches(line, "(<upcase>)(.*?)");
                        foreach (Match match in expressions)
                            foreach (Capture capture in match.Captures)
                                line = line.Replace(capture.Value, capture.Value.Substring(capture.Value.IndexOf("<upcase>") + 8));
                        
                        expressions = Regex.Matches(line, "(.*?)(</upcase>)");
                        foreach (Match match in expressions)
                            foreach (Capture capture in match.Captures)
                                line = line.Replace(capture.Value, capture.Value.Substring(0, capture.Value.IndexOf("</upcase>")));
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
