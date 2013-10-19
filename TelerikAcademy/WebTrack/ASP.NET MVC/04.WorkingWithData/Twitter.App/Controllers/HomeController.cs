using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.App.Models;
using Twitter.Data;
using Kendo.Mvc.Extensions;
using Twitter.Models;

namespace Twitter.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            :base(new UowData())
        {
        }

        public HomeController(IUowData data)
            :base(data)
        {
        }
        public ActionResult Index(string errorMessage, string successMessage)
        {
            var tweets = this.Data.Tweets.All(new string[] { "Tags", "User" }).Select(TweetViewModel.FromTweet).ToList();

            var tweetData = new MainTweetModel();
            tweetData.Tweets = tweets;
            tweetData.NewTweet = new TweetCreateModel();
            tweetData.TagToAdd = new TagShortModel();
            tweetData.ErrorMessage = errorMessage;
            tweetData.SuccessMessage = successMessage;

            return View(tweetData);
        }

        public ActionResult ReadAllTags([DataSourceRequest] DataSourceRequest request)
        {
            var list = this.Data.Tags.All().
                Select(TagShortModel.FromTag).ToArray();
            var json =
                Json(list, JsonRequestBehavior.AllowGet);

            return json;
        }

        public ActionResult PostTweet(TweetCreateModel tweet)
        {
            if (ModelState.IsValid)
            {
                var tweetToAdd = new Tweet() { Text = tweet.Text, DateCreated = DateTime.Now };
                foreach (var tag in tweet.Tags)
                {
                    var tagToAdd = this.Data.Tags.GetById(tag);
                    tweetToAdd.Tags.Add(tagToAdd);
                }

                var username = User.Identity.Name;
                var user = this.Data.Users.All().SingleOrDefault(u => u.UserName == username);
                tweetToAdd.User = user;

                this.Data.Tweets.Add(tweetToAdd);
                this.Data.SaveChanges();
                return RedirectToAction("Index", new { successMessage = "Tweet posted" });
            }

            return RedirectToAction("Index", new { errorMessage = "Tweet text out of character limit - [5, 240]" });
        }

        public ActionResult AddTag(TagShortModel tag)
        {
            if (ModelState.IsValid)
            {
                var tagToAdd = new Tag();
                tagToAdd.Name = tag.Name;
                this.Data.Tags.Add(tagToAdd);
                this.Data.SaveChanges();
                return RedirectToAction("Index", new { successMessage = "Tag added" });
            }

            return RedirectToAction("Index", new { errorMessage = "Tag text out of character limit - [2, 50]" });
        }

        public ActionResult TweetsByUser(string userId)
        {
            ApplicationUser user;
            if (string.IsNullOrEmpty(userId))
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return View("Error");
                }

                user = this.Data.Users.All(new string[] { "Tweets", "Tweets.Tags" }).SingleOrDefault(u => u.UserName == User.Identity.Name);
            }
            else
            {
                user = this.Data.Users.All(new string[] { "Tweets", "Tweets.Tags" }).SingleOrDefault(u => u.Id == userId);
            }

            return View(user);
        }

        [OutputCacheAttribute(VaryByParam = "tagId", Duration = 900)]
        public ActionResult TweetsByTag(int? tagId)
        {
            if (tagId == null)
            {
                return View("Error");
            }

            var tag = this.Data.Tags.All(new string[] { "Tweets", "Tweets.Tags" }).SingleOrDefault(t => t.Id == tagId);
            if (tag == null)
            {
                return View("Error");
            }

            return View(tag);
        }
    }
}