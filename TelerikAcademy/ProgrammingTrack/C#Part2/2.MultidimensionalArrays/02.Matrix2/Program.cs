using System;
// Принтирам втората матрица.

namespace _02.Matrix2
{
    class Program
    {
        static void Main()
        {
            int n = 0, counter;
            bool check = false, way=false;
            while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            int[,] mass = new int[n,n];
            counter=1;
            //Вървим по колони.
            for (int i = 0; i < n; i++)
            {
                //Алтернираме изписването на следващото число първо отгоре-надолу и после отдолу-нагоре.
                if (!way)
                {
                    for (int j = 0; j < n; j++)
                    {
                        mass[j, i] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        mass[j, i] = counter;
                        counter++;
                    }
                }
                way = !way;
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
