using System;
using System.Collections.Generic;
using System.Linq;

namespace Prim
{
    internal class PrimAlgorithmAdjacencyMatrix
    {
        // Prim's mimimum spanning tree (MTS) algorithm, implemented
        // with adjacency matrix(matrica na blizosta). Running time: O(N * N)
        // Learn more at: https://en.wikipedia.org/wiki/Prim%27s_algorithm

        private static void Main()
        {
            // number of nodes
            var n = 9;
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

            var minimumSpanningForest = Prim(n, graphEdges);

            Console.WriteLine("Minimum spanning forest weight: " + minimumSpanningForest.Sum(e => e.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> Prim(int n, List<Edge> graphEdges)
        {
            // Build the graph adjacency matrix
            // int?[n, n] moje da pazi null kato stoinosti, ako niama edge mejdu dvata noda, no po-optimalno ot kam parformance
            // e da pazim -1(ili drugo magichesko chislo primerno Int.MinValue)
            var graphMatrix = new int?[n, n];
            foreach (var edge in graphEdges)
            {
                graphMatrix[edge.StartNode, edge.EndNode] = edge.Weight;
                graphMatrix[edge.EndNode, edge.StartNode] = edge.Weight;
            }

            // Start Prim's algorithm from each node not still in the spanning tree
            var usedNodes = new bool[n];
            var spannngTreeEdges = new List<Edge>();
            // po tozi nachin si garantirame da obhvanem vsichki chasti na nesvarzania graph, ako e takav
            for (var startNode = 0; startNode < n; startNode++)
            {
                if (!usedNodes[startNode])
                {
                    Prim(n, graphMatrix, startNode, usedNodes, spannngTreeEdges);
                }
            }

            return spannngTreeEdges;
        }

        private static void Prim(int n, int?[,] graphMatrix, int startNode, bool[] usedNodes, List<Edge> spannngTreeEdges)
        {
            usedNodes[startNode] = true;
            var startNodeIndexes = new int[n];
            var minimalDistancesBetweeenNodes = new int[n];

            // Compute the distances of the nodes from the start node
            for (var i = 0; i < n; i++)
            {
                minimalDistancesBetweeenNodes[i] = int.MaxValue;
                if (graphMatrix[startNode, i] != null)
                {
                    // will keep the distance from start node to current node i
                    minimalDistancesBetweeenNodes[i] = graphMatrix[startNode, i].Value;
                    // will keep the start node index
                    startNodeIndexes[i] = startNode;
                }
            }

            // Prim's algorithm body
            while (true)
            {
                // Find the next minimal edge to be added to the spanning tree
                var minDist = int.MaxValue;
                var nearestNode = 0;
                // this loop used instead of sorting
                for (var i = 0; i < n; i++)
                {
                    if (!usedNodes[i] && minimalDistancesBetweeenNodes[i] < minDist)
                    {
                        minDist = minimalDistancesBetweeenNodes[i];
                        nearestNode = i;
                    }
                }
                if (minDist == int.MaxValue)
                {
                    // No next minimal edge to add t the spanning tree --> stop
                    return;
                }

                usedNodes[nearestNode] = true;
                spannngTreeEdges.Add(new Edge(startNodeIndexes[nearestNode], nearestNode, minDist));

                // Update the nearest[0...n-1] distances through nearestNode
                for (var i = 0; i < n; i++)
                {
                    // ako noda ne e vkluchen, ako ima pat do nego i ako otsotianieto mu do naj- blizkia e po-malko ot ot otstoianieto mu ot start node
                    if (!usedNodes[i] && graphMatrix[nearestNode, i] != null
                        && graphMatrix[nearestNode, i] < minimalDistancesBetweeenNodes[i])
                    {
                        minimalDistancesBetweeenNodes[i] = graphMatrix[nearestNode, i].Value;
                        startNodeIndexes[i] = nearestNode;
                    }
                }
            }
        }
    }
}