namespace CohesionAndCoupling
{
    using System;

    public class Geometry
    {
        public static double CalculateDistance2D(
                             double startPointCoordinateX, 
                             double startPointCoordinateY, 
                             double endPointCoordinateX, 
                             double endPointCoordinateY)
        {
            double coordinateXDistance = (endPointCoordinateX - startPointCoordinateX) * (endPointCoordinateX - startPointCoordinateX);
            double coordinateYDistance = (endPointCoordinateY - startPointCoordinateY) * (endPointCoordinateY - startPointCoordinateY);

            double distance = Math.Sqrt(coordinateXDistance + coordinateYDistance);
            return distance;
        }

        public static double CalculateDistance3D(
                             double startPointCoordinateX, 
                             double startPointCoordinateY, 
                             double startPointCoordinateZ, 
                             double endPointCoordinateX, 
                             double endPointCoordinateY, 
                             double endPointCoordinateZ)
        {
            double coordinateXDistance = 
                (endPointCoordinateX - startPointCoordinateX) * (endPointCoordinateX - startPointCoordinateX);

            double coordinateYDistance = 
                (endPointCoordinateY - startPointCoordinateY) * (endPointCoordinateY - startPointCoordinateY);

            double coordinateZDistance = 
                (endPointCoordinateZ - startPointCoordinateZ) * (endPointCoordinateZ - startPointCoordinateZ);

            double distance = Math.Sqrt(coordinateXDistance + coordinateYDistance + coordinateZDistance);
            return distance;
        }
    }
}
