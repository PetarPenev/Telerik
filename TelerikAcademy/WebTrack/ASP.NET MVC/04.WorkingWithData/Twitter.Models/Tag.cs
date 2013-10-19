using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Tweet> Tweets { get; set; }

        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    }
}
