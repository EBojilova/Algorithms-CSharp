namespace _06.Generating_Combinations_0_1_Vectors
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var n = 8;
            const int StartNum = 0;
            const int EndNum = 1;

            var arr = new int[n];
            GenCombs(arr, 0, StartNum, EndNum);
        }

        private static void GenCombs(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                PrintCombination(arr);
            }
            else
            {
                for (var i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    // generirane ot liavo na diasno za razlika ot 05 Generatinig 0-1 Vectors
                    GenCombs(arr, index + 1, startNum, endNum);
                }
            }
        }

        private static void PrintCombination(int[] arr)
        {
            // A combination was found --> print it
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
    }
}