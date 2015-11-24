namespace AlgoAcademy.ProblemTwo
{
    using System;
    using System.Linq;

    /// <summary>
    /// Define class with solution for problem two -> "Super sum" from Telerik Algo Academy April 2012
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/123/Telerik-Algo-Academy-April-2012"/>
    public class StartUp
    {
        private static int startNumber;
        private static int count;

        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            startNumber = numbers[0];
            count = numbers[1];

            long result = SuperSum(startNumber, count);
            Console.WriteLine(result);
        }

        private static long SuperSum(int startNumber, int count)
        {
            if (startNumber == 1)
            {
                int sum = 0;

                for (int i = 1; i <= count; i++)
                {
                    sum += i;
                }

                return sum;
            }

            long currentSum = 0;

            for (int i = 1; i <= count; i++)
            {
                currentSum += SuperSum(startNumber - 1, i);
            }

            return currentSum;
        }
    }
}
