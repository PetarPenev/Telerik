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
    public class MarksController : ApiController
    {
        public HttpResponseMessage GetMarks(int id)
        {
            /*var context = new MarksContext();
            var student = context.Students.SingleOrDefault(st => st.Id == id);

            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Student does not exist in database.");
            }

            var marksToReturn = (from mark in student.Marks
                                 select new MarkModel()
                                 {
                                     Id = mark.Id,
                                     Subject = mark.Subject,
                                     Score = mark.Score
                                 });

            return Request.CreateResponse(HttpStatusCode.OK, marksToReturn);*/

            var marksToReturn = new List<MarkModel>();
            marksToReturn.Add(new MarkModel() { Id = 1, Score = 5, Subject = "Maths" });
            marksToReturn.Add(new MarkModel() { Id = 2, Score = 6, Subject = "Maths" });
            marksToReturn.Add(new MarkModel() { Id = 3, Score = 5, Subject = "Literature" });
            return Request.CreateResponse(HttpStatusCode.OK, marksToReturn);
        }
    }
}