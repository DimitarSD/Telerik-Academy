namespace Labyrinth
{
    public struct Cell
    {
        /// <summary>
        /// Creates a new instance of Cell class with coordinate X and Y of the cell and value
        /// </summary>
        /// <param name="coordinateX">Coordinate X of the cell</param>
        /// <param name="coordinateY">Coordinate Y of the cell</param>
        /// <param name="value">Value to be set in the cell</param>
        public Cell(int coordinateX, int coordinateY, int value) 
            : this()
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.Value = value;
        }

        /// <summary>
        /// Gets the coordinate X of the cell
        /// </summary>
        public int CoordinateX { get; private set; }

        /// <summary>
        /// Gets the coordinate Y of the cell
        /// </summary>
        public int CoordinateY { get; private set; }

        /// <summary>
        /// Gets the value of the cell
        /// </summary>
        public int Value { get; private set; }
    }
}
