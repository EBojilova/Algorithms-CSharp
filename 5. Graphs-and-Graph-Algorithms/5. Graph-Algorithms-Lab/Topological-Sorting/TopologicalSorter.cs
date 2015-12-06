using System;
using System.Collections.Generic;

public class TopologicalSorter
{
    private readonly Dictionary<string, List<string>> graph;

    private readonly Dictionary<string, int> predecessorsCount = new Dictionary<string, int>();

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    private void CalculatePredecessorsCount()
    {
        // Calculate the predecessorsCount

        foreach (var node in this.graph)
        {
            if (!this.predecessorsCount.ContainsKey(node.Key))
            {
                this.predecessorsCount[node.Key] = 0;
            }
            foreach (var childNode in node.Value)
            {
                if (!this.predecessorsCount.ContainsKey(childNode))
                {
                    this.predecessorsCount[childNode] = 0;
                }
                this.predecessorsCount[childNode]++;
            }
        }
    }

    //public ICollection<string> TopSort()
    //{
    //    this.CalculatePredecessorsCount();
    //    // Topological sorting: source removal algorithm
    //    var isRemoved = new Dictionary<string, bool>();
    //    // we will keep here the sorted nodes
    //    var removedNodes = new List<string>();
    //    var nodeRemoved = true;
    //    while (nodeRemoved)
    //    {
    //        nodeRemoved = false;
    //        foreach (var node in this.graph)
    //        {
    //            if (!isRemoved.ContainsKey(node.Key))
    //            {
    //                isRemoved[node.Key] = false;
    //            }
    //            if (this.predecessorsCount[node.Key] == 0 && !isRemoved[node.Key])
    //            {
    //                // Found a node with 0 predecessors -> remove it from the graph
    //                // If there are several nodes, which can be removed, it will take one of them, and this is thre reason there could be more than one solutions
    //                foreach (var childNode in this.graph[node.Key])
    //                {
    //                    this.predecessorsCount[childNode]--;
    //                }
    //                isRemoved[node.Key] = true;
    //                removedNodes.Add(node.Key);
    //                nodeRemoved = true;
    //                break;
    //            }
    //        }
    //    }

    //    if (removedNodes.Count != graph.Count)
    //    {
    //        // kazva, che ima zacikliane, no ne moje da kaje kade tochno e
    //        //Console.WriteLine("A cycle detected in the graph.");
    //        throw new InvalidOperationException("A cycle detected in the graph.");
    //    }
    //    return removedNodes;
    //}

    public ICollection<string> TopSort()
    {
        this.CalculatePredecessorsCount();
        // Topological sorting: source removal algorithm
        var isRemoved = new Dictionary<string, bool>();
        // we will keep here the sorted nodes
        var removedNodes = new List<string>();
        var nodeRemoved = true;
        while (nodeRemoved)
        {
            nodeRemoved = false;
            foreach (var node in this.graph)
            {
                if (!isRemoved.ContainsKey(node.Key))
                {
                    isRemoved[node.Key] = false;
                }
                if (this.predecessorsCount[node.Key] == 0 && !isRemoved[node.Key])
                {
                    // Found a node with 0 predecessors -> remove it from the graph
                    // If there are several nodes, which can be removed, it will take one of them, and this is thre reason there could be more than one solutions
                    foreach (var childNode in this.graph[node.Key])
                    {
                        this.predecessorsCount[childNode]--;
                    }
                    isRemoved[node.Key] = true;
                    removedNodes.Add(node.Key);
                    nodeRemoved = true;
                    break;
                }
            }
        }

        if (removedNodes.Count != graph.Count)
        {
            // kazva, che ima zacikliane, no ne moje da kaje kade tochno e
            //Console.WriteLine("A cycle detected in the graph.");
            throw new InvalidOperationException("A cycle detected in the graph.");
        }
        return removedNodes;
    }
}