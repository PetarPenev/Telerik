using _04.ToDoModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ToDoData
{
    public class ListContext: DbContext
    {
        public ListContext()
            : base("ListDb")
        {
        }

        public DbSet<ToDo> Todos { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .HasOptional(r => r.Category)
                .WithMany(s => s.ToDos)
                .HasForeignKey(f => f.CategoryId)
                .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }
    }
}
