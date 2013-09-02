using _02.DataContext;
using _03.WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _03.WebServices.Controllers
{
    public class StudentsController : ApiController
    {
        public HttpResponseMessage GetStudents()
        {
            /*var context = new MarksContext();
            var modelsToReturn = (from student in context.Students
                                  select new StudentModel()
                                  {
                                      Id = student.Id,
                                      FirstName = student.FirstName,
                                      LastName = student.LastName,
                                      Grade = student.Grade,
                                      Age = student.Age
                                  });

            return Request.CreateResponse(HttpStatusCode.OK, modelsToReturn);*/

            var modelsToReturn = new List<StudentModel>();
            modelsToReturn.Add(new StudentModel()
            {
                FirstName = "Ivan",
                LastName = "Hristov",
                Age = 17,
                Grade = 11,
                Id = 1
            });

            modelsToReturn.Add(new StudentModel()
            {
                FirstName = "Stoyan",
                LastName = "Petrov",
                Age = 16,
                Grade = 10,
                Id = 2
            });

            modelsToReturn.Add(new StudentModel()
            {
                FirstName = "Ivona",
                LastName = "Markova",
                Age = 19,
                Grade = 12,
                Id = 3
            });

            return Request.CreateResponse(HttpStatusCode.OK, modelsToReturn);
        }
    }
}