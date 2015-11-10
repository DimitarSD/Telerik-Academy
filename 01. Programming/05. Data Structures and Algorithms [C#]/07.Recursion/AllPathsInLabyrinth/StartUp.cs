namespace AllPathsInLabyrinth
{
    using System;

    public class StartUp
    {        
        private const char PassableCell = ' ';
        private const char NonPassableCell = '*';
        private const char FinalCell = 'e';
        
        private static readonly char[,] Labyrinth =
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        private static readonly char[] Directions = new char[Labyrinth.GetLongLength(0) * Labyrinth.GetLongLength(1)];
        private static int pathsCount = 0;

        public static void Main()
        {
            FindAllPaths(0, 0);

            Console.WriteLine("\nTotal paths: {0}\n", pathsCount);
        }

        private static void FindAllPaths(int row, int col, int currentLength = 1, char dir = ' ')
        {
            if (!IsCellPassable(row, col))
            {
                return;
            }

            if (Labyrinth[row, col] == FinalCell)
            {
                PrintPath(currentLength);
                return;
            }

            Directions[currentLength - 1] = dir;
            Labyrinth[row, col] = NonPassableCell;

            FindAllPaths(row - 1, col, currentLength + 1, 'U');  // Up
            FindAllPaths(row + 1, col, currentLength + 1, 'D');  // Down
            FindAllPaths(row, col - 1, currentLength + 1, 'L');  // Left
            FindAllPaths(row, col + 1, currentLength + 1, 'R');  // Right

            Directions[currentLength - 1] = ' ';
            Labyrinth[row, col] = PassableCell;
        }

        private static bool IsCellPassable(int row, int column)
        {
            return row >= 0 && row < Labyrinth.GetLongLength(0) &&
                   column >= 0 && column < Labyrinth.GetLongLength(1) &&
                   Labyrinth[row, column] != NonPassableCell;
        }

        private static void PrintPath(int currentLength)
        {
            Console.Write("Path #{0} -> cells length: {1} -> Direction: ", ++pathsCount, currentLength);

            for (int i = 1; i < currentLength; i++)
            {
                Console.Write(Directions[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
