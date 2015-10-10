namespace Permutations_with_Reps
{
    using System;

    internal class PermutationsGeneratorWithReps
    {
        private static void Main()
        {
            var array = new[] { 3, 5, 1, 5, 5 };
            Array.Sort(array);
            PermuteRep(array, 0, array.Length - 1);
        }

        private static void PermuteRep(int[] array, int start, int end)
        {
            Print(array);

            for (var left = end - 1; left >= start; left--)
            {
                for (var right = left + 1; right <= end; right++)
                {
                    if (array[left] != array[right])
                    {
                        Swap(ref array[left], ref array[right]);
                        PermuteRep(array, left + 1, end);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = array[left];
                for (var i = left; i <= end - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[end] = firstElement;
            }
        }

        private static void Print<T>(T[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}