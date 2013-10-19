using Exam.WebApp.Controllers;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Exam.WebApp.Models;
using Exam.Models;

namespace Exam.WebApp.Areas.Administration.Controllers
{
    [Authorize(Roles="Admin")]
    public class CategoriesAdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                .Select(x => new CategoryAdminModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryAdminModel category)
        {
            if (ModelState.IsValid)
            {
                var addedCategory = new Category()
                {
                    Name = category.Name
                };

                this.Data.Categories.Add(addedCategory);

                this.Data.SaveChanges();

                category.Id = addedCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryAdminModel category)
        {
            if ((category != null) && ModelState.IsValid)
            {
                var categoryToDelete = this.Data.Categories.All().FirstOrDefault(c => c.Id == category.Id);
                foreach (var ticket in categoryToDelete.Tickets.ToList())
                {
                    foreach (var comment in ticket.Comments.ToList())
                    {
                        this.Data.Comments.Delete(comment);
                    }

                    this.Data.Tickets.Delete(ticket);
                }

                this.Data.Categories.Delete(categoryToDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryAdminModel category)
        {

            if (category != null && ModelState.IsValid)
            {
                var target = this.Data.Categories.All().FirstOrDefault(c => c.Id == category.Id);
                if (target != null)
                {
                    target.Name = category.Name;
                    this.Data.SaveChanges();
                }
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
    }
}