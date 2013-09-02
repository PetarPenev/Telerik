using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.DataContext;
using _01.DataModels;
using System.Data.Entity;
using _02.DataContext.Migrations;

namespace test
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MarksContext, Configuration>());
            using (var context = new MarksContext())
            {
                context.Students.Add(new Student() { FirstName = "Ivo", LastName = "Hristov" });
                context.SaveChanges();
            }
        }
    }
}
