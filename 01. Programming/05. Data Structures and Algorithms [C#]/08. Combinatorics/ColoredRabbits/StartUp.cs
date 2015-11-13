namespace ColoredRabbits
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Solution for problem 2 -> "Colored Rabbits" from Telerik Algo Academy @ October 2012
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012"/>
    public class StartUp
    {
        private static readonly Dictionary<int, int> RabbitsCount = new Dictionary<int, int>();

        public static void Main()
        {
            string input = Console.ReadLine();

            int numberOfRabbits = int.Parse(input);

            // Gets all rabbits answers -> using dictionary to save the their result
            for (int i = 0; i < numberOfRabbits; i++)
            {
                // Adds +1 -> the rabbit which the cat had asked
                int rabbitAnswer = int.Parse(Console.ReadLine()) + 1;

                if (!RabbitsCount.ContainsKey(rabbitAnswer))
                {
                    RabbitsCount.Add(rabbitAnswer, 0);
                }

                RabbitsCount[rabbitAnswer]++;
            }

            int totalRabits = 0;

            foreach (var rabbits in RabbitsCount)
            {
                totalRabits += (int)Math.Ceiling((double)rabbits.Value / rabbits.Key) * rabbits.Key;
            }

            Console.WriteLine(totalRabits);
        }
    }
}
