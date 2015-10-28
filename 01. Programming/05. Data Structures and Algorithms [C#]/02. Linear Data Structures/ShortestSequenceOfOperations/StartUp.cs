namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string MainMessage = "Enter start and end of your sequence. The end must be always bigger.";
        private const string StartNumberMessage = "Start: ";
        private const string EndNumberMessage = "End: ";

        public static void Main()
        {
            Console.WriteLine(MainMessage);
            
            int start = 0;
            int end = 0;
            
            do
            {
                Console.Write(StartNumberMessage);
                start = int.Parse(Console.ReadLine());
                Console.Write(EndNumberMessage);
                end = int.Parse(Console.ReadLine());
                Console.WriteLine(new string('-', 25));
            }
            while (end < start);

            List<int> operations = new List<int>();

            int newEndTarget = end;
            int multyPlierCounter = 0;

            operations.Add(start);

            while (newEndTarget / 2 >= start)
            {
                newEndTarget /= 2;
                multyPlierCounter++;
            }

            while (start < newEndTarget)
            {
                if (start + 2 < newEndTarget)
                {
                    start += 2;
                    operations.Add(start);
                }
                else if (start < newEndTarget)
                {
                    start++;
                    operations.Add(start);
                }
            }

            for (int i = 0; i < multyPlierCounter; i++)
            {
                start *= 2;
                operations.Add(start);
            }

            Console.WriteLine(string.Join(" -> ", operations));
        }
    }
}
