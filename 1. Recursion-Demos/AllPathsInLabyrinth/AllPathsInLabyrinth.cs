
#define DEBUG_MODE

namespace AllPathsInLabyrinth
{
    using System;
    using System.Collections.Generic;

    internal class AllPathsInLabyrinth
    {
        private static readonly char[,] Lab =
            {
                { ' ', ' ', ' ', 'X', ' ', ' ', ' ' },
                { 'X', 'X', ' ', 'X', ' ', 'X', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', 'X', 'X', 'X', 'X', 'X', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', 'e' }
            };

        private static readonly List<char> Path = new List<char>();

        private static void Main()
        {
            FindPathToExit(0, 0, 'S');
        }

        private static void FindPathToExit(int row, int col, char direction)
        {
#if DEBUG_MODE
            PrintLabyrinth(row, col);
#endif

            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Append the current direction to the path
            Path.Add(direction);

            // Check if we have found the exit
            if (Lab[row, col] == 'e')
            {
                PrintPath(Path);
            }

            // will return for all characters-e(exit),X(walls),s(occupied)
            if (Lab[row, col] != ' ')
            {
                return;
            }

            // Temporary mark the current cell as visited
            Lab[row, col] = 's';

            // Recursively explore all possible directions
            FindPathToExit(row, col - 1, 'L'); // left
            FindPathToExit(row - 1, col, 'U'); // up
            FindPathToExit(row, col + 1, 'R'); // right
            FindPathToExit(row + 1, col, 'D'); // down

            // Mark back the current cell as free
            Lab[row, col] = ' ';

            // Remove the last direction from the path
            Path.RemoveAt(Path.Count - 1);
        }

        private static bool InRange(int row, int col)
        {
            var rowInRange = row >= 0 && row < Lab.GetLength(0);
            var colInRange = col >= 0 && col < Lab.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void PrintLabyrinth(int currentRow, int currentCol)
        {
            for (var row = -1; row <= Lab.GetLength(0); row++)
            {
                Console.WriteLine();
                for (var col = -1; col <= Lab.GetLength(1); col++)
                {
                    if ((row == currentRow) && (col == currentCol))
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("x");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (!InRange(row, col))
                    {
                        Console.Write(" ");
                    }
                    else if (Lab[row, col] == ' ')
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(Lab[row, col]);
                    }
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void PrintPath(List<char> path)
        {
            Console.Write("Found path to the exit: ");
            foreach (var dir in path)
            {
                Console.Write(dir);
            }
            Console.WriteLine();
        }
    }
}