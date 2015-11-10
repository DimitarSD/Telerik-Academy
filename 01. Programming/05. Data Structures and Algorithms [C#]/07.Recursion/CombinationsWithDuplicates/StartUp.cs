namespace CombinationsWithDuplicates
{
    using System;

    public class StartUp
    {
        private const int NumberOfElementSet = 3;
        private const int NumberOfElements = 2;
        private static readonly int[] CombinationsCollection = new int[NumberOfElementSet];

        public static void Main()
        {
            // true -> with duplicates
            Combinations(0, 0, true);
        }

        private static void Combinations(int startValue, int depth, bool withReps)
        {
            if (depth >= NumberOfElements)
            {
                Print();
                return;
            }

            for (int i = startValue; i < NumberOfElementSet; i++)
            {
                CombinationsCollection[depth] = i;
                Combinations(withReps ? i : i + 1, depth + 1, withReps);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                Console.Write(CombinationsCollection[i] + 1 + " ");
            }

            Console.WriteLine();
        }
    }
}
