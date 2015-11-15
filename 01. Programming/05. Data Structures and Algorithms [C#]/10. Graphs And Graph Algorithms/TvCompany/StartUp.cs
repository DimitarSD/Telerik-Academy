namespace TvCompany
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Using Kruskal to find Minimal Spanning Tree
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/Kruskal%27s_algorithm"/>
    /// <seealso cref="https://en.wikipedia.org/wiki/Minimum_spanning_tree"/>
    public class StartUp
    {
        private static Tuple<int, int, int>[] paths;
        private static ISet<int> houses;

        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
            #endif

            ParseInput();

            var joinByLine = Environment.NewLine;
            var pathCollection = paths.Select(a => string.Format("[{0} {1} -> {2}]", a.Item1, a.Item2, a.Item3));
            Console.WriteLine(string.Join(Environment.NewLine, pathCollection));

            var allTrees = RepresendEachNodeAsTree();

            double result = FindMinimalCost(allTrees);

            Console.WriteLine("\nMinimal cost for cable: " + result);
        }

        private static HashSet<ISet<int>> RepresendEachNodeAsTree()
        {
            var allTrees = new HashSet<ISet<int>>();

            // Represend each node as tree
            foreach (var node in houses)
            {
                var tree = new HashSet<int>();
                tree.Add(node);

                allTrees.Add(tree);
            }

            return allTrees;
        }

        private static double FindMinimalCost(HashSet<ISet<int>> allTrees)
        {
            // Kruskal -> Sorting edges by their weight
            Array.Sort(paths, (a, b) => a.Item3.CompareTo(b.Item3));

            double result = 0;

            foreach (var path in paths)
            {
                var treeOne = allTrees.Where(tree => tree.Contains(path.Item1)).First();
                var treeTwo = allTrees.Where(tree => tree.Contains(path.Item2)).First();

                // Elements are in same tree
                if (treeOne.Equals(treeTwo))
                {
                    continue;
                }

                result += path.Item3;

                treeOne.UnionWith(treeTwo);
                allTrees.Remove(treeTwo);

                // Small optimization
                if (allTrees.Count == 1)
                {
                    break;
                }
            }

            return result;
        }

        private static void ParseInput()
        {
            int numberOfHouses = int.Parse(Console.ReadLine());
            paths = new Tuple<int, int, int>[numberOfHouses];
            houses = new HashSet<int>();

            for (int i = 0; i < numberOfHouses; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                paths[i] = new Tuple<int, int, int>(input[0], input[1], input[2]);
                houses.Add(input[0]);
                houses.Add(input[1]);
            }
        }
    }
}
