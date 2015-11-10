namespace LargestConnectedArea
{
    using System;
    
    public class StartUp
    {
        private const string VisitedCell = "";
        private const string PassableCell = "x";

        // Passable cell is marked with "x"
        private static readonly string[,] Matrix =
        {
            { "1", "x", "2", "2", "2", "x" },
            { "x", "x", "x", "2", "4", "x" },
            { "4", "x", "1", "2", "x", "x" },
            { "4", "x", "1", "2", "x", "1" },
            { "4", "x", "1", "x", "x", "x" }
        };
                
        public static void Main()
        {
            PrintMatrix();

            var bestLength = FindLargestConnectedArea();

            Console.WriteLine(
                "\nBest area: {0}\n",
                bestLength != 0 ? string.Format("{0} -> {1} time(s).", PassableCell, bestLength) : "There is no best area.");
        }

        private static int FindLargestConnectedArea()
        {
            int bestLength = int.MinValue;

            for (int row = 0; row < Matrix.GetLongLength(0); row++)
            {
                for (int column = 0; column < Matrix.GetLongLength(1); column++)
                {
                    var currentLength = 0;

                    FindAreaDFS(row, column, ref currentLength);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                    }
                }
            }

            return bestLength;
        }

        private static void FindAreaDFS(int row, int col, ref int currentLength)
        {
            var isNonPassableCell = row < 0 || row >= Matrix.GetLongLength(0) ||
                                    col < 0 || col >= Matrix.GetLongLength(1) ||
                                    Matrix[row, col] != PassableCell;

            if (isNonPassableCell)
            {
                return;
            }

            currentLength++;
            Matrix[row, col] = VisitedCell;

            FindAreaDFS(row, col - 1, ref currentLength);
            FindAreaDFS(row, col + 1, ref currentLength);
            FindAreaDFS(row - 1, col, ref currentLength);
            FindAreaDFS(row + 1, col, ref currentLength);
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < Matrix.GetLongLength(0); row++)
            {
                for (int column = 0; column < Matrix.GetLongLength(1); column++)
                {
                    Console.Write("{0,-3}", Matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
