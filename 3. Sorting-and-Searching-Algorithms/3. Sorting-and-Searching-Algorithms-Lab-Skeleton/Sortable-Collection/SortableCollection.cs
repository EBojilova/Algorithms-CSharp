namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;
    using Sortable_Collection.Searchers;

    public class SortableCollection<T>
        where T : IComparable<T>
    {
        // creates an empty SortableCollection
        public SortableCollection()
        {
        }

        // receives an already created collection
        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        // receives a variable number of arguments (the elements separated by commas)
        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        // receives an already created collection, and delegates for Interpolation search
        public SortableCollection(IEnumerable<T> items, Func<T, T, int> subtract, Func<T, T, int> multiply)
            : this(items)
        {
            this.Multiply = multiply;
            this.Subtract = subtract;
        }

        public Func<T, T, int> Multiply { get; }

        public Func<T, T, int> Subtract { get; }

        // returns a list of the items
        public List<T> Items { get; set; } = new List<T>();

        // returns the number of elements
        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            var sercher = new BinarySearcher<T>();
            return sercher.Search(this.Items, item);
        }

        public int InterpolationSearch(T item)
        {
            var sercher = new InterpolationSearcher<T>(this.Subtract, this.Multiply);
            return sercher.Search(this.Items, item);
        }

        public void Shuffle()
        {
            var rnd = new Random();
            var array = this.Items.ToArray();
            var n = array.Length;
            // linear implementation
            for (var i = 0; i < n; i++)
            {
                // Exchange array[i] with random element in array[i … n-1]
                var r = i + rnd.Next(0, n - i);
                var temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }
            this.Items=new List<T>(array);
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }
    }
}