namespace _08.AllPossiblePathsInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static bool pathFound = false;

        private static char[,] labyrinth = new char[100, 100];

        public static void Main()
        {
            int firstXCoordinate = 0;
            int firstYCoordinate = 0;

            int secondXCoordinate = 99;
            int secondYCoordinate = 99;

            labyrinth[secondXCoordinate, secondYCoordinate] = 'e';
            FindPath(firstXCoordinate, firstYCoordinate);
            Console.WriteLine("Path exists between the positions: {0}", pathFound);
        }

        private static void FindPath(int firstCoordinate, int secondCoordinate)
        {
            if (labyrinth[firstCoordinate, secondCoordinate] == 'e')
            {
                pathFound = true;
                return;
            }

            labyrinth[firstCoordinate, secondCoordinate] = 'v';

            /// This is here to help with checking the course of action of the program.
            /// PrintLabyrinth();

            if ((secondCoordinate - 1 >= 0) && (labyrinth[firstCoordinate, secondCoordinate - 1] != '*') && (labyrinth[firstCoordinate, secondCoordinate - 1] != 'v'))
            {
                FindPath(firstCoordinate, secondCoordinate - 1);
            }

            if (pathFound)
            {
                return;
            }

            if ((secondCoordinate + 1 < labyrinth.GetLength(1)) && (labyrinth[firstCoordinate, secondCoordinate + 1] != '*')
                && (labyrinth[firstCoordinate, secondCoordinate + 1] != 'v'))
            {
                FindPath(firstCoordinate, secondCoordinate + 1);
            }

            if (pathFound)
            {
                return;
            }

            if ((firstCoordinate - 1 >= 0) && (labyrinth[firstCoordinate - 1, secondCoordinate] != '*') && (labyrinth[firstCoordinate - 1, secondCoordinate] != 'v'))
            {
                FindPath(firstCoordinate - 1, secondCoordinate);
            }

            if (pathFound)
            {
                return;
            }

            if ((firstCoordinate + 1 < labyrinth.GetLength(0)) && (labyrinth[firstCoordinate + 1, secondCoordinate] != '*')
                && (labyrinth[firstCoordinate + 1, secondCoordinate] != 'v'))
            {
                FindPath(firstCoordinate + 1, secondCoordinate);
            }

            if (pathFound)
            {
                return;
            }

            labyrinth[firstCoordinate, secondCoordinate] = ' ';
        }

        private static void PrintLabyrinth()
        {
            StringBuilder representation = new StringBuilder();

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    representation.Append(labyrinth[i, j] + " ");
                }

                representation.Append(Environment.NewLine);
            }

            Console.WriteLine(representation);
        }
    }
}
