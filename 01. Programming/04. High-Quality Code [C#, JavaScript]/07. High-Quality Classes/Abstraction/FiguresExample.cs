namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        private const string PrintMessageCircle = "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.";
        private const string PrintMessageRectangle = "I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.";

        public static void Main()
        {
            var circle = new Circle(5);

            double circlePerimeter = circle.CalculatePerimeter();
            double circleSurface = circle.CalculateSurface();

            Console.WriteLine(PrintMessageCircle, circlePerimeter, circleSurface);

            var rectangle = new Rectangle(2, 3);

            double rectanglePerimeter = rectangle.CalculatePerimeter();
            double rectangleSurface = rectangle.CalculateSurface();

            Console.WriteLine(PrintMessageRectangle, rectanglePerimeter, rectangleSurface);
        }
    }
}
