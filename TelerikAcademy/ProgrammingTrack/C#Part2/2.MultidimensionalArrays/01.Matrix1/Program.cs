using System;
// Принтираме първата матрица.

namespace _01.Matrix1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=0,counter;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            counter = 1;
            int[,] mass = new int[n,n];
            for (int i=0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    mass[j, i] = counter;
                    counter++;
                }
            for (int i=0; i<n;i++)
            {
                for (int j=0;j<n-1;j++)
                    Console.Write(Convert.ToString(mass[i,j]).PadLeft(4));
                Console.Write(Convert.ToString(mass[i,n-1]).PadLeft(4));
                Console.WriteLine();
            }
        }
    }
}
