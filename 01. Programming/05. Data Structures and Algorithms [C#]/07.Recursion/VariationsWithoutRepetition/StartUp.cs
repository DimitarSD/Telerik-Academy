namespace VariationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        private const int NumberOfStringsToCombine = 2;
        private static readonly string[] Elements = { "test", "rock", "fun" };
        private static int[] variations;
        private static int elementsLength;

        public static void Main()
        {
            elementsLength = Elements.Length;
            variations = new int[elementsLength];

            Variations(0, 0);
        }

        private static void Variations(int start, int depth)
        {
            if (depth >= NumberOfStringsToCombine)
            {
                Print();
                return;
            }

            for (int i = start; i < elementsLength; i++, start++)
            {
                variations[depth] = i;
                Variations(start + 1, depth + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < NumberOfStringsToCombine; i++)
            {
                Console.Write(Elements[variations[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
