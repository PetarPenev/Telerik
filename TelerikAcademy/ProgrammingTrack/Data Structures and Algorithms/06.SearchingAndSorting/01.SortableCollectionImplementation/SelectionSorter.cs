namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("The collection is not initialized.");
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i; j < collection.Count; j++)
                {
                    if (collection[minIndex].CompareTo(collection[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T intermediateValue = collection[minIndex];
                    collection[minIndex] = collection[i];
                    collection[i] = intermediateValue;
                }
            }
        }
    }
}
