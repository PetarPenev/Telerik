using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("SchoolDb")
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Subject> Subjects { get; set; }
    }
}
