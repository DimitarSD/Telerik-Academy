namespace CohesionAndCoupling
{
    using System;

    public class Parallelepiped
    {
        private const string InvalidWidthValueExceptionMessage = "Width must be a number bigger than {0}";
        private const double WidthMinimumValue = 0;
        private const string InvalidHeightValueExceptionMessage = "Height must be a number bigger than {0}";
        private const double HeightMinimumValue = 0;
        private const string InvalidDepthValueExceptionMessage = "Depth must be a number bigger than {0}";
        private const double DepthMinimumValue = 0;

        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= WidthMinimumValue)
                {
                    string exceptionMessage = string.Format(InvalidWidthValueExceptionMessage, WidthMinimumValue);
                    throw new ArgumentException(exceptionMessage);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= HeightMinimumValue)
                {
                    string exceptionMessage = string.Format(InvalidHeightValueExceptionMessage, HeightMinimumValue);
                    throw new ArgumentException(exceptionMessage);
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= DepthMinimumValue)
                {
                    string exceptionMessage = string.Format(InvalidDepthValueExceptionMessage, DepthMinimumValue);
                    throw new ArgumentException(exceptionMessage);
                }

                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = Geometry.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = Geometry.CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = Geometry.CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = Geometry.CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
