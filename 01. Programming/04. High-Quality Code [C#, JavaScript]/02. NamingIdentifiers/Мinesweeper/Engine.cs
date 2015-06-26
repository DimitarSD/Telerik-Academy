namespace Мinesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        private const int NumberOfAllMoves = 35; 

        public static void Main()
        {
            string command = string.Empty;
            char[,] field = CreatePlayingField();
            char[,] mines = PlaceAllMines();
            int count = 0;
            int row = 0;
            int column = 0;
            bool hasExploded = false;
            bool isStart = true;
            bool isEnded = false;
            List<Points> topChampions = new List<Points>(6);

            do
            {
                if (isStart)
                {
                    Console.WriteLine("Lets play Мinesweeper. Try your luck to find all cell without mines. Command 'top' show Score, 'restart' start a new game, 'exit' exit the game.");
                    DrawGameBoard(field);
                    isStart = false;
                }

                Console.Write("Choose row and column: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column) && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Mines.GetRating(topChampions);
                        break;
                    case "restart":
                        field = CreatePlayingField();
                        mines = PlaceAllMines();
                        DrawGameBoard(field);
                        hasExploded = false;
                        isStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                ChangePlayerTurn(field, mines, row, column);
                                count++;
                            }

                            if (NumberOfAllMoves == count)
                            {
                                isEnded = true;
                            }
                            else
                            {
                                DrawGameBoard(field);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command.\n");
                        break;
                }

                if (hasExploded)
                {
                    DrawGameBoard(mines);
                    Console.Write("\nYou die heroically with {0} points. Enter nickname: ", count);
                    string nickname = Console.ReadLine();
                    Points currentPoints = new Points(nickname, count);

                    if (topChampions.Count < 5)
                    {
                        topChampions.Add(currentPoints);
                    }
                    else
                    {
                        for (int i = 0; i < topChampions.Count; i++)
                        {
                            if (topChampions[i].Point < currentPoints.Point)
                            {
                                topChampions.Insert(i, currentPoints);
                                topChampions.RemoveAt(topChampions.Count - 1);
                                break;
                            }
                        }
                    }

                    topChampions.Sort((Points playerOne, Points playerTwo) => playerTwo.Name.CompareTo(playerOne.Name));
                    topChampions.Sort((Points playerOne, Points playerTwo) => playerTwo.Point.CompareTo(playerOne.Point));
                    Mines.GetRating(topChampions);

                    field = CreatePlayingField();
                    mines = PlaceAllMines();
                    count = 0;
                    hasExploded = false;
                    isStart = true;
                }

                if (isEnded)
                {
                    Console.WriteLine("\nYou open 35 cells!!!");
                    DrawGameBoard(mines);
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Points playerPoints = new Points(name, count);
                    topChampions.Add(playerPoints);
                    Mines.GetRating(topChampions);
                    field = CreatePlayingField();
                    mines = PlaceAllMines();
                    count = 0;
                    isEnded = false;
                    isStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void ChangePlayerTurn(char[,] field, char[,] mines, int row, int column)
        {
            char numberOfMines = GetNumberOfMines(mines, row, column);
            mines[row, column] = numberOfMines;
            field[row, column] = numberOfMines;
        }

        private static char GetNumberOfMines(char[,] mines, int currentRow, int currentColumn)
        {
            int count = 0;
            int rows = mines.GetLength(0);
            int columns = mines.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (mines[currentRow - 1, currentColumn] == '*')
                {
                    count++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (mines[currentRow + 1, currentColumn] == '*')
                {
                    count++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (mines[currentRow, currentColumn - 1] == '*')
                {
                    count++;
                }
            }

            if (currentColumn + 1 < columns)
            {
                if (mines[currentRow, currentColumn + 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (mines[currentRow - 1, currentColumn - 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < columns))
            {
                if (mines[currentRow - 1, currentColumn + 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn - 1 >= 0))
            {
                if (mines[currentRow + 1, currentColumn - 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn + 1 < columns))
            {
                if (mines[currentRow + 1, currentColumn + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }

        private static string DrawGameBoard(char[,] gameBoard)
        {
            StringBuilder board = new StringBuilder();

            int rows = gameBoard.GetLength(0);
            int columns = gameBoard.GetLength(1);

            board.AppendLine("\n    0 1 2 3 4 5 6 7 8 9");
            board.AppendLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                board.Append(string.Format("{0} | ", i));
                for (int j = 0; j < columns; j++)
                {
                    board.Append(string.Format("{0} ", gameBoard[i, j]));
                }

                board.Append("|");
                board.AppendLine();
            }

            board.AppendLine("   ---------------------\n");

            return board.ToString();
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

        private static char[,] PlaceAllMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] playingField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> randomPosition = new List<int>();
            while (randomPosition.Count < 15)
            {
                Random position = new Random();
                int currentRandomPosition = position.Next(50);

                if (!randomPosition.Contains(currentRandomPosition))
                {
                    randomPosition.Add(currentRandomPosition);
                }
            }

            foreach (int position in randomPosition)
            {
                int currentColumn = position / columns;
                int currentRow = position % columns;

                if (currentRow == 0 && position != 0)
                {
                    currentColumn--;
                    currentRow = columns;
                }
                else
                {
                    currentRow++;
                }

                playingField[currentColumn, currentRow - 1] = '*';
            }

            return playingField;
        }
    }
}
