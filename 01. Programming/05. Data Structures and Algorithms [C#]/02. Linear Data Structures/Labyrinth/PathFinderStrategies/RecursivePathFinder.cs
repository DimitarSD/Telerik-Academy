namespace Labyrinth.PathFinderStrategies
{
    using System;

    using Labyrinth.Constants;

    public class RecursivePathFinder : IPathFinder
    {
        public string[,] FindAllPaths(string[,] matrix)
        {
            var startupCell = this.GetStartupCell(matrix);

            this.FindPathsRecursively(matrix, startupCell);
            this.MarkInaccessibleCells(matrix);

            return matrix;
        }

        private void FindPathsRecursively(string[,] matrix, Cell cell)
        {
            var currentCell = cell;
            int coordinateX = currentCell.CoordinateX;
            int coordinateY = currentCell.CoordinateY;
            int nextValue = currentCell.Value + 1;

            // Bottom of recursion
            if (!this.TryVisitCell(matrix, currentCell) && currentCell.Value != 0)
            {
                return;
            }

            this.FindPathsRecursively(matrix, new Cell(coordinateX + 1, coordinateY, nextValue));
            this.FindPathsRecursively(matrix, new Cell(coordinateX - 1, coordinateY, nextValue));
            this.FindPathsRecursively(matrix, new Cell(coordinateX, coordinateY + 1, nextValue));
            this.FindPathsRecursively(matrix, new Cell(coordinateX, coordinateY - 1, nextValue));
        }

        private Cell GetStartupCell(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLongLength(1); column++)
                {
                    if (matrix[row, column].CompareTo(LabyrinthSigns.StartupSign) == 0)
                    {
                        return new Cell(row, column, 0);
                    }
                }
            }

            throw new ArgumentOutOfRangeException(ErrorMessages.NoStartupCellFoundExceptionMessage);
        }

        private bool TryVisitCell(string[,] matrix, Cell cell)
        {
            if (this.IsCellAccessible(matrix, cell))
            {
                matrix[cell.CoordinateX, cell.CoordinateY] = cell.Value.ToString();
                return true;
            }

            return false;
        }

        private bool IsCellAccessible(string[,] matrix, Cell cell)
        {
            long rows = matrix.GetLongLength(0);
            long cols = matrix.GetLongLength(1);
            int row = cell.CoordinateX;
            int col = cell.CoordinateY;

            if (row < 0 || row >= rows ||
                col < 0 || col >= cols ||
                matrix[row, col] != LabyrinthSigns.EmptySign)
            {
                return false;
            }

            return true;
        }

        private void MarkInaccessibleCells(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLongLength(1); column++)
                {
                    if (matrix[row, column].CompareTo(LabyrinthSigns.EmptySign) == 0)
                    {
                        matrix[row, column] = LabyrinthSigns.UnreachableSign;
                    }
                }
            }
        }
    }
}
