namespace Kruskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class KruskalAlgorithm
    {
        // Kruskal's Mimimum Spanning Tree (MST) algorithm, implemented
        // with disjoint sets. Running time: O(M * log M)
        // Learn more at: https://en.wikipedia.org/wiki/Kruskal%27s_algorithm
        // http://visualgo.net/ufds.html

        private static void Main()
        {
            var numberOfVertices = 9;
            var graphEdges = new List<Edge>
                                 {
                                     new Edge(0, 3, 9),
                                     new Edge(0, 5, 4),
                                     new Edge(0, 8, 5),
                                     new Edge(1, 4, 8),
                                     new Edge(1, 7, 7),
                                     new Edge(2, 6, 12),
                                     new Edge(3, 5, 2),
                                     new Edge(3, 6, 8),
                                     new Edge(3, 8, 20),
                                     new Edge(4, 7, 10),
                                     new Edge(6, 8, 7)
                                 };

            var minimumSpanningForest = Kruskal(numberOfVertices, graphEdges);

            Console.WriteLine("Minimum spanning forest weight: " + minimumSpanningForest.Sum(edge => edge.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            // edges are sorted according their weight-Edge implements IComparable
            edges.Sort();

            // Initialize parents
            var parent = new int[numberOfVertices];
            for (var i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            // Kruskal's algorithm
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                var rootStartNode = FindRoot(edge.StartNode, parent);
                var rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    // Union (merge) the trees
                    parent[rootStartNode] = rootEndNode;
                }
            }

            return spanningTree;
        }

        private static int FindRoot(int node, int[] parent)
        {
            // Find the root parent for the node
            var root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            // Optimize (compress) the path from node to root
            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}