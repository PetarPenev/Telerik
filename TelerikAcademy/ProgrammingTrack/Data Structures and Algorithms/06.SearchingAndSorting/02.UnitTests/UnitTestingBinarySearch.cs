namespace _02.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class UnitTestingBinarySearch
    {
        [TestMethod]
        public void TestWithAnEmptyCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            bool isFound = collection.BinarySearch(5);
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void TestWithASingleItemFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4 });
            bool isFound = collection.BinarySearch(4);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithASingleItemNotFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4 });
            bool isFound = collection.BinarySearch(5);
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void TestWithTwoItemsFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 3 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(4);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithTwoItemsNotFound()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 3 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(0);
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void TestWithOddNumberOfItemsFoundAtFirstPosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 3, -2, 11, 16, 0, 1 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(-2);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithOddNumberOfItemsFoundAtLastPosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 3, -2, 11, 16, 0, 1 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(16);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithOddNumberOfItemsFoundAtMiddlePosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 4, 3, -2, 11, 16, 0, 1 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(3);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithEvenNumberOfItemsFoundAtFirstPosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 7, 11, 0, -123, 9, 3, 12, 2 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(-123);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithEvenNumberOfItemsFoundAtLastPosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 7, 11, 0, -123, 9, 3, 12, 2 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(12);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithEvenNumberOfItemsFoundAtAbsoluteMiddlePosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 7, 11, 0, -123, 9, 3, 12, 2 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(3);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void TestWithEvenNumberOfItemsFoundAtPositionAfterAbsoluteMiddlePosition()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 7, 11, 0, -123, 9, 3, 12, 2 });
            collection.Sort(new MergeSorter<int>());

            bool isFound = collection.BinarySearch(7);
            Assert.IsTrue(isFound);
        }
    }
}
