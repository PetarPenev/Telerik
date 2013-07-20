namespace _07.AllPathsBetweenCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static Stack<Position> paths = new Stack<Position>();

        private static StringBuilder result = new StringBuilder();

        private static char[,] labyrinth = 
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        };

        public static void Main()
        {
            int firstXCoordinate = 0;
            int firstYCoordinate = 0;

            int secondXCoordinate = 4;
            int secondYCoordinate = 6;

            if ((labyrinth[firstXCoordinate, firstYCoordinate] != ' ') || (labyrinth[secondXCoordinate, secondYCoordinate] != ' '))
            {
                throw new ArgumentException("Both points should be empty spaces.");
            }

            labyrinth[secondXCoordinate, secondYCoordinate] = 'e';
            FindPath(firstXCoordinate, firstYCoordinate);
            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void FindPath(int firstCoordinate, int secondCoordinate)
        {
            if (labyrinth[firstCoordinate, secondCoordinate] == 'e')
            {
                paths.Push(new Position(firstCoordinate, secondCoordinate));
                var points = paths.ToList();
                points.Reverse();
                result.Append(string.Join(", ", points) + Environment.NewLine);
                paths.Pop();
                return;
            }

            labyrinth[firstCoordinate, secondCoordinate] = 'v';
            paths.Push(new Position(firstCoordinate, secondCoordinate));

            /// This is here to help with checking the course of action of the program.
            /// PrintLabyrinth();

            if ((secondCoordinate - 1 >= 0) && (labyrinth[firstCoordinate, secondCoordinate - 1] != '*') && (labyrinth[firstCoordinate, secondCoordinate - 1] != 'v'))
            {
                FindPath(firstCoordinate, secondCoordinate - 1);
            }

            if ((secondCoordinate + 1 < labyrinth.GetLength(1)) && (labyrinth[firstCoordinate, secondCoordinate + 1] != '*') 
                && (labyrinth[firstCoordinate, secondCoordinate + 1] != 'v'))
            {
                FindPath(firstCoordinate, secondCoordinate + 1);
            }

            if ((firstCoordinate - 1 >= 0) && (labyrinth[firstCoordinate - 1, secondCoordinate] != '*') && (labyrinth[firstCoordinate - 1, secondCoordinate] != 'v'))
            {
                FindPath(firstCoordinate - 1, secondCoordinate);
            }

            if ((firstCoordinate + 1 < labyrinth.GetLength(0))  && (labyrinth[firstCoordinate + 1, secondCoordinate] != '*')
                && (labyrinth[firstCoordinate + 1, secondCoordinate] != 'v'))
            {
                FindPath(firstCoordinate + 1, secondCoordinate);
            }

            labyrinth[firstCoordinate, secondCoordinate] = ' ';
            paths.Pop();
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