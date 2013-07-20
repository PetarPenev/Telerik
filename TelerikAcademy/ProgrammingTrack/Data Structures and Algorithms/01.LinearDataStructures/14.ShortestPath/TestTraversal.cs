namespace _14.ShortestPath
{
    using System;
    using System.Collections.Generic;

    public class TestTraversal
    {
        // We are using classic breadth - first search algorithm.
        public const string StartPositionSymbol = "*";

        public const string UnreachableCellSymbol = "u";

        public static void StartTraversal(string[,] labyrinth)
        {
            Tuple<int, int> startPosition = GetStartPosition(labyrinth);
            if (startPosition.Item1 == -1)
            {
                throw new ArgumentException("No start position specified.");
            }

            Traverse(labyrinth, startPosition);
        }

        public static Tuple<int, int> GetStartPosition(string[,] labyrinth)
        {
            Tuple<int, int> startPosition = new Tuple<int, int>(-1, -1);

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == StartPositionSymbol)
                    {
                        startPosition = new Tuple<int, int>(i, j);
                    }
                }
            }

            return startPosition;
        }

        public static void Traverse(string[,] labyrinth, Tuple<int, int> startPosition)
        {
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(startPosition.Item1, startPosition.Item2, 1));

            while (queue.Count != 0)
            {
                Tuple<int, int, int> currentPosition = queue.Dequeue();
             
                CheckToAdd(new Tuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2), labyrinth, queue, currentPosition.Item3);
                CheckToAdd(new Tuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2), labyrinth, queue, currentPosition.Item3);
                CheckToAdd(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1), labyrinth, queue, currentPosition.Item3);
                CheckToAdd(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1), labyrinth, queue, currentPosition.Item3);
            }
        }

        public static bool CheckPosition(int row, int col, string[,] labyrinth, int distance)
        {
            if ((row >= labyrinth.GetLength(0)) || (col >= labyrinth.GetLength(1)) || (row < 0) || (col < 0))
            {
                return false;
            }

            if (labyrinth[row, col] == "x")
            {
                return false;
            }

            if (labyrinth[row, col] == "0")
            {
                return true;
            }

            if (labyrinth[row, col] == StartPositionSymbol)
            {
                return false;
            }

            if (int.Parse(labyrinth[row, col]) > distance)
            {
                return true;
            }

            return false;
        }

        public static void CheckToAdd(Tuple<int, int> position, string[,] labyrinth, Queue<Tuple<int, int, int>> queue, int distance)
        {
            bool addPosition = CheckPosition(position.Item1, position.Item2, labyrinth, distance);

            if (addPosition)
            {
                labyrinth[position.Item1, position.Item2] = distance.ToString();
                queue.Enqueue(new Tuple<int, int, int>(position.Item1, position.Item2, distance + 1));
            }
        }

        public static void Print(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write("{0, 4} ", labyrinth[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void ReplaceUnreachableCells(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = UnreachableCellSymbol;
                    }
                }
            }
        }

        public static void Main()
        {
            string[,] labyrinth = new string[6, 6] 
            {
             { "0", "0", "0", "x", "0", "x" },
             { "0", "x", "0", "x", "0", "x" },
             { "0", "*", "x", "0", "x", "0" },
             { "0", "x", "0", "0", "0", "0" },
             { "0", "0", "0", "x", "x", "0" },
             { "0", "0", "0", "x", "0", "x" },
            };

            StartTraversal(labyrinth);
            ReplaceUnreachableCells(labyrinth);

            Console.WriteLine("The traversed labyrinth:");
            Print(labyrinth);
        }
    }
}
