namespace _02.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class UnitTestingSelectionSort
    {
        [TestMethod]
        public void TestWithAnEmptyCollection()
        {
            List<int> collection = new List<int>();
            SelectionSorter<int> sorter = new SelectionSorter<int>();
            sorter.Sort(collection);
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithNullCollection()
        {
            List<int> collection = null;
            SelectionSorter<int> sorter = new SelectionSorter<int>();
            sorter.Sort(collection);
        }

        [TestMethod]
        public void TestWithOneItemCollection()
        {
            List<int> collection = new List<int>();
            collection.Add(3);

            SelectionSorter<int> sorter = new SelectionSorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(3, collection[0]);
        }

        [TestMethod]
        public void TestWithMultipleItems()
        {
            List<int> collection = new List<int>();
            collection.Add(3);
            collection.Add(-111);
            collection.Add(0);
            collection.Add(24);
            collection.Add(-14);
            collection.Add(-1);
            collection.Add(32);
            collection.Add(-1);
            collection.Add(7);

            SelectionSorter<int> sorter = new SelectionSorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(9, collection.Count);
            Assert.IsTrue(SortableCollection<int>.IsSorted(collection));
        }
    }
}
