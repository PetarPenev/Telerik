using Kendo.Mvc.UI;
using KendoHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoHomework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var categories = context.Categories.Include("Books").ToList();

            var result = context.Categories.Include("Books").ToList().Select(x => new TreeViewItemModel
            {
                Text = x.Name,
                Items = x.Books.Select(y => new TreeViewItemModel
                {
                    Text = y.Title,
                    Url = "Books/Details?id=" + y.Id
                })
                    .ToList()
            });

            return View(result);
        }
    }
}