using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _01.MovieApp.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Studio> Studios { get; set; }
    }
}