using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Services.Repositories
{
    public class SchoolsRepository : IRepository<School>
    {
        private DbContext context;
        private DbSet<School> entities;

        public SchoolsRepository(DbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<School>();
        }

        public IQueryable<School> GetAll()
        {
            return this.entities;
        }

        public School GetById(int id)
        {
            return this.entities.SingleOrDefault(s => s.Id == id);
        }

        public School Post(School entity)
        {
            this.entities.Add(entity);
            this.context.SaveChanges();
            return entity;
        }


        public IQueryable<School> GetBySubjectAndValue(string subject, decimal value)
        {
            throw new NotImplementedException();
        }
    }
}