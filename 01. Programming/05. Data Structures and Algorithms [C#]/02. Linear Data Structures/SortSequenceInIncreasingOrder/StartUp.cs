namespace SortSequenceInIncreasingOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string MainMessage = "Enter your sequence of numbers on the next line. When you are ready press enter to sort them.";
        private const string PrintMessage = "Sorted in increasing order: {0}";

        public static void Main()
        {
            Console.WriteLine(MainMessage);
            string input = Console.ReadLine();

            var sequenceOfNumbers = new List<int>();

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
