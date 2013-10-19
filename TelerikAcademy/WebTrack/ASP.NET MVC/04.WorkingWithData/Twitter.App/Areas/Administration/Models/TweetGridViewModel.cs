using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Twitter.App.Models;
using Twitter.Models;

namespace Twitter.App.Areas.Administration.Models
{
    public class TweetGridViewModel
    {
        public static Expression<Func<Tweet, TweetGridViewModel>> FromTweet
        {
            get
            {
                return c => new TweetGridViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    DateCreated = c.DateCreated,
                    Tags = c.Tags.AsQueryable().Select(TagShortModel.FromTag).ToList(),
                    Username = c.User.UserName
                };
            }

        }

        public int Id { get; set; }

        [Required]
        [StringLength(240, MinimumLength = 5)]
        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public string Username { get; set; }

        public List<TagShortModel> Tags { get; set; }

        public TweetGridViewModel()
        {
            this.Tags = new List<TagShortModel>();
        }
    }
}