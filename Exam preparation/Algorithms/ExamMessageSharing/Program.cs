using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph;

    private static int[] distances;

    private static List<string> names;

    private static List<string> startNames;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
        PrintResult();
    }

    private static List<int>[] ReadGraph()
    {
        names = Console.ReadLine()
            .Replace("People: ", "")
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        // names.Sort();
        var connections = Console.ReadLine()
            .Replace("Connections: ", "")
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var n = names.Count;
        graph = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }
        for (var i = 0; i < connections.Length; i++)
        {
            var edge = connections[i].Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var graphIndex1 = names.IndexOf(edge[0].Trim());
            var graphIndex2 = names.IndexOf(edge[1].Trim());
            graph[graphIndex1].Add(graphIndex2);
            graph[graphIndex2].Add(graphIndex1);
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        distances = new int[names.Count];
        for (var i = 0; i < names.Count; i++)
        {
            distances[i] = -1;
        }
        startNames = Console.ReadLine()
            .Replace("Start: ", "")
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        TraverseBFS();
    }

    public static void TraverseBFS()
    {
        // Queue e obhojdane v shirnia(BSF algoritam), dokato ako e Stack ste e obhojdane v dalbochina(DFS algoritam)
        var nodes = new Queue<int>();
        for (var i = 0; i < startNames.Count; i++)
        {
            var graphIndex = names.IndexOf(startNames[i]);
            // Enqueue the start node to the queue
            distances[graphIndex] = 0;
            nodes.Enqueue(graphIndex);
        }

        // Breadth-First Search (BFS)
        while (nodes.Count != 0)
        {
            var currentNode = nodes.Dequeue();

            foreach (var childNode in graph[currentNode])
            {
                if (distances[childNode] == -1)
                {
                    distances[childNode] = distances[currentNode] + 1;
                    nodes.Enqueue(childNode);
                }
            }
        }
    }

    private static void PrintResult()
    {
        var maxSteps = distances.Max();
        var lastReached = new List<string>();
        var notReachedPeople = new List<string>();
        for (var i = 0; i < distances.Count(); i++)
        {
            if (distances[i] == -1)
            {
                notReachedPeople.Add(names[i]);
            }
            else
            {
                if (distances[i] == maxSteps)
                {
                    lastReached.Add(names[i]);
                }
            }
        }
        if (notReachedPeople.Count == 0)
        {
            Console.WriteLine("All people reached in {0} steps", maxSteps);

            Console.WriteLine("People at last step: {0}", string.Join(", ", lastReached.OrderBy(n => n)));
        }
        else
        {
            Console.WriteLine("Cannot reach: {0}", string.Join(", ", notReachedPeople.OrderBy(n => n)));
        }
    }
}