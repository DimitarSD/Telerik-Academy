namespace AutoResizableStack
{
    using System;

    public class StartUp
    {
        private const string PrintMessageFormat = "Number of elements {0} | Current capacity {1}";
        private const string RemovingMessage = "\nRemoving the last 10 elements from the auto-resizable stack\n";

        public static void Main()
        {
            var numbers = new AutoResizableStack<int>();
            int currentCapacity = numbers.Capacity;

            for (int i = 0; i < 50; i++)
            {
                numbers.Push(i);

                if (currentCapacity != numbers.Capacity)
                {
                    string line = new string('-', 50);
                    Console.WriteLine(line);
                    currentCapacity = numbers.Capacity;
                }

                Console.WriteLine(PrintMessageFormat, numbers.Count.ToString().PadRight(2), numbers.Capacity);
            }

            Console.WriteLine(RemovingMessage);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(PrintMessageFormat, numbers.Peek(), numbers.Capacity);
                numbers.Pop();
            }
        }
    }
}
