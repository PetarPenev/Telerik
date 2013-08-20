using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Services.Repositories
{
    public class StudentsRepository  : IRepository<Student>
    {
        private DbContext context;
        private DbSet<Student> entities;

        public StudentsRepository(DbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<Student>();
        }
        
        public IQueryable<Student> GetAll()
        {
            return this.entities;
        }

        public Student GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id should be non-negative integer.");
            }

            return this.entities.SingleOrDefault(c => c.Id == id);
        }

        public Student Post(Student entity)
        {
            if (!ValidateStudentLastName(entity))
            {
                throw new ArgumentNullException("Student should have a last name");
            }

            if (!ValidateStudentAge(entity.Age))
            {
                throw new ArgumentOutOfRangeException("Student should have a non-negative age");
            }

            if (!ValidateStudentGrade(entity.Grade))
            {
                throw new ArgumentOutOfRangeException("Student should have an appropriate grade (1 - 12)");
            }

            this.entities.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        private bool ValidateStudentGrade(int grade)
        {
            return ((grade > 0) && (grade <= 12));
        }

        private bool ValidateStudentLastName(Student entity)
        {
            return entity.LastName != null;
        }

        private bool ValidateStudentAge(int age)
        {
            return age >= 0;
        }

        public IQueryable<Student> GetBySubjectAndValue(string subject, decimal value)
        {
            return this.entities.Include("School").Include("Marks").Include("Marks.Subject").
                Where(e => e.Marks.Any(m => m.Value >= value) && e.Marks.Any(m => m.Subject.Name == subject));
        }
    }
}