using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Web.Services.Repositories;
using System.Transactions;
using Data.Models;
using Data.Context;

namespace UnitTests.Repositories
{
    [TestClass]
    public class StudentRepositoryTests
    {
        public DbContext dbContext { get; set; }

        public IRepository<Student> studentsRepository { get; set; }

        private static TransactionScope tranScope;

        public StudentRepositoryTests()
        {
            this.dbContext = new SchoolContext();
            this.studentsRepository = new StudentsRepository(this.dbContext);
        }

        [TestInitialize]
        public void TestStartup()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestEnd()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void TestAdd_WithCorrectParameters_ShouldBeAdded()
        {
            var student = new Student
            {
                FirstName = "John",
                LastName = "Travolta",
                Grade = 11,
                Age = 16
            };

            var postedStudent = this.studentsRepository.Post(student);
            Assert.IsTrue(postedStudent.Id > 0);
            var studentFromContext = this.dbContext.Set<Student>().Find(postedStudent.Id);
            Assert.AreEqual(postedStudent.FirstName, studentFromContext.FirstName);
            Assert.AreEqual(postedStudent.LastName, studentFromContext.LastName);
            Assert.AreEqual(postedStudent.Grade, studentFromContext.Grade);
            Assert.AreEqual(postedStudent.Age, studentFromContext.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAdd_WithNullLastName_ShouldThrowException()
        {
            var student = new Student
            {
                FirstName = "John",
                LastName = null,
                Grade = 11,
                Age = 16
            };

            var postedStudent = this.studentsRepository.Post(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAdd_WithNegativeAge_ShouldThrowException()
        {
            var student = new Student
            {
                FirstName = "John",
                LastName = "Travolta",
                Grade = 11,
                Age = -3
            };

            var postedStudent = this.studentsRepository.Post(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAdd_WithNegativeGrade_ShouldThrowException()
        {
            var student = new Student
            {
                FirstName = "John",
                LastName = "Travolta",
                Grade = -3,
                Age = 11
            };

            var postedStudent = this.studentsRepository.Post(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAdd_WithTooHighGrade_ShouldThrowException()
        {
            var student = new Student
            {
                FirstName = "John",
                LastName = "Travolta",
                Grade = 37,
                Age = 11
            };

            var postedStudent = this.studentsRepository.Post(student);
        }

        [TestMethod]
        public void TestGetById_ReturnCorrectOptions()
        {
            var student = new Student
            {
                FirstName = "John",
                LastName = "Travolta",
                Grade = 11,
                Age = 16
            };

            var postedStudent = this.studentsRepository.Post(student);
            Assert.IsTrue(postedStudent.Id > 0);
            var studentFromContext = this.studentsRepository.GetById(postedStudent.Id);
            Assert.AreEqual(postedStudent.FirstName, studentFromContext.FirstName);
            Assert.AreEqual(postedStudent.LastName, studentFromContext.LastName);
            Assert.AreEqual(postedStudent.Grade, studentFromContext.Grade);
            Assert.AreEqual(postedStudent.Age, studentFromContext.Age);
        }

        [TestMethod]
        public void TestGetById_ReturnNothing()
        {
            // Please ensure there is no student with id = 333 in the database.
            var studentFromContext = this.studentsRepository.GetById(333);
            Assert.IsNull(studentFromContext);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetById_NegativeId_ShouldThrowException()
        {            
            var studentFromContext = this.studentsRepository.GetById(-20);
        }
    }
}