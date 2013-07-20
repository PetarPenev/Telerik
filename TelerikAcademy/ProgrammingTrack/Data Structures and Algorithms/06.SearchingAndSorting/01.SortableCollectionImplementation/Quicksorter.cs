namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("The collection is not initialized.");
            }

            var quickSortedCollection = this.QuickSort(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = quickSortedCollection[i];
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            T pivotValue = collection[collection.Count / 2];
            IList<T> lesserValues = new List<T>();
            IList<T> greaterValues = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i != collection.Count / 2)
                {
                    if (collection[collection.Count / 2].CompareTo(collection[i]) < 0)
                    {
                        greaterValues.Add(collection[i]);
                    }
                    else 
                    {
                        lesserValues.Add(collection[i]);
                    }
                }
            }

            return this.Merge(this.QuickSort(lesserValues), pivotValue, this.QuickSort(greaterValues));
        }

        private IList<T> Merge(IList<T> lesserValues, T pivot, IList<T> greaterValues)
        {
            IList<T> newList = new List<T>(lesserValues.Count + greaterValues.Count + 1);
            foreach (var item in lesserValues)
            {
                newList.Add(item);
            }

            newList.Add(pivot);

            foreach (var item in greaterValues)
            {
                newList.Add(item);
            }

            return newList;
        }
    }
}