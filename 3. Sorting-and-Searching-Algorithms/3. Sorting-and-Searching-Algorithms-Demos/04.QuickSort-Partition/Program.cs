namespace _04.QuickSort_Partition
{
    using System;
    using System.Collections.Generic;


    // Tova e nai-chesto izpolzvania sort, no ne za masivi pod 10 elementa, togava e po-dobre da se izpolzva insertion
    public class Test
    {
        private static readonly List<int> arr = RandomList(10);

        public static void Main()
        {
            PrintNumbers();
            MyQuickSort(0, arr.Count);
            PrintNumbers();
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

        private static int FindPivotIndex(int left, int right)
        {
            var start = left;
            // proizvolno izbirame pivot, no e po-dobre da izbrem srednoto mejdu nachalen, kraen i sreden po index element
            // nai-dobre e pivota da e mediana
            // minus ako pivota e v kraia
            var pivot = arr[start];

            left++;
            right--;

            while (true)
            {
                while (left <= right && arr[left] <= pivot)
                {
                    left++;
                }

                while (left <= right && arr[right] > pivot)
                {
                    right--;
                }

                if (left > right)
                {
                    arr[start] = arr[left - 1];
                    arr[left - 1] = pivot;

                    return left;
                }

                // razmeniame mestata na stoinostite ot liavo i ot diasno na pivota
                Swap(left, right);
            }
        }

        private static void MyQuickSort(int left, int right)
        {
            if (arr == null || arr.Count <= 1)
            {
                return;
            }

            if (left < right)
            {
                var pivotIdx = FindPivotIndex(left, right);
                //Console.WriteLine("MQS " + left + " " + right);
                //PrintNumbers(arr);
                MyQuickSort(left, pivotIdx - 1);
                MyQuickSort(pivotIdx, right);
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}