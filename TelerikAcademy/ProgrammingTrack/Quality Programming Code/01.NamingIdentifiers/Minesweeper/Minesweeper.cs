// Used standard code refactoring and naming conventions. Removed one unnecessary method, moved the class Player
// to a seperate .cs file and fixed other minor errors.
namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {        
        public static void Main()
        {
            string command = string.Empty;
            char[,] field = CreatePlayingField();
            char[,] mines = CreateMines();
            int counter = 0;
            bool isMineHit = false;
            List<Player> leaderboard = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool isToStart = true;
            const int CellsToOpen = 35;
            bool gameFinished = false;

            do
            {
                if (isToStart)
                {
                    Console.WriteLine("Let's play Minesweeper. Try your luck and skill." +
                    " Command 'top' shows the ranking, 'restart' starts a new game, 'exit' is for quitting!");
                    UpdateField(field);
                    isToStart = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        {
                            GetLeaderboard(leaderboard);
                            break;
                        }

                    case "restart":
                        {
                            field = CreatePlayingField();
                            mines = CreateMines();
                            UpdateField(field);
                            isMineHit = false;
                            isToStart = false;
                            break;
                        }

                    case "exit":
                        {
                            Console.WriteLine("Bye Bye!");
                            break;
                        }

                    case "turn":
                        {
                            if (mines[row, column] != '*')
                            {
                                if (mines[row, column] == '-')
                                {
                                    MakeTurn(field, mines, row, column);
                                    counter++;
                                }

                                if (CellsToOpen == counter)
                                {
                                    gameFinished = true;
                                }
                                else
                                {
                                    UpdateField(field);
                                }
                            }
                            else
                            {
                                isMineHit = true;
                            }

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Error! Invalid command.");
                            break;
                        }
                }

                if (isMineHit)
                {
                    UpdateField(mines);
                    Console.Write("You died with {0} Poins. " + "Enter nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Player t = new Player(nickname, counter);

                    if (leaderboard.Count < 5)
                    {
                        leaderboard.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < leaderboard.Count; i++)
                        {
                            if (leaderboard[i].Points < t.Points)
                            {
                                leaderboard.Insert(i, t);
                                leaderboard.RemoveAt(leaderboard.Count - 1);
                                break;
                            }
                        }
                    }

                    leaderboard.Sort((Player first, Player second) => second.Name.CompareTo(first.Name));
                    leaderboard.Sort((Player first, Player second) => second.Points.CompareTo(first.Points));
                    GetLeaderboard(leaderboard);

                    field = CreatePlayingField();
                    mines = CreateMines();
                    counter = 0;
                    isMineHit = false;
                    isToStart = true;
                }

                if (gameFinished)
                {
                    Console.WriteLine("Congratulations! You win.");
                    UpdateField(mines);
                    Console.WriteLine("Enter your name: ");
                    string nameOfWinner = Console.ReadLine();
                    Player winner = new Player(nameOfWinner, counter);
                    leaderboard.Add(winner);
                    GetLeaderboard(leaderboard);
                    field = CreatePlayingField();
                    mines = CreateMines();
                    counter = 0;
                    gameFinished = false;
                    isToStart = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Produced in Bulgaria.");
            Console.WriteLine("Hope you enjoyed it.");
            Console.Read();
        }

        private static void GetLeaderboard(List<Player> leaderboard)
        {
            Console.WriteLine("Points:");
            if (leaderboard.Count > 0)
            {
                for (int i = 0; i < leaderboard.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells",
                        i + 1, leaderboard[i].Name, leaderboard[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty leaderboard.");
            }
        }

        private static void MakeTurn(char[,] field,
            char[,] mines, int row, int column)
        {
            char numberOfSurroundingMines = GetNumberOfSurroundingMines(mines, row, column);
            mines[row, column] = numberOfSurroundingMines;
            field[row, column] = numberOfSurroundingMines;
        }

        private static void UpdateField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] field = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int nextNumber = random.Next(50);
                if (!randomNumbers.Contains(nextNumber))
                {
                    randomNumbers.Add(nextNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int column = number / columns;
                int row = number % columns;
                if (row == 0 && number != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                field[column, row - 1] = '*';
            }

            return field;
        }

        //// Removed method smetki because it was never used and it fact it doubled some code.

        private static char GetNumberOfSurroundingMines(char[,] mines, int row, int column)
        {
            int minesCounter = 0;
            int rows = mines.GetLength(0);
            int columns = mines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mines[row - 1, column] == '*')
                {
                    minesCounter++;
                }
            }

            if (row + 1 < rows)
            {
                if (mines[row + 1, column] == '*')
                {
                    minesCounter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (mines[row, column - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if (column + 1 < columns)
            {
                if (mines[row, column + 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (mines[row - 1, column - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (mines[row - 1, column + 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (mines[row + 1, column - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (mines[row + 1, column + 1] == '*')
                {
                    minesCounter++;
                }
            }

            return char.Parse(minesCounter.ToString());
        }
    }
}
