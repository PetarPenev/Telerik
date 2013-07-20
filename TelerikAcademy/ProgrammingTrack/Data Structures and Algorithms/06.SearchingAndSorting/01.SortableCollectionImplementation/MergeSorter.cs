namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("The collection is not initialized.");
            }

            var mergeSortedCollection = this.MergeSort(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = mergeSortedCollection[i];
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            List<T> leftList = new List<T>();
            List<T> rightList = new List<T>();

            for (int i = 0; i < collection.Count / 2; i++)
            {
                leftList.Add(collection[i]);
            }

            for (int i = collection.Count / 2; i < collection.Count; i++)
            {
                rightList.Add(collection[i]);
            }

            return this.Merge(this.MergeSort(leftList), this.MergeSort(rightList));
        }

        private IList<T> Merge(IList<T> leftList, IList<T> rightList)
        {
            IList<T> newList = new List<T>(leftList.Count + rightList.Count);
            int leftIndex = 0;
            int rightIndex = 0;

            while ((leftIndex < leftList.Count) && (rightIndex < rightList.Count))
            {
                if (leftList[leftIndex].CompareTo(rightList[rightIndex]) <= 0)
                {
                    newList.Add(leftList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    newList.Add(rightList[rightIndex]);
                    rightIndex++;
                }
            }

            if (leftIndex < leftList.Count)
            {
                for (int i = leftIndex; i < leftList.Count; i++)
                {
                    newList.Add(leftList[i]);
                }
            }
            else if (rightIndex < rightList.Count)
            {
                for (int i = rightIndex; i < rightList.Count; i++)
                {
                    newList.Add(rightList[i]);   
                }
            }

            return newList;
        }
    }
}