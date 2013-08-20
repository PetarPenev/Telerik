using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Web.Services.Repositories;
using Data.Models;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Web.Services.Models;

namespace UnitTests.Integration
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                LastName = "Johnson",
                Age = 20,
                Grade = 12
            };

            IQueryable<Student> studentEntities = (new List<Student>() { studentToAdd }).AsQueryable();

            Mock.Arrange(() => mockRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            var str = response.Content.ReadAsStringAsync();
            // The str.Results is an array in string form. When it is empty, it always return "[]" string,
            // meaning that if it has content, its length is greater than 2. The approach shown in the lecture
            // is not working - the Assert always passes.
            Assert.IsTrue(str.Result.Length > 2);
        }

        [TestMethod]
        public void GetAll_WhenMultipleStudents_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                LastName = "Johnson",
                Age = 20,
                Grade = 12
            };

            var secondStudentToAdd = new Student()
            {
                LastName = "Davis",
                Age = 16,
                Grade = 10
            };

            IQueryable<Student> studentEntities = (new List<Student>() { studentToAdd, secondStudentToAdd }).AsQueryable();

            Mock.Arrange(() => mockRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var str = response.Content.ReadAsStringAsync();
            Assert.IsTrue(str.Result.Length > 2);
        }

        [TestMethod]
        public void GetAll_WhenNoStudents_ShouldReturnStatusCode200AndNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            IQueryable<Student> studentEntities = (new List<Student>()).AsQueryable();

            Mock.Arrange(() => mockRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var str = response.Content.ReadAsStringAsync();            
            Assert.IsTrue(str.Result.Length == 2);
        }

        [TestMethod]
        public void GetById_WhenStudentsExists_ShouldReturnStatusCode200AndSomeContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();


            var studentToAdd = new Student()
            {
                LastName = "Johnson",
                Age = 20,
                Grade = 12
            };

            Mock.Arrange(() => mockRepository.GetById(Arg.Is<int>(1)))
                .Returns(() => studentToAdd);

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var str = response.Content.ReadAsStringAsync();
            Assert.IsTrue(str.Result.Length > 2);
        }

        [TestMethod]
        public void GetById_WhenStudentsDoesNotExists_ShouldReturnStatusCode404AndSomeContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository.GetById(Arg.IsAny<int>()))
                .Returns(() => null);

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students/1");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenStudentIsCorrect_ShouldReturnStatusCode200AndSomeContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository.Post(Arg.IsAny<Student>()))
                .Returns(() => new Student() { Id = 3 } );

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreatePostRequest("api/students/", new StudentModel()
            {
                Age = 11,
                FirstName = "Boiko",
                LastName = "Kanev",
                Grade = 4
            });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenStudentAgeIsNegative_ShouldReturnStatusCode400()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository.Post(Arg.IsAny<Student>()))
                .Returns(() => new Student() { Id = 3 });

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreatePostRequest("api/students/", new StudentModel()
            {
                Age = -4,
                FirstName = "Boiko",
                LastName = "Kanev",
                Grade = 4
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenStudentGradeIsOutsideRange_ShouldReturnStatusCode400()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository.Post(Arg.IsAny<Student>()))
                .Returns(() => new Student() { Id = 3 });

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreatePostRequest("api/students/", new StudentModel()
            {
                Age = 14,
                FirstName = "Boiko",
                LastName = "Kanev",
                Grade = 21
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenStudentLastNameIsNull_ShouldReturnStatusCode400()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository.Post(Arg.IsAny<Student>()))
                .Returns(() => new Student() { Id = 3 });

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreatePostRequest("api/students/", new StudentModel()
            {
                Age = 14,
                FirstName = "Boiko",
                LastName = null,
                Grade = 8
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
