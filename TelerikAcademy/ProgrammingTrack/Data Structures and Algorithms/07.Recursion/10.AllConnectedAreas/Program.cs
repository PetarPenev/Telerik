namespace _10.AllConnectedAreas
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

        private static List<int> sizeOfAreas = new List<int>();

        public static void Main()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == ' ')
                    {
                        int counter = 0;
                        FindConnectedArea(i, j, ref counter);
                        sizeOfAreas.Add(counter);
                    }
                }
            }

            Console.WriteLine("There are connected areas of the following sizes:");
            for (int i = 0; i < sizeOfAreas.Count; i++)
            {
                Console.WriteLine("Connected area of size {0}.", sizeOfAreas[i]);
            }

            if (sizeOfAreas.Count == 0)
            {
                Console.WriteLine("No empty cells in labyrinth.");
            }
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
