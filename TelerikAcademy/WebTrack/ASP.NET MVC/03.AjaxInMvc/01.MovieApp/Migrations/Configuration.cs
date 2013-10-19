namespace _01.MovieApp.Migrations
{
    using _01.MovieApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_01.MovieApp.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_01.MovieApp.Models.MovieContext context)
        {
            var firstStudio = new Studio()
            {
                Name = "20 Century Fox",
                Address = "First Road"
            };

            context.Studios.AddOrUpdate(s => s.Name, firstStudio);
            context.SaveChanges();

            var secondStudio = new Studio()
            {
                Name = "Metro Goldwin Meyer",
                Address = "Second Road"
            };

            context.Studios.AddOrUpdate(s => s.Name, secondStudio);
            context.SaveChanges();

            var firstDirector = new Person()
            {
                Name = "Tim Burton",
                Age = 54
            };

            context.People.AddOrUpdate(p => p.Name, firstDirector);
            context.SaveChanges();

            var secondDirector = new Person()
            {
                Name = "Christopher Nolan",
                Age = 40
            };

            context.People.AddOrUpdate(p => p.Name, secondDirector);
            context.SaveChanges();

            var maleLead = new Person()
            {
                Name = "Edward Norton",
                Age = 39
            };

            context.People.AddOrUpdate(p => p.Name, maleLead);
            context.SaveChanges();

            var firstFemale = new Person()
            {
                Name = "Christina Hendrix",
                Age = 45
            };

            context.People.AddOrUpdate(p => p.Name, firstFemale);
            context.SaveChanges();

            var secondFemale = new Person()
            {
                Name = "Megan Fox",
                Age = 28
            };

            context.People.AddOrUpdate(p => p.Name, secondFemale);
            context.SaveChanges();

            var firstMovie = new Movie()
            {
                Title = "First Movie",
                Director = firstDirector,
                LeadMaleActor = maleLead,
                LeadFemaleActress = firstFemale,
                Studio = firstStudio,
                Year = 2011
            };

            context.Movies.AddOrUpdate(m => m.Title, firstMovie);
            context.SaveChanges();

            var secondMovie = new Movie()
            {
                Title = "Second Movie",
                Director = secondDirector,
                LeadMaleActor = maleLead,
                LeadFemaleActress = secondFemale,
                Studio = secondStudio,
                Year = 2013
            };

            context.Movies.AddOrUpdate(m => m.Title, secondMovie);
            context.SaveChanges();
        }
    }
}
