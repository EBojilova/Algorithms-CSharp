using System;
using System.Collections.Generic;

namespace DijkstraWithoutQueue
{
    public class DijkstraWithoutQueue
    {
        // Dijkstra's shortest paths algorithm, implemented
        // with adjacency matrix. Running time: O(N * N)
        // Learn more at: https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm

       
        public static void Main()
        {
            // keeps the distance between noded row i s one of the noded, col is the other node
            // (note, can be exchanged row and col and have the same value, i.e. simetry matrix)
            // better inicialization of this matrix- see 3. Prim-Algorithm-Adjacency-Matrix
            // keeps 0, when the nodes are not connected, which is not quite correct- better -1 or null
            var graph = new[,]
            {
                // 0   1   2   3   4   5   6   7   8   9  10  11
                { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
                { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
                { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
                { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
                { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
                { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
                {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
                { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
                {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
                { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
                { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
                { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
            };

            FindAndPrintShortestPath(graph, 0, 9);
            FindAndPrintShortestPath(graph, 0, 2);
            FindAndPrintShortestPath(graph, 0, 10);
            FindAndPrintShortestPath(graph, 0, 11);
            FindAndPrintShortestPath(graph, 0, 1);
            FindAndPrintShortestPath(graph, 0, 0);
        }

        private static List<int> Dijkstra(int[,] graph, int sourceNode, int destinationNode)
        {
            // number of nodes
            var n = graph.GetLength(0);

            // Initialize the distance[]
            // will keep the distances from sourceNode to current node i
            var distance = new int[n];
            for (var i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[sourceNode] = 0;

            // Dijkstra's algorithm implemented without priority queue
            var usedNodes = new bool[n];
            // can keep null values, better is to use -1
            var previousNodes = new int?[n];
            // loop can be max n times
            while (true)
            {
                // Find the nearest unused node from the source
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (var node = 0; node < n; node++)
                {
                    if (!usedNodes[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }
                if (minDistance == int.MaxValue)
                {
                    // No min distance node found --> algorithm finished
                    break;
                }

                usedNodes[minNode] = true;

                // Improve the distance[0…n-1] through minNode
                for (var i = 0; i < n; i++)
                {
                    // if there is connection between min Node and current Node i
                    if (graph[minNode, i] > 0)
                    {
                        // sabirame otstoianiata na min Node do sourse Node i do current Node i
                        var newDistance = distance[minNode] + graph[minNode, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            previousNodes[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                // No path found from sourceNode to destinationNode
                return null;
            }

            // Reconstruct the shortest path from sourceNode to destinationNode
            var path = new List<int>();
            // can be null, if goes otside the array boudaries
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previousNodes[currentNode.Value];
            }
            path.Reverse();
            return path;
        }


        private static void FindAndPrintShortestPath(int[,] graph, int sourceNode, int destinationNode)
        {
            Console.Write("Shortest path [{0} -> {1}]: ", sourceNode, destinationNode);
            var path = Dijkstra(graph, sourceNode, destinationNode);
            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                var pathLength = 0;
                for (var i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }
                var formattedPath = string.Join("->", path);
                Console.WriteLine("{0} (length {1})", formattedPath, pathLength);
            }
        }
    }
}