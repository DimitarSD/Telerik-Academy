namespace RemovingNumbersFromSequence
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string PrintMessage = "Result: {0}";

        public static void Main()
        {
            var sequenceOfNumbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                if (numbers.ContainsKey(sequenceOfNumbers[i]))
                {
                    numbers[sequenceOfNumbers[i]]++;
                }
                else
                {
                    int number = sequenceOfNumbers[i];
                    int appereance = 1;
                    numbers.Add(number, appereance);
                }
            }

            // Remove all numbers that occur odd number of times
            foreach (var element in numbers)
            {
                if (element.Value % 2 != 0)
                {
                    sequenceOfNumbers.RemoveAll(number => number == element.Key);
                }
            }

            Console.WriteLine(PrintMessage, string.Join(", ", sequenceOfNumbers));
        }
    }
}
