using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Data
{
    public interface IUowData : IDisposable
    {
        GenericRepository<Tag> Tags { get; }

        GenericRepository<Tweet> Tweets { get; }

        GenericRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
