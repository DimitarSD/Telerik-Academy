namespace Мinesweeper
{
    public class Points
    {
        private string name;
        private int points;

        public Points()
        {
        }

        public Points(string name, int points)
            : this()
        {
            this.Name = name;
            this.Point = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Point
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }
    }
}
