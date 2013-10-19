using Kendo.Mvc.UI;
using KendoHomework.Areas.Administration.Models;
using KendoHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace KendoHomework.Areas.Administration.Controllers
{
    [Authorize]
    public class BooksAdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BookGridModel book)
        {
            if (book != null)
            {

                if ((book.Title == null) || (book.Title.Length < 2))
                {
                    ModelState.AddModelError("Title", "Title should be at least 2 characters long.");
                    return Json(new[] { book }.ToDataSourceResult(request, ModelState));
                }

                if ((book.Author == null) || (book.Author.Length < 2))
                {
                    ModelState.AddModelError("Author", "Author should be at least 2 characters long.");
                    return Json(new[] { book }.ToDataSourceResult(request, ModelState));
                }

                if (book.CategoryId == 0)
                {
                    ModelState.AddModelError("Category", "Book must have category.");
                    return Json(new[] { book }.ToDataSourceResult(request, ModelState));
                }
            }

            if (book != null && ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                var bookAdded = new Book()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    WebSite = book.WebSite,
                    Description = book.Description,
                    Category = context.Categories.
                        FirstOrDefault(c => c.Id == book.CategoryId)
                };
                context.Books.Add(bookAdded);
                context.SaveChanges();
                book.CategoryName = bookAdded.Category.Name;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var context = new ApplicationDbContext();
            return Json(context.Books.Include("Category").Select(c => new BookGridModel() { Title = c.Title, Id = c.Id,
                Isbn = c.Isbn, Author = c.Author, Description=c.Description, WebSite = c.WebSite,
                CategoryId = c.Category.Id, CategoryName = c.Category.Name}).ToList().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, BookGridModel book)
        {
            if (book != null)
            {
                if ((book.Title == null) || (book.Title.Length < 2))
                {
                    ModelState.AddModelError("Title", "Title should be at least 2 characters long.");
                    return Json(new[] { book }.ToDataSourceResult(request, ModelState));
                }

                if ((book.Author == null) || (book.Author.Length < 2))
                {
                    ModelState.AddModelError("Author", "Author should be at least 2 characters long.");
                    return Json(new[] { book }.ToDataSourceResult(request, ModelState));
                }

                if (book.CategoryId == 0)
                {
                    ModelState.AddModelError("Category", "Book must have category.");
                    return Json(new[] { book }.ToDataSourceResult(request, ModelState));
                }
            }

            if (book != null && ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                var target = context.Books.FirstOrDefault(p => p.Id == book.Id);
                if (target != null)
                {
                    target.Title = book.Title;
                    target.WebSite = book.WebSite;
                    target.Isbn = book.Isbn;
                    target.Description = book.Description;
                    target.Author = book.Author;
                    target.Category = context.Categories.FirstOrDefault(c => c.Id == book.CategoryId);

                    // This is done simply for grid updating purposes.
                    book.CategoryName = target.Category.Name;
                    context.SaveChanges();
                }
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, BookGridModel book)
        {
            if (book != null)
            {
                var context = new ApplicationDbContext();
                var bookToDelete = context.Books.FirstOrDefault(c => c.Id == book.Id);
                context.Books.Remove(bookToDelete);
                context.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }
    }
}