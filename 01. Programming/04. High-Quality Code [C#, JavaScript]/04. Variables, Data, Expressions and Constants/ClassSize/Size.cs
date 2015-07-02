namespace ClassSize
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(Size figure, double angleOfRotation)
        {
            double angleOfRotationCos = Math.Cos(angleOfRotation);
            double angleOfRotationSin = Math.Cos(angleOfRotation);

            double newWidth = Math.Abs(angleOfRotationCos) * figure.width + Math.Abs(angleOfRotationSin) * figure.height;
            double newHeight = Math.Abs(angleOfRotationSin) * figure.width + Math.Abs(angleOfRotationCos) * figure.height;

            return new Size(newWidth, newHeight);
        }
    }
}
