namespace ShortestSequenceOfOperations
{
    // * We are given numbers N and M and the following operations:
    // a) N = N+1
    // b) N = N+2
    // c) N = N*2
    // Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. 
    // Hint: use a queue.
    // Example: N = 5, M = 16
    // Sequence: 5 -> 7 -> 8 -> 16
    using System;
    using System.Collections.Generic;

    public class FindSequenceOfOperations
    {
        private const string MainMessage = "Enter start and end of your sequence. The end must be always bigger.";

        public static void Main()
        {
            Console.WriteLine(MainMessage);
            
            int start = 0;
            int end = 0;

            do
            {
                Console.Write("Start: ");
                start = int.Parse(Console.ReadLine());
                Console.Write("End: ");
                end = int.Parse(Console.ReadLine());
                Console.WriteLine(new string('-', 25));
            }
            while (end < start);

            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(start);

            int currentElement = start;

            while (currentElement != end)
            {

            }


        }
    }
}
