using _01.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Context
{
    public class AlbumContext : DbContext
    {
        public AlbumContext()
            : base("AlbumDb")
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}
