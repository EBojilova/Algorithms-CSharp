namespace _03.InsertionSort
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static readonly List<int> arr = RandomList(10);

        // slow but stable, mostly used together with selection sort(unstable)
        private static void Main(string[] args)
        {
            PrintNumbers();
            InsertionSort();
            PrintNumbers();
        }

        private static void InsertionSort()
        {
            for (var i = 1; i < arr.Count; i++)
            {
                var j = i;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    Swap(j - 1, j);
                    j--;
                }
            }
        }

        private static void Swap(int current, int minIndex)
        {
            var temp = arr[current];
            arr[current] = arr[minIndex];
            arr[minIndex] = temp;
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        private static List<int> RandomList(int size)
        {
            var numbers = new List<int>(size);
            var rand = new Random(1);
            for (var i = 0; i < size; i++)
            {
                numbers.Add(rand.Next(size));
            }
            return numbers;
        }

        private void SortFromHomework(List<int> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int targetIndex = i;

                while (targetIndex > 0 && collection[i].CompareTo(collection[targetIndex - 1]) < 0)
                {
                    targetIndex--;
                }
                // izpolzva se remove i insert, koeto e bavna operacia. Da zameria,koe e po-bavno iterativno swap ili remove i insert
                if (targetIndex < i)
                {
                    int element = collection[i];
                    collection.RemoveAt(i);
                    collection.Insert(targetIndex, element);
                }
            }
        }
    }
}