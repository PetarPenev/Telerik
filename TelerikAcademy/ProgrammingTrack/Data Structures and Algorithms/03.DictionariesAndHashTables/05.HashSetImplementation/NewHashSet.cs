namespace _05.HashSetImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _04.HashTableImplementation;

    public class NewHashSet<T> : IEnumerable<T>
    {
        private NewHashTable<int, T> tableContainer = new NewHashTable<int, T>();

        public int Count
        {
            get
            {
                return this.tableContainer.Count;
            }
        }

        public IEnumerable<T> Elements
        {
            get
            {
                return this.tableContainer.Values;
            }
        }

        public void Add(T element)
        {
            this.tableContainer.Add(element.GetHashCode(), element);
        }

        public bool Find(T element)
        {
            try
            {
                var item = this.tableContainer.Find(element.GetHashCode());
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public void Remove(T element)
        {
            try
            {
                var item = this.tableContainer.Remove(element.GetHashCode());
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("The element does not exist in the hash set.");
            }
        }

        public void Clear()
        {
            this.tableContainer.Clear();
        }

        public NewHashSet<T> Union(NewHashSet<T> otherSet)
        {
            IEnumerable<T> union = this.Elements.Union(otherSet.Elements);

            NewHashSet<T> unionSet = new NewHashSet<T>();

            foreach (var element in union)
            {
                unionSet.Add(element);
            }

            return unionSet;
        }

        public NewHashSet<T> Intersect(NewHashSet<T> otherSet)
        {
            IEnumerable<T> intersect = this.Elements.Intersect(otherSet.Elements);

            NewHashSet<T> intersectSet = new NewHashSet<T>();

            foreach (var element in intersect)
            {
                intersectSet.Add(element);
            }

            return intersectSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
