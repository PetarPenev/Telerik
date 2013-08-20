using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Web.Services.Controllers;
using Web.Services.Repositories;

namespace UnitTests.Integration
{
    class TestDependencyResolver<T> : IDependencyResolver
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.Repository as IRepository<Student>);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(this.Repository as IRepository<School>);
            }
            return null;
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
