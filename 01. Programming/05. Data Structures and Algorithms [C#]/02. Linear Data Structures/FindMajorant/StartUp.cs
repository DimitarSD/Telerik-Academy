namespace FindMajorant
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string FoundMajorantMessage = "Majorant number: {0}";
        private const string NotFoundMajorantMessage = "The majorant does not exists.";

        public static void Main()
        {
            // List<int> sequenceOfIntegers = new List<int>() { 2, 5, 1, 6, 6, 2, 6, 9, 6, 6, 6, 6, 1, 10, 6, 6, 9, 1, 6, 8, 6, 6, 6, 6, 6 };
            // List<int> sequenceOfIntegers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            List<int> sequenceOfIntegers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < sequenceOfIntegers.Count; i++)
            {
                if (numbers.ContainsKey(sequenceOfIntegers[i]))
                {
                    numbers[sequenceOfIntegers[i]]++;
                }
                else
                {
                    numbers.Add(sequenceOfIntegers[i], 1);
                }
            }

            int bestCounter = (sequenceOfIntegers.Count / 2) + 1;
            int majorantNumber = 0;
            bool majorantHasFound = false;

            foreach (var number in numbers)
            {
                if (number.Value >= bestCounter)
                {
                    majorantNumber = number.Key;
                    bestCounter = number.Value;
                    majorantHasFound = true;
                }
            }

            if (majorantHasFound)
            {
                Console.WriteLine(FoundMajorantMessage, majorantNumber);
            }
            else
            {
                Console.WriteLine(NotFoundMajorantMessage);
            }
        }
    }
}
