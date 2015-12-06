namespace Sortable_Collection.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTests
    {
        private static readonly Random Random = new Random();

        [TestMethod]
        public void TestWithEmptyCollectionShouldReturnMissingElement()
        {
            var collection = new SortableCollection<int>();

            var result = collection.BinarySearch(0);
            var expected = Array.BinarySearch(collection.ToArray(), 0);

            Assert.AreEqual(
                expected,
                result,
                "No elements are present in an empty collection; method should return -1.");
        }

        [TestMethod]
        public void TestWithMissingElement()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var result = collection.BinarySearch(0);
            var expected = -1;

            Assert.AreEqual(expected, result, "Missing element should return -1.");
        }

        //[TestMethod]
        //public void TestWithItemAtMidpoint()
        //{
        //    var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

        //    var result = collection.BinarySearch(3);
        //    var expected = Array.BinarySearch(collection.ToArray(), 3);

        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void TestWithItemToTheLeftOfMidpoint()
        //{
        //    var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

        //    var result = collection.BinarySearch(2);
        //    var expected = Array.BinarySearch(collection.ToArray(), 2);

        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void TestWithItemToTheRightOfMidpoint()
        //{
        //    var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

        //    var result = collection.BinarySearch(4);
        //    var expected = Array.BinarySearch(collection.ToArray(), 4);

        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void TestWithMultipleMissingKeysSmallerThanMinimum()
        //{
        //    const int NumberOfChecks = 10000;
        //    const int NumberOfElements = 1000;

        //    var elements = new int[NumberOfElements];

        //    for (var i = 0; i < NumberOfElements; i++)
        //    {
        //        // TODO: debuging
        //        elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
        //    }

        //    Array.Sort(elements);

        //    var collection = new SortableCollection<int>(elements);

        //    for (var i = 0; i < NumberOfChecks; i++)
        //    {
                
        //        var item = Random.Next(int.MinValue, collection.Items[0]);

        //        var result = collection.BinarySearch(item);

        //        Assert.AreEqual(-1, result);
        //    }
        //}

        [TestMethod]
        public void TestWithMultipleMissingKeysLargerThanMaximum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (var i = 0; i < NumberOfElements; i++)
            {
                // TODO: debuging
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);

            for (var i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(collection.Items[collection.Count - 1], int.MaxValue);

                var result = collection.BinarySearch(item);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleKeys()
        {
            const int NumberOfElements = 10000;

            var elements = new int[NumberOfElements];

            for (var i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(-100, 100);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);

            foreach (var element in elements)
            {
                var expected = Array.BinarySearch(elements, element);
                var result = collection.BinarySearch(element);

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestWithRepeatingItemShouldReturnFirstDiscoveredIndex()
        {
            var collection = new SortableCollection<int>(0, 3, 3, 3, 3, 7, 7, 7, 7, 7, 7);
            var result = collection.BinarySearch(3);

            //TODO: it is 2 because of the natyre of binary search- returns the middle index of the part searched
            Assert.AreEqual(2, result);
        }
    }
}