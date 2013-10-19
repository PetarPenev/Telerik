using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ApplicationUser : User
    {
        public ICollection<Tweet> Tweets { get; set; }

        public ApplicationUser()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    }
}
