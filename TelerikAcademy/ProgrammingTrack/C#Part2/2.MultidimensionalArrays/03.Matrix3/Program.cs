using System;
// Принтираме третата матрица.

namespace _03.Matrix3
{
    class Program
    {
        static void Main()
        {
            int n = 0, counter, horizontalIndexRange=1,verticalIndexRange=1,limit=0;
            bool check = false, way = false;
            while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            int[,] mass = new int[n, n];
            counter = 1;
            for (int i = 1; i <= n; i++)
                limit +=  i;
            // Алгоритъмът последователно обхожда всички възможни "диагонали" в матрицата.
            while (counter <= limit)
            {
                for (int i = n - verticalIndexRange, j = 0; (i < n) && (j < horizontalIndexRange); i++, j++)
                {
                    mass[i, j] = counter++;
                }
                verticalIndexRange++;
                horizontalIndexRange++;
            }
            limit = n * n - limit;
            verticalIndexRange-=2;
            horizontalIndexRange-=2;
            while (counter <= n*n)
            {
                for (int i = 0, j = n - horizontalIndexRange; (i < verticalIndexRange) && (j < n); i++, j++)
                {
                    mass[i, j] = counter++;
                }
                verticalIndexRange--;
                horizontalIndexRange--;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                    Console.Write(Convert.ToString(mass[i, j]).PadLeft(4));
                Console.Write(Convert.ToString(mass[i, n - 1]).PadLeft(4));
                Console.WriteLine();
            }

        }
    }
}
