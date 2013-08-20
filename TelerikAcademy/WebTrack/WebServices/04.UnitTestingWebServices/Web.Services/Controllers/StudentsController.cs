using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.Services.Models;
using Web.Services.Repositories;

namespace Web.Services.Controllers
{
    public class StudentsController :ApiController
    {
        private IRepository<Student> repository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.repository = studentsRepository;
        }

        [HttpGet]
        [ActionName("get-all")]
        public HttpResponseMessage GetAll()
        {
            var students = this.repository.GetAll();

            List<StudentModel> modelsToReturn = new List<StudentModel>();

            foreach (var student in students)
            {
                modelsToReturn.Add(new StudentModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, modelsToReturn);
        }

        [HttpGet]
        [ActionName("get-by-id")]
        public HttpResponseMessage GetById(int id)
        {
            if (id <= 0)
            {
                var httpError = new HttpError("Id should be non-negative integer.");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
            }

            var student = this.repository.GetById(id);
            if (student == null)
            {
                var httpError = new HttpError("Such student does not exist");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new StudentModel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade
            });
        }

        [HttpPost]
        public HttpResponseMessage PostStudent([FromBody]StudentModel studentToAdd)
        {
            if (studentToAdd.LastName == null)
            {
                var httpError = new HttpError("Students must have a last name.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, httpError);
            }

            if ((studentToAdd.Age <0))
            {
                var httpError = new HttpError("Students must have a non-negative age.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, httpError);
            }

            if ((studentToAdd.Grade <= 0) || (studentToAdd.Grade > 12))
            {
                var httpError = new HttpError("Students must have an appropriate grade (1 - 12).");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, httpError);
            }

            var student = this.repository.Post(new Student()
            {
                FirstName = studentToAdd.FirstName,
                LastName = studentToAdd.LastName,
                Grade = studentToAdd.Grade,
                Age = studentToAdd.Age
            });

            if (student.Id == 0)
            {
                var httpError = new HttpError("Incorrect database operation.");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [HttpGet]
        public HttpResponseMessage GetBySubjectAndValue(string subject, string value)
        {
            if ((subject == null) || (subject == string.Empty))
            {
                var httpError = new HttpError("Subject should be specified.");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
            }

            decimal decimalValue;
            value = value.Replace('.', ',');
            if ((value == null) || (value == string.Empty) || (!decimal.TryParse(value, out decimalValue)))
            {
                var httpError = new HttpError("Value should be specified and be parsable as decimal.");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
            }

            var students = this.repository.GetBySubjectAndValue(subject, decimalValue);

            List<StudentModel> modelsToReturn = new List<StudentModel>();

            foreach (var student in students)
            {
                modelsToReturn.Add(new StudentModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, modelsToReturn);
        }
    }
}