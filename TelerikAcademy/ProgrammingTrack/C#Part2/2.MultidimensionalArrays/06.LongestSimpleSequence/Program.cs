using System;

/* We are given a matrix of strings of size N x M. 
 * Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
 * Write a program that finds the longest sequence of equal strings in the matrix. */
namespace _06.LongestSimpleSequence
{
    class Program
    {
        static void Main()
        {
            int n = 4, m = 5, maxSequence=0, currentSequence=0;
            string element="";
            bool check = false;
            // Закоментираният код може да се използва при въвеждане на стойностите от клавиатурата.

            /*while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            check = false;
            while (!check)
            {
                Console.WriteLine("Please enter m.");
                check = int.TryParse(Console.ReadLine(), out m);
            }*/
            string[,] matrix = new string[4, 5]
                {   {"ha", "xx", "xx", "xx", "xx"},
                    {"fo", "ha", "ha", "xx", "l"},
                    {"ha", "hi", "ha", "xx", "l"},
                    {"la", "lo", "li", "ha", "m"}
                
                };
                /*for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        Console.WriteLine("Please enter the next element.");
                        matrix[i, j] = Console.ReadLine();
                    }*/

            // Последователно проверяваме всички хоризонтали, вертикали и диагонали на матрицата, търсейки 
            // максималната последователност.
            for (int i=0;i<n;i++)
            {
                currentSequence=1;
                for (int j=1;j<m;j++)
                {
                    if (matrix[i,j]==matrix[i,j-1])
                        currentSequence++;
                    else
                    {
                        if (currentSequence>maxSequence)
                        {
                            maxSequence=currentSequence;
                            element=matrix[i,j-1];
                        }
                        currentSequence = 1;
                    }
                }
                if (currentSequence>maxSequence)
                        {
                            maxSequence=currentSequence;
                            element=matrix[i,m-1];
                            currentSequence=1;
                        }
            }

            for (int i = 0; i < m; i++)
            {
                currentSequence = 1;
                for (int j = 1; j < n; j++)
                {
                    if (matrix[j, i] == matrix[j-1, i])
                        currentSequence++;
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            element = matrix[j-1, i];
                            
                        }
                        currentSequence = 1;
                    }
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    element = matrix[n-1, i];
                    currentSequence = 1;
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                int j = 1;
                int row=i+1;
                currentSequence = 1;
                while ((row < n) && (j < m))
                {
                    if (matrix[row, j] == matrix[row - 1, j - 1])
                        currentSequence++;
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            element = matrix[row - 1, j - 1];
                        }
                        currentSequence = 1;
                    }
                    row++;
                    j++;
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    element = matrix[row - 1, j - 1];
                    currentSequence = 1;
                }
            }

            for (int i = 1; i <m; i++)
            {
                int j = 1;
                int column = i + 1;
                currentSequence = 1;
                while ((j < n) && (column < m))
                {
                    if (matrix[j, column] == matrix[j - 1, column - 1])
                        currentSequence++;
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            element = matrix[j - 1, column - 1];
                        }
                        currentSequence = 1;
                    }
                    column++;
                    j++;
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    element = matrix[j - 1, column - 1];
                    currentSequence = 1;
                }
            }

            //
            for (int i = n - 2; i >= 0; i--)
            {
                int j = m-2;
                int row = i + 1;
                currentSequence = 1;
                while ((row < n) && (j >= 0))
                {
                    if (matrix[row, j] == matrix[row - 1, j + 1])
                        currentSequence++;
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            element = matrix[row - 1, j + 1];
                        }
                        currentSequence = 1;
                    }
                    row++;
                    j--;
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    element = matrix[row - 1, j + 1];
                    currentSequence = 1;
                }
            }
            ////
            for (int i = n-2; i > 0; i--)
            {
                int j = 1;
                int column = i - 1;
                currentSequence = 1;
                while ((j < n) && (column >= m))
                {
                    if (matrix[j, column] == matrix[j - 1, column + 1])
                        currentSequence++;
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            element = matrix[j - 1, column + 1];
                        }
                        currentSequence = 1;
                    }
                    column--;
                    j++;
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    element = matrix[j - 1, column + 1];
                    currentSequence = 1;
                }
            }

            for (int i = 0; i < maxSequence - 1; i++)
                Console.Write(element + ", ");
            Console.Write(element);
            Console.WriteLine();
            
        }
    }
}
