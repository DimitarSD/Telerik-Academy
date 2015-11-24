namespace AlgoAcademy.ProblemOne
{
    using System;
    using System.Linq;

    /// <summary>
    /// Define class with solution for problem one -> "Tribonacci" from Telerik Algo Academy April 2012
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/123/Telerik-Algo-Academy-April-2012"/>
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var numbers = new long[] { input[0], input[1], input[2] };

            long searchedIndex = input[3] - 1;
            long currentIndex = 3;

            while (searchedIndex >= currentIndex)
            {
                long index = currentIndex++ % numbers.Length;
                numbers[index] = numbers.Sum();
            }

            Console.WriteLine(numbers[searchedIndex % numbers.Length]);
        }
    }
}
