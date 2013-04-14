using System;
// Принтираме четвъртата матрица.
namespace _04.Matrix4
{
    class Program
    {
        static void Main()
        {
            int n = 0, counter,limit, startPosition=0;
            bool check = false, way = false;
            while (!check)
            {
                Console.WriteLine("Please enter n.");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            int[,] mass = new int[n, n];
            counter=1;
            limit=n*n;
            // Обхождаме най-външния "слой" (1 колона, последен ред, последна колона, първи ред), след което влизаме навътре.
            // Продължава, докато не изчерпим числата.
            while (counter <= limit)
            {
                for (int i = startPosition; i < n-startPosition; i++)
                    mass[i, startPosition] = counter++;
                for (int i = startPosition+1; i < n-startPosition; i++)
                    mass[n - startPosition-1, i] = counter++;
                for (int i = n - startPosition - 2; i >= startPosition; i--)
                    mass[i, n - startPosition-1] = counter++;
                for (int i = n - startPosition - 2; i > startPosition; i--)
                    mass[startPosition, i] = counter++;
                startPosition++;
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
