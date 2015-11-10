namespace AllPassableAreas
{
    using System;
    using System.Collections.Generic;

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
            { "4", "x", "1", "2", "1", "1" },
            { "4", "x", "1", "x", "x", "x" }
        };
          
        public static void Main()
        {
            PrintMatrix();

            var allPassableAreas = FindAllConnectedAreas();

            Console.WriteLine("\nAll passable areas: \n");
            Console.WriteLine(string.Join(Environment.NewLine, allPassableAreas) + Environment.NewLine);
        }

        private static IList<string> FindAllConnectedAreas()
        {
            var allPassableAreas = new List<string>();
            var currentArea = new List<string>();

            for (int row = 0; row < Matrix.GetLongLength(0); row++)
            {
                for (int column = 0; column < Matrix.GetLongLength(1); column++)
                {
                    currentArea.Clear();

                    FindAreaDFS(row, column, currentArea);

                    if (currentArea.Count > 0)
                    {
                        allPassableAreas.Add(string.Format("{0} -> Length: {1}", string.Join(" -> ", currentArea), currentArea.Count));
                    }
                }
            }

            return allPassableAreas;
        }

        private static void FindAreaDFS(int row, int col, IList<string> areaPath)
        {
            var isNonPassableCell = row < 0 || row >= Matrix.GetLongLength(0) ||
                                    col < 0 || col >= Matrix.GetLongLength(1) ||
                                    Matrix[row, col] != PassableCell;

            if (isNonPassableCell)
            {
                return;
            }

            areaPath.Add(string.Format("({0},{1})", row, col));
            Matrix[row, col] = VisitedCell;

            FindAreaDFS(row, col - 1, areaPath);
            FindAreaDFS(row, col + 1, areaPath);
            FindAreaDFS(row - 1, col, areaPath);
            FindAreaDFS(row + 1, col, areaPath);
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
