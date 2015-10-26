namespace RemoveAllNegativeNumbers
{
    // Write a program that removes from given sequence all negative numbers.
    using System;
    using System.Collections.Generic;

    public class RemoveNegativeNumbers
    {
        private const string BeforeRemovingNegativeNumbersMessage = "The sequence before removing all negative numbers: ";
        private const string AfterRemovingNegativeNumbersMessage = "\nThe sequence after removing all negative numbers: ";

        public static void Main()
        {
            Console.WriteLine(BeforeRemovingNegativeNumbersMessage);

            var sequenceOfNumbers = new List<int>() { 13, -14, 7, -11, -16, 1, -4, 2, -3, 6, -7, 12, -19, 3, -15, 10, -1, -13, -12 };

            Console.WriteLine(string.Join(", ", sequenceOfNumbers));

            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                if (sequenceOfNumbers[i] < 0)
                {
                    sequenceOfNumbers.RemoveAll(n => n < 0);
                }
            }

            Console.WriteLine(AfterRemovingNegativeNumbersMessage);
            Console.WriteLine(string.Join(", ", sequenceOfNumbers));
        }
    }
}
