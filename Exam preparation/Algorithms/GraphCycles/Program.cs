namespace GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int n;

        private static List<int>[] graph;

        private static bool[,] hasEdge;

        private static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            hasEdge = new bool[n, n];

            ReadGraph();

            FindCycles();
        }

        private static void ReadGraph()
        {
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Where(s => s != "->")
                    .Select(int.Parse)
                    .ToArray();
                var sourseNode = input[0];
                graph[sourseNode] = new List<int>();
                for (var childIndex = 1; childIndex < input.Length; childIndex++)
                {
                    var childNode = input[childIndex];
                    graph[sourseNode].Add(childNode);
                    // directed graph
                    hasEdge[sourseNode, childNode] = true;
                }
                graph[sourseNode] = graph[sourseNode].Distinct()
                    .OrderBy(node => node)
                    .ToList();
            }
        }

        private static void FindCycles()
        {
            var cyclesFound = false;
            for (var node = 0; node < n; node++)
            {
                foreach (var childNode in graph[node])
                {
                    if (node < childNode)
                    {
                        foreach (var grandChildNode in graph[childNode])
                        {
                            if (node < grandChildNode && childNode != grandChildNode)
                            {
                                if (hasEdge[grandChildNode, node])
                                {
                                    Console.WriteLine("{{{0} -> {1} -> {2}}}", node, childNode, grandChildNode);
                                    cyclesFound = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!cyclesFound)
            {
                Console.WriteLine("No cycles found");
            }
        }
    }
}