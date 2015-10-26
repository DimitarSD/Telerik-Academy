namespace AppereanceOfEachElement
{
    // Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    // Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    // 2 -> 2 times
    // 3 -> 4 times
    // 4 -> 3 times
    using System;
    using System.Collections.Generic;

    public class AppereanceOfElements
    {
        private const string PrintMessage = "{0} -> {1} times";
        
        public static void Main()
        {
            List<int> sequenceOfIntegers = new List<int>() 
            {
                2, 5, 1, 6, 3, 2, 3, 9, 3, 6, 7, 6, 1, 10, 6, 4, 9, 1, 6, 8, 6, 4, 3, 6, 7,
                2, 5, 1, 6, 3, 2, 3, 9, 3, 6, 7, 6, 1, 10, 6, 4, 9, 1, 6, 8, 6, 4, 3, 6, 7,
                2, 5, 1, 6, 3, 2, 3, 9, 3, 6, 7, 6, 1, 10, 6, 4, 9, 1, 6, 8, 6, 4, 3, 6, 7,
            };

            sequenceOfIntegers.Sort();

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < sequenceOfIntegers.Count; i++)
            {
                if (numbers.ContainsKey(sequenceOfIntegers[i]))
                {
                    int index = sequenceOfIntegers[i];
                    numbers[index]++;
                }
                else
                {
                    numbers.Add(sequenceOfIntegers[i], 1);
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(PrintMessage, number.Key, number.Value);
            }
        }
    }
}
