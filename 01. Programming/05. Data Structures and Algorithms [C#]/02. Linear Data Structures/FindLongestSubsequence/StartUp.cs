namespace FindLongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static List<int> FindTheLongestSubsequenceOfEqualNumbers(List<int> sequenceOfNumbers)
        {
            var finalSequence = new List<int>();
            int maxCounter = int.MinValue;
            int currentCounter = 1;
            int currentNumber = 0;

            for (int i = 0; i < sequenceOfNumbers.Count - 1; i++)
            {
                if (sequenceOfNumbers[i] == sequenceOfNumbers[i + 1])
                {
                    currentCounter++;
                }
                else
                {
                    currentCounter = 1;
                }

                if (maxCounter < currentCounter)
                {
                    maxCounter = currentCounter;
                    currentNumber = sequenceOfNumbers[i];
                }
            }

            for (int i = 0; i < maxCounter; i++)
            {
                finalSequence.Add(currentNumber);
            }

            return finalSequence;
        }

        public static string TestingMethod()
        {
            // var sequenceOfNumbers = new List<int>(){4, 5, 5, 5, 9, 9, 6, 1, 3, 7, 8, 8, 9};
            // var sequenceOfNumbers = new List<int>(){4, 5, 5, 5, 9, 9, 9, 9, 9, 9, 6, 1, 3, 7, 8, 8, 9};
            var sequenceOfNumbers = new List<int>() { 4, 5, 5, 5, 9, 6, 1, 3, 3, 3, 3, 3, 3, 3, 3 };

            var longestSubsequence = FindTheLongestSubsequenceOfEqualNumbers(sequenceOfNumbers);

            return string.Join(", ", longestSubsequence);
        }

        public static void Main()
        {
            string longestSubsequence = TestingMethod();
            Console.WriteLine(longestSubsequence);
        }
    }
}
