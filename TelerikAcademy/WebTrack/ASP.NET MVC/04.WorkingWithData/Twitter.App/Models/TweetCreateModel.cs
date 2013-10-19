using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.App.Models
{
    public class TweetCreateModel
    {
        [Required]
        [StringLength(240, MinimumLength = 5)]
        public string Text { get; set; }

        public List<int> Tags { get; set; }

        public TweetCreateModel()
        {
            this.Tags = new List<int>();
        }
    }
}