using System;
using System.Collections.Generic;

namespace TSUsingSourceDFS
{
    public class DFSTS
    {
        public static void Main()
        {
            var graph = new List<int>[] {
                new List<int> {3, 5},  // children of node 0
                new List<int> {2},     // children of node 1
                new List<int> {},      // children of node 2, if here we put 3 as a child, there will be cycle and sorting can not be done
                new List<int> {5},     // children of node 3
                new List<int> {0, 1},  // children of node 4
                new List<int> {1, 2},  // children of node 5
            };

            // Calculate the predecessorsCount
            var predecessorsCount = new int[graph.Length];
            for (int node = 0; node < graph.Length; node++)
            {
                foreach (var childNode in graph[node])
                {
                    predecessorsCount[childNode]++;
                }
            }

            // Topological sorting: source removal algorithm
            var isRemoved = new bool[graph.Length];
            // we will keep here the sorted nodes
            var removedNodes = new List<int>();
            bool nodeRemoved = true;
            while (nodeRemoved)
            {
                nodeRemoved = false;
                for (int node = 0; node < graph.Length; node++)
                {
                    if (predecessorsCount[node] == 0 && !isRemoved[node])
                    {
                        // Found a node with 0 predecessors -> remove it from the graph
                        // If there are several nodes, which can be removed, it will take one of them, and this is thre reason there could be more than one solutions
                        foreach (var childNode in graph[node])
                        {
                            predecessorsCount[childNode]--;
                        }
                        isRemoved[node] = true;
                        removedNodes.Add(node);
                        nodeRemoved = true;
                        break;
                    }
                }
            }

            if (removedNodes.Count == graph.Length)
            {
                Console.WriteLine("Topological sorting: " +
                    string.Join(" ", removedNodes));
            }
            else
            {
                // kazva, che ima zacikliane, no ne moje da kaje kade tochno e
                Console.WriteLine("A cycle detected in the graph.");
            }
        }
    }
}
