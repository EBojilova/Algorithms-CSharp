namespace Permutations
{
    using System;

    // permutaciite sa chasten slucai na variaciite, kadeto n=k
    internal class PermutationsGenerator
    {
        private static void Main()
        {
            string[] array = { "apple", "banana", "orange" };
            GeneratePermutations(array, 0);
        }

        private static void GeneratePermutations<T>(T[] array, int loopsK)
        {
            if (loopsK >= array.Length)
            {
                Print(array);
            }
            else
            {
                GeneratePermutations(array, loopsK + 1);
                for (var i = loopsK + 1; i < array.Length; i++)
                {
                    Swap(ref array[loopsK], ref array[i]);
                    GeneratePermutations(array, loopsK + 1);
                    Swap(ref array[loopsK], ref array[i]);
                }
            }
        }

        private static void Print<T>(T[] array)
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}