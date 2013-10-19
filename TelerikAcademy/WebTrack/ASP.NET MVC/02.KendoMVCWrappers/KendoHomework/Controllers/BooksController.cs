using KendoHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoHomework.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var context = new ApplicationDbContext();
            var bookToDisplay = context.Books.Include("Category").
                FirstOrDefault(b => b.Id == id.Value);

            return View(bookToDisplay);

        }

        public JsonResult GetAutocompleteData(string serversideautocomplete)
        {
            serversideautocomplete = Request.QueryString["text"];
            var context = new ApplicationDbContext();
            var books = context.Books.Where(b => b.Title.Contains(serversideautocomplete) 
                || b.Author.Contains(serversideautocomplete)).
                OrderBy(b => b.Title).ThenBy(b => b.Author).Select(b => new { Title = b.Title}).ToList();


            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSearchResults(string query)
        {
            var context = new ApplicationDbContext();
            var books = context.Books.Include("Category").Where(b => b.Title.Contains(query)
                || b.Author.Contains(query)).
                OrderBy(b => b.Title).ThenBy(b => b.Author)
                .ToList();

            return View(books);
        }
    }
}