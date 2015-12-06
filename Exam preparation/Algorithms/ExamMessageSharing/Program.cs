using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph;

    private static bool[] visited;

    private static List<string> names;

    private static int countOfSteps;

    private static List<int> lastReached;

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
        visited = new bool[graph.Count()];
        var startNames = Console.ReadLine()
            .Replace("Start: ", "")
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        countOfSteps = 0;
        for (var node = 0; node < startNames.Count; node++)
        {
            var graphIndex = names.IndexOf(startNames[node]);
            if (!visited[graphIndex])
            {
                TraverseBFS(graphIndex);
            }
        }
    }

    //private static void RecursiveDFS(int node)
    //{
    //    countOfSteps++;
    //    // mnogo e vajna tazi proverka, inache moje da zaciklim
    //    if (!visited[node])
    //    {
    //        visited[node] = true;

    //        lastReached = graph[node];
    //        for (var i = 0; i < graph[node].Count; i++)
    //        {
    //            RecursiveDFS(graph[node][i]);
    //        }

    //    }
    //}

    private static void PrintResult()
    {
        var notReachedPeople = new List<string>();
        for (var i = 0; i < visited.Count(); i++)
        {
            if (!visited[i])
            {
                notReachedPeople.Add(names[i]);
            }
        }
        if (notReachedPeople.Count == 0)
        {
            Console.WriteLine("All people reached in {0} steps", countOfSteps);
            Console.WriteLine("People at last step: {0}", string.Join(", ", lastReached.Select(i => names[i])));
        }
        else
        {
            Console.WriteLine("Cannot reach: {0}", string.Join(", ", notReachedPeople));
        }
    }

    public static void TraverseBFS(int node)
    {
        // Queue e obhojdane v shirnia(BSF algoritam), dokato ako e Stack ste e obhojdane v dalbochina(DFS algoritam)
        var nodes = new Queue<int>();

        // Enqueue the start node to the queue
        visited[node] = true;
        nodes.Enqueue(node);
        countOfSteps++;
        
        // Breadth-First Search (BFS)
        while (nodes.Count != 0)
        {
            var currentNode = nodes.Dequeue();
            if (graph[currentNode].Count > 0)
            {
                lastReached = graph[currentNode];
            }

            foreach (var childNode in graph[currentNode])
            {
                if (!visited[childNode])
                {
                    nodes.Enqueue(childNode);
                    visited[childNode] = true;
                }
            }
        }
    }
}