using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph =
        {
            new List<int> { 3, 6 }, new List<int> { 3, 4, 5, 6 },
            new List<int> { 8 }, new List<int> { 0, 1, 5 }, new List<int> { 1, 6 },
            new List<int> { 1, 3 }, new List<int> { 0, 1, 4 }, new List<int> {},
            new List<int> { 2 }
        };

    private static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        var n = int.Parse(Console.ReadLine());
        graph = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            graph[i] =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Count()];
        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node])
            {
                Console.Write("Connected component:");
                RecursiveDFS(node);
                Console.WriteLine();
            }
        }
       
    }

    private static void RecursiveDFS(int node)
    {
        // mnogo e vajna tazi proverka, inache moje da zaciklim
        if (!visited[node])
        {
            visited[node] = true;

            for (var i = 0; i < graph[node].Count; i++)
            {
                RecursiveDFS(graph[node][i]);
            }
            Console.Write(" {0}", node);
        }
    }
}