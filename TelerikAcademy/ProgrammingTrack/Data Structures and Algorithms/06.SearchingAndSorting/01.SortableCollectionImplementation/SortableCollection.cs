namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public static bool IsSorted(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i].CompareTo(collection[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int startIndex = 0;
            int endIndex = this.items.Count - 1;
            int currentGuess = (endIndex - startIndex) / 2;
            bool foundValue = false;
            while (!foundValue && (startIndex <= endIndex))
            {
                if (this.items[currentGuess].CompareTo(item) == 0)
                {
                    foundValue = true;
                }
                else
                {
                    if (this.items[currentGuess].CompareTo(item) < 0)
                    {
                        startIndex = currentGuess + 1;
                        currentGuess = startIndex + ((endIndex - startIndex) / 2);
                    }
                    else
                    {
                        endIndex = currentGuess - 1;
                        currentGuess = startIndex + ((endIndex - startIndex) / 2);
                    }
                }
            }

            return foundValue;
        }

        public void Shuffle()
        {
            Random randomGenerator = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int swappingPosition = i + randomGenerator.Next(0, this.items.Count - 1 - i);
                T intermediateValue = this.items[i];
                this.items[i] = this.items[swappingPosition];
                this.items[swappingPosition] = intermediateValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
