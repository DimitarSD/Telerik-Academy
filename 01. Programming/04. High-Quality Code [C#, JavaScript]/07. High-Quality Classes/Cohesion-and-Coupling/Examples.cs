namespace CohesionAndCoupling
{
    using System;

    public class Examples
    {
        private const string DistancePrintMessage = "Distance in the {0} space = {1:f2}";

        public static void Main()
        {
            string firstFileExtension = File.GetFileExtension("example");
            Console.WriteLine(firstFileExtension);

            string secondFileExtension = File.GetFileExtension("example.pdf");
            Console.WriteLine(secondFileExtension);

            string thirdFileExtension = File.GetFileExtension("example.new.pdf");
            Console.WriteLine(thirdFileExtension);

            string firstFileName = File.GetFileNameWithoutExtension("example");
            Console.WriteLine(firstFileName);

            string secondFileName = File.GetFileNameWithoutExtension("example.pdf");
            Console.WriteLine(secondFileName);

            string thirdFileName = File.GetFileNameWithoutExtension("example.new.pdf");
            Console.WriteLine(thirdFileName);

            double distanceBetweenPoints2D = Geometry.CalculateDistance2D(1, -2, 3, 4);
            Console.WriteLine(DistancePrintMessage, "2D", distanceBetweenPoints2D);

            double distanceBetweenPoints3D = Geometry.CalculateDistance3D(5, 2, -1, 3, -6, 4);
            Console.WriteLine(DistancePrintMessage, "3D", distanceBetweenPoints3D);

            Parallelepiped figure = new Parallelepiped(3, 4, 5);

            double figureVolume = figure.CalculateVolume();
            Console.WriteLine("Volume = {0:f2}", figureVolume);

            double figureDiagonalXYZ = figure.CalculateDiagonalXYZ();
            Console.WriteLine("Diagonal XYZ = {0:f2}", figureDiagonalXYZ);

            double figureDiagonalXY = figure.CalculateDiagonalXY();
            Console.WriteLine("Diagonal XY = {0:f2}", figureDiagonalXY);

            double figureDiagonalXZ = figure.CalculateDiagonalXZ();
            Console.WriteLine("Diagonal XZ = {0:f2}", figureDiagonalXZ);

            double figureDiagonalYZ = figure.CalculateDiagonalYZ();
            Console.WriteLine("Diagonal YZ = {0:f2}", figureDiagonalYZ);
        }
    }
}
