using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SpiralMatrix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter n between 1 and 19.");
            char n = char.Parse(Console.ReadLine());
            Console.WriteLine(n);
            /*
            if ((n <= 0) || (n > 19))
            {
                Console.WriteLine("Number not in requested range.");
            }
            else
            {
                int[,] matrixArray = new int[n, n];
                int size = n;
                int pos = 0;
                int num=1;
                while (size > 0)
                {
                    for (int i = 0 + pos; i < n - pos; i++)
                    {
                        matrixArray[pos, i] = num++;
                    }
                    for (int i = 0 + pos + 1; i < n - pos; i++)
                    {
                        matrixArray[i, n - pos - 1] = num++;
                    }
                    for (int i = n - pos - 2; i >= 0 + pos; i--)
                    {
                        matrixArray[n - pos - 1, i] = num++;
                    }
                    for (int i = n - pos - 2; i > 0 + pos; i--)
                    {
                        matrixArray[i, 0 + pos] = num++;
                    }
                    pos=pos+1;
                    size -= 2;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("{0,5}", matrixArray[i, j]);
                    }
                    Console.WriteLine();
                }

            }*/
        }
    }
}
