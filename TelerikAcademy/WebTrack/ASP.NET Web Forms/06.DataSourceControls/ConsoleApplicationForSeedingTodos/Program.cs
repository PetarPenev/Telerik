using _05.ToDoData;
using _05.ToDoData.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForSeedingTodos
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ListContext, Configuration>());
            var context = new ListContext();
            var cat = context.Categories.SingleOrDefault(c => c.Name == "Sports");
            if (cat != null)
            {
                context.Categories.Remove(cat);
                //context.SaveChanges();
            }
        }
    }
}
