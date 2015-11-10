namespace PermutationsWithDuplicates
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static readonly ISet<string> UniquePermutations = new SortedSet<string>();

        // Faster
        /*
        private static readonly HashSet<string> UniquePermutations = new HashSet<string>();
        */

        private static readonly int[] Elements = { 1, 3, 5, 5 };
        /*
        private static readonly int[] Elements = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        */
        public static void Main()
        {
            Permutations(Elements.Length);
            PrintUniquePermutations();
        }

        private static void Permutations(int depth)
        {
            if (depth == 0)
            {
                UniquePermutations.Add(string.Join(" ", Elements));
                return;
            }

            Permutations(depth - 1);

            for (int i = 0; i < depth - 1; i++)
            {
                if (Elements[i] != Elements[depth - 1])
                {
                    Swap(ref Elements[i], ref Elements[depth - 1]);
                    Permutations(depth - 1);
                    Swap(ref Elements[i], ref Elements[depth - 1]);
                }
            }
        }

        private static void Swap<T>(ref T firstValue, ref T secondValue)
        {
            T swap = firstValue;
            firstValue = secondValue;
            secondValue = swap;
        }

        private static void PrintUniquePermutations()
        {
            foreach (var permutation in UniquePermutations)
            {
                Console.WriteLine(permutation);
            }

            Console.WriteLine("\nTotal unique permutations: {0}\n", UniquePermutations.Count);
        }
    }
}
