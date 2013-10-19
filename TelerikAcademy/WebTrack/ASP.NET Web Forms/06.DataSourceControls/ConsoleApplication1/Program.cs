using _02.Data;
using _02.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorldContext, Configuration>());
            var context = new WorldContext();
            var contr = context.Countries.SingleOrDefault(c => c.Name == "Bulgaria");
            if (contr != null)
            {
                context.Countries.Remove(contr);
                //context.SaveChanges();
            }
        }
    }
}
