namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        public void TestConstructorNormalName()
        {
            Course course = new Course("Chemistry");

            Assert.AreEqual("Chemistry", course.Name);
            Assert.AreEqual(0, course.EnrolledStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorNullName()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorEmptyName()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorWhiteSpacedName()
        {
            Course course = new Course("    ");
        }

        [TestMethod]
        public void TestHasStudentRegularTest()
        {
            Course course = new Course("Chemistry");

            for (int i = 0; i < 20; i++)
            {
                course.AddStudent(new Student("Hari", (uint)i + 145));
            }

            Assert.IsTrue(course.HasStudent(new Student("Hari", 154)));
            Assert.IsFalse(course.HasStudent(new Student("Hari", 101)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHasStudentNullObject()
        {
            Course course = new Course("Chemistry");
            course.HasStudent(null);
        }

        [TestMethod]
        public void TestAddStudentNormalTest()
        {
            Course course = new Course("Chemistry");
            course.AddStudent(new Student("Hari", 11));

            Assert.IsTrue(course.HasStudent(new Student("Hari", 11)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddStudentNullObject()
        {
            Course course = new Course("Chemistry");
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddStudentAlreadyAdded()
        {
            Course course = new Course("Chemistry");
            course.AddStudent(new Student("Iva Toneva", 123));
            course.AddStudent(new Student("Iva Toneva", 123));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddStudentExceededCapacity()
        {
            Course course = new Course("Chemistry");

            for (int i = 0; i < 29; i++)
            {
                course.AddStudent(new Student("Hari", (uint)i + 145));
            }

            course.AddStudent(new Student("Hari", 202));
        }

        [TestMethod]
        public void TestRemoveStudentNormalRemoval()
        {
            Course course = new Course("Chemistry");
            course.AddStudent(new Student("Hari", 125));

            course.RemoveStudent(new Student("Hari", 125));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveStudentNullObject()
        {
            Course course = new Course("Chemistry");
            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestRemoveNonExistentStudent()
        {
            Course course = new Course("Chemistry");
            course.AddStudent(new Student("Hari", 125));

            course.RemoveStudent(new Student("Joe", 111));
        }

        [TestMethod]
        public void TestToString()
        {
            Course course = new Course("Chemistry");
            course.AddStudent(new Student("Hari", 125));

            string expectedOutput = "Course name: Chemistry" + Environment.NewLine +
                "Student: Hari, number: 125.";
            Assert.AreEqual(expectedOutput, course.ToString());
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Course course = new Course("Chemistry");
            course.GetHashCode();
        }

        [TestMethod]
        public void TestEqualDifferentCourses()
        {
            Course course = new Course("Chemistry");
            Course courseMock = new Course("Making Bread");

            Assert.IsFalse(course.Equals(courseMock));
        }

        [TestMethod]
        public void TestEqualSameCourses()
        {
            Course course = new Course("Chemistry");
            Course courseMock = new Course("Chemistry");

            Assert.IsTrue(course.Equals(courseMock));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEqualNullObject()
        {
            Course course = new Course("Chemistry");
            course.Equals(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEqualDifferentObject()
        {
            Course course = new Course("Chemistry");
            Student student = new Student("Hari", 123);

            course.Equals(student);
        }
    }
}
