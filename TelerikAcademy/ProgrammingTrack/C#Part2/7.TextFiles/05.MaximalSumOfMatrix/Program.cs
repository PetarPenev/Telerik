using System;
using System.IO;
using System.Text;

/* Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area 
 * of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains the size of matrix N.
 * Each of the next N lines contain N numbers separated by space.
 * The output should be a single number in a separate text file. */

namespace _05.MaximalSumOfMatrix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the path to the input file.");
            string file = Console.ReadLine();
            Console.WriteLine("Please enter the path to the output file.");
            string outFile = Console.ReadLine();
            try
            {
                using (StreamReader reader = new StreamReader(file, Encoding.Default))
                {
                    int numElements = int.Parse(reader.ReadLine());
                    int[,] array = new int[numElements, numElements];
                    string[] arr = new string[numElements];
                    string line = reader.ReadLine();
                    int pos = -1;
                    while (line != null)
                    {
                        pos++;
                        arr = line.Split(' ');
                        for (int i = 0; i < numElements; i++)
                            array[pos, i] = int.Parse(arr[i]);
                        line = reader.ReadLine();
                    }
                    int returnNumber = FindLargestSum(array);
                    using (StreamWriter writer = new StreamWriter(outFile, false, Encoding.Default))
                    {
                        writer.Write(returnNumber);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Стандартна процедура за намиране на най-голямата сума. Обхождаме всички възможни 2х2 площадки.
        static int FindLargestSum(int[,] array)
        {
            int largestSum=int.MinValue;
            int intermediateSum=0;
            for (int i=0;i<=array.GetLength(0)-2;i++)
                for (int j = 0; j <= array.GetLength(1) - 2; j++)
                {
                    intermediateSum = array[i, j] + array[i + 1, j] + array[i + 1, j + 1] + array[i, j + 1];
                    if (intermediateSum > largestSum)
                        largestSum = intermediateSum;
                }
            return largestSum;
        }
    }
}
