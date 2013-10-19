using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Twitter.Models;

namespace Twitter.App.Models
{
    public class TweetViewModel
    {
        public static Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return tweet => new TweetViewModel
                {
                    Id = tweet.Id,
                    Text = tweet.Text,
                    DateCreated = tweet.DateCreated,
                    Username = tweet.User.UserName,
                    Tags = tweet.Tags.AsQueryable().Select(TagShortModel.FromTag).ToList(),
                    UserId = tweet.User.Id
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }

        public List<TagShortModel> Tags { get; set; }

        public TweetCreateModel Tweet { get; set; }

        public TweetViewModel()
        {
            this.Tags = new List<TagShortModel>();
        }
    }
}