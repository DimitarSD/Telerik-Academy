namespace RotatingWalkInMatrix
{
    public class MatrixTraversal
    {
        private static readonly int[] DirectionsX = { 1, 0, -1, -1, 0, 1, -1, 0 };
        private static readonly int[] DirectionsY = { 1, -1, 0, 1, 1, 0, -1, 1 };

        public static int[,] GenerateMatrix(byte size)
        {
            int[,] matrix = new int[size, size];

            Cell startupCell = FindFirstEmptyCellIfExists(matrix);
            if (startupCell != null)
            {
                FillMatrix(matrix, startupCell);
            }

            return matrix;
        }

        private static void FillMatrix(int[,] matrix, Cell startupCell)
        {
            var currentCell = startupCell;
            var dirIndex = 0;

            while (IsCellPassable(matrix, currentCell))
            {
                matrix[currentCell.X, currentCell.Y] = currentCell.Value;

                while (!IsNextCellPassable(matrix, currentCell, dirIndex) &&
                       CanCellMoveSomewhere(matrix, currentCell, dirIndex))
                {
                    dirIndex = (dirIndex + 1) % DirectionsX.Length;
                }

                currentCell.X += DirectionsX[dirIndex];
                currentCell.Y += DirectionsY[dirIndex];
                currentCell.Value++;
            }

            var nextStartupCell = FindFirstEmptyCellIfExists(matrix);
            if (nextStartupCell != null)
            {
                nextStartupCell.Value = currentCell.Value;
                FillMatrix(matrix, nextStartupCell);
            }
        }

        private static Cell FindFirstEmptyCellIfExists(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        var firstEmptyCell = new Cell(i, j);
                        return firstEmptyCell;
                    }
                }
            }

            return null;
        }

        private static bool IsCellPassable(int[,] matrix, Cell currentCell)
        {
            bool isCellPassable = currentCell.X >= 0 && currentCell.X < matrix.GetLongLength(0) &&
                                  currentCell.Y >= 0 && currentCell.Y < matrix.GetLongLength(1) &&
                                  matrix[currentCell.X, currentCell.Y] == 0;

            return isCellPassable;
        }

        private static bool IsNextCellPassable(int[,] matrix, Cell currentCell, int dirIndex)
        {
            Cell nextCell = new Cell()
            {
                X = currentCell.X + DirectionsX[dirIndex],
                Y = currentCell.Y + DirectionsY[dirIndex]
            };

            return IsCellPassable(matrix, nextCell);
        }

        private static bool CanCellMoveSomewhere(int[,] matrix, Cell currentCell, int dirIndex)
        {
            for (int i = 0; i < DirectionsX.Length; i++)
            {
                dirIndex = (dirIndex + 1) % DirectionsX.Length;

                if (IsNextCellPassable(matrix, currentCell, dirIndex))
                {
                    return true;
                }
            }

            return false;
        }
    }
}