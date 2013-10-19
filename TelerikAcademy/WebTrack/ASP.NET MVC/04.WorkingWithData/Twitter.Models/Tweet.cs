using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(240, MinimumLength = 5)]
        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ApplicationUser User { get; set; }

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }
    }
}
