using Kendo.Mvc.UI;
using KendoHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using KendoHomework.Areas.Administration.Models;

namespace KendoHomework.Areas.Administration.Controllers
{
    [Authorize]
    public class CategoriesAdminController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryGridModel category)
        {
            if ((category.Name == null) || (category.Name.Length < 2))
            {
                ModelState.AddModelError("Name", "Name should be at least 2 characters long.");
                return Json(new[] { category }.ToDataSourceResult(request, ModelState));
            }

            if (category != null && ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                context.Categories.Add(new Category() { Name = category.Name });
                context.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var context = new ApplicationDbContext();
            return Json(context.Categories.Select(c => new CategoryGridModel() { Name = c.Name, Id = c.Id }).ToList().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryGridModel category)
        {
            if ((category.Name == null) || (category.Name.Length < 2))
            {
                ModelState.AddModelError("Name", "Name should be at least 2 characters long.");
                return Json(new[] { category }.ToDataSourceResult(request, ModelState));
            }

            if (category != null && ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                var target = context.Categories.FirstOrDefault(p => p.Id == category.Id);
                if (target != null)
                {
                    target.Name = category.Name;
                    context.SaveChanges();
                }
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CategoryGridModel category)
        {
            if (category != null)
            {
                var context = new ApplicationDbContext();
                var categoryToDelete = context.Categories.FirstOrDefault(c => c.Id == category.Id);
                context.Books.RemoveRange(categoryToDelete.Books);
                context.SaveChanges();
                context.Categories.Remove(categoryToDelete);
                context.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetAllCategories([DataSourceRequest] DataSourceRequest request)
        {
            var context = new ApplicationDbContext();
            var rez = Json(context.Categories.Select(c => new CategoryGridModel() { Name = c.Name, Id = c.Id }).ToList(), JsonRequestBehavior.AllowGet);
            return rez;
        }
    }
}