namespace RemovingNumbersFromSequence
{
    // Write a program that removes from given sequence all numbers that occur odd number of times. 
    // Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
    using System;
    using System.Collections.Generic;

    public class RemovingNumbers
    {
        private const string PrintMessage = "Result: {0}";

        public static void Main()
        {
            List<int> sequenceOfNumbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Dictionary<int, int> numbers = new Dictionary<int, int>();

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

            // Remome all numbers that occur odd number of times
            foreach (var element in numbers)
            {
                if (element.Value % 2 != 0)
                {
                    sequenceOfNumbers.RemoveAll(n => n == element.Key);
                }
            }

            // Print the final result
            Console.WriteLine(PrintMessage, string.Join(", ", sequenceOfNumbers));
        }
    }
}
