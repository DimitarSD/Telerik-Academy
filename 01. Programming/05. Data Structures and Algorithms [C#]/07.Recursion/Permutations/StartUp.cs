namespace Permutations
{
    using System;

    public class StartUp
    {
        private const int Number = 3;
        private static readonly int[] Permutations = new int[Number];
        private static readonly bool[] Used = new bool[Number];

        public static void Main()
        {
            Console.WriteLine("Permutations without repetition: ");
            PermutationsWithoutReps(0);

            Console.WriteLine("\nPermutations with repetition: ");
            PermutationsWithReps(0);
        }

        private static void PermutationsWithoutReps(int depth)
        {
            if (depth >= Number)
            {
                Print();
                return;
            }

            for (int i = 0; i < Number; i++)
            {
                if (Used[i])
                {
                    continue;
                }

                Used[i] = true;
                Permutations[depth] = i;
                PermutationsWithoutReps(depth + 1);
                Used[i] = false;
            }
        }

        private static void PermutationsWithReps(int depth)
        {
            if (depth >= Number)
            {
                Print();
                return;
            }

            for (int i = 0; i < Number; i++)
            {
                Permutations[depth] = i;
                PermutationsWithReps(depth + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < Number; i++)
            {
                Console.Write(Permutations[i] + 1 + " ");
            }

            Console.WriteLine();
        }
    }
}
