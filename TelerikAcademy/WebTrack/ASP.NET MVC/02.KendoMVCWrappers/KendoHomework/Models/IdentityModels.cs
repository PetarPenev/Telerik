using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace KendoHomework.Models
{


    public class ApplicationDbContext : IdentityDbContextWithCustomUser<User>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }
    }

}