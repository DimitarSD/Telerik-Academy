namespace MinimalEditDistance
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const double ReplaceLetterCosts = 1;
        private const double DeleteLetterCosts = 0.9;
        private const double InsertLetterCosts = 0.8;

        private static double[,] matrix;

        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            string input = Console.ReadLine();
            string output = Console.ReadLine();

            var rowsSize = input.Length + 1;
            var columnsSize = output.Length + 1;

            matrix = new double[rowsSize, columnsSize];

            FillFirstRow();
            FillFirstColumn();
            FillMatrix(output, input);
            PrintMatrix();
            PrintAnswer();
        }

        private static void FillFirstRow()
        {
            for (int col = 1; col < matrix.GetLongLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + DeleteLetterCosts;
            }
        }

        private static void FillFirstColumn()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + DeleteLetterCosts;
            }
        }

        private static void FillMatrix(string output, string input)
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    var replaceCosts = matrix[row - 1, col - 1];
                    if (output[col - 1] != input[row - 1])
                    {
                        replaceCosts += ReplaceLetterCosts;
                    }

                    var addCosts = matrix[row, col - 1] + InsertLetterCosts;
                    var removeCosts = matrix[row - 1, col] + DeleteLetterCosts;

                    var minCosts = GetMin(replaceCosts, removeCosts, addCosts);
                    matrix[row, col] = minCosts;
                }
            }
        }

        /// <summary>
        /// Prints the filled matrix on the console with simple style for better preview of the user
        /// </summary>
        private static void PrintMatrix()
        {
            string line = new string('-', matrix.GetLength(0) * 6);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);

            for (int row = 0; row < matrix.GetLongLength(1); row++)
            {
                for (int column = 0; column < matrix.GetLongLength(0); column++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matrix[row, column].ToString().PadLeft(5));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("|");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + line);
            }
        }

        private static double GetMin(params double[] elements)
        {
            return elements.Min();
        }

        private static void PrintAnswer()
        {
            var cost = matrix[matrix.GetLongLength(0) - 1, matrix.GetLongLength(1) - 1];
            Console.WriteLine("Minimal Edit Distance Costs: {0}", cost);
        }
    }
}
