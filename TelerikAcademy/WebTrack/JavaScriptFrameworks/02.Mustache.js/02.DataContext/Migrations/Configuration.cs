namespace _02.DataContext.Migrations
{
    using _01.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_02.DataContext.MarksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_02.DataContext.MarksContext context)
        {
            var firstStudent = new Student();
            firstStudent.FirstName = "Spas";
            firstStudent.LastName = "Spasov";
            firstStudent.Grade = 11;
            firstStudent.Age = 17;
            context.Students.AddOrUpdate(st => st.LastName, firstStudent);

            var firstMark = new Mark() { Subject = "Maths", Score = 5 };
            var secondMark = new Mark() { Subject = "Maths", Score = 6 };
            var thirdMark = new Mark() { Subject = "Literature", Score = 5 };
            firstStudent.Marks.Add(firstMark);
            firstStudent.Marks.Add(secondMark);
            firstStudent.Marks.Add(thirdMark);
            context.SaveChanges();
        }
    }
}
