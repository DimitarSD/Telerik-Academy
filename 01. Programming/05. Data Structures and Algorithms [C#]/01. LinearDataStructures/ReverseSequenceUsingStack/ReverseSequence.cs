namespace ReverseSequenceUsingStack
{
    // Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
    using System;
    using System.Collections.Generic;

    public class ReverseSequence
    {
        private const string MainMessage = "How many numbers you want to enter? : ";
        private const string ReversedSequenceMessage = "All the numbers in reversed order.";

        public static void Main()
        {
            Console.Write(MainMessage);
            int length = int.Parse(Console.ReadLine());

            Stack<int> sequenceOfIntegers = new Stack<int>();

            for (int i = 0; i < length; i++)
            {
                sequenceOfIntegers.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine(ReversedSequenceMessage);

            foreach (var number in sequenceOfIntegers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
