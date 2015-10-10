using System;
using System.Linq;

class CombinationsGeneratorWithReps
{
    const int loopsK = 3;
    const int iterationsN = 5;
	static string[] objects = new string[iterationsN] 
	{
		"banana", "apple", "orange", "strawberry", "raspberry"
	};
	static int[] array = new int[loopsK];

	static void Main()
	{
		GenerateCombinationsNoRepetitions(0, 0);
	}

	static void GenerateCombinationsNoRepetitions(int index, int start)
	{
		if (index >= loopsK)
		{
			PrintCombinations();
		}
		else
		{
			for (int i = start; i < iterationsN; i++)
			{
				array[index] = i;
				GenerateCombinationsNoRepetitions(index + 1, i);
			}
		}
	}

    static void PrintCombinations()
    {
        Console.WriteLine("({0}) --> ({1})",
            string.Join(", ", array),
            string.Join(", ", array.Select(i => objects[i])));
    }
}
