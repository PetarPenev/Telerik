using System;

/* Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has 
 * maximal sum of its elements. */
namespace _05.SquareOfThree
{
    class Program
    {
        static void Main()
        {
            int n = 0, m = 0, startIndexVertical=0,startIndexHorizontal=0, maxSum=0,intermediateSum=0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            check = false;
            while (!check)
            {
                Console.WriteLine("Please enter m.");
                check = int.TryParse(Console.ReadLine(), out m);
            }
            int[,] matrix = new int[n, m];
            // Ако матрицата е с размер по-малък от 3х3, няма смисъл да правим проверка.
            if ((n<3) || (m<3))
                Console.WriteLine("Matrix too small");
            else
            {
                for (int i=0;i<n;i++)
                    for (int j = 0; j < m; j++)
                    {
                        Console.WriteLine("Please enter the next element.");
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }

            }
            // Обхождаме всички възможни квадрати 3х3 и намираме този с най-голяма сума.
            for (int i=0;i<=n-3;i++)
                for (int j = 0; j <= m - 3; j++)
                {
                    intermediateSum = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int d = j; d < j + 3; d++)
                            intermediateSum += matrix[k, d];
                    if (intermediateSum > maxSum)
                    {
                        startIndexHorizontal = j;
                        startIndexVertical = i;
                        maxSum = intermediateSum;
                    }
                }
            Console.WriteLine("This is the square:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0} ", matrix[startIndexVertical+i, startIndexHorizontal+j]);
                }
                Console.WriteLine();
            }

        }
    }
}
