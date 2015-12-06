using System;
using System.Linq;

namespace ExamNonCrossingBridgesEB
{
    public class NonCrossingBridges
    {
        private static int[] seq;

        private static int[] bridgeCounts;

        private static int bestLenghtOfLIS;

        private static bool[] shouldBePrinted;

        public static void Main()
        {
            seq = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bridgeCounts = new int[seq.Length];
            shouldBePrinted = new bool[seq.Length];
            //previousIndexFinish = new int[seq.Length];
            CalcBridgesCount();

            if (bestLenghtOfLIS == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (bestLenghtOfLIS == 1)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                Console.WriteLine($"{bestLenghtOfLIS} bridges found");
            }
            PrintLongestIncreasingSubsequence();
        }

        private static void CalcBridgesCount()
        {
            bestLenghtOfLIS = 0;

            for (var index = 1; index < seq.Length; index++)
            {
                bridgeCounts[index] = bridgeCounts[index - 1];

                // we would like to print the leftmost
                for (var prevIndex = index - 1; prevIndex >= 0; prevIndex--)
                {
                    if (seq[index] == seq[prevIndex] && bridgeCounts[prevIndex] + 1 >= bridgeCounts[index])
                    {
                        bridgeCounts[index] = bridgeCounts[prevIndex] + 1;

                        if (bridgeCounts[index] > bestLenghtOfLIS)
                        {
                            bestLenghtOfLIS = bridgeCounts[index];
                            shouldBePrinted[index] = true;
                            shouldBePrinted[prevIndex] = true;
                        }
                        break;
                    }
                }
            }
        }

        private static void PrintLongestIncreasingSubsequence()
        {
            var result = new string[seq.Length];
            for (var i = 0; i < seq.Length; i++)
            {
                if (shouldBePrinted[i])
                {
                    result[i] = seq[i].ToString();
                }
                else
                {
                    result[i] = "X";
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}