namespace _12.NQueensPuzzle
{
    using System;
    using System.Text;

    public class Program
    {
        private static int[,] unavailablePositions;

        private static int counterOfSolutions = 0;

        public static void Main()
        {
            Console.WriteLine("Please enter the dimensions of the board (respectively, the number of queens to be placed.");
            int n = int.Parse(Console.ReadLine());
            unavailablePositions = new int[n, n];
            for (int i = 0; i < unavailablePositions.GetLength(0); i++)
            {
                PlaceQueens(i, 0, 0);
            }

            Console.WriteLine("The number of solutions is {0}.", counterOfSolutions);
        }

        private static void PlaceQueens(int firstCoordinate, int secondCoordinate, int placedQueens)
        {
            placedQueens++;
            if (placedQueens == unavailablePositions.GetLength(0))
            {
                counterOfSolutions++;
                placedQueens--;
                return;
            }

            for (int i = secondCoordinate; i < unavailablePositions.GetLength(1); i++)
            {
                unavailablePositions[firstCoordinate, i] += 1;
            }

            for (int i = firstCoordinate - 1, j = secondCoordinate + 1; i >= 0 && j < unavailablePositions.GetLength(1); i--, j++)
            {
                unavailablePositions[i, j] += 1;
            }

            for (int i = firstCoordinate + 1, j = secondCoordinate + 1; i < unavailablePositions.GetLength(0) 
                && j < unavailablePositions.GetLength(1); i++, j++)
            {
                unavailablePositions[i, j] += 1;
            }

            for (int i = 0; i < unavailablePositions.GetLength(0); i++)
            {
                if (unavailablePositions[i, secondCoordinate + 1] == 0)
                {
                    PlaceQueens(i, secondCoordinate + 1, placedQueens);
                }
            }

            for (int i = secondCoordinate; i < unavailablePositions.GetLength(1); i++)
            {
                unavailablePositions[firstCoordinate, i] -= 1;
            }

            for (int i = firstCoordinate - 1, j = secondCoordinate + 1; i >= 0 && j < unavailablePositions.GetLength(1); i--, j++)
            {
                unavailablePositions[i, j] -= 1;
            }

            for (int i = firstCoordinate + 1, j = secondCoordinate + 1; i < unavailablePositions.GetLength(0)
                && j < unavailablePositions.GetLength(1); i++, j++)
            {
                unavailablePositions[i, j] -= 1;
            }

            placedQueens--;
        }
    }
}
