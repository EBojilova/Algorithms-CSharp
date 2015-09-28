using System;

internal class CombinationsGenerator
{
    private static void Main()
    {
        var n = 3;
        // var n=8; var startNum=0; var endNum=1;
        var startNum = 4;
        var endNum = 8;

        var arr = new int[n];
        GenCombs(arr, 0, startNum, endNum);
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
                // With i+1 osiguriavame da e combinacia s povtorenia
                // Tazi zadacha e variant na 05. Generatiing 0-1 Vectors, no s modifikacia- vij komentarite
                GenCombs(arr, index + 1, i + 1, endNum);
                //GenCombs(arr, index + 1, i + 1, endNum);
            }
        }
    }

    private static void PrintCombination(int[] arr)
    {
        // A combination was found --> print it
        Console.WriteLine("(" + string.Join(", ", arr) + ")");
    }
}