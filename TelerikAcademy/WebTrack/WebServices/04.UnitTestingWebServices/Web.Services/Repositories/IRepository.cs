using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Services.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Post(T entity);
        IQueryable<T> GetBySubjectAndValue(string subject, decimal value);
    }
}
