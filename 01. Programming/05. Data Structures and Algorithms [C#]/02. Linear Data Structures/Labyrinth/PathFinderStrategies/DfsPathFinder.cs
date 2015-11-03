namespace Labyrinth.PathFinderStrategies
{
    using System;
    using System.Collections.Generic;

    using Labyrinth.Constants;

    public class DfsPathFinder : IPathFinder
    {
        public string[,] FindAllPaths(string[,] matrix)
        {
            var startupCell = this.GetStartupCell(matrix);

            var visitedCells = new Stack<Cell>();
            visitedCells.Push(startupCell);

            while (visitedCells.Count > 0)
            {
                var currentCell = visitedCells.Pop();
                int coordinateX = currentCell.CoordinateX;
                int coordinateY = currentCell.CoordinateY;
                int nextValue = currentCell.Value + 1;

                this.TryVisitCell(visitedCells, matrix, new Cell(coordinateX, coordinateY + 1, nextValue));
                this.TryVisitCell(visitedCells, matrix, new Cell(coordinateX, coordinateY - 1, nextValue));
                this.TryVisitCell(visitedCells, matrix, new Cell(coordinateX + 1, coordinateY, nextValue));
                this.TryVisitCell(visitedCells, matrix, new Cell(coordinateX - 1, coordinateY, nextValue));
            }

            this.MarkInaccessibleCells(matrix);

            return matrix;
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

        private void TryVisitCell(Stack<Cell> visitedCells, string[,] matrix, Cell cell)
        {
            if (this.IsCellAccessible(matrix, cell))
            {
                visitedCells.Push(cell);
                matrix[cell.CoordinateX, cell.CoordinateY] = cell.Value.ToString();
            }
        }

        private bool IsCellAccessible(string[,] matrix, Cell cell)
        {
            long rows = matrix.GetLongLength(0);
            long columns = matrix.GetLongLength(1);
            int row = cell.CoordinateX;
            int column = cell.CoordinateY;

            if (row < 0 || row >= rows ||
                column < 0 || column >= columns ||
                matrix[row, column] != LabyrinthSigns.EmptySign)
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
