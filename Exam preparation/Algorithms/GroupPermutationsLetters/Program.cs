namespace GroupPermutationsLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        private static readonly Dictionary<char, int> LettersCount = new Dictionary<char, int>();

        private static StringBuilder result= new StringBuilder();

        private static void Main(string[] args)
        {
            var lettersInput = Console.ReadLine();
            //var lettersInput = "BCABACB";
            foreach (var letter in lettersInput)
            {
                if (!LettersCount.ContainsKey(letter))
                {
                    LettersCount[letter] = 0;
                }
                LettersCount[letter]++;
            }

            var letters = LettersCount.Keys.ToArray();
            GeneratePermutations(letters, 0);
            Console.Write(result);
        }

        private static void GeneratePermutations(char[] array, int loopsK)
        {
            if (loopsK >= array.Length)
            {
                Print(array);
            }
            else
            {
                // moje i bez tazi rekursia, no togava iteraciata ste pochva ot loopsK- vij resheniata na Nakov i Filip
                // no zakomentirania variant e po-barz
                //GeneratePermutations(array, loopsK + 1);
                //for (var i = loopsK + 1; i < array.Length; i++)
                for (var i = loopsK; i < array.Length; i++)
                {
                    Swap(ref array[loopsK], ref array[i]);
                    GeneratePermutations(array, loopsK + 1);
                    Swap(ref array[loopsK], ref array[i]);
                }
            }
        }

        private static void Print(char[] array)
        {
            foreach (var letter in array)
            {
                for (var i = 0; i < LettersCount[letter]; i++)
                {
                    result.Append(letter);
                }
            }
            result.AppendLine();
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}