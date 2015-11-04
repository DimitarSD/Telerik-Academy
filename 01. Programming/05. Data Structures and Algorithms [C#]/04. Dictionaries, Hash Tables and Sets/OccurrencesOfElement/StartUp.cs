namespace OccurrencesOfElement
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string PrintResultFormatMessage = "{0} -> {1} times";

        public static void Main()
        {
            var numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var occurrencesOfNumber = CountNumberOfOccurrences(numbers);

            foreach (var number in occurrencesOfNumber)
            {
                Console.WriteLine(PrintResultFormatMessage, number.Key, number.Value);
            }
        }

        public static Dictionary<double, int> CountNumberOfOccurrences(double[] numbers)
        {
            var dictionaryOfNumbers = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var key = numbers[i];

                if (!dictionaryOfNumbers.ContainsKey(key))
                {
                    dictionaryOfNumbers[key] = 1;
                }
                else
                {
                    dictionaryOfNumbers[key]++;
                }
            }

            return dictionaryOfNumbers;
        }
    }
}
