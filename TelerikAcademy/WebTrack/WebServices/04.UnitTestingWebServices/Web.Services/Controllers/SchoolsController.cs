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
    public class SchoolsController : ApiController
    {
        private IRepository<School> repository;

        public SchoolsController(IRepository<School> schoolsRepository)
        {
            this.repository = schoolsRepository;
        }

        [HttpGet]
        [ActionName("get-all")]
        public HttpResponseMessage GetAll()
        {
            var schools = this.repository.GetAll();

            List<SchoolModel> modelsToReturn = new List<SchoolModel>();

            foreach (var school in schools)
            {
                modelsToReturn.Add(new SchoolModel
                {
                    Id = school.Id,
                    Name = school.Name,
                    Location = school.Location
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, modelsToReturn);
        }

        [HttpGet]
        [ActionName("get-by-id")]
        public HttpResponseMessage GetById(int id)
        {
            var school = this.repository.GetById(id);
            if (school == null)
            {
                var httpError = new HttpError("Such school does not exist");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new SchoolModel()
            {
                Id = school.Id,
                Name = school.Name,
                Location = school.Location
            });
        }

        [HttpPost]
        public HttpResponseMessage PostSchool([FromBody]SchoolModel schoolToAdd)
        {
            if (schoolToAdd.Name == null)
            {
                var httpError = new HttpError("Schools must have a name.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, httpError);
            }

            var school = this.repository.Post(new School()
            {
                Name = schoolToAdd.Name,
                Location = schoolToAdd.Location
            });

            if (school.Id == 0)
            {
                var httpError = new HttpError("Incorrect database operation.");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new SchoolModel()
            {
                Id = school.Id,
                Name = school.Name,
                Location = school.Location
            });
        }
    }
}