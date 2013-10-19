using _01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Data
{
    public class WorldContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public WorldContext()
            : base("WorldDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Country>().HasMany(c => c.Towns).WithRequired().WillCascadeOnDelete();
            //modelBuilder.Entity<Continent>().HasMany(c => c.Countries).WithRequired().WillCascadeOnDelete();
            //modelBuilder.Entity<Country>().HasRequired(c => c.Towns).WithMany().WillCascadeOnDelete();
            //modelBuilder.Entity<Continent>().HasRequired(c => c.Countries).WithMany().WillCascadeOnDelete();
            modelBuilder.Entity<Country>()
                .HasOptional(r => r.Continent)
                .WithMany(s => s.Countries)
                .HasForeignKey(f => f.ContinentId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Town>()
                .HasOptional(r => r.Country)
                .WithMany(s => s.Towns)
                .HasForeignKey(f => f.CountryId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
