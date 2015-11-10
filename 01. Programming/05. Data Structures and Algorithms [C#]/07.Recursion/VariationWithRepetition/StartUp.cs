namespace VariationWithRepetition
{
    using System;

    public class StartUp
    {
        private const int ElementsSetLength = 2;
        private static readonly string[] Elements = { "hi", "a", "b" };
        private static int[] variations;
        private static int elementsSubsetLength;

        public static void Main()
        {
            elementsSubsetLength = Elements.Length;
            variations = new int[elementsSubsetLength];

            Variations(0);
        }

        private static void Variations(int depth)
        {
            if (depth >= ElementsSetLength)
            {
                Print();
                return;
            }

            for (int i = 0; i < elementsSubsetLength; i++)
            {
                variations[depth] = i;
                Variations(depth + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < ElementsSetLength; i++)
            {
                Console.Write(Elements[variations[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
