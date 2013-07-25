using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _01StudentSystem.Model;

namespace _01.StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            :base("data source=.\\;initial catalog=StudentSystem;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}
