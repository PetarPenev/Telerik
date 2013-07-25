using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;
using System.Data.Entity.Infrastructure;

namespace _06.TwinDatabase
{
    class Program
    {
        static void Main()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                StringBuilder scriptToExecute = new StringBuilder();
                scriptToExecute.AppendLine("Use NorthwindTwin");

                scriptToExecute.AppendLine((northwindEntities as IObjectContextAdapter).ObjectContext.CreateDatabaseScript());
                northwindEntities.Database.ExecuteSqlCommand("CREATE DATABASE NorthwindTwin");
                northwindEntities.Database.ExecuteSqlCommand(scriptToExecute.ToString());
            }
        }
    }
}