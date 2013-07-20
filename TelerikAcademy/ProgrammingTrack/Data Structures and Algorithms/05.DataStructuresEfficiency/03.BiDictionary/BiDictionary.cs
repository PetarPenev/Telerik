namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private MultiDictionary<TKey1, Entry> valuesByKeyOne;

        private MultiDictionary<TKey2, Entry> valuesByKeyTwo;

        private MultiDictionary<Tuple<TKey1, TKey2>, Entry> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByKeyOne = new MultiDictionary<TKey1, Entry>(true);
            this.valuesByKeyTwo = new MultiDictionary<TKey2, Entry>(true);
            this.valuesByBothKeys = new MultiDictionary<Tuple<TKey1, TKey2>, Entry>(true);
        }

        public void AddElement(TKey1 key1, TKey2 key2, TValue value)
        {
            Entry entry = new Entry(key1, key2, value);

            this.valuesByKeyOne[key1].Add(entry);
            this.valuesByKeyTwo[key2].Add(entry);
            this.valuesByBothKeys.Add(new Tuple<TKey1, TKey2>(key1, key2), entry);
        }

        public IEnumerable<TValue> FindByKey1(TKey1 key1)
        {
            return this.valuesByKeyOne[key1].Select(entry => entry.Value);
        }

        public IEnumerable<TValue> FindByKey2(TKey2 key2)
        {
            return this.valuesByKeyTwo[key2].Select(entry => entry.Value);
        }

        public IEnumerable<TValue> FindByBothKeys(TKey1 key1, TKey2 key2)
        {
            return this.valuesByBothKeys[new Tuple<TKey1, TKey2>(key1, key2)].Select(entry => entry.Value);
        }

        public void RemoveByKey1(TKey1 key1)
        {
            var entriesToRemove = this.valuesByKeyOne[key1];

            foreach (var entry in entriesToRemove)
            {
                this.valuesByKeyTwo.Remove(entry.Key2, entry);
                this.valuesByBothKeys.Remove(new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2), entry);
            }

            this.valuesByKeyOne.Remove(key1);
        }

        public void RemoveByKey2(TKey2 key2)
        {
            var entriesToRemove = this.valuesByKeyTwo[key2];

            foreach (var entry in entriesToRemove)
            {
                this.valuesByKeyOne.Remove(entry.Key1, entry);
                this.valuesByBothKeys.Remove(new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2), entry);
            }

            this.valuesByKeyTwo.Remove(key2);
        }

        public void RemoveByBothKeys(TKey1 key1, TKey2 key2)
        {
            var entriesToRemove = this.valuesByBothKeys[new Tuple<TKey1, TKey2>(key1, key2)];

            foreach (var entry in entriesToRemove)
            {
                this.valuesByKeyOne.Remove(entry.Key1, entry);
                this.valuesByKeyTwo.Remove(entry.Key2, entry);
            }

            this.valuesByBothKeys.Remove(new Tuple<TKey1, TKey2>(key1, key2));
        }

        private class Entry : IEquatable<Entry>
        {
            public Entry(TKey1 key1, TKey2 key2, TValue value)
            {
                this.Key1 = key1;
                this.Key2 = key2;
                this.Value = value;
            }

            public TKey1 Key1 { get; private set; }

            public TKey2 Key2 { get; private set; }

            public TValue Value { get; private set; }

            public bool Equals(Entry other)
            {
                return this.Key1.Equals(other.Key1) &&
                    this.Key2.Equals(other.Key2) && this.Value.Equals(other.Value);
            }
        }
    }
}
