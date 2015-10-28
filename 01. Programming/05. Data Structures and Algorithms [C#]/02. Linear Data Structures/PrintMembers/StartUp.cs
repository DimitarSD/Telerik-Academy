namespace PrintMembers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        private const string MainMessage = "Enter number from which the sequence will start: ";
        private const int SequenceMaxLength = 50;
        private const string PrintMessage = "N = {0} -> {1}";

        public static void Main()
        {
            Console.Write(MainMessage);
            string input = Console.ReadLine();
            int firstElementOfTheSequence = int.Parse(input);

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
