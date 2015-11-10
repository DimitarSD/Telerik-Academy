namespace EightQueenPuzzle
{
    using System;
    using System.Diagnostics;
    
    /// <summary>
    /// Solution with complexity n! using technique backtracking.
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/Eight_queens_puzzle"/>
    public class StartUp
    {
        private const int BoardSize = 8;
        private const string QueenSign = "Q";
        private const string EmptyCellSign = ".";

        private static readonly Stopwatch Stopwatch = new Stopwatch();
        private static readonly int[] QueenCell = new int[BoardSize]; // The queen (i, j)

        // Optimization -> quick check for passable cell
        private static readonly bool[] Columns = new bool[BoardSize]; // Check if there is queen on that column
        private static readonly bool[] LeftDiagonal = new bool[2 * BoardSize]; // Check if there is queen on that left diagonal
        private static readonly bool[] RightDiagonal = new bool[2 * BoardSize]; // Check if there is queen on that right diagonal

        private static bool isSolutionFound = false;

        public static void Main()
        {
            Stopwatch.Start();

            int solutionsCount = 0;
            SolveQueenPuzzle(0, ref solutionsCount, findAllSolutions: true, printSolutions: false);

            Stopwatch.Stop();

            Console.WriteLine("Found {0} solutions.", solutionsCount);
            Console.WriteLine("\nElapsed time: {0}\n", Stopwatch.Elapsed);
            Console.WriteLine("If you want to see all solutions set \"printSolutions\" to \"true\"");
        }

        private static void SolveQueenPuzzle(int row, ref int solutionsCount, bool printSolutions = false, bool findAllSolutions = false)
        {
            if (isSolutionFound && !findAllSolutions)
            {
                return;
            }

            if (row == BoardSize)
            {
                solutionsCount++;
                isSolutionFound = true;

                if (printSolutions)
                {
                    PrintChessBoard();
                }
            }

            for (int col = 0; col < BoardSize; col++)
            {
                // Check for passable cell
                if (!Columns[col] && !LeftDiagonal[row + col] && !RightDiagonal[BoardSize + (row - col)])
                {
                    Columns[col] = LeftDiagonal[row + col] = RightDiagonal[BoardSize + (row - col)] = true; // Visited
                    QueenCell[row] = col;

                    SolveQueenPuzzle(row + 1, ref solutionsCount, printSolutions, findAllSolutions);

                    Columns[col] = LeftDiagonal[row + col] = RightDiagonal[BoardSize + (row - col)] = false; // Backtracking
                }
            }
        }

        private static void PrintChessBoard()
        {
            Console.WriteLine(new string('=', 22));
            for (int row = 0; row < BoardSize; row++)
            {
                for (int column = 0; column < BoardSize; column++)
                {
                    Console.Write("{0,-2} ", QueenCell[row] == column ? QueenSign : EmptyCellSign);
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('=', 22));
            Console.WriteLine("\n\n\n");
        }
    }
}
