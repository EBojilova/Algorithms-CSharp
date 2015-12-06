namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
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
                    // http://visualgo.net/ufds.html
                    parent[rootStartNode] = rootEndNode;
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            // Find the root parent for the node
            var root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            // Optimize (compress) the path from node to root
            // pravim struktura koren- listo(bez kloni), zakachame node kam korena
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
