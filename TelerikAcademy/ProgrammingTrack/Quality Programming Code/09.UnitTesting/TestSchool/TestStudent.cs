namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        public void TestConstructorNameNormalValue()
        {
            Student student = new Student("Elena Hristova", 123);

            Assert.AreEqual("Elena Hristova", student.Name);
            Assert.AreEqual(123, (int)student.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorNullName()
        {
            Student student = new Student(null, 123);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorEmptyName()
        {
            Student student = new Student(string.Empty, 123);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorWhiteSpacedName()
        {
            Student student = new Student("   ", 123);
        }

        [TestMethod]
        public void TestToString()
        {
            Student student = new Student("Elena Hristova", 123);

            Assert.AreEqual("Student: Elena Hristova, number: 123.", student.ToString());
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Student student = new Student("Hari", 123);
            student.GetHashCode();
        }

        [TestMethod]
        public void TestEqualsWithEqualNumbersAndNames()
        {
            Student studentFirst = new Student("Elena Hristova", 123);
            Student studentSecond = new Student("Elena Hristova", 123);

            Assert.IsTrue(studentFirst.Equals(studentSecond));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEqualsWithEqualNumbersDifferentNames()
        {
            Student studentFirst = new Student("Elena Hristova", 123);
            Student studentSecond = new Student("Jeni Dacheva", 123);

            Assert.IsTrue(studentFirst.Equals(studentSecond));
        }

        [TestMethod]
        public void TestEqualsWithDifferentNumbers()
        {
            Student studentFirst = new Student("Elena Hristova", 123);
            Student studentSecond = new Student("Iva Ivanova", 1233);

            Assert.IsFalse(studentFirst.Equals(studentSecond));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEqualsWithNullObject()
        {
            Student studentFirst = new Student("Elena Hristova", 123);
            studentFirst.Equals(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEqualsWithDifferentObject()
        {
            Student studentFirst = new Student("Elena Hristova", 123);
            studentFirst.Equals("brigada");
        }
    }
}
