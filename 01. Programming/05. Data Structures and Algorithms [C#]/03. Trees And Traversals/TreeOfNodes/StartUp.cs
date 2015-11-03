namespace TreeOfNodes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Constants;

    public class StartUp
    {
        private const string Path = "../../Inputs/input_4.txt";
        private static readonly Tree<int> Тree = new Tree<int>();

        public static void Main()
        {
            var file = new StreamReader(Path);
            Console.SetIn(file);

            ProcessInput();

            Console.WriteLine(StartupMessage.ParentNodePrintMessage);
            {
                PrintParentNode();
            }

            Console.WriteLine();
            {
                PrintNodes(Тree.Nodes);
            }

            Console.WriteLine(StartupMessage.MiddleNodesPrintMessage);
            {
                PrintNodes(Тree.MiddleNodes);
            }

            Console.WriteLine();
            {
                PrintNodes(Тree.LeafNodes);
            }

            Console.WriteLine(StartupMessage.LeafNodesPrintMessage);
            {
                var treeTraversal = new TreeTraversalStrategy();

                Console.WriteLine(StartupMessage.StartingFromRootNodePrintMessage);
                {
                    var longestPaths = treeTraversal.GetLongestPathInTree(Тree.ParentNode);
                    PrintPaths(longestPaths, null);
                }

                Console.WriteLine(StartupMessage.StartingFromMiddleNodesPrintFirstMessage);
                {
                    var longestPaths = treeTraversal.GetLongestPathInTree(Тree.Nodes.First(n => n.Value == 2));
                    PrintPaths(longestPaths, null);

                    longestPaths = treeTraversal.GetLongestPathInTree(Тree.Nodes.First(n => n.Value == 5));
                    PrintPaths(longestPaths, null);
                }
            }

            Console.WriteLine(StartupMessage.AllPathWithGivenSumPrintMessage);
            {
                var treeTraversal = new TreeTraversalStrategy();

                Console.WriteLine(StartupMessage.StartingFromRootNodePrintMessage);
                {
                    int sumFromRoot = 9;
                    var allPathsWithGivenSum = treeTraversal.GetAllPathsInTreeWithGivenSum(Тree.ParentNode, sumFromRoot);
                    PrintPaths(allPathsWithGivenSum, sumFromRoot);
                }

                Console.WriteLine(StartupMessage.StartingFromMiddleNodesPrintSecondMessage);
                {
                    int sumFromMiddleNode = 6;
                    var allPathsWithGivenSum = treeTraversal.GetAllPathsInTreeWithGivenSum(Тree.Nodes.First(n => n.Value == 2), sumFromMiddleNode);
                    PrintPaths(allPathsWithGivenSum, sumFromMiddleNode);

                    allPathsWithGivenSum = treeTraversal.GetAllPathsInTreeWithGivenSum(Тree.Nodes.First(n => n.Value == 5), sumFromMiddleNode);
                    PrintPaths(allPathsWithGivenSum, sumFromMiddleNode);
                }
            }

            Console.WriteLine(StartupMessage.AllSubtreesWithGivenSumPrintMessgae);
            {
                var treeTraversal = new TreeTraversalStrategy();

                var sum = 16;
                var allSubtreesPaths = treeTraversal.GetAllSubtreesWithGivenSum(Тree, sum);
                PrintPaths(allSubtreesPaths, sum);
            }
        }

        private static void PrintNodes<T>(IReadOnlyCollection<Node<T>> nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }

            Console.WriteLine();
        }

        private static void PrintParentNode()
        {
            Console.WriteLine(StartupMessage.ParentNode, Тree.ParentNode);
        }

        private static void PrintPaths(List<List<int>> paths, int? sum, string separator = StartupMessage.PathSeparator)
        {
            foreach (var path in paths.OrderBy(p => p.Count))
            {
                Console.WriteLine(
                    "{0} {1}",
                    string.Join(separator, path), 
                    sum.HasValue ? "(Sum: " + sum.Value + ")" : string.Empty);
            }
        }

        private static void ProcessInput()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                ParseInput(input);
                input = Console.ReadLine();
            }
        }

        private static void ParseInput(string inputLine)
        {
            var inputValues = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(v => int.Parse(v))
                                       .ToArray();

            var parentNodeValue = inputValues[0];
            var childNodeValue = inputValues[1];

            Тree.ConnectNodes(parentNodeValue, childNodeValue);
        }
    }
}
