using _01.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DataContext
{
    public class MarksContext  : DbContext
    {
        public MarksContext() :
            base("MarksDb")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }
    }
}