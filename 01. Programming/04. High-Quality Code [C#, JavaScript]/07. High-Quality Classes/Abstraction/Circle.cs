namespace Abstraction
{
    using System;

    public class Circle : Figure, IFigure
    {
        private const string RadiusInvalidValueExceptionMessage = "Radius must be a positive number bigger than {0}";
        private const double RadiusMinimumValue = 0;

        private double radius;

        public Circle(double radius) 
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value <= RadiusMinimumValue)
                {
                    string exceptionMessage = string.Format(RadiusInvalidValueExceptionMessage, RadiusMinimumValue);
                    throw new ArgumentException(exceptionMessage);
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
