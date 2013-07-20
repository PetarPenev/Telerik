namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;

    public class NewHashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] array = new LinkedList<KeyValuePair<K, T>>[16];
        private int count = 0;
        private int currentCapacityFilled = 0;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.currentCapacityFilled;
            }
        }

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();

                for (int i = 0; i < this.array.Length; i++)
                {
                    if (this.array[i] != null)
                    {
                        var nextElement = this.array[i].First;
                        while (nextElement != null)
                        {
                            keys.Add(nextElement.Value.Key);
                            nextElement = nextElement.Next;
                        }
                    }
                }

                return keys;
            }
        }

        public List<T> Values
        {
            get
            {
                List<KeyValuePair<K, T>> pairs = this.GetValues();

                List<T> values = new List<T>();

                foreach (var pair in pairs)
                {
                    values.Add(pair.Value);
                }

                return values;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                int hashCode = Math.Abs(key.GetHashCode()) % this.array.Length;

                if (this.array[hashCode] == null)
                {
                    this.array[hashCode] = new LinkedList<KeyValuePair<K, T>>();
                }

                var nextElement = this.array[hashCode].First;
                bool elementInserted = false;
                while (nextElement != null)
                {
                    if (nextElement.Value.Key.Equals(key))
                    {
                        var newElement = new KeyValuePair<K, T>(key, value);
                        this.array[hashCode].AddAfter(nextElement, newElement);
                        this.array[hashCode].Remove(nextElement);
                        elementInserted = true;
                        break;
                    }

                    nextElement = nextElement.Next;
                }

                if (!elementInserted)
                {
                    this.array[hashCode].AddLast(new KeyValuePair<K, T>(key, value));
                }
            }
        }

        public void Add(K key, T value)
        {
            if (this.currentCapacityFilled > (int)(this.array.Length * 0.75))
            {
                this.DoubleCapacity();
            }

            int hashCode = Math.Abs(key.GetHashCode()) % this.array.Length;

            if (this.array[hashCode] == null)
            {
                this.array[hashCode] = new LinkedList<KeyValuePair<K, T>>();
                this.currentCapacityFilled++;
            }

            var nextElement = this.array[hashCode].First;

            while (nextElement != null)
            {
                if (nextElement.Value.Key.Equals(key))
                {
                    throw new ArgumentException("The key already exists in the table");
                }

                nextElement = nextElement.Next;
            }

            this.array[hashCode].AddLast(new KeyValuePair<K, T>(key, value));
            this.count++;
        }

        public T Find(K key)
        {
            int hashCode = Math.Abs(key.GetHashCode()) % this.array.Length;

            if (this.array[hashCode] == null)
            {
                throw new ArgumentOutOfRangeException("There is no such key in the table.");
            }

            var nextElement = this.array[hashCode].First;
            while (nextElement != null)
            {
                if (nextElement.Value.Key.Equals(key))
                {
                    return nextElement.Value.Value;
                }

                nextElement = nextElement.Next;
            }

            throw new ArgumentOutOfRangeException("There is no such key in the table.");
        }

        public T Remove(K key)
        {
            int hashCode = Math.Abs(key.GetHashCode()) % this.array.Length;

            if (this.array[hashCode] == null)
            {
                throw new ArgumentOutOfRangeException("There is no such key in the table.");
            }

            var nextElement = this.array[hashCode].First;

            while (nextElement != null)
            {
                if (nextElement.Value.Key.Equals(key))
                {
                    this.array[hashCode].Remove(nextElement);
                    this.count++;
                    if (this.array[hashCode].First == null)
                    {
                        this.currentCapacityFilled--;
                    }

                    return nextElement.Value.Value;
                }

                nextElement = nextElement.Next;
            }

            throw new ArgumentOutOfRangeException("There is no such key in the table.");
        }

        public void Clear()
        {
            this.count = 0;
            this.currentCapacityFilled = 0;
            this.array = new LinkedList<KeyValuePair<K, T>>[16];
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<K, T>>)this.GetValuesEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleCapacity()
        {
            LinkedList<KeyValuePair<K, T>>[] newArray = new LinkedList<KeyValuePair<K, T>>[this.array.Length * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] != null)
                {
                    var nextElement = this.array[i].First;
                    while (nextElement != null)
                    {
                        int newIndex = Math.Abs(nextElement.Value.Key.GetHashCode()) % newArray.Length;
                        this.AddElement(nextElement.Value, newIndex, newArray);
                        nextElement = nextElement.Next;
                    }
                }
            }

            // Both the currentCapacityFilled and the count remain the same numbers;
            this.array = newArray;
        }

        private void AddElement(KeyValuePair<K, T> pair, int index, LinkedList<KeyValuePair<K, T>>[] array)
        {
            if (array[index] == null)
            {
                array[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            // We do not need to check for duplicates because the array is already checked during the adding process
            // before doubling of the capacity and all its keys are unique.
            array[index].AddLast(pair);
        }

        private IEnumerator<KeyValuePair<K, T>> GetValuesEnumerator()
        {          
            return this.GetValues().GetEnumerator();
        }

        private List<KeyValuePair<K, T>> GetValues()
        {
            List<KeyValuePair<K, T>> values = new List<KeyValuePair<K, T>>();

            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] != null)
                {
                    foreach (var node in this.array[i])
                    {
                        values.Add(node);
                    }
                }
            }

            return values;
        }
    }
}
