namespace PreActionsAndPostActions
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Program
    {
        private static readonly HashSet<string> allPath = new HashSet<string>();

        private static void Main(string[] args)
        {
            Traverse(@"C:\Users\Elena\Downloads\1. Recursion-Demos\PreActionsAndPostActions", 0);
        }

        // This is varainat of DFS(Depth-First-Search algorithm- see video in the course Database)
        private static void Traverse(string path, int indent)
        {
            if (allPath.Contains(path))
            {
                // We have already been here :)
                return;
            }
            allPath.Add(path);
            var files = Directory.GetFiles(path);
            Console.Write(new string('-', indent));
            Console.WriteLine(string.Join(Environment.NewLine, files));

            var subdirs = Directory.GetDirectories(path);
            foreach (var subdir in subdirs)
            {
                Traverse(subdir, indent + 1);
            }
            Console.WriteLine("Post action");
        }
    }
}