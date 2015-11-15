namespace KnapsackProblem
{
    using System;

    public class StartUp
    {
        private static Product[] products;
        private static int[,] matrix;

        internal static void Main()
        {
            // Change the number of the input file to test another case. 
            // Options: 1, 2, 3, 4
            #if DEBUG
            var input = new System.IO.StreamReader("../../input_1.txt");
            Console.SetIn(input);
            #endif

            int maximalWeight;
            Utility.ParseInput(out products, out maximalWeight);
            matrix = new int[products.Length + 1, maximalWeight + 1];

            FillMatrix();

            int maxValueColIndex = FindMaxValueIndexInLastRow();
            var maxValueInLastRow = matrix[products.Length, maxValueColIndex];

            Console.WriteLine("Optimal solution: {0}\n", maxValueInLastRow);
            PrintChosenFoods(maxValueInLastRow, maxValueColIndex);
            Console.WriteLine();
        }

        private static void FillMatrix()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    int upperValue = matrix[row - 1, col], leftValue = 0;
                    int colIndex = col - products[row - 1].Weight;
                    if (colIndex >= 0)
                    {
                        leftValue = matrix[row - 1, colIndex] + products[row - 1].Price;
                    }

                    matrix[row, col] = Math.Max(upperValue, leftValue);
                }
            }
        }

        private static int FindMaxValueIndexInLastRow()
        {
            int maxValue = int.MinValue, indexOfMaxValue = 0;
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                var cellValue = matrix[matrix.GetLongLength(0) - 1, col];
                if (cellValue > maxValue)
                {
                    maxValue = cellValue;
                    indexOfMaxValue = col;
                }
            }

            return indexOfMaxValue;
        }

        private static void PrintChosenFoods(int maxValue, int maxValueColIndex)
        {
            int currentRow = (int)(matrix.GetLongLength(0) - 1), currentCol = maxValueColIndex;
            int currentValue = maxValue, upperValue = 0;

            while (currentRow > 0 && currentCol > 0)
            {
                upperValue = matrix[currentRow - 1, currentCol];

                if (upperValue != currentValue)
                {
                    Console.WriteLine(products[currentRow - 1]);
                    currentCol -= products[currentRow - 1].Weight;
                }

                currentValue = matrix[--currentRow, currentCol];
            }
        }
    }
}
