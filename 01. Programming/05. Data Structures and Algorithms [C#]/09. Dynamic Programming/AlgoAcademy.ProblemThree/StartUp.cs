namespace AlgoAcademy.ProblemThree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define class with solution for problem three -> "Guitar" from Telerik Algo Academy April 2012
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/123/Telerik-Algo-Academy-April-2012"/>
    public class StartUp
    {
        private static List<int> availableSteps = new List<int>();
        private static int maxVolume;

        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var steps = new List<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            var volume = int.Parse(Console.ReadLine());
            maxVolume = int.Parse(Console.ReadLine());

            AddIfInRange(availableSteps, steps[0], volume);

            var nextAvailableSteps = new List<int>();

            for (int row = 1; row < steps.Count; row++, nextAvailableSteps.Clear())
            {
                for (int column = 0; column < availableSteps.Count; column++)
                {
                    AddIfInRange(nextAvailableSteps, steps[row], availableSteps[column]);
                }

                availableSteps = new HashSet<int>(nextAvailableSteps).ToList();
            }

            Console.WriteLine(availableSteps.Count > 0 ? availableSteps.Max() : -1);
        }

        private static void AddIfInRange(IList<int> steps, int volume, int currentStep)
        {
            var next = currentStep + volume;
            var previous = currentStep - volume;

            if (next <= maxVolume)
            {
                steps.Add(next);
            }

            if (previous >= 0 && previous != next)
            {
                steps.Add(previous);
            }
        }
    }
}
