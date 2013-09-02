using _01.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _01.Services.Controllers
{
    public class StudentsController : ApiController
    {
        List<Student> students = new List<Student>();

        public StudentsController()
        {
            students.Add(new Student()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Hristov",
                Grade = 11,
                Marks = new List<Mark>()
                {
                    new Mark(){
                        Subject = "Maths",
                        Value = 4
                    },
                    new Mark(){
                        Subject = "Literature",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "Maths",
                        Value = 5
                    },
                    new Mark(){
                        Subject = "Geography",
                        Value = 2
                    }
                }
            });

            students.Add(new Student()
            {
                Id = 2,
                FirstName = "Nina",
                LastName = "Trencheva",
                Grade = 10,
                Marks = new List<Mark>()
                {
                    new Mark(){
                        Subject = "Biology",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "Biology",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "Biology",
                        Value = 6
                    }
                }
            });

            students.Add(new Student()
            {
                Id = 3,
                FirstName = "Stoyan",
                LastName = "Parvanov",
                Grade = 10,
                Marks = new List<Mark>()
                {
                    new Mark(){
                        Subject = "Biology",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "Biology",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "Physics",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "Maths",
                        Value = 6
                    },
                    new Mark(){
                        Subject = "History",
                        Value = 6
                    }
                }
            });

            students.Add(new Student()
            {
                Id = 4,
                FirstName = "Gabriela",
                LastName = "Ivanova",
                Grade = 12,
                Marks = new List<Mark>()
                {
                    new Mark(){
                        Subject = "Chemistry",
                        Value = 5
                    }
                }
            });
        }

        [HttpGet]
        public HttpResponseMessage All()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.students);
        }

        [HttpGet]
        public HttpResponseMessage ById(int id)
        {
            var student = this.students.SingleOrDefault(st => st.Id == id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Student does not exist.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, student.Marks);
        }
    }
}