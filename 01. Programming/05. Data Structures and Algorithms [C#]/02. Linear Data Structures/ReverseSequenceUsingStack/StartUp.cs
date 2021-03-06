﻿namespace ReverseSequenceUsingStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string MainMessage = "How many numbers you want to enter? : ";
        private const string ReversedSequenceMessage = "All the numbers in reversed order.";

        public static void Main()
        {
            Console.Write(MainMessage);
            int length = int.Parse(Console.ReadLine());

            var sequenceOfIntegers = new Stack<int>();

            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                int parsedNumber = int.Parse(input);
                sequenceOfIntegers.Push(parsedNumber);
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
