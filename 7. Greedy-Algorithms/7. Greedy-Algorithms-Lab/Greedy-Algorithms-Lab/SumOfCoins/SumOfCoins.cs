namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            //var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            //var targetSum = 923;

            var availableCoins = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var targetSum = int.Parse(Console.ReadLine());

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins.OrderByDescending(coin => coin)
                .ToList();
            var chosenCoin= new Dictionary<int,int>();
            var currentSum = 0;
            var coinIndex = 0;
            while (currentSum != targetSum && coinIndex< sortedCoins.Count)
            {
                var currentCoinValue = sortedCoins[coinIndex];
                var remainingSum = targetSum - currentSum;
                var numberOfCoinToTake = remainingSum / currentCoinValue;
                if (numberOfCoinToTake>0)
                {
                    chosenCoin[currentCoinValue] = numberOfCoinToTake;
                    currentSum += currentCoinValue * numberOfCoinToTake;
                }
                coinIndex++;
            }
            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Target sum can not be reached");
            }
            return chosenCoin;
        }
    }
}