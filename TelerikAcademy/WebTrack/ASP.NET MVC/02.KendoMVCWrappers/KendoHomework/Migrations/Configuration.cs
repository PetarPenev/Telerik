namespace KendoHomework.Migrations
{
    using KendoHomework.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KendoHomework.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KendoHomework.Models.ApplicationDbContext context)
        {
            var firstCategory = new Category()
            {
                Name = "Fiction"
            };

            context.Categories.AddOrUpdate(c => c.Name, firstCategory);
            context.SaveChanges();

            var secondCategory = new Category()
            {
                Name = "Non-fiction"
            };

            context.Categories.AddOrUpdate(c => c.Name, secondCategory);
            context.SaveChanges();

            var firstBook = new Book()
            {
                Title = "Under the Yoke",
                Isbn = "1234567890123",
                WebSite = "www.vazov.org",
                Author = "Ivan Vazov",
                Category = firstCategory,
                Description = "Under the Yoke" 
            };

            context.Books.AddOrUpdate(b => b.Title, firstBook);
            context.SaveChanges();

            var secondBook = new Book()
            {
                Title = "New Land",
                Isbn = "9876543210987",
                WebSite = "www.vazov.org",
                Author = "Ivan Vazov",
                Category = firstCategory,
                Description = "New Land"
            };

            context.Books.AddOrUpdate(b => b.Title, secondBook);
            context.SaveChanges();

            var thirdBook = new Book()
            {
                Title = "King Rat",
                Isbn = "9876546670987",
                WebSite = "www.ufc.com",
                Author = "China Mieville",
                Category = firstCategory,
                Description = "King Rat"
            };

            context.Books.AddOrUpdate(b => b.Title, thirdBook);
            context.SaveChanges();

            var forthBook = new Book()
            {
                Title = "The Twilight of the Idols",
                Isbn = "9876512670987",
                WebSite = "www.german-humor.com",
                Author = "Friedrich Nietzsche",
                Category = secondCategory,
                Description = "The Twilight of the Idols"
            };

            context.Books.AddOrUpdate(b => b.Title, forthBook);
            context.SaveChanges();

            var fifthBook = new Book()
            {
                Title = "Psychology of the Crowd",
                Isbn = "9874792670987",
                WebSite = "www.bing.com",
                Author = "Gustave Le Bon",
                Category = secondCategory,
                Description = "Psychology of the Crowd"
            };

            context.Books.AddOrUpdate(b => b.Title, fifthBook);
            context.SaveChanges();
        }
    }
}
