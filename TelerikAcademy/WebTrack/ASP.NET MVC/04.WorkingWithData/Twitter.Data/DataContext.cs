using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;
using System.Data.Entity;

namespace Twitter.Data
{
    public class DataContext: IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<Tag> Tags { get; set; }
    }
}
