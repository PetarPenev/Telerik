namespace _01.StudentSystem.Data.Migrations
{
    using _01StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_01.StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_01.StudentSystem.Data.StudentSystemContext context)
        {
            var firstStudent = new Student
            {
                StudentId = 2,
                FirstName = "Bastian",
                LastName = "Deisler",
                FacultyNumber = "2345"
            };

            var firstCourse = new Course
            {
                Name = "Biology",
                Description = "Introductory Biology Course"
            };

            var secondCourse = new Course
            {
                Name = "Mathematics",
                Description = "Introductory Maths Course"
            };

            //context.Courses.AddOrUpdate(c => c.Name, firstCourse);
            //context.Courses.AddOrUpdate(c => c.Name, secondCourse);

            firstStudent.Courses.Add(firstCourse);
            firstStudent.Courses.Add(secondCourse);
            context.Students.AddOrUpdate(s => s.FacultyNumber, firstStudent);

            var secondStudent = new Student
            {
                StudentId = 3,
                FirstName = "Ivelin",
                LastName = "Popov",
                FacultyNumber = "3456"
            };

            var thirdCourse = new Course
            {
                Name = "Geography",
                Description = "Introductory Geography Course"
            };

            //context.Courses.AddOrUpdate(c => c.Name, thirdCourse);

            secondStudent.Courses.Add(secondCourse);
            secondStudent.Courses.Add(thirdCourse);
            context.Students.AddOrUpdate(s => s.FacultyNumber, secondStudent);
            context.SaveChanges();
        }
    }
}