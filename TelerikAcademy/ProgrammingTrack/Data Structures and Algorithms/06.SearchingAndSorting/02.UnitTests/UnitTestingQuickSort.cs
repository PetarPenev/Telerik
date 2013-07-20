namespace _02.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class UnitTestingQuickSort
    {
        [TestMethod]
        public void TestWithAnEmptyCollection()
        {
            List<int> collection = new List<int>();
            Quicksorter<int> sorter = new Quicksorter<int>();
            sorter.Sort(collection);
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithANullCollection()
        {
            List<int> collection = null;
            Quicksorter<int> sorter = new Quicksorter<int>();
            sorter.Sort(collection);
        }

        [TestMethod]
        public void TestWithASingleItem()
        {
            List<int> collection = new List<int>();
            collection.Add(3);

            Quicksorter<int> sorter = new Quicksorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(3, collection[0]);
        }

        [TestMethod]
        public void TestWithTwoItems()
        {
            List<int> collection = new List<int>();
            collection.Add(3);
            collection.Add(0);

            Quicksorter<int> sorter = new Quicksorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual(0, collection[0]);
            Assert.AreEqual(3, collection[1]);
        }

        [TestMethod]
        public void TestWithOddNumberOfItems()
        {
            List<int> collection = new List<int>();
            collection.Add(3);
            collection.Add(0);
            collection.Add(11);
            collection.Add(-3);
            collection.Add(5);
            collection.Add(0);
            collection.Add(4);

            Quicksorter<int> sorter = new Quicksorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(7, collection.Count);
            Assert.IsTrue(SortableCollection<int>.IsSorted(collection));
        }

        [TestMethod]
        public void TestWithEvenNumberOfItems()
        {
            List<int> collection = new List<int>();
            collection.Add(32);
            collection.Add(11);
            collection.Add(-11);
            collection.Add(9);
            collection.Add(0);
            collection.Add(-1111);
            collection.Add(0);
            collection.Add(7);

            Quicksorter<int> sorter = new Quicksorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(8, collection.Count);
            Assert.IsTrue(SortableCollection<int>.IsSorted(collection));
        }
    }
}
