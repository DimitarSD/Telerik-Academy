namespace PrintMembers
{
    // We are given the following sequence:
    // S1 = N;
    // S2 = S1 + 1;
    // S3 = 2*S1 + 1;
    // S4 = S1 + 2;
    // S5 = S2 + 1;
    // S6 = 2*S2 + 1;
    // S7 = S2 + 2;
    // ...
    // Using the Queue<T> class write a program to print its first 50 members for given N.
    // Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PrintAllMembers
    {
        private const string MainMessage = "Enter number from which the sequence will start: ";
        private const int SequenceMaxLength = 50;
        private const string PrintMessage = "N = {0} -> {1}";

        public static void Main()
        {
            Console.Write(MainMessage);
            int firstElementOfTheSequence = int.Parse(Console.ReadLine());

            List<int> finalSequence = new List<int>();
            finalSequence.Add(firstElementOfTheSequence);

            Queue<int> sequence = new Queue<int>();

            sequence.Enqueue(firstElementOfTheSequence + 1);
            sequence.Enqueue((2 * firstElementOfTheSequence) + 1);
            sequence.Enqueue(firstElementOfTheSequence + 2);

            int index = 0;
            int currentNumber = 0;

            while (true)
            {
                index++;
                currentNumber = sequence.Dequeue();

                sequence.Enqueue(currentNumber + 1);
                sequence.Enqueue((2 * currentNumber) + 1);
                sequence.Enqueue(currentNumber + 2);

                finalSequence.Add(currentNumber);

                if (index == SequenceMaxLength)
                {
                    break;
                }
            }

            Console.WriteLine(PrintMessage, firstElementOfTheSequence, string.Join(", ", finalSequence));
        }
    }
}
