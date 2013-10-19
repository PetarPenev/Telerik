namespace _05.ToDoData.Migrations
{
    using _04.ToDoModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_05.ToDoData.ListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_05.ToDoData.ListContext context)
        {
            var categoryFirst = new Category();
            categoryFirst.Name = "Sports";

            var cat1todo1 = new ToDo();
            cat1todo1.Title = "Football";
            cat1todo1.Text = "Play football for 2 hours";
            cat1todo1.LastChangedDate = DateTime.Now;

            var cat1todo2 = new ToDo();
            cat1todo2.Title = "Basketball";
            cat1todo2.Text = "Play basketball for 3 hours";
            cat1todo2.LastChangedDate = DateTime.Now;

            var cat1todo3 = new ToDo();
            cat1todo3.Title = "Volleyball";
            cat1todo3.Text = "Play volleyball for 1 hour";
            cat1todo3.LastChangedDate = DateTime.Now;

            var cat1todo4 = new ToDo();
            cat1todo4.Title = "Poker";
            cat1todo4.Text = "Play poker for $1000";
            cat1todo4.LastChangedDate = DateTime.Now;

            categoryFirst.ToDos.Add(cat1todo1);
            categoryFirst.ToDos.Add(cat1todo2);
            categoryFirst.ToDos.Add(cat1todo3);
            categoryFirst.ToDos.Add(cat1todo4);
            context.Categories.AddOrUpdate(c => c.Name, categoryFirst);

            var categorySecond = new Category();
            categorySecond.Name = "Movies";

            var cat2todo1 = new ToDo();
            cat2todo1.Title = "Goodfellas";
            cat2todo1.Text = "Watch it again";
            cat2todo1.LastChangedDate = DateTime.Now;

            var cat2todo2 = new ToDo();
            cat2todo2.Title = "BladeRunner";
            cat2todo2.Text = "Watch it for the first time";
            cat2todo2.LastChangedDate = DateTime.Now;

            categorySecond.ToDos.Add(cat2todo1);
            categorySecond.ToDos.Add(cat2todo2);
            context.Categories.AddOrUpdate(c => c.Name, categorySecond);
        }
    }
}
