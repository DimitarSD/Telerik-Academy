namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private const string WidthInvalidValueExceptionMessage = "Width must be a positive number bigger than {0}";
        private const double WidthMinimumValue = 0;
        private const string HeightInvalidValueExceptionMessage = "Height must be a positive number bigger than {0}";
        private const double HeightMinimumValue = 0;

        private double width;
        private double height;

        public Rectangle(double width, double height) 
            : base()
        {
            this.Width = width;
            this.Height = height;
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
                    string exceptionMessage = string.Format(WidthInvalidValueExceptionMessage, WidthMinimumValue);
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
                    string exceptionMessage = string.Format(HeightInvalidValueExceptionMessage, HeightMinimumValue);
                    throw new ArgumentException(exceptionMessage);
                }

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
