using Data.Context;
using Data.Context.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Web.Services.Controllers;
using Web.Services.Repositories;

namespace Web.Services.Resolvers
{
    public class SchoolResolver :IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Configuration>());
            SchoolContext context = new SchoolContext();

            if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(new SchoolsRepository(context));
            }
            else if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(new StudentsRepository(context));
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}