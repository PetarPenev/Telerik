using System;
using System.IO;
using System.Text;
/* Write a program that compares two text files line by line and prints the number of lines that are the same 
 * and the number of lines that are different. Assume the files have equal number of lines. */


namespace _04.CompareTwoFiles
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the path to the first file.");
            string firstFile = Console.ReadLine();
            Console.WriteLine("Please enter the path to the second file.");
            string secondFile = Console.ReadLine();
            int sameLines=0, differentLines=0;
            try
            {
                using (StreamReader firstReader = new StreamReader(firstFile, Encoding.Default))
                {
                    using (StreamReader secondReader = new StreamReader(secondFile, Encoding.Default))
                    {
                        string line1 = firstReader.ReadLine();
                        string line2 = secondReader.ReadLine();
                        // Правим само 1 проверка за line == null, защото в условието е казано, че файловете са с еднакъв
                        // брой редове.
                        while (line1 != null)
                        {
                            if (line1 == line2)
                                sameLines++;
                            else
                                differentLines++;
                            line1 = firstReader.ReadLine();
                            line2 = secondReader.ReadLine();
                        }
                        Console.WriteLine("The same lines are {0} and the different lines are {1}.", sameLines, differentLines);
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
