using System;
using System.Collections.Generic;

// obhojdaneto e v dalbochina
public class RecursiveDFSExample
{
    private static readonly string[] nodeNames =
        {
            "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora",
            "Plovdiv"
        };

    private static readonly List<int>[] childNodes =
        {
            new List<int> { 3, 6 }, // children of node 0 (Ruse)
            new List<int> { 2, 3, 4, 5, 6 }, // successors of node 1 (Sofia)
            new List<int> { 1, 4, 5 }, // successors of node 2 (Pleven)
            new List<int> { 0, 1, 5 }, // successors of node 3 (Varna)
            new List<int> { 1, 2, 6 }, // successors of node 4 (Bourgas)
            new List<int> { 1, 2, 3 }, // successors of node 5 (Stara Zagora)
            new List<int> { 0, 1, 4 } // successors of node 6 (Plovdiv)
        };

    // moje i da e bulev masiv- vij slides
    private static HashSet<int> visited;

    public static void Main()
    {
        visited = new HashSet<int>();

        // Start DFS from node 4 (Bourgas)
        RecursiveDFS(4);
    }

    private static void RecursiveDFS(int node)
    {
        // mnogo e vajna tazi proverka, inache moje da zaciklim
        if (!visited.Contains(node))
        {
            visited.Add(node);
            Console.WriteLine("{0} ({1})", node, nodeNames[node]);

            for (var i = 0; i < childNodes[node].Count; i++)
            {
                RecursiveDFS(childNodes[node][i]);
            }
        }
    }
}