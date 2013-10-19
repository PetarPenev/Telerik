using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.App.Controllers;
using Twitter.Data;
using Kendo.Mvc.Extensions;
using Twitter.App.Areas.Administration.Models;

namespace Twitter.App.Areas.Administration.Controllers
{
    [Authorize]
    //[Authorize(Roles="Admin")]
    public class TweetAdminController : BaseController
    {
        public TweetAdminController()
            :base(new UowData())
        {
        }

        public TweetAdminController(IUowData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var json =
                Json(this.Data.Tweets.All(new string[] { "Tags", "User" }).
                Select(TweetGridViewModel.FromTweet).ToList().ToDataSourceResult(request));

            return json;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TweetGridViewModel model)
        {
            TweetGridViewModel newModel = model;

            if (model != null && ModelState.IsValid)
            {
                var tweetInDb = this.Data.Tweets.All(new string[] { "Tags" }).SingleOrDefault(t => t.Id == model.Id);
                tweetInDb.Text = model.Text;
                tweetInDb.DateCreated = model.DateCreated;
                foreach (var tag in model.Tags)
                {
                    if (tweetInDb.Tags.SingleOrDefault(t => t.Id == tag.Id) == null)
                    {
                        var tagToAdd = this.Data.Tags.GetById(tag.Id);
                        tweetInDb.Tags.Add(tagToAdd);
                    }
                }

                List<int> tagsToRemove = new List<int>();

                foreach (var tag in tweetInDb.Tags)
                {
                    if (model.Tags.SingleOrDefault(t => t.Id == tag.Id) == null)
                    {
                        tagsToRemove.Add(tag.Id);
                    }
                }

                foreach (var id in tagsToRemove)
                {
                    var tagToRemove = tweetInDb.Tags.SingleOrDefault(t => t.Id == id);
                    tweetInDb.Tags.Remove(tagToRemove);
                }

                this.Data.SaveChanges();
            }

            return Json(new[] { newModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, TweetGridViewModel model)
        {

                var tweetToRemove = this.Data.Tweets.GetById(model.Id);
                if (tweetToRemove != null)
                {
                    this.Data.Tweets.Delete(tweetToRemove);
                    this.Data.SaveChanges();
                }

            return Json(new[] { model }.ToDataSourceResult(request));
        }
    }
}