namespace RoboticZombieCamel
{
    using System;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// Solution for problem 10 -> Robotic Zombie Camel from Telerik Algo Academy @ October 2012
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012"/>
    public class StartUp
    {
        private static readonly BigInteger Module = new BigInteger(ulong.MaxValue) + 1;

        public static void Main()
        {
            string input = Console.ReadLine();
            int numberOfObelisks = int.Parse(input);
            int[] values = new int[numberOfObelisks];

            for (int i = 0; i < numberOfObelisks; i++)
            {
                // Hack -> there is an empty row in the input tests in BG coder.
                Console.ReadLine();

                // Reads the coordinates of each obelisk
                string obeliskCoordinates = Console.ReadLine(); 

                // Split and parse the coordinates of the current obelisk
                var coordinates = obeliskCoordinates.Split(' ').Select(int.Parse).ToArray();
                
                // Gets value of each coordinate -> X and Y
                var valueX = Math.Abs(coordinates[0]);
                var valueY = Math.Abs(coordinates[1]);

                // Save the accumulation of X and Y 
                values[i] = valueX + valueY;
            }

            var pow = (BigInteger)1 << (numberOfObelisks - 1);
            var result = (values.Sum() * pow) % Module;

            Console.WriteLine(result);
        }
    }
}
