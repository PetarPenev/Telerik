namespace _09.LargestConnectedArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static char[,] labyrinth = 
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
        };

        public static void Main()
        {
            int maxConnectedElements = 0;
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == ' ')
                    {
                        int counter = 0;
                        FindConnectedArea(i, j, ref counter);
                        if (counter > maxConnectedElements)
                        {
                            maxConnectedElements = counter;
                        }
                    }
                }
            }

            Console.WriteLine("The largest connected area has {0} positions in it.", maxConnectedElements);          
        }

        private static void FindConnectedArea(int firstCoordinate, int secondCoordinate, ref int counter)
        {
            labyrinth[firstCoordinate, secondCoordinate] = 'v';
            counter++;

            /// This is here to help with checking the course of action of the program.
            /// PrintLabyrinth();

            if ((secondCoordinate - 1 >= 0) && (labyrinth[firstCoordinate, secondCoordinate - 1] != '*') && (labyrinth[firstCoordinate, secondCoordinate - 1] != 'v'))
            {
                FindConnectedArea(firstCoordinate, secondCoordinate - 1, ref counter);
            }

            if ((secondCoordinate + 1 < labyrinth.GetLength(1)) && (labyrinth[firstCoordinate, secondCoordinate + 1] != '*')
                && (labyrinth[firstCoordinate, secondCoordinate + 1] != 'v'))
            {
                FindConnectedArea(firstCoordinate, secondCoordinate + 1, ref counter);
            }

            if ((firstCoordinate - 1 >= 0) && (labyrinth[firstCoordinate - 1, secondCoordinate] != '*') && (labyrinth[firstCoordinate - 1, secondCoordinate] != 'v'))
            {
                FindConnectedArea(firstCoordinate - 1, secondCoordinate, ref counter);
            }

            if ((firstCoordinate + 1 < labyrinth.GetLength(0)) && (labyrinth[firstCoordinate + 1, secondCoordinate] != '*')
                && (labyrinth[firstCoordinate + 1, secondCoordinate] != 'v'))
            {
                FindConnectedArea(firstCoordinate + 1, secondCoordinate, ref counter);
            }
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