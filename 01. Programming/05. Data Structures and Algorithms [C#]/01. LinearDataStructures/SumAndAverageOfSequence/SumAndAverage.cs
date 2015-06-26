namespace SumAndAverageOfSequence
{
    // Write a program that reads from the console a sequence of positive integer numbers. 
    // The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. 
    // Keep the sequence in List<int>.
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        private const string MainMessage = "Please enter a sequence of positive integer numbers.";
        private const string PrintSumMessage = "Sum of all numbers: {0}";
        private const string PrintAverageMessage = "Average: {0}";

        public static void Main()
        {
            Console.WriteLine(MainMessage);
            List<int> sequenceOfNumbers = new List<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                sequenceOfNumbers.Add(int.Parse(input));
                input = Console.ReadLine();
            }

            int sum = sequenceOfNumbers.Sum();
            Console.WriteLine(PrintSumMessage, sum);

            double average = sequenceOfNumbers.Average();
            Console.WriteLine(PrintAverageMessage, average);
        }
    }
}
