namespace Methods
{
    using System;

    public class Methods
    {
        private const string InvalidSideLengthExceptionMessage = "All sides of the triangle must be a number bigger than 0";
        private const string ImpossibleToCreateFormTriangleExceptionMessage = "It is impossible to form a triangle with sides {0}, {1} and {2}";
        private const string NegativeDigitExceptionMessage = "Digit cannot be negative";
        private const string NotDigitExceptionMessage = "Only digits are valid parameters";
        private const string EmptyArrayExceptionMessage = "The collection must contain atleast {0} element/elements";
        private const string InvalidFormatExceptionMessage = "Invalid format parameter";
        private const int CollectionMinimumLength = 1;

        /// <summary>
        /// Gets three sides of triangle and calculate its area.
        /// </summary>
        /// <returns>Return number of type double - the area of the triangle</returns>
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException(InvalidSideLengthExceptionMessage);
            }

            if ((sideA > sideB + sideC) || (sideB > sideA + sideC) || (sideC > sideA + sideB))
            {
                string exceptionMessage = string.Format(ImpossibleToCreateFormTriangleExceptionMessage, sideA, sideB, sideC);
                throw new ArithmeticException(exceptionMessage);
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
            return area;
        }

        /// <summary>
        /// Convert a digits to its string representation.
        /// </summary>
        /// <param name="digit">Get a digit of type int</param>
        /// <returns>String value - digit as word</returns>
        public static string ConvertDigitToString(int digit)
        {
            if (digit < 0)
            {
                throw new ArgumentException(NegativeDigitExceptionMessage);
            }

            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException(NotDigitExceptionMessage);
            }
        }

        /// <summary>
        /// Gets array of integer and finds the biggest number.
        /// </summary>
        /// <returns>Return the biggest number from array of integers</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                string exceptionMessage = string.Format(EmptyArrayExceptionMessage, CollectionMinimumLength);
                throw new ArgumentException(exceptionMessage);
            }

            int biggestNumber = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (biggestNumber < elements[i])
                {
                    biggestNumber = elements[i];
                }
            }

            return biggestNumber;
        }

        /// <summary>
        /// Gets a number of type double and return it in specified format
        /// </summary>
        /// <returns>Returns string - number in specified format</returns>
        public static string PrintAsNumber(double number, string format)
        {
            if (format == "f")
            {
                string fixedPointNumber = string.Format("{0:f2}", number);
                return fixedPointNumber;
            }
            else if (format == "%")
            {
                string numberInPercentage = string.Format("{0:p0}", number);
                return numberInPercentage;
            }
            else if (format == "r")
            {
                string numberRightAlign = string.Format("{0,8}", number);
                return numberRightAlign;
            }
            else
            {
                throw new ArgumentException(InvalidFormatExceptionMessage);
            }
        }

        /// <summary>
        /// Get X and Y coordinate of two point (start and end) and calculate its distance. 
        /// </summary>
        /// <param name="startPointCoordinateX">Get coordinate X of the start point</param>
        /// <param name="startPointCoordinateY">Get coordinate Y of the start point</param>
        /// <param name="endPointCoordinateX">Get coordinate X of the end point</param>
        /// <param name="endPointCoordinateY">Get coordinate Y of the end point</param>
        /// <returns>Return a value of type double - the distance</returns>
        public static double CalculateDistance(double startPointCoordinateX, double startPointCoordinateY, 
                                               double endPointCoordinateX, double endPointCoordinateY)
        {
            double coordinateXDistance = (endPointCoordinateX - startPointCoordinateX) * (endPointCoordinateX - startPointCoordinateX);
            double coordinateYDistance = (endPointCoordinateY - startPointCoordinateY) * (endPointCoordinateY - startPointCoordinateY);

            double distance = Math.Sqrt(coordinateXDistance + coordinateYDistance);
            return distance;
        }

        /// <summary>
        /// Get coordinate Y of two points
        /// </summary>
        /// <returns>Return a boolean value </returns>
        public static bool CheckIsHorizontalLine(double startPointCoordinateY, double endPointCoordinateY)
        {
            return startPointCoordinateY == endPointCoordinateY;
        }

        /// <summary>
        /// Get coordinate Y of two points
        /// </summary>
        /// <returns>Return a boolean value</returns>
        public static bool CheckIsVerticalLine(double startPointCoordinateX, double endPointCoordinateX)
        {
            return startPointCoordinateX == endPointCoordinateX;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            string fixedPointNumber = PrintAsNumber(1.3, "f");
            Console.WriteLine(fixedPointNumber);

            string numberInPercentage = PrintAsNumber(0.75, "%");
            Console.WriteLine(numberInPercentage);

            string numberRightAlign = PrintAsNumber(2.30, "r");
            Console.WriteLine(numberRightAlign);

            bool isHorizontalLine = CheckIsHorizontalLine(-1, 2.5);
            Console.WriteLine("Horizontal? - " + isHorizontalLine);

            bool isVerticalLine = CheckIsVerticalLine(3, 3);
            Console.WriteLine("Vertical? - " + isVerticalLine);

            double distance = CalculateDistance(3, -1, 3, 2.5);
            Console.WriteLine("Distance: {0}", distance);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
