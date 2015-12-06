﻿namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Item
    {
        public int Weight { get; set; }

        public int Price { get; set; }
    }

    public class Knapsack
    {
        private static void Main()
        {
            var items = new[]
                            {
                                new Item { Weight = 5, Price = 30 },
                                new Item { Weight = 8, Price = 120 },
                                new Item { Weight = 7, Price = 10 },
                                new Item { Weight = 0, Price = 20 },
                                new Item { Weight = 4, Price = 50 },
                                new Item { Weight = 5, Price = 80 },
                                new Item { Weight = 2, Price = 10 }
                            };
            var knapsackCapacity = 15;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine("  (weight: {0}, price: {1})", item.Weight, item.Price);
            }
            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            var maxPrice = new int[items.Length, capacity + 1];
            var isItemTaken = new bool[items.Length, capacity + 1];

            // Calculate maxPrice[0, 0...capacity]
            for (var c = 0; c <= capacity; c++)
            {
                if (items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    isItemTaken[0, c] = true;
                }
            }

            // Calculate maxPrice[1...len(items), 0...capacity]
            for (var i = 1; i < items.Length; i++)
            {
                for (var c = 0; c <= capacity; c++)
                {
                    // Don't take item i
                    maxPrice[i, c] = maxPrice[i - 1, c];

                    // Try to take item i (if it gives better price)
                    var remainingCapacity = c - items[i].Weight;
                    // here we ensure that we take the max prices
                    if (remainingCapacity >= 0
                        && maxPrice[i - 1, remainingCapacity] + items[i].Price > maxPrice[i - 1, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, remainingCapacity] + items[i].Price;
                        isItemTaken[i, c] = true;
                    }
                }
            }

            // Print the takenItems
            var itemsTaken = new List<Item>();
            var itemIndex = items.Length - 1;
            while (itemIndex >= 0)
            {
                if (isItemTaken[itemIndex, capacity])
                {
                    itemsTaken.Add(items[itemIndex]);
                    capacity -= items[itemIndex].Weight;
                }
                itemIndex--;
            }
            itemsTaken.Reverse();

            return itemsTaken.ToArray();
        }
    }
}