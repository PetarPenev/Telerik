namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void TestConstructor()
        {
            School school = new School();
        }

        [TestMethod]
        public void TestHasCourseExistingCourse()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));

            Assert.IsTrue(school.HasCourse(new Course("Chemistry")));
        }

        [TestMethod]
        public void TestHasCourseMissingCourse()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));

            Assert.IsFalse(school.HasCourse(new Course("Biology")));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHasCourseNullObject()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));

            Assert.IsFalse(school.HasCourse(null));
        }

        [TestMethod]
        public void TestAddCourseNormalAddition()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));

            Assert.IsTrue(school.OfferedCourses.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddCourseNullObject()
        {
            School school = new School();
            school.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddCourseAlreadyAddedCourse()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));
            school.AddCourse(new Course("Chemistry"));
        }

        [TestMethod]
        public void TestRemoveCourseNormalRemoval()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));
            school.AddCourse(new Course("Geography"));

            school.RemoveCourse(new Course("Chemistry"));
            Assert.IsTrue(school.OfferedCourses.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveCourseNullObject()
        {
            School school = new School();
            school.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestRemoveCourseMissingCourse()
        {
            School school = new School();
            school.AddCourse(new Course("Chemistry"));
            school.RemoveCourse(new Course("Geography"));
        }

        [TestMethod]
        public void TestToString()
        {
            School school = new School();
            Course course = new Course("Chemistry");
            course.AddStudent(new Student("Hari", 123));
            course.AddStudent(new Student("Joe", 124));
            school.AddCourse(course);

            string expectedOutput = "Course name: Chemistry" + Environment.NewLine +
                "Student: Hari, number: 123." + Environment.NewLine +
                "Student: Joe, number: 124.";
            Assert.AreEqual(expectedOutput, school.ToString());
        }
    }
}
