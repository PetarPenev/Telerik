using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Web.Services.Repositories;
using Data.Models;
using Telerik.JustMock;
using Web.Services.Controllers;
using System.Linq;
using System.Net;
using Web.Services.Models;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class StudentsControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void GetAll_WhenASingleStudentInRepository_ShouldReturnSingleStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                LastName = "Test student"
            };

            IQueryable<Student> studentEntities = (new List<Student>() { studentToAdd }).AsQueryable();
            Mock.Arrange(() => repository.GetAll()).Returns (() => studentEntities.AsQueryable());

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.GetAll();
            List<StudentModel> students = new List<StudentModel>();
            bool gotValue = response.TryGetContentValue(out students);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(gotValue);
            Assert.IsTrue(students.Count == 1);
        }

        [TestMethod]
        public void GetAll_WhenMultipleStudentsInRepository_ShouldReturnSameCount()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var firstStudentToAdd = new Student()
            {
                LastName = "First test student"
            };

            var secondStudentToAdd = new Student()
            {
                LastName = "Second test student"
            };

            var thirdStudentToAdd = new Student()
            {
                LastName = "Third test student"
            };

            IQueryable<Student> studentEntities = (new List<Student>() 
            { firstStudentToAdd, secondStudentToAdd, thirdStudentToAdd }).AsQueryable();
            Mock.Arrange(() => repository.GetAll()).Returns(() => studentEntities.AsQueryable());

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.GetAll();
            List<StudentModel> students = new List<StudentModel>();
            bool gotValue = response.TryGetContentValue(out students);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(gotValue);
            Assert.IsTrue(students.Count == 3);
        }

        [TestMethod]
        public void GetById_WhenIdMatching_ShouldReturnAppropriateElement()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var firstStudentToAdd = new Student()
            {
                // Deliberate setting so that the appropriate id can be returned in the 
                // controller.
                Id = 32,
                LastName = "First test student"
            };

          
            Mock.Arrange(() => repository.GetById(Arg.Is(1))).Returns(() => firstStudentToAdd);

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.GetById(1);
            StudentModel student = new StudentModel();
            bool gotValue = response.TryGetContentValue(out student);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(gotValue);
            Assert.AreEqual(32, student.Id);
        }

        [TestMethod]
        public void GetById_WhenIdIsLessThanZero_ShouldReturnError()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var controller = new StudentsController(repository);
            SetupController(controller);
            
            var response = controller.GetById(-2);
            
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenValid_ShouldReturnAppropriateElement()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var firstStudentToAdd = new Student()
            {
                // Deliberate setting so that the appropriate id can be returned in the 
                // controller.
                Id = 32,
                LastName = "First test student"
            };


            Mock.Arrange(() => repository.Post(Arg.IsAny<Student>())).Returns(() => firstStudentToAdd);

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.PostStudent(new StudentModel()
            {
                LastName = "John",
                Age = 11,
                Grade = 5
            });

            Student student = new Student();
            bool gotValue = response.TryGetContentValue(out student);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(gotValue);
            Assert.AreEqual(32, student.Id);
        }

        [TestMethod]
        public void Post_WhenLastNameNull_ShouldReturnError()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.PostStudent(new StudentModel()
            {
                LastName = null,
                Age = 11,
                Grade = 5
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenAgeIsNegative_ShouldReturnError()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.PostStudent(new StudentModel()
            {
                LastName = "John",
                Age = -3,
                Grade = 5
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Post_WhenGradeIsNegative_ShouldReturnError()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var controller = new StudentsController(repository);
            SetupController(controller);

            var response = controller.PostStudent(new StudentModel()
            {
                LastName = "John",
                Age = 3,
                Grade = -5
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
