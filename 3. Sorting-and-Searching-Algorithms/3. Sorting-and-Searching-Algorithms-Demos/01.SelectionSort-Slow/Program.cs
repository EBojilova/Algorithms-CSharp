namespace _01.SelectionSort_Slow
{
    internal class Program
    {
        public static int n = 5;

        public static int[] arr = { 2, 6, 9, 1, 0 };

        private static void Main(string[] args)
        {

            // unstable- changes the way of the input if there are more than 2 elements with the same value
            int minIndex;

            for (var left = 0; left < n - 1; left++)
            {
                // Find the min element in the unsorted range arr[left … n-1]
                minIndex = left;
                for (var i = left + 1; i < n; i++)
                {
                    if (arr[i] < arr[minIndex])
                    {
                        minIndex = i;
                    }
                }
                if (minIndex != left)
                {
                    Swap(arr[left], arr[minIndex]);
                }
            }
        }

        private static void Swap(int current, int minIndex)
        {
            var temp = arr[current];
            arr[current] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
}