namespace Abstraction
{
    using System;

    public abstract class Figure : IFigure
    {
        public Figure()
        {
        }

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();
    }
}
