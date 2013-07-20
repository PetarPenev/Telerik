namespace _02.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class UnitTestingLinearSearch
    {
        [TestMethod]
        public void TestWithAnEmptyCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            bool isFound = collection.LinearSearch(4);
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void TestWithASingleItemFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4 });

            bool isFound = collection.LinearSearch(4);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithASingleItemNotFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 6 });

            bool isFound = collection.LinearSearch(4);
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void TestWithMultipleItemsFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 11, -3, 7, 9, 23 });

            bool isFound = collection.LinearSearch(9);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithMultipleItemsNotFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 11, -3, 7, 9, 23 });

            bool isFound = collection.LinearSearch(235);
            Assert.IsFalse(isFound);
        }
    }
}
