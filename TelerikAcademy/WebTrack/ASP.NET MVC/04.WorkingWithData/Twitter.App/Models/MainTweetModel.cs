using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.App.Models
{
    public class MainTweetModel
    {
        public ICollection<TweetViewModel> Tweets { get; set; }

        public TweetCreateModel NewTweet { get; set; }

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        public TagShortModel TagToAdd { get; set; }

        public MainTweetModel()
        {
            this.Tweets = new HashSet<TweetViewModel>();
        }
    }
}