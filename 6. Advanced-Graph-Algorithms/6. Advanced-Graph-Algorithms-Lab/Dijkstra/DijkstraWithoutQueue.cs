namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
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

                // Using the node we just found, we need to go through all nodes connected to it and improve the shortest distances. 
                // A node is connected to another node if there is an edge between them; in the context of our matrix, 
                // this means a cell with value greater than 0.
                for (var i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        // Calculate the distance from the source node to the current node – just add the shortest distance to 
                        // minNode and the distance between minNode and the node
                        var newDistance = distance[minNode] + graph[minNode, i];
                        //	If the calculated distance is shorter than the current shortest distance for the current node – 
                        // update the shortest distance and make minNode the previous element
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
            //  var previousNodes = new int?[n];
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previousNodes[currentNode.Value];
            }
            path.Reverse();
            return path;
        }
    }
}