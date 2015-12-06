using System;
using System.Linq;

namespace BridgesNakov
{
    internal class Bridges
    {
        private const int NotCalculated = -1;

        private static int[,] maxBridges;

        private static int[] north;

        private static int[] south;

        private static void Main()
        {
            north = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            south = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            IntializeMaxBridges();

            CalcMaxBridges(north.Length - 1, south.Length - 1);

            Console.WriteLine(maxBridges[north.Length - 1, south.Length - 1]);
        }

        private static void IntializeMaxBridges()
        {
            maxBridges = new int[north.Length, south.Length];

            for (var x = 0; x < north.Length; x++)
            {
                for (var y = 0; y < south.Length; y++)
                {
                    maxBridges[x, y] = NotCalculated;
                }
            }
        }

        private static int CalcMaxBridges(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (maxBridges[x, y] != NotCalculated)
            {
                return maxBridges[x, y];
            }

            var northLeft = CalcMaxBridges(x - 1, y);
            var southLeft = CalcMaxBridges(x, y - 1);

            if (north[x] == south[y])
            {
                maxBridges[x, y] = 1 + Math.Max(northLeft, southLeft);
            }
            else
            {
                maxBridges[x, y] = Math.Max(northLeft, southLeft);
            }

            return maxBridges[x, y];
        }
    }
}