namespace SortSequenceInIncreasingOrder
{
    // Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortSequence
    {
        private const string MainMessage = "Enter your sequence of numbers on the next line. When you are ready press enter to sort them.";
        private const string PrintMessage = "Sorted in increasing order: {0}";

        public static void Main()
        {
            Console.WriteLine(MainMessage);
            string input = Console.ReadLine();

            List<int> sequenceOfNumbers = new List<int>();

            while (input != string.Empty)
            {
                sequenceOfNumbers.Add(int.Parse(input));
                input = Console.ReadLine();
            }
            
            sequenceOfNumbers.Sort();

            Console.WriteLine(PrintMessage, string.Join(", ", sequenceOfNumbers));
        }
    }
}
