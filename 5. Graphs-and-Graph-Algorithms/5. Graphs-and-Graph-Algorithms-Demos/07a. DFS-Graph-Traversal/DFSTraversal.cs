namespace _07a.DFS_Graph_Traversal
{
    using System;
    using System.Collections.Generic;

    internal class DfsTraversal
    {
        private static readonly string[] nodeNames =
            {
                "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora",
                "Plovdiv"
            };

        private static readonly List<int>[] childNodes =
            {
                new List<int> { 3, 6 }, // children of node 0 (Ruse)
                new List<int> { 2, 3, 4, 5, 6 }, // childern of node 1 (Sofia)
                new List<int> { 1, 4, 5 }, // childern of node 2 (Pleven)
                new List<int> { 0, 1, 5 }, // childern of node 3 (Varna)
                new List<int> { 1, 2, 6 }, // childern of node 4 (Bourgas)
                new List<int> { 1, 2, 3 }, // childern of node 5 (Stara Zagora)
                new List<int> { 0, 1, 4 } // childern of node 6 (Plovdiv)
            };

        public static void Main()
        {
            // Start DFS from node 4 (Bourgas)
            TraverseBFS(4);
        }

        public static void TraverseBFS(int node)
        {
            // Queue e obhojdane v shirnia(BSF algoritam), dokato ako e Stack ste e obhojdane v dalbochina(DFS algoritam)
            var nodes = new Stack<int>();
            var visited = new bool[childNodes.Length];

            // Enqueue the start node to the queue
            visited[node] = true;
            nodes.Push(node);

            // Breadth-First Search (BFS)
            while (nodes.Count != 0)
            {
                var currentNode = nodes.Pop();
                Console.WriteLine("{0} ({1})", currentNode, nodeNames[currentNode]);

                foreach (var childNode in childNodes[currentNode])
                {
                    if (!visited[childNode])
                    {
                        nodes.Push(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }
    }
}